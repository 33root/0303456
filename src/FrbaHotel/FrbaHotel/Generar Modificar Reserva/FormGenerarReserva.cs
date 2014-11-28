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

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class FormGenerarReserva : Form
    {

        SqlConnection conexion = BaseDeDatos.conectar();
        string id_habitacion;

        public FormGenerarReserva()
        {
            InitializeComponent();
        }

     

        private void checkearDisponibilidadButton_Click(object sender, EventArgs e)
        {
            string consultaDisponibilidadDeLaReserva = "SELECT ID_Reserva, Fecha_Desde, Cantidad_Huespedes, Cantidad_Noches, ID_Regimen, ID_Habitacion, ID_Cliente"
                                                              + "FROM AEFI.TL_Reserva r, AEFI.TL_Regimen e, AEFI.TL_Habitacion h"
                                                              + "WHERE Fecha_Desde = @Fecha_Desde"
                                                              + "AND Cantidad_Huespedes = @Cantidad_Huespedes"
                                                              + "AND Cantidad_Noches = @Cantidad_Noches"
                                                              + "AND ID_Cliente = @ID_Cliente";
                                                              //tengo que ver de donde sacar el ID_Habitacion

            string consultaCantidadDeHuespedesParaLaHabitacion = "SELECT Cantidad_Uespedes_Total"
                                                               + "FROM AEFI.TL_Tipo_Habitacion h"
                                                               + "WHERE h.Cantidad_Uespedes_Total = @Cantidad_Uespedes_Total AND h.Descripcion = @Descripcion ";

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand(consultaDisponibilidadDeLaReserva, conexion);
                comando.Parameters.Add(new SqlParameter("@Fecha_Desde", dtpDesde));
                comando.Parameters.Add(new SqlParameter("@Cantidad_Huespedes", txbCantidadDeHuespedes));
                comando.Parameters.Add(new SqlParameter("@Cantidad_Noches", txbCantidadDeNoches));
                comando.Parameters.Add(new SqlParameter("@ID_Cliente", Program.idUsuario));
                //falta que ivan agregue el campu reservada en la tabla de habitaciones, para checkear hay habitaciones del tipo pedido sin reserva
                SqlDataReader reader = comando.ExecuteReader();

                // chequeo que no exista otra reserva igual
                if (reader.HasRows)
                {
                    throw new Excepciones("Ya existe una reserva con los mismos datos");
                }

                if(cbTipoDeRegimen == null){
                    //significa que el usuario no tiene en claro el regimen que desea
                    string consulta = "SELECT Descripcion, Precio_Base"
                                     + "FROM AEFI.TL_Regimen r, AEFI.TL_Regimen_Por_Hotel p"
                                     + "WHERE p.ID_Hotel ="+ Program.idHotel +"AND r.ID_Regimen = p.ID_Regimen";
                                     

                    //cargar la tabla con descripcion y precio base del hotel
                    DataTable tabla = new DataTable();
                    SqlCommand comando2 = new SqlCommand(consulta, conexion);
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    adapter.Fill(tabla);
                    dataGridView1.DataSource = tabla;
                }

                SqlCommand comando3 = new SqlCommand(consultaCantidadDeHuespedesParaLaHabitacion, conexion);
                comando3.Parameters.Add(new SqlParameter("@Cantidad_Uespedes_Total", txbCantidadDeHuespedes));
                comando3.Parameters.Add(new SqlParameter("@Descripcion",cbTipoDeHabitacion));
                SqlDataReader reader3 = comando3.ExecuteReader();

                if(!reader3.HasRows){
                    //si no encontro ninguna coincidencia
                    throw new Excepciones("El tipo de habitacion elegido no tiene la capacidad que usted eligio de huespedes");
                }
            }

            catch (Excepciones exc)
            {
                MessageBox.Show(exc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ingresarButton_Click(object sender, EventArgs e)
        {
            //agregar una reserva en la tabla
            conexion.Open();
            SqlCommand comando = new SqlCommand("AEFI.insertar_Reserva", conexion);
            DateTime fechaAcutal = new DateTime();
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@Fecha_Reserva", fechaAcutal.Date));
            comando.Parameters.Add(new SqlParameter("@Fecha_Desde",dtpDesde));
            comando.Parameters.Add(new SqlParameter("@Cantidad_Huespedes",txbCantidadDeHuespedes));
            comando.Parameters.Add(new SqlParameter("@Cantidad_Noches",txbCantidadDeNoches));
            if (cbTipoDeRegimen.SelectedItem.ToString() == "Pension Completa")
            {
            comando.Parameters.Add(new SqlParameter("@ID_Regimen",1));
            if (cbTipoDeRegimen.SelectedItem.ToString() == "Media Pensión") 
                {
                    comando.Parameters.Add(new SqlParameter("@ID_Regimen", 2));
                    if (cbTipoDeRegimen.SelectedItem.ToString() == "All Inclusive moderado")
                    {
                        comando.Parameters.Add(new SqlParameter("@ID_Regimen", 3));
                        if (cbTipoDeRegimen.SelectedItem.ToString() == "All inclusive")
                        {
                            comando.Parameters.Add(new SqlParameter("@ID_Regimen", 4));

                            if (cbTipoDeRegimen.SelectedItem == null)
                            {
                                //el cliente no tiene en claro el tipo de régimen que desea
                                comando.Parameters.Add(new SqlParameter("ID_Regimen",null));

                            }
                        }
                    }
                }
            }
            if (cbTipoDeHabitacion.SelectedItem.ToString() == "Base Simple")
            {
                string consulta = "SELECT ID_Habitacion,ID_Tipo_Habitacion "
                                 +"FROM AEFI.TL_Habitacion"
                                 +"WHERE ID_Tipo_Habitacion = 1001";
                SqlCommand comando2 = new SqlCommand(consulta, conexion);
                SqlDataReader reader = comando2.ExecuteReader();

                comando.Parameters.Add(new SqlParameter("@ID_Habitacion", reader[0]));
            }
            if (cbTipoDeHabitacion.SelectedItem.ToString() == "Base Doble")
            {
                string consulta = "SELECT ID_Habitacion,ID_Tipo_Habitacion "
                                 + "FROM AEFI.TL_Habitacion"
                                 + "WHERE ID_Tipo_Habitacion = 1002";
                SqlCommand comando2 = new SqlCommand(consulta, conexion);
                SqlDataReader reader = comando2.ExecuteReader();

                comando.Parameters.Add(new SqlParameter("@ID_Habitacion", reader[0]));
            }
            if (cbTipoDeHabitacion.SelectedItem.ToString() == "Base Triple")
            {
                string consulta = "SELECT ID_Habitacion,ID_Tipo_Habitacion "
                                 + "FROM AEFI.TL_Habitacion"
                                 + "WHERE ID_Tipo_Habitacion = 1003";
                SqlCommand comando2 = new SqlCommand(consulta, conexion);
                SqlDataReader reader = comando2.ExecuteReader();
                comando.Parameters.Add(new SqlParameter("@ID_Habitacion", reader[0]));
            }
            if (cbTipoDeHabitacion.SelectedItem.ToString() == "Base Cuadruple")
            {
                string consulta = "SELECT ID_Habitacion,ID_Tipo_Habitacion "
                                 + "FROM AEFI.TL_Habitacion"
                                 + "WHERE ID_Tipo_Habitacion = 1004";
                SqlCommand comando2 = new SqlCommand(consulta, conexion);
                SqlDataReader reader = comando2.ExecuteReader();
                comando.Parameters.Add(new SqlParameter("@ID_Habitacion", reader[0]));
            }
            if (cbTipoDeHabitacion.SelectedItem.ToString() == "King")
            {
                string consulta = "SELECT ID_Habitacion,ID_Tipo_Habitacion "
                                 + "FROM AEFI.TL_Habitacion"
                                 + "WHERE ID_Tipo_Habitacion = 1005";
                SqlCommand comando2 = new SqlCommand(consulta, conexion);
                SqlDataReader reader = comando2.ExecuteReader();
                comando.Parameters.Add(new SqlParameter("@ID_Habitacion", reader[0]));
            }
            comando.Parameters.Add(new SqlParameter("@Estado","Correcta"));
            comando.Parameters.Add(new SqlParameter("@ID_Cliente", Program.usuario));
        }

        private void verCostoButton_Click(object sender, EventArgs e)
        {
            try
            {
                string consulta = "SELECT id_regimen "
                    +             "FROM AEFI.TL_Regimen "
                    +             "WHERE Descripcion =" + cbTipoDeRegimen.SelectedItem.ToString();

                SqlCommand comando2 = new SqlCommand(consulta, conexion);
                SqlDataReader reader = comando2.ExecuteReader();

                string consulta2 = "SELECT h.ID_Tipo_Habitacion, t.Descripcion "
                                 + "FROM AEFI.TL_Habitacion h, AEFI.TL_Tipo_Habitacion t"
                                 + "WHERE t.Descripcion =" + cbTipoDeHabitacion.SelectedItem.ToString();

                SqlCommand comando3 = new SqlCommand(consulta2, conexion);
                SqlDataReader reader2 = comando2.ExecuteReader();

                conexion.Open();
                SqlCommand comando4 = new SqlCommand("AEFI.calcular_costo_porDia", conexion);
                comando4.CommandType = CommandType.StoredProcedure;
                comando4.Parameters.Add(new SqlParameter("@cantidad_huespedes", txbCantidadDeHuespedes));
                comando4.Parameters.Add(new SqlParameter("@id_habitacion", this.id_habitacion));
                comando4.Parameters.Add(new SqlParameter("@cantidad_noches", txbCantidadDeNoches));
                comando4.Parameters.Add(new SqlParameter("@id_regimen", reader[0]));
                comando4.Parameters.Add(new SqlParameter("@id_tipo_habitacion", reader2[0]));

                //string costoString = (comando4.Parameters("@costo").Value).ToString(); //me dice que no se puede usar Parameters porque el comando4 no es invocable :S

                //MessageBox.Show(costoString);

            }

            catch { }
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

        private void txbCantidadDeHuespedes_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbTipoDeHabitacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbTipoDeRegimen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
