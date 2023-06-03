using DataLayer.PublicClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emb_project.Viewmodel
{
     public class CategoryViewModel
     {
        [Key]
        public int Id { get; set; }

        [Display(Name = "عنوان دسته بندی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = PubliClass.EnterMessage)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = PubliClass.LengthMessage)]
        [RegularExpression(@"[0-9A-Zا-یa-z_\s\-\(\)\.]+", ErrorMessage = PubliClass.DangrouseMessageForBadCharachter)]
        public string Title { get; set; }


        [Display(Name = "توضیحات")]
        [Required(AllowEmptyStrings = false, ErrorMessage = PubliClass.EnterMessage)]
        [StringLength(100, MinimumLength = 1, ErrorMessage = PubliClass.LengthMessage)]
        [RegularExpression(@"[0-9A-Zا-یa-z_\s\-\(\)\.]+", ErrorMessage = PubliClass.DangrouseMessageForBadCharachter)]
        public string Description { get; set; }

     }
}
