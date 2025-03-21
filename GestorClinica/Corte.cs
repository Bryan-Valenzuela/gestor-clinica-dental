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
    public partial class Corte : Form
    {
        public Corte()
        {
            InitializeComponent();
            setearDT();
        }

        public void setearDT()
        {
            DateTime fecha = DateTime.Now.Date;
            dateTimePicker.Text = fecha.ToShortDateString();
        }

        public void mostarCorte()
        {
            List<Object> lista = new List<Object>();

            lista = models.Cobro.CorteDeCaja();            

            txtCantEfectivo.Text = models.Cobro.corteEfectivoCant;
            txtCantTarjeta.Text = models.Cobro.corteTarjetaCant;
            txtCantTransferencia.Text = models.Cobro.corteTransferenciaCant;

            txtSubEfectivo.Text = models.Cobro.corteEfectivo;
            txtSubTarjeta.Text = models.Cobro.corteTarjeta;
            txtSubTransferencia.Text = models.Cobro.corteTransferencia;

            txtTotal.Text = models.Cobro.corteTotal;

            dataGridView.DataSource = lista.ToList();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime fecha = dateTimePicker.Value.Date;
            models.Cobro.corteFecha = fecha.ToShortDateString();
            mostarCorte();
        }
    }
}
