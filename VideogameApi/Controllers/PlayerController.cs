using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideogameApi.Data;
using VideogameApi.Models;

namespace VideogameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController(PlayerDbContext context) : ControllerBase
    {
        private readonly PlayerDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<List<Player>>> GetPlayers()
        {
            return Ok(await _context.Players.ToListAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Player>> GetPlayerById(int id) {
            Player? player = await _context.Players.FindAsync(id);

            if (player == null) {
                return NotFound(); 
            }

            return Ok(player);
        }

        [HttpPost]
        public async Task<ActionResult<Player>> AddPlayer(Player newPlayer)
        {
            if (newPlayer == null)
                return BadRequest();

            _context.Players.Add(newPlayer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPlayerById), new { id = newPlayer.Id }, newPlayer);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdatePlayer(int id, Player updatedPlayer)
        {
            Player? player = await _context.Players.FindAsync(id);

            if (player == null) {
                return NotFound();
            }

            player.Level = updatedPlayer.Level;
            player.Name = updatedPlayer.Name;
            player.Score = updatedPlayer.Score;

            await _context.SaveChangesAsync();
            
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletePlayer(int id) {
            Player? player = await _context.Players.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            _context.Players.Remove(player);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
