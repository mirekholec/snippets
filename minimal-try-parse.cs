// binduje jeden parametr na instanci třídy

return api.MapGet("/courses", async ([FromHeader(Name = "Authorization")]AuthKey auth) =>

public class AuthKey
{
    public string Key { get; set; }

    public static bool TryParse(string? value, out AuthKey result)
    {
        result = new AuthKey() {Key = (value + string.Empty).Replace("Bearer ", string.Empty)};
        return true;
    }
}