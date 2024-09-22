using AutoMapper;
using GymHerosAPI.DataLayer;
using GymHerosAPI.Model;

namespace GymHerosAPI.BusinessLayer
{
    public class BLSeriesHistory : BLBase<SeriesHistory, SeriesHistoryDto, SeriesHistoryReg> , IBLSeriesHistory
    {

        public BLSeriesHistory(ICRUD crud, IHttpContextAccessor accessor, IMapper mapper) : base(crud, accessor, mapper)
        {

        }
    }
}
