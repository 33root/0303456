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
            VolverButton.Enabled = false;
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
            //txbNumero.Clear();
            txbPiso.Clear();
            txbDpto.Clear();
            //txbCodigoPostal.Clear();
            txbLocalidad.Clear();
            cbTipoDeDocumento.SelectedIndex = 0;
            dtpFecha.Text = DateTime.Today.ToString();
        
        }

        private void CrearButton_Click(object sender, EventArgs e)
        {
            //en construccion, aca tengo que usar un sp y estoy medio verde en eso :S
            //it is done
            try
            {
                conexion.Open();
                SqlCommand comando = null;

                if (x == 0)
                    comando = new SqlCommand("AEFI.insertar_cliente", conexion);
                else if (x == 1)
                    comando = new SqlCommand("AEFI.actualizar_cliente", conexion);
                else if ( x == 2)
                    comando = new SqlCommand("AEFI.insertar_cliente", conexion);
    
                comando.CommandType = CommandType.StoredProcedure;

                if (x == 1)
                {
                    comando.Parameters.Add(new SqlParameter("@ID_Cliente", id_cliente));
                }

                comando.Parameters.Add(new SqlParameter("@Nombre", txbNombre.Text));
                comando.Parameters.Add(new SqlParameter("@Apellido", txbApellido.Text));
                comando.Parameters.Add(new SqlParameter("@ID_Tipo_Documento", cbTipoDeDocumento.Text));
                comando.Parameters.Add(new SqlParameter("@Documento_Numero", txbDocumentoNumero.Text));
                comando.Parameters.Add(new SqlParameter("@Telefono", txbTelefono.Text));
                comando.Parameters.Add(new SqlParameter("@Fecha_Nacimiento", dtpFecha.Text));
                comando.Parameters.Add(new SqlParameter("@Calle", txbDireccion.Text));
                comando.Parameters.Add(new SqlParameter("@Calle_Nro", txbCalle.Text));
                comando.Parameters.Add(new SqlParameter("@PaisOrigen", txbNacionalidad.Text));
                
                if (!String.IsNullOrEmpty(txbPiso.Text))
                    comando.Parameters.Add(new SqlParameter("@Piso", txbPiso.Text));
                if (!String.IsNullOrEmpty(txbDpto.Text))
                    comando.Parameters.Add(new SqlParameter("@Dpto", txbDpto.Text));
                if (!String.IsNullOrEmpty(txbLocalidad.Text))
                    comando.Parameters.Add(new SqlParameter("@Localidad", txbLocalidad.Text));
                if (!String.IsNullOrEmpty(txbTelefono.Text))
                {
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

                    if (x == 2) 
                    {
                        string consultaID = "SELECT ID_Cliente "
                                          + "FROM AEFI.TL_Cliente "
                                          + "WHERE Mail = " + txbMail.ToString();//ya que no hay 2 mails iguales

                        SqlCommand comandoId = new SqlCommand(consultaID,conexion);
                        SqlDataReader reader2 = comandoId.ExecuteReader();
                        reader2.Read();
                        int id = Convert.ToInt32(reader2["ID_Cliente"]);
                        
                       /* SqlDataAdapter adapter2 = new SqlDataAdapter(comandoId);
                        string id = adapter2.ToString();*/

                        //conexion.Close();

                        FormGenerarReserva r = new FormGenerarReserva(id);
                        this.Hide();
                        r.ShowDialog();
                        this.Close();
                    }

                }
                else
                    throw new Excepciones("No se ingreso ningun mail");

                comando.ExecuteNonQuery();
                MessageBox.Show("Operacion Completada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarButton_Click(sender, e);
                VolverButton.Enabled = true;

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
    }
}
