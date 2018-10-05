using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace Ex1
{
    /// <summary>
    /// Структура содержащая в себе имя и пароли пользователей
    /// </summary>
    struct Account
    {
        private string[] Login;
        private string[] Password;
        public int NumOfUsers { get; set; }

        /*        
                public Account()
                {
                    ReadLoginPassword();           
                }
        */
        /// <summary>
        /// Метод считываеющий данные из файла и записывающий их в экземпляр
        /// </summary>
        /// <returns>Возарщает истину если считывание прошло успешно</returns>
        public bool ReadLoginPassword()
        {
            string filename = "..\\..\\Ex1_Users.txt";
            string[] allFile;
            string[] temp;
            if (File.Exists(filename))
            {
                //Считываем все строки в файл
                allFile = File.ReadAllLines(filename);
                NumOfUsers = allFile.Length;
                Login = new string[NumOfUsers];
                Password = new string[NumOfUsers];
                for (int i = 0; i < NumOfUsers; i++)
                {
                    temp = allFile[i].Split(';');
                    if (temp.Length > 2)
                    {
                        Console.WriteLine("Ошибка чтения данных");
                        continue;
                    }
                    Login[i] = temp[0];
                    Password[i] = temp[1];
                }
                return true;
            }
            else
            {
                Login = null;
                Password = null;
                Console.WriteLine("Файл не найден");
                return false;
            }

        }

        /// <summary>
        /// Метод проверки вводимого логина и пароля с логином и паролем из экземпляра 
        /// </summary>
        /// <param name="Users">Экземпляр</param>
        /// <param name="inputLogin">Проверяемый логин</param>
        /// <param name="inputPassword">Проверяемый пароль</param>
        /// <returns>Возвращаент истину если найдено совпадение пары логин и пароль в экземпляре</returns>
        public static bool CheckLoginAndPassword(Account Users, string inputLogin, string inputPassword)
        {
            for (int i = 0; i < Users.NumOfUsers; i++)
            {
                if (inputLogin == Users.Login[i] && inputPassword == Users.Password[i])
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Метод проверки проверки корректности вводимого пароля с помощье регулярных выражений
        /// </summary>
        /// <param name="inputLogin">Вводимый пароль</param>
        /// <returns></returns>
        public static bool CheckCorrectLoginRegex(string inputLogin)
        {
            if (inputLogin.Length > 10)
                return true;
            var pat = @"\b([^a-z,A-Z]{1}[a-z,0-9,A-Z]{1,9})\b";
            Regex reg = new Regex(pat);
            if (reg.IsMatch(inputLogin))
                return true;
            return false;
        }

        /// <summary>
        /// Метод проверки проверки корректности вводимого пароля
        /// </summary>
        /// <param name="inputLogin">Вводимый пароль</param>
        /// <returns></returns>
        public static bool CheckCorrectLogin(string inputLogin)
        {
            if (inputLogin.Length > 10)
                return true;

            int temp = Convert.ToInt32(inputLogin.First())-48;
            for (int i = 0; i < 10; i++)               
                if (temp == i)
                    return true;

            return false;
        }

    }
}
