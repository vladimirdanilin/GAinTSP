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
            for (int i = 0; i < NumOfSpecies/2; i++)
            { //Для каждой "матери" из первой половины начальной популяции рандомным образом подбирается "отец" из второй половины.
                mother = listOfParentalSpecies.ElementAt(i).Genes;
                father = listOfParentalSpecies.ElementAt(random.Next(NumOfSpecies/2, NumOfSpecies)).Genes;
                offspring1 = Breeding(mother, father, numofcities);
                offspring2 = Breeding(father, mother, numofcities);

                Person person1 = new Person(offspring1, 0);
                Person person2 = new Person(offspring2, 0);
                listOfOffspringSpecies.Add(person1);
                listOfOffspringSpecies.Add(person2);
            }
            return listOfOffspringSpecies;



        }

        public int[] Breeding(int[] mother, int[] father, int numofcities)
        {
            int r = random.Next(0,numofcities);
            int[] offspring = new int[numofcities - 1];
            for (int i = 0; i < r; i++)
            {
                offspring[i] = mother[i];
            }

            for (int i = r; i < numofcities; i++)
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

        public List<Person> Mutation(int numofcities, List<Person> listOfOffspringSpecies, List<Person> listOfOffspringSpeciesMutated)
        {
            int[] arr;

            foreach (var offspring in listOfOffspringSpecies)
            {

                int a = random.Next(0, numofcities - 1);
                int b = random.Next(a + 1, numofcities - 1);
                arr = new int[b - a];
                Array.Copy(offspring.Genes, a, arr, 0, arr.Length);

                arr = arr.Reverse().ToArray();


                Array.Copy(arr, 0, offspring.Genes, a, arr.Length);


                listOfOffspringSpeciesMutated.Add(offspring);              
              
            }
            return listOfOffspringSpeciesMutated;
        }

    }
}
