using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie1
{
    class Cat
    {
         private string name;
        private double weight;
        public Cat (string _name,double _weight)
        {
            Name = _name;
            Weight = _weight;
        }
        public void meow ()
        {
            Console.WriteLine($"{name} МЯЯЯУ!!!");
        }
        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value <= 0)
                    Console.WriteLine("Вес не может быть меньше или равен 0 кг.");
                else
                    weight = value;
            }
        }
        public string Name // свойство, реализуем инкапсуляцию!
        {
            // получение значения - просто возврат name
            get
            {
                return name;
            }
            // установка значения - используем проверку
            set
            {
                bool OnlyLetters = true;
                // ключ. слово value - это то, что хотят свойству присвоить
                foreach (var ch in value)
                {
                    if (!char.IsLetter(ch))
                    {
                        OnlyLetters = false;
                    }
                }

                if (OnlyLetters)
                {
                    name = value;
                } else
                {
                    Console.WriteLine($"{value} - неправильное имя!!!");
                }
            }

        }
        public void catInfo ()
        {
            if(weight == 0)
            {
                Console.WriteLine("Вы ввели неправильный вес кота");
            }

            else if (name.Length == 0)
            {
                Console.WriteLine("Вы неправильно ввели имя кота");
            }
           else
                Console.WriteLine($"Кот по имени {name} с весом {weight} кг");
        }
    }
}
