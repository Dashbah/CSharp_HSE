using System;

[Serializable]
public class Lamp : Furniture
{ 
    public int lifeTime { get; set; }
    public Lamp() : base() { }
    public Lamp(long id, TimeSpan lifeTime) : base(id)
    {
        this.lifeTime = (int)lifeTime.TotalSeconds;
    }
}