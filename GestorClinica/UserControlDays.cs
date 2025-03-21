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
    public partial class UserControlDays : UserControl
    {
        public UserControlDays()
        {
            InitializeComponent();
        }

        public void days(int numDay)
        {
            List<Object> lista = new List<Object>();
            lbDays.Text = numDay + "";

            Regex expDia = new Regex(@"^[0-9]{1}$");

            if (expDia.IsMatch(numDay.ToString()))
            {
                string diaFormato = "0"+numDay;
                models.Consultas.calDia = diaFormato;
                lista = models.Consultas.listarCalendario();
                dataGridView.DataSource = lista.ToList();
            }
            else
            {
                models.Consultas.calDia = numDay.ToString();
                lista = models.Consultas.listarCalendario();
                dataGridView.DataSource = lista.ToList();
            }
        }
    }
}
