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
    public partial class AddPAdulto : Form
    {
        Inicio FI;
        public AddPAdulto(Inicio Fmi)
        {
            InitializeComponent();
            FI = Fmi;
            mostrarInfo();
            FI.tituloVentana.Text = "Crear paciente adulto";
            setearCombobox();
        }

        //REGEX
        Regex expTexto = new Regex(@"^[a-zA-ZÀ-ÿ\s]*$");
        Regex expEdad = new Regex(@"^[0-9]{2,3}$");
        Regex expTelefonos = new Regex(@"^[0-9]{7,10}$");

        public void setearCombobox()
        {
            cbAlergiaPenicilina.Items.Add("Si");
            cbAlergiaPenicilina.Items.Add("No");
            cbAlergiaPenicilina.SelectedIndex = 1;

            cbDiabetes.Items.Add("Si");
            cbDiabetes.Items.Add("No");
            cbDiabetes.SelectedIndex = 1;

            cbHipertension.Items.Add("Si");
            cbHipertension.Items.Add("No");
            cbHipertension.SelectedIndex = 1;

            cbHipotension.Items.Add("Si");
            cbHipotension.Items.Add("No");
            cbHipotension.SelectedIndex = 1;

            cbPCoagulacion.Items.Add("Si");
            cbPCoagulacion.Items.Add("No");
            cbPCoagulacion.SelectedIndex = 1;

        }

        string id;
        string expediente = "adulto";

        public void mostrarInfo()
        {
            List<Object> lista = new List<Object>();
            lista = models.Pacientes.infoPaciente();

            id = models.Pacientes.Id_Paciente.ToString();
            txtNombre.Text = models.Pacientes.nombre;
            txtEdad.Text = models.Pacientes.edad;
            txtCel.Text = models.Pacientes.cel;
            txtTel.Text = models.Pacientes.tel;
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();
            ofdSeleccionar.Filter = "Imagenes| *.jpg; *.jpeg";
            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdSeleccionar.Title = "Seleccionar imagen";

            if (ofdSeleccionar.ShowDialog() == DialogResult.OK)
            {
                pbFoto.Image = Image.FromFile(ofdSeleccionar.FileName);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
           

            models.Pacientes.alergiaPenicilina = cbAlergiaPenicilina.SelectedItem.ToString();
            models.Pacientes.probCuabulacion = cbPCoagulacion.SelectedItem.ToString();
            models.Pacientes.diabetes = cbDiabetes.SelectedItem.ToString();
            models.Pacientes.hipotencion = cbHipotension.SelectedItem.ToString();
            models.Pacientes.hipertencion = cbHipertension.SelectedItem.ToString();
            models.Pacientes.tExpediente = expediente;


            MemoryStream ms = new MemoryStream();
            pbFoto.Image.Save(ms, ImageFormat.Jpeg);
            byte[] abyte = ms.ToArray();
            models.Pacientes.foto = abyte;

            DateTime fecha = DateTime.Now.Date;
            string auxFecha = fecha.ToShortDateString();
            models.Pacientes.FechaCreacionExpediente = auxFecha;

            bool aux = models.Pacientes.AgregarPacienteAdulto();

            if (aux == true)
            {
                FI.tituloVentana.Text = "Lista Pacientes " + models.Pacientes.tExpediente;
                FI.formAbierto(new ListaPacientes(FI));
            }


        }
    }
}
