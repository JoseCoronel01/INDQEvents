using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using APIEventos.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class imagesController : ControllerBase
    {
        private readonly IEventRepositorio eventRepositorio;

        public imagesController(IEventRepositorio repositorio)
        {
            this.eventRepositorio = repositorio;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<string>>> GetImagenes(string fileName = null)
        {
            List<string> imagenes = null;
            try
            {
                var eventos = await this.eventRepositorio.listadoEventos();
                if (eventos != null)
                {
                    if (fileName != null)
                        eventos = eventos.Where(a => a.image == fileName).ToList();
                    foreach (var item in eventos)
                    {
                        if (imagenes == null) imagenes = new List<string>();
                        imagenes.Add(item.image);
                    }
                }
                if (imagenes == null)
                    return StatusCode(StatusCodes.Status404NotFound, "Imagen no encontrada");
            }
            catch (SqlException ex)
            {
                return StatusCode(StatusCodes.Status303SeeOther, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return imagenes;
        }
    }
}