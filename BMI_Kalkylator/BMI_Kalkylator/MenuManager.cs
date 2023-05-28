using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMI_Kalkylator
{
    class MenuManager
    {
        readonly private int breakLineLenght = 40;

        ///////////Public methoder //////

        public MenuManager()
        {
            breakLineLenght = 40;
        }
        public void StartMenu() //Visa texter som starta texter
        {
            BreakLine();
            StartMenuText();
        }
        public void StartCreatPersonText() //Dra en linje och visa Create person metoden
        {
            BreakLine();
            CreatPersonText();
        }
        public void QuitProgram()// Visa några texter (metoder ) och slutat programmet
        {
            BreaKLine('_', breakLineLenght);
            QuitProgramText();
            BreakLine();
        }
        public void CleanScreenPublic()
        {
            CleanScreen();
        }
     
        public string BmiGeneralInfoPublic()// Kalla och visa info om BMI jämför
        {
            string bmiInfoPub = BmiGeneralInfo();
            return bmiInfoPub;
        }
        public string BMITextPublic(float bmi)
        {
            return BMIText(bmi);
        }
        public string EstimateBmiMenuPublic(int BmiMenuNumber)//visa texten om  BMI värde att Jämfor det över hälsa
        {
            return EstimateBmiMenu(BmiMenuNumber);
        }



        ///////////Private methoder //////

        private string BMIText(float bmi)//Visa Bmi
        {
            return "-----------\nDin BMI är: " + bmi;
        }
        private void StartMenuText()//Första Menyn
        {
            Console.ForegroundColor = ConsoleColor.Yellow;//Byta färg
            Console.WriteLine("Välkommen till BMI-kalkylatorn");
            Console.ResetColor();
            BreaKLine('_', breakLineLenght);
            Console.WriteLine("Gör ett av följande val");
            Console.WriteLine("1:Beräkna BMI för en person");
            Console.WriteLine("2:Avsluta peogram");
            Console.ForegroundColor = ConsoleColor.Green;//Byta färg
            Console.WriteLine("\nVal: ");
            Console.ResetColor();

        }
        private void CreatPersonText()//visa texter att räkna BMI av personen
        {
            Console.ForegroundColor = ConsoleColor.Yellow;//Byta färg
            Console.WriteLine("Välkommen här kan du föra in data om en person.");
            Console.ResetColor();
            Console.WriteLine("Skriv ett värde i taget och tryck enter.");
            BreaKLine('_', breakLineLenght);
            Console.ForegroundColor = ConsoleColor.Red;//Byta färg
            Console.WriteLine("\nMata in data: \n");
            Console.ResetColor();
            Console.WriteLine("-Namn\t-Ålder\t-Längd i meter\t-Vikt i kg.");

        }
        private void QuitProgramText()//Slutat programet 
        {
            Console.WriteLine("* Good Bye, and hope to see you soon  *");
            Console.ForegroundColor = ConsoleColor.Red;//Byta färg
            Console.WriteLine("Programmet kommaer att avslutas. Tryck Enter!");
            Console.ResetColor();
        }
        private void BreakLine()//Göra en linje med stycken 
        {
            BreaKLine('*', breakLineLenght);
        }
        private void BreaKLine(char breakLineType, int lineLenght)//Göra en linje med stycken 
        {
            string breakLine = new string(breakLineType, lineLenght);
            Console.WriteLine(breakLine);
        }


        private string BmiGeneralInfo()//Info om BMI jämför
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nBMI< 18.5");
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            Console.Write("         = Uunderweight range.(Underviktsområde)\n");

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.Write("18.5 < BMI < 24.9 ");
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("= Healthy Weight range.( Hälsosam viktintervall.)\n");
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.Write("25.0 < BMI < 29.9 ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("= Overweight range.(Överviktsintervall.)\n");

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.Write("BMI => 30.0 ");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("      = Obese range!(inom fetma!)\n");


            Console.ResetColor();

            return "----[The refrence: WWW.cdc.gov]----\n";
        }

        private string EstimateBmiMenu(int BmiMenuNumber)//Att Jämfor BMI värde över hälsa
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            string estimateText = "";
            switch (BmiMenuNumber)
            {
                case 1:
                    estimateText = ("\nYour BMI shows : You are in: Uunderweight range.(Ditt BMI visar: Du befinner dig i: Underviktsområde.)");
                    break;
                case 2:
                    estimateText = ("\nYour BMI shows : You are in: Healthy Weight range.(Ditt BMI visar: Du befinner dig i: Hälsosam viktintervall.");
                    break;
                case 3:
                    estimateText = ("\nYour BMI shows you are in: Overweight range.(Ditt BMI visar att du är i: Överviktsintervall.)");
                    break;
                case 4:
                    estimateText = ("\nYour BMI shows you are in Obese range!(Ditt BMI visar att du är inom fetma!)");
                    break;

            }
            return estimateText;

        }
        private void CleanScreen()
        {
            Console.Clear();
        }

    }
}


