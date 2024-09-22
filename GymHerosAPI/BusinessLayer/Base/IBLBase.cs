namespace GymHerosAPI.BusinessLayer
{
    public interface IBLBase<TModel, TModelDto, TModelReg>
    {
        TModelDto Get(int id);

        public List<TModelDto> ListAll();

        int Insert(List<TModelReg> lstModel);

        public bool Update(List<TModel> lstModel, bool updateToNull = false);

        public bool Delete(List<int> ids);
    }
}
