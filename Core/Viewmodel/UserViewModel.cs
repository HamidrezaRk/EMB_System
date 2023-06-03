using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emb_project.Viewmodel
{
     public class UserViewModel
     {
        public int Id { get; set; }
        [Display(Name = "انتخاب نقش")]
        public int RoleId_Fk { get; set; }
        [Display(Name = "نام و نام خانوادگی")]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Display(Name = "تاریخ تولد")]
        [MaxLength(10)]
        public string BirthDate { get; set; }

        [Display(Name = "موبایل")]
        [MaxLength(11)]
        [Phone]
        public string mobile { get; set; }


        [Display(Name = "تصویر کاربر")]
        [MaxLength(100)]
        [Phone]
        public string UserAvatar { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
