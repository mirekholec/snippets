// Server.csproj
<PackageReference Include="Grpc.AspNetCore" Version="2.33.1" />

<ItemGroup>
    <Protobuf Include="Protos\greet.proto" GrpcServices="Server" Link="Protos\greet.proto" />
</ItemGroup>

<ItemGroup>
    <Content Update="Protos\*">
        <CopyToOutputDirectory>Always</CopyToOutputDirectory>
    </Content>
</ItemGroup>

// WebApplicationBuilder (builder.Services) 
// podpora pro macOS
WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5000, o => o.Protocols = HttpProtocols.Http2); // gRPC
    options.ListenLocalhost(5003, o => o.Protocols = HttpProtocols.Http1); // protos
});

// WebApplication
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Protos")),
    RequestPath = "/Protos",
    ContentTypeProvider = provider
});

app.UseDirectoryBrowser(new DirectoryBrowserOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Protos")),
    RequestPath = "/Protos"
});

app.MapGrpcService<GreeterService>();

app.MapGet("/", async context =>
{
    context.Response.Redirect("/Protos");
});

app.Map("/{p1?}/{p2?}/{p3?}", async context =>
{
    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
});