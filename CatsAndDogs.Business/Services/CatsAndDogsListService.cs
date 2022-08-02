using AutoMapper;
using CatsAndDogs.Business.Interfaces;
using CatsAndDogs.Business.Models;
using Integration.Cats.Api.Interfaces;
using Integration.Dogs.Api.Interfaces;

namespace CatsAndDogs.Business.Services
{
    /// <summary>
    /// Service class for the Cats and Dogs List
    /// </summary>
    public class CatsAndDogsListService : ICatsAndDogsListService
    {
        private readonly ICatService _catService;
        private readonly IDogService _dogService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for the Cats And Dogs Breeds Services
        /// </summary>
        /// <param name="catService"></param>
        public CatsAndDogsListService(ICatService catService, IDogService dogService, IMapper mapper)
        {
            _catService = catService;
            _dogService = dogService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves the image list of cats and dogs
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public async Task<ResultSet<List<Image>>> GetList(CancellationToken cancellationToken, int page = 1, int limit = 20)
        {
            var newLimit = (limit / 2) + 1;
            var imageList = new List<Image>();

            var randomCatImages = await _catService.GetRandomCatImages(cancellationToken, page, newLimit);
            var randomDogImages = await _dogService.GetRandomDogImages(cancellationToken, page, newLimit);

            foreach(var catImage in randomCatImages)
                imageList.Add(_mapper.Map<Image>(catImage));

            foreach (var dogImage in randomDogImages)
                imageList.Add(_mapper.Map<Image>(dogImage));
            
            if (imageList.Count > 0)
            {
                imageList = imageList.OrderBy(pet => pet.Id).ToList();
                imageList.RemoveRange(imageList.Count - 2, limit % 2 == 0 ? 2 : 1);
            }

            return new ResultSet<List<Image>>
            {
                Page = page,
                Limit = limit,
                Result = imageList
            };

        }
    }
}
