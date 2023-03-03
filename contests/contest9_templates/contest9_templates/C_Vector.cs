namespace contest9_templates;

public class Vector
{
    private int x;
    private int y;
    public Vector(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    internal object CompareTo(Vector second)
    {
        return this.Length.CompareTo(second.Length);
    }

    public double Length => Math.Sqrt(x * x + y * y);

    public static Vector Parse(string input)
    {
        string[] nums = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (nums.Length != 2 || !int.TryParse(nums[0], out int X) || !int.TryParse(nums[1], out int Y))
            throw new ArgumentException("Incorrect vector");
        else
        {
            return new Vector(X, Y);
        }
    }
}