using System.Collections.Generic;
using System.Collections;
using BreedApi.Models;
using BreedApi.Repository;


namespace  BreedApi.Services {
    public class BreedService : IBreedService {
        
        private IBreedRepository _repo;
        
        public BreedService(IBreedRepository repo) {
            _repo = repo;
        }

        
        public IEnumerable<Breed> GetBreeds() {
            IEnumerable<Breed> myList = _repo.GetBreeds();
            return myList;
        }

        public Breed GetBreedbyName(string name) {
            return _repo.GetBreedbyName(name);
        }

        public void CreateBreed(Breed b) {
            _repo.InsertBreed(b);
        }

        public void UpdateBreed(string name, Breed b) {
            _repo.UpdateBreed(name, b);
        }

        public void DeleteBreed(string name) {
            _repo.DeleteBreed(name);
        }



    }
}