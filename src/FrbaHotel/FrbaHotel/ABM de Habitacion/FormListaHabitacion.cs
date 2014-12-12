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
            cmbVista.Items.Add("");
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


            string Query = "SELECT h.ID_Habitacion, h.ID_Hotel, h.Numero, h.Piso, h.Vista, " +
                "th.Descripcion, th.Porcentual, h.Estado, h.Disponible " +
                "FROM AEFI.TL_Habitacion h " +
                "JOIN AEFI.TL_Tipo_Habitacion th ON (h.ID_Tipo_Habitacion = th.ID_Tipo_Habitacion) " +
                "WHERE h.Numero IS NOT NULL " +
                "AND h.ID_Hotel = " + BaseDeDatos.agregarApostrofos(Program.idHotel.ToString());

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
            cmbTHabitacion.SelectedIndex = 0;
            cmbVista.SelectedIndex = 0;
          
            
            
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

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                foreach (DataGridViewRow row in dgvHabitaciones.SelectedRows)
                {
                    string consulta = "SELECT ID_Habitacion FROM AEFI.TL_Habitacion " +
                                      "WHERE ID_Hotel = " + BaseDeDatos.agregarApostrofos(row.Cells[1].Value.ToString()) +
                                      "AND Numero = " + BaseDeDatos.agregarApostrofos(row.Cells[2].Value.ToString());
                   
                   SqlCommand comando = new SqlCommand(consulta, conexion);
                    SqlDataReader reader = comando.ExecuteReader();
                    reader.Read();
                    int cod = Convert.ToInt32(reader[0]);
                    reader.Close();
                    comando = new SqlCommand("AEFI.baja_Habitacion", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@ID_Habitacion", cod));
                    comando.ExecuteNonQuery();

                }
                MessageBox.Show("Habitacion Deshabilitada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }
            btnFiltrar_Click(sender, e);

        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                foreach (DataGridViewRow row in dgvHabitaciones.SelectedRows)
                {
                    string consulta = "SELECT ID_Habitacion FROM AEFI.TL_Habitacion " +
                                      "WHERE ID_Hotel = " + BaseDeDatos.agregarApostrofos(row.Cells[1].Value.ToString()) +
                                      "AND Numero = " + BaseDeDatos.agregarApostrofos(row.Cells[2].Value.ToString());

                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    SqlDataReader reader = comando.ExecuteReader();
                    reader.Read();
                    int cod = Convert.ToInt32(reader[0]);
                    reader.Close();
                    consulta = "UPDATE AEFI.TL_Habitacion SET Estado = 'Habilitado' WHERE ID_Habitacion = " + cod;
                    comando = new SqlCommand(consulta, conexion);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Habitacion Habilitada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
           
            }

            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }
            btnFiltrar_Click(sender, e);



        }

        private void tbNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

      
    }
}
