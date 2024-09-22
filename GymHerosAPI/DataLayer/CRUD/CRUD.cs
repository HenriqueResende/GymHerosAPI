using System.Data.SqlClient;
using System.Data;
using GymHerosAPI.Model;
using AutoMapper.Internal;

namespace GymHerosAPI.DataLayer
{
    public class CRUD : ICRUD
    {
        private readonly IConfiguration _configuration;
        private readonly string Connection;

        public CRUD(IConfiguration configuration)
        {
            _configuration = configuration;

            Connection = _configuration?.GetConnectionString("BaseDB")?.ToString() ?? "";
        }

        #region ListQuery
        /// <summary>
        /// ListQuery
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<Model> ListQuery<Model>(string query)
        {
            var retorno = new List<Model>();

            var dt = new DataTable();

            var adapter = new SqlDataAdapter(query, Connection);

            adapter.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                var obj = Activator.CreateInstance<Model>();

                foreach (var property in typeof(Model).GetProperties())
                {
                    if (dt.Columns.Contains(property.Name))
                    {
                        var value = row[property.Name];
                        if (value != DBNull.Value)
                        {
                            property.SetValue(obj, value);
                        }
                    }
                }

                retorno.Add(obj);
            }

            return retorno;
        }
        #endregion

        #region ExecQuery
        /// <summary>
        /// ExecQuery
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public bool ExecQuery(string query)
        {
            var connection = new SqlConnection(Connection);

            var dt = new DataTable();

            using (var adapter = new SqlDataAdapter(query, connection))
            {
                adapter.Fill(dt);
            };

            return true;
        }
        #endregion

        #region ExecQueryReturnId
        /// <summary>
        /// ExecQueryReturnId
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public int ExecQueryReturnId(string query)
        {
            var dt = new DataTable();

            var adapter = new SqlDataAdapter(query, Connection);

            adapter.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                return Convert.ToInt32(row[0]);
            }

            return 0;
        }
        #endregion

        #region ExecProc
        /// <summary>
        /// ExecProc
        /// </summary>
        /// <param name="proc"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public bool ExecProc(string proc, List<Param>? param = null)
        {
            var connection = new SqlConnection(Connection);

            var dt = new DataTable();

            using (var adapter = new SqlDataAdapter(proc, connection))
            {
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                if (param != null && param.Count > 0)
                    foreach (var item in param)
                    {
                        adapter.SelectCommand.Parameters.Add(item.sqlParameter).Value = item.value;
                    }

                adapter.Fill(dt);
            };

            return true;
        }
        #endregion

        #region ListProc
        /// <summary>
        /// ListProc
        /// </summary>
        /// <param name="proc"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<Model> ListProc<Model>(string proc, List<Param>? param = null)
        {
            var retorno = new List<Model>();

            var connection = new SqlConnection(Connection);

            var dt = new DataTable();

            using (var adapter = new SqlDataAdapter(proc, connection))
            {
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                if(param != null && param.Count > 0)
                    foreach (var item in param)
                    {
                        adapter.SelectCommand.Parameters.Add(item.sqlParameter).Value = item.value;
                    }

                adapter.Fill(dt);

            };

            foreach (DataRow row in dt.Rows)
            {
                var obj = Activator.CreateInstance<Model>();

                foreach (var property in typeof(Model).GetProperties())
                {
                    if (dt.Columns.Contains(property.Name))
                    {
                        var value = row[property.Name];
                        if (value != DBNull.Value)
                        {
                            property.SetValue(obj, value);
                        }
                    }
                }

                retorno.Add(obj);
            }

            return retorno;
        }
        #endregion
    }
}
