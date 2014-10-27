using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.ABM_de_Rol
{
    public partial class FormCrearRol : Form
    {

        SqlConnection conexion = BaseDeDatos.conectar();
        int codigoRol;

        public FormCrearRol()
        {
            InitializeComponent();
        }

        private void FormCrearRol_Load(object sender, EventArgs e) {
            String consultaFuncionalidades = "SELECT Descripcion " +
                                   "FROM AEFI.TL_Funcionalidad f ";

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand(consultaFuncionalidades, conexion);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    checkedListBox1.Items.Add(Convert.ToString(reader["Descripcion"]));

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
        
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormRol rol = new FormRol();
            this.Hide();
            rol.ShowDialog();
            this.Close();

        }

        private void aceptarBtn_Click(object sender, EventArgs e)
        {

            try
            {
                conexion.Open();
                string consulta = "INSERT INTO AEFI.TL_Rol(Descripcion) VALUES ('" + nombreRolTxtBox.Text + "')";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.ExecuteNonQuery();

                foreach (int indexChecked in checkedListBox1.CheckedIndices)
                {
                    comando = new SqlCommand("AEFI.insertar_rol_funcionalidad", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@rol", nombreRolTxtBox.Text));
                    comando.Parameters.Add(new SqlParameter("@funcionalidad", Convert.ToString(checkedListBox1.Items[indexChecked])));
                    comando.ExecuteNonQuery();

                }

                MessageBox.Show("Rol Creado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void nombreRolTxtBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}