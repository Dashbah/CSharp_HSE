using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    class GetNumber
    {
        /// <summary>
        /// Получение целого числа и проверка его на корректность.
        /// </summary>
        /// <param name="n">результат-целое число</param>
        /// <param name="min">минимальное возможное значение</param>
        /// <param name="max">максимальное</param>
        public void Number(out int n, int min, int max)
        {
            n = -1;
            bool flag = true;
            while (flag)
            {
                if (!int.TryParse(Console.ReadLine(), out int n1) || n1 < min || n1 > max)
                    Console.WriteLine($"Некорректное значение. Пожалуйста, введите число от {min} до {max}");
                else
                {
                    n = n1;
                    flag = false;
                }
            }
        }
    }
}
