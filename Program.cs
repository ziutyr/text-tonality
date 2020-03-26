using System;
using System.IO;
using System.Text;

namespace TextTonality
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = Console.ReadLine();
            string fileText = File.ReadAllText(file, Encoding.GetEncoding(1251));

            //формирование словаря тональности
            //определение тональности
        }
    }
}
