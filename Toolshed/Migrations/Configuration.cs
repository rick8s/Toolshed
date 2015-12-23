namespace Toolshed.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Toolshed.Models.ToolshedContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Toolshed.Models.ToolshedContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            context.ToolshedUsers.AddOrUpdate(u => u.UserId,
                new ToolshedUser() { UserId = 1, UserName = "garagedude", FirstName = "Sam", LastName = "Sneed", Phone = "111-222-3333", Street = "9th Fairway" },
                new ToolshedUser() { UserId = 2, UserName = "shoprat", FirstName = "Pete", LastName = "Sampras", Phone = "111-222-4444", Street = "Center Court" },
                new ToolshedUser() { UserId = 3, UserName = "toolman", FirstName = "Tim", LastName = "Taylor", Phone = "111-222-5555", Street = "Some Street" },
                new ToolshedUser() { UserId = 4, UserName = "tooldaddy", FirstName = "Samuel", LastName = "Adams", Phone = "111-222-6666", Street = "Pale Ale Avenue" }
                );
            context.SaveChanges();

            ToolshedUser user_one = context.ToolshedUsers.Where(u => u.UserId == 1).Single();
            ToolshedUser user_two = context.ToolshedUsers.Where(u => u.UserId == 2).Single();
            ToolshedUser user_three = context.ToolshedUsers.Where(u => u.UserId == 3).Single();
            ToolshedUser user_four = context.ToolshedUsers.Where(u => u.UserId == 4).Single();

            context.Tools.AddOrUpdate(t => t.ToolId,
                new Tool() { ToolId = 1, Owner = user_one, Image = "http://placehold.it/140x100", Category = "Power Tools", Name = "Air Compressor", Description = "15 gln 2.5 hp", Available = true },
                new Tool() { ToolId = 2, Owner = user_two, Image = "http://placehold.it/140x100", Category = "Hand Tools", Name = "Racket Stringer", Description = "", Available = true },
                new Tool() { ToolId = 3, Owner = user_three, Image = "http://placehold.it/140x100", Category = "Power Tools", Name = "Leaf Blower", Description = "4 hp backpack", Available = true },
                new Tool() { ToolId = 4, Owner = user_four, Image = "http://placehold.it/140x100", Category = "Lawn and Garden", Name = "Chain Saw", Description = "14 inch gas", Available = false }
                );
            context.SaveChanges();

            Tool tool_one = context.Tools.Where(t => t.ToolId == 1).Single();
            Tool tool_two = context.Tools.Where(t => t.ToolId == 2).Single();
            Tool tool_three = context.Tools.Where(t => t.ToolId == 3).Single();
            Tool tool_four = context.Tools.Where(t => t.ToolId == 4).Single();

            context.Reserved.AddOrUpdate(r => r.ReserveId,
               new ToolReserve() { ReserveId = 1, ReserveDate = "12-21", Who = user_one.UserName, ItemId = tool_four.ToolId, ItemName = tool_four.Name}
                );
            context.SaveChanges();
        }
    }
}
