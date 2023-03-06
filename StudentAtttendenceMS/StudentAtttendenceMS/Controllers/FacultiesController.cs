using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAtttendenceMS.Model;

namespace StudentAtttendenceMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultiesController : ControllerBase
    {
        private readonly SAContext _context;

        public FacultiesController(SAContext context)
        {
            _context = context;
        }

        // GET: api/Faculties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblFaculty>>> GetTblFaculty()
        {
            return await _context.TblFaculty.ToListAsync();
        }

        // GET: api/Faculties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblFaculty>> GetTblFaculty(int id)
        {
            var tblFaculty = await _context.TblFaculty.FindAsync(id);

            if (tblFaculty == null)
            {
                return NotFound();
            }

            return tblFaculty;
        }

        // PUT: api/Faculties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblFaculty(int id, TblFaculty tblFaculty)
        {
            if (id != tblFaculty.FacultyID)
            {
                return BadRequest();
            }

            _context.Entry(tblFaculty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblFacultyExists(id))
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

        // POST: api/Faculties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblFaculty>> PostTblFaculty(TblFaculty tblFaculty)
        {
            _context.TblFaculty.Add(tblFaculty);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblFaculty", new { id = tblFaculty.FacultyID }, tblFaculty);
        }

        // DELETE: api/Faculties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblFaculty(int id)
        {
            var tblFaculty = await _context.TblFaculty.FindAsync(id);
            if (tblFaculty == null)
            {
                return NotFound();
            }

            _context.TblFaculty.Remove(tblFaculty);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblFacultyExists(int id)
        {
            return _context.TblFaculty.Any(e => e.FacultyID == id);
        }
    }
}
