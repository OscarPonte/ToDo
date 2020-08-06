using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Models
{
    public class ToDoTask
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public ICollection<ToDoStep> ToDoSteps { get; set; }
        public ICollection<ToDoUser> ToDoUsers { get; set; }


    }
}