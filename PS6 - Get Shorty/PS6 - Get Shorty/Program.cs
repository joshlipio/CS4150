using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS6___Get_Shorty
{
    class Program
    {
        static void Main(string[] args)
        {
            while (input != "0 0") ;
            {
                string input = Console.ReadLine(); //number of n vertices and m edges
                string[] inputInfo = input.Split(' ');
                Dictionary<string, Vertex> pathDictionary = new Dictionary<string, Vertex>();

                for (int i = 0; i < int.Parse(inputInfo[0]); i++)
                {
                    pathDictionary.Add(i.ToString(), new Vertex(i));
                }

                for (int i = 0; i < int.Parse(inputInfo[1]); i++)
                {
                    string newPath = Console.ReadLine();
                    string[] newPathInfo = newPath.Split(' ');
                    pathDictionary[(newPathInfo[0])].children.Add(pathDictionary[(newPathInfo[1])], int.Parse(newPathInfo[2]));     
                }

                dijkstras(pathDictionary, "0");
            }
            
        }

        static void dijkstras(Dictionary<string, Vertex> pathDictionary, string startVertex)
        {
            double currentWeight = 1;
            foreach (Vertex item in pathDictionary.Values)
            {
                item.cost = Int32.MaxValue;
            }

            pathDictionary[startVertex].cost = 1;
            priorityQueue PQ = new priorityQueue();
            PQ.insertOrChange(pathDictionary[startVertex], 1);

            while (PQ.nodes.Count != 0)
            {
                Vertex v = PQ.deleteMax();
                foreach (var item in v.children.Keys)
                {
                    if (v.cost > item.cost * currentWeight)
                    {
                        v.cost = item.cost * currentWeight;
                        PQ.insertOrChange(v, v.cost);
                    }
                }
            }
        }


    }


    class priorityQueue
    {
        public Dictionary<Vertex, double> nodes;

        public priorityQueue()
        {
            nodes = new Dictionary<Vertex, double>();
        }

        public void insertOrChange(Vertex vertex, double weight)
        {
            try
            {
                vertex.cost = weight;
                nodes.Add(vertex, weight);
            }
            catch (ArgumentException e)
            {
                double val;
                nodes.TryGetValue(vertex, out val);
                vertex.cost = weight;
                val = weight;
            }
        }

        public Vertex deleteMax()
        {
            double currentMax = 0;
            Vertex maxKey = nodes.Keys.First();
            foreach (var item in nodes)
            {
                if (item.Value > currentMax)
                {
                    currentMax = item.Value;
                    maxKey = item.Key;
                }
            }
            nodes.Remove(maxKey);
            return maxKey;
            
        }

    }


    class Vertex
    {
        public int vertexNum;
        public double cost;
        public Dictionary<Vertex, double> children;

        public Vertex(int n)
        {
            vertexNum = n;
            children = new Dictionary<Vertex, double>();
        }
    }
}
