using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emb_project.Viewmodel
{
     public class PlaceNewsInIndexPageViewModel
     {
        public int id { get; set; }
        public string Title { get; set; }
        public List<PlaceNewsInIndexPageViewModel> GetPlaceNewsInIndexPageViewModel()
        {
            var model = new List<PlaceNewsInIndexPageViewModel>
            {
                new PlaceNewsInIndexPageViewModel{ id = 1, Title = "محل خبر (آخرین اخبار وبلاگ)" },
 
            };
            return model;
        }


    }
}
