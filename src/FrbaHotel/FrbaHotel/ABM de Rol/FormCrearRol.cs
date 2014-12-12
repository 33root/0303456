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
    public partial class FormCrearRol : Form
    {

        SqlConnection conexion = BaseDeDatos.conectar();
        int rolSeleccionado;

        int id_Funcionalidad;

        public FormCrearRol()
        {
            InitializeComponent();
        }

        private void FormCrearRol_Load(object sender, EventArgs e) {
            String consultaFuncionalidades = "SELECT Descripcion " +
                                   "FROM AEFI.TL_Funcionalidad f ";

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand(consultaFuncionalidades, conexion);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    checkedListBox1.Items.Add(Convert.ToString(reader["Descripcion"]));

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

        private void button1_Click(object sender, EventArgs e)
        {
            FormRol rol = new FormRol();
            this.Hide();
            rol.ShowDialog();
            this.Close();

        }

        private void aceptarBtn_Click(object sender, EventArgs e)
        {

            try
            {
                conexion.Open();
                
                SqlCommand comando = new SqlCommand("AEFI.crear_Rol", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@Nombre", nombreRolTxtBox.Text));
                comando.ExecuteNonQuery();


                String consultaNuevoRolID = "SELECT ID_Rol " +
                                      "FROM AEFI.TL_Rol " +
                                      "WHERE Descripcion = @Descripcion ";


                comando = new SqlCommand(consultaNuevoRolID, conexion);
                comando.Parameters.Add(new SqlParameter("@Descripcion", nombreRolTxtBox.Text));
                SqlDataReader reader = comando.ExecuteReader();


                reader.Read();
                int rolSeleccionado = Convert.ToInt32(reader["ID_Rol"]);
                reader.Close();

                String consultaIDFuncionalidad = "SELECT ID_Funcionalidad " +
                                       "FROM AEFI.TL_Funcionalidad f " +
                                       "WHERE Descripcion = @descripcion";

                 

                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        


                        if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                        {
                            comando = new SqlCommand(consultaIDFuncionalidad, conexion);
                            comando.Parameters.Add(new SqlParameter("@descripcion", Convert.ToString(checkedListBox1.Items[i])));
                            reader = comando.ExecuteReader();
                            
                            reader.Read();
                            id_Funcionalidad = Convert.ToInt32(reader["ID_Funcionalidad"]);
                            reader.Close();

                            comando = new SqlCommand("AEFI.insertar_rol_funcionalidad", conexion);
                            comando.CommandType = CommandType.StoredProcedure;
                            comando.Parameters.Add(new SqlParameter("@ID_Funcionalidad", id_Funcionalidad));
                            comando.Parameters.Add(new SqlParameter("@ID_Rol", rolSeleccionado));
                            comando.ExecuteNonQuery();
                    }
                    }



                    if (estadoChkBox.CheckState == CheckState.Checked)
                    {
                        if (conexion.State == ConnectionState.Closed)
                        {
                            conexion.Open();

                        }

                        comando = new SqlCommand("AEFI.habilitar_rol", conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@ID_Rol", rolSeleccionado));
                        comando.ExecuteNonQuery();
                    }
                
                
                    MessageBox.Show("Rol Creado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
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
        
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void nombreRolTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void estadoChkBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}