using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreUserAuth.Models.ManageViewModels
{
    public class ManageRoleViewModel
    {
        public ApplicationUser User { get; set; }
        public SelectList IdentityRoles { get; set; }

    }
}
