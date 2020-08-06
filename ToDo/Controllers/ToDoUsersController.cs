using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class ToDoUsersController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();


        // GET: ToDoUsers
        public ActionResult Index()
        {
            return View(_context.ToDoUsers.Include(x => x.ToDoTasks).ToList());
        }

        // GET: ToDoUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var toDoUser = _context.ToDoUsers.Find(id);

            if (toDoUser == null)
            {
                return HttpNotFound();
            }
            return View(toDoUser);
        }

        // GET: ToDoUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDoUsers1/Create       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] ToDoUser toDoUser)
        {
            if (ModelState.IsValid)
            {
                _context.ToDoUsers.Add(toDoUser);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(toDoUser);
        }

        // GET: ToDoUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoUser toDoUser = _context.ToDoUsers.Find(id);
            if (toDoUser == null)
            {
                return HttpNotFound();
            }
            return View(toDoUser);
        }

        // POST: ToDoUsers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] ToDoUser toDoUser)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(toDoUser).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toDoUser);
        }

        // GET: ToDoUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoUser toDoUser = _context.ToDoUsers.Find(id);
            if (toDoUser == null)
            {
                return HttpNotFound();
            }
            return View(toDoUser);
        }

        // POST: ToDoUsers1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ToDoUser toDoUser = _context.ToDoUsers.Find(id);
            _context.ToDoUsers.Remove(toDoUser);
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