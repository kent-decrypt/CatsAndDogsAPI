using CatsAndDogs.Business.Models;

namespace CatsAndDogs.Business.Interfaces
{
    /// <summary>
    /// Interface for the Cats And Dogs Images Service
    /// </summary>
    public interface ICatsAndDogsImageService
    {
        /// <summary>
        /// Retrieves the image details of cats and dogs
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<Image> GetImage(string imageId, CancellationToken cancellationToken);
    }
}
