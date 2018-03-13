using System;

namespace Exam_Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double sabrePrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            var studentsCountPlus = Math.Ceiling(studentsCount + 0.1*studentsCount);
            var freeBelts = 0;
            for (int i = 1; i <= studentsCount; i++)
            {
                if (i % 6 == 0)
                    freeBelts++;
            }
            
            var priceForSabres = studentsCountPlus * sabrePrice;
            var priceForRobes = studentsCount * robePrice;
            var priceForBelts = (studentsCount - freeBelts) * beltPrice;
            var priceForAll = priceForBelts + priceForRobes + priceForSabres;

            if(priceForAll <= money)
            {
                Console.WriteLine($"The money is enough - it would cost {priceForAll:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {priceForAll-money:F2}lv more.");
            }
        }
    }
}
