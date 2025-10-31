using CoreWCF;
using CoreWCF.Configuration;
using ServiceLibrary;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServiceModelServices();
builder.Services.AddServiceModelMetadata();
var app = builder.Build();

app.UseServiceModel(serviceBuilder =>
{
    serviceBuilder.AddService<HelloService>();
    serviceBuilder.AddServiceEndpoint<HelloService, IHelloService>(new BasicHttpBinding(), "/HelloService.svc");
});

var serviceMetadataBehavior = app.Services.GetRequiredService<CoreWCF.Description.ServiceMetadataBehavior>();
serviceMetadataBehavior.HttpGetEnabled = true;

app.Run();
