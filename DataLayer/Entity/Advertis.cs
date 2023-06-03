using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entity
{
   public class Advertis
   {
        [Key]
        public int AdId { get; set; }

        [Display(Name = "تصویر")]
        [Required(AllowEmptyStrings = false, ErrorMessage =PublicClass.PubliClass.EnterMessage)]
        public string gifPath { get; set; }

        [Display(Name = "از تاریخ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = PublicClass.PubliClass.EnterMessage)]
        public string FromDate { get; set; }

        [Display(Name = "تا تاریخ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = PublicClass.PubliClass.EnterMessage)]
        public string ToDate { get; set; }

        [Display(Name = "لینک تبلیغ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = PublicClass.PubliClass.EnterMessage)]
        public string Link { get; set; }

        [Display(Name = "وضعیت")]
        public byte flag { get; set; }

        [Display(Name = "محل نمایش")]
        public byte Advlocation { get; set; }
    }
}
