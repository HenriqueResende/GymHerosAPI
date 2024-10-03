using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using GymHerosAPI.DataLayer.LogError;
using GymHerosAPI.BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using GymHerosAPI.Model;

namespace GymHerosAPI.Controller
{
    [Route("api/ExerciseHistory")]
    [ApiController]
    public class ExerciseHistoryController : ControllerBase
    {
        public readonly IBLExerciseHistory _BLExerciseHistory;


        public ExerciseHistoryController(IBLExerciseHistory exerciseHistory)
        {
            _BLExerciseHistory = exerciseHistory;
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

                var exerciseHistory = _BLExerciseHistory.Get(id.GetValueOrDefault());

                return Ok(exerciseHistory);
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
                var lstExerciseHistory = _BLExerciseHistory.ListAll();

                return Ok(lstExerciseHistory);
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
        public IActionResult Insert(List<ExerciseHistoryReg> lstExerciseHistory)
        {
            try
            {
                return Ok(new { Status = 200, Id = _BLExerciseHistory.Insert(lstExerciseHistory) });
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
        public IActionResult Update(List<ExerciseHistory> lstExerciseHistory, bool updateToNull = false)
        {
            try
            {
                return Ok(new { Status = 200, Sucess = _BLExerciseHistory.Update(lstExerciseHistory, updateToNull) });
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
                return Ok(new { Status = 200, Sucess = _BLExerciseHistory.Delete(ids) });
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
