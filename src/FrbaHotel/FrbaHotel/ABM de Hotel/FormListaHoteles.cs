using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaHotel.Menu;




namespace FrbaHotel.ABM_de_Hotel
{
    public partial class FormListaDeHoteles : Form
    {                      


        SqlConnection conexion = BaseDeDatos.conectar();

        public FormListaDeHoteles()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            FormMenu menu = new FormMenu();
            this.Hide();
            menu.ShowDialog();
            this.Close();
        }

        private void dgvHoteles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormListaDeHoteles_Load(object sender, EventArgs e)
        {

        }
        
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            conexion.Open();


            string Query = "SELECT DISTINCT h.ID_Hotel, h.Nombre, h.Cantidad_Estrellas, h.Ciudad, h.Pais, h.Mail, h.Telefono, h.Calle, h.Fecha_Creacion, h.Nro_Calle, h.Recarga_Estrellas, h.Estado FROM AEFI.TL_Hotel h, AEFI.TL_Usuario_Por_Hotel uph, AEFI.TL_Usuario u " +
                            "WHERE h.Cantidad_Estrellas IS NOT NULL " +
                            "AND h.ID_Hotel = uph.ID_Hotel AND uph.ID_Usuario = u.ID_Usuario " +
                            "AND u.ID_Usuario = " + Program.idUsuario;




            if (!String.IsNullOrEmpty(tbCantEstrellas.Text))
            {
                String aux = BaseDeDatos.agregarApostrofos(tbCantEstrellas.Text);
                Query = Query + " AND h.Cantidad_Estrellas LIKE " + aux;
            }

            if (!String.IsNullOrEmpty(tbCiudad.Text))
            {
                String aux = BaseDeDatos.agregarApostrofos("%" + tbCiudad.Text + "%");
                Query = Query + " AND h.Ciudad LIKE " + aux;
            }

            if (!String.IsNullOrEmpty(tbPais.Text))
            {
                String aux = BaseDeDatos.agregarApostrofos("%" + tbPais.Text + "%");
                Query = Query + " AND h.Pais LIKE " + aux;
            }

            if (!String.IsNullOrEmpty(tbNombre.Text))
            {
                String aux = BaseDeDatos.agregarApostrofos("%" + tbNombre.Text + "%");
                Query = Query + " AND h.Nombre LIKE " + aux;
            }



            SqlDataAdapter adapter = new SqlDataAdapter(Query, conexion);
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            dgvHoteles.DataSource = tabla;


            conexion.Close();

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvHoteles.DataSource = null;
            tbNombre.Clear();
            tbCantEstrellas.Clear();
            tbCiudad.Clear();
            tbPais.Clear();
        
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvHoteles.SelectedRows)
            {
                FormNuevoHotel alta = new FormNuevoHotel(1, row.Cells);
                this.Hide();
                alta.ShowDialog();
                this.Close();
            }
        }

        private void btnDesabilitar_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dgvHoteles.SelectedRows)
            {
                FormBajaHotel baja = new FormBajaHotel(row.Cells);
                this.Hide();
                baja.ShowDialog();
               
            }
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            
          try
            {
                conexion.Open();
                foreach (DataGridViewRow row in dgvHoteles.SelectedRows)
                {
                    string consulta = "SELECT bh.ID_Hotel FROM AEFI.TL_Baja_Hotel bh " +
                                      "WHERE DATEDIFF(Day, Fecha_Fin, GETDATE()) = 0 " +
                                      "AND DATEDIFF(MONTH, Fecha_Fin, GETDATE()) = 0 " +
                                      "AND DATEDIFF(Year, Fecha_Fin, GETDATE()) = 0 " +
                                      "AND bh.ID_Hotel = " + BaseDeDatos.agregarApostrofos(row.Cells[0].Value.ToString());



                    SqlCommand comando2 = new SqlCommand(consulta, conexion);
                    SqlDataReader reader = comando2.ExecuteReader();

                    if (reader.HasRows)
                    {

                        SqlCommand comando = new SqlCommand(consulta, conexion);
                        SqlDataReader reader2 = comando.ExecuteReader();
                        reader.Read();
                        int cod = Convert.ToInt32(reader[0]);
                        reader.Close();
                        consulta = "UPDATE AEFI.TL_Hotel SET Estado = 'Habilitado' WHERE ID_Hotel = " + cod;
                        comando2 = new SqlCommand(consulta, conexion);
                        comando2.ExecuteNonQuery();
                        MessageBox.Show("Hotel Habilitada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string consulta2 = "select Year(bh.Fecha_Fin) " +
                                           "from AEFI.TL_Baja_Hotel bh " +
                                            "where bh.ID_Hotel = " + BaseDeDatos.agregarApostrofos(row.Cells[0].Value.ToString());

                        string consulta3 = "select MONTH(bh.Fecha_Fin) " +
                                           "from AEFI.TL_Baja_Hotel bh " +
                                            "where bh.ID_Hotel = " + BaseDeDatos.agregarApostrofos(row.Cells[0].Value.ToString());

                        string consulta4 = "select DAY(bh.Fecha_Fin) " +
                                           "from AEFI.TL_Baja_Hotel bh " +
                                            "where bh.ID_Hotel = " + BaseDeDatos.agregarApostrofos(row.Cells[0].Value.ToString());
                    SqlCommand comand = new SqlCommand(consulta2, conexion);
                    SqlDataReader reader3 = comand.ExecuteReader();

                         SqlCommand comand2 = new SqlCommand(consulta3, conexion);
                    SqlDataReader reader4 = comand2.ExecuteReader();

                         SqlCommand comand3 = new SqlCommand(consulta4, conexion);
                    SqlDataReader reader5 = comand3.ExecuteReader();

                    reader3.Read();
                    reader4.Read();
                    reader5.Read();

                        MessageBox.Show("No se puede Habilitar el Hotel, la fecha estipulada de reahabilitacion es: " + reader3[0].ToString() + "/" + reader4[0].ToString() + "/" + reader5[0].ToString() , "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        reader3.Close();
                        reader4.Close();
                        reader5.Close();
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
            btnFiltrar_Click(sender, e);
        
        }
        
        

        private void tbCantEstrellas_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbCantEstrellas_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbCiudad_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbPais_KeyPress(object sender, KeyPressEventArgs e)
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

       
    }
}
