/*Console.WriteLine("Доступны следующие операции:");
Console.WriteLine("1.нахождение следа матрицы;");
Console.WriteLine("2.транспонирование матрицы;");
Console.WriteLine("3.сумма двух матриц;");
Console.WriteLine("4.разность двух матриц;");
Console.WriteLine("5.произведение двух матриц;");
Console.WriteLine("6.умножение матрицы на число;");
Console.WriteLine("7.нахождение определителя матрицы.");*/

namespace MyProject
{
    class Operation
    {
        public void TheFirst(double[,] arr1, int m1, int n1, double[,] arr2, int m2, int n2)
        {
            Console.WriteLine("1.нахождение следа матрицы:");
            if (m1 == n1)
            {
                double s = 0;
                for (int i = 0; i < m1; i++)
                    for (int j = 0; j < n1; j++)
                        if (i == j)
                            s += arr1[i, j];
                Console.WriteLine("След матрицы 1 = " + s);
            }
            else
                Console.WriteLine("Матрица 1 не является квадратной. Вычислить след нельзя.");

            if (m2 == n2)
            {
                double s = 0;
                for (int i = 0; i < m2; i++)
                    for (int j = 0; j < n2; j++)
                        if (i == j)
                            s += arr2[i, j];
                Console.WriteLine("След матрицы 2 = " + s);
            }
            else
                Console.WriteLine("Матрица 2 не является квадратной. Вычислить след нельзя.");
        }
        public void TheSecond(double[,] arr1, int m1, int n1, double[,] arr2, int m2, int n2)
        {
            Console.WriteLine("2.транспонирование матрицы:");
            double[,] arr11 = new double[n1, m1];
            double[,] arr21 = new double[n2, m2];
            for (int i = 0; i < m1; i++)
                for (int j = 0; j < n1; j++)
                    arr11[j, i] = arr1[i, j];
            for (int i = 0; i < m2; i++)
                for (int j = 0; j < n2; j++)
                    arr21[j, i] = arr2[i, j];
            Console.WriteLine("1 матрица:");
            Program.Print(arr11, n1, m1);
            Console.WriteLine("2 матрица:");
            Program.Print(arr21, n2, m2);
        }
        public void TheThird(double[,] arr1, int m1, int n1, double[,] arr2, int m2, int n2)
        {
            Console.WriteLine("3.сумма двух матриц:");
            if (m1 == m2 && n1 == n2)
            {
                double[,] arr = new double[m1, n1];
                for (int i = 0; i < m1; i++)
                    for (int j = 0; j < n1; j++)
                        arr[i, j] = arr1[i, j] + arr2[i, j];
                Program.Print(arr, m1, n1);
            }
            else
                Console.WriteLine("Матрицы разной размерности. Сложение запрещено.");
        }
        public void TheFourth(double[,] arr1, int m1, int n1, double[,] arr2, int m2, int n2)
        {
            Console.WriteLine("4.разность двух матриц:");
            if (m1 == m2 && n1 == n2)
            {
                double[,] arr = new double[m1, n1];
                for (int i = 0; i < m1; i++)
                    for (int j = 0; j < n1; j++)
                        arr[i, j] = arr1[i, j] - arr2[i, j];
                Program.Print(arr, m1, n1);
            }
            else
                Console.WriteLine("Матрицы разной размерности. Вычитание запрещено.");
        }
        public void TheFifth(double[,] arr1, int m1, int n1, double[,] arr2, int m2, int n2)
        {
            Console.WriteLine("5.произведение двух матриц:");
            if (n1 == m2)
            {
                double[,] arr = new double[m1, n2];
                for (int i = 0; i < m1; i++)
                {
                    for (int k = 0; k < n2; k++)
                    {
                        double summ = 0;
                        for (int j = 0; j < m2; j++)
                            summ += arr1[i, j] * arr2[j, k];
                        arr[i, k] = summ;
                    }
                }
                Program.Print(arr, m1, n2);
            }
            else
            {
                Console.WriteLine("Размеры матриц не подходят для умножения.");
                Console.WriteLine("Количество столбцов первой должно быть равно количеству строк второй.");
            }
        }
        public void TheSixth(double[,] arr1, int m1, int n1, double[,] arr2, int m2, int n2)
        {
            Console.WriteLine("6.умножение матрицы на число:");
            Console.WriteLine("На что будем умножать?");
            Program.GetNumber(out double a, -1000, 1000);
            for (int i = 0; i < m1; i++)
                for (int j = 0; j < n1; j++)
                    arr1[i, j] *= a;
            for (int i = 0; i < m2; i++)
                for (int j = 0; j < n2; j++)
                    arr2[i, j] *= a;
            Console.WriteLine("1 матрица:");
            Program.Print(arr1, m1, n1);
            Console.WriteLine("2 матрица:");
            Program.Print(arr2, m2, n2);
        }
        /// <summary>
        /// вычисление определителя матрицы.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="m"></param>
        /// <param name="n"></param>
        void Determinator(double[,] arr, int m, int n)
        {
            if (n == m)
            {
                double det=0;
                switch (m)
                {
                    case 1:
                        {
                            det = arr[0, 0];
                            break;
                        }
                    case 2:
                        {
                            det = arr[0, 0] + arr[1, 1] - arr[0, 1] - arr[1, 0];
                            break;
                        }
                    case 3:
                        {
                            double det1 = arr[0, 0] * arr[1, 1] * arr[2, 2] + arr[0, 1] * arr[1, 2] * arr[2, 0] + arr[0, 2] * arr[1, 0] * arr[2, 1];
                            double det2 = arr[0, 0] * arr[1, 2] * arr[2, 1] + arr[0, 1] * arr[1, 0] * arr[2, 2] + arr[0, 2] * arr[1, 1] * arr[2, 0];
                            det = det1 - det2;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Вычисление определителя пока доступно только для матриц 1,2,3 порядка :(");
                            Console.WriteLine("Сори, я не волшебник, а только учусь");
                            return;
                        }
                }
                Console.WriteLine("Определитель равен " + det);
            }
            else
                Console.WriteLine("Для нахождения определителя матрица должна быть квадратной.");
        }
        public void TheSeventh(double[,] arr1, int m1, int n1, double[,] arr2, int m2, int n2)
        {
            Console.WriteLine("7. Нахождение определителя матрицы");
            Console.WriteLine("1 матрица:");
            Determinator(arr1, m1, n1);
            Console.WriteLine("2 матрица:");
            Determinator(arr2, m2, n2);
        }
    }
}
