using System;
using System.ComponentModel.DataAnnotations;

namespace dojodachi.Models
{
    public class Dachi
    {
        public int Fullness {get;set;}
        public int Happiness {get;set;}
        public int Meal {get;set;}
        public int Energy {get;set;}
    
        Random rand = new Random();
        public Dachi()
        {
            Fullness = 20;
            Happiness = 20;
            Meal = 3;
            Energy = 50;
        }

        public string Feed()
        {
            if(this.Meal > 0)
            {
                this.Meal -= 1;

                int chance = rand.Next(1,5);
                if(chance == 1)
                {
                    return "Your dojodachi did not like its food! :(";
                }
                
                this.Fullness += rand.Next(5, 11);

                return "You fed your dojodachi, it's happy!";
            }
            else
            {
                string message = "You don't have enough meals";
                return message;
            }
        }

        public string Play()
        {
            this.Energy -= 5;

            int chance = rand.Next(1,5);
            if(chance == 1)
            {
                return "Your dojodachi did not that! :(";
            }

            this.Happiness += rand.Next(5,11);

            return "You played with your dojodachi, it's happy!";
        }

        public string Work()
        {
            this.Energy -= 5;
            this.Meal += rand.Next(1,4); 
            return "You worked and got more meals";
        }

        public string Sleep()
        {
            this.Energy += 15;
            this.Fullness -= 5;
            this.Happiness -= 5;
            return "Sleeping.";
        }

        // public string WinCheck()
        // {
        //     if(this.Fullness >= 100 && this.Happiness >= 100)
        //     {
        //         return "Winner!";
        //     } 
        //     else 
        //     {

        //     } 
        // }

    }

    
}