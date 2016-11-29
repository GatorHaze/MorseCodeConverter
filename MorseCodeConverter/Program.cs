using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MorseCodeConverter
{
    class Program
    {


        static void Main(string[] args)
        {
            Dictionary<char, string> AlphaToMorse = new Dictionary<char, string>();
            
            var filePath = "morse.csv";

            if (File.Exists(filePath))
            {
                using (var sr = new StreamReader(filePath))
                {
                    while (sr.Peek() > 0)
                    {
                        var line = sr.ReadLine().Split(',');
                        var letter = Convert.ToChar(line[0]);
                        var morse = line[1];

                        AlphaToMorse.Add(letter, morse);

                    }
                }
            }

            Console.WriteLine("Enter a string that you would like to convert to morsecode");
            string inputString = Console.ReadLine().ToUpper().Replace(" ", "");



            foreach (var letter in inputString)
            {
                var morseCode = AlphaToMorse[letter];
                Console.Write(morseCode);
            }
            Console.WriteLine();
        }
    }
}
   

