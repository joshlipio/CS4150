using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS12___Traveling_Salesman
{
    class Program
    {

        static int[,] graph;
        static int V;
        static int minEdgeWeight = int.MaxValue;
        static HashSet<int> visited;
        static int bestSoFar = int.MaxValue;

        static void Main(string[] args)
        {
            string input = Console.ReadLine(); 
            V = int.Parse(input);
            graph = new int[V, V];

            for (int i = 0; i < V; i++)
            {
                input = Console.ReadLine();
                string[] nodeSplit = input.Split(' ');
                for (int j = 0; j < V; j++)
                {     
                    graph[i, j] = int.Parse(nodeSplit[j]);
                    minEdgeWeight = Math.Min(minEdgeWeight, int.Parse(nodeSplit[j]));
                }
            }
            visited = new HashSet<int>();
            visited.Add(0);

            tsp(0, 0, 0);
            Console.WriteLine(bestSoFar);
            Console.ReadLine();
        }

        static void tsp(int currentVertex, int currentTotal, int currentLength)
        {
            if (currentTotal + (V - currentLength) * minEdgeWeight >= bestSoFar) return;

            if ( currentLength == V - 1)
            {
                bestSoFar = Math.Min(bestSoFar, currentTotal + graph[currentVertex, 0]);
            }

            else
            {
                for (int vertex = 0; vertex < V; vertex++)
                {
                    if (!visited.Contains(vertex))
                    {
                        visited.Add(vertex);
                        tsp(vertex, currentTotal + graph[currentVertex, vertex], currentLength + 1);
                        visited.Remove(vertex);
                    }
                }
            }  
        }
    }
}
