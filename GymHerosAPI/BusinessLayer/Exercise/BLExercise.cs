using AutoMapper;
using GymHerosAPI.DataLayer;
using GymHerosAPI.Model;

namespace GymHerosAPI.BusinessLayer
{
    public class BLExercise : BLBase<Exercise, ExerciseDto, ExerciseReg> , IBLExercise
    {

        public BLExercise(ICRUD crud, IHttpContextAccessor accessor, IMapper mapper) : base(crud, accessor, mapper)
        {

        }
    }
}
