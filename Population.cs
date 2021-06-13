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
        Random random = new Random(DateTime.Now.Millisecond);

        public Population(int numOfSpecies)
        {
            NumOfSpecies = numOfSpecies;
        }




        public List<Person> GenerateSpecies(int numofcities, List<Person> listOfParentalSpecies)
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
            return listOfParentalSpecies;
        }



        public List<Person> Crossover(int numofcities, List<Person> listOfParentalSpecies, List<Person> listOfOffspringSpecies)
        {
            int[] mother = new int[numofcities - 1];
            int[] father = new int[numofcities - 1];
            int[] offspring1 = new int[numofcities - 1];
            int[] offspring2 = new int[numofcities - 1];
            for (int i = 0; i < NumOfSpecies / 2; i++)
            { //Сначала ищется особь с индексом m, затем особь с индексом f, причем m!=f
                int m = random.Next(0, NumOfSpecies);
                int f = random.Next(0, NumOfSpecies);
                while (f == m)
                {
                    f = random.Next(0, NumOfSpecies);
                }
                mother = listOfParentalSpecies.ElementAt(m).Genes;
                father = listOfParentalSpecies.ElementAt(f).Genes;
                offspring1 = Breeding(mother, father, numofcities);
                offspring2 = Breeding(father, mother, numofcities);

                Person person1 = new Person(offspring1, 0);
                Person person2 = new Person(offspring2, 0);
                listOfOffspringSpecies.Add(person1);
                listOfOffspringSpecies.Add(person2);
            }
            return listOfOffspringSpecies;



        }

        public int[] Breeding(int[] parent1, int[] parent2, int numofcities)
        {
            int r = random.Next(0, numofcities); //Граница генов.
            int[] offspring = new int[numofcities - 1];
            for (int i = 0; i < r; i++)
            {
                offspring[i] = parent1[i];
            }

            for (int i = r; i < numofcities; i++)
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

        public List<Person> Mutation(int numofcities, List<Person> listOfOffspringSpecies, List<Person> listOfOffspringSpeciesMutated, double percentOfMutation)
        {
            int[] arr;

            foreach (var offspring in listOfOffspringSpecies)
            {
                int a = random.Next(0, numofcities - 1);
                int b = random.Next(a + 1, numofcities - 1);
                int mut = Convert.ToInt32(Math.Round((b-a) * percentOfMutation / 100));
                arr = new int[mut];
                Array.Copy(offspring.Genes, a, arr, 0, arr.Length);

                arr = arr.Reverse().ToArray();


                Array.Copy(arr, 0, offspring.Genes, a, arr.Length);


                listOfOffspringSpeciesMutated.Add(offspring);              
              
            }
            return listOfOffspringSpeciesMutated;
        }

    }
}
