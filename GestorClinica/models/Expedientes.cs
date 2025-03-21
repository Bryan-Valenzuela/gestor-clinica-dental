using System;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorClinica.models
{
    class Expedientes
    {
        static public int Id_Expediente { get; set; }
        static public int idPaciente { get; set; }
        static public string alergias { get; set; }
        static public string observaciones { get; set; }
        static public string limpieza { get; set; }
        static public string resina { get; set; }
        static public string ionomeroVidrio { get; set; }
        static public string pultotomia { get; set; }
        static public string coronas { get; set; }
        static public string extracion { get; set; }
        static public string mantenedorEspacios { get; set; }
        static public string sedacionConciente_ON { get; set; }
        static public string blanqueamiento { get; set; }
        static public string ProtesisFija_removible_total { get; set; }
        static public string otros { get; set; }
        static public string fecha { get; set; }



        static public void setearVariables()
        {
            
            alergias = "";
            observaciones = "";
            limpieza = "";
            resina = "";
            ionomeroVidrio = "";
            pultotomia = "";
            coronas = "";
            extracion = "";
            mantenedorEspacios = "";
            sedacionConciente_ON = "";
            blanqueamiento = "";
            ProtesisFija_removible_total = "";
            otros = "";
            fecha = "";
        }

        
        static string servidor = "localhost";
        static string bd = "clinicabd";
        static string usuario = "root";
        static string pass = "Stroud25";
        static string puerto = "3306";


        

        static public void mostrarTratamiento()
        {

            string aux = Pacientes.Id_Paciente.ToString();
            MySqlDataReader reader;
            MySqlConnection conex = new MySqlConnection();
            
            string query = "SELECT alergias, observaciones, fecha FROM expediente WHERE IdPaciente = '"+aux+"';";
            string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + pass + ";" + "database=" + bd + ";";
            conex.ConnectionString = cadenaConexion;
            conex.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conex);
                reader = cmd.ExecuteReader();

                if (reader != null)
                {
                    while (reader.Read())
                    {
                        alergias = reader.GetString(0);
                        observaciones = reader.GetString(1);
                        fecha = reader.GetString(2);
                    }

                }
                else
                {
                    MessageBox.Show("error con los datos");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            conex.Close();

            string query2 = "SELECT limpieza, resina, ionomeroVidrio, pulpotomia, coronas, extraccion, mantenedorEspacios, sedacionConciente_ON, blanqueamiento, protesisFija_Removible_Total, otros FROM tratamiento WHERE IdPaciente = '"+aux+"';";
           
            
            try
            {
                conex.Open();
                MySqlDataReader reader3 = null;
                MySqlCommand cmd = new MySqlCommand(query2, conex);
                reader3 = cmd.ExecuteReader();

                if (reader3 != null)
                {
                    while (reader3.Read())
                    {
                        limpieza = reader3.GetString(0);
                        resina = reader3.GetString(1);
                        ionomeroVidrio = reader3.GetString(2);
                        pultotomia = reader3.GetString(3);
                        coronas = reader3.GetString(4);
                        extracion = reader3.GetString(5);
                        mantenedorEspacios = reader3.GetString(6);
                        sedacionConciente_ON = reader3.GetString(7);
                        blanqueamiento = reader3.GetString(8);
                        ProtesisFija_removible_total = reader3.GetString(9);
                        otros = reader3.GetString(10);
                    }
                }
                else
                {
                    MessageBox.Show("error con los datos");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


            conex.Close();
        }


        static public void actualizarTratamiento()
        {
            string aux = Pacientes.Id_Paciente.ToString();
            MySqlConnection conex = new MySqlConnection();

            string query = "UPDATE expediente SET alergias='"+alergias+"', observaciones='"+observaciones+"' WHERE IdPaciente = '"+aux+"';";
            string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + pass + ";" + "database=" + bd + ";";
            conex.ConnectionString = cadenaConexion;
            conex.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conex);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            conex.Close();

            string query2 = "UPDATE tratamiento SET limpieza = '"+limpieza+"', resina = '"+resina+"', ionomeroVidrio = '"+ionomeroVidrio+"', pulpotomia = '"+pultotomia+"', coronas = '"+coronas+"', extraccion = '"+extracion+"', mantenedorEspacios = '"+mantenedorEspacios+"', sedacionConciente_ON = '"+sedacionConciente_ON+"', blanqueamiento = '"+blanqueamiento+"', protesisFija_Removible_Total = '"+ProtesisFija_removible_total+"', otros = '"+otros+"' WHERE IdPaciente = '"+aux+"'; ";
            conex.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(query2, conex);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            MessageBox.Show("datos guardados correctamente");
            conex.Close();
        }

        static public void verTratamientoHecho()
        {
            string aux = Pacientes.Id_Paciente.ToString();
            MySqlDataReader reader;
            MySqlConnection conex = new MySqlConnection();

            string query = "SELECT limpieza, resina, ionomeroVidrio, pulpotomia, coronas, extraccion, mantenedorEspacios, sedacionConciente_ON, blanqueamiento, protesisFija_Removible_Total, otros FROM tratado WHERE IdPaciente = '" + aux + "';";
            string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + pass + ";" + "database=" + bd + ";";
            conex.ConnectionString = cadenaConexion;
            conex.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conex);
                reader = cmd.ExecuteReader();

                if (reader != null)
                {
                    while (reader.Read())
                    {
                        limpieza = reader.GetString(0);
                        resina = reader.GetString(1);
                        ionomeroVidrio = reader.GetString(2);
                        pultotomia = reader.GetString(3);
                        coronas = reader.GetString(4);
                        extracion = reader.GetString(5);
                        mantenedorEspacios = reader.GetString(6);
                        sedacionConciente_ON = reader.GetString(7);
                        blanqueamiento = reader.GetString(8);
                        ProtesisFija_removible_total = reader.GetString(9);
                        otros = reader.GetString(10);
                    }
                }
                else
                {
                    MessageBox.Show("error con los datos");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            conex.Close();
        }

    }
}
