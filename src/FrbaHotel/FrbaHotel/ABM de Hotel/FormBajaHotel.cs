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
    public partial class FormBajaHotel : Form
    {

        SqlConnection conexion = BaseDeDatos.conectar();
       


        public FormBajaHotel()
        {
            InitializeComponent();
        }

        public FormBajaHotel(DataGridViewCellCollection cells)
        {
            InitializeComponent();
            lbNombre.Text = cells[1].Value.ToString();
            lbIdHotel.Text = cells[0].Value.ToString();
        }


        private void BajaHotel_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            FormMenu menu = new FormMenu();
            this.Hide();
            menu.ShowDialog();
            this.Close();

            /* esto se deberia adaptar segun el loguin del admin y los hoteles q administra (al que quiere modificar)*/

        }

        private void btnBaja_Click(object sender, EventArgs e)
        {

            try
            {


                conexion.Open();
                SqlCommand comando = null;

                comando = new SqlCommand("AEFI.baja_Hotel", conexion);

                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@ID_Hotel", lbIdHotel.Text));
                comando.Parameters.Add(new SqlParameter("@Fecha_Inicio", dtpInicio.Value));
                comando.Parameters.Add(new SqlParameter("@Fecha_Fin", dtpFin.Value));
                comando.Parameters.Add(new SqlParameter("@Descripcion", rtbMotivos.Text));

                SqlDataReader dr = comando.ExecuteReader();

                MessageBox.Show("El Hotel se dio de baja satisfactoriamente", "Baja Hotel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException exc)
            {
               
                    MessageBox.Show("El Hotel no se puede dar de Baja, revise que no existan Reservas o Estadias en el Periodo de Baja o que ya no este dado de Baja", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
               
            finally
            {
                conexion.Close();
            }

            FormListaDeHoteles listado = new FormListaDeHoteles();
            this.Hide();
            listado.ShowDialog();
            this.Close();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

    }
}
