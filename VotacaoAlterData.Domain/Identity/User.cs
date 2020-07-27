using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using VotacaoAlterData.Domain.Entity;

namespace VotacaoAlterData.Domain
{
    public class User : IdentityUser<int>
    {
        public string FullName { get; set; }
        public List<UserRole> UserRoles { get; set; }
        public List<RecursoUser> RecursosUsers { get; set; }

    }
}
