using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VotacaoAlterData.WebAPI.Dtos
{
    public class ItemRecursoDto
    {
        public int ItemRecursoId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public int RecursoId { get; set; }
        public List<VotoDto> Votos { get; set; }
        public RecursoDto Recurso { get; set; }
    }
}
