using Dapper;
using RepositoryWithDapperAnd.NetCore.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryWithDapperAnd.NetCore.Services
{
    public abstract class GenericDataBaseOperation
    {        
        internal virtual int RunSqlCommand<TEntity>(TEntity entitie, string queryVerb)
        {
            var count = 0;

            using (var con = Connection.GetConnection())
            {
                try
                {
                    con.Open();
                    count = con.Execute(queryVerb, entitie);
                }
                catch (Exception)
                {
                    count = 0;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }
        internal virtual Task<int> RunSqlCommandAsync<TEntity>(TEntity entidade, string verboDaQuery)
        {

            using (var con = Connection.GetConnection())
            {
                try
                {
                    con.Open();
                    return con.ExecuteAsync(verboDaQuery, entidade);
                }
                catch (Exception)
                {

                    return default;
                }
                finally
                {
                    con.Close();
                }
            }
        }
        internal virtual int RunSqlCommand<TEntity>(string queryVerb)
        {
            using (var con = Connection.GetConnection())
            {
                try
                {
                    con.Open();
                    return con.Execute(queryVerb);
                }
                catch (Exception ex)
                {

                    return default;
                }
                finally
                {
                    con.Close();
                }
            }
        }
        internal virtual Task<int> RunSqlCommandAsync<TEntity>(string queryVerb)
        {
            using (var con = Connection.GetConnection())
            {
                try
                {
                    con.Open();
                    return con.ExecuteAsync(queryVerb);
                }
                catch (Exception)
                {

                    return default;
                }
                finally
                {
                    con.Close();
                }
            }
        }
        internal virtual IEnumerable<TEntity> GetEntitysList<TEntity>(string queryVerbs)
        {

            using (var con = Connection.GetConnection())
            {
                try
                {
                    con.Open();
                    return con.Query<TEntity>(queryVerbs);
                }
                catch (Exception ex)
                {
                    return default;
                }
                finally
                {
                    con.Close();
                }
            }
        }
        internal virtual Task<IEnumerable<TEntity>> GetEntitysListAsync<TEntity>(string queryVerb)
        {
            ;
            using (var con = Connection.GetConnection())
            {
                try
                {
                    con.Open();
                    return con.QueryAsync<TEntity>(queryVerb);
                }
                catch (Exception ex)
                {
                    return default;
                }
                finally
                {
                    con.Close();
                }
            }
        }
        internal virtual TEntity GetEntite<TEntity>(string queryVerb)
        {
            using (var con = Connection.GetConnection())
            {
                try
                {
                    con.Open();
                    return con.QuerySingle<TEntity>(queryVerb);
                }
                catch (InvalidOperationException ex)
                {
                    return default;
                }
                catch (Exception)
                {
                    return default;
                }
                finally
                {
                    con.Close();
                }
            }
        }
        internal virtual Task<TEntity> GetEntityAsync<TEntity>(string queryVerb)
        {
            using (var con = Connection.GetConnection())
            {
                try
                {
                    con.Open();
                    return con.QuerySingleAsync<TEntity>(queryVerb);
                }
                catch (InvalidOperationException)
                {
                    return default;
                }
                catch (Exception)
                {
                    return default;
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
