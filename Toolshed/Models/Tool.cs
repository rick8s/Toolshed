using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;



namespace Toolshed.Models 
{
    public class Tool
    {
        [Required]
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public object Owner { get; set; }
        public string Picture { get; set; }
        [Key]
        public int ToolId { get; set; }
    }
}