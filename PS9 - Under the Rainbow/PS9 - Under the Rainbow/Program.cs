using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS9___Under_the_Rainbow
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine(); //number of hotels
            int hotelNumber = int.Parse(input) + 1;
            List<int> hotels = new List<int>();

            //add all hotels to hotelList
            for (int i = 0; i < hotelNumber; i++)
            {
                string hotelDistance = Console.ReadLine();
                hotels.Add(int.Parse(hotelDistance));
            }
            Console.WriteLine(PenaltyHelper(hotelNumber, hotels)); 

        }

        private static int PenaltyHelper(int hotelNumber, List<int> hotels)
        {
            Dictionary<int, int> paths = new Dictionary<int, int>();
            int min = int.MaxValue;
            for (int i = hotels.Count - 1; i >= 0; i--)
            {
                min = Math.Min(min, Penalty(i, hotels, paths));
            }
            return min;
        }

        private static int Penalty(int i, List<int> hotels, Dictionary<int,int> paths)
        {
            int result;
            int min = int.MaxValue;

            if (paths.TryGetValue(i, out result))
            {
                return result;
            }

            else if (hotels.Count - 1 == i)
            {
                return 0;
            }
            else
            {
                for (int j = i+1; j < hotels.Count; j++)
                {
                    result = ((400 - (hotels[j] - hotels[i])) * (400 - (hotels[j] - hotels[i]))) + Penalty(j, hotels, paths);
                    min = Math.Min(min, result);
                }
                paths[i] = min;
                return min;
            }
            
        }
    }
}
