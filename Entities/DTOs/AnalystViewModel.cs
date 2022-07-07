using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AnalystViewModel
    {
        public int TaskId { get; set; }
        public int DifficultyId { get; set; }
        public string TaskName { get; set; }
        public string DifficultyName { get; set; }

    }
}
