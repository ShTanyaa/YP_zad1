using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie1
{
    class Program
    {
       
        static void Main (string[] args)
        {
            while(true)
            {
                try
                {
                    Console.WriteLine("Введи имя кота");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите вес кота");
                    double weight = double.Parse(Console.ReadLine());
                    if (check(name))
                    {
                        Cat cat = new Cat(name, weight);
                        cat.catInfo();
                        cat.meow();
                    } else
                    {
                        Console.WriteLine("Вы неправильно ввели имя кота!");
                    }
                    Console.WriteLine("Если хотите создать еще одного кота введите 'Да'");
                    if (Console.ReadLine() != "да")
                        break;
                    Console.Clear();
                }
                catch
                {
                    Console.WriteLine("Вы ввели не число");
                }
            }
            bool check (string name)
            {
                foreach (char i in name)
                {
                    if (!Char.IsLetter(i))
                        return false;
                }
                return true;
            }
        }
    }
}
