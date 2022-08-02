using CatsAndDogs.Business.Models;

namespace CatsAndDogs.Business.Interfaces
{
    /// <summary>
    /// Interface for the Cats And Dogs Breeds Service
    /// </summary>
    public interface ICatsAndDogsBreedsServices
    {
        /// <summary>
        /// Retrieves the breeds of combined number of cats and dogs
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<ResultSet<List<Pet>>> GetAllBreeds(CancellationToken cancellationToken, int page = 1, int limit = 20);

        /// <summary>
        /// Finds if the specified breed is found
        /// </summary>
        /// <param name="breed"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns>Breed Id</returns>
        Task<ResultSet<List<Pet>>> SearchBreed(string breed, CancellationToken cancellationToken, int page = 1, int limit = 20);

        /// <summary>
        /// Retrieves the images
        /// </summary>
        /// <param name="pet"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns>Breed Id</returns>
        Task<ResultSet<List<Image>>> GetImages(List<Pet> pet, CancellationToken cancellationToken, int page = 1, int limit = 20);
    }
}
