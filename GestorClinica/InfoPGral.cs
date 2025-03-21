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
    public partial class InfoPGral : Form
    {
        string tExpediente ;
        Inicio FI;
        public InfoPGral(Inicio Fmi)

        {
            InitializeComponent();
            FI = Fmi;
            FI.tituloVentana.Text = "Informacion paciente " + models.Pacientes.tExpediente;
            listarPacientes();
        }

        public void listarPacientes()
        {
            List<Object> lista = new List<Object>();
            List<Object> lista2 = new List<Object>();
            lista = models.Pacientes.infoPaciente();
          
            txtID.Text = models.Pacientes.Id_Paciente.ToString();
            txtNombre.Text = models.Pacientes.nombre;
            tExpediente = models.Pacientes.tExpediente;
            txtEdad.Text = models.Pacientes.edad;
            txtCel.Text = models.Pacientes.cel;
            txtTelTutor.Text = models.Pacientes.telTutuor;
            txtTel.Text = models.Pacientes.tel;
            txtFechaRegistro.Text = models.Pacientes.FechaCreacionExpediente;
            txtDM.Text = models.Pacientes.observaciones;
            txtMotivoConsulta.Text = models.Pacientes.motivoConsulta;


            string aux = models.Pacientes.Id_Paciente.ToString();
            lista2 = models.Consultas.infoPacienteConsultas(aux);
            dataGridView.DataSource = lista2.ToList();
        }

        private void btnAPKid_Click(object sender, EventArgs e)
        {
            models.Pacientes.Id_Paciente = int.Parse(txtID.Text);
            FI.formAbierto(new AddPKid(FI));
        }

        private void btnAPAdulto_Click(object sender, EventArgs e)
        {
            models.Pacientes.Id_Paciente = int.Parse(txtID.Text);
            FI.formAbierto(new AddPAdulto(FI));
        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            models.Pacientes.Id_Paciente = int.Parse(txtID.Text);
            FI.formAbierto(new AgregarCita(FI));
        }
    }
}
