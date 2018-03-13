using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Star_enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string pattern = @"s|t|a|r|S|T|A|R";
            string secondPattern = @"(@)([A-Za-z]+)(.*)(:)(\d+)(!)(A|D)(!)(->)(\d+)";
            int attackedPlanets = 0, destroyedPlanets = 0;
            var aPlanets = new List<string>();
            var dPlanets = new List<string>();

            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();
                MatchCollection matches = Regex.Matches(input, pattern);
                int count = matches.Count;
                string newlyBuilt2 = "";

                for (int a = 0; a < input.Length; a++)
                {
                    char newlyBuilt = (char)((int)input[a] - count);
                    newlyBuilt2 += newlyBuilt;
                }
                MatchCollection matches2 = Regex.Matches(newlyBuilt2, secondPattern);
                foreach (Match match in matches2)
                {
                    var planetName = match.Groups[2].Value;
                    var population = match.Groups[5].Value;
                    var attOrDef = match.Groups[7].Value;
                    var soldiers = match.Groups[10].Value;

                    if (attOrDef == "A")
                    {
                        attackedPlanets++;
                        aPlanets.Add(planetName);
                    }
                    else if (attOrDef == "D")
                    {
                        destroyedPlanets++;
                        dPlanets.Add(planetName);
                    }
                }
            }
            aPlanets.Sort();
            dPlanets.Sort();
            Console.WriteLine($"Attacked planets: {attackedPlanets}");
            if (aPlanets != null)
            {
                foreach (var planet in aPlanets)
                {
                    Console.WriteLine($"-> {planet}");
                }
            }
            Console.WriteLine($"Destroyed planets: {destroyedPlanets}");
            if (dPlanets != null)
            {
                foreach (var planet in dPlanets)
                {
                    Console.WriteLine($"-> {planet}");
                }
            }
        }
    }
}
