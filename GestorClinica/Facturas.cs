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
    public partial class Facturas : Form
    {
        public Facturas()
        {
            InitializeComponent();
            setearDT();
        }

        public void setearDT()
        {
            DateTime fecha = DateTime.Now.Date;
            dateTimePicker.Text = fecha.ToShortDateString();
        }

        public void mostarFacturas()
        {
            List<Object> lista = new List<Object>();

            lista = models.Facturas.listarFacturas();

            dataGridView.DataSource = lista.ToList();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime fecha = dateTimePicker.Value.Date;
            models.Facturas.fecha = fecha.ToShortDateString();
            mostarFacturas();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
