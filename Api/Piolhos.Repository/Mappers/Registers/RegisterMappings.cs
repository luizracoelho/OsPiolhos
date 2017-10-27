using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;

namespace Piolhos.Repository.Mappers.Registers
{
    public class RegisterMappings
    {
        public static void Register()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new EmpresaMap());
                config.AddMap(new UsuarioMap());
                config.AddMap(new EventoMap());
                config.AddMap(new PromocaoMap());

                config.ForDommel();
            });
        }
    }
}
