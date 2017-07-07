using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Piolhos.Repository.Mappers.Registers;
using Piolhos.Logic;
using System.Threading.Tasks;

namespace Piolhos.Test
{
    [TestClass]
    public class UsuarioTest
    {
        UsuarioLogic _logic;

        public UsuarioTest()
        {
            try
            {
                RegisterMappings.Register();
            }
            catch (Exception)
            {
            }

            _logic = new UsuarioLogic();
        }

        [TestMethod]
        public async Task CriarUmNovoUsuario()
        {
            var usuario = new Usuario
            {
                Nome = "Luiz R. A. Coelho",
                Email = "luizracoelho@outlook.com",
                Telefone = "16988055590",
                Senha = "123456",
                DataCadastro = DateTime.Now
            };

            await _logic.SaveAsync(usuario);
        }

        [TestMethod]
        public async Task AlterarUmUsuario()
        {
            var usuario = new Usuario
            {
                Id = 2,
                Nome = "Luiz R. A. Coelho",
                Email = "luizracoelho@outlook.com",
                Telefone = "1631021155",
                Senha = "123456",
                DataCadastro = DateTime.Now
            };

            await _logic.SaveAsync(usuario);
        }

        [TestMethod]
        public async Task<Usuario> ObterUmUsuarioPeloId()
        {
            return await _logic.GetAsync(2);
        }
    }
}
