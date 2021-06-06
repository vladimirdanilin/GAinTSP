using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAinTSP
{
    public class Person
    {
        public int[] Genes { get; set; }
        public double Fitness { get; set; }

        public Person(int[] genes, double fitness)
        {
            Genes = genes;
            Fitness = fitness;
        }
    }
}
