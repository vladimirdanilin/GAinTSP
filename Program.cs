using System;
using System.Collections.Generic;
using System.IO;

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
            Console.WriteLine("Введите количество особей, которое необходимо сгенерировать: ");
            int NumOfSpecies = 30;


            Chromosome chromosome = new Chromosome();
            NumOfCities = chromosome.Matrix();

            AdjMatrix = chromosome.GetAdjMatrix();

            GenerateInitialPopulation();
            


            while (ListOfSpeciesSorted[0].Fitness != 11)
            {
                GenerateNewPopulation();
            }

            PrintToFile();


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

            void GenerateInitialPopulation()
            {
                Population initialspecies = new Population(NumOfSpecies);
                ListOfParentalSpecies = initialspecies.GenerateSpecies(NumOfCities, ListOfParentalSpecies);
                initialspecies.PrintGenesOfSpecies(ListOfParentalSpecies, "ListOfParentalSpecies");
                ListOfOffspringSpecies = initialspecies.Crossover(NumOfCities, ListOfParentalSpecies, ListOfOffspringSpecies);
                ListOfOffspringSpeciesMutated = initialspecies.Mutation(NumOfCities, ListOfOffspringSpecies, ListOfOffspringSpeciesMutated);
                ListOfSpeciesUnited = UniteLists(ListOfParentalSpecies, ListOfOffspringSpeciesMutated);
                CountDistance(ListOfSpeciesUnited, AdjMatrix, ListOfSpeciesSorted);
            }

            void GenerateNewPopulation()
            {
                ListOfParentalSpecies.Clear();
                ListOfOffspringSpecies.Clear();
                ListOfOffspringSpeciesMutated.Clear();
                ListOfSpeciesUnited.Clear();
                Population newspecies = new Population(NumOfSpecies);
                newspecies.PrintGenesOfSpecies(ListOfSpeciesSorted, "ListOfParentalSpecies");
                ListOfOffspringSpecies = newspecies.Crossover(NumOfCities, ListOfSpeciesSorted, ListOfOffspringSpecies);
                ListOfOffspringSpeciesMutated = newspecies.Mutation(NumOfCities, ListOfOffspringSpecies, ListOfOffspringSpeciesMutated);
                ListOfSpeciesUnited = UniteLists(ListOfSpeciesSorted, ListOfOffspringSpeciesMutated);
                CountDistance(ListOfSpeciesUnited, AdjMatrix, ListOfSpeciesSorted);
            }

            List<Person> CountDistance(List<Person> listOfSpeciesUnited, double[,] adjMatrix, List<Person> listOfSpeciesSorted)
            {
                Fitness fitness = new Fitness();
                ListOfSpeciesSorted = fitness.CountDistance(listOfSpeciesUnited, adjMatrix, listOfSpeciesSorted);
                return ListOfSpeciesSorted;
            }

            void PrintToFile()
            {
                string writePath = @"C:\Users\Владимир\source\repos\GAinTSP\bin\Debug\results.txt";
                using (var sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    sw.Write("Кратчайший маршрут: 0 ");
                    foreach (var city in ListOfSpeciesSorted[0].Genes)
                    {
                        sw.Write(city + " ");
                    }
                    sw.Write("0 с длиной пути " + ListOfSpeciesSorted[0].Fitness);

                }
            }
            
        }
    }
}
