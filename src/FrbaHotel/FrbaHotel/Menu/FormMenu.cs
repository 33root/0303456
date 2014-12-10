using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.ABM_de_Hotel;
using FrbaHotel.ABM_de_Habitacion;
using FrbaHotel.ABM_de_Rol;
using FrbaHotel.ABM_de_Cliente;
using FrbaHotel.ABM_de_Usuario;
using FrbaHotel.Facturar_Estadia;
using FrbaHotel.Generar_Modificar_Reserva;
using FrbaHotel.Cancelar_Reserva;
using FrbaHotel.Listado_Estadistico;
using System.Data.SqlClient;
using FrbaHotel.Registrar_Estadia;
using FrbaHotel.ABM_de_Regimen;
using FrbaHotel.Registrar_Consumible;
using FrbaHotel.Login;

namespace FrbaHotel.Menu
{
    public partial class FormMenu : Form
    {
        SqlConnection conexion = BaseDeDatos.conectar();


        public FormMenu()
        {
            InitializeComponent();
        }

        private void btnListaHoteles_Click(object sender, EventArgs e)
        {
            FormListaDeHoteles lh = new FormListaDeHoteles();
            this.Hide();
            lh.ShowDialog();
            this.Close();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            try
            {
                string consultaFuncionalidades = "SELECT ID_Funcionalidad " +
                                                 "FROM AEFI.TL_Funcionalidad_Rol "+
                                                 "WHERE ID_ROL = " + Program.idRol;
                 conexion.Open();
                SqlCommand comando = new SqlCommand(consultaFuncionalidades, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    switch (Convert.ToInt32(reader[0]))
                    {
                        case 1:
                            btnGestorDeRoles.Visible = true;
                            break;
                        case 2:
                            btnGestorDeUsuarios.Visible = true;
                            break;
                        case 3:
                            btnGestorDeClientes.Visible = true;
                            //btnListadoDeClientes.Visible = true;
                            break;
                        case 4:
                            btnGestorHoteles.Visible = true;
                            btnListaHoteles.Visible = true;
                            break;
                        case 5:
                            btnGestorDeHabitaciones.Visible = true;
                            btnListadoHabitacion.Visible = true;
                            break;
                        case 6:
                            btnGestorRegimenes.Visible = true;
                            break;
                        case 7:
                            btnGenerarReserva.Visible = true;
                            break;
                        case 8:
                            btnCancelarReservas.Visible = true;
                            break;
                        case 9:
                            btnRegistrarEstadia.Visible = true;
                            break;
                        case 10:
                            btnRegistrarConsumibles.Visible = true;
                            break;
                        case 11:
                            btnFacturar.Visible = true;
                            break;
                        case 12:
                            btnListadoEstadistico.Visible = true;
                            break;                   
                    }
                    if (Program.idUsuario != 0)
                    {
                        btnNuevaClave.Visible = true;
                    }
                }
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


 
    

       private void btnRegistrarConsumibles_Click(object sender, EventArgs e)
       {
           FrmRegistrarConsumible r = new FrmRegistrarConsumible();
           this.Hide();
           r.ShowDialog();
           this.Close();

       }

       private void btnGestorRegimenes_Click(object sender, EventArgs e)
       {
           FrmRegimenDeEstadia r = new FrmRegimenDeEstadia();
           this.Hide();
           r.ShowDialog();
           this.Close();
       }

       private void btnGestorDeUsuarios_Click(object sender, EventArgs e)
       {
           FrmAbmDeUsuario r = new FrmAbmDeUsuario();
           this.Hide();
           r.ShowDialog();
           this.Close();
       }

       private void btnGestorHoteles_Click(object sender, EventArgs e)
       {
           FormNuevoHotel lh = new FormNuevoHotel();
           this.Hide();
           lh.ShowDialog();
           this.Close();

       }

       private void btnGestorDeHabitaciones_Click(object sender, EventArgs e)
       {
           FormNuevaHabitacion lh = new FormNuevaHabitacion();
           this.Hide();
           lh.ShowDialog();
           this.Close();
       }

       private void btnCancelarReservas_Click(object sender, EventArgs e)
       {

           FormCancelarReserva r = new FormCancelarReserva();
           this.Hide();
           r.ShowDialog();
           this.Close();
       }

       private void btnListadoHabitacion_Click(object sender, EventArgs e)
       {
           FormListaHabitacion lh = new FormListaHabitacion();
           this.Hide();
           lh.ShowDialog();
           this.Close();

       }

       private void btnListadoDeClientes_Click(object sender, EventArgs e)
       {
           FormBuscadorDeClientes b = new FormBuscadorDeClientes();
           this.Hide();
           b.ShowDialog();
           this.Close();
       }

       private void btnGestorDeRoles_Click(object sender, EventArgs e)
       {
           FormRol r = new FormRol();
           this.Hide();
           r.ShowDialog();
           this.Close();
       }

       private void btnFacturar_Click(object sender, EventArgs e)
       {
           this.Hide();
           FrmFacturar facturar = new FrmFacturar();
           facturar.ShowDialog();
           this.Close();
       }

       private void btnGestorDeClientes_Click(object sender, EventArgs e)
       {
           FrmHuesped c = new FrmHuesped();
           this.Hide();
           c.ShowDialog();
           this.Close();
       }

       private void btnGenerarReserva_Click(object sender, EventArgs e)
       {
           FormGenerarOModificarReserva r = new FormGenerarOModificarReserva();
           this.Hide();
           r.ShowDialog();
           this.Close();
       }

       private void btnListadoEstadistico_Click(object sender, EventArgs e)
       {
           FrmListadoEstadistico r = new FrmListadoEstadistico();
           this.Hide();
           r.ShowDialog();
           this.Close();

       }

       private void btnSalir_Click(object sender, EventArgs e)
       {
           FrmLogIn r = new FrmLogIn();
           this.Hide();
           r.ShowDialog();
           this.Close();
       }

       private void btnRegistrarEstadia_Click(object sender, EventArgs e)
       {
           FormRegistroEstadia r = new FormRegistroEstadia();
           this.Hide();
           r.ShowDialog();
           this.Close();

       }

       private void btnNuevaClave_Click(object sender, EventArgs e)
       {
           NuevaClave i = new NuevaClave(Convert.ToString(Program.idUsuario));
           this.Hide();
           i.ShowDialog();
           this.Close();
       }


      
    }
}
