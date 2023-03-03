namespace contest1;

public class AEcho
{
    public static void Run()
    {
        string line = Console.ReadLine();
        for(int i=0; i<3; i++)
            Console.WriteLine(line);
    }
}