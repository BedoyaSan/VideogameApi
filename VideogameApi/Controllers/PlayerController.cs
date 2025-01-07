using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideogameApi.Models;

namespace VideogameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        static private List<Player> players = new List<Player> {
            new Player {
                Id = 1,
                Level = 0,
                Name = "Spencer",
                Score = 0,
            },
            new Player {
                Id = 2,
                Level = 0,
                Name = "Harold",
                Score = 0,
            },
            new Player {
                Id = 3,
                Level = 0,
                Name = "Jacob",
                Score = 0,
            },
        };

        [HttpGet]
        public ActionResult<List<Player>> GetPlayers()
        {
            return Ok(players);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Player> GetPlayerById(int id) {
            Player? player = players.FirstOrDefault(x => x.Id == id);

            if (player == null) {
                return NotFound(); 
            }

            return Ok(player);
        }

        [HttpPost]
        public ActionResult<Player> AddPlayer(Player newPlayer)
        {
            if (newPlayer == null)
                return BadRequest();

            newPlayer.Id = players.Max(x => x.Id) + 1;

            players.Add(newPlayer);
            return CreatedAtAction(nameof(GetPlayerById), new { id = newPlayer.Id }, newPlayer);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdatePlayer(int id, Player updatedPlayer)
        {
            Player? player = players.FirstOrDefault(x => x.Id == id);

            if (player == null) {
                return NotFound();
            }

            player.Level = updatedPlayer.Level;
            player.Name = updatedPlayer.Name;
            player.Score = updatedPlayer.Score;
            
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletePlayer(int id) {
            Player? player = players.FirstOrDefault(x => x.Id == id);

            if (player == null)
            {
                return NotFound();
            }

            players.Remove(player);
            return NoContent();
        }
    }
}
