services.AddHttpClient<IApiService, ApiService>(client =>
{
    client.BaseAddress = new Uri("https://www.miroslavholec.cz");
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
}).SetHandlerLifetime(TimeSpan.FromMinutes(2));



public class ApiService : IApiService
{
    private readonly HttpClient httpClient;

    public ApiService(HttpClient httpClient...)
    {
        this.httpClient = httpClient;
    }

    public async Task<List<Article>> GetArticles()
    {
        HttpResponseMessage response = await httpClient.GetAsync("/api/articles");
        string json = await response.Content.ReadAsStringAsync();
        ...
    }
}