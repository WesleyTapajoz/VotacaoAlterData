using System;
using System.Collections.Generic;
using System.Text;

namespace VotacaoAlterData.Domain.Entity
{
    public class ItemRecursoVoto
    {
        public int ItemRecursoVotoId { get; set; }
        public int VotoId { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual Voto Voto { get; set; }
        public virtual ItemRecurso ItemRecurso { get; set; }
        public int ItemRecursoId { get; set; }
    }
}
