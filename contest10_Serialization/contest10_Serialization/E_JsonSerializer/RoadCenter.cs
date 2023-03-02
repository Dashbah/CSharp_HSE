using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

[DataContract]
internal class RoadCenter : ITrackingCenter
{
    [DataMember]
    public List<Camera> cameras = new List<Camera>();
    
    public void AddCamera(int id, int maxSpeed)
    {
        cameras.Add(new Camera(id, maxSpeed));
    }

    public void CheckCarSpeed(int cameraId, int carNumber, int carSpeed)
    {
        foreach (var camera in cameras)
        {
            if (camera.id == cameraId)
            {
                if (carSpeed - camera.maxSpeed >= 1)
                    camera.penalties.Add(new Penalty(carNumber,
                        (carSpeed - camera.maxSpeed) * 100));
                break;
            }
        }
    }

    public void GetData(string inFilePath)
    {
        FileStream fs = new FileStream(inFilePath, FileMode.OpenOrCreate);
        DataContractJsonSerializer formater =
            new DataContractJsonSerializer(typeof(RoadCenter));
        formater.WriteObject(fs, this);
        fs.Close();
    }
}