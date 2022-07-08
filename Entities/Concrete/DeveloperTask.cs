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
        [ForeignKey]
        public int TaskId { get; set; }
        public List<TaskModel> tasks { get; set; }
        public Task Task { get; set; }
    }
}
