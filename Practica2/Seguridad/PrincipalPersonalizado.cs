using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

//Contenedor del Identity. El principal es el hecho de estar autenticado
namespace Practica2.Seguridad
{
   public class PrincipalPersonalizado:IPrincipal
    {
       public bool IsInRole(string role)
       {
           //if (MiIdentidadPersonalizado.Rol == role)
           //    return true;
           //return false;
           return MiIdentidadPersonalizado.Rol == role;
       }

       public IIdentity Identity { get; private set; }

       public IdentityPersonalizado MiIdentidadPersonalizado
       {
           get { return (IdentityPersonalizado) Identity; }
           set { Identity = value; }
       }

       public PrincipalPersonalizado(IdentityPersonalizado identity)
       {
           Identity = identity;
       }

    }
}
