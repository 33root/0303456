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
                

                string obtenerIdDelHotelDelUsuarioLogueado = "SELECT ID_Hotel " +
                                                             "FROM AEFI.TL_Usuario_Por_Hotel " +
                                                             "WHERE ID_Hotel = " + BaseDeDatos.agregarApostrofos(Program.idHotel.ToString()) + "AND ID_Usuario = " + BaseDeDatos.agregarApostrofos(Program.idUsuario.ToString());

                comando = new SqlCommand(obtenerIdDelHotelDelUsuarioLogueado, conexion);
                reader = comando.ExecuteReader();
                reader.Read();
                int idHotel = Convert.ToInt32(reader[0]);
                

                string obtenerIdDelHotelDeLaReserva = "SELECT h.ID_Hotel " +
                                                      "FROM AEFI.TL_Regimen_Por_Hotel h, AEFI.TL_Reserva r " +
                                                      "WHERE h.ID_Regimen = r.ID_Regimen AND r.ID_Reserva = " + BaseDeDatos.agregarApostrofos(txbNumeroDeReserva.Text) +" AND h.ID_Hotel = " + BaseDeDatos.agregarApostrofos(Program.idHotel.ToString()) ;

                comando = new SqlCommand(obtenerIdDelHotelDeLaReserva, conexion);
                reader = comando.ExecuteReader();
                reader.Read();
                int idHotelDeReserva = Convert.ToInt32(reader[0]);
                

                string elIdDeLaReservaDelTxbExiste = "SELECT ID_Reserva " +
                                                     "FROM AEFI.TL_Reserva " +
                                                     "WHERE ID_Reserva = " + BaseDeDatos.agregarApostrofos(txbNumeroDeReserva.Text);
                comando = new SqlCommand(elIdDeLaReservaDelTxbExiste, conexion);
                SqlDataReader reader2 = comando.ExecuteReader();
                reader2.Read();
                

                string laReservaNoTieneEstadia = "SELECT ID_Reserva " +
                                                 "FROM AEFI.TL_Estadia " +
                                                 "WHERE ID_Reserva = " + BaseDeDatos.agregarApostrofos(txbNumeroDeReserva.Text);
                comando = new SqlCommand(laReservaNoTieneEstadia,conexion);
                reader = comando.ExecuteReader();
                reader.Read();

                string laReservaYaFueCancelada = "SELECT ID_Reserva " +
                                                 "FROM AEFI.TL_Estadia " +
                                                 "WHERE Estado LIKE 'Cancelada' AND ID_Reserva = " + BaseDeDatos.agregarApostrofos(txbNumeroDeReserva.Text);
                comando = new SqlCommand(laReservaYaFueCancelada, conexion);
                SqlDataReader reader3 = comando.ExecuteReader();
                reader3.Read();
                

                if (!reader3.HasRows)
                {
                    if (!reader.HasRows)
                    {
                        if (reader2.HasRows)
                        {
                            if ( Program.idHotel == idHotelDeReserva)
                            {
                                if (1 <= (fechaInicioReserva - DateTime.Now).TotalDays)
                                {
                                    comando = new SqlCommand("AEFI.cancelar_Reserva", conexion);
                                    comando.CommandType = CommandType.StoredProcedure;
                                    comando.Parameters.Add(new SqlParameter("@ID_Reserva", txbNumeroDeReserva.Text));
                                    comando.Parameters.Add(new SqlParameter("@Motivo", txbMotivo.Text)); ;
                                    comando.Parameters.Add(new SqlParameter("@ID_Usuario", Program.idUsuario));
                                    comando.ExecuteNonQuery();
                                    MessageBox.Show("Reserva Cancelada Correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    throw new Excepciones("No puede cancelar la reserva en esta fecha");
                                }
                            }
                            else
                            {
                                throw new Excepciones("La reserva seleccionada no pertenece al hotel logueado");
                            }
                        }
                        else
                        {
                            throw new Excepciones("El codigo de reserva elegido no pertenece a una reserva existente");
                        }
                    }
                    else
                    {
                        throw new Excepciones("La reserva ya tiene una estadia");
                    }
                }
                else 
                {
                    throw new Excepciones("La reserva ya fue cancelada");
                }
            }

            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Excepciones exc)
            {
                MessageBox.Show(exc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                conexion.Close();
                this.VolverButton_Click(this, e);
            }
        }

        private static void permitirSoloNumeros(KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private static void permitirSoloLetras(KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txbNumeroDeReserva_KeyPress(object sender, KeyPressEventArgs e)
        {
            permitirSoloNumeros(e);
        }

        private void txbMotivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            permitirSoloLetras(e);
        }
    }
}
