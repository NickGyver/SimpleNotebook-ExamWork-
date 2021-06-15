using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace ExamWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Notebook.fileN = null;
            string state = null;
            
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"{drive.Name}");
            }
            Console.WriteLine("Введите путь каталога из выше перечисленных:");
            Notebook dir = new Notebook(); //первоначальный выбор каталога
            Notebook.dirName = Console.ReadLine();
            DirectoryInfo dirInfo = new DirectoryInfo(Notebook.dirName);

            Console.Clear();

            while (state != "0")
            {
                try
                {              //главное меню
                    Console.WriteLine("\n==== Текущая директория: ==== " + Notebook.dirName + " ====\n" +                       
                        "1 - добавить новую запись\n" +
                        "2 - найти запись по имени\n" +
                        "3 - полный вывод файла записной книги\n" +
                        "4 - инфо о каталоге\n" +
                        "5 - переход в каталог\n" +
                        "6 - инфо о файле\n" +
                        "7 - очистка экрана\n" +
                        "0 - выход");
                    
                    state = Console.ReadLine();
                    switch (state)
                    {
                        case "0":       //очистка экрана
                            Console.Clear();
                            break;

                        case "1":       //Добавление записи
                            Console.Clear();

                                Console.WriteLine("Введите имя файла с которым нужно работать (создастся новый, если отсутствует):");
                                Notebook fileN = new Notebook();
                                Notebook.fileN = Console.ReadLine();

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

                            break;

                        case "2":       //Найти запись
                            Console.Clear();
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
                                Console.WriteLine("==== Подкаталоги: ====");
                                string[] dirs = Directory.GetDirectories(Notebook.dirName);
                                foreach (string s in dirs)
                                {
                                    Console.WriteLine(s);
                                }
                                Console.WriteLine("\n==== Файлы: ==== ");
                                string[] files = Directory.GetFiles(Notebook.dirName);
                                foreach (string s in files)
                                {
                                    Console.WriteLine(s);
                                }
                            }
                            break;

                        case "5":       //Переход в каталог
                            Console.Clear();
                            foreach (DriveInfo drive in drives)
                            {
                                Console.WriteLine($"{drive.Name}");
                            }
                            Console.WriteLine("Введите путь каталога из выше перечисленных:");
                            Notebook.dirName = Console.ReadLine();
                            DirectoryInfo dirInfoLocal = new DirectoryInfo(Notebook.dirName);
                            Console.Clear();
                            break;

                        case "6": //инфо о файле
                            //Console.Clear();
                            Console.WriteLine("Введите название файла:");
                            string fileName = Console.ReadLine();                           
                            string path = Notebook.dirName + @"\" + fileName;
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