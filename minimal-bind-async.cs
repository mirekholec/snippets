// kompletní binding objektu (nesmí se použít s parametrem)

public class PagingFilter
{
    public int? Take { get; set; }
    public int? Skip { get; set; }

    public static ValueTask<CourseFilter> BindAsync(HttpContext context, ParameterInfo param)
    {
        CourseFilter filter = new() {Take = 10, Skip = 0};

        if (context.Request.Query.TryGetValue("take", out var take) &&
            int.TryParse(take, out int takeInt)) {
            filter.Take = takeInt;
        };

        if (context.Request.Query.TryGetValue("skip", out var skip) &&
            int.TryParse(skip, out int skipInt)) {
            filter.Skip = skipInt;
        };

        return ValueTask.FromResult(filter);
    }
}