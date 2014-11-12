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

namespace FrbaHotel.Facturar_Estadía
{
    public partial class FrmTarjeta : Form
    {


        SqlConnection conexion = BaseDeDatos.conectar();


        public FrmTarjeta()
        {
            InitializeComponent();
        }

        private void cancelarBtn_Click(object sender, EventArgs e)
        {
            FormMenu inicio = new FormMenu();
            this.Hide();
            inicio.ShowDialog();
            this.Close();
        }

        private void aceptarBtn_Click(object sender, EventArgs e)
        {
          

            if (String.IsNullOrEmpty(numeroTxtBox.Text))
            {
                MessageBox.Show("Debe insertar un número de tarjeta", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else
            {
                try
                {
                    conexion.Open();

                    SqlCommand comando = new SqlCommand("AEFI.insertar_nueva_Tarjeta", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@numero", Convert.ToInt32(numeroTxtBox.Text)));
                    comando.Parameters.Add(new SqlParameter("@fecha", vtoCalendar.SelectionStart));
                    SqlParameter id1 = new SqlParameter("@id_factura", 0);
                    id1.Direction = ParameterDirection.Output;
                    comando.Parameters.Add(id1);
                    comando.ExecuteNonQuery();

                    

                    MessageBox.Show("La tarjeta ha sido generada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ;
                    this.Close();

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

    }

}
