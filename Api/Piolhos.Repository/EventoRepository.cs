using Dapper;
using MySql.Data.MySqlClient;
using Piolhos.Repository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Piolhos.Repository
{
    public class EventoRepository : BaseRepository<Evento>
    {
        public override Task<IEnumerable<Evento>> GetAllAsync()
        {
            using (var db = new MySqlConnection(ConnectionString))
            {
                return db.QueryAsync<Evento>("select * from app_eventos");
            }
        }
    }
}
