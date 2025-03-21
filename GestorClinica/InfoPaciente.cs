using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorClinica
{
    public partial class InfoPaciente : Form
    {
        Inicio FI;
        public InfoPaciente(Inicio Fmi)
        {
            InitializeComponent();
            FI = Fmi;
            FI.tituloVentana.Text = "Informacion paciente " + models.Pacientes.tExpediente ;
            listarPacientes();
        }

        string expediente;

        public void listarPacientes()
        {
            List<Object> lista = new List<Object>();
            List<Object> lista2 = new List<Object>();
            lista = models.Pacientes.infoPaciente();

            txtID.Text = models.Pacientes.Id_Paciente.ToString();
            txtNombre.Text = models.Pacientes.nombre;
            expediente = models.Pacientes.tExpediente;
            txtEdad.Text = models.Pacientes.edad;
            txtCel.Text = models.Pacientes.cel;
            txtTelTutor.Text = models.Pacientes.telTutuor;
            txtTel.Text = models.Pacientes.tel;
            txtFechaRegistro.Text = models.Pacientes.FechaCreacionExpediente;
            txtDM.Text = models.Pacientes.observaciones;
            txtMotivoConsulta.Text = models.Pacientes.motivoConsulta;

            try
            {
                MySqlConnection conex = new MySqlConnection();
                string servidor = "localhost";
                string bd = "clinicabd";
                string usuario = "root";
                string pass = "Stroud25";
                string puerto = "3306";

                string query = "SELECT foto FROM pacientes WHERE id_Pacientes = '" + models.Pacientes.Id_Paciente.ToString() + "';";
                string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + pass + ";" + "database=" + bd + ";";
                conex.ConnectionString = cadenaConexion;
                conex.Open();
            
                MySqlCommand cmd = new MySqlCommand(query, conex);
                
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        da.Fill(table);

                        byte[] img = (byte[])table.Rows[0][0];
                        MemoryStream ms = new MemoryStream(img);
                        pbFoto.Image = Image.FromStream(ms);
                

                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }






            string aux = models.Pacientes.Id_Paciente.ToString();
            lista2 = models.Consultas.infoPacienteConsultas(aux);
            dataGridView.DataSource = lista2.ToList();
        }

        private void btnTratamiento_Click(object sender, EventArgs e)
        {
            string aux = models.Pacientes.tExpediente;
            if(aux == "adulto")
            {
                FI.formAbierto(new TratamientoAdulto(FI));
            }
            if (aux == "menor")
            {
                FI.formAbierto(new TratamientoKids(FI));
            }

        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            FI.formAbierto(new AgregarCita(FI));
        }
    }
}
