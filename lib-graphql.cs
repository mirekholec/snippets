// Projekt.csproj
<PackageReference Include="GraphQL.Server.Transports.AspNetCore" Version="3.4.0" />
<PackageReference Include="GraphQL.Server.Ui.Playground" Version="3.4.0" />

// WebApplicationBuilder (builder.Services)
Services.AddScoped<IDependencyResolver>(x => new FuncDependencyResolver(x.GetRequiredService));
Services.AddScoped<CourseSchema>();
Services.AddGraphQL(x => { x.ExposeExceptions = true; }).AddGraphTypes(ServiceLifetime.Scoped);
Services.Configure<KestrelServerOptions>(x => x.AllowSynchronousIO = true); // graphql issue workaround

// WebApplication
app.UseGraphQL<CourseSchema>();
app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

// Courses
public class CourseType : ObjectGraphType<CourseModel>
{
    public CourseType()
    {
        Field(x => x.Id);
        Field(x => x.Title);
        //Field(x => x.Date); -> nechci ho v modelu
        Field(x => x.Price);
        Field(x => x.Attendees);
    }
}

public class CourseQuery : ObjectGraphType
{
    public CourseQuery(UnitOfWork uow, IMapper mapper)
    {
        Field<ListGraphType<CourseType>>("courses",
            arguments: new QueryArguments(new QueryArgument<StringGraphType> {Name = "orderBy"}),
            resolve: x =>
            {
                string sort = x.GetArgument<string>("orderBy");

                var data = uow.Courses.AsQueryable();
                if (!string.IsNullOrEmpty(sort))
                {
                    if (sort == "title" || sort == "title:asc")
                    {
                        data = data.OrderBy(x => x.Title);
                    }
                    if (sort == "title:desc")
                    {
                        data = data.OrderByDescending(x => x.Title);
                    }
                }
                
                return mapper.ProjectTo<CourseModel>(data);
            });
    }
}

public class CourseSchema : Schema
{
    public CourseSchema(IDependencyResolver resolver) : base(resolver)
    {
        Query = resolver.Resolve<CourseQuery>();
    }
}