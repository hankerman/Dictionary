using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dictionary
{
    internal class Dictionarys
    {

        SortedDictionary<string, string> dictionary;

        public Dictionarys()
        {
            dictionary = new SortedDictionary<string, string>();
            using (FileStream fs = new FileStream("dicti.txt", FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read))
            {
                using(StreamReader sr = new StreamReader(fs))
                {
                    if(!sr.EndOfStream)
                    {
                        while (!sr.EndOfStream)
                        {
                            string temp = sr.ReadLine();
                            if(temp != "")
                            {
                                string[] tmp = temp.Split('|');
                                dictionary.Add(tmp[0], tmp[1]);
                            }
                            
                        }
                    }
                    
                }
            }
        }

        public void Add(string word, string translation)
        {

            if (dictionary.ContainsKey(word))
            {
                string temp = dictionary[word];
                temp += ", " + translation;
                dictionary[word] = temp;
            }
            else
            {
                dictionary.Add(word, translation);
            }
            
        }

        public void Save()
        {

            using (FileStream fs = new FileStream("dicti.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
            {

                using (StreamWriter sr = new StreamWriter(fs))
                {

                    foreach(var it in dictionary)
                    {

                        sr.WriteLine($"{it.Key}|{it.Value}");

                    }

                    Console.WriteLine("Сохранено");
                }

            }

        }

        public void Print()
        {

            foreach (var it in dictionary)
            {

                Console.WriteLine($"{it.Key}\t|  {it.Value}");

            }

        }

        public void Del(string word)
        {
            dictionary.Remove(word);
        }

        public void Edit()
        {

            DialogResult res = MessageBox.Show("Редактировать слово?", "Редактор", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if(res == DialogResult.Yes)
            {
                Console.WriteLine("Введите слово которое хотите отредактировать");
                string tempKey = Console.ReadLine();
                string tempValue = dictionary[tempKey];
                Console.WriteLine("Введите слово отредактированым");
                string newKey = Console.ReadLine();
                dictionary.Remove(tempKey);
                dictionary.Add(newKey, tempValue);
            }
            else if(res == DialogResult.No)
            {

                Console.WriteLine("Введите слово значение которого хотите отредактировать");
                string tempKey = Console.ReadLine();
                Console.WriteLine("Введите новые значения через запятую");
                string tempValue = Console.ReadLine();
                dictionary[tempKey] = tempValue;

            }
            else
            {

                Console.WriteLine("Не редактируем");

            }

        }

        public void Find(string word)
        {

            if (dictionary.ContainsKey(word))
            {
                Console.WriteLine($"{word} - {dictionary[word]}");
            }
            else
            {
                Console.WriteLine("Слово не найдено");
            }

            

        }

    }
}
