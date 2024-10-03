using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using GymHerosAPI.DataLayer.LogError;
using GymHerosAPI.BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using GymHerosAPI.Model;

namespace GymHerosAPI.Controller
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IBLUser _BLUser;


        public UserController(IBLUser user)
        {
            _BLUser = user;
        }

        #region Update
        [HttpPost]
        [Route("Update")]
        [Authorize]
        public IActionResult Update(List<User> lstUser, bool updateToNull = false)
        {
            try
            {
                var idUser = int.Parse(HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");

                foreach (var item in lstUser)
                {
                    item.Id = idUser;
                }

                return Ok(new { Status = 200, Sucess = _BLUser.Update(lstUser, updateToNull) });
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
