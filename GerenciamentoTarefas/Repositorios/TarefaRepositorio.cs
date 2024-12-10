using GerenciamentoTarefas.Data;
using GerenciamentoTarefas.Enums;
using GerenciamentoTarefas.Models;
using GerenciamentoTarefas.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GerenciamentoTarefas.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly GerenciamentoTarefasDBContext _dbContext;
        public TarefaRepositorio(GerenciamentoTarefasDBContext gerenciamentoTarefasDBContext)
        {
            _dbContext = gerenciamentoTarefasDBContext;
        }
        public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaPorID = await LerporId(id);

            if (tarefaPorID == null)
            {
                throw new Exception($"A Tarefa para o ID: {id} não foi encontrada.");
            }


            if (tarefa.Data_de_Conclusao > tarefaPorID.Data_de_Criacao)
            {
                tarefaPorID.Titulo = tarefa.Titulo;
                tarefaPorID.Descricao = tarefa.Descricao;
                tarefaPorID.Data_de_Conclusao = tarefa.Data_de_Conclusao;
                tarefaPorID.Status = tarefa.Status;
                _dbContext.Tarefas.Update(tarefaPorID);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"A Data de conclusão da Tarefa: {id} não pode ser menor que a data de criação.");
            }
            return tarefaPorID;
        }

        public async Task<TarefaModel> Criar(TarefaModel tarefa)
        {

            if (tarefa.Data_de_Conclusao > tarefa.Data_de_Criacao)
            {
                await _dbContext.Tarefas.AddAsync(tarefa);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("A Data de conclusão da Tarefa não pode ser menor que a data de criação.");
            }
            return tarefa;
        }

        public async Task<bool> Deletar(int id)
        {
            TarefaModel tarefaPorID = await LerporId(id);
            if (tarefaPorID == null)
            {
                throw new Exception($"A Tarefa para o ID: {id} não foi encontrada.");
            }
            _dbContext.Tarefas.Remove(tarefaPorID);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<TarefaModel> LerporId(int id)
        {
            return await _dbContext.Tarefas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TarefaModel>> LerporStatus(StatusTarefa status)
        { 
            return await _dbContext.Tarefas.Where(x => x.Status == status).ToListAsync();
        }

        public async Task<List<TarefaModel>> LerTodasTarefas()
        {
            return await _dbContext.Tarefas.ToListAsync();
        }
    }
}
