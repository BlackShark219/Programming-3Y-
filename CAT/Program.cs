using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Cat
    {
        string name;  // поле 
        int tail;     // поле
        // відкриті члени
        public void Print()  // метод
        {
            Console.WriteLine($"Кiт {name}a має хвiст {tail}см.");
        }
        public Cat(string Name, int Tail)
        {
            name = Name;
            tail = Tail;
            Console.WriteLine($"Виконався конструктор з параметрами");
        }
        public Cat()
        {
            name = "Вася";
            tail = 25;
            Console.WriteLine($"Виконався конструктор без параметрiв {name} має хвiст {tail}");
        }
        public int Tail
        {
            set { tail = value; }
            get { return tail; }
        }

    }
    class Program
    {

        static void Main(string[] arg)
        {
            Cat a = new Cat(); //
            a.Print();  // виклик методу 

            a.Tail = 45;
            Console.WriteLine($"Прошло время и хвост стал {a.Tail}");

            Console.ReadKey();
        }

    }
}

