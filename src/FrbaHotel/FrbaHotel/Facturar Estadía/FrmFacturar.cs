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
using FrbaHotel.Facturar_Estadía;

namespace FrbaHotel.Facturar_Estadia
{
    public partial class FrmFacturar : Form
    {
       int numeroTarjeta;
        SqlConnection conexion = BaseDeDatos.conectar();

        public FrmFacturar()
        {
            InitializeComponent();
        }


        private void FrmFacturar_Load(object sender, EventArgs e)
        {

            String cargarEstadias = "SELECT e.ID_Estadia, e.ID_Reserva, e.Fecha_Inicio, e.Cantidad_Noches, e.ID_Factura FROM AEFI.TL_Estadia e, AEFI.TL_Reserva r, AEFI.TL_Habitacion h WHERE e.ID_Reserva = r.ID_Reserva AND h.ID_Habitacion = r.ID_Habitacion AND e.Estado = 1 AND h.ID_Hotel = " + Program.idHotel;
            
            
            try
            {
                //Cargo las estadias
                conexion.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cargarEstadias, conexion);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                estadiaDGV.DataSource = tabla;


                //Cargo los medios de pago
                if (medioDePagoCmbBox.Items.Count == 0) //para que al recargar la pagina no vuelva a agregar más items
                {
                    medioDePagoCmbBox.Items.Add("Efectivo");
                    medioDePagoCmbBox.Items.Add("Tarjeta de Crédito");
                    medioDePagoCmbBox.SelectedIndex = 0;
                }
                conexion.Close();
            }


            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }

        private void volverBtn_Click(object sender, EventArgs e)
        {
            FormMenu inicio = new FormMenu();
            this.Hide();
            inicio.ShowDialog();
            this.Close();
        }

