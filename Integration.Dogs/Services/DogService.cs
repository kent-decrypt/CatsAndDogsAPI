using Integration.Dogs.Api.Interfaces;
using Integration.Dogs.Api.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Integration.Dogs.Api.Services
{
    /// <summary>
    /// Service class for the Cat Service API Integration
    /// </summary>
    public class DogService : BaseService, IDogService
    {
        /// <summary>
        /// Constructor for the Cats Service API
        /// </summary>
        /// <param name="configurations"></param>
        public DogService(IOptions<Configurations> configurations) : base(configurations) { }

        /// <summary>
        /// Retrieves all of the breeds 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<Dog>> GetBreeds(CancellationToken cancellationToken, int page = 1, int limit = 20)
        {
            var result = await Get($"breeds?page={page - 1}&limit={limit}");
            if (result.Length <= 10) return null;

            var responseData = JsonConvert.DeserializeObject<List<Dog>>(result, new JsonSerializerSettings
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            });

            return responseData;
        }

        /// <summary>
        /// Search for the dog breed
        /// </summary>
        /// <param name="breed"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public async Task<List<DogSearchResult>> SearchBreed(string breed, CancellationToken cancellationToken, int page = 1, int limit = 20)
        {
            var result = await Get($"breeds/search?q={breed}&page={page - 1}&limit={limit}");
            if (result.Length <= 10) return null;

            var responseData = JsonConvert.DeserializeObject<List<DogSearchResult>>(result, new JsonSerializerSettings
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
        public async Task<List<DogImage>> GetDogImagesByBreedId(string breedId, CancellationToken cancellationToken, int page = 1, int limit = 20)
        {
            var result = await Get($"images/search?breed_id={breedId}&page={page - 1}&limit={limit}");
            if (result.Length <= 10) return null;

             var responseData = JsonConvert.DeserializeObject<List<DogImage>>(result, new JsonSerializerSettings
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            });

            return responseData;
        }

        /// <summary>
        /// Retrieves the image details by using the image Id
        /// </summary>
        /// <param name="imageId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DogImage> GetDogImageByImageId(string imageId, CancellationToken cancellationToken)
        {
            var result = await Get($"images/{imageId}");
            if (result.Length <= 10) return null;

            var responseData = JsonConvert.DeserializeObject<DogImage>(result, new JsonSerializerSettings
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            });

            return responseData;
        }

        /// <summary>
        /// Retrieves list of random Dog Images
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public async Task<List<DogImage>> GetRandomDogImages(CancellationToken cancellationToken, int page = 1, int limit = 20)
        {
            var result = await Get($"images/search?page={page - 1}&limit={limit}");
            if (result.Length <= 10) return new List<DogImage>();

            var responseData = JsonConvert.DeserializeObject<List<DogImage>>(result, new JsonSerializerSettings
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            });

            return responseData;
        }
    }
}
