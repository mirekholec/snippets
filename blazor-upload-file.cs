// obsluha události na <InputFile>
private void LoadFile(InputFileChangeEventArgs arg)
{
    MyModel.BrowserFile = arg.File;
}

// uložení na disk, typicky v Blazor Server
if (MyModel.BrowserFile != null)
{
    string path = WebHostEnvironment.WebRootPath + $"/images/{Id}.jpg";
    await using FileStream fs = new(path, FileMode.Create);
    await MyModel.BrowserFile.OpenReadStream().CopyToAsync(fs);
}

// odeslání na REST API
using var content = new MultipartFormDataContent();
using var httpContent = new StreamContent(file.OpenReadStream());
httpContent.Headers.ContentType = new MediaTypeHeaderValue(browserFile.ContentType);
content.Add(httpContent, "files", file.Name);
var response = await _httpClient.PostAsync("api/files", content);

// REST API endpoint
[HttpPost("/api/files")]
public IActionResult UploadFile([FromForm] IEnumerable<IFormFile> files)
{
    // nebo...
    var allFiles = HttpContext.Request.Form.Files;
}