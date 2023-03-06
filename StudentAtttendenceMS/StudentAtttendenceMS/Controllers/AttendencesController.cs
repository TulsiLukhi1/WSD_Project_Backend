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
    public class AttendencesController : ControllerBase
    {
        private readonly SAContext _context;

        public AttendencesController(SAContext context)
        {
            _context = context;
        }

        // GET: api/Attendences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblAttendence>>> GetTblAttendence()
        {
            return await _context.TblAttendence.ToListAsync();
        }

        // GET: api/Attendences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblAttendence>> GetTblAttendence(int id)
        {
            var tblAttendence = await _context.TblAttendence.FindAsync(id);

            if (tblAttendence == null)
            {
                return NotFound();
            }

            return tblAttendence;
        }

        // PUT: api/Attendences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblAttendence(int id, TblAttendence tblAttendence)
        {
            if (id != tblAttendence.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblAttendence).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblAttendenceExists(id))
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

        // POST: api/Attendences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblAttendence>> PostTblAttendence(TblAttendence tblAttendence)
        {
            _context.TblAttendence.Add(tblAttendence);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblAttendence", new { id = tblAttendence.Id }, tblAttendence);
        }

        // DELETE: api/Attendences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblAttendence(int id)
        {
            var tblAttendence = await _context.TblAttendence.FindAsync(id);
            if (tblAttendence == null)
            {
                return NotFound();
            }

            _context.TblAttendence.Remove(tblAttendence);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblAttendenceExists(int id)
        {
            return _context.TblAttendence.Any(e => e.Id == id);
        }
    }
}
