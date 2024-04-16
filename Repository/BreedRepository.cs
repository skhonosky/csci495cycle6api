using System;
using System.Collections.Generic;
using System.Data;
using BreedApi.Models;
using MySql.Data.MySqlClient;

namespace BreedApi.Repository {
    public class BreedRepository : IBreedRepository {
        private static readonly List<Breed> Breeds = new List<Breed>() 
        {
            new Breed {Name="Shih Tzu", Lifespan = "10-18 Years", Traits="playful, affectionate, outgoing", CoatLength="Long"}
            
        };
        private MySqlConnection _connection;

        public BreedRepository() {
            string connectionString="server=localhost;user=csci495user;password=csci495pass;database=csci495cycle6api";
            _connection = new MySqlConnection(connectionString);
            _connection.Open();
            
        }

        ~BreedRepository() {
            _connection.Close();
        }

        public IEnumerable<Breed> GetBreeds() {
            var statement = "Select * from Breeds";
            var command = new MySqlCommand(statement,_connection);
            var results = command.ExecuteReader();

            List<Breed> newList = new List<Breed>(20);

            while(results.Read()){
                Breed b = new Breed {
                    Name = (string)results[0],
                    Lifespan = (string)results[1],
                    Traits = (string)results[2],
                    CoatLength = (string)results[3]
                };
                newList.Add(b);
            }
            results.Close();
            return newList;
            
        }

        public Breed GetBreedbyName(string name) {
            var statement = "Select * From Breeds Where Name = @newName";
            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@newName", name);

            var results = command.ExecuteReader();
            Breed b = null;
            if (results.Read()) {
                b = new Breed {
                    Name = (string)results[0],
                    Lifespan = (string)results[1],
                    Traits = (string)results[2],
                    CoatLength = (string)results[3]
                };
            }
            results.Close();
            return b;
            
        }

        public void InsertBreed(Breed b) {
            
            var statement = "Insert Into Breeds (Name, Lifespan, Traits, CoatLength) Values (@n, @l, @t, @c)";
            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@n", b.Name);
            command.Parameters.AddWithValue("@l", b.Lifespan);
            command.Parameters.AddWithValue("@t", b.Traits);
            command.Parameters.AddWithValue("@c", b.CoatLength);


            int result = command.ExecuteNonQuery();
            Console.WriteLine(result);
        }

        public void UpdateBreed(string name, Breed breedIn) {
            var statement = "Update Breeds Set Name=@newName, Lifespan=@newLifespan, Traits=@newTraits, CoatLength=@newCoatLength Where Name=@updateName";
            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@newName", breedIn.Name);
            command.Parameters.AddWithValue("@newLifespan", breedIn.Lifespan);
            command.Parameters.AddWithValue("@newTraits", breedIn.Traits);
            command.Parameters.AddWithValue("@newCoatLength", breedIn.CoatLength);
            command.Parameters.AddWithValue("@updateName", name);

            Console.WriteLine(breedIn);
            int result = command.ExecuteNonQuery();
            Console.WriteLine(result);
        }


        public bool DeleteBreed(string name) {
            var statement = "DELETE FROM Breeds WHERE Name=@newName";
            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@newName", name);

            int result = command.ExecuteNonQuery();
            if (result == 1)
                return true;
            else
                return false;
        }
    }
}