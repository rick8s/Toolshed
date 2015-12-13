using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Toolshed.Models
{
    public class ToolshedUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Phone { get; set; }
        [Required]
        public string Street { get; set; }
        [Key]
        public string UserID { get; set; }

        public List<Tool> Tools { get; set; }
        public List<Tool> Borrowing { get; set; }
        public List<Tool> Loaning { get; set; }

        
    }
}