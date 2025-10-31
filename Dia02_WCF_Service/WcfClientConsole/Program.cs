using System.ServiceModel;

[ServiceContract]
public interface IHelloService
{
    [OperationContract]
    string SayHello(string name);
}

class Program
{
    static void Main()
    {
        var address = new EndpointAddress("http://localhost:5000/HelloService.svc");
        var binding = new BasicHttpBinding();
        var channelFactory = new ChannelFactory<IHelloService>(binding, address);
        var client = channelFactory.CreateChannel();
        var result = client.SayHello("Paul");
        Console.WriteLine(result);
        ((IClientChannel)client).Close();
        channelFactory.Close();
    }
}
