using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using GymHerosAPI.DataLayer.LogError;
using GymHerosAPI.BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using GymHerosAPI.Model;

namespace GymHerosAPI.Controller
{
    [Route("api/Series")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        public readonly IBLSeries _BLSeries;


        public SeriesController(IBLSeries series)
        {
            _BLSeries = series;
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

                var series = _BLSeries.Get(id.GetValueOrDefault());

                return Ok(series);
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
                var lstSeries = _BLSeries.ListAll();

                return Ok(lstSeries);
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
        public IActionResult Insert(List<SeriesReg> lstSeries)
        {
            try
            {
                return Ok(new { Status = 200, Id = _BLSeries.Insert(lstSeries) });
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
        public IActionResult Update(List<Series> lstSeries, bool updateToNull = false)
        {
            try
            {
                return Ok(new { Status = 200, Sucess = _BLSeries.Update(lstSeries, updateToNull) });
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
                return Ok(new { Status = 200, Sucess = _BLSeries.Delete(ids) });
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
