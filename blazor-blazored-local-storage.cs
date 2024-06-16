// Project.csproj
<PackageReference Include="Blazored.SessionStorage" Version="2.4.0"/>

// Program.cs
builder.Services.AddBlazoredSessionStorage();

public partial class Calc : ComponentBase
{
    [SupplyParameterFromForm] protected Form Form { get; set; } = new();
    [Inject] private ISyncSessionStorageService BrowserStorage { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            if (BrowserStorage.ContainKey("Data"))
            {
                Form.Tokens = BrowserStorage.GetItem<int>("Data");
                StateHasChanged();
            }
        }
    }

    private void OnFieldChanged(object sender, FieldChangedEventArgs e)
    {
        BrowserStorage.SetItem("Data", Form.Tokens);
    }
}