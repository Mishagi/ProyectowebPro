using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoWeb.Models;

namespace ProyectoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PreguntaController : ControllerBase
    {
        private readonly DocenteContext _context;
        public PreguntaController(DocenteContext context)
        {
            _context = context;
            if (_context.Preguntas.Count() == 0)
            {
                // Crea un nuevo item si la coleccion esta vacia,
                // lo que significa que no puedes borrar todos los Items.
                _context.Preguntas.Add(new Pregunta { Descripcion = "Planea y orienta su gestion con base en "+
                                                    "la mision y las politicas institucionales",
                                                    Categoria= "RESPONSABILIDAD", Estado = true});
                _context.Preguntas.Add(new Pregunta { Descripcion = "Propende por el buen uso de los beneficios de la universidad",
                                                    Categoria= "RESPONSABILIDAD", Estado = true});
                _context.Preguntas.Add(new Pregunta { Descripcion = "Reconoce los limites de su autoridad y actua dentro de ellos",
                                                    Categoria= "RESPONSABILIDAD", Estado = true});
                _context.Preguntas.Add(new Pregunta { Descripcion = "Cumple a cabalidad el tiempo de vinculacion laboral o contractual con la universidad",
                                                    Categoria= "RESPONSABILIDAD", Estado = true});

                _context.Preguntas.Add(new Pregunta { Descripcion = "Atiende oportunamente sus compromisos y obligaciones",
                                                    Categoria= "PUNTUALIDAD Y CUMPLIMIENTO", Estado = true});
                _context.Preguntas.Add(new Pregunta { Descripcion = "Asiste puntualmente a las reuniones que se le cita",
                                                    Categoria= "PUNTUALIDAD Y CUMPLIMIENTO", Estado = true});
                _context.Preguntas.Add(new Pregunta { Descripcion ="Atiende diligentemente las soluciones de los estudiantes, profesores y empleados",
                                                    Categoria= "PUNTUALIDAD Y CUMPLIMIENTO", Estado = true});

                _context.Preguntas.Add(new Pregunta { Descripcion = "Faculta el trabajo de los demas",
                                                    Categoria= "EFICIENCIA", Estado = true});                                    
                _context.Preguntas.Add(new Pregunta { Descripcion = "Administra los recursos con equidad y eficiencia",
                                                    Categoria= "EFICIENCIA ", Estado = true});
                _context.Preguntas.Add(new Pregunta { Descripcion = "Propone planes, politicas y acciones coherentes con la mision institucional",
                                                    Categoria= "EFICIENCIA", Estado = true});
                _context.Preguntas.Add(new Pregunta { Descripcion = "Ejecuta acciones de acuerdo con los planes y politicas previamente definidos",
                                                    Categoria= "EFICIENCIA", Estado = true});   

                _context.Preguntas.Add(new Pregunta { Descripcion = "Es creativo en interpretacion de situaciones en la busqueda de eduaciones",
                                                    Categoria= "RELACIONES INTERPERSONALES", Estado = true});   
                _context.Preguntas.Add(new Pregunta { Descripcion = "Propicia el ambiente de confianza, colaboracion y convivencia en el grupo de trabajo",
                                                    Categoria= "RELACIONES INTERPERSONALES", Estado = true});   
                _context.Preguntas.Add(new Pregunta { Descripcion = "Es receptivo y tolerante ante la critica",
                                                    Categoria= "RELACIONES INTERPERSONALES", Estado = true});       
                _context.Preguntas.Add(new Pregunta { Descripcion = "Distingue y separa los problemas organizacionales de las personas",
                                                    Categoria= "RELACIONES INTERPERSONALES", Estado = true});                                                       
                _context.SaveChanges();
            }
        }

        // GET: api/Pregunta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pregunta>>> GetTaskItems()
        {
        return await _context.Preguntas.ToListAsync();
        }

        // GET: api/Pregunta/Activas
        [HttpGet("Activas")]
        public async Task<ActionResult<IEnumerable<Pregunta>>> GetTaskActivas()
        {
            return await _context.Preguntas.Where(p=>p.Estado==true).ToListAsync();
        }


        // GET: api/Pregunta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pregunta>> GetTaskItem(int id)
        {
            var pregunta = await _context.Preguntas.FindAsync(id);
            if (pregunta == null)
            {
                return NotFound();
            }
            return pregunta;
        }

        // POST: api/Pregunta
        [HttpPost]
        public async Task<ActionResult<Pregunta>> PostTaskItem(Pregunta item)
        {
            _context.Preguntas.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTaskItem), new { id = item.Id }, item);
        }

        // PUT: api/Pregunta/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskItem(int id, Pregunta item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Pregunta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskItem(int id)
        {
            var Pregunta = await
            _context.Preguntas.FindAsync(id);
            if (Pregunta == null)
            {
                return NotFound();
            }
            _context.Preguntas.Remove(Pregunta);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}