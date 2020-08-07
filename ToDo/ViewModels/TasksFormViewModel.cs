using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDo.Models;

namespace ToDo.ViewModels
{
    public class TasksFormViewModel
    {
        public ICollection<ToDoUser> ToDoUsers { get; set; }
        public ToDoTask ToDoTask { get; set; }
        public ICollection<ToDoStep> ToDoSteps { get; set; }

    }
}