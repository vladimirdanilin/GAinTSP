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
        List<Person> listOfSpeciesSorted { get; set;}

        public Fitness()
        {
            
        }

        public List<Person> CountDistance(List<Person> listOfSpeciesUnited, double[,] adjmatrix, List<Person> ListOfSpeciesSorted)
        {
            Selection(listOfSpeciesUnited, adjmatrix);
            SortListOfSpeciesUnited(listOfSpeciesUnited, ListOfSpeciesSorted);
            return listOfSpeciesSorted;
        }

        public void Selection(List<Person> listOfSpeciesUnited, double[,] adjmatrix)
        {
            double sum;
            Result = new double[listOfSpeciesUnited.Count];
            ResultSorted = new double[listOfSpeciesUnited.Count];

            foreach (var person in listOfSpeciesUnited)
            {
                sum = Count(person.Genes, adjmatrix);
                person.Fitness = sum;
            }

        }

        public double Count(int[] genes, double[,] adjmatrix)
        { //Подсчет значения функции пригодности каждой особи
            double sum = 0;
            for (int i = 0; i < genes.Length; i++)
            {
                if (i == 0)
                { 
                sum = adjmatrix[0, genes[i]];
                }
                if (i + 1 < genes.Length)
                {
                    sum += adjmatrix[genes[i], genes[i + 1]];
                }
            }
            sum = sum + adjmatrix[genes[genes.Length-1], 0];
            return sum;
        }

        public void SortListOfSpeciesUnited(List<Person> listOfSpeciesUnited, List<Person> ListOfSpeciesSorted)
        {
            //Сортирует объединенный список по значению функции пригодности. Первые 10 элементов переходят в новый список.

            ListOfSpeciesSorted = listOfSpeciesUnited.OrderBy(x => x.Fitness).ToList();

            int n = ListOfSpeciesSorted.Count()/2;
            int m = ListOfSpeciesSorted.Count()/2;

            ListOfSpeciesSorted.RemoveRange(n, m);

            listOfSpeciesSorted = ListOfSpeciesSorted;
        }

        public List<Person> GetListOfSpeciesSorted()
        {
            return listOfSpeciesSorted;
        }
    }
}
