using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AhorcadoCliente.Utils
{
    internal class Validaciones
    {
        public bool validarNombres(string nombres)
        {
            if (Regex.IsMatch(nombres, @"^[a-zA-Z\s]+$"))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Nombre inválido o apellidos no válidos. " +
                    "Debe contener solo letras y espacios.");
                return false;
            }
        }

        public bool validarTelefono(string telefono)
        {
            if(telefono.Length != 10 || String.IsNullOrEmpty(telefono))
            {
                MessageBox.Show("Por favor ingresa un telefono valido");
                return false;
            }

            foreach (char c in telefono)
            {
                if (!char.IsDigit(c))
                {
                    MessageBox.Show("Por favor ingresa un telefono valido");
                    return false;
                }
            }
            return true;
        }

        public bool validarCorreo(string correo)
        {
            if (Regex.IsMatch(correo, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@"
                + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Correo invalido");
                return false;
            }
        }

        public bool validarFecha(DateTime? fechaNacimiento)
        {
            if (fechaNacimiento == null)
            {
                MessageBox.Show("Por favor selecciona la fecha de tu nacimiento");
                return false;
            }

            return true;
        }

        public bool validarNick(string nick)
        {
            if (Regex.IsMatch(nick, @"^[a-zA-Z0-9]+$"))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Nick invalido. Debe contener solo letras y números.");
                return false;
            }
        }

        public bool validarPassword(string contraseña)
        {
            if (Regex.IsMatch(contraseña, @"^[a-zA-Z0-9]{8,15}$"))
            {
                return true;
            }
            else
            {
                MessageBox.Show("La contraseña debe tener entre 8 y 15 caracteres y solo puede " +
                    "contener letras y números.");
                return false;
            }
        }

        public bool passwordsCoinciden(string password, string passwordConfirmacion)
        {
            if (password == passwordConfirmacion)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Los password no coinciden!");
                return false;
            }
        }
    }
}
