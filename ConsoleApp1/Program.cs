using System;
using System.IO;
using System.Text;
// 14 задаия, часть 1 (бинарные потоки)
namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string path1 = @"C:\stream\binary\f1.txt";
                string path2 = @"C:\stream\binary\";
                path2 = @"C:\stream\binary\" + Creating(path2);

                FirstFileWriter(path1);
                Reader(path1, path2);
                Reader2(path2);
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

        static string Creating(string adress)
        {

            string fname;
            try
            {
                do
                {
                    Console.WriteLine(@"Input file's name without '\, /, |, :, ?, *, <, >'; name must be different from 'f1' ");
                    fname = Console.ReadLine();
                    fname = fname.Replace(@"\", "_").Replace("/", "_").Replace(@"|", "_").Replace(@":", "_").Replace(@"?", "_").Replace(@"<", "_").Replace(@">", "_").Replace(@"*", "_");
                }
                while (File.Exists(adress + fname + ".txt"));

                return fname + ".txt";
            }
            catch (IOException e) { Console.WriteLine(e.Message); return null; }
            catch (Exception exc) { Console.WriteLine(exc.Message); return null; }
        }

        static void FirstFileWriter(string path)
        {

            BinaryWriter writer = null;
            try
            {
                int a = 0;
                writer = new BinaryWriter(File.Open(path, FileMode.Truncate, FileAccess.Write), Encoding.UTF8);
                do
                {
                    Console.WriteLine("Input integer number");
                    a = int.Parse(Console.ReadLine());
                    writer.Write(a);
                    Console.WriteLine("Input 'y' to continue writing, any other keys to stop");
                } while (Console.ReadLine() == "y");
                writer.Close();
            }
            catch (FileNotFoundException fnfe) { Console.WriteLine(fnfe.Message); }
            catch (ArgumentNullException ane) { Console.WriteLine(ane.Message); }
            catch (ArgumentException ae) { Console.WriteLine(ae.Message); }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally { writer.Close(); }
        }


        static void Reader(string path1, string path2)
        {
            BinaryReader reader = null;
            BinaryWriter writer = null;
            try
            {
                reader = new BinaryReader(File.Open(path1, FileMode.Open));
                writer = new BinaryWriter(File.Open(path2, FileMode.CreateNew, FileAccess.Write), Encoding.UTF8, false);
                while (reader.PeekChar() != -1)
                {

                    int a = reader.ReadInt32();
                    a = Logic(a);
                    writer.Write(a);
                    Console.WriteLine(a);
                }

            }
            catch (FileNotFoundException fnfe) { Console.WriteLine(fnfe.Message); }
            catch (ArgumentException ae) { Console.WriteLine(ae.Message); }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally { reader.Close(); writer.Close(); }
        }
        static int Logic(int a)
        {
            try
            {
                if (a % 2 == 0) { a = a * a; }
                else { a = a * a * a; }
                return a;
            }
            catch (Exception e) { Console.WriteLine(e.Message); return Logic(a); }
        }
        static void Reader2(string path2)
        {
            BinaryReader reader = null;
            try
            {
                int a;
                reader = new BinaryReader(File.Open(path2, FileMode.Open));
                while (reader.PeekChar() != -1)
                {
                    a = reader.ReadInt32();
                    // Console.WriteLine(a);
                }
            }
            catch (FileNotFoundException fnfe) { Console.WriteLine(fnfe.Message); }
            catch (ArgumentException ae) { Console.WriteLine(ae.Message); }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally { reader.Close(); }
        }
    }
}