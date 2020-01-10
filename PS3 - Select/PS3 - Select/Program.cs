using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS3___Select
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> A = new List<int>(new int[] { 2, 3, 5, 7, 10, 20, 22, });
            List<int> B = new List<int>(new int[] { 1, 3, 8, 9, 14, 17 });

            Console.WriteLine(select(A, B, 5));

        }

        static int select(List<int> A, List<int> B, int k)
        {
            return select(A, 0, A.Count-1, B, 0, B.Count-1, k);
        }

        static int select(List<int>A, int loA, int hiA, List<int> B, int loB, int hiB, int k)
        {
            // A[loA..hiA] is empty
            if (hiA < loA)
                return B[k - loA];
            // B[loB..hiB] is empty
            if (hiB < loB)
                return A[k - loB];
            // Get the midpoints of A[loA..hiA] and B[loB..hiB]
            int i = (loA + hiA) / 2;
            int j = (loB + hiB) / 2;
            // Figure out which one of four cases apply
            if (A[i] > B[j])
            {
                if (k <= i + j) 
                    return select(A, loA, i-1, B, loB, hiB, k);
                else 
                    return select(A, loA, hiA, B, j+1, hiB, k);
            }
            else
            {
                if (k <= i + j) 
                    return select(A, loA, hiA, B, loB, j-1, k);
                else 
                    return select(A, i+1, hiA, B, loB, hiB, k);
            }

        }

    }
}
