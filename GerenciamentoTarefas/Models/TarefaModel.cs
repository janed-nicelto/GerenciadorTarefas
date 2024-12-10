using GerenciamentoTarefas.Enums;
using System.Data.Entity.Core.Metadata.Edm;

namespace GerenciamentoTarefas.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime Data_de_Criacao { get; set; } = DateTime.Now;
        public DateTime? Data_de_Conclusao { get; set; }
        public StatusTarefa Status { get; set; }

        public static implicit operator List<object>(TarefaModel? v)
        {
            throw new NotImplementedException();
        }
    }
}
