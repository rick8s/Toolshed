using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toolshed.Models;

namespace Toolshed.Tests.Models
{
    [TestClass]
    public class ToolTests
    {
        [TestMethod]
        public void ToolEnsureICanCreateAnInstance()
        {
            Tool a_tool = new Tool();

            Assert.IsNotNull(a_tool);
        }

        [TestMethod]
        public void ToolEnsureAToolHasAllItsInfo()
        {
            //Arrange
            Tool a_tool = new Tool();

            // Act 
            a_tool.ToolId = 1;
            a_tool.Description = "My Content";
            a_tool.Owner = null; // Will need to define this later
            a_tool.Picture = "https://google.com";
            a_tool.Category = "A Category";

            // Assert
            Assert.AreEqual(1, a_tool.ToolId);
            Assert.AreEqual("My Content", a_tool.Description);
            Assert.AreEqual(null, a_tool.Owner);
            Assert.AreEqual("https://google.com", a_tool.Picture);
            Assert.AreEqual("A Category", a_tool.Category);
        }
    }
}
