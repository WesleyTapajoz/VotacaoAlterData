using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VotacaoAlterData.WebAPI.Dtos
{
    public class VotarDto
    {
        public int RecursoId { get; set; }
        public int ItemRecursoId { get; set; }
        public string Comentario { get; set; }

    }
}
