// název tabulky se definuje jen pro root a stejně tak dbset
builder
    .HasDiscriminator<byte>("Discriminator")
    .HasValue<Book>(1)
    .HasValue<Product>(0);