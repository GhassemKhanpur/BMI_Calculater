using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMI_Kalkylator
{
    class Person
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public float Lenght { get; private set; }
        public float Weight { get; private set; }

        public Person(string pName, int pAge, float pLenght, float pWeight)
        {
            Name = pName;
            Age = pAge;
            Lenght = pLenght;
            Weight = pWeight;

        }
    }
}
