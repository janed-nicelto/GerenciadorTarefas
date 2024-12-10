using GerenciamentoTarefas.Enums;
using GerenciamentoTarefas.Models;

namespace GerenciamentoTarefas.Repositorios.Interfaces
{
    public interface ITarefaRepositorio
    {
        Task<List<TarefaModel>> LerTodasTarefas();
        Task<TarefaModel> LerporId(int id);
        Task<List<TarefaModel>> LerporStatus(StatusTarefa status);
        Task<TarefaModel> Criar (TarefaModel tarefa);
        Task<TarefaModel> Atualizar (TarefaModel tarefa, int id);
        Task<bool> Deletar (int id);
    }
}
