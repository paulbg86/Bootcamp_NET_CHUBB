using CoreWCF;

namespace ServiceLibrary;

[ServiceContract]
public interface IHelloService
{
    [OperationContract]
    string SayHello(string name);
}
