// Projekt.csproj
<PackageReference Include="Refit.HttpClientFactory" Version="6.1.15" />

// WebApplicationBuilder (builder.Services)
Services.AddRefitClient<IRefitHolecApiService>().ConfigureHttpClient(
    http =>{})
    .AddHeaderPropagation()
    .AddPolicyHandler(_ => Policies.GetRetryPolicy())
    .AddHttpMessageHandler<AuditDelegatingHandler>();;

// IHolecApiService.cs
public interface IHolecApiService
{
    [Get("/articles")]
    Task<CollectionResult<Article>> GetArticles([AliasAs("take")]int take = 10);

    [Get("/articles/{id}")]
    Task<CollectionResult<Article>> GetArticleById([AliasAs("id")]int articleId);

    [Post("/articles")]
    Task<Article> CreateArticle([Body]ArticleCreate model);

    [Get("/users")]
    IObservable<HttpResponseMessage> GetUsers();

    [Get("/users/{user}")]
    Task<ApiResponse<User>> GetUsers(string user);
}