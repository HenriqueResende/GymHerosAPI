using GymHerosAPI.Model;

namespace GymHerosAPI.DataLayer
{
    public interface IDLUser
    {
        User GetUser(string login);
        User GetUser(int id);

        bool InsertUser(SignInReg user);
    }
}
