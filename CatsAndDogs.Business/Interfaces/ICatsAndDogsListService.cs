using CatsAndDogs.Business.Models;

namespace CatsAndDogs.Business.Interfaces
{
    /// <summary>
    /// Interface for the Cats And Dogs List Service
    /// </summary>
    public interface ICatsAndDogsListService
    {
        /// <summary>
        /// Retrieves the image list of cats and dogs
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<ResultSet<List<Image>>> GetList(CancellationToken cancellationToken, int page = 1, int limit = 20);
    }
}
