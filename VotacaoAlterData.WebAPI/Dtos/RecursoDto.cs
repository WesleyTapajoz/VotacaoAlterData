using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotacaoAlterData.Domain.Entity;

namespace VotacaoAlterData.WebAPI.Dtos
{
    public class RecursoDto
    {
        public int RecursoId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual List<ItemRecursoDto> ItensRecurso { get; set; }
        public virtual List<RecursoUserDto> RecursosUsers { get; set; }
        public bool Ativo { get; set; }

    }
}
