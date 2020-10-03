using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingManager.Models
{
    public class IdentityContext : IdentityDbContext<BuildingUser, BuildingUserRole, int>
    {
        public DbSet<BuildingActivity> BuildingActivities { get; set; }

        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {

        }
    }
}
