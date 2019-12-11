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
    public class CalificacionController : ControllerBase
    {
        private readonly DocenteContext _context;
        public CalificacionController(DocenteContext context)
        {
            _context = context;
        }

        // GET: api/Task
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calificaciones>>> GetTaskItems()
        {
        return await _context.Calificaciones.ToListAsync();
        }

       /* [HttpGet("ActivoAdministrativo")]
        public async Task<ActionResult<IEnumerable<Calificaciones>>> GetTaskActivas()
        {
            return await _context.Calificaciones.Where(p=>p.Estado=="ACTIVO" & p.Cargo!="DOCENTE").ToListAsync();
        }*/

        [HttpGet("{identificacion}")]
        public async Task<ActionResult<Calificaciones>> GetTaskItem(string identificacion)
        {
            var lista = await _context.Calificaciones.Where(p=>p.Id_DocenteCalificado==identificacion).ToListAsync();
            int id=0;
            
            foreach (var item in lista)
            {
                id = item.Id;
            }
            
            var user = await _context.Calificaciones.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
        
        /*
        public async Task<ActionResult<Calificaciones>> GetTaskItem(string id)
        {
            var calificacion = await _context.Calificaciones.FindAsync(id);
            if (calificacion == null)
            {
                return NotFound();
            }
            return calificacion;
        }*/

        // POST: api/Task
        [HttpPost]
        public async Task<ActionResult<Calificaciones>> PostTaskItem(Calificaciones item)
        {
            _context.Calificaciones.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTaskItem), new { id = item.Id }, item);
        }

        // PUT: api/Task/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskItem(int id, Calificaciones item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskItem(int id)
        {
            var Calificaciones = await
            _context.Calificaciones.FindAsync(id);
            if (Calificaciones == null)
            {
                return NotFound();
            }
            _context.Calificaciones.Remove(Calificaciones);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
    }
}