using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CA2_backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ArtistController : ControllerBase
	{
		private readonly DataContext _dataContext;

		public ArtistController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		[HttpGet]
		public async Task<ActionResult<List<Artist>>> Get()
		{
			return Ok(await _dataContext.Artists.ToListAsync());
		}


		[HttpGet("{artistName}")]
		public async Task<ActionResult<Artist>> GetArtistByName(string artistName)
		{
			var artist = await _dataContext.Artists.FirstOrDefaultAsync(a => a.artistName == artistName);

			if (artist == null)
			{
				return NotFound();
			}

			return artist;
		}



	}
}
