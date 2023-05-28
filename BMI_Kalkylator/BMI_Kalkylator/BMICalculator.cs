using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMI_Kalkylator
{
    class BMICalculator
    {

        ///////////Public methoder //////

        public string BMICalculatorStart(float lenght, float weight)//Vissa Bmi med  texten 
        {
            return BMICalculatorText(Calculation(lenght, weight));
        }
        public float BMIAmount(float lenghtCount, float weightCount)//visa BMI med baserat på två referenser 
        {
            float bmiValueePass = Calculation(lenghtCount, weightCount);
            return bmiValueePass;

        }
        public int EstimateBmiPublic(float printBmi)//leda uppskatade BMI att ledande till att visa rätt texter
        {
            return EstimateBmi(printBmi);
        }



        ///////////Private methoder //////

        private string BMICalculatorText(float bmi)//Vissa Bmi
        {
            string text = "-----------\n Din BMI är: " + bmi;
            return text;
        }
        private float Calculation(float lenght, float weight)//räkna BMI med två referenser 
        {
            float bmiValuePassed = (float)Math.Round(weight / (lenght * lenght), 3);
            return bmiValuePassed;
        }

        private int EstimateBmi(float bmiGot)//uppskata BMI att jämföra med standard hälsosiffror
        {
            int BmiMenuNumber = 0;

            if (bmiGot < 18.50f)
            {
                BmiMenuNumber = 1;
            }
            if (18.50 <= bmiGot && bmiGot <= 24.90)
            {
                BmiMenuNumber = 2;
            }
            if (25.00 <= bmiGot && bmiGot <= 29.9)
            {
                BmiMenuNumber = 3;
            }
            if (bmiGot >= 30.0)
            {
                BmiMenuNumber = 4;
            }

            return BmiMenuNumber;

        }
    }
}