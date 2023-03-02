using System.Xml.Serialization;

[XmlInclude(typeof(Lamp))]
[XmlInclude(typeof(Bed))]
[XmlInclude(typeof(Pillow))]
[Serializable]
public abstract class Furniture
{
    public long id { get; set; }
    protected Furniture() { }
    protected Furniture(long id) => this.id = id;
}