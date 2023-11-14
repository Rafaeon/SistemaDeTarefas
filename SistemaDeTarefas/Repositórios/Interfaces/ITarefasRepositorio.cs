using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositórios.Interfaces
{
    public interface ITarefasRepositorio
    {
        Task<List<UsuarioModel>> BuscarTodasTarefas();
        Task<TarefaModel> BuscarPorId(int id);
        Task<TarefaModel> Adicionar(TarefaModel tarefa);

        Task<TarefaModel> Atualizar(TarefaModel tarefa, int id);
        Task<bool> Apagar(int id);

    }
}