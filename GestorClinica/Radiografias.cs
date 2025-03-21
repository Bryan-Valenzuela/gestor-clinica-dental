using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorClinica
{
    public partial class Radiografias : Form
    {
        Inicio FI;
        public Radiografias(Inicio Fmi)
        {
            InitializeComponent();
            FI = Fmi;
            FI.tituloVentana.Text = "Radiografias";
            cargarRadiografias();
        }


        public void cargarRadiografias()
        {
            List<Object> lista = new List<Object>();
            models.Radiografias.idPaciente = models.Pacientes.Id_Paciente;
            lista = models.Radiografias.ListarRadiografias();
            dataGridView.DataSource = lista.ToList();
            
        }


        private void btnAgregarRadiografia_Click(object sender, EventArgs e)
        {
            Regex expTexto = new Regex(@"^[a-zA-ZÀ-ÿ0-9\s]*$");

            if (txtNombre != null && txtNombre.Text.Trim() != "")
            {
                if (expTexto.IsMatch(txtNombre.Text.Trim()))
                {

                    models.Radiografias.idPaciente = models.Pacientes.Id_Paciente;

                    DateTime fecha = DateTime.Now.Date;
                    string auxFecha = fecha.ToShortDateString();
                    models.Radiografias.fecha = auxFecha;
                    models.Radiografias.titulo = txtNombre.Text.Trim();

                    MemoryStream ms = new MemoryStream();
                    pbRadiografia.Image.Save(ms, ImageFormat.Jpeg);
                    byte[] abyte = ms.ToArray();
                    models.Radiografias.Radiografia = abyte;

                    models.Radiografias.guardarRadiografias();

                    cargarRadiografias();
                }
                else
                {
                    MessageBox.Show("Solo se permiten letras y numeros en el campo nombre", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("se necesita un nombre");
            }

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();
            ofdSeleccionar.Filter = "Imagenes| *.jpg; *.jpeg";
            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdSeleccionar.Title = "Seleccionar imagen";

            if (ofdSeleccionar.ShowDialog() == DialogResult.OK)
            {
                pbRadiografia.Image = Image.FromFile(ofdSeleccionar.FileName);
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            string id = dataGridView.CurrentRow.Cells[0].Value.ToString();

            try
            {
                MySqlConnection conex = new MySqlConnection();
                string servidor = "localhost";
                string bd = "clinicabd";
                string usuario = "root";
                string pass = "Stroud25";
                string puerto = "3306";

                string query = "SELECT radiografia FROM radiografias WHERE id_Radiografias = '" + id+"';";
                string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + pass + ";" + "database=" + bd + ";";
                conex.ConnectionString = cadenaConexion;
                conex.Open();

                MySqlCommand cmd = new MySqlCommand(query, conex);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);

                byte[] img = (byte[])table.Rows[0][0];
                MemoryStream ms = new MemoryStream(img);
                pbRadiografia.Image = Image.FromStream(ms);



            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (models.Pacientes.tExpediente == "menor")
            {
                FI.formAbierto(new TratamientoKids(FI));
            }
            if (models.Pacientes.tExpediente == "adulto")
            {
                FI.formAbierto(new TratamientoAdulto(FI));
            }

        }
    }
}
