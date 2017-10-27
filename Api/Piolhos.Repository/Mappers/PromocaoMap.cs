using Dapper.FluentMap.Dommel.Mapping;

namespace Piolhos.Repository.Mappers
{
    public class PromocaoMap : DommelEntityMap<Promocao>
    {
        public PromocaoMap()
        {
            ToTable("app_promocoes");

            Map(x => x.DataHora).ToColumn("dataHora");
            Map(x => x.Titulo).ToColumn("titulo");
            Map(x => x.Descricao).ToColumn("descricao");
            Map(x => x.Imagem).ToColumn("imagem");
        }
    }
}
