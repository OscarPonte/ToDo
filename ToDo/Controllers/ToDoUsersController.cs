using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class ToDoUsersController : Controller
    {
     
     public ViewResult Index()
    {
        var users = GetUsers();

        return View(users);
    }

    public ActionResult Details(int id)
    {
        var users = GetUsers().SingleOrDefault(u => u.Id == id);

        if (users == null)
            return HttpNotFound();

        return View(users);
    }

    private IEnumerable<ToDoUser> GetUsers()
    {
            return new List<ToDoUser>
                {
                    new ToDoUser { Id = 1, Name = "Oscar" },
                    new ToDoUser { Id = 2, Name = "Rossy" }
                };
        }
    }
} 