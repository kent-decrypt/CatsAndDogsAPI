using CatsAndDogs.Api.Models;
using CatsAndDogs.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatsAndDogs.Api.Controllers.v1
{
    /// <summary>
    /// Breeds Controller. Contains all of the Breeds endpoints
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BreedsController : BaseController
    {
        private readonly ICatsAndDogsBreedsServices _services;

        /// <summary>
        /// Constructor for the Breeds Controller
        /// </summary>
        /// <param name="services"></param>
        public BreedsController(ICatsAndDogsBreedsServices services)
        {
            _services = services;
        }

        /// <summary>
        /// Returns a combined paginated list of cat and dog breeds
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken, int page = 1, int limit = 20)
        {
            if (page < 1 || limit < 1)
                return BadRequest(new ErrorResponseModel { Error = "Invalid parameter", Message = "Page or Limit must be more than 1" });

            if (limit > 100)
                return BadRequest(new ErrorResponseModel { Error = "Invalid limit", Message = "Limit must not exceed 100" });

            try
            {
                var result = await _services.GetAllBreeds(cancellationToken, page, limit);

                return result.Result.Count <= 0 ? NoContent() : Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError, 
                    new ErrorResponseModel { Error = "An error occurred", Message = "Something went wrong" });
            }
        }

        /// <summary>
        /// Returns a paginated image list of cats or dogs by breed
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        [HttpGet("{breed}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetImageListByBreed(string breed, CancellationToken cancellationToken, int page = 1, int limit = 20)
        {
            if (page < 1 || limit < 1) 
                return BadRequest(new ErrorResponseModel { Error = "Invalid parameter", Message = "Page or Limit must be more than 1" });

            if(limit > 100) 
                return BadRequest(new ErrorResponseModel { Error = "Invalid limit", Message = "Limit must not exceed 100" });

            if (string.IsNullOrEmpty(breed))
                return BadRequest(new ErrorResponseModel { Error = "Breed is required", Message = "Place a breed that you want to get" });

            try
            {
                var searchResult = await _services.SearchBreed(breed, cancellationToken, page, limit);
                if(searchResult.Result.Count < 1) 
                    return NotFound();

                var result = await _services.GetImages(searchResult.Result, cancellationToken, page, limit);

                return result.Result.Count <= 0 ? NoContent() : Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ErrorResponseModel { Error = "An error occurred", Message = "Something went wrong" });
            }
        }
    }
}
