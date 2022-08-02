using AutoMapper;
using CatsAndDogs.Business.Interfaces;
using CatsAndDogs.Business.Models;
using Integration.Cats.Api.Interfaces;
using Integration.Dogs.Api.Interfaces;

namespace CatsAndDogs.Business.Services
{
    /// <summary>
    /// Class for the Cats And Dogs Breeds Service
    /// </summary>
    public class CatsAndDogsBreedsServices : ICatsAndDogsBreedsServices
    {
        private readonly ICatService _catService;
        private readonly IDogService _dogService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for the Cats And Dogs Breeds Services
        /// </summary>
        /// <param name="catService"></param>
        public CatsAndDogsBreedsServices(ICatService catService, IDogService dogService, IMapper mapper)
        {
            _catService = catService;
            _dogService = dogService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves the breeds of combined number of cats and dogs
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public async Task<ResultSet<List<Pet>>> GetAllBreeds(CancellationToken cancellationToken, int page = 1, int limit = 20)
        {
            var newLimit = (limit / 2) + 1;
            var pets = new List<Pet>();

            var cats = await _catService.GetBreeds(cancellationToken, page, newLimit);
            var dogs = await _dogService.GetBreeds(cancellationToken, page, newLimit);

            foreach (var cat in cats) 
                pets.Add(_mapper.Map<Pet>(cat));

            foreach (var dog in dogs)
                pets.Add(_mapper.Map<Pet>(dog));

            pets = pets.OrderBy(pet => pet.Name).ToList();
            pets.RemoveRange(pets.Count - 2, limit % 2 == 0 ? 2 : 1);

            return new ResultSet<List<Pet>> { 
                Result = pets,
                Page = page,
                Limit = limit
            };
        }

        /// <summary>
        /// Finds if the specified breed is found
        /// </summary>
        /// <param name="breed"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns>Breed Id</returns>
        public async Task<ResultSet<List<Pet>>> SearchBreed(string breed, CancellationToken cancellationToken, int page = 1, int limit = 20)
        {
            var newLimit = (limit / 2) + 1;

            var pets = new List<Pet>();
            var cat = await _catService.SearchBreed(breed, cancellationToken, page, newLimit);
            var dog = await _dogService.SearchBreed(breed, cancellationToken, page, newLimit);

            if (cat != null) pets = _mapper.Map<List<Pet>>(cat);
            else if (dog != null) pets = _mapper.Map<List<Pet>>(dog);

            if(pets.Count > 0 && pets.Count - 2 > 0)
            {
                pets = pets.OrderBy(pet => pet.Name).ToList();
                pets.RemoveRange(pets.Count - 2, limit % 2 == 0 ? 2 : 1);
            }

            return new ResultSet<List<Pet>>
            {
                Page = page,
                Limit = limit,
                Result = pets
            };
        }

        /// <summary>
        /// Retrieves the images
        /// </summary>
        /// <param name="pets"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns>Breed Id</returns>
        public async Task<ResultSet<List<Image>>> GetImages(List<Pet> pets, CancellationToken cancellationToken, int page = 1, int limit = 20)
        {
            var model = new List<Image>();
            var newLimit = (limit / 2) + 1;

            foreach (var pet in pets)
            {
                var catImages = await _catService.GetCatImagesByBreedId(pet.Id, cancellationToken, page, newLimit);
                var dogImages = await _dogService.GetDogImagesByBreedId(pet.Id, cancellationToken, page, newLimit);

                if(catImages != null)
                {
                    foreach (var catImage in catImages)
                        model.Add(_mapper.Map<Image>(catImage));
                }

                if(dogImages != null)
                {
                    foreach (var dogImage in dogImages)
                        model.Add(_mapper.Map<Image>(dogImage));
                }

            }

            if(model.Count > 0)
            {
                model = model.OrderBy(pet => pet.Id).ToList();
                model.RemoveRange(model.Count - 2, limit % 2 == 0 ? 2 : 1);
            }

            return new ResultSet<List<Image>>()
            {
                Page = page,
                Limit = limit,
                Result = model
            };
        }
    }
}
