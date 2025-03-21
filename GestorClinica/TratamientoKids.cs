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
    public partial class TratamientoKids : Form
    {
        Inicio FI;
        public TratamientoKids(Inicio Fmi)
        {
            InitializeComponent();
            FI = Fmi;
            FI.tituloVentana.Text = "Plan de tratamiento";
            setarInfo();
            desblockearcampos();
        }

        public void setarInfo()
        {
            models.Pacientes.infoPacienteExpedienteMEnor();

            txtID.Text = models.Pacientes.Id_Paciente.ToString();
            txtNombre.Text = models.Pacientes.nombre;
            txtEdad.Text = models.Pacientes.edad;
            txtDiabetes.Text = models.Pacientes.diabetes;
            
            txtAPenicilina.Text = models.Pacientes.alergiaPenicilina;
            txtPCoagulacion.Text = models.Pacientes.probCuabulacion;

            models.Expedientes.mostrarTratamiento();

            txtAlergias.Text = models.Expedientes.alergias;
            txtObservaciones.Text = models.Expedientes.observaciones;

            txtLimpieza.Text = models.Expedientes.limpieza;
            txtPulpotomia.Text = models.Expedientes.pultotomia;
            txtResina.Text = models.Expedientes.resina;
            txtIonomeroVidrio.Text = models.Expedientes.ionomeroVidrio;
            txtCoronas.Text = models.Expedientes.coronas;
            txtMantenedorEspacios.Text = models.Expedientes.mantenedorEspacios;
            txtExtraccion.Text = models.Expedientes.extracion;
            txtSedacionConcienteON.Text = models.Expedientes.sedacionConciente_ON;

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
            txtPulpotomia.Enabled = false;
            txtResina.Enabled = false;
            txtIonomeroVidrio.Enabled = false;
            txtCoronas.Enabled = false;
            txtMantenedorEspacios.Enabled = false;
            txtExtraccion.Enabled = false;
            txtSedacionConcienteON.Enabled = false;
        }

        public void desblockearcampos()
        {
            txtAlergias.Enabled = true;
            txtObservaciones.Enabled = true;

            txtLimpieza.Enabled = true;
            txtPulpotomia.Enabled = true;
            txtResina.Enabled = true;
            txtIonomeroVidrio.Enabled = true;
            txtCoronas.Enabled = true;
            txtMantenedorEspacios.Enabled = true;
            txtExtraccion.Enabled = true;
            txtSedacionConcienteON.Enabled = true;
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
                        if (expTexto.IsMatch(txtPulpotomia.Text.Trim()))
                        {
                            if (expTexto.IsMatch(txtResina.Text.Trim()))
                            {
                                if (expTexto.IsMatch(txtIonomeroVidrio.Text.Trim()))
                                {
                                    if (expTexto.IsMatch(txtCoronas.Text.Trim()))
                                    {
                                        if (expTexto.IsMatch(txtMantenedorEspacios.Text.Trim()))
                                        {
                                            if (expTexto.IsMatch(txtExtraccion.Text.Trim()))
                                            {
                                                if (expTexto.IsMatch(txtSedacionConcienteON.Text.Trim()))
                                                {


                                                    models.Expedientes.setearVariables();

                                                    models.Expedientes.alergias = txtAlergias.Text;
                                                    models.Expedientes.observaciones = txtObservaciones.Text;

                                                    models.Expedientes.limpieza = txtLimpieza.Text;
                                                    models.Expedientes.resina = txtResina.Text;
                                                    models.Expedientes.ionomeroVidrio = txtIonomeroVidrio.Text;
                                                    models.Expedientes.pultotomia = txtPulpotomia.Text;
                                                    models.Expedientes.coronas = txtCoronas.Text;
                                                    models.Expedientes.extracion = txtExtraccion.Text;
                                                    models.Expedientes.mantenedorEspacios = txtMantenedorEspacios.Text;
                                                    models.Expedientes.sedacionConciente_ON = txtSedacionConcienteON.Text;


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

        private void btnTratado_Click(object sender, EventArgs e)
        {
            models.Expedientes.verTratamientoHecho();
            txtAlergias.Text = models.Expedientes.alergias;
            txtObservaciones.Text = models.Expedientes.observaciones;

            txtLimpieza.Text = models.Expedientes.limpieza;
            txtPulpotomia.Text = models.Expedientes.pultotomia;
            txtResina.Text = models.Expedientes.resina;
            txtIonomeroVidrio.Text = models.Expedientes.ionomeroVidrio;
            txtCoronas.Text = models.Expedientes.coronas;
            txtMantenedorEspacios.Text = models.Expedientes.mantenedorEspacios;
            txtExtraccion.Text = models.Expedientes.extracion;
            txtSedacionConcienteON.Text = models.Expedientes.sedacionConciente_ON;

            FI.tituloVentana.Text = "Plan de tratamiento realizado";

            blockearcampos();
        }

        private void Tratamiento_Click(object sender, EventArgs e)
        {
            FI.tituloVentana.Text = "Plan de tratamiento";
            desblockearcampos();
            models.Expedientes.mostrarTratamiento();
            setarInfo();
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
