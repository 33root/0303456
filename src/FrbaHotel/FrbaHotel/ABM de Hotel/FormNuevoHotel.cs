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

namespace FrbaHotel.ABM_de_Hotel
{
    public partial class FormNuevoHotel : Form
    {
        SqlConnection conexion = BaseDeDatos.conectar();
        int x = 0;
      

        public FormNuevoHotel()
        {
            InitializeComponent();
        }

        public FormNuevoHotel(int cod, DataGridViewCellCollection cells)
        {
            this.x = cod;
            InitializeComponent();
            lbIdHotel.Text = cells[0].Value.ToString();
            tbNombre.Text = cells[1].Value.ToString();
            tbMail.Text = cells[5].Value.ToString();
            tbTelefono.Text = cells[6].Value.ToString();
            tbCantEstrellas.Text = cells[2].Value.ToString();
            tbCalle.Text = cells[7].Value.ToString();
            tbCiudad.Text = cells[3].Value.ToString();
            tbPais.Text = cells[4].Value.ToString();
            tbNroCalle.Text = cells[9].Value.ToString();
            dtpFecha.Text = cells[8].Value.ToString();
            //cbRegimen.Text = cells[8].Value.ToString();
            btnCrear.Text = "Actualizar";
        
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormHotel_Load(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            if (x == 0)
            {
                FormMenu inicio = new FormMenu();
                this.Hide();
                inicio.ShowDialog();
                this.Close();
            }
            else if (x == 1)
            {
                FormListaDeHoteles listado = new FormListaDeHoteles();
                this.Hide();
                listado.ShowDialog();
                this.Close();
            }
        }

        private void labelDireccion_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {

            try
            {
                conexion.Open();
                SqlCommand comando = null;

                if (x == 0)
                    comando = new SqlCommand("AEFI.crear_Hotel", conexion);
                else if (x == 1)
                    comando = new SqlCommand("AEFI.actualizar_Hotel", conexion);


                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@ID_Hotel", lbIdHotel.Text));
                comando.Parameters.Add(new SqlParameter("@Nombre", tbNombre.Text));
                comando.Parameters.Add(new SqlParameter("@Mail", tbMail.Text));
                comando.Parameters.Add(new SqlParameter("@Telefono", tbTelefono.Text));
                //comando.Parameters.Add(new SqlParameter("@Regimen", cbRegimen.Text));
                comando.Parameters.Add(new SqlParameter("@Cantidad_Estrellas", tbCantEstrellas.Text));
                comando.Parameters.Add(new SqlParameter("@Fecha_Creacion", dtpFecha.Text));
                comando.Parameters.Add(new SqlParameter("@Calle", tbCalle.Text));
                comando.Parameters.Add(new SqlParameter("@Ciudad", tbCiudad.Text));
                comando.Parameters.Add(new SqlParameter("@Pais", tbPais.Text));
                comando.Parameters.Add(new SqlParameter("@NroCalle", tbNroCalle.Text));
                

                SqlDataReader dr = comando.ExecuteReader();

                MessageBox.Show("El Hotel se creo satisfactoriamente", "Hotel Creado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Excepciones exc)
            {
                MessageBox.Show(exc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void tbIdHotel_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
