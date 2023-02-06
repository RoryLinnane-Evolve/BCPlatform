using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BCPlatformWEB.Data;
using BCPlatformLib.Models;
using BCPlatformLib.MobileViewModels;

namespace BCPlatformWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Stats/AppGetGames
        [HttpGet("AppGetGames")]
        public async Task<ActionResult<IEnumerable<GameViewModel>>> AppGetGames()
        {
            List<GameViewModel> games = new();
            if (_context.Clubs != null)
            {
                

                foreach (var game in await _context.Games.ToListAsync())
                {
                    games.Add(new GameViewModel()
                    {
                        HomeTeam = _context.Clubs.Find(game.HomeTeam).Name,
                        AwayTeam = _context.Clubs.Find(game.AwayTeam).Name,
                        _DateTime = game._DateTime,
                        ScoresheetName = game.ScoresheetName,
                        Id = game.Id,
                        Info = game.Info,
                        Location = game.Location
                    });
                }
                return games;
            }
            else
            {
                return NotFound();
            }
        }
        // GET: api/Stats/FromGame/1
        [HttpGet("FromGame/{GameId}")]
        public async Task<ActionResult<IEnumerable<Statline>>> StatsFromGameId(Guid GameId)
        {
            if (_context.Stats == null)
            {
                return NotFound();
            }
            return await _context.Stats.Where(x=>x.GameId==GameId).ToListAsync();
        }

        // PUT: api/Stats/UpdateRange
        [HttpPut("UpdateRange")]
        public async Task<IActionResult> UpdateStats(List<Statline> statlines)
        {
            _context.Stats.UpdateRange(statlines);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // PUT: api/Stats/AddRange
        [HttpPut("AddRange")]
        public async Task<IActionResult> AddStats(List<Statline> statlines)
        {
            await _context.Stats.AddRangeAsync(statlines);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // GET: api/Stats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Statline>>> GetStats()
        {
          if (_context.Stats == null)
          {
              return NotFound();
          }
            return await _context.Stats.ToListAsync();
        }

        // GET: api/Stats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Statline>> GetStatline(Guid id)
        {
          if (_context.Stats == null)
          {
              return NotFound();
          }
            var statline = await _context.Stats.FindAsync(id);

            if (statline == null)
            {
                return NotFound();
            }

            return statline;
        }

        // PUT: api/Stats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatline(Guid id, Statline statline)
        {
            if (id != statline.Id)
            {
                return BadRequest();
            }

            _context.Entry(statline).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatlineExists(id))
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

        // POST: api/Stats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Statline>> PostStatline(Statline statline)
        {
          if (_context.Stats == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Stats'  is null.");
          }
            _context.Stats.Add(statline);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatline", new { id = statline.Id }, statline);
        }

        // DELETE: api/Stats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatline(Guid id)
        {
            if (_context.Stats == null)
            {
                return NotFound();
            }
            var statline = await _context.Stats.FindAsync(id);
            if (statline == null)
            {
                return NotFound();
            }

            _context.Stats.Remove(statline);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatlineExists(Guid id)
        {
            return (_context.Stats?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
