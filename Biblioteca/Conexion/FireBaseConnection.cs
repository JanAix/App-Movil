using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Conexion
{
    public  class FireBaseConnection
    {
        public static FirebaseClient FireBase_connect = new FirebaseClient("https://biblioteca-21a38-default-rtdb.firebaseio.com/");
        public const string WepApyAuthentication = "AIzaSyCayIROW4X-3pFa6vn6VC1gjgDXVv-PfYs";

       
    }
}

