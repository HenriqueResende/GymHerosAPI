using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using GymHerosAPI.DataLayer.LogError;
using GymHerosAPI.BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using GymHerosAPI.Model;

namespace GymHerosAPI.Controller
{
    [Route("api/ExerciseTemplate")]
    [ApiController]
    public class ExerciseTemplateController : ControllerBase
    {
        public readonly IBLExerciseTemplate _BLExerciseTemplate;


        public ExerciseTemplateController(IBLExerciseTemplate exerciseTemplate)
        {
            _BLExerciseTemplate = exerciseTemplate;
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

                var exerciseTemplate = _BLExerciseTemplate.Get(id.GetValueOrDefault());

                return Ok(exerciseTemplate);
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
                var lstExerciseTemplate = _BLExerciseTemplate.ListAll();

                return Ok(lstExerciseTemplate);
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
        public IActionResult Insert(List<ExerciseTemplateReg> lstExerciseTemplate)
        {
            try
            {
                return Ok(new { Status = 200, Id = _BLExerciseTemplate.Insert(lstExerciseTemplate) });
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
        public IActionResult Update(List<ExerciseTemplate> lstExerciseTemplate, bool updateToNull = false)
        {
            try
            {
                return Ok(new { Status = 200, Sucess = _BLExerciseTemplate.Update(lstExerciseTemplate, updateToNull) });
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
                return Ok(new { Status = 200, Sucess = _BLExerciseTemplate.Delete(ids) });
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
