using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace ExamWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //string file_name = "Notebook.txt";
            string state = null;

            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"{drive.Name}");
            }
            Console.WriteLine("Введите путь каталога из выше перечисленных:");
            Notebook dir = new Notebook();
            Notebook.dirName = Console.ReadLine();
            DirectoryInfo dirInfo = new DirectoryInfo(Notebook.dirName);

            Console.WriteLine("Хотите ли вы ввести новое имя файла? (y/n)");
            string Q = Console.ReadLine(); 
            if (Q == "y")
            {
                Console.WriteLine("Введите желаемое имя файла:");
                Notebook fileN = new Notebook();
                Notebook.fileN = Console.ReadLine();
            }
            else if (Q == "n")
            {
                Console.Clear();
            }


            //if (System.IO.File.Exists(Path.GetFullPath(Convert.ToString(Notebook.fileN))) == false)
            //    Console.WriteLine("Не найден файл, он будет создан");

            Console.Clear();

            while (state != "7")
            {
                try
                {              //главное меню
                    Console.WriteLine("\n==== Текущая директория: ==== " + Notebook.dirName + " ====\n" +
                        "0 - очистка экрана\n" +
                        "1 - добавить новую запись\n" +
                        "2 - найти запись\n" +
                        "3 - вывод файла записной книги\n" +
                        "4 - инфо о каталоге\n" +
                        "5 - переход в каталог\n" +
                        "6 - Инфо о файле\n" +
                        "7 - выход");
                    
                    state = Console.ReadLine();
                    switch (state)
                    {
                        case "0":       //очистка экрана
                            Console.Clear();
                            break;

                        case "1":       //Добавление записи
                            if (Notebook.fileN != null)
                            {
                                Console.WriteLine("Введите желаемое имя файла:");
                                Notebook fileN = new Notebook();
                                Notebook.fileN = Console.ReadLine();
                            }
                            else
                            {
                                Notebook temp = new Notebook();
                                Console.WriteLine("Введите имя: ");
                                temp.Name = Console.ReadLine();
                                Console.WriteLine("Введите пол: ");
                                temp.Gender = Console.ReadLine();
                                Console.WriteLine("Введите номер телефона: ");
                                temp.Phone = Console.ReadLine();
                                Console.WriteLine("Введите адрес: ");
                                temp.Adress = Console.ReadLine();
                                Console.WriteLine("Введите дату рождения: ");
                                temp.BirthDate = Console.ReadLine();
                                temp.MyWrite();
                            }
                            break;

                        case "2":       //Найти запись
                            string n = null;
                            Console.WriteLine("Введите имя человека для поиска: ");
                            n = Console.ReadLine();
                            Notebook.MySearch(n);
                            break;

                        case "3":       //Вывод всего файла
                            Console.Clear();

                            Notebook.MyRead();
                            break;

                        case "4":       //Инфо о текущем каталоге
                            Console.Clear();
                            if (Directory.Exists(Notebook.dirName))
                            {
                                Console.WriteLine("Подкаталоги:");
                                string[] dirs = Directory.GetDirectories(Notebook.dirName);
                                foreach (string s in dirs)
                                {
                                    Console.WriteLine(s);
                                }
                                Console.WriteLine();
                                Console.WriteLine("Файлы:");
                                string[] files = Directory.GetFiles(Notebook.dirName);
                                foreach (string s in files)
                                {
                                    Console.WriteLine(s);
                                }
                            }
                            break;

                        case "5":       //Переход в каталог

                            Console.WriteLine("Введите новый путь каталога:");
                            Notebook.dirName = Console.ReadLine();
                            DirectoryInfo dirInfoLocal = new DirectoryInfo(Notebook.dirName);
                            Console.Clear();
                            break;
                        case "6": //инфо о файле
                            
                            Console.WriteLine("Введите название файла:");
                            string fileName = Console.ReadLine();                           
                            string path = Notebook.dirName + @"\" + /*"Notebook.txt"*/ fileName;
                            FileInfo fileInf = new FileInfo(path);
                            if (fileInf.Exists)
                            {
                                Console.WriteLine("Имя файла: {0}", fileInf.Name);
                                Console.WriteLine("Время создания: {0}", fileInf.CreationTime);
                                Console.WriteLine("Размер: {0}", fileInf.Length);
                            }

                            break;
                        default:        //дефолт
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } 
        }
    }
}