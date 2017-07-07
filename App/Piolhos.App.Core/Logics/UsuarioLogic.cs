using Piolhos.App.Core.Services;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Piolhos.App.Core.Logics
{
    public class UsuarioLogic
    {
        UsuarioService _service;

        public UsuarioLogic()
        {
            _service = new UsuarioService();
        }

        public async Task<Usuario> GetAsync(string telefone)
        {
            telefone = string.Join("", Regex.Split(telefone, @"[^\d]"));

            return await _service.GetAsync($"usuarios/{telefone}");
        }

        public async Task<bool> SaveAsync(Usuario usuario)
        {
           return await _service.PostAsync("usuarios", usuario);
        }

        public async Task<bool> SaveSenhaAsync(Usuario usuario)
        {
            return await _service.PostAsync("usuarios/senha", usuario);
        }
    }
}
