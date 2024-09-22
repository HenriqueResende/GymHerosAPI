using AutoMapper;
using GymHerosAPI.DataLayer;
using GymHerosAPI.Model;

namespace GymHerosAPI.BusinessLayer
{
    public class BLExerciseTemplate : BLBase<ExerciseTemplate, ExerciseTemplateDto, ExerciseTemplateReg> , IBLExerciseTemplate
    {

        public BLExerciseTemplate(ICRUD crud, IHttpContextAccessor accessor, IMapper mapper) : base(crud, accessor, mapper)
        {

        }
    }
}
