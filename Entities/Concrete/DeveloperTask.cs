using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class DeveloperTask:IEntity
    {
        public int DeveloperId { get; set; }
        //[ForeignKey]
        public int TaskId { get; set; }
        public List<TaskModel> tasks { get; set; }
        public Task Task { get; set; }
        //if (res.Count == 0)
        //{
        //    var result = _taskContext.Developers.Where(c => c.DeveloperId == Randomnumber).SingleOrDefault();

        //    adminViewModel.DeveloperId = result.DeveloperId;
        //    taskModel.TaskId = adminViewModel.TaskId;
        //    taskModel.TaskName = adminViewModel.TaskName;
        //    taskModel.DifficultyId = adminViewModel.DifficultyId;
        //    taskModel.DeveloperId = adminViewModel.DeveloperId;
        //}
        //else
        //{
        //    var total = _taskContext.TaskModels.Where(c => c.DeveloperId == Randomnumber).ToList();
        //    int totalCount = total.Count();
        //    int min=0;
        //    for (int i = 1; i < 9; i++)
        //    {
        //        var result = _taskContext.TaskModels.Where(x => x.DeveloperId == i).ToList();
        //        int resultCount = result.Count();
        //        var ress = _taskContext.TaskModels.Where(x => x.DeveloperId == min).ToList();
        //        if (totalCount >= resultCount)
        //        {
        //            total = _taskContext.TaskModels.Where(c => c.DeveloperId == i).ToList();
        //            totalCount = total.Count;
        //        }
        //        else
        //        {
        //            min = Randomnumber;
        //            break;
        //        }

        //    }
    }
}
