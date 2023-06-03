using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emb_project.Viewmodel
{
    public class RoleViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نقش سیستمی")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Display(Name = "نقش")]
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

    }
}
