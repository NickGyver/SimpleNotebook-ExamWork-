using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ExamWork
{
    public class Notebook
    {
        public static string fileN { get; set; }
        public static string dirName { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string BirthDate { get; set; }
        public Notebook() { }
                
        public void MyWrite()       //запись в файл
        {



            using (StreamWriter sw = File.AppendText(dirName + @"\"+ fileN))
            {
                sw.WriteLine(this.Name);
                sw.WriteLine(this.Gender);
                sw.WriteLine(this.Phone);
                sw.WriteLine(this.Adress);
                sw.WriteLine(this.BirthDate);
            }
        }
        public static void MyRead() //Читаем из файла
        {
            Console.WriteLine("Какой файл считать?:");
            string fileOpen = Console.ReadLine();
            using (StreamReader sr = File.OpenText(dirName + @"\" + fileOpen))
            {

                while (sr.EndOfStream != true)
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
        public static void MySearch(string name)   //поиск по записям
        {
            Console.WriteLine("Какой файл считать?:");
            string fileOpen = Console.ReadLine();
            using (StreamReader sr = File.OpenText(dirName + @"\" + fileOpen))
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
                    Console.WriteLine("Такой человек не найден!");
            }
        }

    }
}
