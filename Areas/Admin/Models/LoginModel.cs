using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.UI.Areas.Admin.Models
{
    public class LoginModel
    {

        [EmailAddress(ErrorMessage = "E-Posta formatında giriş yapınız")]
        [Required(ErrorMessage = "E-Posta Boş Geçilemez")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parola Boş Geçilemez")]
        [MinLength(4, ErrorMessage = "En az 4 karakter olmalıdır")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}