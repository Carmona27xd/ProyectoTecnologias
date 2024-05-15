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

namespace AhorcadoCliente
{
    /// <summary>
    /// Lógica de interacción para RegistroUsuario.xaml
    /// </summary>
    public partial class RegistroUsuario : Window
    {
        UsuarioServiciosClient usuarioServiciosClient = new UsuarioServiciosClient();
        public RegistroUsuario()
        {
            InitializeComponent();
        }

        private async void Button_Registrarse(object sender, RoutedEventArgs e)
        {
            if (!camposFaltantes())
            {
                if (validarCampos())
                {
                    if (await usuarioServiciosClient.comprobarCorreoExistenteAsync(txtCorreo.Text))
                    {
                        MessageBox.Show("Este correo ya se encuentra registrado"); 
                    }
                    else if (await usuarioServiciosClient.comprobarNicknameExistenteAsync(txtNickname.Text))
                    {
                        MessageBox.Show("Este nickname ya se encuentra registrado");
                    }
                    else if (await usuarioServiciosClient.comprobarNumeroExistenteAsync(txtTelefono.Text))
                    {
                        MessageBox.Show("Este telefono ya se encuentra registrado");
                    }
                    else
                    {
                        try
                        {
                            Usuario nuevoUsuario = crearUsuario();
                            bool confirmacion = await usuarioServiciosClient.registrarUsuarioAsync(nuevoUsuario);
                            if (confirmacion)
                            {
                                MessageBox.Show("Usuario registrado con exito!");
                                this.Close();
                                
                            } 
                            else
                            {
                                MessageBox.Show("No se pudo registrar el usuario!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
            } 
            else
            {
                MessageBox.Show("Por favor llena todos los campos!");
            }
        }

        private bool validarCampos()
        {
            if (validarTexto(txtNombres.Text) && validarCorreo(txtCorreo.Text) && validarNick(txtNickname.Text) && validarTexto(txtApellidoMaterno.Text)
                && validarTexto(txtApellidoPaterno.Text) && validarPassword(txtPassword.Password) && validarTelefono(txtTelefono.Text) &&
                validarFecha(dpFechaSeleccionada.SelectedDate) && passwordsCoinciden())
            {
                return true;
            }
            return false;
        }

        private void Button_Cancelar(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("¿Deseas cancelar el registro?", "Confirmación", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                this.Close();
            }
        }

        private Usuario crearUsuario()
        {
            Usuario nuevoUsuario = new Usuario();

            try
            {
                nuevoUsuario.nombres = txtNombres.Text.ToLower();
                nuevoUsuario.apellido_paterno = txtApellidoPaterno.Text.ToLower();
                nuevoUsuario.apellido_materno = txtApellidoMaterno.Text.ToLower();
                nuevoUsuario.correo = txtCorreo.Text;
                nuevoUsuario.nickname = txtNickname.Text;
                nuevoUsuario.password = txtPassword.Password;
                nuevoUsuario.fecha_nacimiento = dpFechaSeleccionada.Text;
                nuevoUsuario.telefono = txtTelefono.Text;
            }
            catch (Exception ex)
            {
                throw;
            }

            return nuevoUsuario;
        }

        private bool camposFaltantes()
        {
            string correo = txtCorreo.Text.Trim();
            string nickname = txtNickname.Text.Trim();
            string nombres = txtNombres.Text.Trim();
            string apellidoPaterno = txtApellidoPaterno.Text.Trim();   
            string apellidoMaterno = txtApellidoMaterno.Text.Trim();
            string password = txtPassword.Password.Trim();
            string telefono = txtTelefono.Text.Trim();
            string fechaNacimiento = dpFechaSeleccionada.Text.Trim();

            if (String.IsNullOrEmpty(correo) || String.IsNullOrEmpty(nickname) || String.IsNullOrEmpty(nombres) || String.IsNullOrEmpty(apellidoPaterno) || 
                String.IsNullOrEmpty(apellidoMaterno) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(telefono) || string.IsNullOrEmpty(fechaNacimiento))
            {
                return true;
            }

            return false;
        }
        private bool validarFecha(DateTime? fechaNacimiento)
        {
            if (fechaNacimiento == null)
            {
                MessageBox.Show("Por favor selecciona la fecha de tu nacimiento"); 
                return false;
            }

            return true;
        }

        private bool validarTexto(string nombre)
        {
            if (Regex.IsMatch(nombre, @"^[a-zA-Z\s]+$"))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Nombre inválido o apellidos no válidos. Debe contener solo letras y espacios.");
                return false;
            }
        }

        private bool validarTelefono(string telefono)
        {

            if (telefono.Length != 10 || String.IsNullOrEmpty(telefono))
            {
                MessageBox.Show("Por favor ingresa un telefono valido");
                return false;
            } 
            
            foreach (char c in telefono)
            {
                if (!char.IsDigit(c))
                {
                    MessageBox.Show("Por favor ingresa un telefono valido");
                    txtTelefono.Clear();
                    return false;
                }
            }
            return true;
        }

        private bool validarCorreo(string correo)
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

        private bool validarNick(string nick)
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
                MessageBox.Show("La contraseña debe tener entre 8 y 15 caracteres y solo puede contener letras y números.");
                return false;
            }
        }

        private bool passwordsCoinciden()
        {
            if (txtPassword.Password == txtPasswordConfirmacion.Password)
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
