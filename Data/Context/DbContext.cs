using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Data.Context
{
    public class DbContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Publicacao> Ativos { get; set; }

    public DbContext(DbContextOptions<DbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContext).Assembly);
    }
}
}