using System.Xml.Serialization;

[Serializable]
public class Bed : Furniture
{
    [XmlElement]
    public List<Pillow> pillow { get; set; }
    public Bed() : base() { }
    public Bed(long id, List<Pillow> pillows) : base(id) 
    {
        this.pillow = pillows;
    }
}