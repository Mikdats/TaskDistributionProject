using Business.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TaskDistributionProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITaskModelService _taskModelService;
        private readonly TaskContext _taskContext;
        TaskContext c = new TaskContext();

        public AdminController(IUserService userService, TaskContext taskContext, ITaskModelService taskModelService)
        {
            _userService = userService;
            _taskContext = taskContext;
            _taskModelService = taskModelService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll(User user)
        {

            var result = _userService.GetAll();
            return View(result);
        }
        [HttpGet]
        public IActionResult Add()
        {
            List<SelectListItem> RoleList = (from x in c.Roles.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.RoleName,
                                                 Value = x.RoleId.ToString()
                                             }).ToList();
            ViewBag.Role = RoleList;
            return View();
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            _userService.Add(user);
            return RedirectToAction("GetAll", "Admin");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var user = _userService.GetById(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult Update(User user)
        {
            _userService.Update(user);
            return RedirectToAction("GetAll", "Admin");
        }
        public IActionResult Delete(int id)
        {
            var user = _userService.GetById(id);
            _userService.Delete(user);
            return RedirectToAction("GetAll", "Admin");
        }
        public IActionResult AllAssignment()
        {
            List<AdminViewModel> adminViewModel = (from t in _taskContext.TaskModels
                                                   join a in _taskContext.DifficultyLevels
                                                   on t.DifficultyId equals a.DifficultyId
                                                   join d in _taskContext.Developers
                                                   on t.DeveloperId equals d.DeveloperId
                                                   into gj
                                                   from x in gj.DefaultIfEmpty()
                                                   select new AdminViewModel
                                                   {

                                                       TaskId = t.TaskId,
                                                       TaskName = t.TaskName,
                                                       DifficultyId = t.DifficultyId,
                                                       DifficultyName = a.DifficultyName,
                                                       DeveloperId = t.DeveloperId,
                                                       DeveloperName = (x == null ? String.Empty : x.DeveloperName)

                                                   }).ToList();
            return View(adminViewModel);
        }
        public IActionResult AddAssignment(int id)
        {
            List<SelectListItem> adminlist = (from x in c.Developers.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.DeveloperName,
                                                  Value = x.DeveloperId.ToString()
                                              }).ToList();
            ViewBag.Adminlist = adminlist;

            AdminViewModel adminViewModel = (from t in _taskContext.TaskModels
                                             join a in _taskContext.DifficultyLevels
                                             on t.DifficultyId equals a.DifficultyId
                                             join d in _taskContext.Developers
                                             on t.DeveloperId equals d.DeveloperId
                                             into gj                                           
                                             from x in gj.DefaultIfEmpty()
                                             where t.TaskId == id
                                             select new AdminViewModel()
                                             {

                                                 TaskId = t.TaskId,
                                                 TaskName = t.TaskName,
                                                 DifficultyId = t.DifficultyId,
                                                 DifficultyName = a.DifficultyName,
                                                 DeveloperId = t.DeveloperId,
                                                 DeveloperName = (x == null ? String.Empty : x.DeveloperName)
                                             }).SingleOrDefault();
            return View(adminViewModel);
        }
        [HttpPost]
        public IActionResult AddAssignment(AdminViewModel adminViewModel)
        {
            Random rnd = new Random();
            int Randomnumber = rnd.Next(1, 9);
            TaskModel taskModel = new TaskModel();
            var result = _taskContext.Developers.Where(c => c.DeveloperId == Randomnumber).SingleOrDefault();
            adminViewModel.DeveloperId = result.DeveloperId;
            taskModel.TaskId =adminViewModel.TaskId;
            taskModel.TaskName = adminViewModel.TaskName;
            taskModel.DifficultyId = adminViewModel.DifficultyId;
            taskModel.DeveloperId = adminViewModel.DeveloperId;


            foreach (var item in taskManagerList.Where(tm=>tm.DeveloperId==adminViewModel.DeveloperId))
            {
                if (item.Tasks.Count<8)
                {
                    foreach (var itemTask in item.Tasks)
                    {
                        var tResult = _taskContext.TaskModels.Where(t=>t.TaskId == adminViewModel.TaskId).SingleOrDefault();
                        if (tResult.DifficultyId!=itemTask.DifficultyId)
                        {
                            tm.DeveloperId = adminViewModel.DeveloperId;
                            td.DifficultyId = adminViewModel.DifficultyId;
                            td.TaskId = adminViewModel.TaskId;
                            tm.Tasks.Add(td);
                            taskManagerList.Add(tm);

                            _taskContext.TaskModels.Update(taskModel);
                            _taskContext.SaveChanges();
                        }
                    }
                    
                }
            }
            
            

            
            
                        
            return RedirectToAction("AllAssignment", "Admin");
        }
    }
}
