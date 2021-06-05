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
        Помiдори,
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
        public enum TypeOfBorder
        {
            Usual = 0,
            Meat,
            Cheese
        }
        List<Ingredient> ingredients = new List<Ingredient>();
        double size;
        public TypeOfBorder Border = TypeOfBorder.Usual;

        public double Price   // property
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

        public void RemoveIngredient(Ingridients ing)
        {
            for (int i = 0; i < ingredients.Count; i++)
            {
                if (ingredients[i].ingridient == ing)
                {
                    ingredients.RemoveAt(i);
                    return;
                }

            }
            throw new InvalidIngredientException();
            //return false;
        }

        public override string ToString()
        {
            string[] bortik = { "звичайний", "м’ясний", "сирний" };
            string text = "У складi пицци є\n";
            for (int i = 0; i < ingredients.Count; i++)
            {
                text += ingredients[i].ToString() + "\n"; // перевизначений ToString()
            }
            text += "розмiр " + size + " см., тип бортика " + bortik[(int)Border];
            return text;
        }
        public static Pizza operator +(Pizza pizza, Ingredient ingridient) // добавляет к обьекту классу пицца обьект класса ингридиент ( если проще добавляет ингридиент в пиццу )
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            for (int i = 0; i < pizza.ingredients.Count; i++)
                ingredients.Add(pizza.ingredients[i]);
            Pizza p = new Pizza(ingredients, pizza.size, pizza.Border);
            p.AddIngredient(ingridient);
            return p;
        }
        public static Pizza operator -(Pizza pizza, Ingridients ing) // если отправлять обьектом класса ингридиент ( удаляет ингридиент с пиццы )
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            for (int i = 0; i < pizza.ingredients.Count; i++)
                ingredients.Add(pizza.ingredients[i]);
            Pizza p = new Pizza(ingredients, pizza.size, pizza.Border);
            p.RemoveIngredient(ing);
            return p;
        }
        //public static Pizza operator - (Pizza pizza, Ingridients ingridient) // если отправлять через енам ( тоже удаляет ингридиент с пиццы )
        //{
        //  return new Pizza(); //???
        //}
    }
    class Program
    {

        static void Main(string[] arg)
        {
            Random r = new Random();
            try
            {
                //Ingridients[] TypeOf = { (Ingridients)0, Ingridients.Шинка, Ingridients.Часник, Ingridients.Сало, Ingridients.Помiдори, Ingridients.Пармезан };
                //Pizza a = new Pizza(); // 
                //Console.WriteLine(a);
                List<Ingredient> ingredients = new List<Ingredient>();
                for (int i = 0; i < 5; i++)
                {
                    Ingredient ing = new Ingredient((Ingridients)i, r.Next(10, 50), r.Next(5, 100));
                    ingredients.Add(ing);
                }


                Pizza b = new Pizza(ingredients, 24, Pizza.TypeOfBorder.Cheese);
                Console.WriteLine(b);
                //Console.WriteLine("\n------------------------------");
                //Console.WriteLine("Який iнгредiєнт додати: ");
                //int name = int.Parse(Console.ReadLine());
                //b.AddIngredient(new Ingredient((Ingridients)name, 100, 200));
                //Console.WriteLine(b);
                Console.WriteLine("\n------------------------------");

                //Console.WriteLine("Який iнгредiєнт усунути: 0-5");
                //name = int.Parse(Console.ReadLine());

                //Console.WriteLine(b);

                Pizza c = b + new Ingredient((Ingridients)0, 1000, 2000);
                Console.WriteLine(b);
                Console.WriteLine("\n------------------------------");
                Console.WriteLine(c);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            Console.ReadKey();
        }

    }
}

