using System.ComponentModel.DataAnnotations;

namespace ToDo.Models
{
    public class ToDoStep
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

    }
}