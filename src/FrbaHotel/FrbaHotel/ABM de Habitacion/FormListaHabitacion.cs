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


namespace FrbaHotel.ABM_de_Habitacion
{
    public partial class FormListaHabitacion : Form
    {
        SqlConnection conexion = BaseDeDatos.conectar();

        public FormListaHabitacion()
        {
            InitializeComponent();
            cmbVista.Items.Add("S");
            cmbVista.Items.Add("N");
        }

        private void FormListaHabitacion_Load(object sender, EventArgs e)
        {

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            conexion.Open();


            string Query = "SELECT h.Numero, h.Piso, h.Vista, Tipo_Comodidades, Tipo_Porcentual FROM AEFI.TL_Habitacion h WHERE h.Numero IS NOT NULL";

            if (!String.IsNullOrEmpty(tbNumero.Text))
            {
                String aux = BaseDeDatos.agregarApostrofos(tbNumero.Text);
                Query = Query + " AND h.Numero LIKE " + aux;
            }

            if (!String.IsNullOrEmpty(cmbVista.Text))
            {
                String aux = BaseDeDatos.agregarApostrofos( cmbVista.Text);
                Query = Query + " AND h.Vista LIKE " + aux;
            }

            if (!String.IsNullOrEmpty(cmbTHabitacion.Text))
            {
                String aux = BaseDeDatos.agregarApostrofos("%" + cmbTHabitacion.Text + "%");
                Query = Query + " AND h.Tipo_Habitacion LIKE " + aux;
            }

            SqlDataAdapter adapter = new SqlDataAdapter(Query, conexion);
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            dgvHabitaciones.DataSource = tabla;


            conexion.Close();

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvHabitaciones.DataSource = null;
            tbNumero.Clear();
            
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FormMenu menu = new FormMenu();
            this.Hide();
            menu.ShowDialog();
            this.Close();
        }
    }
}
