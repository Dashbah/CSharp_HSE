using System;

namespace PeerGrade
{
    class Program
    {
        /// <summary>
        /// Метод генерирует массив, создает из него число.
        /// </summary>
        /// <returns> возвращает строковое представление числа.</returns>
        public static int Number()
        {
            int[] number = new int[4];
            Random rnd = new Random();
            number[0] =  rnd.Next(1, 9);
            for (int i = 0; i < 3; ++i)
            {
                bool exists = false;
                do
                {
                    number[i] = rnd.Next(9);
                    for (int j = 0; j < i; ++j)
                    {
                        if (number[i] == number[j])
                        {
                            exists = true;
                            break;
                        }
                    }
                } while (exists);
            }
            Console.Write(number[0] * 1000 + number[1] * 100 + number[2] * 10 + number[3]);
            return number[0] * 1000 + number[1] * 100 + number[2] * 10 + number[3];
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
        
        static void Main(string[] args)
        {
            Console.WriteLine("Быки - количество угаданных и находящихся на своих местах цифр.");
            Console.WriteLine("Коровы - количество угаданных, но не расположенных на своих местах.");
            Console.WriteLine();
            bool repeat = true;
            while (repeat)
            {
                Console.WriteLine("Введите четырехзначное число, цифры не должны повторяться:");
                string value = Number().ToString();
                string entering;
                do
                {
                    entering = Console.ReadLine();
                    if (!int.TryParse(entering, out int a) || entering.Length != 4)
                        Console.WriteLine("некорректные данные, введите четырехзначное число");
                    else
                        Check(entering, value);
                    Console.WriteLine();
                } while (value != entering);
                
                Console.WriteLine("Поздравляю, Вы угадали!");
                Console.WriteLine("Чтобы начать заново, нажмите пробел. Для выхода нажмите любую другую клавишу.");
                repeat = Console.ReadKey().Key == ConsoleKey.Spacebar;
            }
        }
    }
}