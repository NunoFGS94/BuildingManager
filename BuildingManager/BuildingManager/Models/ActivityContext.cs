using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingManager.Models
{
    public class ActivityContext : DbContext
    {
        public ActivityContext(DbContextOptions<ActivityContext> options) : base(options) { }

        public DbSet<BuildingActivity> Activity { get; set; }
    }
}
