using System;
using System.Linq;

namespace Kamino_Factory2
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            var bestSequence = new int[length];
            int maxCount = 1, bestStartIndex = 0;
            int bestSequenceIndex = 0, currentSequenceIndex = 0;
            

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Clone them!")
                    break;
                var inputParts = input.Split(new[] { '!' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                int startIndex = FindStartIndex(inputParts);
                int count = FindLongestSequence(inputParts);
                if (count > maxCount)
                {
                    maxCount = count;
                    bestStartIndex = startIndex;
                    for (int i = 0; i < inputParts.Length; i++)
                    {
                        bestSequence[i] = inputParts[i];
                    }
                    currentSequenceIndex++;
                    bestSequenceIndex = currentSequenceIndex;
                }
                else if (count == maxCount && startIndex < bestStartIndex)
                {
                    bestStartIndex = startIndex;
                    for (int i = 0; i < inputParts.Length; i++)
                    {
                        bestSequence[i] = inputParts[i];
                    }
                    currentSequenceIndex++;
                    bestSequenceIndex = currentSequenceIndex;
                }
                else if (count == maxCount && startIndex == bestStartIndex)
                {
                    if (inputParts.Sum() > bestSequence.Sum())
                    {
                        for (int i = 0; i < inputParts.Length; i++)
                        {
                            bestSequence[i] = inputParts[i];
                        }
                        currentSequenceIndex++;
                        bestSequenceIndex = currentSequenceIndex;
                    }
                }
                else
                {
                    currentSequenceIndex++;
                }
                
            }
            string result = string.Join(" ", bestSequence);
            Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {bestSequence.Sum()}.");
            Console.WriteLine($"{result}");
        }

        static int FindStartIndex(int[] arr)
        {
            int index = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == 1 && arr[i + 1] == 1)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        static int FindLongestSequence(int[] arr)
        {
            int count = 1;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == 1 && arr[i + 1] == 1)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
