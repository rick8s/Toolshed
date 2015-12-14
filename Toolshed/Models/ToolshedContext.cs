using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Toolshed.Models
{
    public class ToolshedContext : DbContext
    {
        public virtual DbSet<ToolshedUser> ToolshedUsers { get; set; }

        public DbSet<Tool> Tools { get; set; }
    }
}