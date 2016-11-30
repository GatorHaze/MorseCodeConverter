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
            while (true)
            {
                Console.WriteLine("Enter a phrase that you would like to convert to morsecode then push enter. When you are finished type 'exit'");
                string inputString = Console.ReadLine().ToUpper().Replace(" ", "").Replace(".", "").Replace(";", "");
                if (inputString == "EXIT")
                {
                    break;
                }
                else
                {
                    foreach (var letter in inputString)
                    {
                        var morseCode = AlphaToMorse[letter];
                        Console.Write(morseCode);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
   

