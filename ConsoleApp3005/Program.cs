using System;
using System.IO;
using System.Text;

namespace Notebook
{
    class Program
    {
        static void Main(string[] args)
        {
            string file_name = "Notebook.txt";
            string state = null;
            Console.Clear();
            if (System.IO.File.Exists(Convert.ToString(Path.GetFullPath(file_name))) == false)
                Console.WriteLine("Не найден файл Notebook.txt, он будет создан");
            while (state != "4")
            {
                try
                {
                    Console.WriteLine(" 1 - добавить новую запись  2 - найти запись  3 - вывод  4 -  выход");
                    state = Console.ReadLine();
                    switch (state)
                    {
                        case "1":
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
                        case "2":
                            string n = null;
                            Console.WriteLine("Введите имя человека для поиска: ");
                            n = Console.ReadLine();
                            Notebook.MySearch(n);
                            break;
                        case "3":
                            Notebook.MyRead();
                            break;
                        default:
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

    public class Notebook
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string BirthDate { get; set; }
        public Notebook() { }
        public void MyWrite()
        {
            using (StreamWriter sw = File.AppendText("Notebook.txt"))
            {
                sw.WriteLine(this.Name);
                sw.WriteLine(this.Gender);
                sw.WriteLine(this.Phone);
                sw.WriteLine(this.Adress);
                sw.WriteLine(this.BirthDate);
            }
        }
        public static void MyRead()
        {
            using (StreamReader sr = File.OpenText("Notebook.txt"))
            {

                while (sr.EndOfStream!=true)
                {
                    Console.WriteLine(String.Format("Полное имя: " + sr.ReadLine()));
                    Console.WriteLine(String.Format("Пол: " + sr.ReadLine()));
                    Console.WriteLine(String.Format("Телефон: " + sr.ReadLine()));
                    Console.WriteLine(String.Format("Адрес: " + sr.ReadLine()));
                    Console.WriteLine(String.Format("Дата Рождения: " + sr.ReadLine()));
                    Console.WriteLine("\n\n");
                }
            }
        }
        public static void MySearch(string name)
        {
            using (StreamReader sr = File.OpenText("Notebook.txt"))
            {
                string temp = null;
                while ((temp = sr.ReadLine()) != name && temp != null) ;
                if (temp == name)
                {
                    Console.WriteLine("Полное имя: " + temp);
                    Console.WriteLine(String.Format("Пол: " + sr.ReadLine()));
                    Console.WriteLine(String.Format("Телефон: " + sr.ReadLine()));
                    Console.WriteLine(String.Format("Адрес: " + sr.ReadLine()));
                    Console.WriteLine(String.Format("Дата Рождения: " + sr.ReadLine()));
                    Console.WriteLine("\n\n");
                }
                else
                    Console.WriteLine("Такой человек не найден ...");
            }
        }

    }
}