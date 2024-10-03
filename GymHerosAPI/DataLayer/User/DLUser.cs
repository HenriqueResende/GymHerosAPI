using GymHerosAPI.Model;
using System.Data.SqlClient;
using System.Data;

namespace GymHerosAPI.DataLayer
{
    public class DLUser : IDLUser
    {
        private readonly ICRUD _CRUD;

        public DLUser(ICRUD crud)
        {
            _CRUD = crud;
        }

        public User GetUser(string login)
        {
            var param = new List<Param>
            {
                new Param { sqlParameter = new SqlParameter("@Login", SqlDbType.VarChar), value = login }
            };

            return _CRUD.ListProc<User>("GetUser", param).FirstOrDefault() ?? new User();
        }

        public User GetUser(int id)
        {
            var param = new List<Param>
            {
                new Param { sqlParameter = new SqlParameter("@Id", SqlDbType.Int), value = id }
            };

            return _CRUD.ListProc<User>("GetUser", param).FirstOrDefault() ?? new User();
        }

        public bool InsertUser(SignInReg user)
        {
            var param = new List<Param>
            {
                new Param { sqlParameter = new SqlParameter("@Name", SqlDbType.VarChar), value = user.Name },
                new Param { sqlParameter = new SqlParameter("@Login", SqlDbType.VarChar), value = user.Login },
                new Param { sqlParameter = new SqlParameter("@Password", SqlDbType.VarChar), value = user.Password },
                new Param { sqlParameter = new SqlParameter("@Height", SqlDbType.VarChar), value = user.Height },
                new Param { sqlParameter = new SqlParameter("@Weight", SqlDbType.VarChar), value = user.Weight }
            };

            return _CRUD.ExecProc("InsertUser", param);             
        }
    }
}
