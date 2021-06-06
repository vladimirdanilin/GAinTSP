using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAinTSP
{
    public class Fitness
    {
        double[] Result;
        double[] ResultSorted;
        List<int[]> ListOfSpeciesSorted = new List<int[]>();

        public Fitness(List<int[]> listOfSpeciesUnited, double[,] adjmatrix)
        {
            Selection(listOfSpeciesUnited, adjmatrix);
            
            //PrintResult(ResultSorted);
        }

        public void Selection(List<int[]> listOfSpeciesUnited, double[,] adjmatrix)
        {
            double sum = 0;
            Result = new double[listOfSpeciesUnited.Count];
            ResultSorted = new double[listOfSpeciesUnited.Count];

            foreach (var species in listOfSpeciesUnited)
            {
                sum = Count(species, adjmatrix);
                int n = listOfSpeciesUnited.FindIndex(x=>x==species);
                Result[n] = sum;
            }
            PrintResult(Result);
            ResultSorted = Result;
            Array.Sort(ResultSorted);
            PrintResult(ResultSorted);

            foreach (var item in ResultSorted)
            { 
            
            }
        }

        public double Count(int[] species, double[,] adjmatrix)
        {
            double sum = 0;
            for (int i = 0; i < species.Length; i++)
            {
                if (i == 0)
                { 
                sum = adjmatrix[0, species[i]];
                }
                if (i + 1 < species.Length)
                {
                    sum += adjmatrix[species[i], species[i + 1]];
                }
            }
            return sum;
        }

        public void PrintResult(double[] result)
        {
            Console.WriteLine("=========================================" + "\n Result");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
