using System;

using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace oop
{
    delegate int CompareItems(RestrictedStringTuple obj1, RestrictedStringTuple obj2);
    struct RestrictedStringTuple
    {

        public string Item1, Item2, Item3, Item4, Item5, Item6;
        public int MaxSize;
        public bool modify;

        public bool ClearExtra()
        {
            modify = false;
            if (Item1.Length > MaxSize)
            { Item1 = ""; modify = true; }
            if (Item2.Length > MaxSize)
            { Item2 = ""; modify = true; }
            if (Item3.Length > MaxSize)
            { Item3 = ""; modify = true; }
            if (Item4.Length > MaxSize)
            { Item4 = ""; modify = true; }
            if (Item5.Length > MaxSize)
            { Item5 = ""; modify = true; }
            if (Item6.Length > MaxSize)
            { Item6 = ""; modify = true; }
            return modify;
        }

        public override string ToString()
        {
            return $"{Item1}\n{Item2}\n{Item3}\n{Item4}\n{Item5}\n{Item6}\n";

        }
        public static RestrictedStringTuple Create(int maxsize, params string[] s)
        {
            RestrictedStringTuple tuple = new RestrictedStringTuple();
            tuple.Item1 = ""; tuple.Item2 = ""; tuple.Item3 = ""; tuple.Item4 = ""; tuple.Item5 = ""; tuple.Item6 = "";
            switch (s.Length)
            {
                case 1: { tuple.Item1 = s[0]; break; }
                case 2: { tuple.Item1 = s[0]; tuple.Item2 = s[1]; break; }
                case 3: { tuple.Item1 = s[0]; tuple.Item2 = s[1]; tuple.Item3 = s[2]; break; }
                case 4: { tuple.Item1 = s[0]; tuple.Item2 = s[1]; tuple.Item3 = s[2]; tuple.Item4 = s[3]; break; }
                case 5: { tuple.Item1 = s[0]; tuple.Item2 = s[1]; tuple.Item3 = s[2]; tuple.Item4 = s[3]; tuple.Item5 = s[4]; break; }
                case 6: { tuple.Item1 = s[0]; tuple.Item2 = s[1]; tuple.Item3 = s[2]; tuple.Item4 = s[3]; tuple.Item5 = s[4]; tuple.Item6 = s[5]; break; }
                default: throw new RestrictedStringTupleException();
            }
            tuple.MaxSize = maxsize; // максимальний розмір рядка в кортежі
            tuple.modify = false;
            return tuple;
        }

        // властивості-делегати
        public static CompareItems SortByItem1
        {
            get
            {
                return delegate (RestrictedStringTuple x, RestrictedStringTuple y) // анонімний метод
                {
                    return x.Item1.CompareTo(y.Item1);
                };

            }  //(x, y) =>  {return x.Item1.CompareTo(y.Item1); }; }  // лямбда-вираз (лаконична запис анонімного метода)

        }

        public static CompareItems SortByItem2
        {
            get
            {
                return (x, y) => { return x.Item2.CompareTo(y.Item2); }; // лямбда-вираз
            }

        }
        public static CompareItems SortByTolalLength
        {
            get
            {
                return (x, y) =>
                {
                    int Length1 = x.Item1.Length + x.Item2.Length + x.Item3.Length + x.Item4.Length + x.Item5.Length + x.Item6.Length;
                    int Length2 = y.Item1.Length + y.Item2.Length + y.Item3.Length + y.Item4.Length + y.Item5.Length + y.Item6.Length;
                    return Length1.CompareTo(Length2);
                };
            }

        }
    }
    class RestrictedStringTupleException : Exception
    {
        public override string Message
        {
            get { return "Невiрна кiлькiсть параметрiв"; }
        }
    }

    class MyMas
    {
        const int MaxSize = 10;
        RestrictedStringTuple[] mas;
        public MyMas()
        {
            mas = new RestrictedStringTuple[MaxSize];
        }
        public MyMas(int size)
        { if (size == MaxSize)
            { mas = new RestrictedStringTuple[size]; }
            else throw new InvalidSize();
        }
        public class InvalidSize : Exception
        {
            public override string Message
            {
                get { return "Incorrect size"; }
            }
        }

        public RestrictedStringTuple this[int index]
        {
            get
            {
                return mas[index];
            }
            set
            {
                mas[index] = value;
            }
        }
        public void Print()
        {
            foreach (var m in mas)
                Console.WriteLine(m.ToString());
            Console.WriteLine("-------------------------------------------");
        }
        public void ModPrint()
        {
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i].ClearExtra())
                    Console.WriteLine(mas[i].ToString());
            }
            Console.WriteLine("-------------------------------------------");
        }
        public void Sort(CompareItems compare)
        {
            for (int i = 0; i < mas.Length - 1; i++)
                for (int j = i + 1; j < mas.Length; j++)
                    if (compare(mas[i], mas[j]) == 1)
                    {
                        RestrictedStringTuple c = mas[i]; // selection sort
                        mas[i] = mas[j];
                        mas[j] = c;
                    }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            MyMas myTuple = new MyMas(11);
            try
            {
                myTuple[0] = RestrictedStringTuple.Create(20, "Ася", "Асисуалий", "Василий Цезаревич", "Мура Барсиковна", "yyyy", "tttt");
                myTuple[1] = RestrictedStringTuple.Create(15, "Барсик", "Барсилашвили", "Барсилио", "Тима Леопольдовна", "Мура Леопардовна");
                myTuple[2] = RestrictedStringTuple.Create(5, "Алик", "Леопольд", "Лев Леопардович", "Мура Львовна");
                myTuple[3] = RestrictedStringTuple.Create(10, "Л", "О", "М", "П");
                myTuple.Print();
                //Console.WriteLine("=============================================");
                //myTuple.Sort(RestrictedStringTuple.SortByItem1);
                //myTuple.Print();
                //Console.WriteLine("=============================================");
                //myTuple.Sort(RestrictedStringTuple.SortByItem2);
                //myTuple.Print();
                //Console.WriteLine("=============================================");
                //myTuple.Sort(RestrictedStringTuple.SortByTolalLength);
                //myTuple.Print();
                myTuple.ModPrint();
                myTuple.Print();
            }
            catch (RestrictedStringTupleException e)
            {
                Console.WriteLine(e.Message);
            }



            Console.ReadKey();
        }

    }
}




