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

            String cargarEstadias = "SELECT ID_Estadia, ID_Reserva, Fecha_Inicio, Cantidad_Noches, ID_Factura FROM AEFI.TL_Estadia WHERE Estado = 1";
            String consultaMediosDePago = "SELECT Descripcion FROM AEFI.TL_FormaDePago";
            
            try
            {
                //Cargo las estadias
                conexion.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cargarEstadias, conexion);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                estadiaDGV.DataSource = tabla;


                //Cargo los medios de pago


                SqlCommand comando = new SqlCommand(consultaMediosDePago, conexion);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    medioDePagoCmbBox.Items.Add(reader["Descripcion"].ToString());
                }

                reader.Close();
                medioDePagoCmbBox.SelectedIndex = 0;

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

            String obtenerTodoConsumoDeEstadia= "SELECT ID_Consumible FROM AEFI.TL_Consumible_Por_Estadia "+
                                                 "WHERE ID_Estadia = @id_estadia";
            String asignarFacturaAEstadia = "UPDATE AEFI.TL_Estadia SET ID_Factura = @id_factura WHERE ID_Estadia = @id_estadia";

            String obtenerIdCliente = "SELECT r.ID_Cliente FROM AEFI.TL_Reserva r WHERE r.ID_Reserva = @id_reserva";  

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


                        //Verifico medio de pago seleccionado
                        if (String.Equals(medioDePagoCmbBox.SelectedItem.ToString(), "Tarjeta de Crédito"))
                        {
                            FrmTarjeta ingreso = new FrmTarjeta(idCliente, this);
                            ingreso.ShowDialog();
                            


                        }

                        //Creo la factura
                        comando = new SqlCommand("AEFI.insertar_factura", conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@forma_pago", medioDePagoCmbBox.SelectedItem.ToString()));
                        comando.Parameters.Add(new SqlParameter("@fecha", Program.fecha));
                        comando.Parameters.Add(new SqlParameter("@id_reserva",id_reserva));
                        SqlParameter par = new SqlParameter("@id_factura", 0);
                        par.Direction = ParameterDirection.Output;
                        comando.Parameters.Add(par);
                        comando.ExecuteNonQuery();

                        //Linkeo factura con estadia
                        comando = new SqlCommand(asignarFacturaAEstadia, conexion);
                        comando.Parameters.Add(new SqlParameter("@id_factura", par.Value));
                        comando.Parameters.Add(new SqlParameter("@id_estadia", row.Cells["id_estadia"].Value));
                        comando.ExecuteNonQuery();


                        //Cargo los items de la factura

                        //cargo el item estadia
                        comando = new SqlCommand("AEFI.insertar_item_precio_estadia", conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@id_factura", par.Value)); //Item factura;
                        comando.Parameters.Add(new SqlParameter("@id_estadia", row.Cells["id_estadia"].Value));
                        comando.Parameters.Add(new SqlParameter("@id_regimen", id_regimen));
                        comando.ExecuteNonQuery();

                        //cargo los consumibles
                        comando = new SqlCommand(obtenerTodoConsumoDeEstadia, conexion);
                        comando.Parameters.Add(new SqlParameter("@id_estadia", row.Cells["id_estadia"].Value));
                       
                        reader = comando.ExecuteReader();

                        while (reader.Read())
                        {
                            int id_consumible = Convert.ToInt32(reader[0]);


                            comando = new SqlCommand("AEFI.insertar_item_consumible", conexion);
                            comando.CommandType = CommandType.StoredProcedure;
                            comando.Parameters.Add(new SqlParameter("@id_factura", par.Value));
                            comando.Parameters.Add(new SqlParameter("@id_consumible", id_consumible));
                            comando.Parameters.Add(new SqlParameter("@id_regimen", id_regimen));
                            comando.Parameters.Add(new SqlParameter("@id_estadia", row.Cells["id_estadia"].Value));
                            comando.ExecuteNonQuery();
                                                     
                            
                         }
                        //Almaceno el pago dependiendo del tipo .   
                        

                        if (String.Equals(medioDePagoCmbBox.SelectedItem.ToString(), "Tarjeta de Crédito")){

                            comando = new SqlCommand("AEFI.insertar_Registro_Pago_Con_Tarjeta", conexion);
                            comando.CommandType = CommandType.StoredProcedure;
                            comando.Parameters.Add(new SqlParameter("@id_factura", par.Value));
                            comando.Parameters.Add(new SqlParameter("@fecha", System.DateTime.Today));
                            comando.Parameters.Add(new SqlParameter("@numeroTarjeta", Convert.ToInt32(this.numeroTarjeta)));
                            comando.Parameters.Add(new SqlParameter("@id_cliente", idCliente));
                            comando.ExecuteNonQuery();
                        
                        }
                        else {
                            comando = new SqlCommand("AEFI.insertar_Registro_Pago_Sin_Tarjeta", conexion);
                            comando.CommandType = CommandType.StoredProcedure;
                            comando.Parameters.Add(new SqlParameter("@id_factura", par.Value));
                            comando.Parameters.Add(new SqlParameter("@fecha", System.DateTime.Today));
                            comando.Parameters.Add(new SqlParameter("@id_cliente", idCliente));
                            comando.ExecuteNonQuery();
                        
                        }


                        MessageBox.Show("La factura generada en la Número: " +  par.Value.ToString(), "" , MessageBoxButtons.OK, MessageBoxIcon.Information);
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
