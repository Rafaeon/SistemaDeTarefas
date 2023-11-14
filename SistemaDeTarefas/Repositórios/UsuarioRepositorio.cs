using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositórios.Interfaces;

namespace SistemaDeTarefas.Repositórios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaTarefasDBContex _dBContext;
        public UsuarioRepositorio(SistemaTarefasDBContex sistemaTarefasDBContex)
        {
            _dBContext = sistemaTarefasDBContex;
        }
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
#pragma warning disable CS8603 // Possível retorno de referência nula.
            return await _dBContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
#pragma warning restore CS8603 // Possível retorno de referência nula.
        }
        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dBContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dBContext.Usuarios.AddAsync(usuario);
            await _dBContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
           
            if(usuarioPorId == null)
            {
                throw new Exception($"Usuario para ID: {id} nao foi encontrado no banco de dados");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _dBContext.Usuarios.Update(usuarioPorId);
            await _dBContext.SaveChangesAsync();

            return usuarioPorId;

        }


        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para ID: {id} nao foi encontrado no banco de dados");
            }

            _dBContext.Usuarios.Remove(usuarioPorId);
            await _dBContext.SaveChangesAsync();

            return true;
        }

        }

    }
