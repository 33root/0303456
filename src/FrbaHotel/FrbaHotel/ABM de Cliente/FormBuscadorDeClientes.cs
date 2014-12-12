using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Menu;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class FormBuscadorDeClientes : Form
    {
        SqlConnection conexion = BaseDeDatos.conectar();
        int i;

        public FormBuscadorDeClientes()
        {
            InitializeComponent();
        }

        public FormBuscadorDeClientes(int num)
        {   //Si entra aca es porque viene de registrar un check in
            InitializeComponent();
            i = num;
            volverBtn.Visible = false;
            habilitarBtn.Visible = false;
            modificarButton.Visible = false;
            eliminarBtn.Visible = false;
            seleccionarClienteBtn.Visible = true;
        }

        private void FormBuscadorDeClientes_Load(object sender, EventArgs e)
        {
            string consulta = "SELECT Descripcion FROM AEFI.TL_Tipo_Documento";
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand(consulta, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                    cbTipoDeDocumento.Items.Add(reader[0]); //carga los tipos de documentos en el combo box
                reader.Close();
                cbTipoDeDocumento.SelectedIndex = 0;
            }
            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }
            cbTipoDeDocumento.SelectedIndex = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {   //Volver
            FormMenu inicio = new FormMenu();
            this.Hide();
            inicio.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {   //Habilitar
            try
            {
                conexion.Open();
                string consulta = "SELECT Mail FROM AEFI.TL_Cliente " +
                                  "WHERE Mail = " + dataGridView1.SelectedCells[5].Value.ToString(); //[0] porque el ID_Cliente es la primer columna
                SqlCommand comando = new SqlCommand(consulta, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                reader.Read();
                String mail = Convert.ToString(reader["Mail"]);
                reader.Close();

                consulta = "UPDATE AEFI.TL_Usuario SET Habilitado = 1 WHERE Mail = " + mail;
                comando = new SqlCommand(consulta, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show("Usuario Habilitado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }
            button3_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {//BUSCAR
            String consulta = "SELECT c.ID_Cliente, c.Nombre, c.Apellido, t.Descripcion, c.Documento_Nro, " +
                                     "c.Mail, c.Telefono, c.Fecha_Nacimiento, c.Calle, c.Calle_Nro, c.Piso, c.Dpto, " +
                                     "c.Localidad " + 
                              "FROM AEFI.TL_Cliente c " +
                              "JOIN AEFI.TL_Tipo_Documento t ON (c.ID_Tipo_Documento = t.ID_Tipo_Documento) " +
                              "WHERE c.ID_Cliente > 0 ";


            
            if (!String.IsNullOrEmpty(cbTipoDeDocumento.SelectedItem.ToString()))
            {
                consulta = consulta + " AND t.Descripcion = @Tipo_Documento ";
            }
            if (!String.IsNullOrEmpty(txbNombre.Text))
            {
                consulta = consulta + " AND c.Nombre LIKE @Nombre ";
            }
            if (!String.IsNullOrEmpty(txbApellido.Text))
            {
                consulta = consulta + " AND c.Apellido LIKE @Apellido ";
            }
            if (!String.IsNullOrEmpty(txbMail.Text))
            {
                consulta = consulta + " AND c.Mail LIKE @Mail ";
            }
            if (!String.IsNullOrEmpty(txbDocumento.Text))
            {
                consulta = consulta + " AND c.Documento_Nro = @Documento_Nro ";
            }

            try
            {
                conexion.Open();
                DataTable tabla = new DataTable();
                SqlCommand comando = new SqlCommand(consulta, conexion);
                SqlParameter[] parametros = new SqlParameter[5];
                parametros[0] = new SqlParameter("@Nombre", BaseDeDatos.agregarPorcentajes(txbNombre.Text));
                parametros[1] = new SqlParameter("@Apellido", BaseDeDatos.agregarPorcentajes(txbApellido.Text));
                parametros[2] = new SqlParameter("@Documento_Nro", txbDocumento.Text);
                parametros[3] = new SqlParameter("@Tipo_Documento", cbTipoDeDocumento.Text);
                parametros[4] = new SqlParameter("@Mail", BaseDeDatos.agregarPorcentajes(txbMail.Text));
                comando.Parameters.AddRange(parametros);
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(tabla);
                dataGridView1.DataSource = tabla;
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

        private void button1_Click(object sender, EventArgs e)
        {//Eliminar
            try
            {
                conexion.Open();
                string consulta = "SELECT Mail FROM AEFI.TL_Cliente " +
                                  "WHERE Mail = " + dataGridView1.SelectedCells[5].Value.ToString(); //[0] porque el ID_Cliente es la primer columna
                SqlCommand comando = new SqlCommand(consulta, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                reader.Read();
                String mail = Convert.ToString(reader[0]);
                reader.Close();

                consulta = "UPDATE AEFI.TL_Usuario SET Habilitado = 0 WHERE Mail = " + mail;
                comando = new SqlCommand(consulta, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show("Usuario Deshabilitado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }
            button3_Click(sender, e);
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                FormClienteNuevo alta = new FormClienteNuevo(1, row.Cells);
                this.Hide();
                alta.ShowDialog();
                this.Close();
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //Limpiar
            dataGridView1.DataSource = null;
            txbApellido.Clear();
            txbDocumento.Clear();
            txbMail.Clear();
            txbNombre.Clear();
            cbTipoDeDocumento.SelectedIndex = 0;
        }

        private void seleccionarBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                MessageBox.Show("Cliente seleccionado correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                this.Close();

            }
            else
            {
                MessageBox.Show("Debe seleccionar un cliente", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
