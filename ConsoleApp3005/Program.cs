using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3005
{
    class Program
    {
        static void Main(string[] args)
        {
            string file_name = "Notebook.txt";
            string state = null;

            Console.WriteLine("Введите путь каталога");
            string dirName = Console.ReadLine();
            DirectoryInfo dirInfo = new DirectoryInfo(dirName);

            //Console.Clear();
            if (System.IO.File.Exists(Convert.ToString(Path.GetFullPath(file_name))) == false)
                Console.WriteLine("Не найден файл Notebook.txt, он будет создан");
            while (state != "6")
            {
                try
                {              
                    Console.WriteLine("\n==== Текущая директория: ==== " + dirName + " ====\n" +
                        "0 - очистка экрана\n" +
                        "1 - добавить новую запись\n" +
                        "2 - найти запись\n" +
                        "3 - вывод Notebook.txt\n" +
                        "4 -  инфо о каталоге\n" +
                        "5 -  переход в каталог\n" +
                        "6 -  выход");
                    
                    state = Console.ReadLine();
                    switch (state)
                    {
                        case "0":       //очистка экрана
                            Console.Clear();
                            break;

                        case "1":       //Добавление записи
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
                            string n = null;
                            Console.WriteLine("Введите имя человека для поиска: ");
                            n = Console.ReadLine();
                            Notebook.MySearch(n);
                            break;

                        case "3":       //Вывод всего файла
                            Notebook.MyRead();
                            break;

                        case "4":       //Инфо о текущем каталоге
                            if (Directory.Exists(dirName))
                            {
                                Console.WriteLine("Подкаталоги:");
                                string[] dirs = Directory.GetDirectories(dirName);
                                foreach (string s in dirs)
                                {
                                    Console.WriteLine(s);
                                }
                                Console.WriteLine();
                                Console.WriteLine("Файлы:");
                                string[] files = Directory.GetFiles(dirName);
                                foreach (string s in files)
                                {
                                    Console.WriteLine(s);
                                }
                            }
                            break;

                        case "5":       //Переход в каталог
                            string filePath = "E:\\Новая папка\\Новая папка\\Новая папка";
                            string directoryName;
                            int i = 0;

                            while (filePath != null)
                            {
                                //directoryName = Path.GetDirectoryName(filePath);
                                //Console.WriteLine("GetDirectoryName('{0}') returns '{1}'",
                                //    filePath, directoryName);
                                //filePath = directoryName;
                                //if (i == 1)
                                //{
                                //    filePath = directoryName + @"\";
                                //}
                                //i++;


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
            Console.WriteLine("Нажмите любую клавишу для выхода ...");
            Console.ReadLine();
        }
    }


}