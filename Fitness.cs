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

        public Fitness(List<Person> listOfSpeciesUnited, double[,] adjmatrix, List<Person> ListOfSpeciesSorted)
        {
            Selection(listOfSpeciesUnited, adjmatrix);
            SortListOfSpeciesUnited(listOfSpeciesUnited, ListOfSpeciesSorted);
            PrintSpecies(listOfSpeciesSorted);
        }

        public void Selection(List<Person> listOfSpeciesUnited, double[,] adjmatrix)
        {
            double sum = 0;
            Result = new double[listOfSpeciesUnited.Count];
            ResultSorted = new double[listOfSpeciesUnited.Count];

            foreach (var person in listOfSpeciesUnited)
            {
                sum = Count(person.Genes, adjmatrix);
                int n = listOfSpeciesUnited.FindIndex(x => x == person);
                person.Fitness = sum;
                person.PrintPersonInfo();
            }

        }

        public double Count(int[] genes, double[,] adjmatrix)
        {
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
            return sum;
        }

        public void SortListOfSpeciesUnited(List<Person> listOfSpeciesUnited, List<Person> ListOfSpeciesSorted)
        {
            ListOfSpeciesSorted = listOfSpeciesUnited.OrderBy(x => x.Fitness).ToList();

            int n = ListOfSpeciesSorted.Count()/2;
            int m = ListOfSpeciesSorted.Count()/2;

            ListOfSpeciesSorted.RemoveRange(n, m);

            listOfSpeciesSorted = ListOfSpeciesSorted;
        }


        public void PrintSpecies(List<Person> listOfSpeciesUnited)
        {
            Console.WriteLine("=====================================");
            foreach (var person in listOfSpeciesUnited)
            {
                person.PrintPersonInfo();
            }
        }

        public List<Person> GetListOfSpeciesSorted()
        {
            return listOfSpeciesSorted;
        }
    }
}
