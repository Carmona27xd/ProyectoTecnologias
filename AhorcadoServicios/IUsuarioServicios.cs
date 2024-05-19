using AhorcadoServicios.Modelo.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AhorcadoServicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IUsuarioServicios" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IUsuarioServicios
    {
        [OperationContract]
        Usuario iniciarSesion(string correo, string password);
        [OperationContract]
        bool registrarUsuario(Usuario usuario);
        [OperationContract]
        bool comprobarCorreoExistente(string correo);
        [OperationContract]
        bool comprobarNicknameExistente(string nickName);
        [OperationContract]
        bool comprobarNumeroExistente(string numero);
        [OperationContract]
        Usuario obtenerDatosUsuario(int idUsuario);
    }
}
