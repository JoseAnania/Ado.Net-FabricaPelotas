using System;
using System.Data.SqlClient;

namespace FabricaPelotas.Models
{
    public class GestorConexion
    {
        public SqlConnection conexion;
        public void AbrirConexion()
        {
            try
            {
                conexion = new SqlConnection("Data Source=DESKTOP-H3IC85T;Initial Catalog=FabricaPelotas;User ID=sa;Password=giandjoe");
                conexion.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en la conexión: " + e.Message);
            }
        }

        public void CerrarConexion()
        {
            try
            {
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al cerrar la conexión:" + e.Message);
            }
        }
    }
}
