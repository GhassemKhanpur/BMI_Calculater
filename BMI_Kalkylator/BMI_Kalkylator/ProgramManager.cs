using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace BMI_Kalkylator
{
    class ProgramManager
    {

        ///////////Public methoder //////

        public void Start()
        {
            MenuOptions();
        }

        ///////////Private methoder //////

        private void MenuOptions()
        {
            var menuManager = new MenuManager();
            var inputManager = new InputManager();

            bool programOn = true;
            int choice, minChoice, maxChoice;
            minChoice = 1;
            maxChoice = 2;
            while (programOn == true)//Kör loopen för att få rätt input från användaren med två alternativ
            {
                menuManager.StartMenu();

                choice = inputManager.UserInputNumber(minChoice, maxChoice, "menu");
                switch (choice)
                {
                    case 1:
                        //När användaren skrev nummer 1 dök det upp med mer skydd i private metoden
                        CounterBMI();

                        break;

                    case 2:
                        menuManager.QuitProgram();//slutat programmet
                        programOn = false;
                        Environment.Exit(0);
                        break;
                }
            }
        }
        private void CounterBMI()//att göra en ny person objekt och få allt info som sin namn, ålder, längd och vikt
        {
            //kalla allt klasser vi behöver 
            var menuManager = new MenuManager();
            var inputManager = new InputManager();
            var bmiCalculator = new BMICalculator();

            string name;
            int age;
            float lenght, weight;

            //kör programmet i ordning
            menuManager.StartCreatPersonText(); //att visa texten om skappa en persom objekt 

            name = inputManager.UserInputNamePublic();//få  namn från användaren
            age = inputManager.UserInputNumber(1, 140, "age");//få  ålder från användaren
            lenght = inputManager.UserInputHeightPublic();//få  längd från användaren
            weight = inputManager.UserInputWeightPublic();//få  vikt från användaren

            var person = new Person(name, age, lenght, weight);

            menuManager.CleanScreenPublic();



            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Namn: " + person.Name);
            Console.WriteLine("Ålder: " + person.Age);
            Console.WriteLine("Längd: " + person.Lenght);
            Console.WriteLine("Vikt: " + person.Weight);
            Console.ResetColor();

            float bmiAmount = bmiCalculator.BMIAmount(person.Lenght, person.Weight);

            EstimateBmiShow(bmiAmount);

        }
        private void EstimateBmiShow(float bmiAmount)
        {
            var menuManager = new MenuManager();
            var bmiCalculator = new BMICalculator();

            Console.WriteLine(menuManager.BMITextPublic(bmiAmount));

            Console.WriteLine(menuManager.EstimateBmiMenuPublic(bmiCalculator.EstimateBmiPublic(bmiAmount)));

            Console.WriteLine(menuManager.BmiGeneralInfoPublic());
        }
    }
}


