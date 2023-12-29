using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Modelo
{
     public class Usuariosrepositorio
    {


        static string WebAPIKey = "AIzaSyCayIROW4X-3pFa6vn6VC1gjgDXVv-PfYs" ;
        FirebaseAuthProvider authProvider;

        public Usuariosrepositorio()
        {
            authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));
        }

        public async Task<bool> Registrar(string email, string clave)
        {
            var token = await authProvider.CreateUserWithEmailAndPasswordAsync(email, clave);
            if (!string.IsNullOrEmpty(token.FirebaseToken))
            {
                return true;
            }
            return false;
        }
    }
}
