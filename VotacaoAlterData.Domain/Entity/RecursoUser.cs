using System;
using System.Collections.Generic;
using System.Text;

namespace VotacaoAlterData.Domain.Entity
{
    public class RecursoUser
    {
        public int RecursoUserId { get; set; }
        public int Id { get; set; }
        public User User  { get; set; }
        public int RecursoId { get; set; }
        public Recurso Recurso { get; set; }
    }
}
