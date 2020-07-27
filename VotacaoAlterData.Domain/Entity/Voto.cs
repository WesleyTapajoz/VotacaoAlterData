using System;
using System.Collections.Generic;
using System.Text;

namespace VotacaoAlterData.Domain.Entity
{
   public class Voto
    {
        public int VotoId { get; set; }
        public int ItemRecursoId { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Comentario { get; set; }
        public ItemRecurso ItemRecurso { get; set; }
    }
}
