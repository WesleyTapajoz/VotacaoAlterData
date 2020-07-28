using System;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using System.Text;

namespace VotacaoAlterData.Domain.Entity
{
    public class Recurso
    {
        public int RecursoId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual List<ItemRecurso> ItensRecurso { get; set; }
        public virtual List<RecursoUser> RecursosUsers { get; set; }
        public bool Ativo { get; set; }
    }
}
