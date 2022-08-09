builder
    .Property(e => e.Zeme)
    .HasConversion(
        v => v.ToString(),
        v => (ZemeEnum)Enum.Parse(typeof(ZemeEnum), v));

builder
    .Property(e => e.Zeme)
    .HasConversion<string>();   // uloží do DB jako string
