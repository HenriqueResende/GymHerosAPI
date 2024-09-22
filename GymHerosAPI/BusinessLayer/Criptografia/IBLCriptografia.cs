namespace GymHerosAPI.BusinessLayer
{
    public interface IBLCriptografia
    {
        public string Hash(string password);

        public bool Check(string hash, string password);

        public string CreateToken(string login, int id);
    }
}
