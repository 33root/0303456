using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Menu;
using FrbaHotel.Facturar_Estadia;
using System.Data.SqlClient;

namespace FrbaHotel.Facturar_Estadía
{
    public partial class FrmTarjeta : Form
    {
        int idCliente;
        FrmFacturar formFacturar;
        SqlConnection conexion = BaseDeDatos.conectar();


        public FrmTarjeta(int cliente, FrmFacturar facturar)
        {
            idCliente = cliente;
            formFacturar = facturar;
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
             
                    conexion.Open();

                    SqlCommand comando = new SqlCommand("AEFI.insertar_nueva_Tarjeta", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    int numeroTarjeta = Convert.ToInt32(numeroTxtBox.Text);
                    formFacturar.setearNumeroTarjeta(numeroTarjeta);
                    comando.Parameters.Add(new SqlParameter("@numero", numeroTarjeta));
                    comando.Parameters.Add(new SqlParameter("@fecha", vtoCalendar.SelectionStart));
                    comando.Parameters.Add(new SqlParameter("@id_Cliente", idCliente));
             
                    comando.ExecuteNonQuery();

                    conexion.Close();

                    MessageBox.Show("La tarjeta ha sido generada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    

                   // this.Close();
                    this.Hide();
            }

           
        }

        private void numeroTxtBox_KeyPress(object sender, KeyPressEventArgs e)
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



    }

}
