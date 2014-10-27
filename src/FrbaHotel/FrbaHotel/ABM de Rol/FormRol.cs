using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaHotel.Menu;

namespace FrbaHotel.ABM_de_Rol
{
    public partial class FormRol : Form 
    {
        SqlConnection conexion = BaseDeDatos.conectar();

        public FormRol()
        {
            InitializeComponent();
        }

        private void FormRol_Load(object sender, EventArgs e)
        {
          SqlConnection conexion = BaseDeDatos.conectar();
        }

        private void modificarBtn_Click(object sender, EventArgs e)
        {
            FormModificarRol r = new FormModificarRol();
            this.Hide();
            r.ShowDialog();
            this.Close();
        }

        private void crearBtn_Click(object sender, EventArgs e)
        {
            FormCrearRol r = new FormCrearRol();
            this.Hide();
            r.ShowDialog();
            this.Close();
        }

        private void cancelarBtn_Click(object sender, EventArgs e)
        {
            FormMenu inicio = new FormMenu();
            this.Hide();
            inicio.ShowDialog();
            this.Close();
        }

    }
}
