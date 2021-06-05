using System;
using System.IO;

namespace var29
{
    class Program
    {
        static void Main()
        {
            try
            {
                string FileName = "";
                string path = @"C:\alexprog\";

                bool FileCheck = false;
                int choise = 0;

                choise = UserChoise("Программа обрабатывает данные файла.\n 1 - работать с новым файлом \n 2 - работать с существующим файлом");
                if (choise == 1)
                {
                    FileName = CreateFile(path); //Создание файла
                }
                else
                {
                    do
                    {
                        FileName = SearchFile(path); //Поиск файла
                        FileCheck = CheckFile(path, FileName); //Проверка файла на валидность
                    } while (!FileCheck);
                }

                choise = UserChoise("1 - просмотреть содержимое файла \n 2 - завершить работу");

                if (choise == 1) ReadFile(path, FileName); //Просмотр содержимого файла

                MaxSum(path, FileName); //Нахождение максимальной суммы членом растущей последовательности

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }



            Console.ReadLine();
        }

        static int UserChoise(string Message)
        {
            Console.WriteLine(Message);
            double choise = 0;
            try
            {
                do
                {
                    choise = double.Parse(Console.ReadLine());
                } while (choise != (int)choise || choise < 1 || choise > 2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return (int)choise;
        }

        static string CreateFile(string path)
        {
            string FileName = "";
            BinaryWriter file = null;

            do
            {
                try
                {
                    FileName = EnterNewFileName("Введите название создаваемого файла", path);
                    file = new BinaryWriter(new FileStream(path + FileName, FileMode.CreateNew));
                    Random rnd = new Random();
                    int counter = 0;
                    int NumbersAmount = rnd.Next(8);

                    while (counter < NumbersAmount)
                    {
                        int number = rnd.Next(-200, 200);
                        file.Write(number);
                        counter++;
                    }

                }
                catch (Exception e)
                {
                    FileName = "";
                    Console.WriteLine(e);
                }
                finally
                {
                    if (file != null) file.Close();
                }
            } while (FileName.Equals(""));

            return FileName;
        }

        static string SearchFile(string path)
        {
            return CheckFileExisting("Введите имя считываемого файла", path);
        }

        static bool CheckFile(string path, string FileName)
        {
            BinaryReader File = null;

            int current;

            try
            {
                File = new BinaryReader(new FileStream(path + FileName, FileMode.Open));

                /*while (true)
                { */
                    current = File.ReadInt32();
                 /*   if (current > 255) return false; 
                } */
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if (File != null)
                {
                    File.Close();
                }
            }
            return true;
        }

        static string EnterNewFileName(string Message, string path)
        {
            Console.WriteLine(Message);
            string FileName = "";

            do
            {
                FileName = Console.ReadLine();
            } while ((FileName.IndexOfAny(Path.GetInvalidFileNameChars()) != -1) || (FileName.Length + path.Length) >= 259 || FileName.Length == 0 || (File.Exists(path + FileName)));

            return FileName;
        }

        static string CheckFileExisting(string Message, string path)
        {
            string FileName = "";

            do
            {
                Console.WriteLine(Message);
                FileName = Console.ReadLine();
            } while (!File.Exists(path + FileName));

            return FileName;
        }

        static void ReadFile(string path, string FileName)
        {
            BinaryReader File = null;
            int current;
            try
            {
                File = new BinaryReader(new FileStream(path + FileName, FileMode.Open));
                Console.Write("\nСодержимое файла " + FileName + ":\t");
                while (true)
                {
                    current = (int)File.ReadInt32();      //считываем
                    Console.WriteLine(current);     //выводим
                }
            }
            catch (EndOfStreamException) { }
            finally
            {
                if (File != null)
                    File.Close();
            }
        }

        static void MaxSum(string path, string FileName)
        {
            BinaryReader File = null;
            int current;
            int maxsum = 0;
            int currentsum = 0;
            int prev = 0;

            try
            {
                File = new BinaryReader(new FileStream(path + FileName, FileMode.Open));

                prev = File.ReadInt32();
                current = File.ReadInt32();

                if (current > prev) currentsum = prev;

                while (true)
                {
                    if (current > prev)
                    {
                        currentsum += current;
                    }
                    else if (currentsum > maxsum)
                    {
                        maxsum = currentsum;
                        currentsum = 0;
                    }
                    else
                    {
                        currentsum = 0;
                    }

                    prev = current;
                    current = File.ReadInt32();
                }


            }
            catch (EndOfStreamException)
            {
                Console.WriteLine("Наибольшая сумма растущей последовательности: " + maxsum);
            }
            finally
            {
                File.Close();
            }
        }
    }
}