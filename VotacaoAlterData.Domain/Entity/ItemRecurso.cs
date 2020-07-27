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
        public List<Voto> Votos { get; set; }
        public Recurso Recurso { get; set; }
    }
}
