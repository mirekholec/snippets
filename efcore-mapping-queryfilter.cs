// definice filtru globálně - funguje i v includech
builder.Entity<Post>().HasQueryFilter(p => !p.IsDeleted);

// ignorace v dotazování
blogs = db.Blogs.Include(b => b.Posts).IgnoreQueryFilters().ToList();