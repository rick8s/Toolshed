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

        private Mock<ToolshedContext> mock_context;
        private Mock<DbSet<ToolshedUser>> mock_set;
        //private Mock<DbSet<Tool>> mock_tool_set;
        private ToolshedRepository repository;

        private void ConnectMocksToDataStore(IEnumerable<ToolshedUser> data_store)
        {
            var data_source = data_store.AsQueryable<ToolshedUser>();
            // HINT HINT: var data_source = (data_store as IEnumerable<ToolshedUser>).AsQueryable();
            // Convince LINQ that our Mock DbSet is a (relational) Data store.
            mock_set.As<IQueryable<ToolshedUser>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_set.As<IQueryable<ToolshedUser>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_set.As<IQueryable<ToolshedUser>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_set.As<IQueryable<ToolshedUser>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            // This is Stubbing the ToolshedUsers property getter
            mock_context.Setup(a => a.ToolshedUsers).Returns(mock_set.Object);
        }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<ToolshedContext>();
            mock_set = new Mock<DbSet<ToolshedUser>>();
            //mock_tool_set = new Mock<DbSet<Tool>>();
            repository = new ToolshedRepository(mock_context.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            mock_context = null;
            mock_set = null;
           // mock_tool_set = null;
            repository = null;
        }

        [TestMethod]
        public void ToolshedContextEnsureICanCreateInstance()
        {
            ToolshedContext context = mock_context.Object;
            Assert.IsNotNull(context);
        }

        [TestMethod]
        public void ToolshedRepositoryEnsureICanCreateInstance()
        {
            Assert.IsNotNull(repository);
        }

        [TestMethod]
        public void ToolshedRepositoryEnsureICanGetAllUsers()
        {
            //Arrange
            var expected = new List<ToolshedUser>
            {
                new ToolshedUser { UserName = "Rick8s"  },
                new ToolshedUser { UserName = "Kyle" },
                new ToolshedUser { UserName = "Doug" }
            };

            mock_set.Object.AddRange(expected);

            ConnectMocksToDataStore(expected);

            //Act
            var actual = repository.GetAllUsers();

            //Assert
            Assert.AreEqual("Rick8s", actual.First().UserName);
            CollectionAssert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void ToolshedRepositoryEnsureIHaveAContext()
        {
            //Act
            var actual = repository.Context;

            //Assert
            Assert.IsInstanceOfType(actual, typeof(ToolshedContext));
        }
    }
}
