using RepositoryWithDapperAnd.NetCore.Interfaces.Generic;
using RepositoryWithDapperAnd.NetCore.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryWithDapperAnd.NetCore.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private string[] memberGroup = EntityStructure<T>.ReturnEntityMembersList();
        private string memberId = EntityStructure<T>.ReturnEntityMembersList()[0];

        public string Table { get; private set; }

        public RepositoryBase()
        {
            Table = EntityStructure<T>.ReturnTableOrAttributeName();
        }
        public RepositoryBase(string table)
        {
            Table = table;
        }

        public async virtual Task<int> RegisterAsync(T entidade)
        {
            return await GenericDataBaseOperation.RunSqlCommandAsync(entidade, ReturnInsertText());
        }
      
        public async virtual Task<int> UpdateAsync(T entidade)
        {
            return await GenericDataBaseOperation.RunSqlCommandAsync(entidade, ReturnUpdateText(entidade));
        }       
        public async virtual Task<int> DeleteAsync(T entidade)
        {
            return await GenericDataBaseOperation.RunSqlCommandAsync<T>(ReturnDeleteText(entidade));
        }      
        public async virtual Task<T> GetAsync(int id)
        {
            return await GenericDataBaseOperation.GetEntityAsync<T>(ReturnSelectText(id));
        }   
        public async virtual Task<IEnumerable<T>> GetAllAsync()
        {
            return await GenericDataBaseOperation.GetEntitysListAsync<T>(ReturnSelectText());
        }      
        public async virtual Task<T> GetWithPersonalFilterAsync(string campo, object valor)
        {
            return await GenericDataBaseOperation.GetEntityAsync<T>(ReturnSelectText(campo, valor));
        }      
        public async virtual Task<IEnumerable<T>> GetListWithPersonalFilterAsync(string campo, object valor)
        {
            return await GenericDataBaseOperation.GetEntitysListAsync<T>(ReturnSelectText(campo, valor));
        } 
        #region Auxiliar Method
        protected string ReturnSelectText()
        {
            return string.Format("SELECT * FROM {0}", Table);
        }
        protected string ReturnSelectText(int id)
        {
            return string.Format("SELECT * FROM {0} WHERE {1} = {2} ", Table, memberId, id);
        }
        protected string ReturnSelectText(string field, object value)
        {

            return string.Format("SELECT * FROM {0} WHERE {1} = {2}", Table, field, AddSingleQuotesToTypeString(value));
        }
        protected string ReturnSelectText(string filtro)
        {
            return string.Format("SELECT * FROM {0} WHERE {1}", Table, filtro);
        }

        protected string ReturnInsertText(int index = 1)
        {
            return string.Format("INSERT INTO {0} ({1}) VALUES ({2}) SELECT CAST(SCOPE_IDENTITY() as INT)",
                Table,
                AssemblesGroupMembers("", index),
                AssemblesGroupMembers("@", index));
        }
        protected string ReturnUpdateText(T obj, int index = 1)
        {
            return string.Format(
              "UPDATE {0} SET {1} WHERE {2} = {3}",
              Table,
              AssemblesGroupMembersUpdate(index),
              memberId, ReturnValueId(obj));
        }

        protected string ReturnDeleteText(T obj)
        {
            return string.Format(
                  "DELETE FROM {0} WHERE {1} = {2}",
                  Table,
                  memberId,
                  ReturnValueId(obj));
        }
        protected string AssemblesGroupMembers(string caracter = "", int index = 1)
        {
            string textoRetorno = string.Empty;

            for (int i = index; i < memberGroup.Length; i++)
            {
                string addVirgula = i == memberGroup.Length - 1 ? "" : ", ";
                textoRetorno += caracter + memberGroup[i] + addVirgula; ;
            }
            return textoRetorno;
        }
        protected string AssemblesGroupMembersUpdate(int index = 1)
        {
            string textoRetorno = string.Empty;

            for (int i = index; i < memberGroup.Length; i++)
            {
                string addVirgula = i == memberGroup.Length - 1 ? " " : ", ";
                textoRetorno += memberGroup[i] + " = " + "@" + memberGroup[i] + addVirgula;
            }
            return textoRetorno;
        }
        protected int ReturnValueId(T value)
        {
            var arrayPropertiesClass = value.GetType().GetProperties();
            foreach (var propertie in arrayPropertiesClass)
            {
                if (propertie.Name.Substring(0, 2).ToUpper().Contains("ID"))
                {
                    return (int)propertie.GetValue(value);
                }
            }
            return 0;
        }
        protected string AddSingleQuotesToTypeString(object valor)
        {
            if (valor is string)
            {
                return string.Format("'{0}'", valor);
            }
            else
            {
                return string.Format("{0}", valor);
            }
        }
        #endregion

    }
}
