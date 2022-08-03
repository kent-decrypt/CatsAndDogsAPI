using CatsAndDogs.Business.Models;

namespace Tests.CatsAndDogs.MockData
{
    /// <summary>
    /// Mock data for the ImageController in the API Layer
    /// </summary>
    internal static class GetImageMockData
    {
        /// <summary>
        /// Returns a valid image mock data
        /// </summary>
        /// <returns></returns>
        internal static Image GetValidImage()
        {
            return new Image {
                Id = "11egN-Kkf",
                Url = "https://cdn2.thecatapi.com/images/11egN-Kkf.jpg",
                Width = 600,
                Height = 398
            };
        }

        /// <summary>
        /// Returns a mock data result for GetList Service
        /// </summary>
        /// <returns></returns>
        internal static Image GetInvalidImage()
        {
            return new Image
            {
                Id = "11egN-Kkf",
                Url = "https://cdn2.thecatapi.com/images/11egN-Kkf.jpg",
                Width = 600,
                Height = 398
            };
        }

    }
}
