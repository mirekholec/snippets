public class Blog
{
    private string _validatedUrl;

    [BackingField(nameof(_validatedUrl))]
    public string Url
    {
        get { return _validatedUrl; }
    }

    public void SetUrl(string url)
    {
        // validační kód
        _validatedUrl = url;
    }
}