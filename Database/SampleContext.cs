using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql;
using PostgreEFCorePerfTest.Database.Entities;
using System;

namespace PostgreEFCorePerfTest.Database
{
    public class SampleContext : DbContext
    {
        public DbSet<SampleEntity> Samples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("sampleSchema");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbMinPoolSizeValue = Environment.GetEnvironmentVariable("DATABASE_MIN_POOL_SIZE");
            string dbMaxPoolSizeValue = Environment.GetEnvironmentVariable("DATABASE_MAX_POOL_SIZE");
            string dbPort = Environment.GetEnvironmentVariable("DATABASE_PORT");
            string dbHost = Environment.GetEnvironmentVariable("DATABASE_HOST");
            int dbMinPoolSize = (dbMinPoolSizeValue == null) ? 3 : int.Parse(dbMinPoolSizeValue);
            string dbName = Environment.GetEnvironmentVariable("DATABASE_NAME");
            int dbMaxPoolSize = (dbMaxPoolSizeValue == null) ? 10 : int.Parse(dbMaxPoolSizeValue);
            NpgsqlConnectionStringBuilder connString = new NpgsqlConnectionStringBuilder()
            {
                Username = Environment.GetEnvironmentVariable("DATABASE_USER"),
                Password = Environment.GetEnvironmentVariable("DATABASE_PASS"),
                Host = dbHost,
                MaxPoolSize = dbMaxPoolSize,
                MinPoolSize = dbMinPoolSize,
                Port = int.Parse(dbPort),
                Database = dbName,
                Pooling = true
            };
            int dbMinBatchSize = int.Parse(Environment.GetEnvironmentVariable("DATABASE_MIN_BATCH_SIZE") ?? "2");
            int dbMaxBatchSize = int.Parse(Environment.GetEnvironmentVariable("DATABASE_MAX_BATCH_SIZE") ?? "1000");
            optionsBuilder.UseNpgsql(connString.ConnectionString,
             b =>
             {
                 b.MinBatchSize(dbMinBatchSize);
                 b.MaxBatchSize(dbMaxBatchSize);
                 b.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "sampleSchema");
             });
        }
    }
}
