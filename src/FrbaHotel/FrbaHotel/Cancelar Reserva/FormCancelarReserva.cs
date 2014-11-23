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
        ShortDateString f;

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
                f = dtpFechaDeCancelacion.Value.ToShortDateString;
                if (0 > DateTime.Compare(f, DateTime.Now))
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("AEFI.cancelar_Reserva", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@ID_Reserva", txbNumeroDeReserva));
                    comando.Parameters.Add(new SqlParameter("@Motivo", txbMotivo));//vamos a tener que agregar un campo en la tabla de reserva para poder guardar el motivo de cancelacion
                    comando.Parameters.Add(new SqlParameter("@FechaDeCancelacion", dtpFechaDeCancelacion));
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
        }
    }
}
