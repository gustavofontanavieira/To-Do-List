using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using To_Do_List.Models;
using To_Do_List.Repository;

namespace To_Do_List.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskRepository _taskRepository;
        public HomeController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public IActionResult Index()
        {
            var tasks = _taskRepository.ListAll();
            return View(tasks);
        }

        [HttpPost]
        public IActionResult Create(TaskModel task)
        {
            _taskRepository.Create(task);
            return View("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
