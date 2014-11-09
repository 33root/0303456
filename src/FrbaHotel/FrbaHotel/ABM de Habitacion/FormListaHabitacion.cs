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
            cmbTHabitacion.Items.Add("");

            try
            {
                conexion.Open();
                string consulta = "SELECT descripcion FROM AEFI.TL_Tipo_Habitacion ORDER BY ID_Tipo_Habitacion ";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                    cmbTHabitacion.Items.Add(reader[0]);
                reader.Close();
            }
            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }

        }

        private void FormListaHabitacion_Load(object sender, EventArgs e)
        {

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            conexion.Open();


            string Query = "SELECT h.ID_Hotel, h.Numero, h.Piso, h.Vista, " +
                "th.Descripcion, th.Porcentual " +
                "FROM AEFI.TL_Habitacion h " +
                "JOIN AEFI.TL_Tipo_Habitacion th ON (h.ID_Tipo_Habitacion = th.ID_Tipo_Habitacion) " +
                "WHERE h.Numero IS NOT NULL ";

            if (!String.IsNullOrEmpty(tbNumero.Text))
            {
                String aux = BaseDeDatos.agregarApostrofos(tbNumero.Text);
                Query = Query + " AND h.Numero LIKE " + aux;
            }

            if (!String.IsNullOrEmpty(cmbVista.Text))
            {
                String aux = BaseDeDatos.agregarApostrofos(cmbVista.Text);
                Query = Query + " AND h.Vista LIKE " + aux;
            }

            if (!String.IsNullOrEmpty(cmbTHabitacion.Text))
            {
                String aux = BaseDeDatos.agregarApostrofos("%" + cmbTHabitacion.Text + "%");
                Query = Query + "AND th.descripcion LIKE " + aux;
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
            /*falta ver como limpiar los CMB */
            
            
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FormMenu menu = new FormMenu();
            this.Hide();
            menu.ShowDialog();
            this.Close();
        }

        private void btnModificiar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvHabitaciones.SelectedRows)
            {
                FormNuevaHabitacion alta = new FormNuevaHabitacion(1, row.Cells);
                this.Hide();
                alta.ShowDialog();
                this.Close();
            }
        }
    }
}
