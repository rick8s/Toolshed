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

        public ToolshedUser GetUserByUserName(string username)
        {
           
            var query = from user in _context.ToolshedUsers where user.UserName == username select user;

            return query.SingleOrDefault();
        }

        public bool IsUserNameAvailable(string username)
        {
            bool available = false;
            try
            {
                ToolshedUser some_user = GetUserByUserName(username);
                if (some_user == null)
                {
                    available = true;
                }
            }
            catch (InvalidOperationException) { }

            return available;
        }

        public List<ToolshedUser> SearchByUserName(string username)
        {
            var query = from user in _context.ToolshedUsers select user;
            List<ToolshedUser> found_users = query.Where(user => user.UserName.Contains(username)).ToList();
            found_users.Sort();
            return found_users;
        }

        public List<ToolshedUser> SearchByName(string search_term)
        {
            var query = from user in _context.ToolshedUsers select user;
            List<ToolshedUser> found_users = query.Where(user => Regex.IsMatch(user.FirstName, search_term, RegexOptions.IgnoreCase) || Regex.IsMatch(user.LastName, search_term, RegexOptions.IgnoreCase)).ToList();
            found_users.Sort();
            return found_users;
        }

        public List<Tool> GetAllTools()
        {
            // SQL: select * from Tools;
            var query = from tool in _context.Tools select tool;
            List<Tool> found_tools = query.ToList();
            found_tools.Sort();
            return found_tools;
        }
    }
}