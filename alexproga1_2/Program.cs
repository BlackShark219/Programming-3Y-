using System;
using System.IO;

namespace Lab29_2
{
    class Program
    {
        static void Main()
        {
            string path = @"C:\alexprog\", FileType = ".txt";
            string FileToRead = null, FileToWrite = null;
            string Keyword;

            try
            {
                FileToRead = SearchFile(path, FileType);
                WriteContent(FileToRead, path, FileType);
                FileToWrite = CreateFile(path, FileType);
                Keyword = GetKeyword("Введите ключевое слово");
                WriteToFile(FileToRead, FileToWrite, path, FileType, Keyword);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadLine();
        }

        static string SearchFile(string path, string FileType)
        {
            string FileName = "";
            do
            {
                Console.WriteLine("Введите имя файла для считывания");
                FileName = Console.ReadLine();
            } while (!File.Exists(path + FileName + FileType));

            return FileName;
        }

        static void WriteContent(string FileName, string path, string FileType)
        {
            StreamReader file = null;
            string line = null;
            try
            {
                file = new StreamReader(new FileStream(path + FileName + FileType, FileMode.Open));
                while ((line = file.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            finally
            {
                if (file != null)
                    file.Close();
            }
        }

        static string CreateFile(string path, string FileType)
        {
            string FileName = null;
            StreamReader file = null;
            do
            {
                try
                {
                    do
                    {
                        Console.WriteLine("Введите название файла, который хотите создать");
                        FileName = Console.ReadLine();
                    } while ((FileName.IndexOfAny(Path.GetInvalidFileNameChars()) != -1) || (FileName.Length + path.Length) >= 259 || FileName.Length == 0 || (File.Exists(path + FileName + FileType)));
                    file = new StreamReader(new FileStream(path + FileName + FileType, FileMode.CreateNew));
                }
                catch (Exception)
                {
                    FileName = "";
                }
                finally
                {
                    file.Close();
                }
            } while (FileName.Equals(""));
            return FileName;
        }

        static string GetKeyword(string Message)
        {
            string Keyword = " ";

            Console.WriteLine(Message);

            try
            {
                Keyword = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return Keyword;
        }

        static void WriteToFile(string FileToRead, string FileToWrite, string path, string FileType, string Keyword)
        {
            StreamReader file1 = null;
            StreamWriter file2 = null;

            char[] banned = { ' ', ',', '.', ';', ':', '?', '!' };
            string line;
            string[] Array;
            string[] PrevArray;

            try
            {
                file1 = new StreamReader(new FileStream(path + FileToRead + FileType, FileMode.Open));
                file2 = new StreamWriter(new FileStream(path + FileToWrite + FileType, FileMode.Open));

                line = file1.ReadLine();
                PrevArray = line.Split(banned, StringSplitOptions.RemoveEmptyEntries);

                while ((line = file1.ReadLine()) != null)
                {
                    Array = line.Split(banned, StringSplitOptions.RemoveEmptyEntries);



                    if (Array[0] == Keyword)
                    {
                        for (int i = 0; i < PrevArray.Length; i++)
                        {
                            file2.Write(PrevArray[i] + " ");
                        }
                        file2.Write("\n");
                    }

                    PrevArray = Array;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if (file1 != null) file1.Close();
                if (file2 != null) file2.Close();
            }
        }
    }
}