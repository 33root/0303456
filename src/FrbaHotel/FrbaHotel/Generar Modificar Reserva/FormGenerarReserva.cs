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

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class FormGenerarReserva : Form
    {

        SqlConnection conexion = BaseDeDatos.conectar();

        public FormGenerarReserva()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkearDisponibilidadButton_Click(object sender, EventArgs e)
        {

        }

        private void ingresarButton_Click(object sender, EventArgs e)
        {

        }

        private void verCostoButton_Click(object sender, EventArgs e)
        {

        }

        private void FormGenerarReserva_Load(object sender, EventArgs e)
        {
            try {
                string consulta = "SELECT Descripcion"
                                 +"FROM AEFI.TL_Tipo_Habitacion";

                conexion.Open();
                SqlCommand comando = new SqlCommand(consulta, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                    cbTipoDeHabitacion.Items.Add(reader[0]); //carga los tipos de habitacion en el combo box
                reader.Close();
                cbTipoDeHabitacion.SelectedIndex = 0;

                string consulta2 = "SELECT Descripcion"
                                 + "FROM AEFI.TL_Regimen";

                SqlCommand comando2 = new SqlCommand(consulta2, conexion);
                SqlDataReader reader2 = comando2.ExecuteReader();
                while (reader2.Read())
                    cbTipoDeRegimen.Items.Add(reader[0]); //carga los tipos de regimen en el combo box
                reader.Close();
                cbTipoDeRegimen.SelectedIndex = 0;
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

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            FormMenu inicio = new FormMenu();
            this.Hide();
            inicio.ShowDialog();
            this.Close();
        }
    }
}
