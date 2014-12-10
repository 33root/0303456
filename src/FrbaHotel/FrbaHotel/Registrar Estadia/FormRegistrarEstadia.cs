    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaHotel.ABM_de_Cliente;
using FrbaHotel.Menu;
using FrbaHotel.Generar_Modificar_Reserva;


namespace FrbaHotel.Registrar_Estadia
{   

    public partial class FormRegistroEstadia : Form
    {
        SqlConnection conexion = BaseDeDatos.conectar();

        public FormRegistroEstadia()
        {
            InitializeComponent();
        }


        private void btnEntrada_Click(object sender, EventArgs e)
        {
            string obtenerCantidadDeHospedados = "SELECT Cantidad_Huespedes FROM AEFI.TL_Reserva r WHERE r.ID_Reserva = @idReserva";
            String recepcionistaHabilitadoReservaCheckIn = "SELECT ID_Reserva FROM AEFI.TL_Reserva r, AEFI.TL_Usuario_Por_Hotel uph, AEFI.TL_Habitacion h " +
                                                   "WHERE r.ID_Habitacion = h.ID_Habitacion AND h.ID_Hotel = uph.ID_Hotel " +
                                                   "AND r.Estado = 'Correcta' "+
                                                   "AND uph.ID_Usuario = @idUsuario AND uph.ID_Rol = 2 AND uph.ID_Rol = @idRol AND r.ID_Reserva = @idReserva " +
                                                   "AND NOT EXISTS(SELECT re.ID_Estadia FROM AEFI.TL_Registro_Evento re, AEFI.TL_Estadia e WHERE e.ID_Reserva = @idReserva AND e.ID_Estadia = re.ID_Estadia AND re.Descripcion ='Ingreso')";

            String verificarFechaDeIngresoHoy = " SELECT * FROM AEFI.TL_Reserva r WHERE MONTH(r.Fecha_Desde) = MONTH(GETDATE()) AND YEAR(r.fecha_desde) = YEAR(GETDATE()) AND DAY(r.Fecha_Desde) = DAY(GETDATE()) AND r.Estado = 'Correcta' AND r.ID_Reserva = " + reservaTxtBox.Text;


            try
            {
                conexion.Open();




                if (verificarRecepcionistaHabilitado(recepcionistaHabilitadoReservaCheckIn))
                {
                    SqlCommand comando = new SqlCommand(verificarFechaDeIngresoHoy, conexion);
                    SqlDataReader reader = comando.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        comando = new SqlCommand("AEFI.cancelarReserva", conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@IDReserva", reservaTxtBox.Text));
                        comando.ExecuteNonQuery();

                        MessageBox.Show("La reserva no corresponde al día corriente. Realice una nueva reserva", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        button3_Click(this, e);

                    }
                    else
                    {
                        comando = new SqlCommand(obtenerCantidadDeHospedados, conexion);
                        comando.Parameters.Add(new SqlParameter("@idReserva", reservaTxtBox.Text));
                        reader = comando.ExecuteReader();
                        reader.Read();
                        int numeroHospedados = Convert.ToInt32(reader[0]);
                        reader.Close();

                        for (int i = 0; i < numeroHospedados; i++)
                        {
                            int j = i;
                            MessageBox.Show("Ingrese el huesped número: " + (++j), "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            FrmHuesped huesped = new FrmHuesped(1);
                            huesped.ShowDialog();

                        }

                        //Creo la factura
                        comando = new SqlCommand("AEFI.insertar_factura", conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@fecha", Program.fecha));
                        comando.Parameters.Add(new SqlParameter("@id_reserva", reservaTxtBox.Text));
                        SqlParameter par = new SqlParameter("@id_factura", 0);
                        par.Direction = ParameterDirection.Output;
                        comando.Parameters.Add(par);
                        comando.ExecuteNonQuery();
                        int idFactura = Convert.ToInt32(par.Value);


                        //Genero el ingreso
                        comando = new SqlCommand("AEFI.generarIngresoEstadia", conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@idFactura", idFactura));
                        comando.Parameters.Add(new SqlParameter("@idReserva", reservaTxtBox.Text));
                        comando.Parameters.Add(new SqlParameter("@idUsuario", Program.idUsuario));
                        comando.ExecuteNonQuery();

                        MessageBox.Show("El check in de la estadía fue correctamente procesado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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

      

        private void salidaBtn_Click(object sender, EventArgs e)
        {
            String recepcionistaHabilitadoReservaCheckOut = "SELECT ID_Reserva FROM AEFI.TL_Reserva r, AEFI.TL_Usuario_Por_Hotel uph, AEFI.TL_Habitacion h " +
                                                   "WHERE r.ID_Habitacion = h.ID_Habitacion AND h.ID_Hotel = uph.ID_Hotel " +
                                                   "AND uph.ID_Usuario = @idUsuario AND uph.ID_Rol = 2 AND uph.ID_Rol = @idRol AND r.ID_Reserva = @idReserva " +
                                                   "AND r.Estado = 'Efectivizada' "+
                                                   "AND NOT EXISTS(SELECT re.ID_Estadia FROM AEFI.TL_Registro_Evento re, AEFI.TL_Estadia e WHERE e.ID_Reserva = @idReserva AND e.ID_Estadia = re.ID_Estadia AND re.Descripcion ='Egreso')";
           
            try
            {
                conexion.Open();
                if (verificarRecepcionistaHabilitado(recepcionistaHabilitadoReservaCheckOut))
                {

                    //Genero el egreso
                    SqlCommand comando = new SqlCommand("AEFI.generarEgresoEstadia", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@idReserva", reservaTxtBox.Text));
                    comando.Parameters.Add(new SqlParameter("@idUsuario", Program.idUsuario));
                    comando.ExecuteNonQuery();

                    MessageBox.Show("El check out de la estadía fue correctamente procesado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private bool verificarRecepcionistaHabilitado(String consulta)
        {

            String obtenerNombreUsuario = "SELECT Username FROM AEFI.TL_Usuario u WHERE u.ID_Usuario = " + Program.idUsuario;


          
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.Add(new SqlParameter("@idUsuario", Program.idUsuario));
                comando.Parameters.Add(new SqlParameter("@idRol", Program.idRol));
                comando.Parameters.Add(new SqlParameter("@idReserva", reservaTxtBox.Text));
                SqlDataReader reader = comando.ExecuteReader();


                if (reader.HasRows)
                {
                    MessageBox.Show("Reserva válida ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    reader.Close();


                    comando = new SqlCommand(obtenerNombreUsuario, conexion);
                    reader = comando.ExecuteReader();
                    reader.Read();
                    String nombreUsuario = Convert.ToString(reader[0]);
                    reader.Close();



                    MessageBox.Show("La reserva no corresponde a ningún hotel del usuario " + nombreUsuario + " o el evento ya fue registrado ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }
            }

       
           
        

        private void reservaTxtBox_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {

            FormMenu inicio = new FormMenu();
            this.Hide();
            inicio.ShowDialog();
            this.Close();
        
        }

        }
    }

