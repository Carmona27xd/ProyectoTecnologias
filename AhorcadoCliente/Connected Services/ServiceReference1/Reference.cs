﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference1
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Usuario", Namespace="http://schemas.datacontract.org/2004/07/AhorcadoServicios.Modelo.POCO")]
    public partial class Usuario : object, System.ComponentModel.INotifyPropertyChanged
    {
        
        private string apellido_maternoField;
        
        private string apellido_paternoField;
        
        private string correoField;
        
        private string fecha_nacimientoField;
        
        private int id_cuentaField;
        
        private string nicknameField;
        
        private string nombresField;
        
        private string passwordField;
        
        private int puntos_obtenidosField;
        
        private int telefonoField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string apellido_materno
        {
            get
            {
                return this.apellido_maternoField;
            }
            set
            {
                if ((object.ReferenceEquals(this.apellido_maternoField, value) != true))
                {
                    this.apellido_maternoField = value;
                    this.RaisePropertyChanged("apellido_materno");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string apellido_paterno
        {
            get
            {
                return this.apellido_paternoField;
            }
            set
            {
                if ((object.ReferenceEquals(this.apellido_paternoField, value) != true))
                {
                    this.apellido_paternoField = value;
                    this.RaisePropertyChanged("apellido_paterno");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string correo
        {
            get
            {
                return this.correoField;
            }
            set
            {
                if ((object.ReferenceEquals(this.correoField, value) != true))
                {
                    this.correoField = value;
                    this.RaisePropertyChanged("correo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string fecha_nacimiento
        {
            get
            {
                return this.fecha_nacimientoField;
            }
            set
            {
                if ((object.ReferenceEquals(this.fecha_nacimientoField, value) != true))
                {
                    this.fecha_nacimientoField = value;
                    this.RaisePropertyChanged("fecha_nacimiento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id_cuenta
        {
            get
            {
                return this.id_cuentaField;
            }
            set
            {
                if ((this.id_cuentaField.Equals(value) != true))
                {
                    this.id_cuentaField = value;
                    this.RaisePropertyChanged("id_cuenta");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nickname
        {
            get
            {
                return this.nicknameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.nicknameField, value) != true))
                {
                    this.nicknameField = value;
                    this.RaisePropertyChanged("nickname");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nombres
        {
            get
            {
                return this.nombresField;
            }
            set
            {
                if ((object.ReferenceEquals(this.nombresField, value) != true))
                {
                    this.nombresField = value;
                    this.RaisePropertyChanged("nombres");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string password
        {
            get
            {
                return this.passwordField;
            }
            set
            {
                if ((object.ReferenceEquals(this.passwordField, value) != true))
                {
                    this.passwordField = value;
                    this.RaisePropertyChanged("password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int puntos_obtenidos
        {
            get
            {
                return this.puntos_obtenidosField;
            }
            set
            {
                if ((this.puntos_obtenidosField.Equals(value) != true))
                {
                    this.puntos_obtenidosField = value;
                    this.RaisePropertyChanged("puntos_obtenidos");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int telefono
        {
            get
            {
                return this.telefonoField;
            }
            set
            {
                if ((this.telefonoField.Equals(value) != true))
                {
                    this.telefonoField = value;
                    this.RaisePropertyChanged("telefono");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IUsuarioServicios")]
    public interface IUsuarioServicios
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioServicios/iniciarSesion", ReplyAction="http://tempuri.org/IUsuarioServicios/iniciarSesionResponse")]
        ServiceReference1.Usuario iniciarSesion(string correo, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioServicios/iniciarSesion", ReplyAction="http://tempuri.org/IUsuarioServicios/iniciarSesionResponse")]
        System.Threading.Tasks.Task<ServiceReference1.Usuario> iniciarSesionAsync(string correo, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public interface IUsuarioServiciosChannel : ServiceReference1.IUsuarioServicios, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public partial class UsuarioServiciosClient : System.ServiceModel.ClientBase<ServiceReference1.IUsuarioServicios>, ServiceReference1.IUsuarioServicios
    {
        
        /// <summary>
        /// Implemente este método parcial para configurar el punto de conexión de servicio.
        /// </summary>
        /// <param name="serviceEndpoint">El punto de conexión para configurar</param>
        /// <param name="clientCredentials">Credenciales de cliente</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public UsuarioServiciosClient() : 
                base(UsuarioServiciosClient.GetDefaultBinding(), UsuarioServiciosClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IUsuarioServicios.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public UsuarioServiciosClient(EndpointConfiguration endpointConfiguration) : 
                base(UsuarioServiciosClient.GetBindingForEndpoint(endpointConfiguration), UsuarioServiciosClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public UsuarioServiciosClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(UsuarioServiciosClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public UsuarioServiciosClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(UsuarioServiciosClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public UsuarioServiciosClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public ServiceReference1.Usuario iniciarSesion(string correo, string password)
        {
            return base.Channel.iniciarSesion(correo, password);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.Usuario> iniciarSesionAsync(string correo, string password)
        {
            return base.Channel.iniciarSesionAsync(correo, password);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IUsuarioServicios))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IUsuarioServicios))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:51443/UsuarioServicios.svc");
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return UsuarioServiciosClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IUsuarioServicios);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return UsuarioServiciosClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IUsuarioServicios);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IUsuarioServicios,
        }
    }
}