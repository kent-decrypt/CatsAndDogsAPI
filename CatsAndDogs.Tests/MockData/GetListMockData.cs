using CatsAndDogs.Business.Models;

namespace Tests.CatsAndDogs.MockData
{
    /// <summary>
    /// Mock data for the ListController in the API Layer
    /// </summary>
    internal static class GetListMockData
    {
        /// <summary>
        /// Returns a list of Mock Images
        /// </summary>
        /// <returns></returns>
        private static List<Image> GetMockImages(int numberOfImages = 1)
        {
            var imageList = new List<Image>();

            for (var i = 0; i < numberOfImages; i++)
            {
                imageList.Add(new Image { Id = $"Id={i}", Height = i, Width = i, Url = $"https://some.url/{i}" });
            }

            return imageList;
        }

        /// <summary>
        /// Returns a mock data result for GetList Service
        /// </summary>
        /// <returns></returns>
        internal static ResultSet<List<Image>> GetList_1Page_20Limit_ListImageMockData()
        {
            return new ResultSet<List<Image>>()
            {
                Page = 1,
                Limit = 20,
                Result = GetMockImages(20)
            };
        }

        /// <summary>
        /// Returns a mock data result for GetList Service
        /// </summary>
        /// <returns></returns>
        internal static ResultSet<List<Image>> GetList_1Page_20Limit_NoImageMockData()
        {
            return new ResultSet<List<Image>>()
            {
                Page = 0,
                Limit = 0,
                Result = GetMockImages(0)
            };
        }

        /// <summary>
        /// Returns a mock data result for GetList Service with a negative value for page
        /// </summary>
        /// <returns></returns>
        internal static ResultSet<List<Image>> GetList_Negative1Page_20Limit_ListImageMockData()
        {
            return new ResultSet<List<Image>>()
            {
                Page = -1,
                Limit = 20,
                Result = GetMockImages(20)
            };
        }

        /// <summary>
        /// Returns a mock data result for GetList Service with a negative value for limit
        /// </summary>
        /// <returns></returns>
        internal static ResultSet<List<Image>> GetList_1Page_Negative20Limit_ListImageMockData()
        {
            return new ResultSet<List<Image>>()
            {
                Page = 1,
                Limit = -20,
                Result = GetMockImages(1)
            };
        }

        /// <summary>
        /// Returns a mock data result for GetList Service with a more than 100 value for limit
        /// </summary>
        /// <returns></returns>
        internal static ResultSet<List<Image>> GetList_1Page_MoreThan100Limit_ListImageMockData()
        {
            return new ResultSet<List<Image>>()
            {
                Page = 1,
                Limit = 999,
                Result = GetMockImages(100)
            };
        }
    }
}
