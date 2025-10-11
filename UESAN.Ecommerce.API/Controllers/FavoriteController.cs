using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Ecommerce.CORE.Core.DTOs;
using UESAN.Ecommerce.CORE.Core.Interfaces;

namespace UESAN.Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;

        public FavoriteController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFavorites()
        {
            var favorites = await _favoriteService.GetFavorites();
            return Ok(favorites);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFavoriteById(int id)
        {
            var favorite = await _favoriteService.GetFavoriteById(id);
            if (favorite == null)
            {
                return NotFound();
            }
            return Ok(favorite);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavorite(int id)
        {
            var favorite = await _favoriteService.GetFavoriteById(id);
            if (favorite == null)
            {
                return NotFound();
            }
            await _favoriteService.DeleteFavorite(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFavorite([FromBody] FavoriteCreateDTO favoriteCreateDTO)
        {
            if (favoriteCreateDTO == null)
            {
                return BadRequest();
            }
            var newFavoriteId = await _favoriteService.InsertFavorite(favoriteCreateDTO);
            return CreatedAtAction(nameof(GetFavoriteById),
                new { id = newFavoriteId }, favoriteCreateDTO);
        }



    }
}
