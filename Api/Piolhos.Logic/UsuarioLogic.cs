using Piolhos.Logic.Tools;
using Piolhos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Piolhos.Logic
{
    public class UsuarioLogic
    {
        UsuarioRepository _repository;

        public UsuarioLogic()
        {
            _repository = new UsuarioRepository();
        }

        public async Task<Usuario> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<Usuario> GetByLoginAsync(Login login)
        {
            return (await _repository.SelectAsync(x => x.Telefone == login.Telefone &&
                                                       x.Senha == login.Senha
                                                  )).FirstOrDefault();
        }

        public async Task<Usuario> GetByTelefoneAsync(string telefone)
        {
            telefone = string.Join("", Regex.Split(telefone, @"[^\d]"));

            return (await _repository.SelectAsync(x => x.Telefone == telefone)).FirstOrDefault();
        }

        public async Task SaveAsync(Usuario usuario)
        {
            usuario.Telefone = string.Join("", Regex.Split(usuario.Telefone, @"[^\d]"));
            usuario.DataCadastro = DateTime.Today;

            var usuarioTelefone = await GetByTelefoneAsync(usuario.Telefone);

            if (usuario.Id == 0)
            {
                //Verificar se o telefone já existe
                if (usuarioTelefone != null)
                    throw new ArgumentException("Já existe um usuário cadastrado para este telefone.");

                //Criptografar a senha
                var crypt = new Crypt();
                usuario.Senha = crypt.Encrypt(usuario.Senha);

                //Inserir o usuário
                await _repository.InsertAsync(usuario);
            }
            else
            {
                //Verificar se o telefone já existe para outro usuário
                if (usuarioTelefone != null && (usuarioTelefone?.Id ?? 0) != usuario.Id)
                    throw new ArgumentException("Já existe um usuário cadastrado para este telefone.");

                //Recuperar o usuário do banco
                var usuarioBd = await GetAsync(usuario.Id);

                //Preencher somente as informações que deverão ser alteradas
                usuarioBd.Nome = usuario.Nome;
                usuarioBd.Email = usuario.Email;
                usuarioBd.Telefone = usuario.Telefone;

                //Alterar o usuário
                await _repository.UpdateAsync(usuarioBd);
            }
        }

        public async Task SaveSenhaAsync(Usuario usuario)
        {
            //Recuperar o usuário do banco
            var usuarioBd = await GetAsync(usuario.Id);

            if (usuarioBd != null)
            {
                //Criptografar a senha
                var crypt = new Crypt();
                usuarioBd.Senha = crypt.Encrypt(usuario.Senha);

                //Alterar o usuário
                await _repository.UpdateAsync(usuarioBd);
            }
        }
    }
}
