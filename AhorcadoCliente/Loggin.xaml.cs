using ServiceReference1;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AhorcadoCliente
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UsuarioServiciosClient servicios = new UsuarioServiciosClient();
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool verificarFormulario(string correo, string password)
        {

            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            return true;
        }

        private void Button_Registrarse(object sender, RoutedEventArgs e)
        {
            RegistroUsuario ventanaRegistro = new RegistroUsuario();
            ventanaRegistro.ShowDialog();
        }

        private void Button_IniciarSesion(object sender, RoutedEventArgs e)
        {
            try
            {
                string correo = txtCorreo.Text;
                string password = txtPassword.Password;
                if (!verificarFormulario(correo, password))
                {
                    MessageBox.Show("Por favor ingresa los datos faltantes");
                }
                else
                {
                    Usuario usuarioLoggeado = servicios.iniciarSesion(correo, password);
                    if (usuarioLoggeado != null)
                    {
                        MessageBox.Show("Bienvenido al juego!");
                    }
                    else
                    {
                        MessageBox.Show("Usuario y/o password incorrectos!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesion!");
            }
        }
    }
}