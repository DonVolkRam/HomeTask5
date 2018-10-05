using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex5
{

    public class TrueOrFalse
    {
        string[] Question;
        string[] Answer;
        int NumOfQuiz;
        List <int> RandomIndexes = new List<int>();

        public string[] Question1 { get => Question; set => Question = value; }
        public string[] Answer1 { get => Answer; set => Answer = value; }
        public List<int> RandomIndexes1 { get => RandomIndexes; set => RandomIndexes = value; }

        public static void Main(string[] args)
        {
            Console.WriteLine("Инициализация базы вопросов");
            try
            {
                TrueOrFalse Quiz = new TrueOrFalse();
                int Score = 0;
                string Answer = "";
                if (Quiz.Read() == false)
                    throw new Exception("Error load file");
                Console.WriteLine("Добро подаловать на игру Квиз!\n" +
                    "Вам предстоит ответить на пять вопросов.\n" +
                    "Желаю вам удачи!\n");
                for (int i = 0; i < 5; i++)
                {
                    int Index = Quiz.Chose();
                    Console.Write(Quiz.Question[Index]);
                    Answer = Console.ReadLine();
                    if (Answer.ToLower() == Quiz.Answer[Index].ToLower())
                        Score++;
//                    Console.Read();
                }
                Console.WriteLine("Вы ответили правильно на " + Score + " вопросов");
            }
            catch
            {
                Console.WriteLine("Ошибка инициализации");
            }
            finally
            {
                Console.Read();
            }
            return;
        }

        /// <summary>
        /// Выбор случайного вопроса без повторений
        /// </summary>
        /// <returns>Возвращает номер вопроса</returns>
        public int Chose()
        {
            Random rnd = new Random();
            bool Compare = true;
            int RndIndex = 0;           
            
            while (Compare)
            {
                RndIndex = rnd.Next(0, 36);
                for (int i = 0; i < RandomIndexes.LongCount(); i++)
                {
                    if (RndIndex == RandomIndexes.ElementAt(i))
                    {
                        Compare = true;
                        break;
                    }
                }
                Compare = false;
            }
            RandomIndexes.Add(RndIndex);
            return RndIndex;
        }
        /// <summary>
        /// Чтение из файлов вопросов
        /// </summary>
        /// <returns>Возвращает истину если успешное чтение</returns>
        public bool Read()
        {
            string filename = "..\\..\\Ex5_Qwiz.txt";
            string[] allFile;
            string[] temp;
            if (File.Exists(filename))
            {
                //Считываем все строки в файл
                allFile = File.ReadAllLines(filename);
                NumOfQuiz = allFile.Length;
                Question1 = new string[NumOfQuiz];
                Answer1 = new string[NumOfQuiz];
                for (int i = 0; i < NumOfQuiz; i++)
                {
                    temp = allFile[i].Split(';');
                    if (temp.Length > 3)
                    {
                        Console.WriteLine("Ошибка чтения данных");
                        continue;
                    }
                    Question1[i] = temp[1];
                    Answer1[i] = temp[2];
                }
                return true;
            }
            else
            {
                Question1 = null;
                Answer1 = null;
                Console.WriteLine("Файл не найден");
                return false;
            }

        }
    }

    
}
