using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class FrmHuesped : Form
    {
        public FrmHuesped()
        {
            InitializeComponent();
        }

        private void buscarHuespedButton_Click(object sender, EventArgs e)
        {
            FormBuscadorDeClientes b = new FormBuscadorDeClientes();
            this.Hide();
            b.ShowDialog();
            this.Close();
        }

        private void nuevoHuespedButton_Click(object sender, EventArgs e)
        {
            FormClienteNuevo c = new FormClienteNuevo();
            this.Hide();
            c.ShowDialog();
            this.Close();
        }

       
    }
}
