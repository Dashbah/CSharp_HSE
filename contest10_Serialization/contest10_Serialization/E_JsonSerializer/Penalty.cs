using System.Runtime.Serialization;

[DataContract]
internal class Penalty
{
    [DataMember]
    public int car_number;
    [DataMember]
    public int cost;
    public Penalty() { }
    public Penalty(int carNumber, int cost)
    {
        (this.car_number, this.cost) = (carNumber, cost);
    }
}