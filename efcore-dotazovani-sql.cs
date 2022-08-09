// SQL RAW
var blogs = context.Blogs.FromSqlRaw("SELECT * FROM dbo.Blogs").ToList();

// SQL PROC
var blogs = context.Blogs.FromSqlRaw("EXECUTE dbo.GetMostPopularBlogs").ToList();

// SQL PROC + PARAM
var user = "johndoe";
var blogs = context.Blogs.FromSqlRaw("EXECUTE dbo.GetMostPopularBlogsForUser {0}", user).ToList();

// SQL INTERPOLATED + JOIN
var blogs = context.Blogs.FromSqlInterpolated($"SELECT * FROM dbo.SearchBlogs({searchTerm})")
    .Include(b => b.Posts).ToList();

