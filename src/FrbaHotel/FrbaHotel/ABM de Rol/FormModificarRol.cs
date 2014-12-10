using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.ABM_de_Rol
{
    public partial class FormModificarRol : Form
    {


        int rolSeleccionado;

        SqlConnection conexion = BaseDeDatos.conectar();

        public FormModificarRol()
        {
            InitializeComponent();
            String consultaRoles = "SELECT Descripcion " +
                                    "FROM AEFI.TL_Rol r ";

            try
            {
                conexion.Open();
                //Cargo los roles
                SqlCommand comando = new SqlCommand(consultaRoles, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    rolesBox.Items.Add(reader["Descripcion"].ToString());
                }
                reader.Close();
                rolesBox.SelectedIndex = 0;
            }

            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

    
        private void confirmarBtn_Click_1(object sender, EventArgs e)
        {



            String consultaActivo = "SELECT Activo " +
                                    "FROM AEFI.TL_Rol r" +
                                        " WHERE r.ID_Rol = @rolSeleccionado ";



            String consulta = "SELECT ID_Rol " +
                                  "FROM AEFI.TL_Rol " +
                                  "WHERE Descripcion = @Descripcion ";

             String consultaFuncionalidades = "SELECT Descripcion " +
                                    "FROM AEFI.TL_Funcionalidad f " +
                                    "WHERE f.Restriccion = @rolSeleccionado OR f.Restriccion IS NULL";

            String consultaFuncionalidadXRol = "SELECT ID_Rol " +
                                    "FROM AEFI.TL_Funcionalidad_Rol x , AEFI.TL_Funcionalidad f " +
                                    "WHERE ID_Rol = @rol" +
                                    " AND f.Descripcion = @descripcion" +
                                    " AND f.ID_Funcionalidad = x.ID_Funcionalidad";

            try
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();

                }


                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.Add(new SqlParameter("@Descripcion", rolesBox.SelectedItem.ToString()));
                SqlDataReader reader = comando.ExecuteReader();


                reader.Read();
                rolSeleccionado = Convert.ToInt32(reader["ID_Rol"]);
                reader.Close();

                nombreRolBox.Visible = true;
                nombreRolBox.Text = Convert.ToString(rolesBox.SelectedItem);
                aplicarCambiosBtn.Visible = true;
                checkedListBox.Visible = true;
                estadoChkBox.Visible = true;

                comando = new SqlCommand(consultaActivo, conexion);
                comando.Parameters.Add(new SqlParameter("@rolSeleccionado", rolSeleccionado));
                reader = comando.ExecuteReader();

                reader.Read();
                bool Activo = Convert.ToBoolean(reader["Activo"]);
                reader.Close();

                if ( Activo == true) {
                estadoChkBox.Checked = true;
                }


                nombreLbl.Visible = true;
                funcionalidadeslbl.Visible = true;


                // cargo las funcionalidades que puede elegir
                comando = new SqlCommand(consultaFuncionalidades, conexion);
                comando.Parameters.Add(new SqlParameter("@rolSeleccionado", rolSeleccionado));
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    checkedListBox.Items.Add(Convert.ToString(reader["Descripcion"]));
                }
                

                    for (int i = 0; i < checkedListBox.Items.Count; i++)
                    {
                        String funcionalidadSeleccionada = Convert.ToString(checkedListBox.Items[i]);

                        comando = new SqlCommand(consultaFuncionalidadXRol, conexion);
                        comando.Parameters.Add(new SqlParameter("@rol", rolSeleccionado));
                        comando.Parameters.Add(new SqlParameter("@descripcion", funcionalidadSeleccionada));

                        reader = comando.ExecuteReader();

                        if (reader.HasRows)
                        {
                            checkedListBox.SetItemChecked(i, true);
                        }



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
        

        private void cancelarBtn_Click(object sender, EventArgs e)
        {
            FormRol rol = new FormRol();
            this.Hide();
            rol.ShowDialog();
            this.Close();


        }

        private void aplicarCambiosBtn_Click(object sender, EventArgs e)
        {

            String consultaIDFuncionalidad = "SELECT ID_Funcionalidad " +
                                   "FROM AEFI.TL_Funcionalidad f " +
                                   "WHERE Descripcion = @descripcion";

            try
            {
                conexion.Open();
                SqlCommand comando;
                String ID_Funcionalidad;
       
              
                for (int i = 0; i < checkedListBox.Items.Count; i++)
                {
                    comando = new SqlCommand(consultaIDFuncionalidad, conexion);
                    comando.Parameters.Add(new SqlParameter("@descripcion", Convert.ToString(checkedListBox.Items[i])));
                    SqlDataReader reader = comando.ExecuteReader();
                    reader.Read();
                    ID_Funcionalidad = Convert.ToString(reader["ID_Funcionalidad"]);
                    reader.Close();
                    

                    if (checkedListBox.GetItemCheckState(i) == CheckState.Unchecked)
                    { // todas las no seleccionadas



                        comando = new SqlCommand("AEFI.eliminar_funcionalidad_rol", conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@ID_Funcionalidad", ID_Funcionalidad));
                        comando.Parameters.Add(new SqlParameter("@ID_Rol", rolSeleccionado));
                        comando.ExecuteNonQuery();

                    }
                    else
                    {
                        comando = new SqlCommand("AEFI.insertar_rol_funcionalidad", conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@ID_Funcionalidad", ID_Funcionalidad));
                        comando.Parameters.Add(new SqlParameter("@ID_Rol", rolSeleccionado));
                        comando.ExecuteNonQuery();
                    }

                    if (!String.Equals(Convert.ToString(nombreRolBox.Text), Convert.ToString(rolesBox.SelectedItem)) || !String.Equals(Convert.ToString(nombreRolBox.Text), ""))
                    {
                        comando = new SqlCommand("AEFI.modificar_nombre_rol", conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@ID_Rol", rolSeleccionado));
                        comando.Parameters.Add(new SqlParameter("@nombre", nombreRolBox.Text));
                        comando.ExecuteNonQuery();

                    }
                    
                }
                MessageBox.Show("Rol Modificado Exitósamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                estadoChkBox_CheckedChanged(sender, e);
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


        private void estadoChkBox_CheckedChanged (object sender, EventArgs e)
        { 

            try 
            {

            if (estadoChkBox.CheckState  == CheckState.Checked)
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();

                }

                SqlCommand comando = new SqlCommand("AEFI.habilitar_rol", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@ID_Rol", rolSeleccionado));
                comando.ExecuteNonQuery();

                MessageBox.Show("Rol Habilitado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        else
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();

            }
    
                    SqlCommand comando = new SqlCommand("AEFI.inhabilitar_rol", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@ID_Rol", rolSeleccionado));
                    comando.ExecuteNonQuery();
           
                MessageBox.Show("Rol Inhabilitado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            

        }
            }

            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
                this.Close();
            }

        }

        }


                

                



        

    }



