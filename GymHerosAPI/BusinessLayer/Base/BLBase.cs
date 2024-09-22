using AutoMapper;
using GymHerosAPI.DataLayer;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Security.Claims;

namespace GymHerosAPI.BusinessLayer
{
    public abstract class BLBase<TModel, TModelDto, TModelReg> : IBLBase<TModel, TModelDto, TModelReg>
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly ICRUD _CRUD;
        private readonly IMapper _Mapper;

        public BLBase(ICRUD crud, IHttpContextAccessor accessor, IMapper mapper)
        {
            _CRUD = crud;
            _accessor = accessor;
            _Mapper = mapper;
        }

        #region Get
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TModelDto Get(int id)
        {
            var lstWorkout = _CRUD.ListQuery<TModel>($"SELECT TOP 1 * FROM {typeof(TModel).Name} WHERE Id = {id}").FirstOrDefault(Activator.CreateInstance<TModel>());

            return _Mapper.Map<TModelDto>(lstWorkout);
        }
        #endregion

        #region ListAll
        /// <summary>
        /// ListAll
        /// </summary>
        /// <returns></returns>
        public List<TModelDto> ListAll()
        {
            var where = string.Empty;

            var properties = typeof(TModel).GetProperties();
            if (properties.Any(x => x.Name.Equals("iduser", StringComparison.CurrentCultureIgnoreCase)))
            {
                where = $"WHERE IdUser = {_accessor?.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? ""}";
            }

            var lstWorkout = _CRUD.ListQuery<TModel>($"SELECT*FROM {typeof(TModel).Name} {where}");

            return _Mapper.Map<List<TModelDto>>(lstWorkout);
        }
        #endregion

        #region Insert
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="lstModel"></param>
        /// <returns></returns>
        public int Insert(List<TModelReg> lstModel)
        {
            var lstInset = _Mapper.Map<List<TModel>>(lstModel);

            //Inicia a variável que irá salvar os valores a serem inseridos
            var values = string.Empty;

            //Percorre toda a lista para criar a query
            foreach (var model in lstInset)
            {
                //A primeira coluna é sempre vazia por se tratar do id
                values += "(";

                //Pega os campos da model (colunas)
                var properties = typeof(TModel).GetProperties();

                //Percorre por todas as colunas
                foreach (var property in properties)
                {
                    //Busca o atributo configurado para o campo
                    var attribute = property.GetCustomAttribute<ColumnAttribute>() ?? new ColumnAttribute();

                    //Não adiciona o valor caso seja o id ou uma coluna que deve ser ignorada
                    if (property.Name.ToLower() == "id")
                        continue;

                    //Busca o valor
                    var value = property.GetValue(model);

                    //Caso seja uma data formata o valor para ser inserido
                    if (value != null && (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?)))
                        values += $"'{(value as DateTime?).GetValueOrDefault().ToString("yyyy-MM-dd HH:mm:ss")}',";

                    else if (property.Name.ToLower() == "iduser")
                        values += $"'{_accessor?.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? ""}',";

                    //Adiciona um valor
                    else if (value != null)
                        values += $"'{value}',";

                    //Caso seja vazio, adiciona o valor NULL
                    else
                        values += "NULL,";
                }

                //Remove a ultima , e adiciona o ) de fechamento da linha
                values = values.TrimEnd(',') + "),";
            }

            //Remove a ultima ,
            values = values.TrimEnd(',');

            //Monta a query para inserir os valores
            var query = $"INSERT INTO {typeof(TModel).Name} VALUES {values} SELECT SCOPE_IDENTITY()";

            return _CRUD.ExecQueryReturnId(query);
        }
        #endregion

        #region Update
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="lstModel"></param>
        /// <param name="updateToNull"></param>
        /// <returns></returns>
        public bool Update(List<TModel> lstModel, bool updateToNull = false)
        {
            var query = string.Empty;

            //Percorre toda a lista para criar a query
            foreach (var model in lstModel)
            {
                var id = string.Empty; //Salva o id do registro
                var values = string.Empty; //Salva o valor do campo

                //Pega os campos da model (colunas)
                var properties = typeof(TModel).GetProperties();

                //Percorre por todas as colunas
                foreach (var property in properties)
                {
                    //Busca o atributo configurado para o campo
                    var attribute = property.GetCustomAttribute<ColumnAttribute>() ?? new ColumnAttribute();

                    //Busca o valor
                    var value = property.GetValue(model);

                    //Caso seja o id, salva esse valor pula para o próximo campo
                    if (property.Name.ToLower() == "id")
                    {
                        id = (string)Convert.ChangeType(value, typeof(string));
                        continue;
                    }

                    //Caso seja uma data formata o valor para ser atualizado
                    if (value != null && (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?)))
                        values += $"[{property.Name}] = '{(value as DateTime?).GetValueOrDefault().ToString("yyyy-MM-dd HH:mm:ss")}',";

                    else if (property.Name.ToLower() == "iduser")
                        values += $"[{property.Name}] = '{_accessor?.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? ""}',";

                    //Atualiza o valor
                    else if (value != null)
                        values += $"[{property.Name}] = '{value}',";

                    //Caso desejado, atualiza o valor para NULL
                    else if (updateToNull)
                        values += $"[{property.Name}] = NULL,";
                }

                //Remove a ultima ,
                values = values.TrimEnd(',');

                //Monta a query para inserir os valores
                query += $"UPDATE {typeof(TModel).Name} SET {values} WHERE Id = {id} ";
            }

            return _CRUD.ExecQuery(query);
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool Delete(List<int> ids)
        {
            //Cria o comando
            var query = $"DELETE FROM {typeof(TModel).Name} WHERE Id IN ({string.Join(',', ids)})";

            return _CRUD.ExecQuery(query);
        }
        #endregion
    }
}
