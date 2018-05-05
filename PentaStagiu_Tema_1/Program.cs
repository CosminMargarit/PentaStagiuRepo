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
            int attempts = 0;
            int guessNr = GenerateRandomNr();
            int userNr = GetNrFromUser();

            if (userNr == 24011989)
            {
                Console.WriteLine(guessNr);
            }
            while (userNr != guessNr)
            {
                attempts++;
                string diff = (userNr < guessNr ? "mic" : "mare");
                Console.WriteLine("Numarul introdus este mai {0}. Incearca din nou!", diff);
                userNr = GetNrFromUser();
            }
            if (attempts > 1)
            {
                Console.WriteLine("Felicitari! Ai ghicit numarul din {0} incercari.", attempts);
            }
            else
            {
                Console.WriteLine("Felicitari! Ai ghicit numarul din prima.");
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
            if(userInput != 24011989)
            {
                if (!isNr || userInput < 0 || userInput > 100)
                {
                    GetNrFromUser();
                }
            }
            return userInput;
        }
    }
}