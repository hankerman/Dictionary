using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionarys dictionary = new Dictionarys();
            int key;
            //dictionary.Add("square", "квадрат");
            //dictionary.Add("square", "площадь");            
            //dictionary.Print();
            //dictionary.Edit();
            //dictionary.Print();
            //dictionary.Save();

            bool end = true;
            string temp;

            while (end)
            {
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Выбр действия");
                Console.WriteLine("1 - вывести все слова\n2 - перевод слова из словаря\n3 - добавить слово\n4 - удалить слово\n" +
                    "5 - редактировать слово или его перевод\n6 - сохранить\n7 - выход");
                key = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("------------------------------------------------------\n\n\n");

                switch (key)
                {

                    case 1: dictionary.Print();
                        break;
                    case 2: Console.WriteLine("Введите интересующее слово");
                        temp = Console.ReadLine();
                        dictionary.Find(temp);
                        break;
                    case 3: Console.WriteLine("Введите слово");
                        temp = Console.ReadLine();
                        Console.WriteLine("Введите перевод, если значение не одно запишите через запятую");
                        string tempVal = Console.ReadLine();
                        dictionary.Add(temp, tempVal);
                        break;
                    case 4: Console.WriteLine("Введите слово");
                        temp = Console.ReadLine();
                        dictionary.Del(temp);
                        break;
                    case 5: dictionary.Edit();
                        break;
                    case 6: dictionary.Save();
                        break;
                    case 7: dictionary.Save();
                        end = false;
                        break;
                    default: Console.WriteLine("Такой команды не существует");
                        break;


                }


            }


        }
    }
}
