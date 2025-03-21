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
    public partial class ValidadCpanel : Form
    {
        Inicio FI;
        public ValidadCpanel(Inicio Fmi)
        {
            InitializeComponent();
            FI = Fmi;
            FI.tituloVentana.Text = "Autentificacion";
        }

        public void Validar()
        {

            //REGEX
            Regex expUsuario = new Regex(@"^[a-zA-Z]*$");
            Regex expPass = new Regex(@"^[a-zA-Z0-9]*$");

            if (expUsuario.IsMatch(txtUsuario.Text.Trim()))
            {
                if (expPass.IsMatch(txtPass.Text.Trim()))
                {
                    models.Pacientes.validarCpanel();
                    string auxUser = models.Pacientes.valUsuario;
                    string auxPass = models.Pacientes.valPass;

                    string user = txtUsuario.Text.Trim();
                    string pass = txtPass.Text.Trim();

                    if (auxUser == user)
                    {
                        if (pass == auxPass)
                        {
                            FI.formAbierto(new Cpanel(FI));
                        }
                        else
                        {
                            MessageBox.Show("La contraseña no coincide");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El usuario no coincide");
                    }
                }
                else
                {
                    MessageBox.Show("Solo se permiten letras y numeros en el campo contraseña", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Solo se permiten letras en el campo usuario", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Validar();
        }
    }
}
