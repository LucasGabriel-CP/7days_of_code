using RestSharp;
using System.Text.Json;
using cs_challenge.Utils;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace challenge {

    public class PokeInfo {
        public List<Pokemon>? results { get; set; }
    }

    class Program {
        static int Main(string[] args) {
            Console.Write("N# of pokemons: ");
            var n = int.Parse(Console.ReadLine()!);
            List<Pokemon> pokedex = do_get(n);
            Console.WriteLine("Pokemons Avaliable:");
            Console.WriteLine("----------------------------------------------------------------");
            foreach (var pokemon in pokedex) {
                Console.WriteLine(pokemon);
                Console.WriteLine("----------------------------------------------------------------");
            }


            return 0;
        }

        private static List<Pokemon> do_get(int n) {
            var client = new RestClient($"https://pokeapi.co/api/v2");
            RestRequest request = new RestRequest($"/pokemon?limit={n}", Method.Get);
            RestResponse response = client.Execute(request);
            PokeInfo? poke_info = JsonSerializer.Deserialize<PokeInfo>(response.Content??@"{""count"": ""0""}");
            List<Pokemon> pokedex = new List<Pokemon>();
            
            for (int i = 1; i <= (poke_info?.results!).Count; i++) {
                request = new RestRequest($"/pokemon/{i}/", Method.Get);
                response = client.Execute(request);
                Pokemon? pk = JsonSerializer.Deserialize<Pokemon>(response.Content!);
                if (pk != null) {
                    pokedex.Add(pk);
                }
            }

            return pokedex;
        }
    }
}