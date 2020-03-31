using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3.Models
{
    public class Lab3Context : IdentityDbContext<User>
    {
        public DbSet<User> Persons { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }

        public Lab3Context(DbContextOptions<Lab3Context> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }
    }

    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int StateId { get; set; }
        public State State { get; set; }
    }
}