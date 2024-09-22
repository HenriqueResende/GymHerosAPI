using AutoMapper;
using GymHerosAPI.DataLayer;
using GymHerosAPI.Model;

namespace GymHerosAPI.BusinessLayer
{
    public class BLWorkoutHistory : BLBase<WorkoutHistory, WorkoutHistoryDto, WorkoutHistoryReg> , IBLWorkoutHistory
    {

        public BLWorkoutHistory(ICRUD crud, IHttpContextAccessor accessor, IMapper mapper) : base(crud, accessor, mapper)
        {

        }
    }
}
