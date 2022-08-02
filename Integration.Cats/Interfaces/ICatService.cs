using Integration.Cats.Api.Models;

namespace Integration.Cats.Api.Interfaces
{
    /// <summary>
    /// Interface class for the Cat Service Integration
    /// </summary>
    public interface ICatService
    {
        /// <summary>
        /// Retrieves all of the breeds 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<List<Cat>> GetBreeds(CancellationToken cancellationToken, int page = 1, int limit = 20);

        /// <summary>
        /// Search for the cat breed
        /// </summary>
        /// <param name="breed"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<List<CatSearchResult>> SearchBreed(string breed, CancellationToken cancellationToken, int page = 1, int limit = 20);

        /// <summary>
        /// Retrieves list of images by using the breedId
        /// </summary>
        /// <param name="breed"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<List<CatImage>> GetCatImagesByBreedId(string breedId, CancellationToken cancellationToken, int page = 1, int limit = 20);

        /// <summary>
        /// Retrieves the image details by using the image Id
        /// </summary>
        /// <param name="imageId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<CatImage> GetCatImageByImageId(string imageId, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves list of random Cat Images
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<List<CatImage>> GetRandomCatImages(CancellationToken cancellationToken, int page = 1, int limit = 20);
    }
}
