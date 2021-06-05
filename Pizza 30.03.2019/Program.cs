using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_30._03._2019
{
    enum Ingridients
    {
        Salami,
        Ham,
        Tomatoes,
        Parmesan,
        Fat,
        Garlic
    }
    class Ingredient
    {
        public Ingridients ingridient;
        private double weight;
        protected double price;
        public double Price
        {
            get { return price; }
            set
            {
                if (value > 0)
                {
                    price = value;
                }
                else throw new InvalidPrice();
            }
        }
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

        public Ingredient(Ingridients ingridient, double weight, double price)
        {
            this.ingridient = ingridient;
            this.Weight = weight;
            this.Price = price;
        }
        public override string ToString()
        {
            return ingridient + ": weight " + weight + "g.,price " + Price + "grn.";
        }
    }

    public class InvalidIngredientException : Exception
    {
        public InvalidIngredientException() { }
        public override string Message
        {
            get { return "Incorrect ingridient"; }
        }
    }
    public class InvalidPrice : Exception
    {
        public InvalidPrice() { }
        public override string Message
        {
            get { return "Incorrect price value"; }
        }
    }

    public class InvalidWeight : Exception
    {
        public InvalidWeight() { }
        public override string Message
        {
            get { return "Incorrect weight value"; }
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

        private double size;
        private List<Ingredient> ingredients;
        private TypeOfBorder border;
        public TypeOfBorder Border { get { return border; } set { border = value; } }
        public double Size { get { return size; } set { size = value; } }
        public List<Ingredient> Ingridients { get { return ingredients; } set { ingredients = value; } }
        public double Price
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
            ingredients = new List<Ingredient>();
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
            bool no = true;
            for (int i = 0; i < ingredients.Count; i++)
            {
                if (ingredients[i].ingridient == ing)
                {
                    ingredients.RemoveAt(i);
                    no = false;
                }
            }
            if (no)
                throw new InvalidIngredientException();

        }
        public override string ToString()
        {
            string[] bortik = { "usual", "meat", "cheese" };
            string text = "Pizza contains\n";
            for (int i = 0; i < ingredients.Count; i++)
            {
                text += ingredients[i].ToString() + "\n";
            }
            text += "size " + size + " sm., type of border " + bortik[(int)Border];
            return text;
        }
        public static Pizza operator +(Pizza pizza, Ingredient ingridient)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            for (int i = 0; i < pizza.ingredients.Count; i++)
                ingredients.Add(pizza.ingredients[i]);
            Pizza p = new Pizza(ingredients, pizza.size, pizza.Border);
            p.AddIngredient(ingridient);
            return p;

        }
        public static Pizza operator -(Pizza pizza, Ingridients ing)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            for (int i = 0; i < pizza.ingredients.Count; i++)
                ingredients.Add(pizza.ingredients[i]);
            Pizza p = new Pizza(ingredients, pizza.size, pizza.Border);
            p.RemoveIngredient(ing);
            return p;

        }
    }
    public class Program
    {
        public static void Main(string[] arg)
        {
            Random r = new Random();
            try
            {

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

                a = a + new Ingredient((Ingridients)2, 10, 20);
                Console.WriteLine("\nwith added component");
                Console.WriteLine(a);
                Console.WriteLine("\nanother pizza");
                Pizza b = new Pizza(ingredients, 24, Pizza.TypeOfBorder.Cheese);
                Console.WriteLine(b);
                Console.WriteLine("\n------------------------------");
                Console.WriteLine("Which ingridient should be added:0-5 ");
                int name = int.Parse(Console.ReadLine());
                b += new Ingredient((Ingridients)name, 100, 200);
                // b.AddIngredient(new Ingredient((Ingridients)name, 100, 200));
                Console.WriteLine(b);
                Console.WriteLine("\n------------------------------");

                Console.WriteLine("Which ingridient should be removed: 0-5");
                name = int.Parse(Console.ReadLine());
                b -= (Ingridients)name;
                Console.WriteLine(b);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

    }

}
