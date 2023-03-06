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
    public class StudentsController : ControllerBase
    {
        private readonly SAContext _context;

        public StudentsController(SAContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblStudent>>> GetTblStudents()
        {
            return await _context.TblStudents.ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblStudent>> GetTblStudent(int id)
        {
            var tblStudent = await _context.TblStudents.FindAsync(id);

            if (tblStudent == null)
            {
                return NotFound();
            }

            return tblStudent;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblStudent(int id, TblStudent tblStudent)
        {
            if (id != tblStudent.StudentID)
            {
                return BadRequest();
            }

            _context.Entry(tblStudent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblStudentExists(id))
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

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblStudent>> PostTblStudent(TblStudent tblStudent)
        {
            _context.TblStudents.Add(tblStudent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblStudent", new { id = tblStudent.StudentID }, tblStudent);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblStudent(int id)
        {
            var tblStudent = await _context.TblStudents.FindAsync(id);
            if (tblStudent == null)
            {
                return NotFound();
            }

            _context.TblStudents.Remove(tblStudent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblStudentExists(int id)
        {
            return _context.TblStudents.Any(e => e.StudentID == id);
        }
    }
}
