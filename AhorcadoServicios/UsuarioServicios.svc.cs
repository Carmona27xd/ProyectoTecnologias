using AhorcadoServicios.Modelo.DTO;
using AhorcadoServicios.Modelo.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AhorcadoServicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "UsuarioServicios" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione UsuarioServicios.svc o UsuarioServicios.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class UsuarioServicios : IUsuarioServicios
    {
        public bool comprobarCorreoExistente(string correo)
        {
            return UsuarioDTO.comprobarCorreoExistente(correo);
        }

        public bool comprobarNicknameExistente(string nickName)
        {
            return UsuarioDTO.comprobarNicknameExistente(nickName);
        }

        public Usuario iniciarSesion(string correo, string password)
        {
            return UsuarioDTO.iniciarSesion(correo, password);
        }

        public bool registrarUsuario(Usuario usuario)
        {
            return UsuarioDTO.registrarUsuario(usuario);
        }
    }
}
