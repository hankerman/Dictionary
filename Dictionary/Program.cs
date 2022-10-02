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
            //dictionary.Add("square", "квадрат");
            //dictionary.Add("square", "площадь");            
            dictionary.Print();
            dictionary.Edit();
            dictionary.Print();
            dictionary.Save();

        }
    }
}
