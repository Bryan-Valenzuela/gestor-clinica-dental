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
    public partial class InfoCita : Form
    {
        Inicio FI;
        public InfoCita(Inicio Fmi)
        {
            InitializeComponent();
            FI = Fmi;
            FI.tituloVentana.Text = "Informacion de la cita";
            setearCombobox();
            setearInfo();
        }

        public void setearCombobox()
        {
            cbEstadoCita.Items.Add("Pendiente");
            cbEstadoCita.Items.Add("Realizada");
            cbEstadoCita.Items.Add("Cancelada");
        }

        public void setearInfo()
        {
            models.Consultas.infoConsultas();
            txtID.Text = models.Consultas.Id_Consulta.ToString();
            txtNombre.Text = models.Consultas.nombrePaciente;
            txtFecha.Text = models.Consultas.fecha;
            txtCel.Text = models.Consultas.celPaciente;
            txtProcedimiento.Text = models.Consultas.nombreProcedimietnto;
            txtEspecialidad.Text = models.Consultas.especialidad;
            txtHora.Text = models.Consultas.hora;
            txtDuracion.Text = models.Consultas.duracion.ToString();
            txtDientesTratar.Text = models.Consultas.dientes;
            cbEstadoCita.SelectedItem = models.Consultas.estado;

            DateTime fecha = DateTime.Now.Date;

            if (Convert.ToDateTime(models.Consultas.fecha) < fecha)
            {
                cbEstadoCita.Enabled = false;
            }



        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (cbEstadoCita.SelectedItem.ToString() != models.Consultas.estado)
            {
                if (cbEstadoCita.SelectedItem.ToString() == "Realizada")
                { 
                    FI.formAbierto(new Cobro(FI));
                }
                if (cbEstadoCita.SelectedItem.ToString() == "Cancelada")
                {

                    //obtenemos valores para empezar la eliminacion de datos en la validacion
                    string[] horario = new[] { "09:00", "09:30", "10:00", "10:30", "11:00", "11:30", "12:00", "12:30", "13:00", "13:30", "14:00", "14:30", "15:00", "15:30", "16:00", "16:30", "17:00", "17:30", "18:00", "18:30", "19:00" };
                    int index = -1;
                    string horaInicio = txtHora.Text;
                    double reps = 2 * double.Parse(txtDuracion.Text);

                    for (int i = 0; i < horario.Length; i++)
                    {

                        if (horario[i].ToString() == horaInicio)
                        {
                            index = i;
                            break;
                        }

                    }

                    
                    int auxIndex = index;
                    models.Consultas.especialidad = txtEspecialidad.Text;
                    
                    models.Consultas.fecha = txtFecha.Text;

                    //elimina registros
                    for (int i = 0; i < reps; i++)
                    {
                        models.Consultas.valHora = horario[auxIndex];

                        models.Consultas.eliminarCitaCancelada();

                        auxIndex++;
                    }

                    //eliminamos la cita del historial
                    models.Consultas.borrarCita();
                    FI.formAbierto(new Agenda(FI));
                }

            }
            else
            {
                MessageBox.Show("El estado de la cita no a cambiado");

            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {

            DateTime fecha = DateTime.Now.Date;

            if (Convert.ToDateTime(models.Consultas.fecha) == fecha)
            {
                if (cbEstadoCita.SelectedItem.ToString() == models.Consultas.estado)
                {
                    FI.formAbierto(new Cobro(FI));
                }
                else
                {
                    MessageBox.Show("No se pueden pagar consultas que no sean en el dia actual");

                }
            }
            else
            {
                MessageBox.Show("solo se puedenpagar citas en el dia actual");
            }

        


        }
    }
}
