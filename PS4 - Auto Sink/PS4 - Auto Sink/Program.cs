using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS4___Auto_Sink
{
    class Program
    {
        public static List<Vertex> vertexList = new List<Vertex>();

        static void Main(string[] args)
        {
            string input = Console.ReadLine(); //number of cities
            Dictionary<string, Vertex> routeDictionary = new Dictionary<string, Vertex>();

            for (int i = 0; i < int.Parse(input); i++)
            {
                string newCity = Console.ReadLine();
                string[] newCityInformation = newCity.Split(' ');
                routeDictionary.Add(newCityInformation[0], new Vertex(int.Parse(newCityInformation[1])));
            }

            input = Console.ReadLine(); //number of routes
            for (int i = 0; i < int.Parse(input); i++)
            {
                string newRoute = Console.ReadLine();
                string[] newRouteInformation = newRoute.Split(' ');
                routeDictionary[newRouteInformation[0]].children.Add(newRouteInformation[1], routeDictionary[newRouteInformation[1]]);
            }

            dfs(routeDictionary);

            input = Console.ReadLine(); //paths to check
            for (int i = 0; i < int.Parse(input); i++)
            {
                string route = Console.ReadLine();
                string[] routeInformation = route.Split(' ');

                Vertex source = routeDictionary[routeInformation[0]];
                Vertex sink = routeDictionary[routeInformation[1]];
                autoSink(routeDictionary, source);

                if (sink.costSoFar == Int32.MaxValue)
                {
                    Console.WriteLine("NO");
                }
                else
                {
                    Console.WriteLine(sink.costSoFar);
                }
            }
        }

        static void autoSink(Dictionary<string, Vertex> routeDict, Vertex source)
        {
            Stack<Vertex> stack = new Stack<Vertex>();

            foreach (Vertex item in vertexList)
            {
                stack.Push(item);
            }

            foreach (Vertex item in routeDict.Values)
            {
                item.costSoFar = Int32.MaxValue;
            }

            source.costSoFar = 0;

            while (stack.Count != 0)
            {
                Vertex v = stack.Pop();
                if (v.costSoFar != Int32.MaxValue)
                {
                    foreach (Vertex item in v.children.Values)
                    {
                        if (item.costSoFar > v.costSoFar + item.cost)
                        {
                            item.costSoFar = v.costSoFar + item.cost;
                        }
                    }
                }
            }
        }


        static void dfs(Dictionary<string, Vertex> routeDict)
        {
            foreach (Vertex item in routeDict.Values)
            {
                item.explored = false;
            }
            foreach (Vertex item in routeDict.Values)
            {
                if (item.explored == false)
                    explore(routeDict, item);
            }
        }

        static void explore(Dictionary<string,Vertex> routeDict, Vertex v)
        {
            
            v.explored = true;
            foreach (Vertex item in v.children.Values)
            {
                if (item.explored == false)
                    explore(item.children, item);
            }
            vertexList.Add(v);
        }
    }

    class Vertex
    {
        public int cost;
        public int costSoFar;
        public bool explored;
        public Dictionary<string, Vertex> children;

        public Vertex(int c)
        {
            cost = c;
            children = new Dictionary<string, Vertex>();
        }
    }
}
