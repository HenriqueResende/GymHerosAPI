using AutoMapper;
using GymHerosAPI.DataLayer;
using GymHerosAPI.Model;

namespace GymHerosAPI.BusinessLayer
{
    public class BLImage : BLBase<Image, ImageDto, ImageReg> , IBLImage
    {

        public BLImage(ICRUD crud, IHttpContextAccessor accessor, IMapper mapper) : base(crud, accessor, mapper)
        {

        }
    }
}
