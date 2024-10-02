using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CitiesGame
{
    class Program
    {
        static List<string> cities = new List<string>();

        static void Main(string[] args)
        {
            LoadCities();

            Console.WriteLine("Welcome to the Cities game!");
            Console.WriteLine("Do you want to play with a computer or another player? (C/P)");
            string choice = Console.ReadLine();

            if (choice.ToUpper() == "C")
            {
                PlayWithComputer();
            }
            else if (choice.ToUpper() == "P")
            {
                PlayWithPlayer();
            }
            else
            {
                Console.WriteLine("Invalid choice. Exiting...");
                return;
            }
        }

        static void LoadCities()
        {
            string[] lines = File.ReadAllLines("C:/333/cities.txt");
            cities.AddRange(lines);
        }

        static void PlayWithComputer()
        {
            string lastCity = "";
            while (true)
            {
                Console.WriteLine("Enter a city:");
                string city = Console.ReadLine();

                if (!cities.Contains(city, StringComparer.OrdinalIgnoreCase))
                {
                    Console.WriteLine("City not found. Game over.");
                    return;
                }

                lastCity = city;
                string newCity = GetNextCity(lastCity);
                Console.WriteLine($"Computer's turn: {newCity}");
                lastCity = newCity;
            }
        }

        static void PlayWithPlayer()
        {
            string lastCity = "";
            while (true)
            {
                Console.WriteLine("Enter a city:");
                string city = Console.ReadLine();

                if (!cities.Contains(city, StringComparer.OrdinalIgnoreCase))
                {
                    Console.WriteLine("City not found. Game over.");
                    return;
                }

                lastCity = city;
                Console.WriteLine("Player 2's turn:");
                string newCity = Console.ReadLine();

                if (!cities.Contains(newCity, StringComparer.OrdinalIgnoreCase))
                {
                    Console.WriteLine("City not found. Game over.");
                    return;
                }

                lastCity = newCity;
            }
        }

        static string GetNextCity(string city)
        {
            char lastLetter;
            if (city.EndsWith("ь", StringComparison.OrdinalIgnoreCase))
            {
                lastLetter = city[city.Length - 2]; // Take the second last letter if the city ends with a soft sign
            }
            else
            {
                lastLetter = city[city.Length - 1];
            }

            string newCity = cities.FirstOrDefault(c => c.StartsWith(lastLetter.ToString(), StringComparison.OrdinalIgnoreCase));
            return newCity;
        }
    }
}