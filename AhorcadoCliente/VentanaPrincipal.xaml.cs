using AhorcadoCliente.SingletonLoggin;
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
    /// Lógica de interacción para VentanaPrincipal.xaml
    /// </summary>
    public partial class VentanaPrincipal : Window
    {

        public VentanaPrincipal()
        {
            InitializeComponent();
        }

        private void Modificar_perfil(object sender, RoutedEventArgs e)
        {
            int sesionID = SessionManager.Instance.getIdUser();
            MessageBox.Show("ID de la sesion iniciada: " + sesionID);
        }

        private void Cerrar_Sesion(object sender, RoutedEventArgs e)
        {
            SessionManager.Instance.Logout();
            
        }
    }
}
