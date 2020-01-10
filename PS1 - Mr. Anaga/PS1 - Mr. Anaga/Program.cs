using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS1___Mr.Anaga
{
    class Program
    {
        List<string> generatedDictionary = new List<string>();

        static void Main()
        {
            Anaga(File.ReadAllLines("4x5.txt"), 4);
            Anaga(File.ReadAllLines("8x5.txt"), 8);
            Anaga(File.ReadAllLines("16x5.txt"), 16);
            Anaga(File.ReadAllLines("32x5.txt"), 32);
            Anaga(File.ReadAllLines("64x5.txt"), 64);
            Anaga(File.ReadAllLines("128x5.txt"), 128);
            Anaga(File.ReadAllLines("256x5.txt"), 256);
            Anaga(File.ReadAllLines("512x5.txt"), 512);
            Anaga(File.ReadAllLines("1028x5.txt"), 1028);
            Anaga(File.ReadAllLines("2048x5.txt"), 2056);
            Anaga(File.ReadAllLines("4096x5.txt"), 4096);
            Anaga(File.ReadAllLines("8192x5.txt"), 8192);
            Anaga(File.ReadAllLines("4.txt"), 4);
            Anaga(File.ReadAllLines("8.txt"), 8);
            Anaga(File.ReadAllLines("16.txt"), 16);
            Anaga(File.ReadAllLines("32.txt"), 32);
            Anaga(File.ReadAllLines("64.txt"), 64);
            Anaga(File.ReadAllLines("128.txt"), 128);
            Anaga(File.ReadAllLines("256.txt"), 256);
            Anaga(File.ReadAllLines("512.txt"), 512);
            Anaga(File.ReadAllLines("1028.txt"), 1028);
            Anaga(File.ReadAllLines("2048.txt"), 2056);
            Anaga(File.ReadAllLines("4096.txt"), 4096);
            Anaga(File.ReadAllLines("8192.txt"), 8192);

        }
        static void Anaga(string[] lines, int length)
        {
            Console.WriteLine(length);
            Dictionary <string, char[]> dictionary = new Dictionary<string, char[]>();
            List<string> solutions = new List<string>();
            List<string> rejected = new List<string>();


            for (int i = 0; i < lines.Length; i++)
            {
                string newWord = lines[i];
                char[] newWordArray = newWord.ToCharArray();
                if (dictionary.ContainsKey(newWord) == false)
                    dictionary.Add(newWord, newWordArray);
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();

            foreach (var entry in dictionary)
            {
                Array.Sort(entry.Value);
                string sortedWord = new string(entry.Value);
                if (solutions.Contains(sortedWord))
                {
                    solutions.Remove(sortedWord);
                    rejected.Add(sortedWord);
                }
                else if (rejected.Contains(sortedWord) == false)
                {
                    solutions.Add(sortedWord);
                }
            }
            //Console.WriteLine(solutions.Count());
            sw.Stop();
            Console.WriteLine((((double)sw.ElapsedTicks) / Stopwatch.Frequency) * 1000);
        }
    }
}
