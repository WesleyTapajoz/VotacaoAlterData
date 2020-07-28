using System;
using System.Collections.Generic;
using System.Text;

namespace VotacaoAlterData.Domain.Entity
{
    public class ItemRecurso
    {
        public int ItemRecursoId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public int RecursoId { get; set; }
        public virtual Recurso Recurso { get; set; }
        public virtual List<Voto> Votos { get; set; }

    }
}