        private void facturarBtn_Click(object sender, EventArgs e)
        {
           
            String obtenerReserva = "SELECT ID_Reserva FROM AEFI.TL_Estadia WHERE ID_Estadia = @id_estadia";
            String obtenerRegimen = "SELECT ID_Regimen FROM AEFI.TL_Reserva WHERE ID_Reserva= @id_reserva";

        

            String obtenerIDFactura = "SELECT ID_Factura FROM AEFI.TL_Estadia WHERE ID_Estadia = @id_estadia";
            String obtenerMontoTotal = "SELECT Total FROM AEFI.TL_Factura WHERE ID_Factura = @id_factura";

            String obtenerIdCliente = "SELECT r.ID_Cliente FROM AEFI.TL_Reserva r WHERE r.ID_Reserva = @id_reserva";
            String obtenerFechaFinEstadia = "SELECT DATEADD(DAY, e.cantidad_noches, e.fecha_inicio) FROM AEFI.TL_Estadia e WHERE ID_Estadia = @id_estadia";

            try
            {
                conexion.Open();

                if (estadiaDGV.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in estadiaDGV.SelectedRows)
                    {
                       

                        SqlCommand comando = new SqlCommand(obtenerReserva, conexion);
                        comando.Parameters.Add(new SqlParameter("@id_estadia", row.Cells["id_estadia"].Value));
                        SqlDataReader reader = comando.ExecuteReader();
                        reader.Read();
                        int id_reserva = Convert.ToInt32(reader[0]);
                        reader.Close();


                        comando = new SqlCommand(obtenerRegimen, conexion);
                        comando.Parameters.Add(new SqlParameter("@id_reserva", id_reserva));
                        reader = comando.ExecuteReader();
                        reader.Read();
                        int id_regimen = Convert.ToInt32(reader[0]);
                        reader.Close();

                        //Obtengo id de cliente a quien le voy a cobrar
                        comando = new SqlCommand(obtenerIdCliente, conexion);
                        comando.Parameters.Add(new SqlParameter("@id_reserva", id_reserva));
                        reader = comando.ExecuteReader();
                        reader.Read();
                        int idCliente = Convert.ToInt32(reader[0]);
                        reader.Close();

                        //Obtengo fecha de salida
                        comando = new SqlCommand(obtenerFechaFinEstadia, conexion);
                        comando.Parameters.Add(new SqlParameter("@id_estadia", row.Cells["id_estadia"].Value));
                        reader = comando.ExecuteReader();
                        reader.Read();
                        DateTime fechaSalida = Convert.ToDateTime(reader[0]);
                        reader.Close();

                        //Verifico medio de pago seleccionado
                        if (String.Equals(medioDePagoCmbBox.SelectedItem.ToString(), "Tarjeta de Crédito"))
                        {
                            FrmTarjeta ingreso = new FrmTarjeta(idCliente, this);
                            ingreso.ShowDialog();
                            


                        }

             
                        //obtengo la factura linkeada a la estadia
                        comando = new SqlCommand(obtenerIDFactura, conexion);
                        comando.Parameters.Add(new SqlParameter("@id_estadia", row.Cells["id_estadia"].Value));
                        reader = comando.ExecuteReader();
                        reader.Read();
                        int idFactura = Convert.ToInt32(reader[0]);
                        reader.Close();

                       
                        //Cargo los items de la factura

                        //cargo el item estadia
                        comando = new SqlCommand("AEFI.insertar_item_precio_estadia", conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@id_factura", idFactura)); 
                        comando.Parameters.Add(new SqlParameter("@id_estadia", row.Cells["id_estadia"].Value));
                        comando.Parameters.Add(new SqlParameter("@id_regimen", id_regimen));
                        comando.ExecuteNonQuery();


                        //Verifico si le faltaban dias de estadia. Si le faltan, lo inserto en la factura.
                        if (fechaSalida < System.DateTime.Today)
                        {
                            comando = new SqlCommand("AEFI.insertar_item_precio_diasNoAlojados", conexion);
                            comando.CommandType = CommandType.StoredProcedure;
                            comando.Parameters.Add(new SqlParameter("@id_factura", idFactura));
                            comando.Parameters.Add(new SqlParameter("@id_estadia", row.Cells["id_estadia"].Value));
                            comando.Parameters.Add(new SqlParameter("@id_regimen", id_regimen));
                            comando.ExecuteNonQuery();
                        }

                        //Almaceno el pago dependiendo del tipo .   


                        if (String.Equals(medioDePagoCmbBox.SelectedItem.ToString(), "Tarjeta de Crédito"))
                        {

                            comando = new SqlCommand("AEFI.insertar_Registro_Pago_Con_Tarjeta", conexion);
                            comando.CommandType = CommandType.StoredProcedure;
                            comando.Parameters.Add(new SqlParameter("@id_factura", idFactura));
                            comando.Parameters.Add(new SqlParameter("@numeroTarjeta", Convert.ToInt32(this.numeroTarjeta)));
                            comando.Parameters.Add(new SqlParameter("@id_cliente", idCliente));
                            comando.ExecuteNonQuery();

                        }
                        else
                        {
                            comando = new SqlCommand("AEFI.insertar_Registro_Pago_Sin_Tarjeta", conexion);
                            comando.CommandType = CommandType.StoredProcedure;
                            comando.Parameters.Add(new SqlParameter("@id_factura", idFactura));
                            comando.Parameters.Add(new SqlParameter("@id_cliente", idCliente));
                            comando.ExecuteNonQuery();

                        }

                        //Obtengo el monto total de la factura.

                            comando = new SqlCommand(obtenerMontoTotal, conexion);
                            comando.Parameters.Add(new SqlParameter("@id_factura", idFactura));
                            reader = comando.ExecuteReader();
                            reader.Read();
                            int monto = Convert.ToInt32(reader[0]);
                            reader.Close();


                        


                        MessageBox.Show("El numero de factura es: " +  idFactura.ToString() + " cuyo monto total es : U$S" + monto.ToString(), "" , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        conexion.Close();
                        this.FrmFacturar_Load(this, e);

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

        public void setearNumeroTarjeta(int numTarjeta) {

            numeroTarjeta = numTarjeta;
        }
    }

}
