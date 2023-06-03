using emb_project.Viewmodel;
using DataLayer.Entity;
using emb_project.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emb_project.Interface
{
     public interface IAdmin:IDisposable
     {
        #region Category
        // 1 Select - 2 Add - 3 Delete - 4 Update in Category 
        Task<List<Category>> GetCategories();
        //Qury show on 
        Task<Category> GetCategoriesByid(int id);
        void AddCategory(CategoryViewModel model);
        bool UpdateCategory( int id,CategoryViewModel model);
        bool DeleteCategory(int id);
        #endregion

        #region News
        // 1 Select - 2 Add - 3 Delete - 4 Update in News
        Task<List<News>> GetNews();
        Task<News> GetNewsByID(int id);
        void AddNews(NewsViewModelForInsert model);
        bool UpdateNews(int id, NewsViewModel model);
        bool DeleteNews(int id);
        void RefreshVisitCount(int id);
        #endregion
    }
}
