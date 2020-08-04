using System;
using System.Collections.Generic;

namespace HungryNinja
{

    public class Food
    {
        public string Name;
        public int Calories;
        public bool IsSpicy;
        public bool IsSweet;
        public Food(string name, int calories, bool spicy, bool sweet)
        {
            Name = name;
            Calories = calories;
            IsSpicy = spicy;
            IsSweet = sweet;
        }
    }
    public class Buffet
    {
        public List<Food> Menu;
        public Buffet()
        {
            Menu = new List<Food>()
            {
                new Food("Orange Chicken", 600, false, true),
                new Food("Paella", 550, false, false),
                new Food("Enchilada", 800, true, false),
                new Food("Hamburger", 800, false, false),
                new Food("Pad Thai", 600, true, false),
                new Food("Salad", 350, false, false),
                new Food("Chocolate Cake", 500, false, true)
            };
        }
        public Food Serve()
        {
            Random rnd = new Random();
            return Menu[rnd.Next(0, this.Menu.Count)];
        }
    }
    public class Ninja
    {
        private int calorieIntake;
        public List<Food> FoodHistory;
        public Ninja()
        {
            calorieIntake = 0;
            FoodHistory = new List<Food>();
        }
        public bool IsFull
        {
            get
            {
                if (calorieIntake > 1200) { return true; }
                else { return false; }
            }
        }
        public void Eat(Food meal)
        {
            if (!this.IsFull)
            {
                this.calorieIntake += meal.Calories;
                this.FoodHistory.Add(meal);
                string Spicy = "is spicy";
                string Sweet = "is sweet!";
                if (!meal.IsSpicy) { Spicy = "is not spicy"; };
                if (!meal.IsSweet) { Sweet = "is not sweet!"; };
                System.Console.WriteLine($"Ninja ate {meal.Name} which {Spicy} and {Sweet}");
                System.Console.WriteLine($"Ninja has consumed {this.calorieIntake} calories today.");
            }
            else
            {
                System.Console.WriteLine("Warning. This ninja is full and might explode if he/she eats more");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Buffet DojoCafe = new Buffet();
            Ninja joe = new Ninja();
            while (!joe.IsFull)
            {
                joe.Eat(DojoCafe.Serve());
            }
        }
    }

}
