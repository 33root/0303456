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
using FrbaHotel.ABM_de_Cliente;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class FormGenerarReserva : Form
    {

        SqlConnection conexion = BaseDeDatos.conectar();
        int id_habitacion;
        int idTipoHabitacion;
        int idCliente;
        string flag;
        string mail;
        int idReservaAModificar;

        public FormGenerarReserva()
        {
            InitializeComponent();
        }

        public FormGenerarReserva(int i)
        {
            InitializeComponent();
            idCliente = i;
            flag = "TeAbrieronDespuesDeCrearUnCliente";
        }

        public FormGenerarReserva(int idCliente2,int id, DataGridViewCellCollection cells) 
        {
            InitializeComponent();
            flag = "TeAbrieronDesdeModificarReserva";
            idReservaAModificar = id;
            idCliente = idCliente2;
            dtpDesde.Value = Convert.ToDateTime(cells[0].Value);
            txbCantidadDeHuespedes.Text = cells[1].Value.ToString();
            txbCantidadDeNoches.Text = cells[2].Value.ToString();

            ingresarButton.Text = "Modificar";
        }



     

        private void checkearDisponibilidadButton_Click(object sender, EventArgs e)
        {
            string consultaDisponibilidadDeLaReserva = "SELECT r.ID_Reserva, r.Fecha_Desde, r.Cantidad_Huespedes, r.Cantidad_Noches, e.ID_Regimen, h.ID_Habitacion, r.ID_Cliente " +
                                                        "FROM AEFI.TL_Reserva r, AEFI.TL_Regimen e, AEFI.TL_Habitacion h  " +
                                                        "WHERE r.Fecha_Desde = @Fecha_Desde AND r.ID_Cliente = @ID_Cliente AND r.Cantidad_Huespedes = @Cantidad_Huespedes " +
                                                        "AND r.Cantidad_Noches = @Cantidad_Noches AND r.ID_Regimen = e.ID_Regimen  AND h.ID_Hotel =" + Program.idHotel;
                                                              

            string consultaCantidadDeHuespedesParaLaHabitacion = "SELECT Cantidad_Huespedes_Total "
                                                               + "FROM AEFI.TL_Tipo_Habitacion "
                                                               + "WHERE Cantidad_Huespedes_Total >= @Cantidad_Huespedes_Total AND Descripcion = @Descripcion ";

            string consultaDisponibilidadDeLaHabitacion = "SELECT h.ID_Habitacion, h.Disponible, t.Descripcion "
                                                        + "FROM AEFI.TL_Habitacion h, AEFI.TL_Tipo_Habitacion t "
                                                        + "WHERE h.ID_Tipo_Habitacion = t.ID_Tipo_Habitacion AND t.ID_Tipo_Habitacion = @ID_Tipo_Habitacion AND h.Disponible = 'Si' ";

            try
            {
                conexion.Open();

                SqlCommand comando5 = new SqlCommand(consultaDisponibilidadDeLaHabitacion, conexion);
                comando5.Parameters.Add(new SqlParameter("@ID_Tipo_Habitacion", cbTipoDeHabitacion.SelectedItem.ToString()));
                SqlDataReader reader5 = comando5.ExecuteReader();


                SqlCommand comando = new SqlCommand(consultaDisponibilidadDeLaReserva, conexion);
                comando.Parameters.Add(new SqlParameter("@Fecha_Desde", dtpDesde.Value.Date));
                comando.Parameters.Add(new SqlParameter("@Cantidad_Huespedes", txbCantidadDeHuespedes.ToString()));
                comando.Parameters.Add(new SqlParameter("@Cantidad_Noches", txbCantidadDeNoches.ToString()));
                comando.Parameters.Add(new SqlParameter("@ID_Cliente", Program.idUsuario));
                
                SqlDataReader reader = comando.ExecuteReader();

                
                if (reader.HasRows)
                {
                    throw new Excepciones("Ya existe una reserva con los mismos datos");
                }

                if (reader5.HasRows)
                {
                    throw new Excepciones("No hay habitaciones disponibles");
                }

                if ((cbTipoDeRegimen.SelectedItem.ToString() != "Pension Completa") || (cbTipoDeRegimen.SelectedItem.ToString() != "Media Pensión")
                    || (cbTipoDeRegimen.SelectedItem.ToString() != "All Inclusive moderado") || (cbTipoDeRegimen.SelectedItem.ToString() != "All inclusive"))
                {
                    if (Program.idUsuario != 0)
                    {
                        
                        string consulta = "SELECT h.ID_Habitacion, h.Numero, r.Descripcion, r.Precio_Base "
                                         + "FROM AEFI.TL_Regimen r, AEFI.TL_Regimen_Por_Hotel p, AEFI.TL_Habitacion h, AEFI.TL_Tipo_Habitacion th "
                                         + "WHERE p.ID_Hotel = " + BaseDeDatos.agregarApostrofos(Program.idHotel.ToString()) + " AND r.ID_Regimen = p.ID_Regimen "
                                         + " AND h.ID_Hotel = p.ID_Hotel AND h.ID_Tipo_Habitacion = th.ID_Tipo_Habitacion AND th.Descripcion = " + BaseDeDatos.agregarApostrofos(cbTipoDeHabitacion.SelectedItem.ToString());


                        
                        DataTable tabla = new DataTable();
                        SqlCommand comando2 = new SqlCommand(consulta, conexion);
                        SqlDataAdapter adapter = new SqlDataAdapter(comando2);
                        adapter.Fill(tabla);
                        dataGridView1.DataSource = tabla;
                    }
                    else 
                    {
                        
                        string consulta = "SELECT o.Nombre, h.ID_Habitacion, h.Numero, r.Descripcion, r.Precio_Base "
                                         + "FROM AEFI.TL_Regimen r, AEFI.TL_Regimen_Por_Hotel p, AEFI.TL_Habitacion h, AEFI.TL_Tipo_Habitacion th, AEFI.TL_Hotel o "
                                         + "WHERE p.ID_Hotel = o.ID_Hotel AND r.ID_Regimen = p.ID_Regimen "
                                         + " AND h.ID_Hotel = p.ID_Hotel AND h.ID_Tipo_Habitacion = th.ID_Tipo_Habitacion AND th.Descripcion = " + BaseDeDatos.agregarApostrofos(cbTipoDeHabitacion.SelectedItem.ToString());


                        
                        DataTable tabla = new DataTable();
                        SqlCommand comando2 = new SqlCommand(consulta, conexion);
                        SqlDataAdapter adapter = new SqlDataAdapter(comando2);
                        adapter.Fill(tabla);
                        dataGridView1.DataSource = tabla;
                    }

                }

                comando = new SqlCommand(consultaCantidadDeHuespedesParaLaHabitacion, conexion);
                comando.Parameters.Add(new SqlParameter("@Cantidad_Huespedes_Total", txbCantidadDeHuespedes.Text));
                comando.Parameters.Add(new SqlParameter("@Descripcion",cbTipoDeHabitacion.SelectedItem.ToString()));
                reader = comando.ExecuteReader();

                if(!(reader.HasRows)){
                    
                    throw new Excepciones("El tipo de habitacion elegido no tiene la capacidad que usted eligio de huespedes");
                } else
                    {
                        MessageBox.Show("Hay disponibilidad");   
                    }
            }

            catch (Excepciones exc)
            {
                MessageBox.Show(exc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }
        }


        private void aniadirParametroRegimen(SqlCommand comando)
        {
            switch (cbTipoDeRegimen.SelectedItem.ToString())
            {
                case "Pension Completa":
                    comando.Parameters.Add(new SqlParameter("@ID_Regimen", 1));
                    break;
                case "Media Pensión":
                    comando.Parameters.Add(new SqlParameter("@ID_Regimen", 2));
                    break;
                case "All Inclusive moderado":
                    comando.Parameters.Add(new SqlParameter("@ID_Regimen", 3));
                    break;
                case "All inclusive":
                    comando.Parameters.Add(new SqlParameter("@ID_Regimen", 4));
                    break;
                case "":

                    break;

            }
        }


        private void obtenerIDHabitacion()
        {
            
            string consultaIDHabitacion = "SELECT ID_Habitacion "
                                 + "FROM AEFI.TL_Habitacion "
                                 + "WHERE ID_Tipo_Habitacion = @idTipoHabitacion AND Disponible = 'Si' ";

            SqlCommand comando = new SqlCommand(consultaIDHabitacion, conexion);
          

            switch (cbTipoDeHabitacion.SelectedItem.ToString())
            {
                case "Base Simple":
                    comando.Parameters.Add(new SqlParameter("@idTipoHabitacion", 1001));
                    SqlDataReader reader = comando.ExecuteReader();
                    reader.Read();
                    id_habitacion = Convert.ToInt32(reader[0]);
                    reader.Close();
                    break;
                case "Base Doble":
                    comando.Parameters.Add(new SqlParameter("@idTipoHabitacion", 1002));
                    reader = comando.ExecuteReader();
                    reader.Read();
                    id_habitacion = Convert.ToInt32(reader[0]);
                    reader.Close();
                    break;
                case "Base Triple":
                    comando.Parameters.Add(new SqlParameter("@idTipoHabitacion", 1003));
                    reader = comando.ExecuteReader();
                    reader.Read();
                    id_habitacion = Convert.ToInt32(reader[0]);
                    reader.Close();
                    break;
                case "Base Cuadruple":
                    comando.Parameters.Add(new SqlParameter("@idTipoHabitacion", 1004));
                    reader = comando.ExecuteReader();
                    reader.Read();
                    id_habitacion = Convert.ToInt32(reader[0]);
                    reader.Close();
                    break;
                case "King":
                    comando.Parameters.Add(new SqlParameter("@idTipoHabitacion", 1005));
                    reader = comando.ExecuteReader();
                    reader.Read();
                    id_habitacion = Convert.ToInt32(reader[0]);
                    reader.Close();

                    break;

            }
        }

        private void ingresarButton_Click(object sender, EventArgs e)
        {
            if (verificarTextBoxNoVacios())
            {

                try
                {
                    conexion.Open();

                    if (flag != "TeAbrieronDespuesDeCrearUnCliente")
                    {
                        string consultaSiElUsuarioEsYaCliente = "SELECT Mail "
                                                               + "FROM AEFI.TL_Cliente "
                                                               + "WHERE Mail = @Mail ";

                        SqlCommand comando2 = new SqlCommand(consultaSiElUsuarioEsYaCliente, conexion);
                        comando2.Parameters.Add("@Mail", Program.mailUsuario);
                        SqlDataReader reader2 = comando2.ExecuteReader();
                        reader2.Read();

                        if (Program.idUsuario != 1 /*osea no es el admin*/)
                        {
                            if (Program.idUsuario != 0/*osea es guest y no tiene mail*/)
                            {
                                mail = Convert.ToString(reader2["Mail"]);
                            }
                        }


                        if (reader2.HasRows)
                        {

                            reader2.Close();

                            string consultaID = "SELECT ID_Cliente "
                                              + "FROM AEFI.TL_Cliente "
                                              + "WHERE Mail = " + BaseDeDatos.agregarApostrofos(mail);

                            SqlCommand comandoId = new SqlCommand(consultaID, conexion);
                            SqlDataAdapter adapter2 = new SqlDataAdapter(comandoId);
                            
                            SqlDataReader readerId = comandoId.ExecuteReader();
                            readerId.Read();
                            int id = Convert.ToInt32(readerId["ID_Cliente"]);
                            SqlCommand comando = null;

                            if (flag != "TeAbrieronDesdeModificarReserva")
                            {
                                comando = new SqlCommand("AEFI.insertar_Reserva", conexion);
                            }
                            else 
                            {
                                comando = new SqlCommand("AEFI.modificar_Reserva",conexion);
                            }
                            
                            
                            comando.CommandType = CommandType.StoredProcedure;
                            
                            comando.Parameters.Add(new SqlParameter("@Fecha_Desde", Convert.ToDateTime(dtpDesde.Value)));
                            comando.Parameters.Add(new SqlParameter("@Cantidad_Huespedes", txbCantidadDeHuespedes.Text));
                            comando.Parameters.Add(new SqlParameter("@Cantidad_Noches", txbCantidadDeNoches.Text));


                            this.aniadirParametroRegimen(comando);
                            this.obtenerIDHabitacion();
                            comando.Parameters.Add(new SqlParameter("@ID_Habitacion", id_habitacion));
                            

                            if (flag != "TeAbrieronDesdeModificarReserva")
                            {
                                comando.Parameters.Add(new SqlParameter("@Estado", "Correcta"));
                            }
                            else
                            {
                                comando.Parameters.Add(new SqlParameter("@Estado", "Modificada"));
                            }

                            if (flag != "TeAbrieronDesdeModificarReserva")
                            {
                                comando.Parameters.Add(new SqlParameter("@ID_Cliente", id));
                            }
                            else
                            {
                                comando.Parameters.Add(new SqlParameter("@ID_Cliente", idCliente));
                                comando.Parameters.Add(new SqlParameter("@ID_Reserva",idReservaAModificar));
                            }
                            
                            
                            comando.ExecuteNonQuery();

                            if (flag != "TeAbrieronDesdeModificarReserva")
                            {
                                string idReservaCreada = "SELECT ID_Reserva " +
                                                         "FROM AEFI.TL_Reserva " +
                                                         "WHERE ID_Cliente = " + BaseDeDatos.agregarApostrofos(id.ToString()) + " AND Cantidad_Huespedes = " + 
                                                         BaseDeDatos.agregarApostrofos(txbCantidadDeHuespedes.Text) + 
                                                         " AND Cantidad_Noches = " + BaseDeDatos.agregarApostrofos(txbCantidadDeNoches.Text) ;

                                SqlCommand comandoIdReservaCreada = new SqlCommand(idReservaCreada,conexion);
                                SqlDataReader readerIdReservaCreada = comandoIdReservaCreada.ExecuteReader();
                                readerIdReservaCreada.Read();
                                int idDeLaReservaRecienCreada = Convert.ToInt32(readerIdReservaCreada[0]);

                                MessageBox.Show("Reserva Ingresada. Usted ya es cliente de este hotel. El codigo de la reserva es:" + idDeLaReservaRecienCreada.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Reserva Modificada. Usted ya es cliente de este hotel", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        
                            this.CancelarButton_Click(this, e);
                        }
                        else
                        {
                            MessageBox.Show("Usted no esta registrado como cliente de este hotel, a continuacion ingrese sus datos para luego efectuar la reserva", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            FormClienteNuevo c = new FormClienteNuevo(2);
                            this.Hide();
                            c.ShowDialog();
                            this.Close();
                        }

                    }
                    else
                    {
                        SqlCommand comando = new SqlCommand("AEFI.insertar_Reserva", conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@Fecha_Desde", Convert.ToDateTime(dtpDesde.Value)));
                        comando.Parameters.Add(new SqlParameter("@Cantidad_Huespedes", txbCantidadDeHuespedes.Text));
                        comando.Parameters.Add(new SqlParameter("@Cantidad_Noches", txbCantidadDeNoches.Text));


                        this.aniadirParametroRegimen(comando);
                        this.obtenerIDHabitacion();
                        comando.Parameters.Add(new SqlParameter("@ID_Habitacion", id_habitacion));
                        comando.Parameters.Add(new SqlParameter("@Estado", "Correcta"));
                        comando.Parameters.Add(new SqlParameter("@ID_Cliente", this.idCliente));
                        comando.ExecuteNonQuery();

                        string idReservaCreada = "SELECT ID_Reserva " +
                                                         "FROM AEFI.TL_Reserva " +
                                                         "WHERE ID_Cliente = " + BaseDeDatos.agregarApostrofos(this.idCliente.ToString()) + " AND Cantidad_Huespedes = " +
                                                         BaseDeDatos.agregarApostrofos(txbCantidadDeHuespedes.Text) +
                                                         " AND Cantidad_Noches = " + BaseDeDatos.agregarApostrofos(txbCantidadDeNoches.Text);

                        SqlCommand comandoIdReservaCreada = new SqlCommand(idReservaCreada, conexion);
                        SqlDataReader readerIdReservaCreada = comandoIdReservaCreada.ExecuteReader();
                        readerIdReservaCreada.Read();
                        int idDeLaReservaRecienCreada = Convert.ToInt32(readerIdReservaCreada[0]);

                        MessageBox.Show("Reserva Ingresada. Usted ya es cliente de este hotel. El codigo de la reserva es:" + idDeLaReservaRecienCreada.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.CancelarButton_Click(this, e);
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
            else
            {
                MessageBox.Show("Debe completar todos los campos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void verCostoButton_Click(object sender, EventArgs e)
        {
            if (verificarTextBoxNoVacios())
            {
                try
                {
                    string consultaIDRegimen = "SELECT id_regimen "
                        + "FROM AEFI.TL_Regimen "
                        + "WHERE Descripcion = " + BaseDeDatos.agregarApostrofos(cbTipoDeRegimen.SelectedItem.ToString());

                    string consultaTipoHabitacion = "SELECT h.ID_Tipo_Habitacion "
                                    + "FROM AEFI.TL_Habitacion h, AEFI.TL_Tipo_Habitacion t "
                                    + "WHERE t.Descripcion =" + BaseDeDatos.agregarApostrofos(cbTipoDeHabitacion.SelectedItem.ToString())
                                    + " AND h.ID_Tipo_Habitacion = t.ID_Tipo_Habitacion ";

                    string consultaIDHabitacion = "SELECT ID_Habitacion "
                                     + "FROM AEFI.TL_Habitacion "
                                     + "WHERE ID_Tipo_Habitacion = @idTipoHabitacion";



                    conexion.Open();

                    SqlCommand comando = new SqlCommand(consultaIDRegimen, conexion);
                    SqlDataReader reader = comando.ExecuteReader();
                    reader.Read();
                    int idRegimen = Convert.ToInt32(reader[0]);
                    reader.Close();

                    comando = new SqlCommand(consultaTipoHabitacion, conexion);
                    reader = comando.ExecuteReader();
                    reader.Read();
                    int idTipoHabitacion = Convert.ToInt32(reader[0]);
                    reader.Close();

                    comando = new SqlCommand(consultaIDHabitacion, conexion);
                    comando.Parameters.Add(new SqlParameter("@idTipoHabitacion", idTipoHabitacion));
                    reader = comando.ExecuteReader();
                    reader.Read();
                    id_habitacion = Convert.ToInt32(reader[0]);
                    reader.Close();

                    comando = new SqlCommand("AEFI.calcular_costo_porDia", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@id_habitacion", id_habitacion));
                    comando.Parameters.Add(new SqlParameter("@cantidad_noches", txbCantidadDeNoches.Text));
                    comando.Parameters.Add(new SqlParameter("@id_regimen", idRegimen));
                    comando.Parameters.Add(new SqlParameter("@id_tipo_habitacion", idTipoHabitacion));
                    SqlParameter par = new SqlParameter("@costo", 0);
                    par.Direction = ParameterDirection.Output;
                    comando.Parameters.Add(par);
                    comando.ExecuteNonQuery();
                    double valor = Convert.ToDouble(par.Value);

                    MessageBox.Show("El costo es de : U$S" + valor, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            else
            {
                MessageBox.Show("Debe completar todos los campos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private void FormGenerarReserva_Load(object sender, EventArgs e)
        {
            
                try
                {
                    string consulta = "SELECT Descripcion "
                                     + "FROM AEFI.TL_Tipo_Habitacion";

                    conexion.Open();
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                        cbTipoDeHabitacion.Items.Add(reader[0]); 
                    reader.Close();
                    cbTipoDeHabitacion.SelectedIndex = 0;
                    SqlCommand comando2 = null;
                    if (Program.idUsuario != 0)
                    {
                        string consulta2 = "SELECT r.Descripcion "
                                         + "FROM AEFI.TL_Regimen r, AEFI.TL_Regimen_Por_Hotel h "
                                         + "WHERE r.ID_Regimen = h.ID_Regimen AND h.ID_Hotel = " + BaseDeDatos.agregarApostrofos(Program.idHotel.ToString());
                        comando2 = new SqlCommand(consulta2, conexion);
                    }
                    else 
                    {
                        string consulta2 = "SELECT DISTINCT r.Descripcion "
                                         + "FROM AEFI.TL_Regimen r, AEFI.TL_Regimen_Por_Hotel h "
                                         + "WHERE r.ID_Regimen = h.ID_Regimen ";
                        comando2 = new SqlCommand(consulta2, conexion);
                    }

                    
                    SqlDataReader reader2 = comando2.ExecuteReader();
                    while (reader2.Read())
                        cbTipoDeRegimen.Items.Add(reader2[0]);
                    reader.Close();
                    cbTipoDeRegimen.Items.Add("");
                    cbTipoDeRegimen.SelectedIndex = 0;
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

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            FormMenu inicio = new FormMenu();
            this.Hide();
            inicio.ShowDialog();
            this.Close();
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

        private void txbCantidadDeHuespedes_KeyPress(object sender, KeyPressEventArgs e)
        {
            permitirSoloNumeros(e);
        }

        private void txbCantidadDeNoches_KeyPress(object sender, KeyPressEventArgs e)
        {
            permitirSoloNumeros(e);
        }
     
    }
}
