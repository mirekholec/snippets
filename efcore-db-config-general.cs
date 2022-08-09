// OnModelCreating
modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");
modelBuilder.HasServiceTier("BusinessCritical");
modelBuilder.HasDatabaseMaxSize("2 GB");
modelBuilder.HasPerformanceLevel("BC_Gen4_1");
modelBuilder.HasPerformanceLevelSql("ELASTIC_POOL ( name = myelasticpool )");