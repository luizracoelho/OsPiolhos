using Dapper;
using MySql.Data.MySqlClient;
using Piolhos.Repository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Piolhos.Repository
{
    public class PromocaoRepository : BaseRepository<Promocao>
    {
        public override Task<IEnumerable<Promocao>> GetAllAsync()
        {
            using (var db = new MySqlConnection(ConnectionString))
            {
                return db.QueryAsync<Promocao>("select * from app_promocoes");
            }
        }
    }
}
