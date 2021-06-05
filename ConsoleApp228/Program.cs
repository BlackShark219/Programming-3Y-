using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    enum Ingridients
    {
        Салями,
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
        protected double price;
        public double Price { get { return price; } }
        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value > 0)
                {
                    weight = value;
                }
                else throw new InvalidWeight();
            }
        }
        public double Priceof
        {
            get
            {
                return price;
            }
            set
            {
                if (value > 0)
                {
                    price = value;
                }
                else throw new InvalidPrice();
            }
        }
        public Ingredient(Ingridients ingridient, double weight, double price)
        {
            this.ingridient = ingridient;
            this.weight = weight;
            this.price = price;
        }
        public override string ToString()
        {
            return ingridient + ": вага " + weight + "гр., вартiсть " + Price + "грн.";
        }
    }

    public class InvalidIngredientException : Exception
    {
        public InvalidIngredientException() { }
        public override string Message
        {
            get { return "Неправильний інгредієнт"; }
        }
    }
    public class InvalidPrice : Exception
    {
        public InvalidPrice() { }
        public override string Message
        {
            get { return "недопустиме значення ціни"; }
        }
    }

    public class InvalidWeight : Exception
    {
        public InvalidWeight() { }
        public override string Message
        {
            get { return "недопустиме значення ваги"; }
        }
    }

    class Pizza
    {
        public enum TypeOfBorder
        {
            Usual,
            Meat,
            Cheese
        }
        private List<Ingredient> ingredients = new List<Ingredient>();
        private double size;
        //public TypeOfBorder Border = TypeOfBorder.Usual;
        private TypeOfBorder border;
        public TypeOfBorder Border { get { return border; } set { border = value; } }
        public double Size { get { return size; } set { size = value; } }
        public List<Ingredient> Ingridients { get { return ingredients; } set { ingredients = value; } }
        public double Price   // property
        {
            get
            {
                double sum = 0;
                for (int i = 0; i < ingredients.Count; i++)
                { sum += ingredients[i].Price; }
                return sum;
            }
        }
        public Pizza()
        {
            size = 23;
            border = TypeOfBorder.Usual;
        }
        public Pizza(List<Ingredient> ingredients, double size, TypeOfBorder Border)
        {
            this.ingredients = ingredients;
            this.size = size;
            this.Border = Border;

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
    public class Program
    {
        public static void Main(string[] arg)
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

                Pizza a = new Pizza();
                Console.WriteLine(a);
                a.Border = Pizza.TypeOfBorder.Cheese;
                a.Size = 27;
                Console.WriteLine(a);
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

                Pizza c = b + new Ingredient((Ingridients)0, 100, 2000);
                Console.WriteLine(b);
                Console.WriteLine("\n------------------------------");
                Console.WriteLine(c);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

    }
}