using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Ingredient
    {
        private string[] ingredients = { "салями", "шинка", "помiдори", "пармезан", "сало", "часник"};
        public string TypeOf { get; set; }  // властивість тип
        public double Weight { get; set; }  // властивість вага гр
        public double Price { get; set; }  // властивість цена за 100 гр
        public Ingredient(string TypeOf, double Weight, double Price)
        {
            bool valid = false;
            foreach (string s in ingredients)
            {
                if (TypeOf == s)
                {
                    this.TypeOf = TypeOf;
                    valid = true;
                }
            }
            if (!valid) throw new IvalidIngredientException();
            
            this.Weight = Weight;
            this.Price = Price;
        }
    }

    class IvalidIngredientException : Exception
    {
        public IvalidIngredientException() { }
        public override string Message
        {
            get { return "Неправильний інгредієнт"; }
        }
    }

    class Pizza
    {
        List<Ingredient> ingredients;  // ссылка  на список ингредиентов
        double size; // розмір см.
        int TypeOfBorder; // 0 - Usual , 1 - Meat, 2 - Cheese


        // відкриті члени
        public void Print()  // метод
        {
            Console.Write(this.ToString());
        }
        public override string ToString()
        {
            string[] bortik = { "звичайний", "м’ясний", "сирний" };
            string text = "";
            if (ingredients != null)
            {
                text += "У складi пицци є\n";
                foreach (var x in ingredients)
                    text += x.TypeOf + ": вага " + x.Weight + "гр., вартiсть " + x.Price + "грн.\n";
            }
            else
                text += "Основа пицци не мiстить iнгредiєнтiв,\n";
            text += "розмiр " + size + " см., тип бортика " + bortik[TypeOfBorder];

            return text;
        }
        public Pizza(List<Ingredient> ingredients, double size, int TypeOfBorder)
        {
            this.ingredients = ingredients;
            this.size = size;
            if (TypeOfBorder >= 0 && TypeOfBorder < 3)
                this.TypeOfBorder = TypeOfBorder;
            else
            {
                this.TypeOfBorder = 0;
                Console.WriteLine("Тип бортика задано невiрно (0 - Usual , 1 - Meat, 2 - Cheese)");
            }
            Console.WriteLine($"Виконався конструктор з параметрами");
        }
        public Pizza() : this(null, 12, 0)
        {
            Console.WriteLine($"Виконався конструктор без параметрiв");
        }
        public void AddIngredient(Ingredient ing)
        {
            ingredients.Add(ing); // додаємо новий інгредієнт
        }
        public void RemoveIngredient(string Type)
        {

            if (ingredients != null && ingredients.Count > 0)
            {
                bool removed = false;
                foreach (var x in ingredients)
                {
                    if (x.TypeOf.ToLower() == Type.ToLower())
                    {
                        ingredients.Remove(x);
                        Console.WriteLine($"Iнгредiєнт {Type} вилучений");
                        removed = true;
                    }
                    if(!removed) Console.WriteLine($"Вказаний тип {Type} iнгредiєнта на знайдено");
                }
            }
            else
                Console.WriteLine($"Пицца не мiстить iнгредiєнтiв");
        }
        public double Price()
        {
            double c = 0;
            if (ingredients != null && ingredients.Count > 0)
            {
                foreach (var x in ingredients)
                    c += x.Price;
            }
            //c+= ціна бортика и основи
            return c;
        }

    }
    class Program
    {

        static void Main(string[] arg)
        {
            Random r = new Random();
            string[] TypeOf = { "салями", "шинка", "помiдори", "пармезан", "часник" };
            Pizza a = new Pizza(); // 
            a.Print();  // виклик методу 
            Console.WriteLine("\n------------------------------");
            List<Ingredient> ingredients = new List<Ingredient>();
            for (int i = 0; i < 5; i++)
            {
                Ingredient ing = new Ingredient(TypeOf[i], r.Next(10, 50), r.Next(5, 100));
                ingredients.Add(ing);
            }
            Pizza b = new Pizza(ingredients, 24, 4);
            //b.Print();
            //Console.WriteLine("\n------------------------------");
            //Console.WriteLine("Який iнгредiєнт додати: ");
            string name; // = Console.ReadLine();
            //b.AddIngredient(name, r.Next(50, 100), r.Next(1, 100));
            b.Print();
            Console.WriteLine("\n------------------------------");

            //Console.WriteLine("Який iнгредiєнт усунути: ");
            name = Console.ReadLine();
           // Ingredient sal = new Ingredient("сало", 35, 90);
            //b.AddIngredient(sal);
           // b.Print();
            //Console.WriteLine("\n------------------------------");
            //Console.WriteLine($"Цiна {b.Price()}$");
            b.RemoveIngredient(name);
            b.Print();
            Console.ReadKey();
        }

    }
}


