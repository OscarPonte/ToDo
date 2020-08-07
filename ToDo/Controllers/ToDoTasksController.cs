using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ToDo.Models;
using ToDo.ViewModels;

namespace ToDo.Controllers
{
    public class ToDoTasksController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();


        // GET: ToDoTasks
        public ActionResult Index()
        {
            return View(_context.ToDoTasks.Include(s => s.ToDoSteps).ToList());
        }

        // GET: ToDoTasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var toDoTask = _context.ToDoTasks
                .Include(u => u.ToDoUsers)
                .Include(s => s.ToDoSteps)
                .SingleOrDefault(t => t.Id == id);
            var toDoUsers = _context.ToDoUsers.ToList();
            var toDoSteps = _context.ToDoSteps.ToList();
            var viewModel = new TasksFormViewModel
            {
                ToDoUsers = toDoUsers,
                ToDoSteps = toDoSteps,
                ToDoTask = toDoTask
            };

            if (toDoTask == null)
            {
                return HttpNotFound();
            }

            return View(viewModel);            
        }

        // GET: ToDoTasks/Create
        public ActionResult Create()
        {           
            return View();
        }

        // POST: ToDoTasks/Create       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] ToDoTask toDoTask)
        {
            if (ModelState.IsValid)
            {
                toDoTask.DateAdded = DateTime.Now;
                _context.ToDoTasks.Add(toDoTask);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toDoTask);
        }

        // GET: ToDoTasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var toDoTask = _context.ToDoTasks
                .Include(u => u.ToDoUsers)
                .Include(s => s.ToDoSteps)
                .SingleOrDefault(t => t.Id == id);

            if (toDoTask == null)
            {
                return HttpNotFound();
            }

            var viewModel = new TasksFormViewModel
            {
                ToDoTask = toDoTask,
                ToDoUsers = toDoTask.ToDoUsers,
                ToDoSteps = toDoTask.ToDoSteps
            };

            return View("Create", viewModel);
        }

        // POST: ToDoTasks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] ToDoTask toDoTask)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(toDoTask).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toDoTask);
        }

        // GET: ToDoTasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoTask toDoTask = _context.ToDoTasks.Find(id);
            if (toDoTask == null)
            {
                return HttpNotFound();
            }
            return View(toDoTask);
        }

        // POST: ToDoTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ToDoTask toDoTask = _context.ToDoTasks.Find(id);
            _context.ToDoTasks.Remove(toDoTask);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}