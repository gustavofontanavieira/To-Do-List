using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace To_Do_List.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public string Status { get; set; }
    }
}
