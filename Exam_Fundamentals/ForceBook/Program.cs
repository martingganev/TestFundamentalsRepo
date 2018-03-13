using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            int count2 = 0;
            var dict = new Dictionary<string, string>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Lumpawaroo")
                    break;
                if (input.Contains('|'))
                {
                    var inputParts = input.Split(new[] { '|', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    var forceUser = inputParts[1];
                    var forceSide = inputParts[0];
                    if (!dict.ContainsKey(forceUser))
                    {
                        dict.Add(forceUser, forceSide);
                        count2++;
                        
                     }
                }
                else
                {
                    string forceUser = "", forceSide = "";
                    var inputParts = input.Split(new[] { '-', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    if (inputParts.Length > 2)
                    {
                        forceUser = inputParts[0] + " " + inputParts[1];
                        forceSide = inputParts[2];
                    }
                    else
                    {
                        forceUser = inputParts[0];
                        forceSide = inputParts[1];
                    }
                    if (!dict.ContainsKey(forceUser))
                    {
                        dict.Add(forceUser, forceSide);
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                        count2++;
                    }
                    else
                    {
                        dict[forceUser] = forceSide;
                        if (dict.ContainsValue(forceSide))
                        {
                            Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                        }
                    }
                }
            }
            int count = 0;
              foreach (var value in dict.OrderBy(x => x.Key))
            {
                if (count == 0)
                {
                    Console.WriteLine($"Side: {value.Value}, Members: {count2}");
                    count++;
                }
                Console.WriteLine($"! {value.Key}");
            }
        }
    }
}
