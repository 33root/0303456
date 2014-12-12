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

        private void FormNuevoHotel_Load(object sender, EventArgs e)
        {

        }

        public FormNuevoHotel(int cod, DataGridViewCellCollection cells)
        {
            this.x = cod;
            InitializeComponent();
            lbIdHotel.Text = cells[0].Value.ToString();
            tbNombre.Text = cells[1].Value.ToString();
            tbMail.Text = cells[5].Value.ToString();
            tbTelefono.Text = cells[6].Value.ToString();
            tbCalle.Text = cells[7].Value.ToString();
            tbNroCalle.Text = cells[9].Value.ToString();
            tbCantEstrellas.Text = cells[2].Value.ToString();
            nudRecarga.Text = cells[10].Value.ToString();
            tbCiudad.Text = cells[3].Value.ToString();
            tbPais.Text = cells[4].Value.ToString();

            btnCrear.Text = "Actualizar";
        
        }


      

        private void btnCrear_Click(object sender, EventArgs e)
        {


            if (verificarTextBoxNoVacios())
            {

                conexion.Open();

                if (x == 0)
                {
                    string consulta = "Select * From AEFI.TL_Hotel h Where h.Nombre = " + BaseDeDatos.agregarApostrofos(tbNombre.Text.ToString());
                    string consultaMail = "Select * From AEFI.TL_Hotel h Where h.Mail = " + BaseDeDatos.agregarApostrofos(tbMail.Text.ToString());                 

                    SqlCommand comando2 = new SqlCommand(consulta, conexion);
                    SqlCommand comandoMail = new SqlCommand(consultaMail, conexion);
                    SqlDataReader reader = comando2.ExecuteReader();
                    SqlDataReader readerMail = comandoMail.ExecuteReader();

                    if (reader.HasRows)
                    {

                        MessageBox.Show("Ya existe un Hotel con este Nombre ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        conexion.Close();

                    }
                    else
                    {
                        if (readerMail.HasRows)
                        {
                            MessageBox.Show("Ya existe un Hotel con este Mail ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            conexion.Close();
                        }
                        else
                        {
                            MetodoCrear();
                        }

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
                    comando = new SqlCommand("AEFI.crear_Hotel", conexion);
                else if (x == 1)
                    comando = new SqlCommand("AEFI.actualizar_Hotel", conexion);


                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@ID_Hotel", lbIdHotel.Text));
                comando.Parameters.Add(new SqlParameter("@Nombre", tbNombre.Text));
                comando.Parameters.Add(new SqlParameter("@Mail", tbMail.Text));
                comando.Parameters.Add(new SqlParameter("@Telefono", tbTelefono.Text));
               
                comando.Parameters.Add(new SqlParameter("@Cantidad_Estrellas", tbCantEstrellas.Text));
                comando.Parameters.Add(new SqlParameter("@Fecha_Creacion", Program.fecha));
                comando.Parameters.Add(new SqlParameter("@NroCalle", tbNroCalle.Text));
                comando.Parameters.Add(new SqlParameter("@Calle", tbCalle.Text));
                comando.Parameters.Add(new SqlParameter("@Ciudad", tbCiudad.Text));
                comando.Parameters.Add(new SqlParameter("@Pais", tbPais.Text));
                comando.Parameters.Add(new SqlParameter("@Recarga_Estrellas", nudRecarga.Text));


                SqlDataReader dr = comando.ExecuteReader();

                if (x == 0)
                {
                    MessageBox.Show("El Hotel se creo satisfactoriamente", "Hotel Creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (x == 1)
                {
                    MessageBox.Show("El Hotel se actualizo correctamente", "Habitacion Creada", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                FormListaDeHoteles listado = new FormListaDeHoteles();
                this.Hide();
                listado.ShowDialog();
                this.Close();
            }
        }

        private void tbTelefono_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbNroCalle_KeyPress(object sender, KeyPressEventArgs e)
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
        }
    }

