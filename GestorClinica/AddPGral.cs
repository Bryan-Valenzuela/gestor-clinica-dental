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
    public partial class AddPGral : Form
    {
        Inicio FI;
        public AddPGral(Inicio Fmi)
        {
            InitializeComponent();
            FI = Fmi;
        }


        


        //Funciones


        public void agregarPGral()
        {
            string nombre = "";
            string edad = "";
            string cel = "";
            string teltutor = "";
            string tel = "";
            string mConsulta = "";

            Regex expTexto = new Regex(@"^[a-zA-ZÀ-ÿ\s]*$");
            Regex expEdad = new Regex(@"^[0-9]{2,3}$");
            Regex expTelefonos = new Regex(@"^[0-9]{7,10}$");


            if (txtNombre != null && txtNombre.Text != "")
            {
                if (expTexto.IsMatch(txtNombre.Text.Trim()))
                {
                    if (txtEdad.Text != null && txtEdad.Text != "")
                    {
                        if (expEdad.IsMatch(txtEdad.Text.Trim()))
                        {
                            if (expTexto.IsMatch(txtMConsulta.Text.Trim()) && txtMConsulta.Text != null && txtMConsulta.Text.Trim() != "")
                            {
                                if (txtCel.Text != null && txtCel.Text != "")
                                {
                                    if (expTelefonos.IsMatch(txtCel.Text.Trim()))
                                    {
                                        cel = txtCel.Text;

                                        if (txtTelTutor.Text != null && txtTelTutor.Text != "")
                                        {
                                            if (expTelefonos.IsMatch(txtTelTutor.Text.Trim()))
                                            {
                                                teltutor = txtTelTutor.Text;
                                            }

                                        }

                                        if (txtTel.Text != null && txtTel.Text != "")
                                        {
                                            if (expTelefonos.IsMatch(txtTel.Text.Trim()))
                                            {
                                                tel = txtTel.Text;
                                            }

                                        }

                                        nombre = txtNombre.Text;
                                        edad = txtEdad.Text;
                                        mConsulta = txtMConsulta.Text;


                                        models.Pacientes.nombre = nombre;
                                        models.Pacientes.edad = edad;
                                        models.Pacientes.cel = cel;
                                        models.Pacientes.telTutuor = teltutor;
                                        models.Pacientes.tel = tel;
                                        models.Pacientes.motivoConsulta = mConsulta;
                                        models.Pacientes.tExpediente = "general";

                                        DateTime fecha = DateTime.Now.Date;
                                        string auxFecha = fecha.ToShortDateString();
                                        models.Pacientes.FechaCreacionExpediente = auxFecha;

                                        bool aux = models.Pacientes.AgregarPacienteGral();

                                        if (aux == true)
                                        {
                                            FI.tituloVentana.Text = "Lista Pacientes " + models.Pacientes.tExpediente;
                                            FI.formAbierto(new ListaPacientes(FI));
                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show("Solo se permiten numeros en el campo telefono y telefonos validos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }

                                }

                            

                        }
                        else
                        {
                            MessageBox.Show("Se necesita un motivo de consulta", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                                   
                        }
                        else
                        {
                            MessageBox.Show("Solo se permiten numeros y una edad valida", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("se necesita una edad");
                    }                    
                }
                else
                {
                     MessageBox.Show("Solo se permiten letras en el campo nombre", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            else
                {
                    MessageBox.Show("se necesita un nombre");
                }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
           agregarPGral();
        }
    }
}
