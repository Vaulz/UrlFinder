using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;
using NetExamenam.Controllers;
using NetExamenam.Models;

namespace NetExamenam
{
    public class AppContext : DbContext
    {
        public AppContext() 
            : base("UrlDatabase")
        {
        }

        public DbSet<UrlModel> UrlModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
