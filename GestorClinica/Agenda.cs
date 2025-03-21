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
    public partial class Agenda : Form
    {
        Inicio FI;
        public Agenda(Inicio Fmi)
        {
            InitializeComponent();
            FI = Fmi;
            FI.tituloVentana.Text = "Agenda "+models.Consultas.especialidad;
            listarConsultas();
        }

        public void listarConsultas()
        {
            List<Object> lista = new List<Object>();
            DateTime fecha = DateTime.Now.Date;
            dateTimePicker.Text = fecha.ToShortDateString();
            models.Consultas.fecha = fecha.ToShortDateString();
            lista = models.Consultas.ListarConsultas();
            dataGridView.DataSource = lista.ToList();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            List<Object> lista = new List<Object>();
            DateTime fecha = dateTimePicker.Value.Date;
            models.Consultas.fecha = fecha.ToShortDateString();
            lista = models.Consultas.ListarConsultas();
            dataGridView.DataSource = lista.ToList();
        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            string id = null;
            if (id != null)
            {
                id = dataGridView.CurrentRow.Cells[3].Value.ToString();
                models.Pacientes.Id_Paciente = int.Parse(id);
                models.Pacientes.nombre = dataGridView.CurrentRow.Cells[4].Value.ToString();
                FI.formAbierto(new AgregarCita(FI));
            }
            
        }

        private void btnVerCita_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dataGridView.CurrentRow.Cells[0].Value.ToString());
            string id = dataGridView.CurrentRow.Cells[0].Value.ToString();
            
            models.Consultas.Id_Consulta = int.Parse(id);
            FI.formAbierto(new InfoCita(FI));
        }

        private void btnCalendario_Click(object sender, EventArgs e)
        {
            CalendarioMensual CM = new CalendarioMensual();
            CM.Show();
        }

        private void Agenda_Load(object sender, EventArgs e)
        {
            
        }
    }
}
