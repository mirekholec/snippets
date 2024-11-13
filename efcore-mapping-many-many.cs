builder.HasMany(x => x.Categories)
    .WithMany(x => x.Products)
    .UsingEntity<Dictionary<string, object>>(
        "ProductCategories",
        x => x.HasOne<Category>().WithMany().HasForeignKey("CategoryId"),
        x => x.HasOne<Product>().WithMany().HasForeignKey("ProductId")
    );

builder
        .HasMany(x => x.Categories)
        .WithMany(x => x.Products)
        .UsingEntity("ProductCategories",
            x=>x.HasOne(typeof(Category)).WithMany().HasForeignKey("CategoryId").HasPrincipalKey(nameof(Category.Id)),
            x=>x.HasOne(typeof(Product)).WithMany().HasForeignKey("ProductId").HasPrincipalKey(nameof(Product.Id)),
            x=>x.HasKey("ProductId", "CategoryId"));