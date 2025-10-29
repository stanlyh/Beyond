using Microsoft.EntityFrameworkCore;
using System;

namespace Beyond.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Client> Clients => Set<Client>();
    }
}
