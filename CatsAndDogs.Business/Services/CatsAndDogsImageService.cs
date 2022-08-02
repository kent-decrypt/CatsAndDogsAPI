using AutoMapper;
using CatsAndDogs.Business.Interfaces;
using CatsAndDogs.Business.Models;
using Integration.Cats.Api.Interfaces;
using Integration.Dogs.Api.Interfaces;

namespace CatsAndDogs.Business.Services
{
    /// <summary>
    /// Service class for the Cats And Dogs Images Service
    /// </summary>
    public class CatsAndDogsImageService : ICatsAndDogsImageService
    {
        private readonly ICatService _catService;
        private readonly IDogService _dogService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for the Cats And Dogs Breeds Services
        /// </summary>
        /// <param name="catService"></param>
        public CatsAndDogsImageService(ICatService catService, IDogService dogService, IMapper mapper)
        {
            _catService = catService;
            _dogService = dogService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves the image details of cats and dogs
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public async Task<Image> GetImage(string imageId, CancellationToken cancellationToken)
        {
            var image = new Image();

            var catImage = await _catService.GetCatImageByImageId(imageId, cancellationToken);
            var dogImage = await _dogService.GetDogImageByImageId(imageId, cancellationToken);

            if (catImage != null) image = _mapper.Map<Image>(catImage);
            else if (dogImage != null) image = _mapper.Map<Image>(dogImage);

            return image;
        }
    }
}
