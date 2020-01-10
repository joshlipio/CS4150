using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS3___Galaxy_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputInformation = Console.ReadLine();
            string[] startingNumbers = inputInformation.Split(' ');
            long[][] starList = new long[long.Parse(startingNumbers[1])][];
            long galaxyDiameter = long.Parse(startingNumbers[0]);

            for (long i = 0; i < long.Parse(startingNumbers[1]); i++)
            {
                string newStar = Console.ReadLine();
                string[] newStarCoords = newStar.Split(' ');
                starList[i] = new long[2] { long.Parse(newStarCoords[0]), long.Parse(newStarCoords[1]) }; 
            }

            long[] majority = findGalaxies(starList, galaxyDiameter);
            if (majority == null)
            {
                Console.WriteLine("NO");
                return;
            }
            Console.WriteLine(countStars(starList, majority, galaxyDiameter));
            return;
        }

        static long[] findGalaxies(long[][] starList, long galaxyDiameter)
        {
            if (starList.Length == 1)
            {
                return starList[0];
            }

            else
            {
                long split = starList.Length / 2;
                long[][] starListLeft = new long[split][];
                long[][] starListRight = new long[starList.Length - split][];

                Array.Copy(starList, 0, starListLeft, 0, split);
                Array.Copy(starList, split, starListRight, 0, starListRight.Length);

                long[] leftStar = findGalaxies(starListLeft, galaxyDiameter);
                long[] rightStar = findGalaxies(starListRight, galaxyDiameter);

                if (leftStar == null && rightStar == null)
                {
                    return null;
                } 

                else if (leftStar == null)
                { 
                    long count = countStars(starList, rightStar, galaxyDiameter);

                    if (count > starList.Length / 2)
                    {
                        return rightStar;
                    }
                    return null;
                }

                else if (rightStar == null)
                {
                    long count = countStars(starList, leftStar, galaxyDiameter);

                    if (count > starList.Length / 2)
                    {
                        return leftStar;
                    }
                    return null;
                }

                else
                {
                    long leftCount = countStars(starList, leftStar, galaxyDiameter);
                    long rightCount = countStars(starList, rightStar, galaxyDiameter);

                    if (leftCount > starList.Length / 2)
                    {
                        return leftStar;
                    }

                    else if (rightCount > starList.Length / 2)
                    {
                        return rightStar;
                    }
                    return null;
                }
            }
        }

        static long countStars(long[][] starList, long[] currentStar, long galaxyDiameter)
        {
            long starCount = 0;
            for (long i = 0; i < starList.Length; i++)
            {
                long xDistance = starList[i][0] - currentStar[0];
                long yDistance = starList[i][1] - currentStar[1];
                long distance = (xDistance * xDistance) + (yDistance * yDistance);

                if (distance < (galaxyDiameter*galaxyDiameter))
                {
                    starCount++;
                }
            }
            return starCount;
        }    
    }
}
