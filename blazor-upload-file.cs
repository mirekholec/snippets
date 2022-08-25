if (_model.BrowserFile != null)
{
    string path = WebHostEnvironment.WebRootPath + $"/images/{Id}.jpg";
    await using FileStream fs = new(path, FileMode.Create);
    await _model.BrowserFile.OpenReadStream().CopyToAsync(fs);
}