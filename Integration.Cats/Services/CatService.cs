using Integration.Cats.Api.Interfaces;
using Integration.Cats.Api.Models;
using Integration.Cats.Services;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Integration.Cats.Api.Services
{
    /// <summary>
    /// Service class for the Cat Service API Integration
    /// </summary>
    public class CatService : BaseService, ICatService
    {
        /// <summary>
        /// Constructor for the Cats Service API
        /// </summary>
        /// <param name="configurations"></param>
        public CatService(IOptions<Configurations> configurations) : base(configurations) { }

        /// <summary>
        /// Retrieves all of the breeds 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<Cat>> GetBreeds(CancellationToken cancellationToken, int page = 1, int limit = 20)
        {
            var result = await Get($"breeds?page={page - 1}&limit={limit}");
            if (result.Length <= 10) return null;

            var responseData = JsonConvert.DeserializeObject<List<Cat>>(result, new JsonSerializerSettings
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            });

            return responseData;
        }

        /// <summary>
        /// Search for the cat breed
        /// </summary>
        /// <param name="breed"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public async Task<List<CatSearchResult>> SearchBreed(string breed, CancellationToken cancellationToken, int page = 1, int limit = 20)
        {
            var result = await Get($"breeds/search?q={breed}&page={page - 1}&limit={limit}");
            if (result.Length <= 10) return null;

            var responseData = JsonConvert.DeserializeObject<List<CatSearchResult>>(result, new JsonSerializerSettings
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            });

            return responseData;            
        }

        /// <summary>
        /// Retrieves list of images by using the breedId
        /// </summary>
        /// <param name="breed"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public async Task<List<CatImage>> GetCatImagesByBreedId(string breedId, CancellationToken cancellationToken, int page = 1, int limit = 20)
        {
            var result = await Get($"images/search?breed_id={breedId}&page={page - 1}&limit={limit}");
            if (result.Length <= 10) return null;

            var responseData = JsonConvert.DeserializeObject<List<CatImage>>(result, new JsonSerializerSettings
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            });

            return responseData;
        }

        /// <summary>
        /// Retrieves the details by using the image Id
        /// </summary>
        /// <param name="imageId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CatImage> GetCatImageByImageId(string imageId, CancellationToken cancellationToken)
        {
            var result = await Get($"images/{imageId}");
            if (result.Length <= 10) return null;

            var responseData = JsonConvert.DeserializeObject<CatImage>(result, new JsonSerializerSettings
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            });

            return responseData;
        }

        /// <summary>
        /// Retrieves list of random Cat Images
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public async Task<List<CatImage>> GetRandomCatImages(CancellationToken cancellationToken, int page = 1, int limit = 20)
        {
            var result = await Get($"images/search?page={page - 1}&limit={limit}");
            if (result.Length <= 10) return new List<CatImage>();
            var responseData = JsonConvert.DeserializeObject<List<CatImage>>(result, new JsonSerializerSettings
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            });

            return responseData;            
        }
    }
}
