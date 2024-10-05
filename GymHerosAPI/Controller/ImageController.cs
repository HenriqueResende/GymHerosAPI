using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using GymHerosAPI.DataLayer.LogError;
using GymHerosAPI.BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using GymHerosAPI.Model;

namespace GymHerosAPI.Controller
{
    [Route("api/Image")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        public readonly IBLImage _BLImage;


        public ImageController(IBLImage image)
        {
            _BLImage = image;
        }

        #region Get
        [HttpGet]
        [Route("Get")]
        [Authorize]
        public IActionResult Get(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return Ok(new { Status = 400, Mensagem = "Informe o id." });

                var image = _BLImage.Get(id.GetValueOrDefault());

                return Ok(image);
            }
            catch (Exception ex)
            {
                LogError.SaveLog(ex, User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");

                return BadRequest(new { Status = 500, Mensagem = "Algo deu errado, tente novamente mais tarde!" });
            }
        }
        #endregion

        #region ListAll
        [HttpGet]
        [Route("ListAll")]
        [Authorize]
        public IActionResult ListAll()
        {
            try
            {
                var lstImage = _BLImage.ListAll();

                return Ok(lstImage);
            }
            catch (Exception ex)
            {
                LogError.SaveLog(ex, User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");

                return BadRequest(new { Status = 500, Mensagem = "Algo deu errado, tente novamente mais tarde!" });
            }
        }
        #endregion

        #region Insert
        [HttpPost]
        [Route("Insert")]
        [Authorize]
        public IActionResult Insert(List<ImageReg> lstImage)
        {
            try
            {
                return Ok(new { Status = 200, Id = _BLImage.Insert(lstImage) });
            }
            catch (Exception ex)
            {
                LogError.SaveLog(ex, User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");

                return BadRequest(new { Status = 500, Mensagem = "Algo deu errado, tente novamente mais tarde!" });
            }
        }
        #endregion

        #region Update
        [HttpPost]
        [Route("Update")]
        [Authorize]
        public IActionResult Update(List<Image> lstImage, bool updateToNull = false)
        {
            try
            {
                return Ok(new { Status = 200, Sucess = _BLImage.Update(lstImage, updateToNull) });
            }
            catch (Exception ex)
            {
                LogError.SaveLog(ex, User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");

                return BadRequest(new { Status = 500, Mensagem = "Algo deu errado, tente novamente mais tarde!" });
            }
        }
        #endregion

        #region Delete
        [HttpDelete]
        [Route("Delete")]
        [Authorize]
        public IActionResult Delete(List<int> ids)
        {
            try
            {
                return Ok(new { Status = 200, Sucess = _BLImage.Delete(ids) });
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
