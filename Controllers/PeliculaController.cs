using Microsoft.AspNetCore.Mvc;
using Movies.Data.Repositories;
using Movies.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        IPeliculasepository _repository;
        public PeliculaController(IPeliculasepository repository)
        {
            _repository = repository;
        }
        // GET: api/<PeliculaController>
        [HttpGet("MostrarPeliculasEnEstreno")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500, "Error Interno");
            }
        }


        // POST api/<PeliculaController>
        [HttpPost("CrearPelicula")]
        public IActionResult Post([FromBody] Pelicula value)
        {
            try
            {
                if (IsValid(value))
                {
                    _repository.Create(value);
                    return Ok("Pelicula Creada con exito!!");
                }
                else
                {
                    return BadRequest("Datos Incorrectos o Incompletos");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Error Interno");
            }
        }

        private bool IsValid(Pelicula value)
        {
            return string.IsNullOrEmpty(value.Titulo) && string.IsNullOrEmpty(value.Director) && value.Anio != 0 && value.IdGenero > 0;
        }

        // PUT api/<PeliculaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Pelicula value)
        {
            try
            {
                _repository.Update(id);
                return Ok("Cartelera Deshabilitada");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error Interno");
            }
        }
    }
}
