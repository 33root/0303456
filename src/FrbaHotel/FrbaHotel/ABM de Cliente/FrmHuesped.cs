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
        int i;
        public FrmHuesped()
        {
            
            InitializeComponent();
        }
        public FrmHuesped(int num)
        {
            InitializeComponent();
            i = num;
        }


        private void buscarHuespedButton_Click(object sender, EventArgs e)
        {
            if (i == 1)
            {
                FormBuscadorDeClientes b = new FormBuscadorDeClientes(1);
                this.Hide();
                b.ShowDialog();
                this.Close();
            }
            else
            {
                FormBuscadorDeClientes b = new FormBuscadorDeClientes();
                this.Hide();
                b.ShowDialog();
                this.Close();
            }
        }

        private void nuevoHuespedButton_Click(object sender, EventArgs e)
        {
            if (i == 1)
            {
                FormClienteNuevo c = new FormClienteNuevo(1);
                this.Hide();
                c.ShowDialog();
                this.Close();
            }
            else
            {
                FormClienteNuevo c = new FormClienteNuevo();
                this.Hide();
                c.ShowDialog();
                this.Close();
            }
        }

       
    }
}
