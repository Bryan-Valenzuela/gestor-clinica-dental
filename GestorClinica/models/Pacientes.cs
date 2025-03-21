using MySql.Data.MySqlClient;
using MySql.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace GestorClinica.models
{
    class Pacientes
    {
        static public int Id_Paciente { get; set; }
        static public string tExpediente { get; set; }
        static public string nombre { get; set; }
        static public string edad { get; set; }
        static public string tel { get; set; }
        static public string cel { get; set; }
        static public string telTutuor { get; set; }
        static public string motivoConsulta { get; set; }
        static public byte[] foto { get; set; }
        static public string diabetes { get; set; }
        static public string probCuabulacion { get; set; }
        static public string alergiaPenicilina { get; set; }
        static public string sedacion_AnesteciaGral { get; set; }
        static public string hipertencion { get; set; }
        static public string hipotencion { get; set; }
        static public string FechaCreacionExpediente { get; set; }
        static public string observaciones { get; set; }

        static public string valUsuario { get; set; }
        static public string valPass { get; set; }

        public void setearVariables()
        {
            byte[] listaviacia = (byte[])foto.ToArray().DefaultIfEmpty();
            tExpediente = "";
            nombre = "";
            edad = "";
            tel = "";
            cel = "";
            telTutuor = "";
            motivoConsulta = "";
            foto = listaviacia;
            diabetes = "";
            probCuabulacion = "";
            alergiaPenicilina = "";
            sedacion_AnesteciaGral = "";
            hipertencion = "";
            hipotencion = "";
            FechaCreacionExpediente = "";
            observaciones = "";
        }



        MySqlConnection conex = new MySqlConnection();
        static string servidor = "localhost";
        static string bd = "clinicabd";
        static string usuario = "root";
        static string pass = "Stroud25";
        static string puerto = "3306";

        string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + pass + ";" + "database=" + bd + ";";

        public MySqlConnection establecerConexion()
        {
            try
            {
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                MessageBox.Show("se logro la conexion");
                return conex;
            }
            catch (MySqlException e)
            {
                MessageBox.Show("nos e pudo conectar la base de datos" + e.ToString());
                return null;
            }

        }

        //Funciones

        static public List<Object> ListarPacientes()
        {
            MySqlDataReader reader = null;
            MySqlConnection conex = new MySqlConnection();
            List<Object> lista = new List<Object>();
            string query = "SELECT id_Pacientes, nombre, cel, telTutor FROM pacientes WHERE tipoExpediente = '" + tExpediente + "'";
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
                        Id_Paciente = int.Parse(reader.GetString(0));
                        nombre = reader.GetString(1);
                        cel = reader.GetString(2);
                        telTutuor = reader.GetString(3);

                        string ID_Paciente = Id_Paciente.ToString();
                        string Nombre = nombre;
                        string Celular = cel;
                        string Tutor = telTutuor;



                        lista.Add(new { ID_Paciente, Nombre, Celular, Tutor });
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

        static public List<Object> buscarPacientes(string dato)
        {
            MySqlDataReader reader = null;
            MySqlConnection conex = new MySqlConnection();
            List<Object> lista = new List<Object>();
            string query = "SELECT id_Pacientes, nombre, cel, telTutor FROM pacientes WHERE tipoExpediente = '" + tExpediente + "' AND nombre = '" + dato + "' ";
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
                        Id_Paciente = int.Parse(reader.GetString(0));
                        nombre = reader.GetString(1);
                        cel = reader.GetString(2);
                        telTutuor = reader.GetString(3);
                        lista.Add(new { Id_Paciente, nombre, cel, telTutuor });
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

        static public List<Object> infoPaciente()
        {
            MySqlConnection conex = new MySqlConnection();
            List<Object> lista = new List<Object>();

            if (tExpediente == "general")
            {
                try
                {
                    
                    string query = "SELECT p.id_Pacientes, p.nombre, p.tipoExpediente, p.edad, p.cel, p.telTutor, p.tel, p.fechaCreacion, p.motivoConsulta FROM pacientes p WHERE p.id_Pacientes = '" + Id_Paciente.ToString() + "' AND p.tipoExpediente = '" + tExpediente + "' ";
                    string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + pass + ";" + "database=" + bd + ";";
                    conex.ConnectionString = cadenaConexion;
                    conex.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conex);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Id_Paciente = int.Parse(reader.GetString(0));
                            nombre = reader.GetString(1);
                            tExpediente = reader.GetString(2);
                            edad = reader.GetString(3);
                            cel = reader.GetString(4);
                            telTutuor = reader.GetString(5);
                            tel = reader.GetString(6);
                            FechaCreacionExpediente = reader.GetString(7);
                            motivoConsulta = reader.GetString(8);

                            lista.Add(new { Id_Paciente, nombre, tExpediente, edad, cel, telTutuor, tel, FechaCreacionExpediente, motivoConsulta });
                        }
                        conex.Close();
                    }
                    else
                    {
                        MessageBox.Show("error con los datos");
                    }
                    conex.Close();
                }
                catch (MySqlException ex)
                {
                    conex.Close();
                    MessageBox.Show(ex.Message.ToString());
                }
                conex.Close();
            }
            else
            {
                try
                {
                    
                    string query = "SELECT p.id_Pacientes, p.nombre, p.tipoExpediente, p.edad, p.cel, p.telTutor, p.tel, p.fechaCreacion, e.observaciones, p.motivoConsulta FROM pacientes p INNER JOIN expediente e ON p.id_Pacientes=e.IdPaciente WHERE p.id_Pacientes = '" + Id_Paciente.ToString() + "' AND p.tipoExpediente = '" + tExpediente + "' ";
                    string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + pass + ";" + "database=" + bd + ";";
                    conex.ConnectionString = cadenaConexion;
                    conex.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conex);
                    MySqlDataReader reader = cmd.ExecuteReader();



                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Id_Paciente = int.Parse(reader.GetString(0));
                            nombre = reader.GetString(1);
                            tExpediente = reader.GetString(2);
                            edad = reader.GetString(3);
                            cel = reader.GetString(4);
                            telTutuor = reader.GetString(5);
                            tel = reader.GetString(6);
                            FechaCreacionExpediente = reader.GetString(7);
                            observaciones = reader.GetString(8);
                            motivoConsulta = reader.GetString(9);

                            
                        }
                        conex.Close();
                    }
                    else
                    {
                        MessageBox.Show("error con los datos");
                    }
                    conex.Close();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                conex.Close();
            }


            conex.Close();
            return lista;
        }


        static public bool AgregarPacienteGral()
        {
            bool aux = false;
            try
            {
                MySqlConnection conex = new MySqlConnection();
                string query = "INSERT INTO pacientes (tipoExpediente,nombre,edad,tel,cel,telTutor,motivoConsulta,fechaCreacion) VALUES ( '" + tExpediente + "','" + nombre + "', '" + edad + "', '" + tel + "', '" + cel + "', '" + telTutuor + "','" + motivoConsulta + "','"+FechaCreacionExpediente+"'); ";
                string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + pass + ";" + "database=" + bd + ";";
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                MySqlCommand cmd = new MySqlCommand(query, conex);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Datos guardados exitosamente");
                conex.Close();

                aux = true;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            return aux;
        }

        static public bool AgregarPacienteMenor()
        {
            bool aux = false;
            try
            {
                MySqlConnection conex = new MySqlConnection();
                string query = "UPDATE pacientes SET tipoExpediente='" + tExpediente + "', foto=@imagen, alergiaPenicilina='" + alergiaPenicilina + "', problemasCoabulacion='" + probCuabulacion + "', diabetes='" + diabetes + "', sedacionConcienteAnesteciaGral='" + sedacion_AnesteciaGral + "', fechaCreacion='" + FechaCreacionExpediente + "' WHERE id_Pacientes='" + Id_Paciente + "'; ";
                string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + pass + ";" + "database=" + bd + ";";
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                MySqlCommand cmd = new MySqlCommand(query, conex);
                cmd.Parameters.AddWithValue("imagen", foto);
                cmd.ExecuteNonQuery();

                string query2 = "INSERT INTO expediente (IdPaciente,fecha,alergias,observaciones) VALUES ('" + Id_Paciente + "','" + FechaCreacionExpediente + "','','');";
                MySqlCommand cmd2 = new MySqlCommand(query2, conex);
                cmd2.ExecuteNonQuery();

                string query3 = "INSERT INTO tratamiento (IdPaciente,limpieza,resina,ionomeroVidrio,pulpotomia,coronas,extraccion,mantenedorEspacios,sedacionConciente_ON,blanqueamiento,protesisFija_Removible_Total,otros) VALUES ('" + Id_Paciente + "', '','','','','','','','','','','');";
                MySqlCommand cmd3 = new MySqlCommand(query3, conex);
                cmd3.ExecuteNonQuery();

                string query4 = "INSERT INTO tratado (IdPaciente,limpieza,resina,ionomeroVidrio,pulpotomia,coronas,extraccion,mantenedorEspacios,sedacionConciente_ON,blanqueamiento,protesisFija_Removible_Total,otros) VALUES ('" + Id_Paciente + "', '','','','','','','','','','','');";
                MySqlCommand cmd4 = new MySqlCommand(query4, conex);
                cmd4.ExecuteNonQuery();


                MessageBox.Show("Datos guardados exitosamente");
                conex.Close();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            return aux = true;
        }

        static public bool AgregarPacienteAdulto()
        {
            bool aux = false;
            try
            {
                MySqlConnection conex = new MySqlConnection();
                string query = "UPDATE pacientes SET tipoExpediente='" + tExpediente + "', foto=@imagen, alergiaPenicilina='" + alergiaPenicilina + "', problemasCoabulacion='" + probCuabulacion + "', diabetes='" + diabetes + "', hipertencion='" +hipertencion +"', hipotencion='" +hipotencion +"', fechaCreacion='" + FechaCreacionExpediente + "' WHERE id_Pacientes='" + Id_Paciente + "'; ";
                string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + pass + ";" + "database=" + bd + ";";
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                MySqlCommand cmd = new MySqlCommand(query, conex);
                cmd.Parameters.AddWithValue("imagen",foto);
                cmd.ExecuteNonQuery();
                conex.Close();

                conex.Open();
                string query2 = "INSERT INTO expediente (IdPaciente,fecha,alergias,observaciones) VALUES ('" + Id_Paciente + "','" + FechaCreacionExpediente + "','','');";
                MySqlCommand cmd2 = new MySqlCommand(query2, conex);
                cmd2.ExecuteNonQuery();
                conex.Close();

                conex.Open();
                string query3 = "INSERT INTO tratamiento (IdPaciente,limpieza,resina,ionomeroVidrio,pulpotomia,coronas,extraccion,mantenedorEspacios,sedacionConciente_ON,blanqueamiento,protesisFija_Removible_Total,otros) VALUES ('" + Id_Paciente + "', '','','','','','','','','','','');";
                MySqlCommand cmd3 = new MySqlCommand(query3, conex);
                cmd3.ExecuteNonQuery();
                conex.Close();

                conex.Open();
                string query4 = "INSERT INTO tratado (IdPaciente,limpieza,resina,ionomeroVidrio,pulpotomia,coronas,extraccion,mantenedorEspacios,sedacionConciente_ON,blanqueamiento,protesisFija_Removible_Total,otros) VALUES ('" + Id_Paciente + "', '','','','','','','','','','','');";
                MySqlCommand cmd4 = new MySqlCommand(query4, conex);
                cmd4.ExecuteNonQuery();
                conex.Close();

                MessageBox.Show("Datos guardados exitosamente");
                conex.Close();

                aux = true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            return aux;
        }

        static public void validarCpanel()
        {
            


            try
            {
                MySqlConnection conex = new MySqlConnection();
                string query = "SELECT nombreUsuario, passwordUsuario FROM usuario WHERE id_Usuario = 1";
                string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + pass + ";" + "database=" + bd + ";";
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                MySqlCommand cmd = new MySqlCommand(query, conex);
                MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            valUsuario = reader.GetString(0);
                            valPass = reader.GetString(1);
                        }
                        conex.Close();
                    }
                    else
                    {
                        MessageBox.Show("error con los datos");
                    }
                conex.Close();
            }
            catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
        }

        static public void infoPacienteExpedienteAdulto()
        {
            MySqlConnection conex = new MySqlConnection();

            
                try
                {

                    string query = "SELECT diabetes, problemasCoabulacion, alergiaPenicilina, hipertencion, hipotencion FROM pacientes WHERE id_Pacientes = '" + Id_Paciente+ "' ";
                    string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + pass + ";" + "database=" + bd + ";";
                    conex.ConnectionString = cadenaConexion;
                    conex.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conex);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            diabetes = reader.GetString(0);
                            probCuabulacion = reader.GetString(1);
                            alergiaPenicilina = reader.GetString(2);
                            hipertencion = reader.GetString(3);
                            hipotencion = reader.GetString(4);
                            

                        }
                        conex.Close();
                    }
                    else
                    {
                        MessageBox.Show("error con los datos");
                    }
                    conex.Close();
                }
                catch (MySqlException ex)
                {
                    conex.Close();
                    MessageBox.Show(ex.Message.ToString());
                }
                conex.Close();
            
        }


        static public void infoPacienteExpedienteMEnor()
        {
            MySqlConnection conex = new MySqlConnection();
            

           
                try
                {

                    string query = "SELECT diabetes, problemasCoabulacion, alergiaPenicilina, sedacionConcienteAnesteciaGral FROM pacientes WHERE id_Pacientes = '" + Id_Paciente+ "' ";
                    string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + pass + ";" + "database=" + bd + ";";
                    conex.ConnectionString = cadenaConexion;
                    conex.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conex);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            diabetes = reader.GetString(0);
                            probCuabulacion = reader.GetString(1);
                            alergiaPenicilina = reader.GetString(2);
                            sedacion_AnesteciaGral = reader.GetString(3);
                        }
                        conex.Close();
                    }
                    else
                    {
                        MessageBox.Show("error con los datos");
                    }
                    conex.Close();
                }
                catch (MySqlException ex)
                {
                    conex.Close();
                    MessageBox.Show(ex.Message.ToString());
                }
                conex.Close();
            
        }





    }
}
