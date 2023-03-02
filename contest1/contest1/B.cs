namespace contest1;

public class B
{
    public static void Run()
    {     
        string s1 = Console.ReadLine();
        string s2 = Console.ReadLine();
        if (!int.TryParse(s1, out int a) || !int.TryParse(s2, out int b))
        {
            Console.WriteLine("Incorrect input");
            return;
        }
        Console.WriteLine(a - b);
    }
}