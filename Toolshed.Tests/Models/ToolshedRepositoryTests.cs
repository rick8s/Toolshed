using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Toolshed.Models;
using Moq;
using System.Data.Entity;
using System.Linq;

namespace Toolshed.Tests.Models
{
    [TestClass]
    public class ToolshedRepositoryTests
    {
        [TestMethod]
        public void ToolshedContextEnsureICanCreateInstance()
        {
            ToolshedContext context = new ToolshedContext();
            Assert.IsNotNull(context);
        }

        [TestMethod]
        public void ToolshedRepositoryEnsureICanCreateInstance()
        {
            ToolshedRepository repository = new ToolshedRepository();
            Assert.IsNotNull(repository);
        }

        [TestMethod]
        public void ToolshedRepositoryEnsureICanGetAllUsers()
        {
            //Arrange
            var expected = new List<ToolshedUser>
            {
                new ToolshedUser { FirstName = "Rick"  },
                new ToolshedUser { FirstName = "Kyle" },
                new ToolshedUser {FirstName = "Doug" }
            };
            Mock<ToolshedContext> mock_context = new Mock<ToolshedContext>();
            Mock<DbSet<ToolshedUser>> mock_set = new Mock<DbSet<ToolshedUser>>();

            mock_set.Object.AddRange(expected);
            var data_source = expected.AsQueryable();

            mock_set.As<IQueryable<ToolshedUser>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_set.As<IQueryable<ToolshedUser>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_set.As<IQueryable<ToolshedUser>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_set.As<IQueryable<ToolshedUser>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            mock_context.Setup(a => a.ToolshedUsers).Returns(mock_set.Object);
            ToolshedRepository repository = new ToolshedRepository(mock_context.Object);

            //Act
            var actual = repository.GetAllUsers();

            //Assert
            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void ToolshedRepositoryEnsureIHaveAContext()
        {
            //Arrange
            ToolshedRepository repository = new ToolshedRepository();

            //Act
            var actual = repository.Context;

            //Assert
            Assert.IsInstanceOfType(actual, typeof(ToolshedContext));
        }
    }
}
