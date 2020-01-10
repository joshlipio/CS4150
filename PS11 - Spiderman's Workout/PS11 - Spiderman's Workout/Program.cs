using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS11___Spiderman_s_Workout
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine(); //number of test scenarios
            int numScenarios = int.Parse(input);

            for (int i = 0; i < numScenarios; i++)
            {
                Console.ReadLine(); //Reads first line containing num of distances
                string newScenario = Console.ReadLine();
                string[] stringDistances = newScenario.Split(' ');
                List<int> distances = new List<int>();
                foreach (string item in stringDistances)
                {
                    distances.Add(int.Parse(item));
                }
                Console.WriteLine(WorkoutHelper(distances));
            }
        }

        private static string WorkoutHelper(List<int> distances)
        {
            if (distances.Count() % 2 != 0)
                return "IMPOSSIBLE";

            Dictionary<int, string> paths = new Dictionary<int, string>();
            Workout(distances, 0, 0, 0, true, "U", paths);

            if (paths.Count == 0)
                return "IMPOSSIBLE";

            else
                return paths[paths.Keys.Min()];
        }

        private static string Workout(List<int> distances, int currentPoint, int currentHeight, int maxHeight, bool goingUp, string pathSoFar, Dictionary<int, string> cache)
        {
            string result;
            if (cache.TryGetValue(currentPoint, out result))
            {
                return result;
            }

            if (currentPoint == distances.Count - 1 && currentHeight - distances[currentPoint] == 0 && !goingUp && !cache.ContainsKey(maxHeight))
            {
                cache[currentPoint] = pathSoFar; 
            }

            else
            {
                cache[currentPoint] = "IMPOSSIBLE";
            }

            if (currentPoint + 1 <= distances.Count)
            {

                if (goingUp)
                    currentHeight += distances[currentPoint];

                else
                    currentHeight -= distances[currentPoint];
                maxHeight = Math.Max(currentHeight, maxHeight);
                Workout(distances, currentPoint + 1, currentHeight, maxHeight, true, pathSoFar + "U", cache);
                if (currentHeight - distances[currentPoint + 1] >= 0)
                    Workout(distances, currentPoint + 1, currentHeight, maxHeight, false, pathSoFar + "D", cache);
            }

            return cache[currentPoint];

            //string result;
            //if (cache.TryGetValue(currentPoint, out result))
            //{
            //    return result;
            //}

            //if (currentHeight - distances[currentPoint + 1] >= 0)
            //{
            //    string up = Workout(distances, currentPoint + 1, currentHeight, maxHeight, true, pathSoFar + "U", cache);
            //    string down = Workout(distances, currentPoint + 1, currentHeight, maxHeight, false, pathSoFar + "D", cache);
            //    cache[currentPoint] = 
            //}

            //else
            //{
            //    cache[currentPoint] = Workout(distances, currentPoint + 1, currentHeight, maxHeight, true, pathSoFar + "U", cache);
            //}
            //return cache[currentPoint];
        }
    }
}
