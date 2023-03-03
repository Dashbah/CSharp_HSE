using System.Xml.Serialization;

internal class SimpleFurnitureSerializer
{
    public void Serialize(List<Furniture> furniture, string outputPath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Furniture>));
        FileStream fs = new FileStream(outputPath, FileMode.OpenOrCreate);
        serializer.Serialize(fs, furniture);
    }
}