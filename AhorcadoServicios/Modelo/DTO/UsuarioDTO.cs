using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AhorcadoServicios.Modelo.POCO;

namespace AhorcadoServicios.Modelo.DTO
{
    public class UsuarioDTO
    {
        public static Usuario iniciarSesion(string correo, string password)
        {
            try
            {
                var conexion = ConexionBD.obtenerConexion();
                conexion.Open();
                DataContext dataContext = new DataContext(conexion);
                var usuario = (from us in dataContext.GetTable<Usuario>()
                               where us.correo == correo && us.password == password
                               select us).FirstOrDefault();
                return usuario;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static Usuario obtenerDatosUsuario(int idUsuario)
        {
            try
            {
                var conexion = ConexionBD.obtenerConexion();
                conexion.Open();
                DataContext dataContext = new DataContext(conexion);
                var usuario = (from us in dataContext.GetTable<Usuario>()
                               where us.id_cuenta == idUsuario
                               select us).FirstOrDefault();
                return usuario;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static bool registrarUsuario(Usuario usuario)
        {
            try
            {
                var conexion = ConexionBD.obtenerConexion();
                conexion.Open();
                DataContext dataContext = new DataContext(conexion);
                dataContext.GetTable<Usuario>().InsertOnSubmit(usuario);
                dataContext.SubmitChanges();
                return true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static bool comprobarCorreoExistente(string correo)
        {
            try
            {
                var conexion = ConexionBD.obtenerConexion();
                conexion.Open();
                DataContext dataContext = new DataContext(conexion);
                bool correoExiste = dataContext.GetTable<Usuario>().Any(usuario => usuario.correo == correo);
                return correoExiste;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static bool comprobarNicknameExistente(string nickname)
        {
            try
            {
                var conexion = ConexionBD.obtenerConexion();
                conexion.Open();
                DataContext dataContext = new DataContext(conexion);
                bool nickNameExiste = dataContext.GetTable<Usuario>().Any(usuario => usuario.nickname == nickname);
                return nickNameExiste;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public static bool comprobarNumeroExistente(string telefono)
        {
            try
            {
                var conexion = ConexionBD.obtenerConexion();
                conexion.Open();
                DataContext dataContext = new DataContext(conexion);
                bool telefonoExiste = dataContext.GetTable<Usuario>().Any(usuario => usuario.telefono == telefono);
                return telefonoExiste;
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }
    }
}