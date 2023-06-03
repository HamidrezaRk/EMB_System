using emb_project.Entity;
using emb_project.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emb_project.Interface
{
     public interface IUser:IDisposable
     {
        #region User
        Task<List<User>> GetUsers();
        Task<User> GetUserByID(int id);
        void AddUser(User model);
        bool UpdateUser(int id, UserViewModel model);
        void DeleteUser(int id);

        #endregion

        #region Role
        Task<List<Role>> GetRoles();
        Task<Role> GetRoleByID(int id);
        void AddRoll(RoleViewModel model);
        bool UpdateRoll(int id, RoleViewModel model);
        void DeleteRole(int id);

        #endregion

        #region Login
        Task<User> Login(LoginViewModel model);

        bool ChechUserRole(string Role, string UserName);
        #endregion

    }
}
