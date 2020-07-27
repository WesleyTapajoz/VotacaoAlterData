using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VotacaoAlterData.WebAPI.Dtos
{
    public class RecursoDto
    {
        public int RecursoId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public List<ItemRecursoDto> ItensRecurso { get; set; }
        public List<UserDto> Users { get; set; }
    }
}
