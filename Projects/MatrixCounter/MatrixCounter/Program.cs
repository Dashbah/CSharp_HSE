namespace MyProject
{
    class Program
    {
        /// <summary>
        /// Получение введенного целого числа и проверка его на корректность.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="min">минимальное допустимое значение</param>
        /// <param name="max">максимальное</param>
        static void GetNumber(out int n, int min, int max)
        {
            n = -1;
            bool flag = true;
            while (flag)
            {
                if (!int.TryParse(Console.ReadLine(), out int n1) || n1 < min || n1 > max)
                    Console.WriteLine("Некорректное значение");
                else
                {
                    n = n1;
                    flag = false;
                }
            }
        }
        /// <summary>
        /// Получение введенного числа  типа double и проверка его на корректность.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="min">минимальное допустимое значение</param>
        /// <param name="max">максимальное</param>
        public static void GetNumber(out double n, int min, int max)
        {
            n = -1;
            bool flag = true;
            while (flag)
            {
                if (!Double.TryParse(Console.ReadLine(), out double n1) || n1 < min || n1 > max)
                    Console.WriteLine("Некорректное значение");
                else
                {
                    n = n1;
                    flag = false;
                }
            }
        }
        /// <summary>
        /// получение размеров матриц.
        /// </summary>
        /// <param name="m_1">количество строк первой матрицы</param>
        /// <param name="n_1">количество столбцов первой матрицы</param>
        /// <param name="m_2">количество строк второй матрицы</param>
        /// <param name="n_2">количество столбцов второй матрицы</param>
        static void GetSize(out int m_1, out int n_1, out int m_2, out int n_2)
        {
            Console.WriteLine("Сейчас Вам будет предложено ввести размерности матриц. Число должно быть целым положительным.");
            Console.WriteLine("Данные для первой матрицы:");
            Console.Write("количество строк: ");
            GetNumber(out int m1, 0, 100);
            bool flag = true;
            Console.Write("количество столбцов: ");
            GetNumber(out int n1, 0, 100);
            flag = true;
            Console.WriteLine("Данные для второй матрицы:");
            Console.Write("количество строк: ");
            GetNumber(out int m2, 0, 100);
            Console.Write("количество столбцов: ");
            GetNumber(out int n2, 0, 100);
            m_1 = m1;
            n_1 = n1;
            m_2 = m2;
            n_2 = n2;
        }
        /// <summary>
        /// получение номера операции.
        /// </summary>
        /// <param name="operation">номер операции</param>
        static void GetNumberOfOperation(out int operation)
        {
            Console.WriteLine("Доступны следующие операции:");
            Console.WriteLine("1.нахождение следа матрицы;");
            Console.WriteLine("2.транспонирование матрицы;");
            Console.WriteLine("3.сумма двух матриц;");
            Console.WriteLine("4.разность двух матриц;");
            Console.WriteLine("5.произведение двух матриц;");
            Console.WriteLine("6.умножение матрицы на число;");
            Console.WriteLine("7.нахождение определителя матрицы.");
            Console.Write("Введите номер операции: ");
            GetNumber(out int operation1, 1, 7);
            operation = operation1;
        }
        /// <summary>
        /// выбор варианта заполнения массива. 1- рандомно, 2- пользователем.
        /// </summary>
        /// <param name="option">номер варианта заполнения</param>
        static void GetInputOption(out int option)
        {
            Console.WriteLine("Если хотите, чтобы матрицы сгенерировались случайным образом, введите 1");
            Console.WriteLine("Если хотите задать элементы сами, введите 2");
            GetNumber(out int option1, 1, 2);
            option = option1;
        }
        /// <summary>
        /// заполнение массива, вывод на консоль.
        /// </summary>
        /// <param name="m">количество строк</param>
        /// <param name="n">количество столбцов</param>
        /// <param name="input_option">вариант ввода</param>
        /// <returns></returns>
        static double[,] GetArray(int m, int n, int input_option)
        {
            double[,] arr = new double[m, n];
            //случайное заполнение.
            if (input_option == 1)
            {
                Random rnd = new Random();
                for (int i = 0; i < m; i++)
                    for (int j = 0; j < n; j++)
                        arr[i, j] = rnd.Next(-100, 101);
            }
            //ввод пользователем.
            else
            {
                Console.WriteLine("Каждое значение вводится в новую строку. Значения double (c плавающей точкой) от -1000 до 1000");
                for (int i = 0; i < m; i++)
                {
                    Console.WriteLine(i + " строка:");
                    for (int j = 0; j < n; j++)
                    {
                        GetNumber(out double a1, -1000, 1000);
                        arr[i, j] = a1;
                    }
                }
            }
            return arr;
        }
        /// <summary>
        /// вывод массива на консоль.
        /// </summary>
        /// <param name="arr">массив</param>
        /// <param name="m">количество строк</param>
        /// <param name="n">количество столбцов</param>
        public static void Print(double[,] arr, int m, int n)
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        /// <summary>
        /// выполняет выбранную операцию.
        /// </summary>
        /// <param name="arr1">1 матрица</param>
        /// <param name="m1">количество строк первой матрицы</param>
        /// <param name="n1">количество столбцов первой матрицы</param>
        /// <param name="arr2">вторая матрица</param>
        /// <param name="m2">количество строк второй матрицы</param>
        /// <param name="n2">количество столбцов второй матрицы</param>
        /// <param name="operation">номер выбранной операции</param>
        static void DoTheOperation(double[,] arr1, int m1, int n1, double[,] arr2, int m2, int n2, int operation)
        {
            //класс с операциями.
            Operation Op = new Operation();
            switch (operation)
            {
                case 1:
                    {
                        Op.TheFirst(arr1, m1, n1, arr2, m2, n2);
                        break;
                    }
                case 2:
                    {
                        Op.TheSecond(arr1, m1, n1, arr2, m2, n2);
                        break;
                    }
                case 3:
                    {
                        Op.TheThird(arr1, m1, n1, arr2, m2, n2);
                        break;
                    }
                case 4:
                    {
                        Op.TheFourth(arr1, m1, n1, arr2, m2, n2);
                        break;
                    }
                case 5:
                    {
                        Op.TheFifth(arr1, m1, n1, arr2, m2, n2);
                        break;
                    }
                case 6:
                    {
                        Op.TheSixth(arr1, m1, n1, arr2, m2, n2);
                        break;
                    }
                case 7:
                    {
                        Op.TheSeventh(arr1, m1, n1, arr2, m2, n2);
                        break;
                    }
            }
        }
        /// <summary>
        /// точка входа.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            bool repeat = true;
            while (repeat)
            {          
                Console.Clear();
                Console.WriteLine("Вас приветствует калькулятор матриц!");
                //получение номера оперции.
                GetNumberOfOperation(out int operation);
                Console.Clear();
                //получение размеров матриц.
                GetSize(out int m1, out int n1, out int m2, out int n2);
                //выбор варианта ввода.
                GetInputOption(out int input_option);
                //создание и инициализация массивов.
                double[,] arr1 = GetArray(m1, n1, input_option);
                double[,] arr2 = GetArray(m2, n2, input_option);
                //очищение консоли и вывод матриц.
                Console.Clear();
                Console.WriteLine("1 матрица:");
                Print(arr1, m1, n1);
                Console.WriteLine("2 матрица:");
                Print(arr2, m2, n2);
                //выполнение операции.
                DoTheOperation(arr1, m1, n1, arr2, m2, n2, operation);
                //повтор решения.
                Console.WriteLine("Для повтора нажмите пробел, для выхода любую другую клавишу");
                var a = Console.ReadKey();
                repeat = (a.Key == ConsoleKey.Spacebar);
            }
        }
    }
}
