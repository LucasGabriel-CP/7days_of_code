using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_challenge.Menus {
    internal class Menus {
        public static void header_menu() {
            Console.WriteLine(" /$$$$$$$$ /$$$$$$  /$$      /$$  /$$$$$$   /$$$$$$   /$$$$$$  /$$$$$$$$ /$$$$$$  /$$   /$$ /$$$$$$\r\n|__  $$__//$$__  $$| $$$    /$$$ /$$__  $$ /$$__  $$ /$$__  $$|__  $$__//$$__  $$| $$  | $$|_  $$_/\r\n   | $$  | $$  \\ $$| $$$$  /$$$$| $$  \\ $$| $$  \\__/| $$  \\ $$   | $$  | $$  \\__/| $$  | $$  | $$  \r\n   | $$  | $$$$$$$$| $$ $$/$$ $$| $$$$$$$$| $$ /$$$$| $$  | $$   | $$  | $$      | $$$$$$$$  | $$  \r\n   | $$  | $$__  $$| $$  $$$| $$| $$__  $$| $$|_  $$| $$  | $$   | $$  | $$      | $$__  $$  | $$  \r\n   | $$  | $$  | $$| $$\\  $ | $$| $$  | $$| $$  \\ $$| $$  | $$   | $$  | $$    $$| $$  | $$  | $$  \r\n   | $$  | $$  | $$| $$ \\/  | $$| $$  | $$|  $$$$$$/|  $$$$$$/   | $$  |  $$$$$$/| $$  | $$ /$$$$$$\r\n   |__/  |__/  |__/|__/     |__/|__/  |__/ \\______/  \\______/    |__/   \\______/ |__/  |__/|______/\r\n                                                                                                   \r\n                                                                                                   \r\n                                                                                                   \r\n\r\n");
            Console.Write("Type your name: ");
        }
        private static bool valid_op(int op) {
            if (op < 1 || op > 3) {
                Console.WriteLine("Invalid option!");
                return false;
            }
            return true;
        }
        public static int initial_menu() {
            int op = 0;
            do {
                try {
                    Console.WriteLine("---------------------------------------------- MENU ----------------------------------------------");
                    Console.WriteLine("1 - Adopt a Pokemon");
                    Console.WriteLine("2 - View your Pokemons");
                    Console.WriteLine("3 - Exit Tamagotchi");
                    Console.Write("Select a option: ");
                    op = int.Parse(Console.ReadLine()!);
                } catch (Exception e) {
                    Console.WriteLine($"{e.Message}");
                }
            } while (!valid_op(op));
            return op;
        }
        public static string action_menu() {
            Console.WriteLine("Do a action:");
            Console.WriteLine("  Type the name of your desired Pokemon\n  next for the next page\n  prev for previous page\n  return to return for to menu");
            var op = Console.ReadLine();
            return op!.ToLower();
        }

        public static int menu_adopt(string pk_name) {
            int op = 0;
            do {
                try {
                    Console.WriteLine("---------------------------------------------ADOPTION---------------------------------------------");
                    Console.WriteLine($"What do you want to do?");
                    Console.WriteLine($"1 - Know more about {pk_name}");
                    Console.WriteLine($"2 - Adopt {pk_name}");
                    Console.WriteLine($"3 - return to the catalog");
                    op = int.Parse(Console.ReadLine()!);
                }
                catch (Exception e) {
                    Console.WriteLine($"{e.Message}");
                }
            } while (!valid_op(op));
            return op;
        }

        public static void adoption_info(string pk_name) {
            Console.WriteLine($"Nice! You just adopted {pk_name}, the egg is hatching :D");
            Console.WriteLine("                                                                          \r\n                                                                          \r\n                                                                          \r\n                                ████████                                  \r\n                              ██        ██                                \r\n                            ██▒▒▒▒        ██                              \r\n                          ██▒▒▒▒▒▒      ▒▒▒▒██                            \r\n                          ██▒▒▒▒▒▒      ▒▒▒▒██                            \r\n                        ██  ▒▒▒▒        ▒▒▒▒▒▒██                          \r\n                        ██                ▒▒▒▒██                          \r\n                      ██▒▒      ▒▒▒▒▒▒          ██                        \r\n                      ██      ▒▒▒▒▒▒▒▒▒▒        ██                        \r\n                      ██      ▒▒▒▒▒▒▒▒▒▒    ▒▒▒▒██                        \r\n                      ██▒▒▒▒  ▒▒▒▒▒▒▒▒▒▒  ▒▒▒▒▒▒██                        \r\n                        ██▒▒▒▒  ▒▒▒▒▒▒    ▒▒▒▒██                          \r\n                        ██▒▒▒▒            ▒▒▒▒██                          \r\n                          ██▒▒              ██                            \r\n                            ████        ████                              \r\n                                ████████                                  \r\n                                                                          \r\n                                                                          \r\n                                                                          \r\n");
        }

        public static void byebye() {
            Console.Write("\n\n\n");
            Console.WriteLine("  ____   __     __  ______   ____   __     __  ______ \r\n |  _ \\  \\ \\   / / |  ____| |  _ \\  \\ \\   / / |  ____|\r\n | |_) |  \\ \\_/ /  | |__    | |_) |  \\ \\_/ /  | |__   \r\n |  _ <    \\   /   |  __|   |  _ <    \\   /   |  __|  \r\n | |_) |    | |    | |____  | |_) |    | |    | |____ \r\n |____/     |_|    |______| |____/     |_|    |______|\r\n                                                      \r\n                                                      \r\n\r\n");
        }
    }
}
