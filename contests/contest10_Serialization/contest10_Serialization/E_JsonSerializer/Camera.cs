using System.Runtime.Serialization;

[DataContract]
internal class Camera
{
    [DataMember]
    public List<Penalty> penalties = new List<Penalty>();
    [DataMember]
    public int id;
    public int maxSpeed;
    public Camera() { }
    public Camera(int id, int maxSpeed)
    {
        (this.id, this.maxSpeed) = (id, maxSpeed);
    }
}