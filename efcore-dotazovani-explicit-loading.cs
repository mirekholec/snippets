// explicit collection
context.Entry(blog).Collection(b => b.Posts).Load();

// explicit entity
context.Entry(blog).Reference(b => b.Owner).Load();

// explicit collection query
var goodPosts = context.Entry(blog).Collection(b => b.Posts)
        .Query().Where(p => p.Rating > 3).ToList();
