using emb_project.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entity
{
     public class Comment
     {
        [Key]
        public int Id { get; set; }

        public int NewsId { get; set; }


        [Display(Name = "نام")]
        [Required(AllowEmptyStrings = false, ErrorMessage = PublicClass.PubliClass.EnterMessage)]
        [StringLength(60, MinimumLength = 3, ErrorMessage = PublicClass.PubliClass.LengthMessage)]
        [RegularExpression(@"[ا-ی\sآ]", ErrorMessage = PublicClass.PubliClass.DangrouseMessageForBadCharachter)]
        public string FullName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(AllowEmptyStrings = false, ErrorMessage = PublicClass.PubliClass.EnterMessage)]
        [DataType(DataType.EmailAddress, ErrorMessage = "ایمیل را صحیح وارد نمایید")]
        public string Email { get; set; }

        [Display(Name = "متن نظر")]
        [Required(AllowEmptyStrings = false, ErrorMessage = PublicClass.PubliClass.EnterMessage)]
        [StringLength(2000, MinimumLength = 10, ErrorMessage = PublicClass.PubliClass.LengthMessage)]
        [RegularExpression(@"[0-9A-Zا-یa-z_\s\-\(\)\.]+", ErrorMessage = PublicClass.PubliClass.DangrouseMessageForBadCharachter)]
        public string Message { get; set; }

        [Display(Name = "آی پی")]
        public string IP { get; set; }

        [Display(Name = "تاریخ ارسال نظر")]
        public string commentDate { get; set; }

        [Display(Name = "زمان ارسال نظر")]
        public string commentTime { get; set; }

        public int LikeCount { get; set; }
        public int DisLikeCount { get; set; }

        [Display(Name = "وضعیت")]
        public bool status { get; set; }

        public int ReplyID { get; set; }


        [ForeignKey("NewsId")]
        public virtual News TblNews { get; set; }
    }
}
