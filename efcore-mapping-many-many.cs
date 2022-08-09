builder.HasMany(x => x.Categories)
    .WithMany(x => x.Products)
    .UsingEntity<Dictionary<string, object>>(
        "ProductCategories",
        x => x.HasOne<Category>().WithMany().HasForeignKey("CategoryId"),
        x => x.HasOne<Product>().WithMany().HasForeignKey("ProductId")
    );