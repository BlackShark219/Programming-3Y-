using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    class Program
    {
        static void Main(string[] args)
        {
            Ingridient[] ingridients = new Ingridient[] {
                new Ingridient("Vegetables", "Tomat", 1.4), new Ingridient("Vegetables", "Cucumber", 1.2), new Ingridient("Vegetables", "Sweet peppers", 1.31), new Ingridient("Vegetables", "Chilli peppers", 1.6),
                new Ingridient("Vegetables", "Onion", 1), new Ingridient("Vegetables", "Corn", 1.25), new Ingridient("Vegetables", "Mushrooms", 2), new Ingridient("Vegetables", "Jalapeno", 2),new Ingridient("Meat", "Bacon", 1.9),
                new Ingridient("Meat", "Sausage", 1.55), new Ingridient("Cheese", "Mozzarella", 2.1), new Ingridient("Cheese", "Parmesan", 2.05), new Ingridient("Cheese", "Cheddar", 1.93)};

            for (int i = 0; i < ingridients.Length; i++)
                Console.WriteLine(ingridients[i]);

            Pizza pizza1 = new Pizza();
            Pizza pizza2 = new Pizza();
            Pizza pizza3 = new Pizza();
            Console.WriteLine();
            Console.WriteLine(pizza1.Equals(pizza2));
            Console.WriteLine(pizza2.Equals(pizza3));
            Console.WriteLine(pizza3.Equals(pizza1));
            Console.WriteLine();
            pizza1.AddIngridients(ingridients[1]);
            pizza1.AddIngridients(ingridients[2]);
            pizza1.AddIngridients(ingridients[3]);
            Console.WriteLine(pizza1);
            Console.WriteLine();
            Console.WriteLine(pizza1.Equals(pizza2));
            Console.WriteLine(pizza2.Equals(pizza3));
            Console.WriteLine(pizza3.Equals(pizza1));
            Console.WriteLine();
            Console.WriteLine(pizza1);
        }
    }
    class Pizza
    {
        protected List<Ingridient> ingridients = new List<Ingridient>();
        protected int size;
        protected double size_cost;
        protected string border;
        protected double border_cost;
        public Pizza()
        {
            size = 22;
            size_cost = 60;
            border = "Classic";
            border_cost = 0;
        }
        public Pizza(int size)
        {
            if (!Check_size(size))
                throw new Exception("Bad size");
        }
        public Pizza(int size, string border)
        {
            if (!Check_size(size))
                throw new Exception("Bad size");
            if (!Check_border(border))
                throw new Exception("Bad border type");
        }
        public Pizza(int size, string border, List<Ingridient> ingridients)
        {
            if (!Check_size(size))
                throw new Exception("Bad size");
            if (!Check_border(border))
                throw new Exception("Bad border type");
            this.ingridients = ingridients;
            this.ingridients.Sort();
        }
        public bool ChangeBorder(string border)
        {
            return Check_border(border);

        }
        public bool ChangeSize(int size)
        {
            return Check_size(size);
        }
        private bool Check_border(string border)
        {
            switch (border)
            {
                case "Classic":
                    this.border_cost = size_cost;
                    break;
                case "Cheese":
                    this.border_cost = size_cost * 1.12;
                    break;
                case "Meat":
                    this.border_cost = size_cost * 1.17;
                    break;
                default:
                    return false;
            }
            return true;
        }
        private bool Check_size(int size)
        {
            switch (size)
            {
                case 22:
                    this.size = size;
                    this.size_cost = 60;
                    break;
                case 30:
                    this.size = size;
                    this.size_cost = 85;
                    break;
                case 36:
                    this.size = size;
                    this.size_cost = 120;
                    break;
                default:
                    return false;
            }
            return true;
        }
        public double Cost()
        {
            double cost = 0 + this.size_cost + this.border_cost;
            for (int i = 0; i < this.ingridients.Count; i++)
            {
                Ingridient ingridient = this.ingridients[i];
                cost += ingridient.Cost;
            }
            return cost;
        }
        public bool AddIngridients(Ingridient ingridient)
        {
            try
            {
                if (ingridient != null && ingridient.Cost != 0 && ingridient.Name != "" && ingridient.Type != "")
                {
                    this.ingridients.Add(ingridient);
                    this.ingridients.Sort();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public bool RemoveIngridients(string name)
        {
            try
            {
                for (int i = 0; i < this.ingridients.Count; i++)
                {
                    Ingridient ingridient = this.ingridients[i];
                    if (ingridient.Name == name)
                    {
                        this.ingridients.RemoveAt(i);
                        return true;
                    }

                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public bool IsIngridients(string name)
        {
            try
            {
                for (int i = 0; i < this.ingridients.Count; i++)
                {
                    Ingridient ingridient = this.ingridients[i];
                    if (ingridient.Name == name)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public bool IsIngridients(string name, out int nums)
        {
            try
            {
                nums = 0;
                for (int i = 0; i < this.ingridients.Count; i++)
                {
                    Ingridient ingridient = this.ingridients[i];
                    if (ingridient.Name == name)
                    {
                        nums++;
                    }

                }
                if (nums > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                nums = 0;
                return false;
            }
        }
        public string ListIngridients()
        {
            string text = "";
            for (int i = 0; i < this.ingridients.Count; i++)
            {
                Ingridient ingridient = this.ingridients[i];
                text += ingridient + "\n";
            }
            return text;
        }
        public override string ToString()
        {
            string text = string.Format("Size: {0}sm \nBorder: {1}\n\n", this.size, this.border);
            for (int i = 0; i < this.ingridients.Count; i++)
            {
                Ingridient ingridient = this.ingridients[i];
                text += ingridient + "\n";
            }
            text += string.Format("\nTotal Cost: {0}", Cost());
            return text;
        }
        public override bool Equals(object obj)
        {
            var pizza = obj as Pizza;
            if (this.border != pizza.border)
                return false;
            if (this.size != pizza.size)
                return false;
            if (this.ingridients.Count != pizza.ingridients.Count)
                return false;
            for (int i = 0; i < this.ingridients.Count; i++)
            {
                Ingridient a = this.ingridients[i];
                Ingridient b = pizza.ingridients[i];
                if (a.Name != b.Name || a.Type != b.Type || a.Cost != b.Cost)
                    return false;
            }
            return true;
        }
    }
    class Ingridient
    {
        public string Type { get; }
        public double Cost { get; }
        public string Name { get; }
        public Ingridient(string Type, string Name, double Cost)
        {
            if (Type == "")
                throw new Exception("Bad type");
            this.Type = Type;
            if (Name == "")
                throw new Exception("Bad name");
            this.Name = Name;
            if (Cost <= 0)
                throw new Exception("Bad cost");
            this.Cost = Cost;
        }
        public override string ToString()
        {
            return string.Format("Type: {0,-10}\tName: {1,-18}\tCost: {2}", this.Type, this.Name, this.Cost);
        }
    }
}