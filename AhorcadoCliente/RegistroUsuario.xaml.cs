using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private void Button_Registrarse(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Cancelar(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("¿Deseas cancelar el registro?", "Confirmación", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK) 
            {
                this.Close();
            }
        }
    }
}
