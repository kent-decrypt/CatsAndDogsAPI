using CatsAndDogs.Api.Models;
using CatsAndDogs.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatsAndDogs.Api.Controllers.v1
{
    /// <summary>
    /// Images Controller. Contains all of the Image endpoints
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ImagesController : BaseController
    {
        private readonly ICatsAndDogsImageService _iCatsAndDogsImageService;

        /// <summary>
        /// Constructor for the ImagesController 
        /// </summary>
        /// <param name="iCatsAndDogsImageService"></param>
        public ImagesController(ICatsAndDogsImageService iCatsAndDogsImageService) 
        {
            _iCatsAndDogsImageService = iCatsAndDogsImageService;
        }

        /// <summary>
        /// Returns an image of the cat or dog by image ID
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        [HttpGet("{imageId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Index(string imageId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(imageId))
                return BadRequest(new ErrorResponseModel { Error = "ImageId is required", Message = "Place an image id that you want to get" });

            try
            {
                var result = await _iCatsAndDogsImageService.GetImage(imageId, cancellationToken);

                return Ok(result);
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
