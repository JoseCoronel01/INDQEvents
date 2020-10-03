using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using str = ModeloClases;
using APIEventos.Repositorio;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace APIEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //Esta línea de codigo valida el acceso por token cuando la persona se loguea.
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class eventsController : ControllerBase
    {
        private readonly IEventRepositorio eventRepositorio;

        public eventsController(IEventRepositorio repositorio)
        {
            this.eventRepositorio = repositorio;
        }

        [HttpPost]
        public async Task<ActionResult<string>> nuevoEvento(str.Event evento)
        {
            string id = string.Empty;
            try
            {
                //if (UsuarioLogueado() == false)
                //    return StatusCode(StatusCodes.Status401Unauthorized, "Acceso denegado");

                if (DateTime.Parse(evento.date) < DateTime.UtcNow)
                    return StatusCode(StatusCodes.Status303SeeOther, "La Fecha del evento no debe de ser menor al día de hoy.");
                id = await this.eventRepositorio.nuevoEvento(evento);
                return Ok("Evento registrado correctamente con id: " + id);
            }
            catch (SqlException ex)
            {
                return StatusCode(StatusCodes.Status303SeeOther, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Datos inválidos.");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<str.ListadoEventos>>> listadoEventos(int? page = null, 
            int? limit = null, 
            decimal? lat = null, 
            decimal? ing = null, string titulo = null)
        {
            List<str.ListadoEventos> listadoEventos = null;
            try
            {
                var list = await this.eventRepositorio.paginacionEventos();
                if (page != null)
                    list = list.Where(a => a.page == page).ToList();
                if (limit != null)
                    list = list.Take((int)limit).ToList();
                foreach (var item in list)
                {
                    if (listadoEventos == null) listadoEventos = new List<str.ListadoEventos>();
                    var aux = list.Select(a => a.items[0]).First();
                    if (aux.location[0] == lat || aux.location[1] == ing || aux.title == titulo)
                        listadoEventos.Add(item);
                }
                if (listadoEventos.Count == 0)
                    listadoEventos.AddRange(list);
                return listadoEventos;
            }
            catch (SqlException ex)
            {
                return StatusCode(StatusCodes.Status303SeeOther, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los eventos " + ex.Message);
            }
        }        
    }
}