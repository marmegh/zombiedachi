using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace dojodachi
{
    public class Zombie
    {
        static Random rand = new Random();
        int fullness;
        int happiness;
        int energy;
        int meals;

        public Zombie()
        {
            this.fullness = 20;
            this.happiness = 20;
            this.energy = 50;
            this.meals = 3;
        }
        public void feed()
        {
            if(this.meals >= 1)
            {
                this.meals -= 1;
                int brain = rand.Next(0,5);
                if (brain < 4)
                {
                    this.fullness += rand.Next(5,11);
                }
            }
        }
        public void play()
        {
            this.energy -= 5;
            int fun = rand.Next(0,5);
            if (fun < 4)
            {
                this.happiness += rand.Next(5,11);
            }
        }
        public void sleep()
        {
            this.energy += 15;
            this.happiness -=5;
            this.fullness -=5;
        }
        public void work()
        {
            this.energy -= 5;
            this.meals += rand.Next(1,4);
        }
        public int getFullness()
        {
            return this.fullness;
        }
        public int getHappiness()
        {
            return this.happiness;
        }
        public int mealCount()
        {
            return this.meals;
        }
        public int getEnergy()
        {
            return this.energy;
        }
    }
}