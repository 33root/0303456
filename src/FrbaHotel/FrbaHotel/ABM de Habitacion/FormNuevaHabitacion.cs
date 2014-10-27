using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Menu;
using System.Data.SqlClient;

namespace FrbaHotel.ABM_de_Habitacion
{
    public partial class FormNuevaHabitacion : Form
    {

        SqlConnection conexion = BaseDeDatos.conectar();
        int x = 0;

        public FormNuevaHabitacion()
        {
            InitializeComponent();
            cmbVista.Items.Add("S");
            cmbVista.Items.Add("N");
        }

        private void tbNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                SqlCommand comando = null;


                comando = new SqlCommand("AEFI.crear_Habitacion", conexion);

                comando.CommandType = CommandType.StoredProcedure;
                //comando.Parameters.Add(new SqlParameter("@ID_Habitacion", lbIdHabitacion.Text));
                comando.Parameters.Add(new SqlParameter("@Numero", tbNumero.Text));
                comando.Parameters.Add(new SqlParameter("@Piso", tbPiso.Text));
                comando.Parameters.Add(new SqlParameter("@Vista", cmbVista.Text));
                comando.Parameters.Add(new SqlParameter("@Tipo_Habitacion", cmbTHabitacion.Text));
                comando.Parameters.Add(new SqlParameter("@Descripcion", rtbDescripcion.Text));
                comando.Parameters.Add(new SqlParameter("@Porcentual", tbPorcentual.Text));


                SqlDataReader dr = comando.ExecuteReader();

                MessageBox.Show("La Habitacion se creo satisfactoriamente", "Habitacion Creada", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Excepciones exc)
            {
                MessageBox.Show(exc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnVolver_Click(object sender, EventArgs e)
        {
            if (x == 0)
            {
                FormMenu inicio = new FormMenu();
                this.Hide();
                inicio.ShowDialog();
                this.Close();
            }
        }

        private void tbPiso_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbVista_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbTHabitacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rtbDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormNuevaHabitacion_Load(object sender, EventArgs e)
        {

        }

    }
}

