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

namespace FrbaHotel.Facturar_Estadia
{
    public partial class FrmFacturar : Form
    {

        SqlConnection conexion = BaseDeDatos.conectar();

        public FrmFacturar()
        {
            InitializeComponent();
        }


        private void FrmFacturar_Load(object sender, EventArgs e)
        {

            String cargarEstadias = "SELECT * FROM AEFI.TL_Estadia";
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

                        comando = new SqlCommand("AEFI.insertar_factura", conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@forma_pago", medioDePagoCmbBox.SelectedItem.ToString()));
                        comando.Parameters.Add(new SqlParameter("@fecha", Program.fecha));
                        SqlParameter par = new SqlParameter("@nro_factura", 0);
                        par.Direction = ParameterDirection.Output;
                        comando.Parameters.Add(par);
                        comando.ExecuteNonQuery();
                        /*
                                        if (dataGridView.SelectedRows.Count > 0)
                                        {
                                            foreach (DataGridViewRow row in dataGridView.SelectedRows)
                                            {
                                                string consultaCantidadConsumiciones = "SELECT COUNT(*) " +
                                                    "FROM AEFI.Consumible_Por_Estadia c " +
                                                    "JOIN AEFI.Estadia e ON (e.ID_Estadia = c.ID_Estadia ) "+
                                                    "AND c.ID_Consumible = @consumible ";
                                                comando = new SqlCommand(consultaCantidadConsumiciones, conexion);
                                                SqlDataReader reader = comando.ExecuteReader();
                                                reader.Read();
                                                int cantidadConsumiciones = Convert.ToInt32(reader[0]);
                                                reader.Close();







                                }*/
                    }


                }
            }

            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }
    }

}
