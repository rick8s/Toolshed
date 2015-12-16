using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Toolshed.Models
{
    public class ToolReserve
    {
        [Key]
        public string ReserveId { get; set; }
        public string ReserveDate { get; set; }
        public string UserName { get; set; }
        public int ToolId { get; set; }
    }
}