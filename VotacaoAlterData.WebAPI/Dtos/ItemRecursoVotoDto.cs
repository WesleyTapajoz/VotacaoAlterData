using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VotacaoAlterData.WebAPI.Dtos
{
    public class ItemRecursoVotoDto
    {

        public int ItemRecursoId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public int RecursoId { get; set; }
        public virtual RecursoDto Recurso { get; set; }
        public virtual List<VotoDto> Votos { get; set; }
        public bool Active { get; set; }
        public bool Votado { get; set; }
        public int Count { get; set; }
    }
}
