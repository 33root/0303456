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
        DateTimePicker f;
       

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
                f = dtpFechaDeCancelacion;
                
                if (0 > DateTime.Compare(f.Value, DateTime.Now))
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("AEFI.cancelar_Reserva", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@ID_Reserva", txbNumeroDeReserva.Text));
                    comando.Parameters.Add(new SqlParameter("@Motivo", txbMotivo.Text));
                    comando.Parameters.Add(new SqlParameter("@FechaDeCancelacion", dtpFechaDeCancelacion.Value.Date));
                    comando.Parameters.Add(new SqlParameter("@ID_Usuario", Program.idUsuario));
                    //acordarce de cambiar el estado de reserva a "cancelada" en el store procedure
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
            }
        }
    }
}
