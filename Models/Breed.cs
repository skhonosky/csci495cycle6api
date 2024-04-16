namespace BreedApi.Models
{
    public class Breed {
        public string Name {get; set;}
        public string Lifespan {get; set;}
        public string Traits {get; set;}
        public string CoatLength {get; set;}

        public override string ToString() {
            return $"{Name}, {Lifespan}, {Traits}, {CoatLength}";    
        }
    }
}