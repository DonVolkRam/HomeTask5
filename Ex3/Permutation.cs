using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//* Для двух строк написать метод, определяющий, является ли одна строка перестановкой
//другой.Регистр можно не учитывать:
//а) с использованием методов C#;
//б) * разработав собственный алгоритм.
// Например:
//badc являются перестановкой abcd .

//Выполнил Волков Кирилл

namespace Ex3
{
    class Permutation
    {
        static void Main(string[] args)
        {
            string a = "толстые книги в тонких обложках";
            string b = "тонкие книги в толстых обложках";
            //string a = "qwert asdFGH";
            //string b = "asdqwe rtfgh";

            Console.WriteLine(a);
            Console.WriteLine(b);

            Console.WriteLine("\nC# методы");
            if(PermutationSharp(a, b))
                Console.WriteLine("Строки являются перестановкой друг друга");
            else
                Console.WriteLine("Перестановка отсутствует");

            Console.WriteLine("\nСобственный метод");
            if (PermutationMine(a, b))
                Console.WriteLine("Строки являются перестановкой друг друга");
            else
                Console.WriteLine("Перестановка отсутствует");

            Console.Read();
        }

        /// <summary>
        /// Метод проверки наличия перестановки двух строк используя стандартные методы С Sharp
        /// </summary>
        /// <param name="a">Первая строка</param>
        /// <param name="b">Вторая строка</param>
        /// <returns></returns>
        private static bool PermutationSharp(string a, string b)
        {
            a = a.ToLower();
            b = b.ToLower();

            if (a.Length != b.Length)
                return false;

            List<char> aList, bList;

            aList = new List<char>();
            bList = new List<char>();
            for (int i = 0; i < a.Length; i++)
            {
                aList.Add(a.ElementAt(i));
                bList.Add(b.ElementAt(i));
            }

            aList.Sort();                
            bList.Sort();

            for (int i = 0; i < bList.LongCount(); i++)
            {
                if (aList.ElementAt(i) != bList.ElementAt(i))
                    return false;
            }
            return true;                       
        }

        /// <summary>
        /// Метод проверки наличия перестановки двух строк
        /// </summary>
        /// <param name="First">Первая строка</param>
        /// <param name="Second">Вторая строка</param>
        /// <returns>Возвращает истину если есть перестановка.</returns>
        public static bool PermutationMine(String First, String Second)
        {
            First = First.ToLower();
            Second = Second.ToLower();

            if (First.Length != Second.Length)
                return false;

            int[] letters = new int[2048];
            char[] CharArray = First.ToCharArray();

            for (int i = 0; i < CharArray.Length; i++)
                letters[Convert.ToInt32(CharArray[i])]++;

            for (int i = 0; i < Second.Length; i++)
                if (--letters[Convert.ToInt32(Second.ElementAt(i))] < 0)
                    return false;

            return true;
        }

    }

    
}
