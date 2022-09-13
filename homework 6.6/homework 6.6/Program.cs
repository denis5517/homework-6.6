using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_6._6
{
    internal class Program
    {
        const string file = "file.txt";
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            ConsoleKeyInfo consoleKeyInfo;
            do
            {
                Console.WriteLine("Введем 1 - вывести данные на экран");
                Console.WriteLine("Введем 2 - заполнить данные и добавить новую запись в конец файла");
                consoleKeyInfo = Console.ReadKey();
                Console.WriteLine();
                switch (consoleKeyInfo.KeyChar)
                {
                    case '1';
                        Print();
                        break;

                    case '2';
                        Input();
                        break;
                }
            }
            while (consoleKeyInfo.Key != ConsoleKey.D0);   
        } 
        static void Input()
        {
            StringBuilder stringBuilder = new StringBuilder();
            int id = 1;
            if (!file.Exists(file))
            {
                file.Create(file).close();
                Console.WriteLine("Файл создан");
            }
            else
            {
                id = file.ReadAllLines(file).Length + 1;
            }
            Console.WriteLine($"{id}: Дата и время добавления записи: {DateTime.Now.ToString()}");
            stringBuilder.Append($"{id++}#");
            stringBuilder.Append($"{DateTime.Now.ToString()}#");
            Console.WriteLine("\n Введите Ф.И.О.:");
            stringBuilder.Append($"{Console.ReadLine()}#");
            Console.WriteLine("Введите возраст:");
            stringBuilder.Append($"{Console.ReadLine()}#");
            Console.WriteLine("Введите рост:");
            stringBuilder.Append($"{Console.ReadLine()}#");
            Console.WriteLine("Введите дату рождения:");
            stringBuilder.Append($"{Console.ReadLine()}#");
            Console.WriteLine("Введите место рождения:");
            stringBuilder.Append($"{Console.ReadLine()}");
            using (StreamWriter list = new StreamWriter("file.txt", true, Encoding.Unicode))
            {
                list.WriteLine(stringBuilder.ToString());
            }
        }

        static void Print()
        {
            
            if (!file.Exists(file))
            {
                Console.WriteLine("Файл не существует");
                return;
            }
            using (StreamReader list2 = new StreamReadr(file, Encoding.Unicode))
            {
                string line;
                Console.WriteLine($"{"id",5} {"Дата и время",5} {"Ф.И.О.",5} {"Возраст",5} {"Рост",5} {"Дата рождения",5} {"Место рождения",5}");
                while ((line = list2.ReadLine()) != null)
                {
                    string[] daty = line.Split('#');
                    Console.WriteLine($"{daty[0],5} {daty[1],5} {daty[2],5} {daty[3],5} {daty[4],5} {daty[5],5} {daty[6],5}");
                }
            }
        }   
    }
}
