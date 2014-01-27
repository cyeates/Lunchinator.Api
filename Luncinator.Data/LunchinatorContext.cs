using Lunchinator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lunchinator.Data
{
    public class LunchinatorContext : DbContext
    {
       public DbSet<Lunch> Lunches { get; set; }
       public DbSet<User> Users { get; set; }
    }
}