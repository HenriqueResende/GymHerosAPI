using GymHerosAPI.Model;

namespace GymHerosAPI.BusinessLayer
{
    public interface IBLLogin
    {
        public UserDto Login(LoginDto login);

        public bool SignIn(UserReg user);
    }
}
