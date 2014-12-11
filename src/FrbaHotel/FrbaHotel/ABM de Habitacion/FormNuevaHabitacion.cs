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


namespace FrbaHotel.ABM_de_Habitacion
{
    public partial class FormNuevaHabitacion : Form
    {

        SqlConnection conexion = BaseDeDatos.conectar();
        int x = 0;

        public FormNuevaHabitacion()
        {
            InitializeComponent();
            cmbVista.Items.Add("S");
            cmbVista.Items.Add("N");
            lbIDHotel.Text = Program.idHotel.ToString();
            cmbTHabitacion.Items.Add("");

            try
            {
                conexion.Open();
                string consulta = "SELECT descripcion FROM AEFI.TL_Tipo_Habitacion ORDER BY ID_Tipo_Habitacion ";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                    cmbTHabitacion.Items.Add(reader[0]);
                reader.Close();
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

        public FormNuevaHabitacion(int cod, DataGridViewCellCollection cells)
        {
            this.x = cod;
            InitializeComponent();

            lbIDHabitacion.Text = cells[0].Value.ToString();
            lbIDHotel.Text = cells[1].Value.ToString();
            tbNumero.Text = cells[2].Value.ToString();
            tbPiso.Text = cells[3].Value.ToString();
            cmbVista.Text = cells[4].Value.ToString();
            cmbTHabitacion.Hide();
            label7.Hide();
            btnCrear.Text = "Actualizar";

    
            cmbVista.Items.Add("S");
            cmbVista.Items.Add("N");
            

        }               

        private void tbNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            

            if (verificarTextBoxNoVacios())
            {

                conexion.Open();
                if (x == 0)
                {
                    string consulta = "Select * From AEFI.TL_Habitacion h Where h.Numero = " + BaseDeDatos.agregarApostrofos(tbNumero.Text.ToString());

                    SqlCommand comando2 = new SqlCommand(consulta, conexion);
                    SqlDataReader reader = comando2.ExecuteReader();

                    if (reader.HasRows)
                    {

                        MessageBox.Show("Ya existe una Habitacion con este Numero ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        conexion.Close();

                    }
                    else
                    {

                        MetodoCrear();

                    }
                }
                else
                {
                    if (x == 1)
                    {
                        MetodoCrear();
                    }
                }

                
            }
            else
            {
                MessageBox.Show("Todos los campos deben ser rellenados ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void MetodoCrear()
        {
            try
            {
        
                SqlCommand comando = null;


                if (x == 0)
                    comando = new SqlCommand("AEFI.crear_Habitacion", conexion);

                else if (x == 1)
                    comando = new SqlCommand("AEFI.actualizar_Habitacion", conexion);


                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@ID_Hotel", lbIDHotel.Text));
                comando.Parameters.Add(new SqlParameter("@ID_Habitacion", lbIDHabitacion.Text));
                comando.Parameters.Add(new SqlParameter("@Numero", tbNumero.Text));
                comando.Parameters.Add(new SqlParameter("@Piso", tbPiso.Text));
                comando.Parameters.Add(new SqlParameter("@Vista", cmbVista.Text));
                comando.Parameters.Add(new SqlParameter("@Tipo_habitacion", cmbTHabitacion.Text));




                SqlDataReader dr = comando.ExecuteReader();

                if (x == 0)
                {
                    MessageBox.Show("La Habitacion se creo satisfactoriamente", "Habitacion Creada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (x == 1)
                {
                    MessageBox.Show("La Habitacion se actualizo correctamente", "Habitacion Creada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

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
                FormListaHabitacion listado = new FormListaHabitacion();
                this.Hide();
                listado.ShowDialog();
                this.Close();
            }
        }

        private void tbPiso_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbVista_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbTHabitacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rtbDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormNuevaHabitacion_Load(object sender, EventArgs e)
        {

        }

        private void tbNumero_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbPiso_KeyPress(object sender, KeyPressEventArgs e)
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

