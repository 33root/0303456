using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class FormBuscadorDeClientes : Form
    {
        SqlConnection conexion = BaseDeDatos.conectar();

        public FormBuscadorDeClientes()
        {
            InitializeComponent();
        }

        private void FormBuscadorDeClientes_Load(object sender, EventArgs e)
        {
            string consulta = "SELECT Descripcion FROM AEFI.TL_Tipo_Documento"; //me parece que esto tendria que ser un tipo de documento, que por ahora no esta en nuestra tabla de clientes
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand(consulta, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                    cbTipoDeDocumento.Items.Add(reader[0]); //carga los tipos de documentos en el combo box, aunque por ahora no estan cargados los tipos
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            /*Menu inicio = new Menu();   lo dejo comentado porque no me deja poner el using
            this.Hide();
            inicio.ShowDialog();
            this.Close();*/
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                string consulta = "SELECT ID_Usuario FROM AEFI.TL_Cliente " +
                                  "WHERE Documento_Nro = " + dataGridView1.SelectedCells[4].Value;
                SqlCommand comando = new SqlCommand(consulta, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                reader.Read();
                int id = Convert.ToInt32(reader[0]);
                reader.Close();

                consulta = "UPDATE AEFI.TL_Usuario SET Habilitado = 1 WHERE ID_Usuario = " + id;
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
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            txbApellido.Clear();
            txbDocumento.Clear();
            txbMail.Clear();
            txbNombre.Clear();
            cbTipoDeDocumento.SelectedIndex = 0;
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                //FormClienteNuevo alta = new FormClienteNuevo(1, row.Cells); la otra clase no esta terminada :P
                this.Hide();
                //alta.ShowDialog();
                this.Close();
            }
        }

        private void txbNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbMail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbApellido_TextChanged(object sender, EventArgs e)
        {

        }      
    }
        }
