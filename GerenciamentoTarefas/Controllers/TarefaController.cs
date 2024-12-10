using GerenciamentoTarefas.Enums;
using GerenciamentoTarefas.Models;
using GerenciamentoTarefas.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;
        public TarefaController(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> LerTodasTarefas()
        {
            try
            {
                List<TarefaModel> tarefas = await _tarefaRepositorio.LerTodasTarefas();
                return Ok(tarefas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao ler todas as tarefas");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TarefaModel>>> LerporId(int id)
        {
            TarefaModel tarefas = await _tarefaRepositorio.LerporId(id);
            return Ok(tarefas);
        }

        [HttpGet("Status/{status}")]
        public async Task<ActionResult<List<TarefaModel>>> LerporStatus(StatusTarefa status)
        {
            List<TarefaModel> tarefas = await _tarefaRepositorio.LerporStatus(status);
            return Ok(tarefas);
        }


        [HttpPost]
        public async Task<ActionResult<TarefaModel>> Criar([FromBody] TarefaModel tarefaModel)
        {
            TarefaModel tarefa =  await _tarefaRepositorio.Criar(tarefaModel);
            return Ok(tarefa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TarefaModel>> Atualizar ([FromBody] TarefaModel tarefaModel, int id)
        {
            tarefaModel.Id = id;
            TarefaModel tarefa = await _tarefaRepositorio.Atualizar(tarefaModel, id);
            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TarefaModel>> Deletar(int id)
        {
            bool deletado = await _tarefaRepositorio.Deletar(id);
            return Ok(deletado);
        }

    }
}
