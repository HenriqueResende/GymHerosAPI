using GymHerosAPI.Model;

namespace GymHerosAPI.DataLayer
{
    public interface ICRUD
    {
        public bool ExecQuery(string query);

        public List<Model> ListQuery<Model>(string query);

        public bool ExecProc(string proc, List<Param>? param = null);

        public int ExecQueryReturnId(string query);

        public List<Model> ListProc<Model>(string proc, List<Param>? param = null);
    }
}
