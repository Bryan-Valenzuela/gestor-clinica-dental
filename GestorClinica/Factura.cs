using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorClinica
{
    public partial class Factura : Form
    {
        Inicio FI;
        public Factura(Inicio Fmi)
        {
            InitializeComponent();
            FI = Fmi;
            FI.tituloVentana.Text = "Datos factura";
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {

            string nombre = "";
            string rfc = "";
            string dirreccion = "";
            string correo = "";


            Regex expRFC = new Regex(@"^[A-Z0-9]{12,13}$");
            Regex expCorreos = new Regex(@"^[a-zA-Z0-9\@\._-]*$");
            Regex expNombre = new Regex(@"^[a-zA-ZÀ-ÿ\s]*$");
            Regex expDireccion = new Regex(@"^[a-zA-ZÀ-ÿ0-9,.\s#]*$");


            if (txtNombre != null && txtNombre.Text != "")
            {
                if (expNombre.IsMatch(txtNombre.Text.Trim()))
                {
                    if (txtRFC != null && txtRFC.Text != "")
                    {
                        if (expRFC.IsMatch(txtRFC.Text.Trim()))
                        {
                            if (txtDireccion != null && txtDireccion.Text != "")
                            {
                                if (expDireccion.IsMatch(txtDireccion.Text.Trim()))
                                {
                                    if (txtCorreo != null && txtCorreo.Text != "")
                                    {
                                        if (expCorreos.IsMatch(txtCorreo.Text.Trim()))
                                        {
                                            models.Facturas.nombreCompleto = txtNombre.Text.Trim();
                                            models.Facturas.RFC = txtRFC.Text.Trim();
                                            models.Facturas.direccion = txtDireccion.Text.Trim();
                                            models.Facturas.correo = txtCorreo.Text.Trim();
                                            models.Facturas.idConsulta = models.Cobro.idConsultas;

                                            DateTime fecha = DateTime.Now.Date;
                                            models.Facturas.fecha = fecha.ToShortDateString();
                                            
                                            bool aux2 = false;

                                            bool aux = models.Cobro.realizarPago();

                                            if ( aux == true)
                                            {
                                                aux2 = models.Facturas.realizarFactura();
                                            }
                                            else
                                            {
                                                MessageBox.Show("Ocurrio un problema");
                                            }

                                            
                                            if ((aux == true) && (aux2 == true))
                                            {
                                                models.Consultas.actualizarEstado();
                                                models.Consultas.actualizarTratamientoTratado();
                                                FI.formAbierto(new Agenda(FI));
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("introduzca un correo valido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Se necesita un correo");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Solo se permiten letras, numeros y '#' en el campo direccion", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Se necesita una direccion");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Solo se permiten letras mayusculas y numeros en el campo RFC", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Se necesita un RFC");
                    }
                }
                else
                {
                    MessageBox.Show("Solo se permiten letras en el campo nombre", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Se necesita un nombre");
            }

        }
    }
}
