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
            List<Person> ListOfParentalSpecies = new List<Person>();
            List<Person> ListOfOffspringSpecies = new List<Person>();
            List<Person> ListOfOffspringSpeciesMutated = new List<Person>();
            List<Person> ListOfSpeciesUnited = new List<Person>();
            List<Person> ListOfSpeciesSorted = new List<Person>();
            double[,] AdjMatrix;
            int NumOfCities;


            Chromosome chromosome = new Chromosome();
            NumOfCities = chromosome.GetNumOfCities();

            Population initialspecies = new Population(NumOfCities, ListOfParentalSpecies, ListOfOffspringSpecies, ListOfOffspringSpeciesMutated);
            
            ListOfSpeciesUnited = UniteLists(ListOfParentalSpecies, ListOfOffspringSpeciesMutated);

            foreach (var person in ListOfSpeciesUnited)
            {
                foreach (var gene in person.Genes)
                {
                    Console.Write(gene);
                }
                Console.WriteLine();
            }
            AdjMatrix = chromosome.GetAdjMatrix();

            Fitness fitness = new Fitness(ListOfSpeciesUnited, AdjMatrix, ListOfSpeciesSorted);

            ListOfSpeciesSorted = fitness.GetListOfSpeciesSorted();

            while (ListOfSpeciesSorted[0].Fitness > 4)
            {
                ListOfParentalSpecies.Clear();
                ListOfOffspringSpecies.Clear();
                ListOfOffspringSpeciesMutated.Clear();
                ListOfSpeciesUnited.Clear();
                Population species = new Population(ListOfSpeciesSorted, ListOfOffspringSpecies, ListOfOffspringSpeciesMutated, NumOfCities);
                //ListOfParentalSpecies = species.GetListOfParentalSpecies(ListOfParentalSpecies);
                //ListOfOffspringSpeciesMutated = species.GetListOfOffspringSpeciesMutated(ListOfOffspringSpeciesMutated);
                ListOfSpeciesUnited = UniteLists(ListOfSpeciesSorted, ListOfOffspringSpeciesMutated);

                foreach (var person in ListOfSpeciesUnited)
                {
                    foreach (var gene in person.Genes)
                    {
                        Console.Write(gene);
                    }
                    Console.WriteLine();
                }
                AdjMatrix = chromosome.GetAdjMatrix();

                fitness = new Fitness(ListOfSpeciesUnited, AdjMatrix, ListOfSpeciesSorted);
                
                ListOfSpeciesSorted = fitness.GetListOfSpeciesSorted();
            }
            /*
             while ( F > 13)
            Новый список потомков из старых
            Мутации
            Фитнесс
            */

            List<Person> UniteLists(List<Person> species1, List<Person> species2)
            {
                foreach (var person in species1)
                {
                    ListOfSpeciesUnited.Add(person);
                }
                foreach (var person in species2)
                {
                    if (ListOfSpeciesUnited.Contains(person))
                        ListOfSpeciesUnited.Remove(person);
                }
                foreach (var person in species2)
                {
                    ListOfSpeciesUnited.Add(person);
                }
                
                return ListOfSpeciesUnited;
            }

            void FindSmallestDistance()
            {
                foreach (var person in ListOfSpeciesUnited) ;
            }
        }
    }
}
