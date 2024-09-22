using AutoMapper;
using GymHerosAPI.DataLayer;
using GymHerosAPI.Model;
using Microsoft.IdentityModel.Tokens;

namespace GymHerosAPI.BusinessLayer
{
    public class BLLogin : IBLLogin
    {
        private readonly IDLUser _DLUser;
        private readonly IBLCriptografia _criptografia;
        private readonly IMapper _Mapper;

        public BLLogin(IDLUser dLUser, IBLCriptografia criptografia, IMapper mapper)
        {
            _DLUser = dLUser;
            _criptografia = criptografia;
            _Mapper = mapper;
        }

        #region Login
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public UserDto Login(LoginDto login)
        {
            if (login.Login.IsNullOrEmpty())
                throw new FormatException("Informe o login.");

            else if (login.Password.IsNullOrEmpty())
                throw new FormatException("Informe a Senha.");

            var user = _DLUser.GetUser(login.Login);

            if (user == null || user?.Id == null || user.Id == 0)
                throw new FormatException("Usuário não cadastrado.");


            if (_criptografia.Check(user.Password ?? "", login.Password))
            {
                user.Token = _criptografia.CreateToken(login.Login, user.Id.GetValueOrDefault());

                return _Mapper.Map<UserDto>(user);
            }
            else
                throw new FormatException("Login ou senha inválidos.");
        }
        #endregion

        #region SignIn
        /// <summary>
        /// SignIn
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool SignIn(UserReg user)
        {
            if (user.Login.IsNullOrEmpty())
                throw new FormatException("Informe o login.");

            if (user.Login.Length < 3)
                throw new FormatException("O login deve conter no mínimo 3 caracteres.");

            var userDb = _DLUser.GetUser(user.Login);
            if (userDb != null && userDb?.Id != null && userDb?.Id != 0)
                throw new FormatException("Login já cadastrado.");

            if (user.Password.IsNullOrEmpty())
                throw new FormatException("Informe a senha.");

            if (user.Password.Length < 6)
                throw new FormatException("A senha deve conter no mínimo 6 caracteres.");

            if (user.Name.IsNullOrEmpty())
                throw new FormatException("Informe o nome.");

            user.Password = _criptografia.Hash(user.Password);

            return _DLUser.InsertUser(user);
        }
        #endregion
    }
}
