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
            if (validarTexto(txtNombres.Text) && validarCorreo(txtCorreo.Text) && validarNick(txtNickname.Text) && validarTexto(txtApellidoMaterno.Text)
                && validarTexto(txtApellidoPaterno.Text) && validarPassword(txtPassword.Password))
            {
                Console.WriteLine("entro el 1 if");

                if (await usuarioServiciosClient.comprobarCorreoExistenteAsync(txtCorreo.Text))
                {
                    MessageBox.Show("Este correo ya se encuetra registrado");
                    Console.WriteLine("entro el 2 if");

                }
                else
                {
                    if (await usuarioServiciosClient.comprobarNicknameExistenteAsync(txtNickname.Text))
                    {
                        MessageBox.Show("Este nickname ya se encuentra registrado");
                        Console.WriteLine("entro el 3 if");

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
                                MessageBox.Show("No se pudo registrar el usuario");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);

                        }
                    }
                }

            }
        }

        private Usuario crearUsuario()
        {
            Usuario nuevoUsuario = new Usuario();

            try
            {
                nuevoUsuario.nombres = txtNombres.Text;
                nuevoUsuario.correo = txtCorreo.Text;
                nuevoUsuario.nickname = txtNickname.Text;
                nuevoUsuario.password = txtPassword.Password;
                nuevoUsuario.apellido_paterno = txtApellidoPaterno.Text;
                nuevoUsuario.apellido_materno = txtApellidoMaterno.Text;
                nuevoUsuario.fecha_nacimiento = dpFechaSeleccionada.Text;

                int telefonoInt = Int32.Parse(txtTelefono.Text);
                nuevoUsuario.telefono = telefonoInt;

            }
            catch (FormatException)
            {
                MessageBox.Show("El telefono no es valido");
            }

            return nuevoUsuario;
        }

        private void Button_Cancelar(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("¿Deseas cancelar el registro?", "Confirmación", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK) 
            {
                this.Close();
            }
        }
        private bool validarTexto(string nombre)
        {
            if (Regex.IsMatch(nombre, @"^([a-zA-Z]+)(\s[a-zA-Z]+)*$"))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Nombre invalido");
                return false;
            }
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
            if (Regex.IsMatch(contraseña, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&#.$($)$-$_])[A-Za-z\d$@$!%*?&#.$($)$-$_]{8,15}$"))
            {
                return true;
            }
            else
            {
                MessageBox.Show("No se pudo registrar el usuario, la contraseña debe tener entre 8 y 15 caracteres, al menos un dígito, " +
                    "al menos una minúscula y al menos una mayúscula, un caracter especial y no espacios en blanco.");

                return false;
            }

        }

    }
}
