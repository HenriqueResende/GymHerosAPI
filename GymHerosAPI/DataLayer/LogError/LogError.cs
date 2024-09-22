using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using GymHerosAPI.Model;

namespace GymHerosAPI.DataLayer.LogError
{
    public static class LogError
    {
        private static readonly IConfiguration _configuration;
        private static readonly string Connection;

        static LogError()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())

            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configuration = builder.Build();

            Connection = _configuration?.GetConnectionString("BaseDB")?.ToString() ?? "";
        }

        public static void SaveLog(Exception ex, string idUserStr = "")
        {
            int.TryParse(idUserStr, out int idUser);

            var param = new List<Param>
            {
                new Param { sqlParameter = new SqlParameter("@Origin", SqlDbType.VarChar), value = "API" },
                new Param { sqlParameter = new SqlParameter("@IdUser", SqlDbType.Int), value = idUser == 0 ? null : idUser },
                new Param { sqlParameter = new SqlParameter("@Message", SqlDbType.VarChar), value = ex.Message },
                new Param { sqlParameter = new SqlParameter("@StackTrace", SqlDbType.VarChar), value = ex.StackTrace ?? "" },
                new Param { sqlParameter = new SqlParameter("@Date", SqlDbType.DateTime), value = DateTime.Now }
            };

            var connection = new SqlConnection(Connection);

            var dt = new DataTable();

            using (var adapter = new SqlDataAdapter("InserLogError", connection))
            {
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                if (param != null && param.Count > 0)
                    foreach (var item in param)
                    {
                        adapter.SelectCommand.Parameters.Add(item.sqlParameter).Value = item.value;
                    }

                adapter.Fill(dt);
            };
        }
    }
}
