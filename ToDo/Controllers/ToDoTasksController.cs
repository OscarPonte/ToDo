using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class ToDoTasksController : Controller
    {
        // GET: Tasks
        public ViewResult Index()
        {
            var tasks = GetTasks();

            return View(tasks);
        }
        public ActionResult Details(int id)
        {
            var tasks = GetTasks().SingleOrDefault(t => t.Id == id);

            if (tasks == null)
                return HttpNotFound();

            return View(tasks);
        }
        private IEnumerable<ToDoTask> GetTasks()
        {
            return new List<ToDoTask>
            {
                new ToDoTask {Id = 1, Name = "Clean The Bathroom"},
                new ToDoTask {Id = 2, Name = "Clean The Kitchen"},
                new ToDoTask {Id = 3, Name = "Clean The Bedroom"}
            };

        }

    }
}