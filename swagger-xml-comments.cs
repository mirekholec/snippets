// WebApplicationBuilder (builder.Services)

string XmlFileName(Type type) => type.GetTypeInfo().Module.Name.Replace(".dll", ".xml").Replace(".exe", ".xml");

Services.AddSwaggerGen(x =>
{
    // zahrne XML soubory s dokumentací
    x.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, XmlFileName(typeof(Program))));