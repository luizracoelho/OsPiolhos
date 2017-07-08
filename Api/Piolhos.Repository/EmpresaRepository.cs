using System.Collections.Generic;
using System.Threading.Tasks;
using Piolhos.Repository.Base;
using MySql.Data.MySqlClient;
using Dapper;

namespace Piolhos.Repository
{
    public class EmpresaRepository : BaseRepository<Empresa>
    {
        public override Task<IEnumerable<Empresa>> GetAllAsync()
        {
            using (var db = new MySqlConnection(ConnectionString))
            {
                return db.QueryAsync<Empresa>("select * from app_empresas");
            }
        }
    }
}
