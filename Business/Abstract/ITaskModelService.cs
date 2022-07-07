using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITaskModelService
    {
        List<TaskModel> GetAll();
        void Add(TaskModel taskModel);
        TaskModel GetById(int id);
        void Delete(TaskModel taskModel);
        void Update(TaskModel taskModel);
    }
}
