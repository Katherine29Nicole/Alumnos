using KNFU110924.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KNFU110924.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        //Declaracion de una lista  estatica  de objetos
        //"Alumnos" para almacenar clientes
        static List<Alumno> alumnos = new List<Alumno>();

        //Definicion de un metodo HTTP Get
        //que devuelve una coleccion de alumnos
        [HttpGet]
        public IEnumerable<Alumno> Get()
        {
            return alumnos;
        }

        //Definicion de un metodo HTTP Get
        //que recibe un Id como parametro y devuelve un alumno especifico
        [HttpGet("{id}")]
        public Alumno Get(int id)
        {
            var alumno = alumnos.FirstOrDefault(a => a.Id == id);
            return alumno;
        }

        // Definicion de un metodo Http Post
        [HttpPost]
        public IActionResult Post([FromBody] Alumno alumno)
        {
            alumnos.Add(alumno);
            return Ok();
        }

        // Definicion de un metodo HTTP PUT
        //para actualizar un alumno existente en la lista por su ID
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Alumno alumno)
        {
            var existingAlumno = alumnos.FirstOrDefault(a => a.Id == id);
            if (existingAlumno != null)
            {
                existingAlumno.Nombre = alumno.Nombre;
                existingAlumno.Apellido = alumno.Apellido;
                existingAlumno.Edad = alumno.Edad;
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // Definicion de un metodo HTTP DELETE
        //para eliminar un alumno por su ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingAlumno = alumnos.FirstOrDefault(a => a.Id == id);
            if (existingAlumno != null)
            {
                alumnos.Remove(existingAlumno);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
    

