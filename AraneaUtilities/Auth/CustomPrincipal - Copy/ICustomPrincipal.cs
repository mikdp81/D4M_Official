using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AraneaUtilities.Authorization.CustomPrincipal
{
    public interface ICustomPrincipal
    {
        IPrincipal Principal { get; }
        IIdentity Identity { get; }

        bool Start(bool toSession);

        bool SetInstanceToSession();

        bool IsAuthenticated();

        bool IsInRole(string role);

        void SetActive();

    }
}
