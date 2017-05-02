using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DWD273_Final_Project_Revised.Models
{
    public class TicketContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Topic> Topics { get; set; }

        public System.Data.Entity.DbSet<DWD273_Final_Project_Revised.Models.Comment> Comments { get; set; }
    }
}