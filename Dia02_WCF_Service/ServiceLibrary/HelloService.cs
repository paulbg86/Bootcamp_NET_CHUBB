namespace ServiceLibrary;

public class HelloService : IHelloService
{
    public string SayHello(string name) => $"Hola {name}, desde CoreWCF en .NET 8";
}
