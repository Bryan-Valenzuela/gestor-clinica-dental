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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            PMAgenda.Visible = false;
            PMPacientes.Visible = false;
            models.Consultas.cancelarCitaVieja();
        }

        //esconder menu
        public void hideMenu()
        {
            if(PMPacientes.Visible == true)
            {
                PMPacientes.Visible = false;
            }
            if (PMAgenda.Visible == true)
            {
                PMAgenda.Visible = false;
            }
        }

        //mostrar menu
        public void showMenu(Panel menu)
        {
            if(menu.Visible == false)
            {
                hideMenu();
                menu.Visible = true;
            }
            else
            {
                menu.Visible = true;
            }
        }

        //abir form en panel

        public Form formActivo = null;
        
        public void formAbierto( Form formulario )
        {
            if (formActivo != null)
            {
                formActivo.Close();
            }
            formActivo = formulario;
            //metodo para poner el form en el panel
            formulario.TopLevel = false;
            formulario.Dock = DockStyle.Fill;
            PContenido.Controls.Add(formulario);
            PContenido.Tag = formulario;
            formulario.Show();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            models.Pacientes objetoConexion = new models.Pacientes();
            objetoConexion.establecerConexion();
        }

        private void inicio_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        //Botones

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            hideMenu();
            showMenu(PMPacientes);
        }

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            hideMenu();
            showMenu(PMAgenda);
        }

        private void btnPGral_Click(object sender, EventArgs e)
        {
            tituloVentana.Text = "Paciente general";
            models.Pacientes.tExpediente = "general";
            formAbierto(new ListaPacientes(this));
        }

        private void btnPKids_Click(object sender, EventArgs e)
        {
            tituloVentana.Text = "Paciente menor";
            models.Pacientes.tExpediente = "menor";
            formAbierto(new ListaPacientes(this));
        }

        private void btnPAdulto_Click(object sender, EventArgs e)
        {
            tituloVentana.Text = "Paciente adulto";
            models.Pacientes.tExpediente = "adulto";
            formAbierto(new ListaPacientes(this));
        }

        private void btnOdontologiaGeneral_Click(object sender, EventArgs e)
        {
            models.Consultas.especialidad = "odontologia general";
            formAbierto(new Agenda(this));
        }

        private void btnOdontopediatria_Click(object sender, EventArgs e)
        {
            models.Consultas.especialidad = "odontopediatria";
            formAbierto(new Agenda(this));
        }

        private void btnOrtodoncia_Click(object sender, EventArgs e)
        {
            models.Consultas.especialidad = "ortodoncia";
            formAbierto(new Agenda(this));
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCPanel_Click(object sender, EventArgs e)
        {
            models.Consultas.especialidad = "ortodoncia";
            formAbierto(new ValidadCpanel(this));
        }
    }
}
