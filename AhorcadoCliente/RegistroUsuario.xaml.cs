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
using AhorcadoCliente.Utils;

namespace AhorcadoCliente
{
    /// <summary>
    /// Lógica de interacción para RegistroUsuario.xaml
    /// </summary>
    public partial class RegistroUsuario : Window
    {
        UsuarioServiciosClient usuarioServiciosClient = new UsuarioServiciosClient();
        Validaciones validaciones = new Validaciones();
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
            bool nombres = validaciones.validarNombres(txtNombres.Text);
            bool apellidoP = validaciones.validarNombres(txtApellidoPaterno.Text);
            bool apellidoM = validaciones.validarNombres(txtApellidoMaterno.Text);
            bool correo = validaciones.validarCorreo(txtCorreo.Text);
            bool nickName = validaciones.validarNick(txtNickname.Text);
            bool telefono = validaciones.validarTelefono(txtTelefono.Text);
            bool password = validaciones.validarPassword(txtPassword.Password);
            bool validarFecha = validaciones.validarFecha(dpFechaSeleccionada.SelectedDate);
            bool passwordsCoinciden = validaciones.passwordsCoinciden(txtPassword.Password, txtPasswordConfirmacion.Password);

            if (nombres && apellidoP && apellidoM && correo && nickName && telefono && password
                && validarFecha && passwordsCoinciden)
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
    }
}
