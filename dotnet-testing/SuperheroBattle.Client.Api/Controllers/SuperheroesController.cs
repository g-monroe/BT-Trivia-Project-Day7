using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperheroBattle.Core.Entities;
using SuperheroBattle.DataAccessHandlers;

namespace SuperheroBattle.Client.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperheroesController : ControllerBase
    {
        private readonly SuperheroBattleContext _context;

        public SuperheroesController(SuperheroBattleContext context)
        {
            _context = context;
        }

        // GET: api/Superheroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Superhero>>> GetSuperheroes()
        {
            return await _context.Superheroes
                                 .Include(s => s.SuperheroAbilities)
                                 .ThenInclude(sa => sa.Ability).ToListAsync();
        }

        // GET: api/Superheroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Superhero>> GetSuperhero(int id)
        {
            var superhero = await _context.Superheroes.FindAsync(id);

            if (superhero == null)
            {
                return NotFound();
            }

            return superhero;
        }

        // GET: api/Superheroes/5
        [HttpGet("abilities")]
        public async Task<ActionResult<IEnumerable<SuperheroAbility>>> GetSuperheroAbilities()
        {
            var superheroAbilities = await _context.SuperheroAbilities.ToListAsync();

            if (superheroAbilities == null)
            {
                return NotFound();
            }

            return superheroAbilities;
        }

        // PUT: api/Superheroes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuperhero(int id, Superhero superhero)
        {
            if (id != superhero.SuperheroID)
            {
                return BadRequest();
            }

            _context.Entry(superhero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuperheroExists(id))
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

        // POST api/values
        [HttpPut("abilities")]
        public async Task<ActionResult<IEnumerable<Superhero>>> LinkSuperheroesAndAbilities([FromBody] IEnumerable<SuperheroAbility> superheroAbilities)
        {
            _context.SuperheroAbilities.AddRange(superheroAbilities);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSuperheroAbilities", null);
        }

        // POST: api/Superheroes
        [HttpPost]
        public async Task<ActionResult<Superhero>> PostSuperhero(Superhero superhero)
        {
            _context.Superheroes.Add(superhero);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSuperhero", new { id = superhero.SuperheroID }, superhero);
        }

        // DELETE: api/Superheroes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Superhero>> DeleteSuperhero(int id)
        {
            var superhero = await _context.Superheroes.FindAsync(id);
            if (superhero == null)
            {
                return NotFound();
            }

            _context.Superheroes.Remove(superhero);
            await _context.SaveChangesAsync();

            return superhero;
        }

        private bool SuperheroExists(int id)
        {
            return _context.Superheroes.Any(e => e.SuperheroID == id);
        }
    }
}
