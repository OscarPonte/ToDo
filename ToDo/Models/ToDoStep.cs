using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Models
{
    public class ToDoStep
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool TheStepItsDone { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateEnded { get; set; }
        public ToDoTask ToDoTask { get; set; }
        public int ToDoTaskId { get; set; }


    }
}