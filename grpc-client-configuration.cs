// WebApplicationBuilder (builder.Services)
Services.AddGrpcClient<Greeter.GreeterClient>(x =>
{
    x.Address = new Uri("http://localhost:5000");
})
.ConfigureChannel(options =>
{
    options.MaxReceiveMessageSize = 1 * 1024 * 1024;
    options.MaxSendMessageSize = 1 * 1024 * 1024;
});