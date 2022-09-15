using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using schollApp.Context;
using schollApp.Models;

namespace schollApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriasController : ControllerBase
    {
        private readonly AppDBContext _context;

        public MateriasController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Materias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Materia>>> Getmateria()
        {
          if (_context.materia == null)
          {
              return NotFound();
          }
            return await _context.materia.ToListAsync();
        }

        // GET: api/Materias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Materia>> GetMateria(int id)
        {
          if (_context.materia == null)
          {
              return NotFound();
          }
            var materia = await _context.materia.FindAsync(id);

            if (materia == null)
            {
                return NotFound();
            }

            return materia;
        }

        // PUT: api/Materias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMateria(int id, Materia materia)
        {
            if (id != materia.id_materia)
            {
                return BadRequest();
            }

            _context.Entry(materia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MateriaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Materias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Materia>> PostMateria(Materia materia)
        {
          if (_context.materia == null)
          {
              return Problem("Entity set 'AppDBContext.materia'  is null.");
          }
            _context.materia.Add(materia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMateria", new { id = materia.id_materia }, materia);
        }

        // DELETE: api/Materias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMateria(int id)
        {
            if (_context.materia == null)
            {
                return NotFound();
            }
            var materia = await _context.materia.FindAsync(id);
            if (materia == null)
            {
                return NotFound();
            }

            _context.materia.Remove(materia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MateriaExists(int id)
        {
            return (_context.materia?.Any(e => e.id_materia == id)).GetValueOrDefault();
        }
    }
}
