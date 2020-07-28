using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace VotacaoAlterData.Domain
{
    public class Role : IdentityRole<int>
    {
        public virtual List<UserRole> UserRoles { get; set; }

    }
}
