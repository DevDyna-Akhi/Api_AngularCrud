using Api_AngularCrud.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.EntityFrameworkCore;

namespace Api_AngularCrud.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly CandidateDbContext _context;

        public CandidateController(CandidateDbContext context)
        {
            _context = context;
        }
        // GET: api/Candidate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidate>>> Getcandidate()
        {
            if (_context.candidates == null)
            {
                return NotFound();
            }
            return await _context.candidates.ToListAsync();
        }
        // GET: api/Candidate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Candidate>> GetCandidate(int id)
        {
            if (_context.candidates == null)
            {
                return NotFound();
            }
            var courses = await _context.candidates.FindAsync(id);

            if (courses == null)
            {
                return NotFound();
            }

            return courses;
        }

        // PUT: api/Candidate/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidate(int id, Candidate candidate)
        {
            if (id != candidate.Id)
            {
                return BadRequest();
            }

            _context.Entry(candidate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoursesExists(id))
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

        // POST: api/Candidate
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Candidate>> PostCandidate(Candidate candidate)
        {
            if (_context.candidates == null)
            {
                return Problem("Entity set 'CandidateDbContext.candidates'  is null.");
            }
            _context.candidates.Add(candidate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCandidate", new { id = candidate.Id }, candidate);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            if (_context.candidates == null)
            {
                return NotFound();
            }
            var courses = await _context.candidates.FindAsync(id);
            if (courses == null)
            {
                return NotFound();
            }

            _context.candidates.Remove(courses);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoursesExists(int id)
        {
            return (_context.candidates?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}



