using AutoMapper;
using GymHerosAPI.DataLayer;
using GymHerosAPI.Model;

namespace GymHerosAPI.BusinessLayer
{
    public class BLExerciseHistory : BLBase<ExerciseHistory, ExerciseHistoryDto, ExerciseHistoryReg> , IBLExerciseHistory
    {

        public BLExerciseHistory(ICRUD crud, IHttpContextAccessor accessor, IMapper mapper) : base(crud, accessor, mapper)
        {

        }
    }
}
