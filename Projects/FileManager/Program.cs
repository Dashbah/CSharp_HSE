using System;

namespace MyProject
{
    class Program
    {
        /// <summary>
        /// Точка входа.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            bool repeat = true;
            while (repeat)
            {
                Console.Clear();
                HelloWords hello = new HelloWords();
                GetNumber get = new GetNumber();
                Operations operation = new Operations();
                hello.Words();
                get.Number(out int n, 1, 11);
                switch (n)
                {
                    case 1: operation.GetDrives(); break;
                    case 2: operation.DirectorySelect(); break;
                    case 3: operation.GetDirectories(); break;
                    case 4: operation.TextOutput(System.Text.Encoding.UTF8); break;
                    case 5: operation.TextOutputSelectedEncoding(); break;
                    case 6: operation.CopyFile(); break;
                    case 7: operation.MoveFile(); break;
                    case 8: operation.DeleteFile(); break;
                    case 9: operation.CreateFile(System.Text.Encoding.UTF8); break;
                    case 10: operation.SelectEncodingForFileCreate(); break;
                    case 11: operation.Concatination(); break;
                }
                Console.WriteLine("Для повтора нажмите любую клавишу. Для выхода нажмите Escape");
                repeat = ! (Console.ReadKey().Key == ConsoleKey.Escape);
            }
        }
    }
}
