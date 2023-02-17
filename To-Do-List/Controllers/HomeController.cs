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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTask(TaskModel newTask)
        {
            try
            {
                if (newTask.Task != null && ModelState.IsValid)
                {
                    _taskRepository.Create(newTask);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch(System.Exception erro)
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult UpdateStatus(int id)
        {
            _taskRepository.UpdateStatus(id);
            return RedirectToAction("Index");
        }


        public IActionResult Update(int id)
        {
            var task = _taskRepository.FindTask(id);
            return View(task);
        }
        public IActionResult UpdateTask(TaskModel updatedTask)
        {
            _taskRepository.Update(updatedTask);
            return RedirectToAction("Index");
        }

        public IActionResult PendingStatus(int id)
        {
            _taskRepository.PendingStatus(id);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _taskRepository.Delete(id);
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
