using System.Configuration;
using System.Data;
using System.Windows;

namespace AhorcadoCliente
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Cargar diccionario de recursos predeterminado
            LoadDefaultResourceDictionary();
        }

        private void LoadDefaultResourceDictionary()
        {
            var defaultResourceDict = new ResourceDictionary();
            defaultResourceDict.Source = new Uri("/Resources/Strings.xaml", UriKind.Relative);
            Resources.MergedDictionaries.Add(defaultResourceDict);
        }
    }
}
