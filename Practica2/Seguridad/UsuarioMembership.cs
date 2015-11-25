using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using Practica2.Models;

namespace Practica2.Seguridad
{
    //intermediario recoge los datos del usuario y se los pasa al identity
    //En usuariomembership no se guarda la contraseña en memoria por si se sufre algun ataque
  public class UsuarioMembership:MembershipUser
    {
        public int idUsuario { get; set; }
        public string login { get; set; }
        public String Rol { get; set; }
         public override String Email { get; set; }
      public UsuarioMembership(Usuario us)
      {
          var clave = ConfigurationManager.AppSettings["ClaveCifrado"];
          idUsuario = us.idUsuario;
          Rol = us.Rol.nombre;
          login = us.login;
      }

    }
}
