using System;
using System.Collections.Generic;
using System.Linq;

namespace Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            var bestSequence = new int[length];
            int count = 1, startIndex = 0, bestStartIndex = 0;
            int maxCount = 1, bestSequenceIndex = 0;
            

            while(true)
            {
                count = 1;
                startIndex = 0;
                var input = Console.ReadLine();
                if (input == "Clone them!")
                    break;
                var inputParts = input.Split(new[] {'!'}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int i = 0; i < inputParts.Length-1; i++)
                {
                    if(inputParts[i] == 1 && inputParts[i+1] == 1)
                    {
                        startIndex = i;
                        break;
                    }
                }
                for (int i = startIndex; i < inputParts.Length-1; i++)
                {
                    if(inputParts[i] == 1 && inputParts[i+1] == 1)
                    { 
                        count++;
                    }
                }
                if (count > maxCount)
                {
                    maxCount = count;
                    bestStartIndex = startIndex;
                    for (int i = 0; i < length; i++)
                    {
                        bestSequence[i] = inputParts[i];
                    }
                    bestSequenceIndex++;
                }
                else if (count == maxCount)
                {
                    if (startIndex < bestStartIndex)
                    {
                        bestStartIndex = startIndex;
                        for (int i = 0; i < length; i++)
                        {
                            bestSequence[i] = inputParts[i];
                        }
                        bestSequenceIndex++;
                    }
                    else if(startIndex == bestStartIndex)
                    {
                        if (inputParts.Sum() > bestSequence.Sum())
                        {
                            for (int i = 0; i < length; i++)
                            {
                                bestSequence[i] = inputParts[i];
                            }
                            bestSequenceIndex++;
                        }
                    }
                }
            }
            Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {bestSequence.Sum()}.");
            var result = string.Join(" ", bestSequence);
            Console.WriteLine(result);
        }
    }
}
