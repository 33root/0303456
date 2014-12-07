using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Menu;
using FrbaHotel.ABM_de_Usuario;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class FrmAbmDeUsuario : Form
    {
        public FrmAbmDeUsuario()
        {
            InitializeComponent();
        }

        private void volverBtn_Click(object sender, EventArgs e)
        {
            FormMenu inicio = new FormMenu();
            this.Hide();
            inicio.ShowDialog();
            this.Close();
        }

        private void nuevoUsuarioBtn_Click(object sender, EventArgs e)
        {
            FrmNuevoUsuario r = new FrmNuevoUsuario();
            this.Hide();
            r.ShowDialog();
            this.Close();
        }

        private void modificarUsuarioBtn_Click(object sender, EventArgs e)
        {
            FrmModificarOBajaUsuario r = new FrmModificarOBajaUsuario();
            this.Hide();
            r.ShowDialog();
            this.Close();
        }
    }
}
