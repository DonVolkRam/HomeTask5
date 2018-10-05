using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//1. Создать программу, которая будет проверять корректность ввода логина.Корректным
//логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита
//или цифры, при этом цифра не может быть первой:
//а) без использования регулярных выражений;
//б) ** с использованием регулярных выражений.

//Выполнил Волков Кирилл
namespace Ex1
{
    public class ProLogin
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Инициализация базы пользователей");
            try
            {
                Account Users = new Account();
                if (Users.ReadLoginPassword() == false)
                    throw new Exception("Error load file");
                string login;
                string password;
                bool checkL = false;
                bool checkLP = false;
                int tryIndex = 3;
                do
                {
                    if (tryIndex < 3)
                    {
                        Console.Clear();
                        Console.WriteLine("Пара логин и пароль не верна ", tryIndex);
                    }
 
                    do
                    {
                        if (checkL)
                        {
                            Console.Clear();
                            Console.WriteLine("Пароль не может начинаться с цифры и быть больше 10 символов.");
                        }

                        Console.Write("Введите логин ");
                        login = Convert.ToString(Console.ReadLine());
                    }
//                    while (checkL = Account.CheckCorrectLoginRegex(login));
                    while (checkL = Account.CheckCorrectLogin(login));

                    Console.Write("Введите пароль ");
                    password = Convert.ToString(Console.ReadLine());

                    tryIndex--;
                }
                while (!(checkLP = Account.CheckLoginAndPassword(Users, login, password)) && tryIndex > 0);
                if (checkLP)
                    Console.WriteLine("Добро пожаловать!");
                else
                    Console.WriteLine("Доступ запрещен!");
            }
            catch
            {
                Console.WriteLine("Ошибка инициализации");
            }
            finally
            {
                Console.Read();
            }
        }

    }
}
