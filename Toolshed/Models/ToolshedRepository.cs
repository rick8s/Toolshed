using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Toolshed.Models
{
    public class ToolshedRepository
    {
        private ToolshedContext _context;
        public ToolshedContext Context { get { return _context; } }

        public ToolshedRepository()
        {
            _context = new ToolshedContext();
        }
        public ToolshedRepository(ToolshedContext a_context)
        {
            _context = a_context;
        }
        public List<ToolshedUser> GetAllUsers()
        {
            var query = from users in _context.ToolshedUsers select users;
            return query.ToList();
        }
    }
}