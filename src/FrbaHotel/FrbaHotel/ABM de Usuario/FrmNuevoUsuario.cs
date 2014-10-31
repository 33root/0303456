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

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class FrmNuevoUsuario : Form
    {
        SqlConnection conexion = BaseDeDatos.conectar();

        public FrmNuevoUsuario()
        {
            InitializeComponent();

        }

        private void FrmNuevoUsuario_Load(object sender, EventArgs e)
        {


            String cargarRoles = "SELECT Descripcion " +
                                   "FROM AEFI.TL_Rol r " +
                                   "WHERE r.Descripcion != 'Guest' ";

            String cargarHoteles = "SELECT Nombre " +
                                    "FROM AEFI.TL_Hotel h ";

            String cargarTipoDocumento = "SELECT Descripcion " +
                                         "FROM AEFI.TL_Tipo_Documento ";

            try
            {
                conexion.Open();
                //Cargo los roles
                SqlCommand comando = new SqlCommand(cargarRoles, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    rolesBox.Items.Add(reader["Descripcion"].ToString());
                }

                rolesBox.SelectedIndex = 0;


                //Cargo los tipos de documento
                comando = new SqlCommand(cargarTipoDocumento, conexion);
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    tipoDocCmbBox.Items.Add(reader["Descripcion"].ToString());
                }

                tipoDocCmbBox.SelectedIndex = 0;



                // cargo los hoteles que puede elegir
                comando = new SqlCommand(cargarHoteles, conexion);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    checkedListBox.Items.Add(Convert.ToString(reader["Nombre"]));
                }
                reader.Close();


            }

            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void cancelarBtn_Click(object sender, EventArgs e)
        {
            FormMenu inicio = new FormMenu();
            this.Hide();
            inicio.ShowDialog();
            this.Close();
        }

        private void nuevoUsuarioBtn_Click(object sender, EventArgs e)
        {
            int id_Hotel;
            int id_tipo_doc;
            int id_usuario_creado;
            int id_rol;


            String ObtenerIdHotel = "SELECT ID_Hotel " +
                                    "FROM AEFI.TL_Hotel " +
                                    "WHERE h.Nombre = @NombreHotel";
            String verificarUsernameNoUsado = "SELECT COUNT (*) " +
                                              "FROM AEFI.TL_Usuario u " +
                                              "WHERE u.Username != @Username ";
            String obtenerIdTipoDocumento = "SELECT ID_Tipo_Documento " +
                                           "FROM AEFI.TL_Tipo_Documento t " +
                                           "WHERE t.Descripcion = @Descripcion ";

            String obtenerIdUsuarioCreado = "SELECT ID_Usuario " +
                                           "FROM AEFI.TL_Usuario u " +
                                           "WHERE u.Username = @Username ";

            String obtenerIdRol = "SELECT ID_Rol " +
                                   "FROM AEFI.TL_Rol r " +
                                   "WHERE r.Descripcion = @Descripcion";




            try
            {


                SqlCommand comando = new SqlCommand(obtenerIdTipoDocumento, conexion);
                comando.Parameters.Add(new SqlParameter("@Descripcion", tipoDocCmbBox.Text));
                SqlDataReader reader = comando.ExecuteReader();

                reader.Read();
                id_tipo_doc = Convert.ToInt32(reader["ID_Tipo_Documento"]);
                reader.Close();

                comando = new SqlCommand(obtenerIdRol, conexion);
                comando.Parameters.Add(new SqlParameter("Descripcion", rolesBox.Text));
                reader = comando.ExecuteReader();

                reader.Read();
                id_rol = Convert.ToInt32(reader["ID_Rol"]);
                reader.Close();


                
                if (!String.IsNullOrEmpty(userTxtBox.Text))
                {

                    comando = new SqlCommand(verificarUsernameNoUsado, conexion);
                    comando.Parameters.Add(new SqlParameter("@Username", userTxtBox.Text));
                    reader = comando.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        comando = new SqlCommand("AEFI.crear_usuario", conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@Username", userTxtBox.Text));

                        comando.Parameters.Add(new SqlParameter("@Nombre", nombreTxtBox.Text));


                        comando.Parameters.Add(new SqlParameter("@Password", passwordTxtBox.Text));


                        comando.Parameters.Add(new SqlParameter("@Password", BaseDeDatos.cifrar256(passwordTxtBox.Text)));


                        comando.Parameters.Add(new SqlParameter("@calle", calleTxtBox.Text));
                        comando.Parameters.Add(new SqlParameter("@calle_nro", numeroTxtBox.Text));
                        comando.Parameters.Add(new SqlParameter("@piso", pisoTxtBox.Text));

                        comando.Parameters.Add(new SqlParameter("@mail", mailTxtBox.Text));

                        comando.Parameters.Add(new SqlParameter("@telefono", telefonoTxtBox.Text));

                        comando.Parameters.Add(new SqlParameter("@fecha_nacimiento", dateTimePicker1.Value.Date));
                        comando.Parameters.Add(new SqlParameter("@id_tipo_documento", id_tipo_doc));


                        reader = comando.ExecuteReader();


                        comando = new SqlCommand(obtenerIdUsuarioCreado, conexion);
                        comando.Parameters.Add(new SqlParameter("@Username", userTxtBox.Text));
                        reader = comando.ExecuteReader();
                        reader.Read();
                        id_usuario_creado = Convert.ToInt32(reader["ID_Usuario"]);
                        reader.Close();





                        comando = new SqlCommand("AEFI.crear_usuario_por_rol", conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@ID_Rol", id_rol));
                        comando.Parameters.Add(new SqlParameter("@ID_Usuario", id_usuario_creado));








                        for (int i = 0; i < checkedListBox.Items.Count; i++)
                        {
                            if (checkedListBox.GetItemCheckState(i) == CheckState.Checked)
                            {   //Obtengo el ID del Hotel si esta checkeado
                                try
                                {
                                    comando = new SqlCommand(ObtenerIdHotel, conexion);
                                    comando.Parameters.Add(new SqlParameter("@NombreHotel", Convert.ToString(checkedListBox.Items[i])));
                                    reader = comando.ExecuteReader();


                                    reader.Read();
                                    id_Hotel = Convert.ToInt32(reader["ID_Hotel"]);
                                    reader.Close();

                                    comando = new SqlCommand("AEFI.crear_usuario_por_hotel", conexion);
                                    comando.CommandType = CommandType.StoredProcedure;
                                    comando.Parameters.Add(new SqlParameter("ID_Rol", id_rol));
                                    comando.Parameters.Add(new SqlParameter("ID_Usuario", id_usuario_creado));
                                    comando.Parameters.Add(new SqlParameter("ID_Hotel", id_Hotel));
                                }
                                catch (Excepciones exc)
                                {
                                    MessageBox.Show(exc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }


                        MessageBox.Show("El Usuario se creo satisfactoriamente", "Usuario Creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }
            }


            finally
            {
                conexion.Close();
            }

        }

        }

            


         



        

    }


        
    






