using Dapper.FluentMap.Dommel.Mapping;

namespace Piolhos.Repository.Mappers
{
    public class EmpresaMap : DommelEntityMap<Empresa>
    {
        public EmpresaMap()
        {
            ToTable("app_empresas");

            Map(x => x.Id).ToColumn("id").IsKey();
            Map(x => x.Nome).ToColumn("nome");
            Map(x => x.Categoria).ToColumn("categoria");
            Map(x => x.Descricao).ToColumn("descr");
            Map(x => x.Latitude).ToColumn("lat");
            Map(x => x.Longitude).ToColumn("lng");
            Map(x => x.Telefone).ToColumn("tel");
            Map(x => x.Slogan).ToColumn("slogan");
            Map(x => x.Site).ToColumn("site");
            Map(x => x.Facebook).ToColumn("facebook");
            Map(x => x.Endereco).ToColumn("endereco");
            Map(x => x.Beneficio1).ToColumn("benef1");
            Map(x => x.Beneficio2).ToColumn("benef2");
            Map(x => x.Beneficio3).ToColumn("benef3");
            Map(x => x.QuantAvaliacoes).ToColumn("quant_avaliacao");
            Map(x => x.ValorAvaliacoes).ToColumn("valor_avaliacao");
            Map(x => x.Logo).ToColumn("logo");
            Map(x => x.Imagem).ToColumn("imagem");
        }
    }
}
