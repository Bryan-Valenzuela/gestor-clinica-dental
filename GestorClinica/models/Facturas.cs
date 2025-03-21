using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorClinica.models
{
    class Facturas
    {
        static public int Id_Factura { get; set; }
        static public int idConsulta { get; set; }
        static public string nombreCompleto { get; set; }
        static public string RFC { get; set; }
        static public string direccion { get; set; }
        static public string correo { get; set; }
        static public string fecha { get; set; }


        public void setearVariables()
        {
            Id_Factura = int.Parse("");
            idConsulta = int.Parse("");
            nombreCompleto = "";
            RFC = "";
            direccion = "";
            correo = "";
            fecha = "";
        }

        static string servidor = "localhost";
        static string bd = "clinicabd";
        static string usuario = "root";
        static string pass = "Stroud25";
        static string puerto = "3306";


        static public bool realizarFactura()
        {
            bool aux = false;
            try
            {
                MySqlConnection conex = new MySqlConnection();
                string query = "INSERT INTO factura (IdConsulta, nombreCompleto, RFC, direccion, correo, fecha) values ('" +idConsulta+"', '" +nombreCompleto +"', '" +RFC+"', '" +direccion+"', '" +correo+"', '" +fecha+"');";
                string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + pass + ";" + "database=" + bd + ";";
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                MySqlCommand cmd = new MySqlCommand(query, conex);
                cmd.ExecuteNonQuery();
                conex.Close();

                aux = true;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            return aux;
        }

        static public List<Object> listarFacturas()
        {
            List<Object> lista = new List<Object>();
            try
            {
                MySqlConnection conex = new MySqlConnection();

                string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + pass + ";" + "database=" + bd + ";";
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                string query = "SELECT c.procedimiento, c.costo, f.nombreCompleto, f.RFC, f.direccion, f.correo FROM factura f INNER JOIN cobro c ON f.IdConsulta = c.idConsulta WHERE f.fecha = '"+fecha+"'";
              
            
                MySqlCommand cmd = new MySqlCommand(query, conex);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string Procedimiento = reader.GetString(0);
                        string Costo = reader.GetString(1);
                        string Nombre = reader.GetString(2);
                        string RFC = reader.GetString(3);
                        string Direccion = reader.GetString(4);
                        string Correo = reader.GetString(5);

                        lista.Add(new { Procedimiento, Costo, Nombre, RFC,Direccion,Correo });
                    }
                    conex.Close();
                }

                conex.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            

            return lista;
        }


        



    }
}
