builder
    .HasIndex(x => new {x.ProductId, x.CategoryId})
    .IsUnique()
    .HasName("IX_ProductId_CategoryId");