using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//Разработать класс Message, содержащий следующие статические методы для обработки
//текста:
//а) Вывести только те слова сообщения, которые содержат не более n букв.
//б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
//в) Найти самое длинное слово сообщения.
//г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.

//Выполнил Волков Кирилл
namespace Ex2
{
    class Message
    {
        static void Main(string[] args)
        {
            string Message = "В школе нас всех учили писать под диктовку. " +
                "Но это не имеет никакого отношения к конспектированию лекций. " +
                "Метод Корнелла наводит порядок в хаотичных студенческих записях и " +
                "позволяет легко подготовитьсяzzz к экзаменам. Кстати, этот метод пригодится " +
                "вам и на работе во время встреч и совещаний.";

            Console.WriteLine(Message+"\n");

            List<string> Result = new List<string>();
            Result=GetWordsOf(Message, 3);
            for (int i = 0; i < Result.LongCount(); i++)
                Console.WriteLine(Result.ElementAt(i));

            Console.WriteLine("\n" + DeleteWordsEndsOn(Message, 'д') + "\n");

            Console.WriteLine("САМОЕ ДЛИННОЕ СЛОВО");
            string word = FindTheLongestWord(Message);
            Console.WriteLine(word + "\n");
            
            Console.WriteLine("StringBuilder : " + stringBuilder(Message, word));
            Console.Read();
        }

        /// <summary>
        /// Метод возвращающий слова с количеством букв не превышающих n
        /// </summary>
        /// <param name="message">Сообщение со словами</param>
        /// <param name="n">количество букв </param>
        /// <returns>Возвращает список слов удовлетворяющий условию входа</returns>
        public static List<string> GetWordsOf(string message, int n)
        {
            List<string> Result = new List<string>();
            var pat = @"[A-Za-zА-Яа-я]{1,}";
            Regex reg = new Regex(pat);
            foreach (var e in reg.Matches(message))
            {
                string Stemp = e.ToString();
                if (Stemp.Length < n + 1)
                    Result.Add(Stemp);
            }
            return Result;
        }

        /// <summary>
        /// Метод удаляющий из сообщения слова оканчивающиеся на букву
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="c">Конечная буква слова, которое нужно удалить из сообщения</param>
        /// <returns></returns>
        public static string DeleteWordsEndsOn(string message, char c)
        {
            string newMessage = message;
            var pat = @"[A-Za-zА-Яа-я]{1,}";
            Regex reg = new Regex(pat);
            foreach (var e in reg.Matches(message))
            {
                string Stemp = e.ToString();
                if (Stemp.LastOrDefault() == c)                   
                    newMessage = newMessage.Substring(0, newMessage.IndexOf(Stemp)) + 
                        newMessage.Substring(newMessage.IndexOf(e.ToString()) + Stemp.Length);
            }            
            return newMessage;
        }

        /// <summary>
        /// Метод возвращающий самое длинное слово в сообщении
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <returns>Самое длинное слово</returns>
        public static string FindTheLongestWord(string message)
        {
            string Word = "";
            int MaxLenght = 0;
            var pat = @"[A-Za-zА-Яа-я]{1,}";
            Regex reg = new Regex(pat);
            foreach (var e in reg.Matches(message))
            {
                string Stemp = e.ToString();
                if (Stemp.Length > MaxLenght)
                {
                    MaxLenght = Stemp.Length;
                    Word = Stemp;
                }
            }
            return Word;
        }

        /// <summary>
        /// метод собирающий самые длинные слова
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="word">самое длинное слово</param>
        /// <returns>склейку из самых длинных слов</returns>
        public static StringBuilder stringBuilder(string message, string word)
        {
            StringBuilder Result = new StringBuilder();
            Result.Clear();           
            var pat = @"[A-Za-zА-Яа-я]{1,}";
            Regex reg = new Regex(pat);
            foreach (var e in reg.Matches(message))
            {
                string Stemp = e.ToString();
                if (Stemp.Length == word.Length)
                    Result.Append(Stemp);
            }
            return Result;
        }

    }
}
