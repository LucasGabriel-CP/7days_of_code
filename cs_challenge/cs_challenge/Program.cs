using RestSharp;
using System.Text.Json;

namespace challenge {
    public class Pokemon {
        public string? name { get; set; }
        public string? url { get; set; }
    }

    public class Pokedex {
        public int count { get; set; }
        public List<Pokemon>? results { get; set; }
    }


    class Program {
        static int Main(string[] args) {
            var pokes = do_get();
            if (pokes == null) {
                Console.WriteLine("deu ruim");
                return -1;
            }

            print_deserialized(pokes.Content);

            return 0;
        }

        private static RestResponse do_get() {
            var client = new RestClient($"https://pokeapi.co/api/v2");
            RestRequest request = new RestRequest("/pokemon?limit=100000&offset=0/json/", Method.Get);
            RestResponse response = client.Execute(request);
            return response;
        }

        private static void print_deserialized(string? json_string) {
            if (json_string == null) {
                Console.WriteLine("json_string null");
                return;
            }
            Pokedex? pokemon = JsonSerializer.Deserialize<Pokedex>(json_string);
            if (pokemon == null || pokemon.results == null) {
                Console.WriteLine("Nothing to print");
                return;
            }
            foreach (var pk in pokemon.results) {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine($"name: {pk.name}\nurl: {pk.url}");
            }
            Console.WriteLine("------------------------------------------");
        }
    }
}