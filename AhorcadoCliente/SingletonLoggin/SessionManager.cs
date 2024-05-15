using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhorcadoCliente.SingletonLoggin
{
    internal class SessionManager
    {
        private static SessionManager instance;
        private Usuario currentUser;

        private SessionManager() { }

        public static SessionManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SessionManager();
                }
                return instance;
            }
        }

        public void Login (Usuario usuario)
        {
            currentUser = usuario;
        }

        public void Logout ()
        {
            currentUser = null;
        }

        public int getIdUser ()
        {
            if (currentUser != null)
            {
                return currentUser.id_cuenta;
            }
            else
            {
                throw new InvalidCastException("No hay un usuario en la sesionz");
            }
        }
    }
}
