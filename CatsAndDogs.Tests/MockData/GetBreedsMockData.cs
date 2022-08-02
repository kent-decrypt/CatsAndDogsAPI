using CatsAndDogs.Business.Models;

namespace CatsAndDogs.Tests.MockData
{
    /// <summary>
    /// Mock data for the ResultSet class in the API Layer
    /// </summary>
    internal static class GetBreedsMockData
    {
        /// <summary>
        /// Returns a fake result for the page = 1 and limit = 20 and a result model
        /// </summary>
        /// <returns></returns>
        internal static ResultSet<List<Pet>> GetFact1PageLimit20MockData()
        {
            var list = new List<Pet>();

            for(int i = 0; i < 20; i++)
            {
                list.Add(new Pet
                {
                    Id = $"Id-{i}",
                    Name = $"Name-{i}",
                    Temperament = $"Temperament-{i}",
                    Origin = $"Origin-{i}",
                    CountryCode = $"CountryCode-{i}",
                    Description = $"Description-{i}",
                    BredFor = $"BredFor-{i}",
                    BreedGroup = $"BreedGroup-{i}",
                    Image = new Image
                    {
                        Id = $"FakeImage-{i}",
                        Width = i,
                        Height = i,
                        Url = $"FakeImage-{i}"
                    }
                });
            }

            return new ResultSet<List<Pet>>()
            {
                Page = 1,
                Limit = 20,
                Result = list
            };
        }

        /// <summary>
        /// Returns a fake result image list
        /// </summary>
        /// <returns></returns>
        internal static ResultSet<List<Pet>> GetFact1PageLimi20PetImageListMockData()
        {
            var petList = new List<Pet>();


            return new ResultSet<List<Pet>>
            {
                Page = 1,
                Limit = 20,
                Result = petList,
            };
        }
    }
}
