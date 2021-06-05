using System;

class Program
{
    public static void Main()
    {
       while (true)
      {
            Console.Write("Enter the number of elements: ");
            int quantity = NumbersQ();
            Console.WriteLine("===================FIBONACCI==================");
            FibonacciSeq(quantity);
            Console.WriteLine(" ");
      }
    }
    static int NumbersQ()
    {
        bool isvalid;
        int number = 0;
        do
        {
            try
            {
                isvalid = true;
                number = Convert.ToInt32(Console.ReadLine());
                if (number <= 0) throw new Exception("Must be an integer more than 0");
            }
            catch(FormatException)
            {
                isvalid = false;
                Console.WriteLine("Wrong input format");
            }
            catch(Exception e)
            {
                isvalid = false;
                Console.WriteLine(e.Message);
            }

        }
        while (isvalid == false);
        return number;
    }
    static void FibonacciSeq(int amount)
    {
        int n1 = 0;
        int n2 = 1;
        int n3;
        int i;
        if (amount == 1) Console.Write(n1);
        else
        Console.Write(n1 + " " + n2 + " ");
        for (i = 2; i<amount; ++i)
        {
            n3 = n1 + n2;
            Console.Write(n3 + " ");
            n1 = n2;
            n2 = n3;
        }
    }
}