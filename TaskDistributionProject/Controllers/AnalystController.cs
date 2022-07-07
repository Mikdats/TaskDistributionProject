using Business.Abstract;
using DataAccess.Concrete.Context;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TaskDistributionProject.Controllers
{
    public class AnalystController : Controller
    {
        TaskContext _taskContext;
        ITaskModelService _taskModelService;
        TaskContext c = new TaskContext();
        public AnalystController(TaskContext taskContext, ITaskModelService taskModelService)
        {
            _taskContext = taskContext;
            _taskModelService = taskModelService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AllTaskForAnalyst()
        {
            List<AnalystViewModel> analystViewModel = (from t in _taskContext.TaskModels
                                                   join a in _taskContext.DifficultyLevels
                                                   on t.DifficultyId equals a.DifficultyId                                                    
                                                   into gj
                                                   from x in gj.DefaultIfEmpty()
                                                   select new AnalystViewModel
                                                   {

                                                       TaskId = t.TaskId,
                                                       TaskName = t.TaskName,                                                                      
                                                       DifficultyId = t.DifficultyId,
                                                       DifficultyName = (x == null ? String.Empty : x.DifficultyName),
                                                      
                                                   }).ToList();
            return View(analystViewModel);

        }
        public IActionResult TaskForAnalyst(int id)
        {

            List<SelectListItem> List = (from x in c.DifficultyLevels.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.DifficultyName,
                                                  Value = x.DifficultyId.ToString()
                                              }).ToList();

            ViewBag.list = List;

            AnalystViewModel analystViewModel = (from t in _taskContext.TaskModels
                                                 join a in _taskContext.DifficultyLevels
                                                 on t.DifficultyId equals a.DifficultyId
                                                 into gj
                                                 from x in gj.DefaultIfEmpty()
                                                 where t.TaskId == id
                                                 select new AnalystViewModel()
                                                 {
                                                     DifficultyId=t.DifficultyId,
                                                     TaskId = t.TaskId,
                                                     TaskName = t.TaskName,
                                                     DifficultyName = (x == null ? String.Empty : x.DifficultyName)
                                                 }).SingleOrDefault();         
            return View(analystViewModel);
        }
        [HttpPost]
        public IActionResult TaskForAnalyst(AnalystViewModel analystViewModel)
        {
            var result = _taskModelService.GetById(analystViewModel.TaskId);          
            result.DifficultyId = analystViewModel.DifficultyId;
            _taskModelService.Update(result);
            return RedirectToAction("AllTaskForAnalyst", "Analyst");
        }
    }
}
