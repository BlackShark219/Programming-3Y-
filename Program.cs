using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Program
    {
        static void Create_Bin(string name)
        {
            using (BinaryWriter f1 = new BinaryWriter(new FileStream(name, FileMode.Create)))
            {
                Console.WriteLine("Write empty line to end entering");
                int num;
                string vvod;
                while ((vvod = Console.ReadLine()) != "")
                {
                    while (!Int32.TryParse(vvod, out num))
                    {
                        Console.WriteLine("Write a number");
                    }
                    f1.Write(num);
                }
                Console.WriteLine("End entering");
            }
        }


        static void Read_Bin_int(string name)
        {
            using (BinaryReader work = new BinaryReader(File.Open(name, FileMode.Open)))
            {
                int pos = 0;
                int length = (int)work.BaseStream.Length;
                while (pos < length)
                {
                    int v = work.ReadInt32();
                    Console.WriteLine(v);
                    pos += sizeof(int);
                }
                Console.WriteLine();
            }
        }
        public static bool isValid(string filepath, char[] invalidchars)
        {
            foreach (char someChar in invalidchars)
            {
                for (int i = 0; i < filepath.Length; i++)
                {
                    if (filepath[i] == someChar)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        static string EnterName(string path)
        {
            char[] invalidFileChars = Path.GetInvalidFileNameChars();

            string filename = Console.ReadLine();
            while (!isValid(filename, invalidFileChars))// && !File.Exists(path+filename))
            {
                Console.WriteLine("Write valid name");
                filename = Console.ReadLine();
            }
            return filename;
        }
        static void logic(string path, string f1, string f2)
        {
            using (BinaryReader work_1 = new BinaryReader(File.Open(path + f1, FileMode.Open)))
            {
                using (BinaryWriter work_2 = new BinaryWriter(new FileStream(path + f2, FileMode.Create)))
                {
                    int num;
                    bool first_flag = true;
                    int a1 = 1;
                    int a2 = 1;
                    while (work_1.PeekChar() != -1)
                    {
                        num = work_1.ReadInt32();
                        int number;
                        if (first_flag)
                        {
                            a1 = num;
                            number = a1 * a1;
                            first_flag = false;
                        }
                        else
                        {
                            a2 = num;
                            number = a1 * a2;
                            a1 = a2;
                        }
                        work_2.Write(number);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            string path = "c:/fff/";
            char[] invalidPathChars = Path.GetInvalidPathChars();
            if (isValid(path, invalidPathChars))
            {

                Console.WriteLine("Write first file name");
                string f1 = EnterName(path);
                Console.WriteLine("Write second file name");
                string f2 = EnterName(path);
                try
                {
                    Console.WriteLine("Enter 'create' to create a binary file");
                    string action = Console.ReadLine();
                    if (action == "create")
                    {
                        Create_Bin(path + f1);
                    }
                    if (File.Exists(path + f1))
                    {
                        logic(path, f1, f2);
                        Read_Bin_int(path + f2);
                    }
                    else
                    {
                        Console.WriteLine("File not found");
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine(e);
                }
            }
            else
            {
                Console.WriteLine("Change path");
            }
            Console.ReadKey();
        }
        
    }
}