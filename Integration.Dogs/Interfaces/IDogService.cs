using Integration.Dogs.Api.Models;

namespace Integration.Dogs.Api.Interfaces
{
    /// <summary>
    /// Interface class for the Cat Service Integration
    /// </summary>
    public interface IDogService
    {
        /// <summary>
        /// Retrieves all of the breeds 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<List<Dog>> GetBreeds(CancellationToken cancellationToken, int page = 1, int limit = 20);

        /// <summary>
        /// Search for the dog breed
        /// </summary>
        /// <param name="breed"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<List<DogSearchResult>> SearchBreed(string breed, CancellationToken cancellationToken, int page = 1, int limit = 20);

        /// <summary>
        /// Retrieves list of images by using the breedId
        /// </summary>
        /// <param name="breed"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<List<DogImage>> GetDogImagesByBreedId(string breedId, CancellationToken cancellationToken, int page = 1, int limit = 20);

        /// <summary>
        /// Retrieves the image details by using the image Id
        /// </summary>
        /// <param name="imageId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DogImage> GetDogImageByImageId(string imageId, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves list of random Dog Images
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<List<DogImage>> GetRandomDogImages(CancellationToken cancellationToken, int page = 1, int limit = 20);
    }
}
