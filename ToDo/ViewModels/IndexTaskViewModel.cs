using System.Collections.Generic;
using ToDo.Models;

namespace ToDo.ViewModels
{
    public class IndexTaskViewModel
    {
        public ToDoTask Task { get; set; }
        public List<ToDoUser> Users { get; set; }
    }
}