using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Practica2.Seguridad
{
    //El identity es toda la informacion que se tiene del usuario autenticado
    public class IdentityPersonalizado : IIdentity
    {
        public string Name
        {
            get { return login; }
        }

        public string AuthenticationType
        {
            get { return Identity.AuthenticationType; }
        }

        public bool IsAuthenticated
        {
            get { return Identity.IsAuthenticated; }
        }

        public int idUsuario { get; set; }
        public string login { get; set; }
        public String Rol { get; set; }
        public IIdentity Identity { get; set; }

        public IdentityPersonalizado(IIdentity identity)
        {
            this.Identity = identity;
            var us = Membership.GetUser(identity.Name) as UsuarioMembership;
            login = us.login;
            idUsuario = us.idUsuario;
            Rol = us.Rol;
        }
    }
}
