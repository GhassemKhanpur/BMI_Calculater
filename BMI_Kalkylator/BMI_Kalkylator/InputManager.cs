using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace BMI_Kalkylator
{
    class InputManager
    {


        ///////////Public methoder //////


        //få en string från användaren och sortera för att vilka typer måste skicka (meny nummer,namn eller ålder)
        public string UserInputString()
        {
            return Console.ReadLine();//NotEmptyInput metoden: att konterella input är inte tömma

        }
        public string UserInputNamePublic()//Fråga att få namn från användaren
        {
            return UserInputName();

        }
        public float UserInputHeightPublic()
        {
            return UserInputFloat(100.00E-2f, 300.00E-2f, "height");
        }

        public float UserInputWeightPublic()
        {
            return UserInputFloat(100.00E-2f, 50000.00E-2f, "weight");
        }
        public int UserInputNumber(int min, int max, string inputType)//Leda programmet till rät rut att få ett nummer
        {
            int number = 0;
            bool validNumber = false;
            while (validNumber == false)
            {
                Int32.TryParse(UserInputString(), out number);

                switch (number <= max && number >= min)
                {
                    case true://informera till användaren angvas rätt nummer 
                        switch (inputType)
                        {
                            case "menu"://valde nummer 1 att starta BMI räkna på menynnåva (om menu (inte age)
                                UseInputMenuMessage(number);

                                break;


                            case "age"://valde nummer 1 att starta BMI räkna på menynnåva (om age (inte menu )
                                RightInputAgetMessage(number);

                                break;
                        }
                        validNumber = true;
                        break;

                    case false://informera till användaren angvas inte rätt nummer 
                        InvalidInputMenuMessage(inputType, min, max);

                        break;
                }
            }
            return number;
        }


        ///////////Private methoder //////


        //informera till användaren angvas inte rätt nummer
        private void InvalidInputMenuMessage(string inputType, int min, int max)
        {
            switch (inputType)
            {
                case "menu":
                    InvalidInputMenuMessage(min, max);
                    break;


                case "age":
                    InvalidInputAgeMessage(min, max);
                    break;
            }

        }
        private void UseInputMenuMessage(int number)
        {
            switch (number)
            {
                case 1:
                    RightInputMenuMessageOne(number);//användaren angvas nummer 1 till starta BMI rökna

                    break;

                case 2:
                    RightInputMenuMessageTwo(number);//användaren angvas nummer 2 till avslutat programmet
                    break;
            }
        }
        private string UserInputName()// att konrollera allt input från användaren är inte tömma
        {
            string userInput = "";
            bool inputLoop = false;
            while (inputLoop == false)
            {
                userInput = Console.ReadLine();
                switch (IsNotEmpty(userInput) && IsString(userInput))//IsStrig=(true)  (!IsStrig=false)
                {
                    case true://input är inte tömma

                        RightInputNameMessage(userInput);

                        inputLoop = true;

                        break;

                    case false://user input är tömma så informa till användaren och börja loopen igen

                        InvalidInputNameMessage();
                        break;
                }
            }
            return userInput;
        }
        private float UserInputFloat(float min, float max, string floatType)//Fråga användaren att få högt och vikt
        {
            float floatInput = 0f;
            bool validLoop = false;

            while (validLoop != true)
            {
                string floatInstring = Console.ReadLine();
                switch (IsNotEmpty(floatInstring) && !IsString(floatInstring))
                {
                    case true:

                        floatInput = ConvertInputToFloat(floatInstring);
                        validLoop = IsBetweenMinAndMax(min, max, floatInput, floatType, validLoop);

                        break;


                    case false:

                        InvalidInputHeightAndWeightMessage(min, max);
                        break;
                }
            }
            return floatInput;
        }

        private bool IsBetweenMinAndMax(float min, float max, float numberInput, string floatType, bool validLoopValue)
        {

            switch (numberInput >= min && numberInput <= max)//Att kontrolla min och max
            {
                case true:
                    switch (floatType)//sortera i type
                    {
                        case "height":

                            RightInputHeightMessage(numberInput);


                            break;

                        case "weight":
                            RightInputWeightMessage(numberInput);
                            break;
                    }
                    validLoopValue = true;
                    break;


                case false:

                    InvalidInputHeightAndWeightMessage(min, max);

                    break;


            }
            return validLoopValue;
        }


        //////////////////////Rätt inmatningsmeddelanden////////////
        private void RightInputMenuMessageOne(int valuePassed)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("OK! Du valde " + valuePassed + ". Let's start to count your BMI.(Låt oss börja räkna ditt BMI.)");
        }
        private void RightInputMenuMessageTwo(int valuePassed)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("OK! Du valde " + valuePassed + ". ");
        }
        private void RightInputNameMessage(string valuePassed)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Name: " + valuePassed + "! Now enter your age.(Ange nu din ålder):");
        }
        private void RightInputAgetMessage(int valuePassed)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("OK! Your age is " + valuePassed + ". Now enter your height in meter like 1.80 meter.");
        }
        private void RightInputHeightMessage(float valuePassed)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Ok! Your height is " + valuePassed + ". Now enter your weight in kg like 70.400 kg.");
        }
        private void RightInputWeightMessage(float valuePassed)
        {
            //Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(valuePassed + "kg.\nInformation inputing Complated.");
            Thread.Sleep(1000);//en pause
            Console.ResetColor();
            BreakPauseLine();
            Thread.Sleep(1000);//en pause

        }

        //////////////////////Ogiltiga inmatningsmeddelanden////////////
        private void InvalidInputMenuMessage(int min, int max)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Please try again! Enter a number between " + min + " and " + max + " .");
        }
        private void InvalidInputNameMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Empty value or not a valid input!, Please write your name :");
        }
        private void InvalidInputAgeMessage(int min, int max)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Please try again.Use a number between " + min + " and " + max + " .");
        }
        private void InvalidInputHeightAndWeightMessage(float min, float max)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Please try againg! Use a number between " + min + " and " + max + " .");
        }

        private float ConvertInputToFloat(string floatInput)//Den Metoden att konvertera string till float
        {
            float floatTemp = float.Parse(floatInput, CultureInfo.InvariantCulture.NumberFormat);

            return floatTemp;
        }
        private bool IsString(object inputedValue)//Att konterall input är float(inte alfabetisk string)
        {
            bool onlyAlphas = Convert.ToString(inputedValue).All(c => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'));

            return onlyAlphas;

        }
        private bool IsNotEmpty(object inputPut)
        {
            bool IsEmptyOrNot = false;
            switch ((!string.IsNullOrEmpty(Convert.ToString(inputPut)) || !string.IsNullOrWhiteSpace(Convert.ToString(inputPut))))
            {
                case true:
                    IsEmptyOrNot = true;
                    break;


                case false:
                    IsEmptyOrNot = false;
                    break;
            }

            return IsEmptyOrNot;
        }
        private void BreakPauseLine()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < 6; i++)
            {
                Console.Write("___________");
                Thread.Sleep(100);//en pause
            }

        }

    }
}
