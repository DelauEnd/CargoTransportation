using RequestHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargoTransportation.ActionFilters
{
    public class HasManagerRole : RoleAttributeBase
    {
        protected override string RequiredRole { get; set; }

        public HasManagerRole(IRequestManager request) : base(request)
        {
            RequiredRole = "Manager";
        }
    }
}
