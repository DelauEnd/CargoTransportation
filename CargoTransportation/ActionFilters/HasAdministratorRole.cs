using RequestHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargoTransportation.ActionFilters
{
    public class HasAdministratorRole : RoleAttributeBase
    {
        protected override string RequiredRole { get; set; }

        public HasAdministratorRole(IRequestManager request) : base(request)
        {
            RequiredRole = "Administrator";
        }
    }
}
