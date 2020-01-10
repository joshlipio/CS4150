using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS2___Ceiling_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputInformation = Console.ReadLine();
            string[] startingNumbers = inputInformation.Split(' ');
            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < int.Parse(startingNumbers[0]); i++)
            {
                string newTree = Console.ReadLine();
                string[] newTreeNumbers = newTree.Split(' ');
                binaryTree newBinaryTree = new binaryTree();
                for (int j  = 0; j < newTreeNumbers.Length; j++)
                {
                    newBinaryTree.Add(int.Parse(newTreeNumbers[j]));
                }
                set.Add(newBinaryTree.traversal());
            }
            Console.WriteLine(set.Count);
        }
    }

    class Node
    {
        public int value;
        public Node left;
        public Node right;

        public Node(int initial)
        {
            value = initial;
            left = null;
            right = null;
        }
    }

    class binaryTree
    {
        public Node top;
        public string stringTraversal;

        public binaryTree()
        {
            top = null;
        }

        public binaryTree(int initial)
        {
            top = new Node(initial);
        }

        public void Add(int value)
        {
            addRecursive(ref top, value);
        }

        private void addRecursive(ref Node currentNode, int value)
        {
            if (currentNode == null)
            {
                Node newNode = new Node(value);
                currentNode = newNode;
                return;
            }

            if (value <= currentNode.value)
            {
                addRecursive(ref currentNode.left, value);
                return;
            }

            if (value > currentNode.value)
            {
                addRecursive(ref currentNode.right, value);
                return;
            }
        }

        public string traversal()
        {
            stringTraversal = "";
            traverseRecursive(top);
            return stringTraversal;
        }

        public void traverseRecursive(Node currentNode)
        {
            if (currentNode.left != null)
            {
                stringTraversal += "l";
                traverseRecursive(currentNode.left);       
            }    
            if (currentNode.right != null)
            {
                stringTraversal += "r";
                traverseRecursive(currentNode.right);
            }
            stringTraversal += "n";


        }
    }
}
