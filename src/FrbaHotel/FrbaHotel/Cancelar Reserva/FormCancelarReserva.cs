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


namespace FrbaHotel.Cancelar_Reserva
{
    public partial class FormCancelarReserva : Form
    {
        SqlConnection conexion = BaseDeDatos.conectar();
       

        public FormCancelarReserva()
        {
            InitializeComponent();
        }

        private void FormCancelarReserva_Load(object sender, EventArgs e)
        {

        }

        private void VolverButton_Click(object sender, EventArgs e)
        {
            FormMenu inicio = new FormMenu();
            this.Hide();
            inicio.ShowDialog();
            this.Close();
        }

        private void CancelarReservaButton_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                string obtenerDiaDeReserva = "SELECT Fecha_Desde FROM AEFI.TL_Reserva WHERE ID_Reserva = " + Convert.ToInt32(txbNumeroDeReserva.Text);
                SqlCommand comando = new SqlCommand(obtenerDiaDeReserva, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                reader.Read();
                DateTime fechaInicioReserva = Convert.ToDateTime(reader["Fecha_Desde"]);
                reader.Close();


                if (1 <= (fechaInicioReserva -DateTime.Now).TotalDays )
                {
                    comando = new SqlCommand("AEFI.cancelar_Reserva", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@ID_Reserva", txbNumeroDeReserva.Text));
                    comando.Parameters.Add(new SqlParameter("@Motivo", txbMotivo.Text));;
                    comando.Parameters.Add(new SqlParameter("@ID_Usuario", Program.idUsuario));
                    MessageBox.Show("Reserva Cancelada Correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    throw new Excepciones("No puede cancelar la reserva en esta fecha");
                }
            }
            catch(SqlException exc)
            {
                MessageBox.Show(exc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                conexion.Close();
                this.VolverButton_Click(this, e);
            }
        }
    }
}
