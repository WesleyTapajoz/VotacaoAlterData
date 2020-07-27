using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotacaoAlterData.Domain;

namespace VotacaoAlterData.WebAPI.Dtos
{
    public class UserDto
    {
        public string FullName { get; set; }
        public string Password { get; set; }
        public  string Email { get; set; }
    }
}
