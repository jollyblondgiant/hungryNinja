using System;
using System.Collections.Generic;

namespace Hungry
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    class Food
    {
        public string Name;
        public int Calories;
        public bool IsSpicy;
        public bool IsSweet;

        public Food(string name, int calories, bool isSpicy, bool isSweet){
            Name = name;
            Calories = calories;
            IsSpicy = isSpicy;
            IsSweet = isSweet;
        }
    }
    class Buffet{
        public List<Food> Menu;
        public Buffet()
        {
            Menu = new List<Food>(){
                new Food("Salad", 10, false, false),
                new Food("Peach", 50, false, true),
                new Food("Pepper", 25, true, false),
                new Food("Whiskey", 75, true, true),
                new Food("Beer", 85, false, true),
                new Food("Steak", 100, true, false),
                new Food("Avocado", 60, false, false)
            };
        }
        public Food Serve(){
            Random rand = new Random();
            return Menu[rand.Next(0, Menu.Count)];
        }

    }
    class Ninja{
        private int calorieIntake;
        public List<Food> FoodHistory;
        public Ninja(){
            FoodHistory = new List<Food>();
            calorieIntake = 0;

        }
        public void Eat(Food item){
            if(!this.IsFull){
                this.calorieIntake += item.Calories;
                FoodHistory.Add(item);
                Console.WriteLine(item.Name);
                if(item.IsSpicy){
                    Console.WriteLine("Ohh! Spicy!");
                }
                if(item.IsSweet){
                    Console.WriteLine("Ooh! Sweet!");
                }
            }
            else{
                Console.WriteLine("Ninja too full! Eat no more!");
            } 
        }
        bool IsFull{
            get{
                if(this.calorieIntake > 1200){
                    return true;
                }
                else{return false;}
            }
            set{

            }
        }
    }
}
