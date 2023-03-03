using System.Text;

namespace MyProject
{
    /// <summary>
    /// Содержит методы работы с файлами.
    /// </summary>
    class Operations
    {
        GetNumber getNumber = new GetNumber();
        /// <summary>
        /// Выводит информацию для пользователя.
        /// </summary>
        void Info()
        {
            Console.WriteLine("Путь вводится в зависимости от особенностей вашей операционной системы.");
            Console.WriteLine("Будьте вниметельны с пробелами, например, в начале ввода пути.");
        }
        /// <summary>
        /// Выводит список дисков, предлагает выбрать диск.
        /// </summary>
        public void GetDrives()
        {
            try
            {
                DriveInfo[] allDrives = DriveInfo.GetDrives();
                foreach (DriveInfo d in allDrives)
                {
                    Console.WriteLine("Drive {0}", d.Name);
                }
                Console.WriteLine("Выберите диск. Путь в формате D:/ (так на Windows)");
                string drive = Console.ReadLine();
                if (Directory.Exists(drive))
                    Console.WriteLine("Диск выбран");
                else
                    Console.WriteLine("Такого диска не существует");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Выбор папки.
        /// </summary>
        public void DirectorySelect()
        {
            Info();
            string directory = Console.ReadLine();
            try
            {
                if (Directory.Exists(directory))
                {
                    Console.WriteLine("папка выбрана");
                }
                else
                    Console.WriteLine("Данной папки не существует.");
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Просмотр подпапок.
        /// </summary>
        public void GetDirectories()
        {
            Info();
            string directory = Console.ReadLine();
            try
            {
                if (!Directory.Exists(directory))
                    Console.WriteLine("Выбранной директории не существует");
                else
                {
                    string[] directories = Directory.GetDirectories(directory);
                    foreach (string d in directories)
                        Console.WriteLine(d);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        /// <summary>
        /// Вывод текста из файла в заданной кодировке.
        /// </summary>
        /// <param name="encoding"> Кодировка. </param>
        public void TextOutput(Encoding encoding)
        {
            Info();
            string file = Console.ReadLine();
            try
            {
                string[] text = File.ReadAllLines(file, encoding);
                foreach (string line in text)
                    Console.WriteLine(line);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Выбор кодировки для вывода текста из файла.
        /// </summary>
        public void TextOutputSelectedEncoding()
        {
            Console.WriteLine("Введите номер желаемой кодировки:");
            Console.WriteLine("1.ASCII");
            Console.WriteLine("2.Unicode");
            Console.WriteLine("3.Default");
            getNumber.Number(out int n, 1, 3);
            switch (n)
            {
                case 1: TextOutput(Encoding.ASCII); break;
                case 2: TextOutput(Encoding.Unicode); break;
                case 3: TextOutput(Encoding.Default); break;
            }
        }
        /// <summary>
        /// Копирование файла.
        /// </summary>
        public void CopyFile()
        {
            Info();
            Console.WriteLine("Введите путь к файлу, который хотите скопировать");
            string copiedFile = Console.ReadLine();
            Console.WriteLine("Введите путь к новому файлу");
            string copyTo = Console.ReadLine();
            try
            {
                FileInfo fi1 = new FileInfo(copiedFile);
                fi1.CopyTo(copyTo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Перемещение файла.
        /// </summary>
        public void MoveFile()
        {
            Info();
            Console.WriteLine("Введите путь к файлу, который хотите переместить");
            string copiedFile = Console.ReadLine();
            Console.WriteLine("Введите новый путь к файлу");
            string moveTo = Console.ReadLine();
            try
            {
                FileInfo fi1 = new FileInfo(copiedFile);
                fi1.MoveTo(moveTo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Удаление файла.
        /// </summary>
        public void DeleteFile()
        {
            Info();
            Console.WriteLine("Введите путь к файлу");
            string file = Console.ReadLine();
            try
            {
                if (!File.Exists(file))
                    Console.WriteLine("Такого файла не существует");
                else
                {
                    File.Delete(file);
                    if (!File.Exists(file))
                        Console.WriteLine("Файл удалён успешно");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Создание файла в заданной кодировке.
        /// </summary>
        /// <param name="encoding"> Кодировка. </param>
        public void CreateFile(Encoding encoding)
        {
            Info();
            Console.WriteLine("Введите путь к файлу");
            string file = Console.ReadLine();
            try
            {
                if (File.Exists(file))
                    Console.WriteLine("Этот файл уже существует");
                else
                {
                    File.WriteAllText(file, "", encoding);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Выбор кодировки для создания файла.
        /// </summary>
        public void SelectEncodingForFileCreate()
        {
            Console.WriteLine("Введите номер желаемой кодировки:");
            Console.WriteLine("1.ASCII");
            Console.WriteLine("2.Unicode");
            Console.WriteLine("3.Default");
            getNumber.Number(out int n, 1, 3);
            switch (n)
            {
                case 1: CreateFile(Encoding.ASCII); break;
                case 2: CreateFile(Encoding.Unicode); break;
                case 3: CreateFile(Encoding.Default); break;
            }
        }
        /// <summary>
        /// Конкатинация файлов.
        /// </summary>
        public void Concatination()
        {
            // Получение количества файлов и путей к ним.
            Console.Write("Введите количество файлов для конкатинации: ");
            getNumber.Number(out int n, 1, 50);
            Info();
            string[] fileNames = new string[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write(i + 1 + ":");
                fileNames[i] = Console.ReadLine();
            }
            // Создание/очищение результирующего файла.
            CreateResultFileForConcatination();
            // Конкатенация.
            foreach (string fileName in fileNames)
            {
                try
                {
                    string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);
                    File.AppendAllLines("concatination.txt", lines);
                    OutputConcatination();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            // Вывод результата в консоль.
           
        }
        /// <summary>
        /// Создание результирующего файла либо
        /// удаление и создание для конкатинации.
        /// </summary>
        void CreateResultFileForConcatination()
        {
            string resultFile = "concatination.txt";
            try
            {
                if (!File.Exists(resultFile))
                    File.Create(resultFile).Close();
                else
                {
                    File.Delete(resultFile);
                    File.Create(resultFile).Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Вывод результата конкатинации на консоль.
        /// </summary>
        void OutputConcatination()
        {
            Console.WriteLine();
            try
            {
                string[] lines = File.ReadAllLines("concatination.txt", Encoding.UTF8);
                foreach (string line in lines)
                    Console.WriteLine(line);
                Console.WriteLine("Результат находится в файле concatination.txt в папке net5.0");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
