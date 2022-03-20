using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FabricaPelotas.Models
{
    public class GestorPlanta
    {
        GestorConexion gc = new GestorConexion();
        private SqlCommand comando;
        private SqlDataReader dr;
        public void AltaPlanta(Planta nuevaPlanta)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("INSERT INTO Planta (nombrePlanta, idFabrica, idColor, superficie) VALUES (@nombrePlanta, @idFabrica, @idColor, @superficie)", gc.conexion);

                comando.Parameters.Add(new SqlParameter("@nombrePlanta", nuevaPlanta.NombrePlanta));
                comando.Parameters.Add(new SqlParameter("@idFabrica", nuevaPlanta.IdFabrica));
                comando.Parameters.Add(new SqlParameter("@idColor", nuevaPlanta.IdColor));
                comando.Parameters.Add(new SqlParameter("@superficie", nuevaPlanta.Superficie));

                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error al insertar una Planta: " + e.Message);
            }
            finally
            {
                try
                {
                    gc.CerrarConexion();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error al cerrar la conexión: " + e.Message);
                }
            }
        }

        public List<Fabrica> cboFabrica()
        {
            List<Fabrica> lista = new List<Fabrica>();

            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("SELECT * FROM Fabrica", gc.conexion);
                dr = comando.ExecuteReader();

                while (dr.Read())
                {

                    Fabrica f = new Fabrica();
                    f.IdFabrica = dr.GetInt32(0);
                    f.NombreFabrica = dr.GetString(1);
                    lista.Add(f);

                }

                dr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error al mostrar las Fábricas: " + e.Message);
            }
            finally
            {
                try
                {
                    gc.CerrarConexion();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error al cerrar la conexión: " + e.Message);
                }
            }

            return lista;
        }

        public List<Color> cboColor()
        {
            List<Color> lista = new List<Color>();

            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("SELECT * FROM Color", gc.conexion);
                dr = comando.ExecuteReader();

                while (dr.Read())
                {

                    Color f = new Color();
                    f.IdColor = dr.GetInt32(0);
                    f.NombreColor = dr.GetString(1);
                    lista.Add(f);

                }

                dr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error al mostrar los Colores: " + e.Message);
            }
            finally
            {
                try
                {
                    gc.CerrarConexion();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error al cerrar la conexión: " + e.Message);
                }
            }

            return lista;
        }

        public void BajaPlanta(Planta borrarPlanta)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("DELETE FROM Planta WHERE idPlanta=@idPlanta", gc.conexion);

                comando.Parameters.Add(new SqlParameter("@idPlanta", borrarPlanta.IdPlanta));
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error al borrar una Planta: " + e.Message);
            }
            finally
            {
                try
                {
                    gc.CerrarConexion();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error al cerrar la conexión: " + e.Message);
                }
            }
        }

        public List<Planta> cboPlanta()
        {
            List<Planta> lista = new List<Planta>();

            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("SELECT idPlanta, nombrePlanta FROM Planta", gc.conexion);
                dr = comando.ExecuteReader();

                while (dr.Read())
                {

                    Planta p = new Planta();
                    p.IdPlanta = dr.GetInt32(0);
                    p.NombrePlanta = dr.GetString(1);
                    lista.Add(p);

                }

                dr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error al mostrar las Plantas: " + e.Message);
            }
            finally
            {
                try
                {
                    gc.CerrarConexion();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error al cerrar la conexión: " + e.Message);
                }
            }

            return lista;
        }

        public void ModificarPlanta(Planta cambiarPlanta)
        {
            try
            {
                gc.AbrirConexion();
                comando = new SqlCommand("UPDATE Planta SET nombrePlanta=@nombrePlanta, idFabrica=@idFabrica, idColor=@idColor, superficie=@superficie WHERE idPlanta=@idPlanta", gc.conexion);

                comando.Parameters.Add(new SqlParameter("@nombrePlanta", cambiarPlanta.NombrePlanta));
                comando.Parameters.Add(new SqlParameter("@idFabrica", cambiarPlanta.IdFabrica));
                comando.Parameters.Add(new SqlParameter("@idColor", cambiarPlanta.IdColor));
                comando.Parameters.Add(new SqlParameter("@superficie", cambiarPlanta.Superficie));
                comando.Parameters.Add(new SqlParameter("@idPlanta", cambiarPlanta.IdPlanta));

                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error al modificar una Planta: " + e.Message);
            }
            finally
            {
                try
                {
                    gc.CerrarConexion();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error al cerrar la conexión: " + e.Message);
                }
            }
        }

        public List<PlantaDto> Listar()
        {
            List<PlantaDto> lista = new List<PlantaDto>();

            gc.AbrirConexion();
            comando = new SqlCommand("SELECT p.idPlanta, p.nombrePlanta, f.nombreFabrica, c.nombreColor, p.superficie FROM Planta p INNER JOIN Fabrica f ON p.idFabrica=f.idFabrica INNER JOIN Color c ON p.idColor=c.idColor", gc.conexion);
            dr = comando.ExecuteReader();

            while (dr.Read())
            {
                int idPlanta = dr.GetInt32(0);
                string nombrePlanta = dr.GetString(1);
                string nombreFabrica = dr.GetString(2);
                string nombreColor = dr.GetString(3);
                double superficie = dr.GetDouble(4);

                PlantaDto p = new PlantaDto(idPlanta, nombrePlanta, nombreFabrica, nombreColor, superficie);
                lista.Add(p);
            }
            gc.CerrarConexion();
            return lista;
        }
    }
}