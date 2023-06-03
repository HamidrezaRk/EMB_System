using DataLayer.PublicClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emb_project.Viewmodel
{
     public class NewsViewModel
     {
        public int NewsId { get; set; }

        [Display(Name = "عنوان خبر")]
        [Required(AllowEmptyStrings = false, ErrorMessage = PubliClass.EnterMessage)]
        [StringLength(250, MinimumLength = 4, ErrorMessage = PubliClass.LengthMessage)]
        [RegularExpression(@"[0-9A-Zا-یa-z_\s\-\(\)\.]+", ErrorMessage = PubliClass.DangrouseMessageForBadCharachter)]
        public string Title { get; set; }


        [Display(Name = "متن خبر")]
        [Required(AllowEmptyStrings = false, ErrorMessage = PubliClass.EnterMessage)]
        public string Content { get; set; }


        [Display(Name = "چکیده")]
        [Required(AllowEmptyStrings = false, ErrorMessage = PubliClass.EnterMessage)]
        [StringLength(400, MinimumLength = 5, ErrorMessage = PubliClass.LengthMessage)]
        [RegularExpression(@"[0-9A-Zا-یa-z_\s\-\(\)\.]+", ErrorMessage = PubliClass.DangrouseMessageForBadCharachter)]
        public string Abstract { get; set; }

        [Display(Name = "تصویر شاخص")]
        public string IndexImage { get; set; }

        [Display(Name = "کاربر")]
        public int UserID_fk { get; set; }
        [Display(Name = "دسته بندی")]
        public int CategoryID_fk { get; set; }

        [Display(Name = "نوع خبر")]
        public byte NewsType { get; set; }
        [Display(Name = "محل ارسال خبر")]
        public byte PlaceNewsID { get; set; }
    }
}
