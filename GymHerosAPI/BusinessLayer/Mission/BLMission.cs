using AutoMapper;
using GymHerosAPI.DataLayer;
using GymHerosAPI.Model;

namespace GymHerosAPI.BusinessLayer
{
    public class BLMission : BLBase<Mission, MissionDto, MissionReg> , IBLMission
    {

        public BLMission(ICRUD crud, IHttpContextAccessor accessor, IMapper mapper) : base(crud, accessor, mapper)
        {

        }
    }
}
