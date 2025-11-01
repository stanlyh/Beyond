using Beyond.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Beyond.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<Client> Clients => Set<Client>();
        public DbSet<User> Users => Set<User>();
    }
}
