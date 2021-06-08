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
            
        }

        public int Matrix()
        {
            AddAdjMatrix();
            PrintAdjMatrix();
            return NumOfCities;
        }

        public void AddAdjMatrix()
        {

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

    }
}
