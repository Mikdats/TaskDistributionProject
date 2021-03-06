using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class TaskModel:IEntity
    {
        [Key]
        public int TaskId { get; set; }
        public string TaskName { get; set; }      
        public int DeveloperId { get; set; }
        public int DifficultyId { get; set; }
    }
}
