using System;

namespace PeerGrade
{
    class Program
    {
        /// <summary>
        /// Метод генерирует массив, создает из него число.
        /// </summary>
        /// <returns> возвращает строковое представление числа.</returns>
        public static string Number()
        {
            //По умолчанию массив заполняется нулями. Тогда при генерации все нули будут удаляться как повторяющиеся.
            //Поэтому его нужно заполнить.
            int[] number = new int[4] { 10, 10, 10, 10 };
            Random rnd = new Random();
            int rpt;
            // l- вспомогательная переменная. Генерация цифры идет, пока l=1. Если цифра уже была в числе, 
            // т.е. rpt>0, то l остается равной 1. Если же цифра новая, то l=0, переходим к новой цифре.
            int l;
            for (int i = 0; i < 4; i++)
            {
                l = 1;
                while (l == 1)
                {
                    if (i == 0)
                        number[i] = rnd.Next(1, 9);
                    else
                        number[i] = rnd.Next(9);
                    rpt = 0;
                    for (int j = 0; j < 4; j++)
                        if (number[i] == number[j] && i != j)
                            rpt++;
                    if (rpt == 0)
                        l = 0;
                }
            }
            int result = number[0] * 1000 + number[1] * 100 + number[2] * 10 + number[3];
            //Перевод в строковый тип, так как Check будет сравнивать строки.
            string result1 = result.ToString();
            return result1;
        }

        /// <summary>
        /// Вычисляет количество коров и быков.
        /// </summary>
        /// <param name="number">Введенное пользователем число.</param>
        /// <param name="value">Загаданное число.</param>
        public static void Check(string number, string value)
        {
            int a = 0, b = 0;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    //Вычисляем полностью угаданные (а).
                    if (number[i] == value[j] && i == j)
                        a++;
                    //Угаданные, но не на своих местах (b).
                    if (number[i] == value[j] && i != j)
                        b++;
                }
            Console.WriteLine("быки: " + a);
            Console.WriteLine("коровы: " + b);
        }

        /// <summary>
        /// Точка входа.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Быки - количество угаданных и находящихся на своих местах цифр.");
            Console.WriteLine("Коровы - количество угаданных, но не расположенных на своих местах.");
            Console.WriteLine();
            //repeat отвечает за то, чтобы пользователь мог перезапустить игру.
            bool repeat = true;
            while (repeat)
            {
                Console.WriteLine("Введите четырехзначное число, цифры не должны повторяться:");
                //Генерация числа.
                string value = Number();
                //Введенное пользователем число.
                string entering = "0";
                //Цикл выполнется, пока число не будет угадано.
                while (value != entering)
                {
                    entering = Console.ReadLine();
                    if (!int.TryParse(entering, out int a) || entering.Length != 4)
                        Console.WriteLine("некорректные данные, введите четырехзначное число");
                    else
                        Check(entering, value);
                    Console.WriteLine();
                }
                Console.WriteLine("Поздравляю, Вы угадали!");
                Console.WriteLine("Чтобы начать заново, нажмите пробел. Для выхода нажмите любую другую клавишу.");
                if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                {
                    repeat = true;
                    Console.WriteLine();
                }
                else
                    repeat = false;
            }
        }
    }
}