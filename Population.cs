using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAinTSP
{
    public class Population
    {
        int NumOfSpecies { get; set; }
        //List<int[]> ListOfParentalSpecies = new List<int[]>();
        //List<int[]> ListOfOffspringSpecies = new List<int[]>();
        //List<int[]> ListOfOffspringSpeciesMutated = new List<int[]>();
        Random random = new Random(DateTime.Now.Millisecond);

        public Population(int numofcities, List<Person> listOfParentalSpecies, List<Person> listOfOffspringSpecies, List<Person> listOfOffspringSpeciesMutated)
        {
            Console.WriteLine("Введите количество особей, которое необходимо сгенерировать: ");
            NumOfSpecies = 10;
            GenerateSpecies(numofcities, listOfParentalSpecies);
            PrintGenesOfSpecies(listOfParentalSpecies, "ListOfParentalSpecies");
            Crossover(numofcities, listOfParentalSpecies, listOfOffspringSpecies);
            Mutation(numofcities, listOfOffspringSpecies, listOfOffspringSpeciesMutated);
        }

        public Population(List<Person> listOfSortedSpecies, List<Person> listOfOffspringSpecies, List<Person> listOfOffspringSpeciesMutated, int numofcities)
        {
            Console.WriteLine("Введите количество особей, которое необходимо сгенерировать: ");
            NumOfSpecies = 10;
            PrintGenesOfSpecies(listOfSortedSpecies, "ListOfParentalSpecies");
            Crossover(numofcities, listOfSortedSpecies, listOfOffspringSpecies);
            Mutation(numofcities, listOfOffspringSpecies, listOfOffspringSpeciesMutated);
        }



        public void GenerateSpecies(int numofcities, List<Person> listOfParentalSpecies)
        {
            //Создание начальной популяции
            
            int[] genes = new int[numofcities - 1];
            int[] genes1 = new int[numofcities - 1];

            for (int i = 0; i < NumOfSpecies; i++)
            {

                for (int j = 0; j < genes.Length; j++)
                {
                    genes[j] = j+1;
                }
                //Меняем местами гены в рандомном порядке
                genes1 = genes.OrderBy(x => random.Next()).ToArray();
                Person person = new Person(genes1, 0);
                listOfParentalSpecies.Add(person);
            }
        }



        public void Crossover(int numofcities, List<Person> listOfParentalSpecies, List<Person> listOfOffspringSpecies)
        {
            int[] mother = new int[numofcities - 1];
            int[] father = new int[numofcities - 1];
            int[] offspring1 = new int[numofcities - 1];
            int[] offspring2 = new int[numofcities - 1];
            for (int i = 0; i < NumOfSpecies/2; i++)
            { //Для каждой "матери" из первой половины начальной популяции рандомным образом подбирается "отец" из второй половины.
                mother = listOfParentalSpecies.ElementAt(i).Genes;
                father = listOfParentalSpecies.ElementAt(random.Next(NumOfSpecies/2, NumOfSpecies)).Genes;
                offspring1 = Breeding(mother, father, numofcities);
                offspring2 = Breeding(father, mother, numofcities);
                //PrintSpecies(mother, "Mother");
                //PrintSpecies(father, "Father");
                //PrintSpecies(offspring1, "Offspring1");
                //PrintSpecies(offspring2, "Offspring2");
                Person person1 = new Person(offspring1, 0);
                Person person2 = new Person(offspring2, 0);
                listOfOffspringSpecies.Add(person1);
                listOfOffspringSpecies.Add(person2);
            }
       

        }

        public int[] Breeding(int[] mother, int[] father, int numofcities)
        {
            int[] offspring = new int[numofcities - 1];
            for (int i = 0; i < 3; i++)
            {
                offspring[i] = mother[i];
            }

            for (int i = 3; i < numofcities; i++)
            {
                foreach (var gene in father)
                {
                    if (!offspring.Contains(gene))
                    {
                        offspring[i] = gene;
                    }
                }
            }

            return offspring;
        }

        public void Mutation(int numofcities, List<Person> listOfOffspringSpecies, List<Person> listOfOffspringSpeciesMutated)
        {
            int[] arr;
            PrintGenesOfSpecies(listOfOffspringSpecies, "ListOfOffspringSpecies");

            foreach (var offspring in listOfOffspringSpecies)
            {

                int a = random.Next(0, numofcities - 1);
                //Console.WriteLine("a = " + a);
                int b = random.Next(a + 1, numofcities - 1);
                //Console.WriteLine("b = " + b);
                arr = new int[b - a];
                Array.Copy(offspring.Genes, a, arr, 0, arr.Length);
                //PrintSpecies(offspring, "Offspring");
                //PrintSpecies(arr, "Array");

                arr = arr.Reverse().ToArray();

                //PrintSpecies(arr, "ArrayReversed");

                Array.Copy(arr, 0, offspring.Genes, a, arr.Length);

                //PrintSpecies(offspring, "OffspringMutated");

                    listOfOffspringSpeciesMutated.Add(offspring);              
              
            }
            PrintGenesOfSpecies(listOfOffspringSpeciesMutated, "ListOfOffspringSpeciesMutated");

        }


        static bool Contains(int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value) return true;
            }
            return false;
        }

        public void PrintGenesOfSpecies(List <Person> list, string name)
        {
            Console.WriteLine(name);
            foreach (var species in list)
            {
                foreach (var city in species.Genes)
                {
                    Console.Write(city + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("======================================");
        }

        public void PrintGenesOfPerson(Person person, string name)
        {
            Console.WriteLine(name);
            foreach (var city in person.Genes)
            {
                Console.Write(city + " ");
            }
            Console.WriteLine("\n======================================");
        }

        public List<Person> GetListOfParentalSpecies(List<Person> listOfParentalSpecies)
        {
            return listOfParentalSpecies;
        }

        public List<Person> GetListOfOffspringSpeciesMutated(List<Person> listOfOffspringSpeciesMutated)
        {
            return listOfOffspringSpeciesMutated;
        }




    }
}
