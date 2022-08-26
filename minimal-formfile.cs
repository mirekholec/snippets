app.MapPost("/upload", async(IFormFile file) =>
{
    using var stream = System.IO.File.OpenWrite("upload.txt");
    await file.CopyToAsync(stream); 
});

app.MapPost("/upload", async (IFormFileCollection myFiles) => 
{

});