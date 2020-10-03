using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIEventos.Repositorio;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ModeloClases;

namespace APIEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : ControllerBase
    {
        private readonly IUserRepositorio userRepositorio;
        private readonly IConfiguration configuration;

        public usersController(IUserRepositorio repositorio, IConfiguration config)
        {
            this.userRepositorio = repositorio;
            this.configuration = config;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<int>> registroDeUsuario(ModeloClases.User user)
        {
            int id = 0;
            try
            {
                User user1 = await this.userRepositorio.obtenerUsuario(user);
                if (user1 != null)
                    return StatusCode(StatusCodes.Status403Forbidden, "La cuenta con ese correo electrónico ya existe.");

                id = await this.userRepositorio.RegistrarUsuario(user);
                if (id > 0)
                    this.Ok("Usuario registrado correctamente");
            }
            catch (SqlException ex)
            {
                return StatusCode(StatusCodes.Status303SeeOther, ex.Message.ToString());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Datos inválidos");
            }
            return id;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<InicioSesionRespuesta>> inicioDeSesion(InicioSesion inicioSesion)
        {
            InicioSesionRespuesta respuesta = null;
            try
            {
                var user = await this.userRepositorio.iniciarSesion(inicioSesion);
                if (user == null)
                    return StatusCode(StatusCodes.Status400BadRequest, "Credenciales inválidas");

                respuesta = GenerarTokenJwt(user);

                this.Ok("Sesión iniciada correctamente");
            }
            catch (SqlException ex)
            {
                return StatusCode(StatusCodes.Status303SeeOther, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return respuesta;
        }

        private InicioSesionRespuesta GenerarTokenJwt(User login)
        {
            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:ClaveSecreta"]));
            var credenciales = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);
            var titulo = new JwtHeader(credenciales);
            var info = new[]
            {
                new Claim("nombre", login.firstName),
                new Claim("apellido", login.lastName),
                new Claim("email", login.email),
                new Claim(JwtRegisteredClaimNames.Email, login.email)
            };
            var cargaJwt = new JwtPayload(
                issuer: configuration["JWT:Isuser"],
                audience: configuration["JWT:Audience"],
                claims: info,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddHours(24)
            );
            var token = new JwtSecurityToken(titulo, cargaJwt);
            InicioSesionRespuesta inicioSesionRespuesta = new InicioSesionRespuesta();
            inicioSesionRespuesta.id = login.id.ToString();
            inicioSesionRespuesta.firstName = login.firstName;
            inicioSesionRespuesta.lastName = login.lastName;
            inicioSesionRespuesta.token = new JwtSecurityTokenHandler().WriteToken(token);
            return inicioSesionRespuesta;
        }
    }
}