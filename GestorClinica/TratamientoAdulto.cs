using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorClinica
{
    public partial class TratamientoAdulto : Form
    {
        Inicio FI;
        public TratamientoAdulto(Inicio Fmi)
        {
            InitializeComponent();
            FI = Fmi;
            FI.tituloVentana.Text = "Plan de tratamiento";
            setarInfo();
            desblockearcampos();
        }

        public void setarInfo()
        {

            models.Pacientes.infoPacienteExpedienteAdulto();

            txtID.Text = models.Pacientes.Id_Paciente.ToString();
            txtNombre.Text = models.Pacientes.nombre;
            txtEdad.Text = models.Pacientes.edad;
            txtDiabetes.Text = models.Pacientes.diabetes;
            txtHipertension.Text = models.Pacientes.hipertencion;
            txtHipotension.Text = models.Pacientes.hipotencion;
            txtAPenicilina.Text = models.Pacientes.alergiaPenicilina;
            txtPCoagulacion.Text = models.Pacientes.probCuabulacion;

            models.Expedientes.mostrarTratamiento();

            txtAlergias.Text = models.Expedientes.alergias;
            txtObservaciones.Text = models.Expedientes.observaciones;

            txtLimpieza.Text = models.Expedientes.limpieza;
            txtBlanqueamiento.Text = models.Expedientes.blanqueamiento;
            txtResina.Text = models.Expedientes.resina;
            txtIonomeroVidrio.Text = models.Expedientes.ionomeroVidrio;
            txtCoronas.Text = models.Expedientes.coronas;
            txtProtesis.Text = models.Expedientes.ProtesisFija_removible_total;
            txtExtraccion.Text = models.Expedientes.extracion;
            txtOtros.Text = models.Expedientes.otros;

            try
            {
                MySqlConnection conex = new MySqlConnection();
                string servidor = "localhost";
                string bd = "clinicabd";
                string usuario = "root";
                string pass = "Stroud25";
                string puerto = "3306";

                string query = "SELECT foto FROM pacientes WHERE id_Pacientes = '" + models.Pacientes.Id_Paciente.ToString() + "';";
                string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + pass + ";" + "database=" + bd + ";";
                conex.ConnectionString = cadenaConexion;
                conex.Open();

                MySqlCommand cmd = new MySqlCommand(query, conex);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);

                byte[] img = (byte[])table.Rows[0][0];
                MemoryStream ms = new MemoryStream(img);
                pbFoto.Image = Image.FromStream(ms);



            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void blockearcampos()
        {
            txtAlergias.Enabled = false;
            txtObservaciones.Enabled = false;

            txtLimpieza.Enabled = false;
            txtBlanqueamiento.Enabled = false;
            txtResina.Enabled = false;
            txtIonomeroVidrio.Enabled = false;
            txtCoronas.Enabled = false;
            txtProtesis.Enabled = false;
            txtExtraccion.Enabled = false;
            txtOtros.Enabled= false;
        }

        public void desblockearcampos()
        {
            txtAlergias.Enabled = true;
            txtObservaciones.Enabled = true;

            txtLimpieza.Enabled = true;
            txtBlanqueamiento.Enabled = true;
            txtResina.Enabled = true;
            txtIonomeroVidrio.Enabled = true;
            txtCoronas.Enabled = true;
            txtProtesis.Enabled = true;
            txtExtraccion.Enabled = true;
            txtOtros.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {


            //REGEX
            Regex expTexto = new Regex(@"^[a-zA-ZÀ-ÿ0-9\,\s]*$");


            if (expTexto.IsMatch(txtAlergias.Text.Trim()))
            {
                if (expTexto.IsMatch(txtObservaciones.Text.Trim()))
                {
                    if (expTexto.IsMatch(txtLimpieza.Text.Trim()))
                    {
                        if (expTexto.IsMatch(txtBlanqueamiento.Text.Trim()))
                        {
                            if (expTexto.IsMatch(txtResina.Text.Trim()))
                            {
                                if (expTexto.IsMatch(txtIonomeroVidrio.Text.Trim()))
                                {
                                    if (expTexto.IsMatch(txtCoronas.Text.Trim()))
                                    {
                                        if (expTexto.IsMatch(txtProtesis.Text.Trim()))
                                        {
                                            if (expTexto.IsMatch(txtExtraccion.Text.Trim()))
                                            {
                                                if (expTexto.IsMatch(txtOtros.Text.Trim()))
                                                {


                                                    models.Expedientes.setearVariables();

                                                    models.Expedientes.alergias = txtAlergias.Text.Trim();
                                                    models.Expedientes.observaciones = txtObservaciones.Text.Trim();

                                                    models.Expedientes.limpieza = txtLimpieza.Text.Trim();
                                                    models.Expedientes.resina = txtResina.Text.Trim();
                                                    models.Expedientes.ionomeroVidrio = txtIonomeroVidrio.Text.Trim();
                                                    models.Expedientes.coronas = txtCoronas.Text.Trim();
                                                    models.Expedientes.extracion = txtExtraccion.Text.Trim();
                                                    models.Expedientes.blanqueamiento = txtBlanqueamiento.Text.Trim();
                                                    models.Expedientes.ProtesisFija_removible_total = txtProtesis.Text.Trim();
                                                    models.Expedientes.otros = txtOtros.Text.Trim();

                                                    models.Expedientes.actualizarTratamiento();



                                                }
                                                else
                                                {
                                                    MessageBox.Show("Solo se permite texto, numeros y ',' ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Solo se permite texto, numeros y ',' ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Solo se permite texto, numeros y ',' ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Solo se permite texto, numeros y ',' ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Solo se permite texto, numeros y ',' ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Solo se permite texto, numeros y ',' ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Solo se permite texto, numeros y ',' ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Solo se permite texto, numeros y ',' ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Solo se permite texto, numeros y ',' ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Solo se permite texto, numeros y ',' ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void Tratamiento_Click(object sender, EventArgs e)
        {
            models.Expedientes.mostrarTratamiento();
            desblockearcampos();
            setarInfo();
        }

        private void btnTratado_Click(object sender, EventArgs e)
        {
            models.Expedientes.verTratamientoHecho();
            txtAlergias.Text = models.Expedientes.alergias;
            txtObservaciones.Text = models.Expedientes.observaciones;

            txtLimpieza.Text = models.Expedientes.limpieza;
            txtBlanqueamiento.Text = models.Expedientes.blanqueamiento;
            txtResina.Text = models.Expedientes.resina;
            txtIonomeroVidrio.Text = models.Expedientes.ionomeroVidrio;
            txtCoronas.Text = models.Expedientes.coronas;
            txtProtesis.Text = models.Expedientes.ProtesisFija_removible_total;
            txtExtraccion.Text = models.Expedientes.extracion;
            txtOtros.Text = models.Expedientes.otros;

            blockearcampos();
        }

        private void btnInfoPaciente_Click(object sender, EventArgs e)
        {
            FI.formAbierto(new InfoPaciente(FI));
        }

        private void btnRadiografias_Click(object sender, EventArgs e)
        {
            FI.formAbierto(new Radiografias(FI));
        }
    }
}
