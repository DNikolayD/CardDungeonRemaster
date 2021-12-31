using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.User
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole(string roleName) : base(roleName)
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.Now;
        }

        public DateTime CreatedOn { get; init; }

        public bool IsDeleted { get; set; }

        public DateTime DeletedOn { get; set; }

        public DateTime EditedOn { get; set; }

        public bool IsEdited { get; set; }
    }
}
