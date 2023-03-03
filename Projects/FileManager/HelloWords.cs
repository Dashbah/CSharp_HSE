using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    class HelloWords
    {
        /// <summary>
        /// Слова приветствия.
        /// </summary>
        public void Words()
        {
            string title = "======= Файловый менеджер =======";
            int xPosition = Console.WindowWidth / 2 - title.Length / 2;
            Console.SetCursorPosition(xPosition, 1);
            Console.WriteLine(title);
            Console.WriteLine("Для начала давайте познакомимся. Как Вас зовут?");
            string name = Console.ReadLine();
            Console.WriteLine($"Очень приятно, {name}. Меня зовут Файл Альбертович");
            Console.Write("Показать, что я могу? ;) Для этого нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();
            Console.SetCursorPosition(xPosition, 1);
            Console.WriteLine(title);
            Console.WriteLine("Я могу выполнять следующие команды:");
            Console.WriteLine("1. просмотр списка дисков компьютера и выбор диска");
            Console.WriteLine("2. переход в другую директорию(выбор папки)");
            Console.WriteLine("3. просмотр списка файлов в директории");
            Console.WriteLine("4. вывод содержимого текстового файла в консоль в кодировке UTF-8");
            Console.WriteLine("5. вывод содержимого текстового файла в консоль в выбранной кодировке");
            Console.WriteLine("6. копирование файла");
            Console.WriteLine("7. перемещение файла в выбранную директорию");
            Console.WriteLine("8. удаление файла");
            Console.WriteLine("9. создание простого текстового файла в кодировке UTF-8");
            Console.WriteLine("10.создание простого текстового файла в выбранной кодировке");
            Console.WriteLine("11.конкатенация содержимого двух или более текстовых файлов и вывод");
            Console.WriteLine("результата в консоль в кодировке UTF-8.");
            Console.WriteLine($"{name}, выбирайте менюшку: ");
        }
    }
}
