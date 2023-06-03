using DataLayer.PublicClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emb_project.Entity
{
   public class User
   {
        [Key]
        public int Id { get; set; }

        [Display(Name = "انتخاب نقش")]
        public int RoleId_Fk { get; set; }

        [Display(Name = "نام کاربری")]
        [MaxLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = PubliClass.EnterMessage)]
        [StringLength(50, MinimumLength = 4, ErrorMessage = PubliClass.LengthMessage)]
        [RegularExpression(@"[0-9A-Zا-یa-z_\s\-\(\)\.]+", ErrorMessage = PubliClass.DangrouseMessageForBadCharachter)]

        public string UserName { get; set; }

        [Display(Name = "کلمه عبور")]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = PubliClass.EnterMessage)]
        [StringLength(100, MinimumLength = 4, ErrorMessage = PubliClass.LengthMessage)]
        [RegularExpression(@"[0-9A-Zا-یa-z_\s\-\(\)\.]+", ErrorMessage =PubliClass.DangrouseMessageForBadCharachter)]
        public string Password { get; set; }


        [Display(Name = "تاریخ عضویت")]
        [MaxLength(10)]
        public string Date_Register { get; set; }

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

        [ForeignKey("RoleId_Fk")]
        public virtual Role Role { get; set; }


        [Display(Name = "تصویر")]
        [MaxLength(100)]
        public string UserAvatar { get; set; }

        public virtual ICollection<News> news { get; set; }
    }
}
