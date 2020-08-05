﻿using System.ComponentModel.DataAnnotations;

namespace ToDo.Models
{
    public class ToDoTask
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public ToDoStep ToDoStep { get; set; }
        public int ToDoStepId { get; set; }

    }
}