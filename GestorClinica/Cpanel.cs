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
    public partial class Cpanel : Form
    {
        Inicio FI;
        public Cpanel(Inicio Fmi)
        {
            InitializeComponent();
            FI = Fmi;
            FI.tituloVentana.Text = "Panel de control";
        }

        public Form formActivo2 = null;

        public void formAbierto2(Form formulario)
        {
            if (formActivo2 != null)
            {
                formActivo2.Close();
            }
            formActivo2 = formulario;
            //metodo para poner el form en el panel
            formulario.TopLevel = false;
            formulario.Dock = DockStyle.Fill;
            contenedorCPanel.Controls.Add(formulario);
            contenedorCPanel.Tag = formulario;
            formulario.Show();
        }

        private void btnCorte_Click(object sender, EventArgs e)
        {
            FI.tituloVentana.Text = "Corte de caja";
            formAbierto2(new Corte());
        }

        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            FI.tituloVentana.Text = "Facturas";
            formAbierto2(new Facturas());
        }
    }
}
