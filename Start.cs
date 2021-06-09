using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAinTSP
{
    public class Start
    {
        List<Person> ListOfParentalSpecies = new List<Person>();
        List<Person> ListOfOffspringSpecies = new List<Person>();
        List<Person> ListOfOffspringSpeciesMutated = new List<Person>();
        List<Person> ListOfSpeciesUnited = new List<Person>();
        List<Person> ListOfSpeciesSorted = new List<Person>();
        List<Person> BestSpecies = new List<Person>();
        int NumOfCities;
        int NumOfSpecies;
        double Result;
        int NumOfPopulations;
        int MaxNumOfPopulations = 60;
        bool Checked;
        public Start(int numOfSpecies, double result, int numOfPopulations, bool Checked1, int maxNumOfPopulations)
        {
            NumOfSpecies = numOfSpecies;
            Result = result;
            NumOfPopulations = numOfPopulations;
            Checked = Checked1;
            if (maxNumOfPopulations != 0)
            {
                MaxNumOfPopulations = maxNumOfPopulations;
            }
            
        }



        double[,] AdjMatrix;
        

        public void Run(string inputFile, string outputFile)
        {
            Chromosome chromosome = new Chromosome();
            NumOfCities = chromosome.Matrix(inputFile);
            AdjMatrix = chromosome.GetAdjMatrix();

            if (Checked == true)
            {
                AppStartResult();
            }
            else
            { 
                AppStartPopulations();
            }
            

            

            void AppStartResult()
            {
                GenerateInitialPopulation();
                int n = 1; //Число поколений, по истечению которого происходит новая генерация начального поколения.
                int k = 1; //Максимально возможное число поколений.
                while ((ListOfSpeciesSorted[0].Fitness > Result) && (k < 200))
                {
                    GenerateNewPopulation();
                    n++;

                    if (n == MaxNumOfPopulations)
                    { 
                        GenerateInitialPopulation();
                        n = 1;
                    }
                    k++;
                }
                Console.WriteLine(k);

                PrintToFile(outputFile, ListOfSpeciesSorted);

            }

            void AppStartPopulations()
            {
                int n = 1;
                GenerateInitialPopulation();
                BestSpecies.Add(ListOfSpeciesSorted[0]);
                if (NumOfPopulations > 0)
                {
                    while (n != NumOfPopulations)
                    { 
                        GenerateNewPopulation();
                        n++;
                        BestSpecies.Add(ListOfSpeciesSorted[0]);
                    }
                    Console.WriteLine(n);
                    Console.WriteLine("++++++++++++++++++++++++++++++");
                    foreach (var item in BestSpecies)
                    {
                        item.PrintPersonInfo();
                    }
                    BestSpecies = BestSpecies.OrderBy(x => x.Fitness).ToList();
                    Console.WriteLine("++++++++++++++++++++++++++++++");
                    foreach (var item in BestSpecies)
                    {
                        item.PrintPersonInfo();
                    }
                }
                

                PrintToFile(outputFile, BestSpecies);

                Console.WriteLine("++++++++++++++++++++++++++++++");
            }



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

            void PrintToFile(string OutputFile, List <Person> list)
            {
                string writePath = "C:\\Users\\Владимир\\source\\repos\\GAinTSP — MAIN\\bin\\Debug\\";
                string writePathDefault = @"C:\Users\Владимир\source\repos\GAinTSP — MAIN\bin\Debug\result.txt";

                if (OutputFile != null)
                {
                    writePath = writePath + OutputFile;
                }
                else
                {
                    writePath = writePathDefault;
                }
                
                using (var sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    sw.Write("Кратчайший маршрут: 0 ");
                    foreach (var city in list[0].Genes)
                    {
                        sw.Write(city + " ");
                    }
                    sw.Write("0 с длиной пути " + list[0].Fitness);

                }
            }
        }
        
    }
}
