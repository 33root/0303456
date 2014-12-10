using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Menu;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class FormGenerarOModificarReserva : Form
    {
        public FormGenerarOModificarReserva()
        {
            InitializeComponent();
        }

        private void GenerarReservaButton_Click(object sender, EventArgs e)
        {
            FormGenerarReserva r = new FormGenerarReserva();
            this.Hide();
            r.ShowDialog();
            this.Close();
        }

        private void modificarReservaButton_Click(object sender, EventArgs e)
        {
            FormModificarReserva r = new FormModificarReserva();
            this.Hide();
            r.ShowDialog();
            this.Close();
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            FormMenu inicio = new FormMenu();
            this.Hide();
            inicio.ShowDialog();
            this.Close();
        }
    }
}
