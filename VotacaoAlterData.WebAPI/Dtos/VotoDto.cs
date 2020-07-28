using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VotacaoAlterData.WebAPI.Dtos
{
    public class VotoDto
    {
        public int VotoId { get; set; }
        public DateTime DataDataCadastro { get; set; }
        public string Comentario { get; set; }
        public int ItemRecursoId { get; set; }
        public virtual ItemRecursoDto ItemRecurso { get; set; }

    }
}
