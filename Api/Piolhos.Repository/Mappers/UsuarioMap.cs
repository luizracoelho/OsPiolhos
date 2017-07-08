using Dapper.FluentMap.Dommel.Mapping;

namespace Piolhos.Repository.Mappers
{
    public class UsuarioMap : DommelEntityMap<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("app_usuarios");

            Map(x => x.Id).ToColumn("id").IsKey();
            Map(x => x.Nome).ToColumn("nome");
            Map(x => x.Email).ToColumn("email");
            Map(x => x.Telefone).ToColumn("telefone");
            Map(x => x.Senha).ToColumn("senha");
            Map(x => x.DataCadastro).ToColumn("dataCadastro");
        }
    }
}
