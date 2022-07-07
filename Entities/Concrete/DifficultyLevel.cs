using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class DifficultyLevel:IEntity
    {
        [Key]
        public int DifficultyId { get; set; }
        public string DifficultyName { get; set; }
    }
}
