using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreUserAuth.Models.ManageViewModels
{
    public class ManageRoleViewModel
    {
        public ApplicationUser User { get; set; }
        [Display(Name = "Role")]
        public string SelectedRoleId { get; set; }
        public SelectList IdentityRoles { get; set; }

    }
}
