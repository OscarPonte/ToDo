using System.Collections.Generic;
using ToDo.Models;

namespace ToDo.ViewModels
{
    public class IndexTaskViewModel
    {
        public ToDoTask Task { get; set; }
        public List<User> Users { get; set; }
    }
}