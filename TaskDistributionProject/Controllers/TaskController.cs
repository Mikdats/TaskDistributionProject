using Business.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TaskDistributionProject.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskModelService _taskModelService;
        private readonly TaskContext _taskContext;

        public TaskController(ITaskModelService taskModelService, TaskContext taskContext)
        {
            _taskModelService = taskModelService;
            _taskContext = taskContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll(TaskModel taskModel)
        {
            var recipes = _taskModelService.GetAll();
            return View(recipes);
        }
        public IActionResult Add()
        {           
            return View();
        }
        [HttpPost]
        public IActionResult Add(TaskModel taskModel)
        {
            _taskModelService.Add(taskModel);
            return RedirectToAction("GetAll", "Task");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var user = _taskModelService.GetById(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult Update(TaskModel taskModel)
        {
            _taskModelService.Update(taskModel);
            return RedirectToAction("GetAll", "Task");
        }
        public IActionResult Delete(int id)
        {
            var taskModel = _taskModelService.GetById(id);
            _taskModelService.Delete(taskModel);
            return RedirectToAction("GetAll", "Task");
        }

    }
}
