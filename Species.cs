using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAinTSP
{
    public class Species
    {
        int NumOfSpecies { get; set; }
        //List<int[]> ListOfParentalSpecies = new List<int[]>();
        //List<int[]> ListOfOffspringSpecies = new List<int[]>();
        //List<int[]> ListOfOffspringSpeciesMutated = new List<int[]>();
        Random random = new Random(DateTime.Now.Millisecond);

        public Species(int numofcities, List<int[]> listOfParentalSpecies, List<int[]> listOfOffspringSpecies, List<int[]> listOfOffspringSpeciesMutated)
        {
            Console.WriteLine("Введите количество особей, которое необходимо сгенерировать: ");
            NumOfSpecies = 6;
            GenerateSpecies(numofcities, listOfParentalSpecies);
            PrintSpecies(listOfParentalSpecies, "ListOfParentalSpecies");
            Crossover(numofcities, listOfParentalSpecies, listOfOffspringSpecies);
            Mutation(numofcities, listOfOffspringSpecies, listOfOffspringSpeciesMutated);
        }


        public void GenerateSpecies(int numofcities, List<int[]> listOfParentalSpecies)
        {
            //Создание начальной популяции
            
            int[] species = new int[numofcities - 1];
            int[] species1 = new int[numofcities - 1];

            for (int i = 0; i < NumOfSpecies; i++)
            {

                for (int j = 0; j < species.Length; j++)
                {
                    species[j] = j+1;
                }
                //Меняем местами гены в рандомном порядке
                species1 = species.OrderBy(x => random.Next()).ToArray();
                listOfParentalSpecies.Add(species1);
            }
        }



        public void Crossover(int numofcities, List<int[]> listOfParentalSpecies, List<int[]> listOfOffspringSpecies)
        {
            int[] mother = new int[numofcities - 1];
            int[] father = new int[numofcities - 1];
            int[] offspring1 = new int[numofcities - 1];
            int[] offspring2 = new int[numofcities - 1];
            for (int i = 0; i < NumOfSpecies/2; i++)
            { //Для каждой "матери" из первой половины начальной популяции рандомным образом подбирается "отец" из второй половины.
                mother = listOfParentalSpecies.ElementAt(i);
                father = listOfParentalSpecies.ElementAt(random.Next(NumOfSpecies/2, NumOfSpecies));
                offspring1 = Breeding(mother, father, numofcities);
                offspring2 = Breeding(father, mother, numofcities);
                //PrintSpecies(mother, "Mother");
                //PrintSpecies(father, "Father");
                //PrintSpecies(offspring1, "Offspring1");
                //PrintSpecies(offspring2, "Offspring2");
                listOfOffspringSpecies.Add(offspring1);
                listOfOffspringSpecies.Add(offspring2);
            }
       

        }

        public int[] Breeding(int[] parent1, int[] parent2, int numofcities)
        {
            int[] offspring = new int[numofcities - 1];
            for (int i = 0; i < 3; i++)
            {
                offspring[i] = parent1[i];
            }

            for (int i = 3; i < numofcities; i++)
            {
                foreach (var gene in parent2)
                {
                    if (!offspring.Contains(gene))
                    {
                        offspring[i] = gene;
                    }
                }
            }

            return offspring;
        }

        public void Mutation(int numofcities, List<int[]> listOfOffspringSpecies, List<int[]> listOfOffspringSpeciesMutated)
        {
            int[] arr;
            //PrintSpecies(ListOfOffspringSpecies, "ListOfOffspringSpecies");

            foreach (var offspring in listOfOffspringSpecies)
            {

                int a = random.Next(0, numofcities - 1);
                //Console.WriteLine("a = " + a);
                int b = random.Next(a + 1, numofcities - 1);
                //Console.WriteLine("b = " + b);
                arr = new int[b - a];
                Array.Copy(offspring, a, arr, 0, arr.Length);
                //PrintSpecies(offspring, "Offspring");
                //PrintSpecies(arr, "Array");

                arr = arr.Reverse().ToArray();

                //PrintSpecies(arr, "ArrayReversed");

                Array.Copy(arr, 0, offspring, a, arr.Length);

                //PrintSpecies(offspring, "OffspringMutated");

                    listOfOffspringSpeciesMutated.Add(offspring);              
              
            }
            PrintSpecies(listOfOffspringSpeciesMutated, "ListOfOffspringSpeciesMutated");

        }


        static bool Contains(int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value) return true;
            }
            return false;
        }

        public void PrintSpecies(List <int[]> list, string name)
        {
            Console.WriteLine(name);
            foreach (var species in list)
            {
                foreach (var city in species)
                {
                    Console.Write(city + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("======================================");
        }

        public void PrintSpecies(int[] array, string name)
        {
            Console.WriteLine(name);
            foreach (var city in array)
            {
                Console.Write(city + " ");
            }
            Console.WriteLine("\n======================================");
        }

        public List<int[]> GetListOfParentalSpecies(List<int[]> listOfParentalSpecies)
        {
            return listOfParentalSpecies;
        }

        public List<int[]> GetListOfOffspringSpeciesMutated(List<int[]> listOfOffspringSpeciesMutated)
        {
            return listOfOffspringSpeciesMutated;
        }




    }
}
