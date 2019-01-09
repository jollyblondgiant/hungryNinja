using System;
using System.Collections.Generic;

namespace Hungry {
    interface IConsumable {
        string Name { get; set; }
        int Calories { get; set; }
        bool IsSpicy { get; set; }
        bool IsSweet { get; set; }
        string GetInfo ();
    }
    class Program {
        static void Main (string[] args) {
            Random serve = new Random();
            Console.WriteLine ("Hello World!");
            SweetTooth tj = new SweetTooth();
            SpiceHound andy = new SpiceHound();
            Buffet allUCanEat = new Buffet();
            while(!andy.IsFull){
                andy.Consume(allUCanEat.Serve());
            }
            while(!tj.IsFull){
                tj.Consume(allUCanEat.Serve());
            }
            if(andy.ConsumptionHistory.Count>tj.ConsumptionHistory.Count){
                Console.WriteLine($"Andy consumed the most : {andy.ConsumptionHistory.Count} items!");
            }
            if(tj.ConsumptionHistory.Count > andy.ConsumptionHistory.Count){ 
                Console.WriteLine($"TJ is the winrar: {tj.ConsumptionHistory.Count} items!");
            }
        }
        
    }
    class Food : IConsumable {

        public string Name { get; set; }
        public int Calories { get; set; }
        public bool IsSpicy { get; set; }
        public bool IsSweet { get; set; }
        public string GetInfo () {
            return $"{Name} (Food). Calories: {Calories}. Spicy? {IsSpicy}, Sweet? {IsSweet}";
        }

        public Food (string name, int calories, bool isSpicy, bool isSweet) {
            Name = name;
            Calories = calories;
            IsSpicy = isSpicy;
            IsSweet = isSweet;
        }
    }
    class Drink : IConsumable {
        public string Name { get; set; }
        public int Calories { get; set; }
        public bool IsSpicy { get; set; }
        public bool IsSweet { get; set; }
        public string GetInfo () {
            return $"{Name} (Drink). Calories: {Calories}. Spicy? {IsSpicy}, Sweet? {IsSweet}";
        }
        public Drink (string name, int calories, bool isSpicy, bool isSweet) {
            Name = name;
            Calories = calories;
            IsSpicy = isSpicy;
            IsSweet = true;

        }
    }
    class Buffet {
        public List<IConsumable> Menu;
        public Buffet () {
            Menu = new List<IConsumable> () {
                new Food ("Salad", 300, false, false),
                new Food ("Peach", 50, false, true),
                new Food ("Pepper", 50, true, false),
                new Drink ("Milkshake", 75, true, true),
                new Drink ("Beer", 150, false, true),
                new Food ("Steak", 700, true, false),
                new Food ("Avocado", 60, false, false),
                new Drink ("Just Hot Sauce", 65, true, false),
                new Drink("Mango Nectar", 120, false, true)
            };
        }
        public IConsumable Serve () {
            Random rand = new Random ();
            var food = Menu[rand.Next (0, Menu.Count)];
            Console.WriteLine(food.GetInfo());
            return food;

        }

    }
    abstract class Ninja {
        protected int calorieIntake;
        public List<IConsumable> ConsumptionHistory;
        public Ninja () {
            calorieIntake = 0;
            ConsumptionHistory = new List<IConsumable> ();

        }
        
        public abstract bool IsFull {
            get;

        }
        public abstract void Consume (IConsumable item);
    }
    class SweetTooth : Ninja {
        public override bool IsFull {
            get {
                return calorieIntake >= 1500;
            }
        }
        public override void Consume (IConsumable item) {
            item.GetInfo();
            if (!IsFull) {
                ConsumptionHistory.Add(item);
                calorieIntake += item.Calories;
                if(item.IsSweet){calorieIntake+=10;}
                Console.WriteLine("EAT");
            } else {
                Console.WriteLine ("Too Full, no more eat!");

            }
        }
    }
    class SpiceHound : Ninja {
        public override bool IsFull {
            get {
                return calorieIntake >= 1200;
            }
        }

        public override void Consume (IConsumable item) {

            item.GetInfo ();
            if (!IsFull) {
                ConsumptionHistory.Add (item);

                calorieIntake += item.Calories;
                if (item.IsSpicy) {
                    calorieIntake -= 5;
                }
            } else {
                Console.WriteLine ("Too Full, eat no more!");
            }
        }
    }
}