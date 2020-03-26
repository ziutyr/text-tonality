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

            // Формирование словаря тональности
            string dictionary_path = "./dictionary.txt";
            string dictText = File.ReadAllText(dictionary_path, Encoding.GetEncoding(1251));
            var dictionary = new Dictionary<string, string>();
            int c_start = 0;
            string key = default;
            for (int c = 1; c < dictText.Length; c++)
            {
                if (dictText[c] == ',')
                {
                    key = dictText.Substring(c_start, c - c_start);
                    c_start = c + 1;
                    c++;
                }
                else if (dictText[c] == '\r')
                {
                    string value = dictText.Substring(c_start, c - c_start);
                    dictionary[key] = value;
                    c_start = c + 2;
                    c += 2;
                }
            }
            // Чтения файла для определения тональности
            Console.Write("[ОПРЕДЕЛЕНИЕ ТОНАЛЬНОСТИ ФАЙЛА]\nПуть к файлу:\n");
            string file = Console.ReadLine();

            if (File.Exists(file))
            {
                // Определение тональности
                string fileText = File.ReadAllText(file, Encoding.GetEncoding(1251));
                int tonality = 0;
                string[] words = fileText.ToLower().Split(new char[] { ' ', '\n' });
                char[] specialSymbols = "`~!@\"#№$;%:^?&*()-_=+[]{}'\\|/.,\r".ToCharArray();
                string word;
                foreach (string w in words)
                {
                    word = w.Trim(specialSymbols);
                    if (dictionary.ContainsKey(word))
                    {
                        switch (dictionary[word])
                        {
                            case "нгтв":
                                tonality--;
                                break;
                            case "пзтв":
                                tonality++;
                                break;
                        }
                    }
                }

                // Вывод результата
                Console.WriteLine("\nТональность текста - " +
                    (tonality > 0 ? "положительная" : (tonality < 0 ? "отрицательная" : "нейтральная")) +
                    ".\nТочное значение: " + tonality);
            }
            else
            {
                Console.WriteLine("\nФайл не существует. Проверьте правильность пути.");
            }

            Console.ReadKey();
        }
    }
}
