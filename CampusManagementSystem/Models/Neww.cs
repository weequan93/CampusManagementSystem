using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CampusManagementSystem.Models
{
    public class Neww
    {
        public string Info { get; set; }
        public int Id { get; set; }
        public string Date { get; set; }
    }

    public class NewwsContext : DbContext
    {
        public DbSet<Neww> Newws { get; set; }
        public DbSet Newwss { get; set; }
    }
}
