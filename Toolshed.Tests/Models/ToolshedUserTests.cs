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
        public void JitterUserEnsureJitterUserHasAllTheThings()
        {
            // Arrange
            ToolshedUser a_user = new ToolshedUser();

            a_user.UserID = "1";
            a_user.FirstName = "Jim";
            a_user.LastName = "Beam";
            a_user.Phone = "111-222-3333";
            a_user.Street = "Anystreet Blvd";

            // Assert 
            Assert.AreEqual("1", a_user.UserID);
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
                new Tool { ToolId = 1, Description = "cordless drill"},
                new Tool { ToolId =2, Description = "table saw"}
            };
            ToolshedUser a_user = new ToolshedUser { UserID = "1", Tools = list_of_tools };
            // Act
            List<ToolshedUser> actual_tools = a_user.Tools;
            // Assert
            CollectionAssert.AreEqual(list_of_tools, actual_tools);
        }

        [TestMethod]
        public void ToolshedUserEnsureUserCanBorrowATool()
        {
            // Arrange
            List<Tool> list_of_borrowed_tools = new List<Tool>
            {
                new Tool { ToolId = 2, Description = "hammer" },
                new Tool { ToolId = 3, Description = "nail gun"}
            };

            ToolshedUser a_user = new ToolshedUser { UserID = "1", Borrowing = list_of_borrowed_tools };
            // Act
            List<ToolshedUser> actual_borrowed = a_user.Borrowing;
            // Assert
            CollectionAssert.AreEqual(list_of_borrowed_tools, actual_borrowed);
        }
    }
}
