using emb_project.Interface;
using emb_project.Viewmodel;
using DataLayer.Context;
using DataLayer.Entity;
using emb_project.Entity;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public class AdminService:IAdmin
    {
        private DataBaseDbContext _context;
        public AdminService(DataBaseDbContext context)
        {
            _context = context;
        }
        //
        #region Category
        public void AddCategory(CategoryViewModel model)
        {
            Category category = new Category
            {
                Title=model.Title,
                Description=model.Description
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public bool DeleteCategory(int id)
        {
            Category category = _context.Categories.Find(id);

            if (category != null)
            {
                _context.Remove(category);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _context.Categories.OrderBy(c => c.Title).ToListAsync();
        }
            
        public async Task<Category> GetCategoriesByid(int id)
        {
            return await _context.Categories.FindAsync(id); 
           
        }

        public bool UpdateCategory(int id, CategoryViewModel model)
        {
            Category category = _context.Categories.Find(id);
            {
                if(category!=null)
                {
                    category.Title = model.Title;
                    category.Description = model.Description;
                    _context.SaveChanges();
                    return true;

                }
               else
               {
                    return false;
                    
               }    
                    
            }
        }


        #endregion

        #region News
        public void AddNews(NewsViewModelForInsert model)
        {
            News news = new News
            {
                Abstract=model.Abstract,
                Content=model.Content,
                IndexImage=model.IndexImage,
                NewsTime=model.NewsTime,
                NewsDate=model.NewsDate,
                UserID_fk=model.UserID_fk,
                VisitCount=model.VisitCount,
                Title=model.Title,
                CategoryID_fk=model.CategoryID_fk,
                NewsType=model.NewsType,
                PlaceNewsID=model.PlaceNewsID
            };
            _context.Add(news);
            _context.SaveChanges();
        }
        public  async Task<List<News>> GetNews()
        {
            return await _context.News.Include(c=>c.Categories).OrderBy(c => c.Title).ToListAsync();
        }
        public async Task<News> GetNewsByID(int id)
        {
            return await _context.News.FindAsync(id);
        }
        public bool DeleteNews(int id)
        {
            throw new NotImplementedException();
        }
        public bool UpdateNews(int id, NewsViewModel model)
        {
            throw new NotImplementedException();
        }
       
        public void RefreshVisitCount(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        public void Dispose()
        {
            if (_context == null)
                _context.Dispose();
        }

    }
}
