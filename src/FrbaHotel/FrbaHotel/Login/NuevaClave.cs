using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.Login
{

    public partial class NuevaClave : Form
    {

        SqlConnection conexion = BaseDeDatos.conectar();
        string usuario;

        public NuevaClave(string usuarioModificar)
        {
            InitializeComponent();
            this.usuario = usuarioModificar;
        }

        private void NuevaClave_Load(object sender, EventArgs e)
        {

        }

        private void aceptarBtn_Click(object sender, EventArgs e)
        {

            String consulta = "UPDATE AEFI.TL_Usuario " +
                "SET Password = @contrasena, Pass_Temporal = 0 " +
                "WHERE Username = @usuario";

            if (String.Equals(clave2TxtBox.Text, claveTxtBox.Text))
            {

                try
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    comando.Parameters.Add(new SqlParameter("@usuario", this.usuario));
                    comando.Parameters.Add(new SqlParameter("@contrasena", BaseDeDatos.cifrar256(claveTxtBox.Text)));
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Clave modificada exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (SqlException exc)
                {
                    MessageBox.Show(exc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conexion.Close();

                    this.cancelarBtn_Click(this,e);
                }
                
            }
            else
            {
                MessageBox.Show("Las claves NO coiciden", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cancelarBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogIn inicio = new FrmLogIn();
            inicio.ShowDialog();
            this.Close();
        }
    }
}