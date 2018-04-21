using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using portfeuilleService.Data;
using portfeuilleService.Models;

namespace portfeuilleService.Controllers
{
    [Produces("application/json")]
    [Route("api/Personnes")]
    public class PersonnesController : Controller
    {
        private readonly PortfeuilleContext _context;

        public PersonnesController(PortfeuilleContext context)
        {
            _context = context;
        }

        // GET: api/Personnes
        [HttpGet]
        public IEnumerable<Personne> GetPersonnes()
        {
            return _context.Personnes;
        }

        // GET: api/Personnes/email
        [HttpGet("{login}")]
        public async Task<IActionResult> GetPersonne([FromRoute] String login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personne = await _context.Personnes.SingleOrDefaultAsync(m => m.Email.Equals(login));
            if (personne == null)
            {
                return Ok(false);
            }
            return Ok(true);
        }

        // GET: api/Personnes/email/password
        [HttpGet("{login}/{pass}")]
        public async Task<IActionResult> GetPersonne([FromRoute] String login, [FromRoute] String pass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personne = await _context.Personnes.SingleOrDefaultAsync(m => m.Email.Equals(login));
            if (personne == null)
            {
                return NotFound();
            }

            if(!personne.Pass.Equals(pass))
            {
                return NotFound();
            }
            return Ok(personne);
        }

        // PUT: api/Personnes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonne([FromRoute] int id, [FromBody] Personne personne)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personne.PersonneID)
            {
                return BadRequest();
            }

            _context.Entry(personne).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonneExists(id))
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

        // POST: api/Personnes
        [HttpPost]
        public async Task<IActionResult> PostPersonne([FromBody] Personne personne)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Personnes.Add(personne);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonne", new { id = personne.PersonneID }, personne);
        }

        // DELETE: api/Personnes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonne([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personne = await _context.Personnes.SingleOrDefaultAsync(m => m.PersonneID == id);
            if (personne == null)
            {
                return NotFound();
            }

            _context.Personnes.Remove(personne);
            await _context.SaveChangesAsync();

            return Ok(personne);
        }

        private bool PersonneExists(int id)
        {
            return _context.Personnes.Any(e => e.PersonneID == id);
        }
    }
}