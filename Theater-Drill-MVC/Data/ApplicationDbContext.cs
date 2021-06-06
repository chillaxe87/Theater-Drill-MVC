using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Theater_Drill_MVC.Models;

namespace Theater_Drill_MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Auditorium> Auditoriums { get; set; }
    }
}

