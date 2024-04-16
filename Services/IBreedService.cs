using System.Collections.Generic;
using System.Data;
using BreedApi.Models;

namespace BreedApi.Services {
    public interface IBreedService {
        public IEnumerable<Breed> GetBreeds();
        public Breed GetBreedbyName(string name);
        public void CreateBreed(Breed b);
        public void UpdateBreed(string name, Breed b);
        public void DeleteBreed(string name);

    }
}