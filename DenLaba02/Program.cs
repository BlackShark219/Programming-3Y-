using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum Ingridients
    {
        Салями = 0,
        Шинка,
        Помідори,
        Пармезан,
        Сало,
        Часник
    }
    class Ingredient
    {
        public Ingridients ingridient;
        private double weight;
        private double price;
        public Ingredient(Ingridients ingridient, double weight, double price)
        {

            if ((int)ingridient < 0 || (int)ingridient > 5)
                throw new InvalidIngredientException();
            this.ingridient = ingridient;
            this.weight = weight;
            this.price = price;
        }
        public override string ToString()
        {
            return ingridient + ": вага " + weight + "гр., вартiсть " + price + "грн.";
        }
        public double Price() { return price; }
    }

    class InvalidIngredientException : Exception
    {
        public InvalidIngredientException() { }
        public override string Message
        {
            get { return "Неправильний інгредієнт"; }
        }
    }

    class Pizza
    {
        List<Ingredient> ingredients = new List<Ingredient>();
        double size;
        public TypeOfBorder Border = TypeOfBorder.Usual;
        public enum TypeOfBorder
        {
            Usual = 0,
            Meat,
            Cheese
        }
        public double Price
        {
            get
            {
                double sum = 0;
                for (int i = 0; i < ingredients.Count; i++)
                { sum += ingredients[i].Price(); }
                return sum;
            }
        }
        public Pizza(List<Ingredient> ingredients, double size, TypeOfBorder Border)
        {
            this.ingredients = ingredients;
            this.size = size;

            if ((int)Border >= 0 && (int)Border < 3)
                this.Border = Border;
            else
            {
                this.Border = 0;
            }
        }
        public Pizza()
        {
            size = 12;
            Border = TypeOfBorder.Usual;
        }
        public void AddIngredient(Ingredient ing)
        {
            ingredients.Add(ing);
        }

        public bool RemoveIngredient(Ingridients ing)
        {
            for (int i = 0; i < ingredients.Count; i++)
            {
                if (ingredients[i].ingridient == ing)
                {
                    ingredients.RemoveAt(i);
                    return true;
                }

            }
            return false;
        }

        public override string ToString()
        {
            string[] bortik = { "звичайний", "м’ясний", "сирний" };
            string text = "У складi пицци є \n";
            for (int i = 0; i < ingredients.Count; i++)
            {
                text += ingredients[i].ToString();
            }
            text += "розмiр " + size + " см., тип бортика " + bortik[(int)Border];
            return text;
        }
        public static Pizza operator +(Pizza pizza, Ingredient ingridient) // добавляет к обьекту классу пицца обьект класса ингридиент ( если проще добавляет ингридиент в пиццу )
        {
            pizza.AddIngredient(ingridient);
            return new Pizza();
        }
        public static Pizza operator -(Pizza pizza, Ingredient ingridient) // если отправлять обьектом класса ингридиент ( удаляет ингридиент с пиццы )
        {
            pizza.RemoveIngredient(ingridient.ingridient);
            return new Pizza();
        }
        public static Pizza operator -(Pizza pizza, Ingridients ingridient) // если отправлять через енам ( тоже удаляет ингридиент с пиццы )
        {
            pizza.RemoveIngredient(ingridient);
            return new Pizza();
        }
    }
    class Program
    {

        static void Main(string[] arg)
        {
            Random r = new Random();
            Ingridients[] TypeOf = { Ingridients.Салями, Ingridients.Шинка, Ingridients.Часник, Ingridients.Сало, Ingridients.Помідори, Ingridients.Пармезан };
           // Pizza a = new Pizza(); // 
           // Console.WriteLine(a);
            List<Ingredient> ingredients = new List<Ingredient>();
            for (int i = 0; i < 6; i++)
            {
                Ingredient ing = new Ingredient(TypeOf[i], r.Next(10, 50), r.Next(5, 100));
                ingredients.Add(ing);
            }

            Pizza b = new Pizza(ingredients, 24,Pizza.TypeOfBorder.Cheese);
            //b.Print();
            //Console.WriteLine("\n------------------------------");
            //Console.WriteLine("Який iнгредiєнт додати: ");
           // string name; // = Console.ReadLine();и
            //b.AddIngredient(name, r.Next(50, 100), r.Next(1, 100));
            Console.WriteLine(b);
            Console.WriteLine("\n------------------------------");

            //Console.WriteLine("Який iнгредiєнт усунути: ");
            //name = Console.ReadLine();
            // Ingredient sal = new Ingredient("сало", 35, 90);
            //b.AddIngredient(sal);
            // b.Print();
            //Console.WriteLine("\n------------------------------");
            //Console.WriteLine($"Цiна {b.Price()}$");
            b.RemoveIngredient(Ingridients.Пармезан);
            Console.WriteLine(b);
            Console.WriteLine(b.Price);

            Console.ReadKey();
        }

    }
}
