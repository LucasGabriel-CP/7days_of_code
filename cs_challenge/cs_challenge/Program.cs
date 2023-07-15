using RestSharp;
using System.Text.Json;
using cs_challenge.Menus;
using cs_challenge.Utils;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace challenge {

    public class PokeInfo {
        public List<Pokemon>? results { get; set; }
    }

    class Program {
        public static RestClient client = new RestClient($"https://pokeapi.co/api/v2");
        static int Main(string[] args) {
            Menus.header_menu();
            var username = Console.ReadLine();
            Console.WriteLine($"Hello {username}!");
            int op;
            do {
                op = Menus.initial_menu();
                if (op == 1) {
                    string pk_name;
                    int adopt_op = 0;
                    do {
                        pk_name = view_pokemons();
                        if (pk_name != "return") {
                            do {
                                adopt_op = Menus.menu_adopt(pk_name);
                                if (adopt_op == 1) {
                                    Console.WriteLine(get_pokemon(pk_name));
                                }
                            } while (adopt_op == 1);
                        }
                    } while (pk_name != "return" && adopt_op != 2);
                    if (pk_name == "return") { continue; }
                    Pokemon? adopted_pokemon = get_pokemon(pk_name);
                    if (adopted_pokemon == null) { continue; }
                    Menus.adoption_info(pk_name);
                    Console.WriteLine("Press ENTER to continue...");
                    Console.ReadKey();
                }
                else if (op == 2) {
                    /*view adoptions*/
                }
            } while(op != 3);
            Menus.byebye();

            return 0;
        }

        private static Pokemon? get_pokemon(string pk_name) {
            RestRequest request = new RestRequest($"/pokemon/{pk_name}", Method.Get);
            RestResponse response = client.Execute(request);
            Pokemon? pokemon = JsonSerializer.Deserialize<Pokemon>(response.Content ?? @"{""ruim"": ""deu""}");
            return pokemon;
        }

        private static string view_pokemons() {
            int pg = 0;
            while (pg <= 128) {
                List<Pokemon> pokedex = do_get(pg);
                Console.WriteLine("Pokemons Avaliable:");
                Console.WriteLine("--------------------------------");
                bool ok = false;
                foreach (var pokemon in pokedex) {
                    var value = String.Format("| {0, -12} |", pokemon);
                    ok = !ok;
                    Console.Write(value);
                    if (!ok) {
                        Console.Write('\n');
                        Console.WriteLine("--------------------------------");
                    }
                }
                string op = Menus.action_menu();
                if (op == "next") { pg++; }
                else if (op == "prev") { pg--; }
                else if (op == "return") { return op; }
                else {
                    if (check_existance(op)) {
                        return op;
                    }
                    Console.WriteLine("Pokemon does not exist! Press ENTER to continue...");
                    Console.ReadKey();
                }
            }
            return "return";
        }

        private static bool check_existance(string pk_name) {
            RestRequest request = new RestRequest($"/pokemon/{pk_name}", Method.Get);
            RestResponse response = client.Execute(request);
            return response.IsSuccessStatusCode;
        }

        private static List<Pokemon> do_get(int pg = 0, int n = 10) {
            RestRequest request = new RestRequest($"/pokemon?offset={10*pg}limit={n}", Method.Get);
            RestResponse response = client.Execute(request);
            PokeInfo? poke_info = JsonSerializer.Deserialize<PokeInfo>(response.Content??@"{""count"": ""0""}");

            return poke_info?.results!;
        }
    }
}