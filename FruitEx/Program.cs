using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitEx
{
    public enum Color
    {
        Red,Green,Yellow
    }
    public class Fruit
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }
        public double Price { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Fruit> fruits = new List<Fruit>
            {
                new Fruit{Id="f1", Name="Apple", Color=Color.Red, Price=23.0,},
                new Fruit{Id="f2", Name="Banana", Color=Color.Yellow, Price=10.0,},
                new Fruit{Id="f3", Name="Pineapple", Color=Color.Yellow, Price=55.0,},
                new Fruit{Id="f4", Name="Cherry", Color=Color.Red, Price=40.0,},
                new Fruit{Id="f5", Name="Watermelon", Color=Color.Green, Price=28.0,},
                new Fruit{Id="f6", Name="Strawberry", Color=Color.Red, Price=33.0,}
            };

            //1.fruits in Descending order.
            var orderedDescendingFruitsLinq = (from fruit in fruits
                                               orderby fruit.Name descending
                                               select fruit).ToList();
            DisplayFruits(orderedDescendingFruitsLinq);
            var orderedDescendingFruitsLambda = fruits.OrderByDescending(fruit => fruit.Name).ToList();
            DisplayFruits(orderedDescendingFruitsLambda);

            //2.fruits in Ascending order.
            var orderedAscendingFruitsLinq = (from fruit in fruits
                                              orderby fruit.Name ascending
                                              select fruit).ToList();

            var orderedAscendingFruitsLambda = fruits.OrderBy(fruit => fruit.Name).ToList();
            DisplayFruits(orderedAscendingFruitsLambda);

            //3.Get Red and Green fruits.
            var colorRedandGreenLinq = (from fruit in fruits
                                        where fruit.Color == Color.Red || fruit.Color == Color.Green
                                        select fruit).ToList();

            DisplayFruits(colorRedandGreenLinq.ToList());

            //4.cheapest fruit.
            var cheapBudget = 20;
            var cheapFruitLinq = from fruit in fruits
                                 where fruit.Price <= cheapBudget
                                 select fruit;
            DisplayFruits(cheapFruitLinq.ToList());

            //5.most expensive fruit.
            var ExpensiveBudget = 50;
            var ExpensiveFruitLinq = from fruit in fruits
                                     where fruit.Price >= ExpensiveBudget
                                     select fruit;
            DisplayFruits(ExpensiveFruitLinq.ToList());

            //6.fruits by budget of 40 Rs.
            var budget = 40;
            var budgetFruitLinq = from fruit in fruits
                                  where fruit.Price <= budget
                                  select fruit;
            DisplayFruits(budgetFruitLinq.ToList());

            //7.count of Red fruits.
            var colorRedLinq = (from fruit in fruits
                                where fruit.Color == Color.Red
                                select fruit).Count();
            Console.WriteLine("Red Color Fruits : " + colorRedLinq);
            Console.ReadKey();

            //8.Group fruits with colors.
            var groupColorFruitLinq = from fruit in fruits
                                      group fruit by fruit.Color into fruitGroup
                                      select fruitGroup;

            var groupColorFruitsLambda = fruits.GroupBy(fruit => fruit.Color);
            foreach (var fruitGroup in groupColorFruitLinq)
            {
                Console.WriteLine(fruitGroup.Key);
                foreach (var fruit in fruitGroup)
                {
                    Console.WriteLine("    " + fruit.Name);
                }

            }
            Console.ReadKey();

            DisplayFruits(fruits);
        }
        static void DisplayFruits(List<Fruit> fruits)
        {

            foreach (var fruit in fruits)
            {
                Console.WriteLine(fruit.Name);
            }
            Console.ReadKey();
        }
    }
}
