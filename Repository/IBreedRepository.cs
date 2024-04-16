using System.Collections.Generic;
using BreedApi.Models;

namespace BreedApi.Repository {
    public interface IBreedRepository {
        public IEnumerable<Breed> GetBreeds();
        public Breed GetBreedbyName(string name);
        public void InsertBreed(Breed b);
        public void UpdateBreed(string name, Breed breedIn);
        public bool DeleteBreed(string name);
    }
}