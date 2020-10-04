using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestJudicial123.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<EstudiosJuridicos> EstudiosJuridicos { get; set; }
        

        public ApplicationDbContext() : base("DefaultConnection") 
        {
        }
    }
}