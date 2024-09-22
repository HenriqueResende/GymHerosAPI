using System.Data.SqlClient;

namespace GymHerosAPI.Model
{
    public class Param
    {
        public SqlParameter sqlParameter { get; set; }

        public object value { get; set; }
    }
}
