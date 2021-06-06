using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAinTSP
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int[]> ListOfParentalSpecies = new List<int[]>();
            List<int[]> ListOfOffspringSpecies = new List<int[]>();
            List<int[]> ListOfOffspringSpeciesMutated = new List<int[]>();

            List<int[]> ListOfSpeciesUnited = new List<int[]>();
            double[,] AdjMatrix;

            Console.WriteLine("Введите количество городов: ");
            int NumOfCities = 5;

            Chromosome chromosome = new Chromosome(NumOfCities);

            Species species = new Species(NumOfCities, ListOfParentalSpecies, ListOfOffspringSpecies, ListOfOffspringSpeciesMutated);
            ListOfParentalSpecies = species.GetListOfParentalSpecies(ListOfParentalSpecies);
            ListOfOffspringSpeciesMutated = species.GetListOfOffspringSpeciesMutated(ListOfOffspringSpeciesMutated);
            ListOfSpeciesUnited = AddListToList(ListOfParentalSpecies, ListOfOffspringSpeciesMutated);

            foreach (var item in ListOfSpeciesUnited)
            {
                foreach (var item1 in item)
                {
                    Console.Write(item1);
                }
                Console.WriteLine();
            }
            AdjMatrix = chromosome.GetAdjMatrix();
            Fitness fitness = new Fitness(ListOfSpeciesUnited, AdjMatrix);

            /*
             while ( F > 13)
            Новый список потомков из старых
            Мутации
            Фитнесс
            */

            List<int[]> AddListToList(List<int[]> list1, List<int[]> list2)
            {
                foreach (var item in list1)
                {
                    ListOfSpeciesUnited.Add(item);
                }
                foreach (var item in list2)
                {
                    if (ListOfSpeciesUnited.Contains(item))
                        ListOfSpeciesUnited.Remove(item);
                }
                foreach (var item in list2)
                {
                    ListOfSpeciesUnited.Add(item);
                }
                
                return ListOfSpeciesUnited;
            }
        }
    }
}
