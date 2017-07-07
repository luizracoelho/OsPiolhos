using Piolhos.Logic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Piolhos.Api.Controllers
{
    public class UsuariosController : ApiController
    {
        UsuarioLogic _logic;

        public UsuariosController()
        {
            _logic = new UsuarioLogic();
        }

        // GET: api/Usuarios/5
        public async Task<Usuario> Get(string id)
        {
            //Recuperar o usuário
            var usuario = await _logic.GetByTelefoneAsync(id);

            //Esconder a senha do usuário
            if (usuario != null)
                usuario.Senha = "******";

            //Retornar o usuário
            return usuario;
        }

        // POST: api/Usuarios
        public async Task Post(Usuario usuario)
        {
            await _logic.SaveAsync(usuario);
        }

        // POST: api/Usuarios/senha
        [HttpPost, Route("api/usuarios/senha")]
        public async Task PostSenha(Usuario usuario)
        {
            await _logic.SaveSenhaAsync(usuario);
        }
    }
}
