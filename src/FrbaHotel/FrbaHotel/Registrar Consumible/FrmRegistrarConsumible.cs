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


namespace FrbaHotel.Registrar_Consumible
{
    public partial class FrmRegistrarConsumible : Form
    {
        SqlConnection conexion = BaseDeDatos.conectar();

        public FrmRegistrarConsumible()
        {
            InitializeComponent();
        }

        private void FrmRegistrarConsumible_Load(object sender, EventArgs e)
        {
            string consultaCons = "SELECT Descripcion FROM AEFI.TL_Consumible";
            string consultaHab = "SELECT DISTINCT ID_Tipo_Habitacion FROM AEFI.TL_Habitacion";
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand(consultaHab, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                    cbHabitacion.Items.Add(reader[0]);
                reader.Close();
                cbHabitacion.SelectedIndex = 0;
            }
            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }
            cbHabitacion.SelectedIndex = 0;
        }

        private void volverBtn_Click(object sender, EventArgs e)
        {
            FormMenu inicio = new FormMenu();
            this.Hide();
            inicio.ShowDialog();
            this.Close();
        }

        private void cbConsumibles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstConsumibles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AGREGAR_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
