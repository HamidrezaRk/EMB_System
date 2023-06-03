using DataLayer.PublicClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emb_project.Viewmodel
{
     public class LoginViewModel
     {
        [Display(Name = "نام کاربری")]
        [Required(AllowEmptyStrings = false, ErrorMessage = PubliClass.EnterMessage)]
        public string UserName { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(AllowEmptyStrings = false, ErrorMessage = PubliClass.EnterMessage)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "مرا بخاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}
