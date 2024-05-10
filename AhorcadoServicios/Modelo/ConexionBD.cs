using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AhorcadoServicios.Modelo
{
    public class ConexionBD
    {
        public static SqlConnection obtenerConexion()
        {
            string conexionString = "Data Source=CARMONA;Initial Catalog=proyecto;Integrated Security=True";
            return new SqlConnection(conexionString);

        }
    }
}