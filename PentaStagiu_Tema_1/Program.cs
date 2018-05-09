using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PentaStagiu
{
    class Program
    {
        static void Main(string[] args)
        {
            int guessNr = GenerateRandomNr();
            int userNr = GetNrFromUser();
            int guessAttempts = 0;
            
            while (userNr != guessNr)
            {
                string diff = (userNr < guessNr ? "mic" : "mare");
                Console.WriteLine("Numarul introdus este mai {0}. Incearca din nou!", diff);
                guessAttempts++;
                userNr = GetNrFromUser();
            }

            if (guessAttempts > 1)
            {
                Console.WriteLine("Felicitari! Ai ghicit numarul din {0} incercari.", guessAttempts);
            }
            else
            {
                Console.WriteLine("Felicitari! Ai ghicit numarul din prima incercare.");
            }
            Console.ReadLine();
        }

        static int GenerateRandomNr()
        {
            Random rng = new Random();
            return rng.Next(0, 100);
        }

        static int GetNrFromUser()
        {
            Console.WriteLine("Introdu un numar intre 0 si 100");
            int userInput = -1;
            bool isNr = int.TryParse(Console.ReadLine(), out userInput);
            if (!isNr || userInput < 0 || userInput > 100)
            {
                GetNrFromUser();
            }
            return userInput;
        }
    }
}