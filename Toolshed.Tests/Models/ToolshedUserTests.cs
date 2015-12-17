using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toolshed.Models;
using System.Collections.Generic;

namespace Toolshed.Tests.Models
{
    [TestClass]
    public class ToolshedUserTests
    {
        [TestMethod]
        public void ToolshedUserEnsureICanCreateInstance()
        {
            ToolshedUser a_user = new ToolshedUser();
            Assert.IsNotNull(a_user);
        }

        [TestMethod]
        public void ToolshedUserEnsureJitterUserHasAllTheThings()
        {
            // Arrange
            ToolshedUser a_user = new ToolshedUser();

            a_user.UserId = 1;
            a_user.FirstName = "Jim";
            a_user.LastName = "Beam";
            a_user.Phone = "111-222-3333";
            a_user.Street = "Anystreet Blvd";

            // Assert 
            Assert.AreEqual(1, a_user.UserId);
            Assert.AreEqual("111-222-3333", a_user.Phone);
            Assert.AreEqual("Jim", a_user.FirstName);
            Assert.AreEqual("Beam", a_user.LastName);
            Assert.AreEqual("Anystreet Blvd", a_user.Street);
        }

        [TestMethod]
        public void ToolshedUserEnsureUserHasTools()
        {
            // Arrange
            List<Tool> list_of_tools = new List<Tool>
            {
                new Tool { ToolId = 1, Name = "cordless drill" },
                new Tool { ToolId = 2, Name = "table saw" }
            };
            ToolshedUser a_user = new ToolshedUser { UserId = 1, Tools = list_of_tools };
            // Act
            List<Tool> actual_tools = a_user.Tools;
            // Assert
            CollectionAssert.AreEqual(list_of_tools, actual_tools);
        }

        [TestMethod]
        public void ToolshedUserEnsureUserCanBorrowATool()
        {
            // Arrange
            List<Tool> list_of_borrowed_tools = new List<Tool>
            {
                new Tool { ToolId = 2, Name = "hammer" },
                new Tool { ToolId = 3, Name = "nail gun" }
            };

            ToolshedUser a_user = new ToolshedUser { UserId = 1, Borrowing = list_of_borrowed_tools };
            // Act
            List<Tool> actual_borrowed = a_user.Borrowing;
            // Assert
            CollectionAssert.AreEqual(list_of_borrowed_tools, actual_borrowed);
        }

        [TestMethod]
        public void ToolshedUserEnsureUserCanLoanATool()
        {
            // Arrange
            List<Tool> list_of_loaned_tools = new List<Tool>
            {
                new Tool { ToolId = 4, Name = "cordless drill" },
                new Tool { ToolId = 5, Name = "table saw"}
            };

            ToolshedUser a_user = new ToolshedUser { UserId = 1, Loaning = list_of_loaned_tools };
            // Act
            List<Tool> actual_loaned = a_user.Loaning;
            // Assert
            CollectionAssert.AreEqual(list_of_loaned_tools, actual_loaned);
        }
    }
}
