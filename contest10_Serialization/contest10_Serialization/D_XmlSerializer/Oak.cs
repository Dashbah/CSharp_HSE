public class Oak : Tree
{
    public int acornCount;
    public Oak() : base() { }
    public Oak(int height, int age, int acornCount) : base(height, age)
    {
        this.acornCount = acornCount;
    }
    public override string ToString()
    {
        return $"Oak with height:{height} age:{age} acorn:{acornCount}";
    }
}