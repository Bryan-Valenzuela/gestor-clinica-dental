using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorClinica.models
{
    class Cobro
    {
        static public int Id_Cobro { get; set; }
        static public int idConsultas { get; set; }
        static public double costo { get; set; }
        static public string fecha { get; set; }
        static public string mPago { get; set; }
        static public string factura { get; set; }
        static public string procedimiento { get; set; }

        static public string corteEfectivo { get; set; }
        static public string corteTarjeta { get; set; }
        static public string corteTransferencia { get; set; }
        static public string corteEfectivoCant { get; set; }
        static public string corteTarjetaCant { get; set; }
        static public string corteTransferenciaCant { get; set; }
        static public string corteTotal { get; set; }
        static public string corteFecha { get; set; }


        public void setearVariables()
        {
            idConsultas = int.Parse("");
            costo = int.Parse("");
            fecha = "";
            mPago = "";
            factura = "";
            
        }

        static public void setearCorte()
        {
            corteEfectivo = "0";
            corteTarjeta = "0";
            corteTransferencia = "0";
            corteEfectivoCant = "0";
            corteTarjetaCant = "0";
            corteTransferenciaCant = "0";
            corteTotal = "0";
            
        }

        static string servidor = "localhost";
        static string bd = "clinicabd";
        static string usuario = "root";
        static string pass = "Stroud25";
        static string puerto = "3306";

        static public bool realizarPago()
        {
            bool aux = false;
            try
            {
                MySqlConnection conex = new MySqlConnection();
                string query = "INSERT INTO cobro (idConsulta, Costo, fecha, mPago, factura, procedimiento) values ('"+idConsultas+"', '" +costo+"', '" +fecha+"', '" +mPago+"', '" +factura+"', '" +procedimiento+"');";
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
        

        static public List<Object> CorteDeCaja()
        {
            setearCorte();
            List<Object> lista = new List<Object>();
            MySqlConnection conex = new MySqlConnection();
            string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + pass + ";" + "database=" + bd + ";";
            conex.ConnectionString = cadenaConexion;
            try
            {
                
                
                
                conex.Open();

                string auxQuery = "SELECT idConsulta FROM cobro WHERE fecha = '" + corteFecha + "';";
                MySqlCommand auxCmd = new MySqlCommand(auxQuery, conex);
                MySqlDataReader auxReader = auxCmd.ExecuteReader();

                if (!auxReader.Read())
                {
                    conex.Close();
                    MessageBox.Show("No se han realizado pagos el dia seleccionado");
                }
                else
                {
                    conex.Close();

                    try
                    {

                        conex.Open();

                        string query = "SELECT SUM(costo) FROM cobro WHERE mPago = 'tarjeta' AND fecha = '" + corteFecha + "';";
                        MySqlCommand cmd = new MySqlCommand(query, conex);
                        MySqlDataReader reader = cmd.ExecuteReader();


                        if (reader.HasRows)
                        {
                                while (reader.Read())
                                {
                                    if (!reader.IsDBNull(0))
                                    {
                                        corteTarjeta = reader.GetString(0);
                                    }                                    
                                }
                            
                        }

                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }


                    conex.Close();

                    try
                    {
                        conex.Open();
                        string query2 = "SELECT SUM(costo) FROM cobro WHERE mPago = 'Transferencia' AND fecha = '" + corteFecha + "';";
                        MySqlCommand cmd2 = new MySqlCommand(query2, conex);
                        MySqlDataReader reader2 = cmd2.ExecuteReader();



                        if (reader2.HasRows)
                        {
                            
                                while (reader2.Read())
                                {
                                    if (!reader2.IsDBNull(0))
                                    {
                                        corteTransferencia = reader2.GetString(0);
                                    }
                                }
                            

                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }

                    conex.Close();

                    try
                    {
                        conex.Open();
                        string query3 = "SELECT SUM(costo) FROM cobro WHERE mPago = 'Efectivo' AND fecha = '" + corteFecha + "';";
                        MySqlCommand cmd3 = new MySqlCommand(query3, conex);
                        MySqlDataReader reader3 = cmd3.ExecuteReader();


                        if (reader3.HasRows)
                        {
                            
                                while (reader3.Read())
                                {
                                    if (!reader3.IsDBNull(0))
                                    {
                                        corteEfectivo = reader3.GetString(0);
                                    }
                                }
                            

                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }

                    conex.Close();



                    try
                    {
                        conex.Open();
                        string query4 = "SELECT SUM(costo) FROM cobro WHERE fecha = '" + corteFecha + "';";
                        MySqlCommand cmd4 = new MySqlCommand(query4, conex);
                        MySqlDataReader reader4 = cmd4.ExecuteReader();


                        if (reader4.HasRows)
                        {
                            
                                while (reader4.Read())
                                {
                                    if (!reader4.IsDBNull(0))
                                    {
                                        corteTotal = reader4.GetString(0);
                                    }
                                }
                            

                        }

                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    conex.Close();




                    try
                    {

                    string query5 = "SELECT id_Cobro AS 'ID Pago', idConsulta AS 'ID Consulta', mPago AS 'Metodo de pago', costo AS 'Costo', procedimiento FROM cobro WHERE fecha = '" + corteFecha + "' ORDER BY mPago;";
                    conex.Open();
                    
                        MySqlCommand cmd5 = new MySqlCommand(query5, conex);
                        MySqlDataReader reader5 = cmd5.ExecuteReader();


                        if (reader5 != null)
                        {
                            while (reader5.Read())
                            {
                                Id_Cobro = int.Parse(reader5.GetString(0));
                                idConsultas = int.Parse(reader5.GetString(1));
                                mPago = reader5.GetString(2);
                                costo = double.Parse(reader5.GetString(3));
                                procedimiento = reader5.GetString(4);

                                string ID_Pago = Id_Cobro.ToString();
                                string ID_Consulta = idConsultas.ToString();
                                string Metodo = mPago;
                                string Costo = costo.ToString();
                                string Procedimiento = procedimiento;
                                

                                lista.Add(new { ID_Pago, ID_Consulta, Metodo, Costo, Procedimiento });
                            }

                        }


                        conex.Close();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    conex.Close();

                    try
                    {
                        conex.Open();
                        string query6 = "SELECT COUNT(costo) FROM cobro WHERE mPago = 'tarjeta' AND fecha = '" + corteFecha + "';";
                        MySqlCommand cmd6 = new MySqlCommand(query6, conex);
                        MySqlDataReader reader6 = cmd6.ExecuteReader();


                        if (reader6.HasRows)
                        {
                            
                                while (reader6.Read())
                                {
                                    if (!reader6.IsDBNull(0))
                                    {
                                        corteTarjetaCant = reader6.GetString(0);
                                    }
                                }
                            

                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    conex.Close();

                    try
                    {
                        conex.Open();
                        string query7 = "SELECT COUNT(costo) FROM cobro WHERE mPago = 'Transferencia' AND fecha = '" + corteFecha + "';";
                        MySqlCommand cmd7 = new MySqlCommand(query7, conex);
                        MySqlDataReader reader7 = cmd7.ExecuteReader();


                        if (reader7.HasRows)
                        {
                            
                                while (reader7.Read())
                                {
                                    if (!reader7.IsDBNull(0))
                                    {
                                        corteTransferenciaCant = reader7.GetString(0);
                                    }
                                }
                            

                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    conex.Close();

                    try
                    {
                        conex.Open();
                        string query8 = "SELECT COUNT(costo) FROM cobro WHERE mPago = 'Efectivo' AND fecha = '" + corteFecha + "';";
                        MySqlCommand cmd8 = new MySqlCommand(query8, conex);
                        MySqlDataReader reader8 = cmd8.ExecuteReader();


                        if (reader8.HasRows)
                        {
                            
                                while (reader8.Read())
                                {
                                    if (!reader8.IsDBNull(0))
                                    {
                                        corteEfectivoCant = reader8.GetString(0);
                                    }
                                }
                            

                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
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

