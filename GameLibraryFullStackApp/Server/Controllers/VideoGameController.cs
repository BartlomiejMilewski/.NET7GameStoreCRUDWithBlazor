using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameLibraryFullStackApp.Server.Data;
using GameLibraryFullStackApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameLibraryFullStackApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideoGameController : ControllerBase
    {
        private readonly DataContext _context;

        public VideoGameController(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<VideoGame>>> GetAllVideoGames()
        {
            var list = await _context.VideoGames.OrderBy(g => g.ReleaseYear).ToListAsync();


            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<VideoGame>>> GetVideoGame(int id)
        {
            var dbVideoGame = await _context.VideoGames.FindAsync(id);
            if (dbVideoGame == null)
            {
                return NotFound("This video game does not exist !");
            }


            return Ok(dbVideoGame);
        }

        [HttpPost]
        public async Task<ActionResult<List<VideoGame>>> CreateVideoGame(VideoGame videoGame)
        {

            _context.VideoGames.Add(videoGame);
            await _context.SaveChangesAsync();

            return await GetAllVideoGames();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<VideoGame>>> UpdateVideoGame(int id, VideoGame videoGame)
        {
            var dbVideoGame = await _context.VideoGames.FindAsync(id);
            if(dbVideoGame == null)
            {
                return NotFound("This video game does not exist !");
            }

            dbVideoGame.Title = videoGame.Title;
            dbVideoGame.ReleaseYear = videoGame.ReleaseYear;
            dbVideoGame.Publisher = videoGame.Publisher;

            await _context.SaveChangesAsync();

            return await GetAllVideoGames();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<VideoGame>>> DeleteVideoGame(int id)
        {
            var dbVideoGame = await _context.VideoGames.FindAsync(id);
            if (dbVideoGame == null)
            {
                return NotFound("This video game does not exist !");
            }

            _context.VideoGames.Remove(dbVideoGame);
            await _context.SaveChangesAsync();

            return await GetAllVideoGames();
        }
    }
}

