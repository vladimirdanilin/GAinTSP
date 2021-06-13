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
        double PercentOfMutation = 100;
        double Result; //Значение функции пригодности
        int NumOfPopulations;
        int MaxNumOfPopulations = 60; //Дефолтное значение количества поколений, после которого генерируется новое начальное поколение
        bool Checked;
        string krit = ""; //Зависит от k (Было ли достигнуто критическое число поколений)
        public Start(int numOfSpecies, double result, int numOfPopulations, bool Checked1, int maxNumOfPopulations, double percentOfMutation)
        {
            NumOfSpecies = numOfSpecies;
            Result = result;
            NumOfPopulations = numOfPopulations;
            Checked = Checked1;
            /*if (numOfSpeciesForCrossover != 0)
            {
                NumOfSpeciesForCrossover = numOfSpeciesForCrossover;
            }
            else
            {
                NumOfSpeciesForCrossover = NumOfSpecies;
            }*/
            if (maxNumOfPopulations != 0)
            {
                MaxNumOfPopulations = maxNumOfPopulations;
            }

            if (percentOfMutation != 0)
            {
                PercentOfMutation = percentOfMutation;
            }


        }
        



        double[,] AdjMatrix;
        

        public void Run(string inputFile, string outputFile)
        {
            Adjacency adjacency = new Adjacency();
            NumOfCities = adjacency.Matrix(inputFile);
            AdjMatrix = adjacency.GetAdjMatrix();

            if (Checked == true)
            {
                AppStartResult();
            }
            else
            { 
                AppStartPopulations();
            }
            

            

            void AppStartResult() //Запускается метод, работающий по минимальному значению функции пригодности
            {
                GenerateInitialPopulation();
                int n = 1; //Число поколений, по истечению которого происходит новая генерация начального поколения.
                int k = 1; //Максимально возможное число поколений(Критическое число).
                
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
                if (k == 200)
                {
                    krit = "Было достигнуто критическое количество поколений (200). Решение не найдено!";
                }

                PrintToFile(outputFile, ListOfSpeciesSorted, krit);
            }

            void AppStartPopulations() //Запускается метод, работающий по количеству поколений
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
                        foreach (var person in ListOfSpeciesSorted)
                        {
                            if (person.Fitness == ListOfSpeciesSorted[0].Fitness)
                            {
                                BestSpecies.Add(person);
                            }
                        }
                        
                    }

                    BestSpecies = BestSpecies.OrderBy(x => x.Fitness).ToList();

                }
                
                PrintToFile(outputFile, BestSpecies, krit);

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
                //Генерируется исходное (начальное поколение)
                Population initialspecies = new Population(NumOfSpecies);
                ListOfParentalSpecies = initialspecies.GenerateSpecies(NumOfCities, ListOfParentalSpecies);
                ListOfOffspringSpecies = initialspecies.Crossover(NumOfCities, ListOfParentalSpecies, ListOfOffspringSpecies);
                ListOfOffspringSpeciesMutated = initialspecies.Mutation(NumOfCities, ListOfOffspringSpecies, ListOfOffspringSpeciesMutated, PercentOfMutation);
                ListOfSpeciesUnited = UniteLists(ListOfParentalSpecies, ListOfOffspringSpeciesMutated);
                CountDistance(ListOfSpeciesUnited, AdjMatrix, ListOfSpeciesSorted);
            }

            void GenerateNewPopulation()
            {
                //Генерируется новое поколение из ListOfSpeciesSorted (Лучшие особи)
                ListOfParentalSpecies.Clear();
                ListOfOffspringSpecies.Clear();
                ListOfOffspringSpeciesMutated.Clear();
                ListOfSpeciesUnited.Clear();
                Population newspecies = new Population(NumOfSpecies);
                ListOfOffspringSpecies = newspecies.Crossover(NumOfCities, ListOfSpeciesSorted, ListOfOffspringSpecies);
                ListOfOffspringSpeciesMutated = newspecies.Mutation(NumOfCities, ListOfOffspringSpecies, ListOfOffspringSpeciesMutated, PercentOfMutation);
                ListOfSpeciesUnited = UniteLists(ListOfSpeciesSorted, ListOfOffspringSpeciesMutated);
                CountDistance(ListOfSpeciesUnited, AdjMatrix, ListOfSpeciesSorted);
            }

            List<Person> CountDistance(List<Person> listOfSpeciesUnited, double[,] adjMatrix, List<Person> listOfSpeciesSorted)
            {
                Fitness fitness = new Fitness();
                ListOfSpeciesSorted = fitness.CountDistance(listOfSpeciesUnited, adjMatrix, listOfSpeciesSorted);
                return ListOfSpeciesSorted;
            }

            void PrintToFile(string OutputFile, List <Person> list, string krit)
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

                List<Person> TestList = new List<Person>();
                
                TestList.AddRange(list.ToList());

                foreach (var person in list) //Отбираются только лучшие особи с минимальным значением функции качества
                {
                    if (person.Fitness != list[0].Fitness)
                    {
                        TestList.Remove(person);
                    }
                }


                double[] arr = new double[TestList.Count]; //Массив для исключения повторяющихся элементов
                for (int i = 0; i < TestList.Count; i++)
                {
                    arr[i] = TestList[i].Fitness;
                }


                for (int i = 0; i < TestList.Count; i++)
                {
                    if (arr[i] != 0)
                    {

                        for (int j = i + 1; j < TestList.Count; j++)
                        {
                            if (TestList[i].Genes.SequenceEqual(TestList[j].Genes))
                            {
                                arr[j] = 0; //Если элемент повторяется, значение в массиве с его индексом равно 0
                            }
                        }
                    }
                }


                using (var sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    if (krit.Length != 0)
                    {
                        sw.Write(krit);
                    }
                    else
                    {
                        for (int i = 0; i < TestList.Count; i++)
                        {
                            if (arr[i] != 0)
                            {
                                sw.Write("Кратчайший маршрут: 0 ");
                                foreach (var city in TestList[i].Genes)
                                {
                                    sw.Write(city + " ");
                                }
                                sw.Write("0 с длиной пути " + TestList[i].Fitness + "\n");
                            }
                        }
                    }
                }
            }

            
        }
        
    }
}
