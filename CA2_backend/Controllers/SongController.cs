using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CA2_backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SongController : ControllerBase
	{

		private readonly DataContext _dataContext;
		public SongController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		[HttpGet]
		public async Task<ActionResult<List<Songs>>> Get()
		{
			return Ok(await _dataContext.Songs.ToListAsync());
		}

		[HttpGet("{songName}")]
		public async Task<ActionResult<Songs>> GetSongByName(string songName)
		{
			var song = await _dataContext.Songs.FirstOrDefaultAsync(s => s.songName == songName);

			if (song == null)
			{
				return NotFound();
			}

			return Ok(song);
		}


	}
}
