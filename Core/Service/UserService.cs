using DataLayer.Context;
using emb_project.Entity;
using emb_project.Interface;
using emb_project.Security;
using emb_project.Viewmodel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emb_project.Service
{
    public class UserService : IUser
    {
        // ctor
        private DataBaseDbContext _context;

        public UserService(DataBaseDbContext context)
        {
            _context = context;
        }
        
        #region User
        public void AddUser(User model)
        {
           if(!CheckUserName(model.UserName))
           {
                User user = new User
                {
                    FullName = model.FullName,
                    BirthDate = model.BirthDate,
                    Date_Register = model.Date_Register,
                    UserName = model.UserName,
                    Password = Hash_EnCode.GetHashCode(model.Password),
                    mobile = model.mobile,
                    RoleId_Fk = model.RoleId_Fk,
                    UserAvatar = model.UserAvatar
                };
                _context.Add(user);
                _context.SaveChanges();
           }
          

        }
        //
        public async Task<User> GetUserByID(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.Include(r => r.Role).OrderBy(u => u.FullName).ToListAsync();
        }
        //
        public void DeleteUser(int id)
        {
            User user = _context.Users.Find(id);
            if(user!=null)
            {
                _context.Remove(user);
                _context.SaveChanges();
            }
        }
        //
        public bool UpdateUser(int id, UserViewModel model)
        {
            User user = _context.Users.Find(id);
            if(user!=null)
            {
                user.FullName = model.FullName;
                user.BirthDate = model.BirthDate;
                user.mobile = model.mobile;
                user.RoleId_Fk = model.RoleId_Fk;
                user.UserAvatar = model.UserAvatar;
                if (user.Password != null)
                    user.Password = model.Password;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }
        #endregion

        #region Role

        public void AddRoll(RoleViewModel model)
        {
            Role role = new Role
            {
                Name = model.Name,
                Title=model.Title
            };
            _context.Add(role);
            _context.SaveChanges();
            
        }

        public void DeleteRole(int id)
        {
            Role role = _context.Roles.Find(id);
            if(role != null)
            {
                _context.Remove(role);
                _context.SaveChanges();
            
            }
        }

        public  async Task<Role> GetRoleByID(int id)
        {

            return await _context.Roles.FindAsync(id);
        }

        public async Task<List<Role>> GetRoles()
        {
            return await _context.Roles.OrderBy(c => c.Title).ToListAsync();
        }

        public bool UpdateRoll(int id, RoleViewModel model)
        {
            Role role = _context.Roles.Find(id);
            if(role !=null)
            {
                role.Name = model.Name;
                role.Title = model.Title;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }
        #endregion

        #region Login
        //Show Praperti ViewModel In View
        public Task<User> Login(LoginViewModel model)
        {
            throw new NotImplementedException();
        }
        //Chech equality UserName == Role User
        public bool ChechUserRole(string Role, string UserName)
        {
            throw new NotImplementedException();
        }

        #endregion


        //Chech In DataBace UserName
        public bool CheckUserName (string UserName)
        {
            return _context.Users.Any(c => c.UserName == UserName);
        }

        public void Dispose()
        {
            if (_context == null)
                _context.Dispose();
        }

      
    }
}
