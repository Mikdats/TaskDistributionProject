using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User:IEntity
    {
        public int UserId { get; set; }

        [Required(ErrorMessage ="Kullanıcı adı kısmı gereklidir!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre kısmı gereklidir!")]
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
