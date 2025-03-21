using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorClinica.models
{
    class Radiografias
    {
        static public int Id_Radiografia { get; set; }
        static public int idPaciente { get; set; }
        static public string fecha { get; set; }
        static public string titulo { get; set; }
        static public byte[] Radiografia { get; set; }


        

        MySqlConnection conex = new MySqlConnection();
        static string servidor = "localhost";
        static string bd = "clinicabd";
        static string usuario = "root";
        static string pass = "Stroud25";
        static string puerto = "3306";
        
        static public void guardarRadiografias()
        {

            MySqlConnection conex = new MySqlConnection();
            string query = "INSERT INTO radiografias (IdPaciente,fecha,titulo,radiografia) VALUES ( '" + idPaciente + "', '" + fecha + "', '" + titulo + "', @imagen) ; ";
            string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + pass + ";" + "database=" + bd + ";";
            conex.ConnectionString = cadenaConexion;
            conex.Open();
            MySqlCommand cmd = new MySqlCommand(query, conex);
            cmd.Parameters.AddWithValue("imagen", Radiografia);
            cmd.ExecuteNonQuery();
            conex.Close();
        }


        static public List<Object> ListarRadiografias()
        {
            MySqlDataReader reader = null;
            MySqlConnection conex = new MySqlConnection();
            List<Object> lista = new List<Object>();
            string query = "SELECT id_Radiografias, IdPaciente, fecha, titulo FROM radiografias WHERE IdPaciente = '" + idPaciente + "'";
            string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + pass + ";" + "database=" + bd + ";";
            conex.ConnectionString = cadenaConexion;
            conex.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conex);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Id_Radiografia = int.Parse(reader.GetString(0));
                        idPaciente = int.Parse(reader.GetString(1));
                        fecha = reader.GetString(2);
                        titulo = reader.GetString(3);

                        string ID = Id_Radiografia.ToString();
                        string ID_Paciente = idPaciente.ToString();
                        string Fecha= fecha;
                        string Nombre = titulo;

                        lista.Add(new { ID, ID_Paciente, Fecha, Nombre});
                    }
                }
                else
                {
                    MessageBox.Show("Datos no existentes");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            conex.Close();
            return lista;
        }

    }
}
