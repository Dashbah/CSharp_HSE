[Serializable]
public class Ash : Tree
{
    public int leafCount;
    public Ash() : base() { }
    public Ash(int height, int age, int leafCount) : base(height, age) 
    {
        this.leafCount = leafCount;
    }
    
    public override string ToString()
    {
        return $"Ash with height:{height} age:{age} leaf:{leafCount}";
    }
}