using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorClinica
{
    public partial class AgregarCita : Form
    {
        Inicio FI;
        public AgregarCita(Inicio Fmi)
        {
            InitializeComponent();
            FI = Fmi;
            FI.tituloVentana.Text = "Agendar cita";
            txtID.Text = models.Pacientes.Id_Paciente.ToString();
            txtNombre.Text = models.Pacientes.nombre;
            setearProcedimientos();
            setearCombobox();
        }

        MySqlConnection conex = new MySqlConnection();
        static string servidor = "localhost";
        static string bd = "clinicabd";
        static string usuario = "root";
        static string pass = "Stroud25";
        static string puerto = "3306";

        public string listaDientes="";

        public void verificarCheckbox()
        {
            //sector 1
            if (cbD11.Checked)
            {
                listaDientes = listaDientes + "11, ";
            }
            if (cbD12.Checked)
            {
                listaDientes = listaDientes + "12, ";
            }
            if (cbD13.Checked)
            {
                listaDientes = listaDientes + "13, ";
            }
            if (cbD14.Checked)
            {
                listaDientes = listaDientes + "14, ";
            }
            if (cbD15.Checked)
            {
                listaDientes = listaDientes + "15, ";
            }
            if (cbD16.Checked)
            {
                listaDientes = listaDientes + "16, ";
            }
            if (cbD17.Checked)
            {
                listaDientes = listaDientes + "17, ";
            }
            if (cbD18.Checked)
            {
                listaDientes = listaDientes + "18, ";
            }
            if (cbD51.Checked)
            {
                listaDientes = listaDientes + "51, ";
            }
            if (cbD52.Checked)
            {
                listaDientes = listaDientes + "52, ";
            }
            if (cbD53.Checked)
            {
                listaDientes = listaDientes + "53, ";
            }
            if (cbD54.Checked)
            {
                listaDientes = listaDientes + "54, ";
            }
            if (cbD55.Checked)
            {
                listaDientes = listaDientes + "55, ";
            }

            //sector 2
            if (cbD21.Checked)
            {
                listaDientes = listaDientes + "21, ";
            }
            if (cbD22.Checked)
            {
                listaDientes = listaDientes + "22, ";
            }
            if (cbD23.Checked)
            {
                listaDientes = listaDientes + "23, ";
            }
            if (cbD24.Checked)
            {
                listaDientes = listaDientes + "24, ";
            }
            if (cbD25.Checked)
            {
                listaDientes = listaDientes + "25, ";
            }
            if (cbD26.Checked)
            {
                listaDientes = listaDientes + "26, ";
            }
            if (cbD27.Checked)
            {
                listaDientes = listaDientes + "27, ";
            }
            if (cbD28.Checked)
            {
                listaDientes = listaDientes + "28, ";
            }
            if (cbD61.Checked)
            {
                listaDientes = listaDientes + "61, ";
            }
            if (cbD62.Checked)
            {
                listaDientes = listaDientes + "62, ";
            }
            if (cbD63.Checked)
            {
                listaDientes = listaDientes + "63, ";
            }
            if (cbD64.Checked)
            {
                listaDientes = listaDientes + "64, ";
            }
            if (cbD65.Checked)
            {
                listaDientes = listaDientes + "65, ";
            }

            //sector 3
            if (cbD31.Checked)
            {
                listaDientes = listaDientes + "31, ";
            }
            if (cbD32.Checked)
            {
                listaDientes = listaDientes + "32, ";
            }
            if (cbD33.Checked)
            {
                listaDientes = listaDientes + "33, ";
            }
            if (cbD34.Checked)
            {
                listaDientes = listaDientes + "34, ";
            }
            if (cbD35.Checked)
            {
                listaDientes = listaDientes + "35, ";
            }
            if (cbD36.Checked)
            {
                listaDientes = listaDientes + "36, ";
            }
            if (cbD37.Checked)
            {
                listaDientes = listaDientes + "37, ";
            }
            if (cbD38.Checked)
            {
                listaDientes = listaDientes + "38, ";
            }
            if (cbD71.Checked)
            {
                listaDientes = listaDientes + "71, ";
            }
            if (cbD72.Checked)
            {
                listaDientes = listaDientes + "72, ";
            }
            if (cbD73.Checked)
            {
                listaDientes = listaDientes + "73, ";
            }
            if (cbD74.Checked)
            {
                listaDientes = listaDientes + "74, ";
            }
            if (cbD75.Checked)
            {
                listaDientes = listaDientes + "75, ";
            }

            //sector 4
            if (cbD41.Checked)
            {
                listaDientes = listaDientes + "41, ";
            }
            if (cbD42.Checked)
            {
                listaDientes = listaDientes + "42, ";
            }
            if (cbD43.Checked)
            {
                listaDientes = listaDientes + "43, ";
            }
            if (cbD44.Checked)
            {
                listaDientes = listaDientes + "44, ";
            }
            if (cbD45.Checked)
            {
                listaDientes = listaDientes + "45, ";
            }
            if (cbD46.Checked)
            {
                listaDientes = listaDientes + "46, ";
            }
            if (cbD47.Checked)
            {
                listaDientes = listaDientes + "47, ";
            }
            if (cbD48.Checked)
            {
                listaDientes = listaDientes + "48, ";
            }
            if (cbD81.Checked)
            {
                listaDientes = listaDientes + "81, ";
            }
            if (cbD82.Checked)
            {
                listaDientes = listaDientes + "82, ";
            }
            if (cbD83.Checked)
            {
                listaDientes = listaDientes + "83, ";
            }
            if (cbD84.Checked)
            {
                listaDientes = listaDientes + "84, ";
            }
            if (cbD85.Checked)
            {
                listaDientes = listaDientes + "85, ";
            }
        }


        public void setearProcedimientos()
        {
            MySqlConnection conex = new MySqlConnection();
            string query = "SELECT id_Procedimientos, nombre FROM procedimientos;";
            string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + pass + ";" + "database=" + bd + ";";
            conex.ConnectionString = cadenaConexion;
            conex.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conex);
                MySqlDataAdapter datos = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                datos.Fill(dt);

                cbProcedimientos.ValueMember = "id_Procedimientos";
                cbProcedimientos.DisplayMember = "nombre";
                cbProcedimientos.DataSource = dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            conex.Close();
        }

        public void setearCombobox()
        {
            cbEspecialidad.Items.Add("odontologia general");
            cbEspecialidad.Items.Add("odontopediatria");
            cbEspecialidad.Items.Add("ortodoncia");
            cbEspecialidad.SelectedIndex = 0;
            

            cbHora.Items.Add("09:00");
            cbHora.Items.Add("09:30");
            cbHora.Items.Add("10:00");
            cbHora.Items.Add("10:30");
            cbHora.Items.Add("11:00");
            cbHora.Items.Add("11:30");
            cbHora.Items.Add("12:00");
            cbHora.Items.Add("12:30");

            cbHora.Items.Add("15:30");
            cbHora.Items.Add("16:00");
            cbHora.Items.Add("16:30");
            cbHora.Items.Add("17:00");
            cbHora.Items.Add("17:30");
            cbHora.Items.Add("18:00");
            cbHora.Items.Add("18:30");
            cbHora.SelectedIndex = 0;

            cbDuracion.Items.Add("0.5");
            cbDuracion.Items.Add("1.0");
            cbDuracion.Items.Add("1.5");
            cbDuracion.Items.Add("2.0");  
            cbDuracion.SelectedIndex = 0;

            DateTime fecha = DateTime.Now.Date;
            dateTimePicker.Text = fecha.ToShortDateString();

        }

        public void validarCita()
        {
            

            string [] horario = new [] { "09:00", "09:30", "10:00", "10:30", "11:00", "11:30", "12:00", "12:30", "13:00", "13:30", "14:00", "14:30", "15:00", "15:30", "16:00", "16:30", "17:00", "17:30", "18:00", "18:30", "19:00" };
            int index = -1;
            string horaInicio = cbHora.SelectedItem.ToString();
            double reps = 2 * double.Parse(cbDuracion.SelectedItem.ToString());

            for (int i=0; i<horario.Length; i ++)
            {
                
                if (horario[i].ToString() == horaInicio)
                {
                    index = i;
                    break;
                }
                
            }

            bool auxBandera = true;
            int auxIndex = index;
            models.Consultas.especialidad = cbEspecialidad.SelectedItem.ToString();
            DateTime fecha = dateTimePicker.Value.Date;
            models.Consultas.fecha = fecha.ToShortDateString();

            //validar disponibilidad
            for (int i = 0; i < reps; i++)
            {
                models.Consultas.valHora = horario[auxIndex];

                bool aux = models.Consultas.validarDisponibilidadCita();

                if(aux == false)
                {
                    auxBandera = aux;
                    break;

                }
                

                
                auxIndex++;
            }

            if(auxBandera == true)
            {
                verificarCheckbox();
                models.Consultas.idPaciente = models.Pacientes.Id_Paciente;

                if (listaDientes == "")
                {
                    models.Consultas.dientes = "R, ";
                }
                else
                {
                    models.Consultas.dientes = listaDientes;
                }
                

                models.Consultas.idProcedimiento = int.Parse(cbProcedimientos.SelectedValue.ToString());
                models.Consultas.especialidad = cbEspecialidad.SelectedItem.ToString();
                models.Consultas.hora = cbHora.SelectedItem.ToString();
                models.Consultas.duracion = double.Parse(cbDuracion.SelectedItem.ToString());
                models.Consultas.estado = "Pendiente";

                bool aux = models.Consultas.AgregarConsulta();

                if (aux == true)
                {
                    int auxIndexAgregar = index;

                    //validar agregar los espacios para las validaciones de las citas
                    for (int i = 0; i < reps; i++)
                    {
                        models.Consultas.valHora = horario[auxIndexAgregar];

                        models.Consultas.agregarCitaValidacion();

                        auxIndexAgregar++;
                    }




                    if (models.Pacientes.tExpediente == "menor" || models.Pacientes.tExpediente == "adulto")
                    {
                        FI.formAbierto(new InfoPaciente(FI));
                    }
                    if (models.Pacientes.tExpediente == "general")
                    {
                        FI.formAbierto(new InfoPGral(FI));
                    }

                }
            }
            else
            {
                MessageBox.Show("Horario no disponible");
            }
        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {

            if (dateTimePicker.Value.Date >= DateTime.Now.Date)
            {
                if (cbEspecialidad.SelectedIndex != -1)
                {
                    if (cbHora.SelectedIndex != -1)
                    {
                        if (cbDuracion.SelectedIndex != -1)
                        {
                            validarCita();
                        }
                        else
                        {
                            MessageBox.Show("Seleccione una duracion");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seleccione un horario");
                    }
                }
                else 
                {
                    MessageBox.Show("Seleccione una especialidad");
                }

            }
            else
            {
                MessageBox.Show("No se pueden agendar citas en dias anteriores al actual");
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            models.Consultas.especialidad = cbEspecialidad.SelectedItem.ToString();
            CalendarioMensual CM = new CalendarioMensual();
            CM.Show();
        }
    }
}
