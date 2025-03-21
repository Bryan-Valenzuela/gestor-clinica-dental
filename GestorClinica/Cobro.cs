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
    public partial class Cobro : Form
    {
        Inicio FI;
        public Cobro(Inicio Fmi)
        {
            InitializeComponent();
            FI = Fmi;
            FI.tituloVentana.Text = "Informacion de la cita";
            setearCombobox();
            setearInfo();
        }

        public void setearCombobox()
        {
            cbMPago.Items.Add("Tarjeta");
            cbMPago.Items.Add("Transferencia");
            cbMPago.Items.Add("Efectivo");

            cbMPago.SelectedIndex = 1;
        }

        public void setearInfo()
        {
            models.Consultas.infoCobro();
            txtID.Text = models.Consultas.Id_Consulta.ToString();
            txtNombre.Text = models.Consultas.nombrePaciente;
            txtFecha.Text = models.Consultas.fecha;
            txtProcedimiento.Text = models.Consultas.nombreProcedimietnto;
            txtEspecialidad.Text = models.Consultas.especialidad;
            txtHora.Text = models.Consultas.hora;
            txtDuracion.Text = models.Consultas.duracion.ToString();
            txtCosto.Text = models.Consultas.costoConsulta.ToString();




        }



        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (cboxFactura.Checked)
            {
                models.Cobro.idConsultas = int.Parse(txtID.Text);
                models.Cobro.costo = int.Parse(txtCosto.Text);
                models.Cobro.mPago = cbMPago.SelectedItem.ToString();
                models.Cobro.factura = cboxFactura.Text;
                models.Cobro.procedimiento = txtProcedimiento.Text;

                DateTime fecha = DateTime.Now.Date;
                models.Cobro.fecha = fecha.ToShortDateString();

                models.Consultas.estado = "Realizada";

                FI.formAbierto(new Factura(FI));
            }
            else
            {
                models.Cobro.idConsultas = int.Parse(txtID.Text);
                models.Cobro.costo = int.Parse(txtCosto.Text);
                models.Cobro.mPago = cbMPago.SelectedItem.ToString();
                models.Cobro.factura = "No";
                models.Cobro.procedimiento = txtProcedimiento.Text;

                DateTime fecha = DateTime.Now.Date;
                models.Cobro.fecha = fecha.ToShortDateString();

                models.Consultas.estado = "Realizada";
                

                bool aux = models.Cobro.realizarPago();
                if (aux == true)
                {
                    models.Consultas.actualizarEstado();
                    models.Consultas.actualizarTratamientoTratado();
                    FI.formAbierto(new Agenda(FI));
                }
            }
            
        }
    }
}
