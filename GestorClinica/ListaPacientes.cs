using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GestorClinica
{
    public partial class ListaPacientes : Form
    {
        Inicio FI;
        public ListaPacientes(Inicio Fmi)
        {
            InitializeComponent();
            FI = Fmi;
            listarPacientes();
        }

        //REGEX
        Regex expTexto = new Regex(@"^[a-zA-ZÀ-ÿ\s]*$");


        public void listarPacientes()
        {
            List<Object> lista = new List<Object>();
            lista = models.Pacientes.ListarPacientes();
            dataGridView1.DataSource = lista.ToList();
            FI.tituloVentana.Text = "Lista de pacientes "+models.Pacientes.tExpediente;
        }


        public void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            if(txtBuscar.Text != null && txtBuscar.Text.Trim() != "")
            {
                if (expTexto.IsMatch(txtBuscar.Text))
                {
                    String buscar = txtBuscar.Text;
                    List<Object> lista = new List<Object>();
                    lista = models.Pacientes.buscarPacientes(buscar);
                    dataGridView1.DataSource = lista.ToList();
                }
                else
                {                
                    MessageBox.Show("Solo se permiten letras en el campo buscar", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Introduzca un nombre", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnVerPaciente_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            models.Pacientes.Id_Paciente = int.Parse(id);
            string aux = models.Pacientes.tExpediente;
            if (aux == "general")
            {
                FI.formAbierto(new InfoPGral(FI));
            }
            if ((aux == "adulto") || (aux == "menor"))
            {
                FI.formAbierto(new InfoPaciente(FI));
            }

        }

        private void btnAgregarPaciente_Click(object sender, EventArgs e)
        {
            FI.tituloVentana.Text = "Crear paciente general";
            FI.formAbierto(new AddPGral(FI));
        }

        private void ListaPacientes_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listarPacientes();
        }
    }
}
