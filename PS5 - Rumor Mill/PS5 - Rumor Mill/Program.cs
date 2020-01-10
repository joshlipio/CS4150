using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS5___Rumor_Mill
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine(); //number of people
            Dictionary<string, Vertex> friendDictionary = new Dictionary<string, Vertex>();

            for (int i = 0; i < int.Parse(input); i++)
            {
                string newFriend = Console.ReadLine();
                friendDictionary.Add(newFriend, new Vertex(newFriend));
            }

            input = Console.ReadLine(); //number of pairs
            for (int i = 0; i < int.Parse(input); i++)
            {
                string newPair = Console.ReadLine();
                string[] newPairSplit = newPair.Split(' ');
                friendDictionary[newPairSplit[0]].children.Add(newPairSplit[1], friendDictionary[newPairSplit[1]]);
                friendDictionary[newPairSplit[1]].children.Add(newPairSplit[0], friendDictionary[newPairSplit[0]]);
            }

            input = Console.ReadLine(); //number of reports
            for (int i = 0; i < int.Parse(input); i++)
            {
                string newReport = Console.ReadLine();
                bfs(friendDictionary, newReport);
                List<Vertex> finalReport = new List<Vertex>();

                foreach (Vertex item in friendDictionary.Values)
                {
                    finalReport.Add(item);
                }

                finalReport = finalReport.OrderBy(x => x.cost).ThenBy(y => y.name).ToList();

                for (int j = 0; j < finalReport.Count; j++)
                {
                    Console.Write(finalReport[j].name + " ");
                }
                Console.WriteLine();
            }
        }

        static void bfs(Dictionary<string, Vertex> friendDictionary, string startVertex)
        {
            foreach (Vertex item in friendDictionary.Values)
            {
                item.cost = Int32.MaxValue;
            }

            friendDictionary[startVertex].cost = 0;
            Queue<Vertex> queue = new Queue<Vertex>();
            queue.Enqueue(friendDictionary[startVertex]);

            while(queue.Count != 0)
            {
                Vertex v = queue.Dequeue();
                foreach (Vertex item in v.children.Values)
                {
                    if (item.cost == Int32.MaxValue)
                    {
                        queue.Enqueue(item);
                        item.cost = v.cost + 1;
                    }
                }
            }
        }
    }
    class Vertex
    {
        public string name;
        public int cost;
        public Dictionary<string, Vertex> children;

        public Vertex(string n)
        {
            name = n;
            children = new Dictionary<string, Vertex>();
        }
    }

}
