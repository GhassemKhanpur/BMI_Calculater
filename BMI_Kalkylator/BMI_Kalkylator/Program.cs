using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMI_Kalkylator
{
    class Program
    {
        static void Main()
        {
            ProgramManager program=new ProgramManager();//Kall på klassen att starta programmet
            program.Start();
        }
    }
}
