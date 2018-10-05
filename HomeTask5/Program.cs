using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex1;
using Ex2;
using Ex3;
using Ex5;

namespace HomeTask5
{
    class Program
    {
        static void Main(string[] args)
        {                      
            if (true)
            {
                int choise = 0;
                string temp;
                while (true)
                {                   
                    PrintTask();
                    try
                    {
                        temp = Console.ReadLine();
                        if ("q" == Convert.ToString(temp))
                        {
                            Console.WriteLine("До свидания! Всего доброго!");
                            Pause();
                            break;
                        }
                        else
                            choise = Convert.ToInt32(temp);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Неверный формат ввода. Введите число соответствующее номеру задачи");
                    }
                    Console.Clear();
                    switch (choise)
                    {
                        case 1:
                            Console.WriteLine("Программа, которая проверяет корректность ввода логина\n");
                            ProLogin.Main(args);
                            break;
                        case 2:
                            Console.WriteLine("Класс Message, содержащий статические методы для обработки\n");
                            Message.Main(args);
                            break;
                        case 3:
                            Console.WriteLine("Метод, определяющий, является ли одна строка перестановкой другой\n");
                            Permutation.Main(args);
                            break;
                        case 4:
                            Console.WriteLine("Фамилии и имена трёх худших по среднему баллу учеников\n");

                            break;
                        case 5:
                            Console.WriteLine("Игра - Верю. Не верю\n");
                            TrueOrFalse.Main(args);
                            break;
                        default:
                            break;
                    }
                    choise = 0;
                }
            }
            else
                Pause();
        }

        /// <summary>
        /// Пауза программы
        /// </summary>
        public static void Pause()
        {
            Console.Read();
        }

        /// <summary>
        /// Метод вывода на эран меню выбора задач
        /// </summary>
        static void PrintTask()
        {
            Console.Clear();
            Console.WriteLine("Вас приветствует программа демонстраии домашнего задания!");
            Console.WriteLine("\nВыберете задание и введите номер задания");
            Console.WriteLine("1: Программа, которая проверяет корректность ввода логина" +
                            "\n2: Класс Message, содержащий статические методы для обработки" +
                            "\n3: Метод, определяющий, является ли одна строка перестановкой другой" +
                            "\n4: Фамилии и имена трёх худших по среднему баллу учеников" +
                            "\n5: Игра - Верю. Не верю");

            Console.WriteLine("Для выхода нажмите - q \n");
        }
    }
}
