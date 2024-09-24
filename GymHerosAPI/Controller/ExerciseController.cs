using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using GymHerosAPI.DataLayer.LogError;
using GymHerosAPI.BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using GymHerosAPI.Model;

namespace GymHerosAPI.Controller
{
    [Route("api/Exercise")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        public readonly IBLExercise _BLExercise;


        public ExerciseController(IBLExercise exercise)
        {
            _BLExercise = exercise;
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

                var lstExercise = _BLExercise.Get(id.GetValueOrDefault());

                return Ok(new { Status = 200, Exercise = lstExercise });
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
                var lstExercise = _BLExercise.ListAll();

                return Ok(lstExercise);
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
        public IActionResult Insert(List<ExerciseReg> lstExercise)
        {
            try
            {
                return Ok(new { Status = 200, Id = _BLExercise.Insert(lstExercise) });
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
        public IActionResult Update(List<Exercise> lstExercise, bool updateToNull = false)
        {
            try
            {
                return Ok(new { Status = 200, Sucess = _BLExercise.Update(lstExercise, updateToNull) });
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
                return Ok(new { Status = 200, Sucess = _BLExercise.Delete(ids) });
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
