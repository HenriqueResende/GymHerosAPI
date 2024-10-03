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
            //Verifica as regras do login, caso tenha algum erro envia um erro de formato com a mensagem o descrevendo
            if (login.Login.IsNullOrEmpty())
                throw new FormatException("Informe o login.");

            else if (login.Password.IsNullOrEmpty())
                throw new FormatException("Informe a Senha.");

            //Busca o usuário para realizar o login
            var user = _DLUser.GetUser(login.Login);

            //Retorna um erro caso o usuário não exista
            if (user == null || user?.Id == null || user.Id == 0)
                throw new FormatException("Usuário não cadastrado.");

            //Verifica se as senhas batem
            if (_criptografia.Check(user.Password ?? "", login.Password))
            {
                //Gera um token para acessar a API
                user.Token = _criptografia.CreateToken(login.Login, user.Id.GetValueOrDefault());

                //Faz o mapper para transformar a model para a dto (apenas os valores que o usuário visualiza)
                return _Mapper.Map<UserDto>(user);
            }
            else //Retona erro de senha inválida
                throw new FormatException("Senha inválida.");
        }
        #endregion

        #region SignIn
        /// <summary>
        /// Cadastro de novo usuários
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool SignIn(SignInReg user)
        {
            //Verifica as regras do login, caso tenha algum erro envia um erro de formato com a mensagem o descrevendo
            if (user.Login.IsNullOrEmpty())
                throw new FormatException("Informe o login.");

            if (user.Login.Length < 3)
                throw new FormatException("O login deve conter no mínimo 3 caracteres.");

            var userDb = _DLUser.GetUser(user.Login); //Busca o usuário pelo login para não cadastrar duplicados
            if (userDb != null && userDb?.Id != null && userDb?.Id != 0)
                throw new FormatException("Login já cadastrado.");

            if (user.Password.IsNullOrEmpty())
                throw new FormatException("Informe a senha.");

            if (user.Password.Length < 6)
                throw new FormatException("A senha deve conter no mínimo 6 caracteres.");

            if (user.Name.IsNullOrEmpty())
                throw new FormatException("Informe o nome.");

            //Criptografa a senha para armazenar no banco
            user.Password = _criptografia.Hash(user.Password);

            //Insere o usuário
            return _DLUser.InsertUser(user);
        }
        #endregion
    }
}
