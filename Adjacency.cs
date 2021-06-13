using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAinTSP
{

    public class Adjacency
    {
        public double[,] AdjMatrix { get; set; }
        public int NumOfCities { get; set; }


        public Adjacency()
        {
            
        }

        public int Matrix(string inputFile)
        {
            AddAdjMatrix(inputFile);
            return NumOfCities;
        }

        public void AddAdjMatrix(string inputFile)
        {
            //Получение матрицы смежности из txt файла
            string InputPath = "C:\\Users\\Владимир\\source\\repos\\GAinTSP — MAIN\\bin\\Debug\\";
            string InputPathDefault = "C:\\Users\\Владимир\\source\\repos\\GAinTSP — MAIN\\bin\\Debug\\text.txt";
            string[] strings = File.ReadAllLines(@InputPathDefault);

            if (inputFile != null)
            {
                InputPath = InputPath + inputFile;
                strings = File.ReadAllLines(@InputPath);
            }
            

            NumOfCities = strings[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
            AdjMatrix = new double[NumOfCities, NumOfCities];


            for (int i = 0; i < NumOfCities; i++)
            {
                double[] row = strings[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                for (int j = 0; j < NumOfCities; j++)
                {
                    AdjMatrix[i, j] = row[j];
                }

            }

        }

      

        public double[,] GetAdjMatrix()
        {
            return AdjMatrix;
        }

    }
}
