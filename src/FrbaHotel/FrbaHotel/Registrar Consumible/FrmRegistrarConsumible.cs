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
        int idEstadia;
        SqlConnection conexion = BaseDeDatos.conectar();

        public FrmRegistrarConsumible()
        {
            InitializeComponent();
        }

        private void volverBtn_Click(object sender, EventArgs e)
        {

            FormMenu inicio = new FormMenu();
            this.Hide();
            inicio.ShowDialog();
            this.Close();
        
        }

        private void verConsumiblesBtn_Click(object sender, EventArgs e)
        {
            String consultarConsumibles = "SELECT * FROM AEFI.TL_Consumible co, AEFI.TL_Consumible_Por_Estadia cpe WHERE cpe.ID_Estadia = @idEstadia AND cpe.ID_Consumible = co.ID_Consumible ";
            String consultarIdEstadia = "SELECT ID_Estadia FROM AEFI.TL_Estadia e, AEFI.TL_Reserva r, AEFI.TL_Habitacion h WHERE r.ID_Habitacion = h.ID_Habitacion AND e.ID_Reserva = r.ID_Reserva AND h.numero = @numero AND e.Estado = 1 AND h.ID_Hotel =" + Program.idHotel;
            
            
            consumiblesCmbBox.Enabled = true;
            cantidadTxtBox.Enabled = true;
            facturarBtn.Enabled = true;
            
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand(consultarIdEstadia, conexion);
                comando.Parameters.Add(new SqlParameter("@numero", habitacionTxtBox.Text));
                SqlDataReader reader = comando.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    idEstadia = Convert.ToInt32(reader[0]);

                }
                else
                {
                    MessageBox.Show("La habitación no posee una estadía activa", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conexion.Close();
                    this.Hide();
                    FrmRegistrarConsumible r = new FrmRegistrarConsumible();
                    r.ShowDialog();
                    this.Close();
                }
                reader.Close();

                comando = new SqlCommand(consultarConsumibles, conexion);
                comando.Parameters.Add(new SqlParameter("@idEstadia", idEstadia));
                
                        SqlDataAdapter adapter = new SqlDataAdapter(comando);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        consumibleDGV.DataSource = dataTable;
                   
                
                
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

        private void habitacionTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            permitirSoloNumeros(e);

          

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

        private void FrmRegistrarConsumible_Load(object sender, EventArgs e)
        {
            string consumibles = "SELECT DISTINCT Descripcion FROM AEFI.TL_Consumible ";
            try
            {

                conexion.Open();
                SqlCommand comando = new SqlCommand(consumibles, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    consumiblesCmbBox.Items.Add(reader["Descripcion"].ToString());
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

        private void cantidadTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            permitirSoloNumeros(e);
            agregarConsBtn.Enabled = true;

        }

        private void agregarConsBtn_Click(object sender, EventArgs e)
        {

            if (verificarTextBoxNoVacios())
            {
                try
                {
                    conexion.Open();



                    SqlCommand comando = new SqlCommand("AEFI.agregarConsumiblePorEstadia", conexion);
                    comando.Parameters.Add(new SqlParameter("@consumible", consumiblesCmbBox.SelectedItem.ToString()));
                    comando.Parameters.Add(new SqlParameter("@idEstadia", idEstadia));
                    comando.Parameters.Add(new SqlParameter("@cantidad", cantidadTxtBox.Text));
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.ExecuteNonQuery();


                    conexion.Close();

                    this.verConsumiblesBtn_Click(this, e);






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

        }


        private Boolean verificarTextBoxNoVacios()
        {
            bool textBoxNoVacio = false;

            foreach (Control c in this.Controls)
            {

                if (c is TextBox)
                {
                    TextBox textBox = c as TextBox;
                    if (textBox.Text == string.Empty)
                    {
                        return false;
                    }
                    else
                    {
                        textBoxNoVacio = true;
                    }

                }


            }

            return textBoxNoVacio;
        }

        private void consumibleDGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            eliminarBtn.Enabled = true;
            
        }

        private void eliminarBtn_Click(object sender, EventArgs e)
        {

            try
            {
                
                if (consumibleDGV.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in consumibleDGV.SelectedRows)
                    {
                        conexion.Open();
                        SqlCommand comando = new SqlCommand("AEFI.quitarConsumiblePorEstadia", conexion);
                        comando.Parameters.Add(new SqlParameter("@idConsumiblePorEstadia", row.Cells["id_consumible_por_estadia"].Value));
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.ExecuteNonQuery();
                        conexion.Close();
                    }
                }

                this.verConsumiblesBtn_Click(this, e);

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

        private void facturarBtn_Click(object sender, EventArgs e)
        {
               String obtenerTodoConsumoDeEstadia= "SELECT ID_Consumible FROM AEFI.TL_Consumible_Por_Estadia "+
                                                   "WHERE ID_Estadia = @id_estadia";
               String obtenerIDFactura = "SELECT ID_Factura FROM AEFI.TL_Estadia WHERE ID_Estadia = @id_estadia";
               String obtenerReserva = "SELECT ID_Reserva FROM AEFI.TL_Estadia WHERE ID_Estadia = @id_estadia";
               String obtenerRegimen = "SELECT ID_Regimen FROM AEFI.TL_Reserva WHERE ID_Reserva= @id_reserva";
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand(obtenerReserva, conexion);
                comando.Parameters.Add(new SqlParameter("@id_estadia",idEstadia));
                SqlDataReader reader = comando.ExecuteReader();
                reader.Read();
                int id_reserva = Convert.ToInt32(reader[0]);
                reader.Close();

                  //obtengo la factura linkeada a la estadia
                comando = new SqlCommand(obtenerIDFactura, conexion);
                        comando.Parameters.Add(new SqlParameter("@id_estadia", idEstadia));
                         reader = comando.ExecuteReader();
                        reader.Read();
                        int idFactura = Convert.ToInt32(reader[0]);
                        reader.Close();

                //obtengo el regimen.
                 comando = new SqlCommand(obtenerRegimen, conexion);
                        comando.Parameters.Add(new SqlParameter("@id_reserva", id_reserva));
                        reader = comando.ExecuteReader();
                        reader.Read();
                        int id_regimen = Convert.ToInt32(reader[0]);
                        reader.Close();

                //cargo los consumibles.
               comando = new SqlCommand(obtenerTodoConsumoDeEstadia, conexion);
                comando.Parameters.Add(new SqlParameter("@id_estadia",idEstadia));

                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    int id_consumible = Convert.ToInt32(reader[0]);


                    comando = new SqlCommand("AEFI.insertar_item_consumible", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@id_factura", idFactura));
                    comando.Parameters.Add(new SqlParameter("@id_consumible", id_consumible));
                    comando.Parameters.Add(new SqlParameter("@id_regimen", id_regimen));
                    comando.Parameters.Add(new SqlParameter("@id_estadia", idEstadia));
                    comando.ExecuteNonQuery();
                  

                }
                MessageBox.Show("Los items fueron facturados", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


            finally
            {
                conexion.Close();
                this.volverBtn_Click(this, e);
            }
        }


    }
}
