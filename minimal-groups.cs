var mainGroup = app.MapGroup("api");
var coursesGroup = mainGroup.WithTags("Kurzy")

coursesGroup.MapMethods("courses/{id:int}", // ...