using CatsAndDogs.Api.Models;
using CatsAndDogs.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatsAndDogs.Api.Controllers.v1
{
    /// <summary>
    /// List Controller. Contains all of the List endpoints
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ListController : BaseController
    {
        private readonly ICatsAndDogsListService _iCatsAndDogsList;

        /// <summary>
        /// Constructor for the ListController 
        /// </summary>
        /// <param name="iCatsAndDogsList"></param>
        public ListController(ICatsAndDogsListService iCatsAndDogsList) 
        {
            _iCatsAndDogsList = iCatsAndDogsList;
        }

        /// <summary>
        /// Returns the combined paginated list of cat and dog breeds
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetList(CancellationToken cancellationToken, int page = 1, int limit = 20)
        {
            if (page < 1 || limit < 1)
                return BadRequest(new ErrorResponseModel { Error = "Invalid parameter", Message = "Page or Limit must be more than 1" });

            if (limit > 100)
                return BadRequest(new ErrorResponseModel { Error = "Invalid limit", Message = "Limit must not exceed 100" });

            try
            {
                var result = await _iCatsAndDogsList.GetList(cancellationToken, page, limit);

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
