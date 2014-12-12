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
using FrbaHotel.Generar_Modificar_Reserva;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class FormClienteNuevo : Form
    {
        public FormClienteNuevo()
        {
            InitializeComponent();
        }

        SqlConnection conexion = BaseDeDatos.conectar();
        int x = 0; //0 cuando entran directamente al form, 1 cuando entran desde el listado con un seleccionado
        string usu = "";
        string con = "";
        string id_cliente;
        int cantDeClientesAntes;
        

        public FormClienteNuevo(int cod, DataGridViewCellCollection cells)
        {
            this.x = cod;
            InitializeComponent();

            id_cliente = cells[0].Value.ToString();
            
            txbNombre.Text = cells[1].Value.ToString();
            txbApellido.Text = cells[2].Value.ToString();
            cbTipoDeDocumento.Text = cells[3].Value.ToString();
            txbDocumentoNumero.Text = cells[4].Value.ToString();
            txbMail.Text = cells[5].Value.ToString();
            txbTelefono.Text = cells[6].Value.ToString();
            dtpFecha.Text = cells[7].Value.ToString();
            txbDireccion.Text = cells[8].Value.ToString();
            //txbNumero.Text = cells[9].Value.ToString();
            txbPiso.Text = cells[10].Value.ToString();
            txbDpto.Text = cells[11].Value.ToString();
            //txbCodigoPostal.Text = cells[12].Value.ToString();
            txbLocalidad.Text = cells[12].Value.ToString();
            CrearButton.Text = "Actualizar";
        }

        public FormClienteNuevo(int id, string u, string c)
        {
            this.x = id;
            this.usu = u;
            this.con = c;
            InitializeComponent();
            this.ControlBox = false;
            VolverButton.Enabled = true;
        }

        public FormClienteNuevo(int bandera)
        {
            this.x = bandera;
            InitializeComponent();
            this.ControlBox = false;
            VolverButton.Enabled = false;
        }

        private void VolverButton_Click(object sender, EventArgs e)
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
                FormBuscadorDeClientes listado = new FormBuscadorDeClientes();
                this.Hide();
                listado.ShowDialog();
                this.Close();
            }
        }

        private void FormClienteNuevo_Load(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                string consulta = "SELECT Descripcion FROM AEFI.TL_Tipo_Documento ORDER BY ID_Tipo_Documento";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                    cbTipoDeDocumento.Items.Add(reader[0]);
                reader.Close();
                cbTipoDeDocumento.SelectedIndex = 0;

                string cantidadDeClientes = "SELECT COUNT(ID_Cliente) " +
                                                "FROM AEFI.TL_Cliente ";

                SqlCommand comandoCantidad = new SqlCommand(cantidadDeClientes, conexion);
                SqlDataReader readerCantidad = comandoCantidad.ExecuteReader();
                readerCantidad.Read();
                cantDeClientesAntes = Convert.ToInt32(readerCantidad[0]);
            }
            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }

            dtpFecha.Text = DateTime.Today.ToString();
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            txbNombre.Clear();
            txbApellido.Clear();
            txbDocumentoNumero.Clear();
            txbMail.Clear();
            txbTelefono.Clear();
            txbDireccion.Clear();
            txbNumero.Clear();
            txbPiso.Clear();
            txbDpto.Clear();
            txbLocalidad.Clear();
            txbPaisOrigen.Clear();
            cbTipoDeDocumento.SelectedIndex = 0;
            dtpFecha.Text = DateTime.Today.ToString();
        
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
        private void CrearButton_Click(object sender, EventArgs e)
        {
            if (verificarTextBoxNoVacios())
            {
                
                try
                {
                    conexion.Open();

                    if (x == 0)
                    {

                       SqlCommand comando = new SqlCommand("AEFI.insertar_cliente", conexion);
                       comando.CommandType = CommandType.StoredProcedure;
                        aniadirParametros(comando);
                    }
                    else if (x == 1)
                    {
                        SqlCommand comando = new SqlCommand("AEFI.actualizar_cliente", conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@ID_Cliente", id_cliente));
                        aniadirParametros(comando);
                    }
                    else if (x == 2)
                    {
                     SqlCommand comando = new SqlCommand("AEFI.insertar_cliente", conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        aniadirParametros(comando);

                        string consultaID = "SELECT ID_Cliente "
                                          + "FROM AEFI.TL_Cliente "
                                          + "WHERE Mail = " + BaseDeDatos.agregarApostrofos(txbMail.Text);//ya que no hay 2 mails iguales

                        SqlCommand comandoId = new SqlCommand(consultaID, conexion);
                        SqlDataReader readerId = comandoId.ExecuteReader();
                        readerId.Read();
                        int id = Convert.ToInt32(readerId[0]);
                        readerId.Close();
                        

                        string cantidadDeClientes = "SELECT COUNT(ID_Cliente) " +
                                                    "FROM AEFI.TL_Cliente ";
                        
                        //perdon Esme la costumbre gana, tengo que crear otro commando :P
                        SqlCommand comandoCant = new SqlCommand(cantidadDeClientes, conexion);
                        SqlDataReader readerCant = comandoCant.ExecuteReader();
                        readerCant.Read();
                        int cantDeClientesDespues = Convert.ToInt32(readerCant[0]);
                        
                        if (cantDeClientesAntes != cantDeClientesDespues)
                        {//significa que si se ingreso un cliente
                            FormGenerarReserva r = new FormGenerarReserva(id);
                            this.Hide();
                            r.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            FormMenu m = new FormMenu();
                            this.Hide();
                            m.ShowDialog();
                            this.Close();
                        }
                    }

                }
                catch (Excepciones exc)
                {
                    MessageBox.Show(exc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conexion.Close();

                    FormMenu m = new FormMenu();
                    this.Hide();
                    m.ShowDialog();
                    this.Close();

                }
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void aniadirParametros(SqlCommand comando)
        {
            try
            {
                comando.Parameters.Add(new SqlParameter("@Nombre", txbNombre.Text));
                comando.Parameters.Add(new SqlParameter("@Apellido", txbApellido.Text));
                comando.Parameters.Add(new SqlParameter("@ID_Tipo_Documento", Convert.ToString(cbTipoDeDocumento.Text)));
                comando.Parameters.Add(new SqlParameter("@Documento_Numero", Convert.ToInt32(txbDocumentoNumero.Text)));
                comando.Parameters.Add(new SqlParameter("@Telefono", txbTelefono.Text));
                comando.Parameters.Add(new SqlParameter("@Fecha_Nacimiento", dtpFecha.Text));
                comando.Parameters.Add(new SqlParameter("@Calle", txbDireccion.Text));
                comando.Parameters.Add(new SqlParameter("@Calle_Nro", txbNumero.Text));
                comando.Parameters.Add(new SqlParameter("@PaisOrigen", txbPaisOrigen.Text));

                comando.Parameters.Add(new SqlParameter("@Piso", txbPiso.Text));

                comando.Parameters.Add(new SqlParameter("@Dpto", txbDpto.Text));

                comando.Parameters.Add(new SqlParameter("@Localidad", txbLocalidad.Text));

                if (x != 1)
                {
                    SqlCommand comandoTelefono = new SqlCommand("SELECT * FROM AEFI.TL_cliente " +
                                    "WHERE Mail = @Mail", conexion);
                    comandoTelefono.Parameters.Add(new SqlParameter("@Mail", txbMail.Text));
                    SqlDataReader reader = comandoTelefono.ExecuteReader();
                    if (reader.HasRows)
                        throw new Excepciones("El mail ya existe");
                    reader.Close();
                }
                comando.Parameters.Add(new SqlParameter("@Mail", txbMail.Text));
                comando.ExecuteNonQuery();
                MessageBox.Show("Operacion Completada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Excepciones exc)
            {
                MessageBox.Show(exc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void txbTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            permitirSoloNumeros(e);
        }

        private void txbCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            permitirSoloNumeros(e);
        }

        private void txbPiso_KeyPress(object sender, KeyPressEventArgs e)
        {
            permitirSoloNumeros(e);
        }

        private void txbDocumentoNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            permitirSoloNumeros(e);
        }

        private void txbNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            permitirSoloLetras(e);
        }

        private void txbApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            permitirSoloLetras(e);
        }

        private void txbDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            permitirSoloLetras(e);
        }

        private void txbLocalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            permitirSoloLetras(e);
        }

        private void txbNacionalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            permitirSoloLetras(e);
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

        private static void permitirSoloLetras(KeyPressEventArgs e) 
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
