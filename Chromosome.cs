using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAinTSP
{
    
    public class Chromosome
    {
        public double[,] AdjMatrix { get; set; }


        public Chromosome(int numofcities)
        {
            AddAdjMatrix(numofcities);
            PrintAdjMatrix(numofcities);
            //GetAdjMatrix(AdjMatrix);
        }

        public void AddAdjMatrix(int numofcities)
        {

            AdjMatrix = new double[numofcities, numofcities];

            /*for (int i = 0; i < numofcities; i++)
            {
                for (int j = 0; j < numofcities; j++)
                {
                    if (i != j)
                    {
                        //Console.WriteLine($"Введите расстояние между {i} и {j} городом: ");
                        AdjMatrix[i, j] = 1;
                    }
                    
                }
            }*/
            AdjMatrix[0, 1] = 2;
            AdjMatrix[0, 2] = 3;
            AdjMatrix[0, 3] = 2;
            AdjMatrix[0, 4] = 4;
            AdjMatrix[1, 2] = 1;
            AdjMatrix[1, 3] = 2;
            AdjMatrix[1, 4] = 3;
            AdjMatrix[2, 1] = 1;
            AdjMatrix[2, 3] = 5;
            AdjMatrix[2, 4] = 6;
            AdjMatrix[3, 1] = 2;
            AdjMatrix[3, 2] = 8;
            AdjMatrix[3, 4] = 9;
            AdjMatrix[4, 1] = 3;
            AdjMatrix[4, 2] = 6;
            AdjMatrix[4, 3] = 9;

        }

       

        public void PrintAdjMatrix(int numofcities)
        {
            for (int i = 0; i < numofcities; i++)
            {
                for (int j = 0; j < numofcities; j++)
                {
                    Console.Write($"\t ({i} и {j})=:" + AdjMatrix[i,j]);
                }
                Console.WriteLine();
            }
        }

        public double[,] GetAdjMatrix()
        {
            return AdjMatrix;
        }
    }
}
