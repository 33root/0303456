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
                //falta que ivan agregue el campu reservada en la tabla de habitaciones, para checkear hay habitaciones del tipo pedido sin reserva
                SqlDataReader reader = comando.ExecuteReader();

                // chequeo que no exista otra reserva igual
                if (reader.HasRows)
                {
                    throw new Excepciones("Ya existe una reserva con los mismos datos");
                }

                if (reader5.HasRows)
                {
                    throw new Excepciones("No hay habitaciones disponibles");
                }

                if(cbTipoDeRegimen == null){
                    //significa que el usuario no tiene en claro el regimen que desea
                    string consulta = "SELECT r.Descripcion, r.Precio_Base "
                                     + "FROM AEFI.TL_Regimen r, AEFI.TL_Regimen_Por_Hotel p "
                                     + "WHERE p.ID_Hotel ="+ Program.idHotel +" AND r.ID_Regimen = p.ID_Regimen ";
                                     

                    //cargar la tabla con descripcion y precio base del hotel
                    DataTable tabla = new DataTable();
                    SqlCommand comando2 = new SqlCommand(consulta, conexion);
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    adapter.Fill(tabla);
                    dataGridView1.DataSource = tabla;
                }

                comando = new SqlCommand(consultaCantidadDeHuespedesParaLaHabitacion, conexion);
                comando.Parameters.Add(new SqlParameter("@Cantidad_Huespedes_Total", txbCantidadDeHuespedes.Text));
                comando.Parameters.Add(new SqlParameter("@Descripcion",cbTipoDeHabitacion.SelectedItem.ToString()));
                reader = comando.ExecuteReader();

                if(!(reader.HasRows)){
                    //si no encontro ninguna coincidencia
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
                                 + "WHERE ID_Tipo_Habitacion = @idTipoHabitacion";

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
           
            try
            {
                conexion.Open();
                
                if (flag != "TeAbrieronDespuesDeCrearUnCliente")
                {
                    string consultaSiElUsuarioEsYaCliente =  "SELECT Mail "
                                                           + "FROM AEFI.TL_Cliente "
                                                           + "WHERE Mail = @Mail ";

                    SqlCommand comando2 = new SqlCommand(consultaSiElUsuarioEsYaCliente, conexion);
                    comando2.Parameters.Add("@Mail", Program.mailUsuario); //ESTO SE TIENE QUE CARGAR EN EL LOGIN, ya que en los clientes el Mail es lo que no se repite, comparar por ID no tiene sentido
                    SqlDataReader reader2 = comando2.ExecuteReader();
                    reader2.Read();

                    if(Program.idUsuario != 1 /*osea no es el admin*/)
                    {//si es el admin la lectura de arriba no va a traer ningun mail, entonces esto rompia por eso
                    mail = Convert.ToString(reader2["Mail"]);
                        //cuando entro con un usuario creado esto funciona, pero cuando entro con el admin no
                        //creia que era porque el admin no tiene mail tiene null, entonces le agregue un mail admin@gmail.com
                        //pero me sigue diciendo que aca no lee nada... Help!
                    }
                    
                    
                    if (reader2.HasRows)
                    {

                        reader2.Close();

                        string consultaID = "SELECT ID_Cliente "
                                          + "FROM AEFI.TL_Cliente "
                                          + "WHERE Mail = " + BaseDeDatos.agregarApostrofos(mail);

                        SqlCommand comandoId = new SqlCommand(consultaID, conexion);
                        SqlDataAdapter adapter2 = new SqlDataAdapter(comandoId);
                        //string id = adapter2.ToString();// me parece que esto no esta bien, pero lo de abajo me dice que no se pudo enlazar el mail
                        SqlDataReader readerId = comandoId.ExecuteReader();
                        readerId.Read();
                        int id = Convert.ToInt32(readerId["ID_Cliente"]);

                        SqlCommand comando = new SqlCommand("AEFI.insertar_Reserva", conexion);
                        DateTime fechaAcutal = new DateTime();
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@Fecha_Reserva", fechaAcutal.Date));
                        comando.Parameters.Add(new SqlParameter("@Fecha_Desde", dtpDesde.Value));
                        comando.Parameters.Add(new SqlParameter("@Cantidad_Huespedes", txbCantidadDeHuespedes.ToString()));
                        comando.Parameters.Add(new SqlParameter("@Cantidad_Noches", txbCantidadDeNoches.ToString()));


                        this.aniadirParametroRegimen(comando);
                        this.obtenerIDHabitacion();
                        comando.Parameters.Add(new SqlParameter("@ID_Habitacion", id_habitacion));
                        comando.Parameters.Add(new SqlParameter("@Estado", "Correcta"));
                        comando.Parameters.Add(new SqlParameter("@ID_Cliente", id));

                        MessageBox.Show("Reserva Ingresada. Usted ya es cliente de este hotel", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    DateTime fechaAcutal = new DateTime();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@Fecha_Reserva", fechaAcutal.Date));
                    comando.Parameters.Add(new SqlParameter("@Fecha_Desde", dtpDesde.Value));
                    comando.Parameters.Add(new SqlParameter("@Cantidad_Huespedes", txbCantidadDeHuespedes.ToString()));
                    comando.Parameters.Add(new SqlParameter("@Cantidad_Noches", txbCantidadDeNoches.ToString()));


                    this.aniadirParametroRegimen(comando);
                    this.obtenerIDHabitacion();
                    comando.Parameters.Add(new SqlParameter("@ID_Habitacion", id_habitacion));
                    comando.Parameters.Add(new SqlParameter("@Estado", "Correcta"));
                    comando.Parameters.Add(new SqlParameter("@ID_Cliente", this.idCliente));
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
                Console.WriteLine("Pase por el finally");
                conexion.Close();
            }
        }


        private void verCostoButton_Click(object sender, EventArgs e)
        {
            try
            {
                string consultaIDRegimen = "SELECT id_regimen "
                    +             "FROM AEFI.TL_Regimen "
                    +             "WHERE Descripcion = " + BaseDeDatos.agregarApostrofos(cbTipoDeRegimen.SelectedItem.ToString());

                string consultaTipoHabitacion = "SELECT h.ID_Tipo_Habitacion "
                                + "FROM AEFI.TL_Habitacion h, AEFI.TL_Tipo_Habitacion t "
                                + "WHERE t.Descripcion =" + BaseDeDatos.agregarApostrofos(cbTipoDeHabitacion.SelectedItem.ToString());

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
                comando.Parameters.Add(new SqlParameter("@cantidad_huespedes", txbCantidadDeHuespedes.Text));
                comando.Parameters.Add(new SqlParameter("@id_habitacion", id_habitacion));
                comando.Parameters.Add(new SqlParameter("@cantidad_noches", txbCantidadDeNoches.Text));
                comando.Parameters.Add(new SqlParameter("@id_regimen", idRegimen));
                comando.Parameters.Add(new SqlParameter("@id_tipo_habitacion", idTipoHabitacion));
                SqlParameter par = new SqlParameter("@costo", 0);
                par.Direction = ParameterDirection.Output;
                comando.Parameters.Add(par);
                comando.ExecuteNonQuery();

                MessageBox.Show("El costo es de : U$S"+ par.Value , "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void FormGenerarReserva_Load(object sender, EventArgs e)
        {
            try {
                string consulta = "SELECT Descripcion "
                                 +"FROM AEFI.TL_Tipo_Habitacion";

                conexion.Open();
                SqlCommand comando = new SqlCommand(consulta, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                    cbTipoDeHabitacion.Items.Add(reader[0]); //carga los tipos de habitacion en el combo box
                reader.Close();
                cbTipoDeHabitacion.SelectedIndex = 0;

                string consulta2 = "SELECT Descripcion "
                                 + "FROM AEFI.TL_Regimen";

                SqlCommand comando2 = new SqlCommand(consulta2, conexion);
                SqlDataReader reader2 = comando2.ExecuteReader();
                while (reader2.Read())
                    cbTipoDeRegimen.Items.Add(reader2[0]); //carga los tipos de regimen en el combo box
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

     
    }
}
