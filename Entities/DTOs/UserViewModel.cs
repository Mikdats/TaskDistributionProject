using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "E-Posta alanı gereklidir. ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        public string Password { get; set; }
    }
}
