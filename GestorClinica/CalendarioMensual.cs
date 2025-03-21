using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorClinica
{
    public partial class CalendarioMensual : Form
    {

        public CalendarioMensual()
        {
            InitializeComponent();
            mostrarDias();
        }

        int month, year;

        private void cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMesSiguiente_Click(object sender, EventArgs e)
        {
            //vaciar el contenedor
            dayContainer.Controls.Clear();

            //Incrementar el mes
            if (month == 12)
            {
                month = 1;
                year++;
            }
            else 
            { 
                month++;
            }

            models.Consultas.calMes = month.ToString();
            models.Consultas.calYear = year.ToString();

            string mesNombre = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbMA.Text = mesNombre + ", " + year;

            //obtener el primer dia del mes
            DateTime principioDeMes = new DateTime(year, month, 1);

            //obtener la cantidad de dias en el mes
            int dias = DateTime.DaysInMonth(year, month) + 1;

            //convertir el inicio del mes en int
            int diaDeLaSemana = Convert.ToInt32(principioDeMes.DayOfWeek.ToString("d")) + 1;

            //crear users controlls en blanco
            for (int i = 1; i < diaDeLaSemana; i++)
            {
                UserControlBlank ucBlank = new UserControlBlank();
                dayContainer.Controls.Add(ucBlank);
            }

            //crear los user controls para los dias 
            for (int i = 1; i < dias; i++)
            {
                UserControlDays ucDays = new UserControlDays();
                ucDays.days(i);
                dayContainer.Controls.Add(ucDays);
            }
        }

        private void btnMesAnterior_Click(object sender, EventArgs e)
        {
            //vaciar el contenedor
            dayContainer.Controls.Clear();

            //Reducir el mes
            if (month == 1)
            {
                month = 12;
                year--;
            }
            else
            {
                month--;
            }

            models.Consultas.calMes = month.ToString();
            models.Consultas.calYear = year.ToString();

            string mesNombre = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbMA.Text = mesNombre + ", " + year;

            //obtener el primer dia del mes
            DateTime principioDeMes = new DateTime(year, month, 1);

            //obtener la cantidad de dias en el mes
            int dias = DateTime.DaysInMonth(year, month) + 1;

            //convertir el inicio del mes en int
            int diaDeLaSemana = Convert.ToInt32(principioDeMes.DayOfWeek.ToString("d")) + 1;

            //crear users controlls en blanco
            for (int i = 1; i < diaDeLaSemana; i++)
            {
                UserControlBlank ucBlank = new UserControlBlank();
                dayContainer.Controls.Add(ucBlank);
            }

            //crear los user controls para los dias 
            for (int i = 1; i < dias; i++)
            {
                UserControlDays ucDays = new UserControlDays();
                ucDays.days(i);
                dayContainer.Controls.Add(ucDays);
            }
        }

        public void mostrarDias()
        {
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;

            models.Consultas.calMes = month.ToString();
            models.Consultas.calYear = year.ToString();

            string mesNombre = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbMA.Text = mesNombre +", "+ year;

            //obtener el primer dia del mes
            DateTime principioDeMes = new DateTime(year, month, 1);

            //obtener la cantidad de dias en el mes
            int dias = DateTime.DaysInMonth(year, month)+1;

            //convertir el inicio del mes en int
            int diaDeLaSemana = Convert.ToInt32(principioDeMes.DayOfWeek.ToString("d"))+1;

            //crear users controlls en blanco
            for (int i = 1; i < diaDeLaSemana; i++)
            {
                UserControlBlank ucBlank = new UserControlBlank();
                dayContainer.Controls.Add(ucBlank);
            }

            //crear los user controls para los dias 
            for(int i = 1; i < dias; i++)
            {
                UserControlDays ucDays = new UserControlDays();
                ucDays.days(i);
                dayContainer.Controls.Add(ucDays);
            }
        }






    }
}
