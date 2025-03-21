using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GestorClinica.models
{
    class Consultas
    {
        static public int Id_Consulta { get; set; }
        static public int idPaciente { get; set; }
        static public int idProcedimiento { get; set; }
        static public string nombrePaciente { get; set; }
        static public string celPaciente { get; set; }
        static public string fecha { get; set; }
        static public string hora { get; set; }
        static public double duracion { get; set; }
        static public string dientes { get; set; }
        static public string estado { get; set; }
        static public string nombreProcedimietnto { get; set; }
        static public string especialidad { get; set; }
        static public int costoConsulta { get; set; }
        static public string valHora { get; set; }


        static public string calDia { get; set; }
        static public string calMes { get; set; }
        static public string calYear { get; set; }



        public void setearVariables()
        {
            Id_Consulta = int.Parse("");
            idPaciente = int.Parse("");
            nombreProcedimietnto = "";
            fecha = "";
            hora = "";
            duracion = double.Parse("");
            dientes = "";
            estado = "";
            nombreProcedimietnto = "";

        }


        static string servidor = "localhost";
        static string bd = "clinicabd";
        static string usuario = "root";
        static string pass = "Stroud25";
        static string puerto = "3306";




        static public List<Object> infoPacienteConsultas(String dato)
        {

            MySqlDataReader reader;
            MySqlConnection conex = new MySqlConnection();
            List<Object> lista = new List<Object>();
            string query = "SELECT c.id_Consulta, c.fecha, c.hora, pc.nombre FROM consulta c INNER JOIN procedimientos pc ON c.IdProcedimientos = pc.id_Procedimientos WHERE c.IdPaciente = '" + dato + "' AND c.estado != 'Realizada' AND c.estado != 'Cancelada' ORDER BY c.fecha ASC , c.hora ASC ;";
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
                        Id_Consulta = int.Parse(reader.GetString(0));
                        fecha = reader.GetString(1);
                        hora = reader.GetString(2);
                        nombreProcedimietnto = reader.GetString(3);

                        string ID_Consulta = Id_Consulta.ToString();
                        string Fecha = fecha;
                        string Hora = hora;
                        string Procedimiento = nombreProcedimietnto;
                        lista.Add(new { ID_Consulta, Fecha, Hora, Procedimiento});
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
            return lista;
        }


        static public List<Object> ListarConsultas()
        {
            MySqlDataReader reader = null;
            MySqlConnection conex = new MySqlConnection();
            List<Object> lista = new List<Object>();
            string query = "SELECT c.id_Consulta AS 'ID consulta', c.hora AS 'Hora', pc.nombre AS 'Procedimiento', c.duracion, p.nombre AS 'Nombre', p.cel AS 'Cel' FROM consulta c INNER JOIN pacientes p ON c.IdPaciente = p.id_Pacientes INNER JOIN procedimientos pc ON c.IdProcedimientos = pc.id_Procedimientos WHERE c.fecha = '" + fecha + "' AND c.especialidad = '" + especialidad + "' AND c.estado != 'Realizada' AND c.estado != 'Cancelada' ORDER BY c.hora ASC; ";
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
                        Id_Consulta = int.Parse(reader.GetString(0));
                        hora = reader.GetString(1);
                        nombreProcedimietnto = reader.GetString(2);
                        duracion = double.Parse(reader.GetString(3));
                        nombrePaciente = reader.GetString(4);
                        celPaciente = reader.GetString(5);

                        string ID_Consulta = Id_Consulta.ToString();
                        string Hora = hora;
                        string Procedimiento = nombreProcedimietnto;
                        string Duracion = duracion.ToString();
                        string Paciente = nombrePaciente;
                        string Celular = celPaciente;

                        lista.Add(new { ID_Consulta, Hora, Procedimiento, Duracion, Paciente, Celular });
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            conex.Close();
            return lista;
        }

        static public void agregarCitaValidacion()
        {
            try
            {
                MySqlConnection conex = new MySqlConnection();
                string query = "INSERT INTO citas (fecha, especialidad, hora) VALUES ('" + fecha + "', '" + especialidad + "', '" + valHora + "') ";
                string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + pass + ";" + "database=" + bd + ";";
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                MySqlCommand cmd = new MySqlCommand(query, conex);
                cmd.ExecuteNonQuery();
                conex.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        static public bool AgregarConsulta()
        {
            bool aux = false;
            try
            {
                MySqlConnection conex = new MySqlConnection();
                string query = "INSERT INTO consulta (IdPaciente, IdProcedimientos, fecha, hora, especialidad, duracion, dientes, estado) VALUES ('" + idPaciente + "', '" + idProcedimiento + "', '" + fecha + "', '" + hora + "', '" + especialidad + "', '" + duracion + "', '" + dientes + "', '" + estado + "');";
                string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + pass + ";" + "database=" + bd + ";";
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                MySqlCommand cmd = new MySqlCommand(query, conex);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cita creada exitosamente");
                conex.Close();

                aux = true;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            return aux;
        }

        static public void infoConsultas()
        {

            MySqlDataReader reader;
            MySqlConnection conex = new MySqlConnection();
            string query = "SELECT p.id_Pacientes, p.cel, p.nombre, pc.nombre, c.fecha, c.hora, c.especialidad, c.duracion, c.dientes, c.estado FROM consulta c INNER JOIN pacientes p ON c.IdPaciente = p.id_Pacientes INNER JOIN procedimientos pc ON c.IdProcedimientos = pc.id_Procedimientos WHERE c.id_Consulta = '" + Id_Consulta + "'";
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
                        idPaciente = int.Parse(reader.GetString(0));
                        celPaciente = reader.GetString(1);
                        nombrePaciente = reader.GetString(2);
                        nombreProcedimietnto = reader.GetString(3);
                        fecha = reader.GetString(4);
                        hora = reader.GetString(5);
                        especialidad = reader.GetString(6);
                        duracion = double.Parse(reader.GetString(7));
                        dientes = reader.GetString(8);
                        estado = reader.GetString(9);

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

        static public bool actualizarEstado()
        {
            bool aux = false;
            try {
                MySqlConnection conex = new MySqlConnection();
                string query = "UPDATE consulta SET estado = '" + estado + "' WHERE id_Consulta = '" + Id_Consulta + "';";
                string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + pass + ";" + "database=" + bd + ";";
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                MySqlCommand cmd = new MySqlCommand(query, conex);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Estado de la cita actualizado correctamente");
                conex.Close();

                aux = true;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


            return aux;

        }

        static public void borrarCita()
        {
            try
            {
                MySqlConnection conex = new MySqlConnection();
                string query = "DELETE FROM consulta WHERE id_Consulta = '" + Id_Consulta + "';";
                string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + pass + ";" + "database=" + bd + ";";
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                MySqlCommand cmd = new MySqlCommand(query, conex);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Datos guardados exitosamente");
                conex.Close();



            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        static public void infoCobro()
        {

            MySqlDataReader reader;
            MySqlConnection conex = new MySqlConnection();
            string query = "SELECT p.id_Pacientes, p.nombre, pc.nombre, c.fecha, c.hora, c.especialidad, c.duracion, pc.costo FROM consulta c INNER JOIN pacientes p ON c.IdPaciente = p.id_Pacientes INNER JOIN procedimientos pc ON c.IdProcedimientos = pc.id_Procedimientos WHERE c.id_Consulta = '" + Id_Consulta + "'; ";
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
                        idPaciente = int.Parse(reader.GetString(0));
                        nombrePaciente = reader.GetString(1);
                        nombreProcedimietnto = reader.GetString(2);
                        fecha = reader.GetString(3);
                        hora = reader.GetString(4);
                        especialidad = reader.GetString(5);
                        duracion = double.Parse(reader.GetString(6));
                        costoConsulta = int.Parse(reader.GetString(7));

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

        static public bool actualizarTratamientoTratado()
        {
            bool aux = false;
            string auxDientes = "";
            try
            {

                string query = "SELECT " + nombreProcedimietnto + " FROM tratado WHERE IdPaciente='" + idPaciente + "'; ";

                MySqlConnection conex = new MySqlConnection();
                string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + pass + ";" + "database=" + bd + ";";
                conex.ConnectionString = cadenaConexion;
                conex.Open();

                MySqlDataReader reader;
                MySqlCommand cmd = new MySqlCommand(query, conex);
                reader = cmd.ExecuteReader();

                if (reader != null)
                {
                    while (reader.Read())
                    {
                        auxDientes = reader.GetString(0);
                    }
                }
                else
                {
                    MessageBox.Show("error con los datos");
                }
                conex.Close();

                conex.Open();

                string query2 = "UPDATE tratado SET " + nombreProcedimietnto + " = '" + auxDientes + dientes + "' WHERE IdPaciente=" + idPaciente + ";";
                MySqlCommand cmd2 = new MySqlCommand(query2, conex);
                cmd2.ExecuteNonQuery();

                conex.Close();

                aux = true;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            return aux;
        }

        static public void cancelarCitaVieja()
        {

            try
            {
                string auxFecha = DateTime.Now.Date.ToShortDateString();
                MySqlConnection conex = new MySqlConnection();
                string query = "UPDATE consulta SET estado = 'Cancelada' WHERE fecha < '" + auxFecha + "' AND estado = 'Pendiente' AND id_Consulta <> 0;";
                string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + pass + ";" + "database=" + bd + ";";
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                MySqlCommand cmd = new MySqlCommand(query, conex);
                cmd.ExecuteNonQuery();
                conex.Close();



            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        static public bool validarDisponibilidadCita()
        {
            bool aux = true;

            MySqlConnection conex = new MySqlConnection();
            string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + pass + ";" + "database=" + bd + ";";
            conex.ConnectionString = cadenaConexion;
            try
            {

                conex.Open();

                string auxQuery = "SELECT * FROM citas WHERE fecha = '" + fecha + "' AND especialidad = '" + especialidad + "' AND hora = '" + valHora + "' ";
                MySqlCommand auxCmd = new MySqlCommand(auxQuery, conex);
                MySqlDataReader auxReader = auxCmd.ExecuteReader();

                if (auxReader.HasRows)
                {
                    aux = false;
                }
                conex.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            conex.Close();
            return aux;
        }

        static public void eliminarCitaCancelada()
        {
            MySqlConnection conex = new MySqlConnection();
            string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + pass + ";" + "database=" + bd + ";";
            conex.ConnectionString = cadenaConexion;
            try
            {
                MySqlDataReader reader = null;
                string query = "SELECT id_Citas FROM citas WHERE fecha = '" + fecha + "' AND especialidad = '" + especialidad + "' AND hora = '" + valHora + "'; ";
                conex.Open();

                string auxIdCita = "";
                MySqlCommand cmd = new MySqlCommand(query, conex);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        auxIdCita = reader.GetString(0);
                    }
                }

                conex.Close();


                conex.Open();

                string auxQuery = "DELETE FROM citas WHERE id_Citas = '"+ auxIdCita + "'; ";
                MySqlCommand auxCmd = new MySqlCommand(auxQuery, conex);
                MySqlDataReader auxReader = auxCmd.ExecuteReader();

                conex.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            conex.Close();
        }


        static public List<Object> listarCalendario()
        {
            MySqlDataReader reader = null;
            MySqlConnection conex = new MySqlConnection();
            List<Object> lista = new List<Object>();

            string fechaCalendario;

            Regex expMes = new Regex(@"^[0-9]{1}$");

            if (expMes.IsMatch(calMes))

            {
                string mesFormato = "0" + calMes;
                calMes = mesFormato;
                
            }

            fechaCalendario = calDia + "/" + calMes + "/" + calYear;

            string query = "SELECT hora, duracion FROM consulta WHERE fecha = '"+fechaCalendario+"' AND especialidad = '"+especialidad+"' AND estado = 'Pendiente' ORDER BY hora ASC; ";
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
                        string Hora = reader.GetString(0);
                        string Duracion = reader.GetString(1);

                        lista.Add(new { Hora, Duracion });
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
            return lista;
        }
    }
}
