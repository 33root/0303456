using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.ABM_de_Hotel;
using FrbaHotel.ABM_de_Habitacion;
using FrbaHotel.ABM_de_Rol;
using FrbaHotel.ABM_de_Cliente;


namespace FrbaHotel.Menu
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void btnListaHoteles_Click(object sender, EventArgs e)
        {
            FormListaDeHoteles lh = new FormListaDeHoteles();
            this.Hide();
            lh.ShowDialog();
            this.Close();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnNuevoHotel_Click(object sender, EventArgs e)
        {
            FormNuevoHotel lh = new FormNuevoHotel();
            this.Hide();
            lh.ShowDialog();
            this.Close();
        }

        private void btnNuevaHabitacion_Click(object sender, EventArgs e)
        {
            
            FormNuevaHabitacion lh = new FormNuevaHabitacion();
            this.Hide();
            lh.ShowDialog();
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            FormListaHabitacion lh = new FormListaHabitacion();
            this.Hide();
            lh.ShowDialog();
            this.Close();


        }

        

        private void gestorDeRolesBtn_Click(object sender, EventArgs e)
        {
            FormRol r = new FormRol();
            this.Hide();
            r.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormBuscadorDeClientes b = new FormBuscadorDeClientes();
            this.Hide();
            b.ShowDialog();
            this.Close();
        }

    }
}
