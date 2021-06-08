using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAinTSP
{
    
    public class Chromosome
    {
        public double[,] AdjMatrix { get; set; }
        public int NumOfCities { get; set; }


        public Chromosome()
        {
            AddAdjMatrix();
            PrintAdjMatrix();
            //GetAdjMatrix(AdjMatrix);
        }

        public void AddAdjMatrix()
        {


            #region
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
            /*AdjMatrix[0, 1] = 2;
            AdjMatrix[0, 2] = 3;
            AdjMatrix[0, 3] = 2;
            AdjMatrix[0, 4] = 4;
            AdjMatrix[0, 5] = 2;
            AdjMatrix[1, 0] = 2;
            AdjMatrix[1, 2] = 1;
            AdjMatrix[1, 3] = 2;
            AdjMatrix[1, 4] = 3;
            AdjMatrix[1, 5] = 1;
            AdjMatrix[2, 0] = 3;
            AdjMatrix[2, 1] = 1;
            AdjMatrix[2, 3] = 5;
            AdjMatrix[2, 4] = 6;
            AdjMatrix[2, 5] = 5;
            AdjMatrix[3, 0] = 2;
            AdjMatrix[3, 1] = 2;
            AdjMatrix[3, 2] = 8;
            AdjMatrix[3, 4] = 9;
            AdjMatrix[3, 5] = 6;
            AdjMatrix[4, 0] = 4;
            AdjMatrix[4, 1] = 3;
            AdjMatrix[4, 2] = 6;
            AdjMatrix[4, 3] = 9;
            AdjMatrix[4, 5] = 2;
            AdjMatrix[5, 0] = 2;
            AdjMatrix[5, 1] = 1;
            AdjMatrix[5, 2] = 5;
            AdjMatrix[5, 3] = 6;

            using (var sw = new StreamWriter("text.txt"))
            {
                for (int i = 0; i < numofcities; i++)
                {
                    for (int j = 0; j < numofcities; j++)
                    {
                        if (i != j)
                        {
                            sw.Write(AdjMatrix[i, j] + " ");
                        }
                        else
                        {
                            sw.Write("0 ");
                        }
                    }
                    sw.WriteLine();
                }
            }*/

            #endregion

            string[] strings = File.ReadAllLines(@"C:\Users\Владимир\source\repos\GAinTSP\bin\Debug\text.txt");
            NumOfCities = strings[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
            AdjMatrix = new double[NumOfCities, NumOfCities];


            for (int i = 0; i < NumOfCities; i++)
            {
                int[] row = strings[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < NumOfCities; j++)
                {
                    AdjMatrix[i, j] = row[j];
                }

            }
            Console.WriteLine(NumOfCities);

        }

       

        void PrintAdjMatrix()
        {
            for (int i = 0; i < NumOfCities; i++)
            {
                for (int j = 0; j < NumOfCities; j++)
                {
                    Console.Write(AdjMatrix[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        public double[,] GetAdjMatrix()
        {
            return AdjMatrix;
        }

        public int GetNumOfCities()
        {
            return NumOfCities;
        }
    }
}
