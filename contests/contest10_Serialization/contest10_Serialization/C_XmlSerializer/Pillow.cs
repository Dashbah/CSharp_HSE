public class Pillow : Furniture
{
    public string isRuined { get; set; }
    public Pillow() { }
    public Pillow(long id, bool isRuined)
    {
        this.isRuined = isRuined ? "Yes" : "No";
        this.id = id;
    }
}