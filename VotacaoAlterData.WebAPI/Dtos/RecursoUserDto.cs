using System;
using System.Collections.Generic;
using System.Text;

namespace VotacaoAlterData.WebAPI.Dtos
{
    public class RecursoUserDto
    {
        public int RecursoUserId { get; set; }
        public int Id { get; set; }
        public virtual UserDto User  { get; set; }
        public int RecursoId { get; set; }
        public virtual RecursoDto Recurso { get; set; }
    }
}
