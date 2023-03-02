using System.Xml.Serialization;

[XmlInclude(typeof(Oak))]
[XmlInclude(typeof(Ash))]
public class Tree : IComparable
{
    public int height;
    public int age;
    public Tree() { }
    public Tree(int height, int age)
    {
        this.height = height;
        this.age = age;
    }
    public int CompareTo(object obj)
    {
        Tree tree = obj as Tree;
        return height - tree.height;
    }
}