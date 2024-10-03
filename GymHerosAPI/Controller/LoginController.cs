using GymHerosAPI.Model;
using Microsoft.AspNetCore.Mvc;
using GymHerosAPI.BusinessLayer;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using GymHerosAPI.DataLayer;
using GymHerosAPI.DataLayer.LogError;

namespace GymHerosAPI.Controller
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public readonly IBLLogin _Login;
        public readonly IDLUser _DLUser;


        public LoginController(IBLLogin login, IDLUser dLUser)
        {
            _Login = login;
            _DLUser = dLUser;
        }

        #region Login
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginDto login)
        {
            try
            {
                var user = _Login.Login(login);

                return Ok(new { Status = 200, User = user });
            }
            catch (FormatException Ex)
            {
                return BadRequest(new { Status = 400, Mensagem = Ex.Message });
            }
            catch (Exception ex)
            {
                LogError.SaveLog(ex);

                return BadRequest(new { Status = 500, Mensagem = "Algo deu errado, tente novamente mais tarde!" });
            }
        }
        #endregion

        #region SignIn
        [HttpPost]
        [Route("signin")]
        public IActionResult SignIn(SignInReg usuario)
        {
            try
            {
                if (_Login.SignIn(usuario))
                    return Ok(new { Status = 200, Mensagem = "Usuário cadastrado com sucesso." });

                else
                    return BadRequest(new { Status = 500, Mensagem = "Algo deu errado, tente novamente mais tarde!" });
            }
            catch (FormatException Ex)
            {
                return BadRequest(new { Status = 400, Mensagem = Ex.Message });
            }
            catch (Exception ex)
            {
                LogError.SaveLog(ex);

                return BadRequest(new { Status = 500, Mensagem = "Algo deu errado, tente novamente mais tarde!" });
            }
        }
        #endregion

        #region GetLoggedInUser
        [HttpGet]
        [Route("GetLoggedInUser")]
        [Authorize]
        public IActionResult GetLoggedInUser()
        {
            try
            {
                var idUserStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
                int.TryParse(idUserStr, out int idUser);

                return Ok(new { Status = 200, User = _DLUser.GetUser(idUser) });
            }
            catch (FormatException Ex)
            {
                return BadRequest(new { Status = 400, Mensagem = Ex.Message });
            }
            catch (Exception ex)
            {
                LogError.SaveLog(ex, User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");

                return BadRequest(new { Status = 500, Mensagem = "Algo deu errado, tente novamente mais tarde!" });
            }
        }
        #endregion
    }
}
