using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace FrbaHotel.ABM_de_Usuario
{
    public partial class FrmModificarOBajaUsuario : Form
    {
        SqlConnection conexion = BaseDeDatos.conectar();
        int idUser;
        string pass;

        public FrmModificarOBajaUsuario()
        {
            InitializeComponent();
        }

        private void FrmModificarOBajaUsuario_Load(object sender, EventArgs e)
        {

            String cargarUsuarios = "SELECT DISTINCT u.Id_Usuario, u.Username, u.Password, u.Habilitado, u.Nombre, u.Apellido, u.ID_Tipo_Documento, u.Documento_Nro, u.Mail, u.Telefono, u.Calle, u.Calle_Nro, u.Piso, u.Dpto, u.Fecha_Nacimiento " +
                                 " FROM AEFI.TL_Usuario u, AEFI.TL_Usuario_Por_Hotel uph WHERE uph.ID_Usuario= u.ID_Usuario " +
                                 " AND u.ID_Usuario = uph.ID_Usuario AND uph.ID_Hotel =" + Program.idHotel +
                                    " AND u.ID_Usuario != " + Program.idUsuario;

            
            try
            {
                //Cargo los usuarios
                conexion.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cargarUsuarios, conexion);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                usuariosDGV.DataSource = tabla;


                conexion.Close();
            }


            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }

        private void modificarBtn_Click(object sender, EventArgs e)
        {
            if (usuariosDGV.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in usuariosDGV.SelectedRows)
                {
                    idUser = Convert.ToInt32(row.Cells["id_usuario"].Value);
                    pass = Convert.ToString(row.Cells["Password"].Value);
                    cargarDatos(row);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Usuario", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }

        private void cargarDatos(DataGridViewRow row)
        {
           
            loadCmbBox();

            label2.Visible = true;
            aniadirlbl.Visible = true;
            tipolbl.Visible = true;
            nrodoclbl.Visible = true;
            nombrelbl.Visible = true;
            apellidolbl.Visible = true;
            hotelesDelRolCmbBox.Visible = true;
            hotelesDelRolLbl.Visible = true;
            mailbl.Visible = true;
            telefonolbl.Visible = true;
            fechalbl.Visible = true;
            callelbl.Visible = true;
            nrolbl.Visible = true;
            pisolbl.Visible = true;
            dptolbl.Visible = true;
            hotelesLbl.Visible = true;
            modiBtn.Visible = true;
            quitarlbl.Visible = true;
            passwordTxtBox.Visible = true;
            tipoDocCmbBox.Visible = true;
            aniadirCmbBox.Visible = true;
            quitarcmbBox.Visible = true;      
            

            nrodocTxtBox.Visible = true;
            nrodocTxtBox.Text = Convert.ToString(row.Cells["Documento_Nro"].Value);
            nombreTxtBox.Visible = true;
            nombreTxtBox.Text = Convert.ToString(row.Cells["Nombre"].Value);
            apellidoTxtBox.Visible = true;
            apellidoTxtBox.Text = Convert.ToString(row.Cells["Apellido"].Value);
            mailTxtBox.Visible = true;
            mailTxtBox.Text = Convert.ToString(row.Cells["Mail"].Value);
            dateTimePicker1.Visible = true;
            dateTimePicker1.Value = Convert.ToDateTime(row.Cells["Fecha_Nacimiento"].Value);
            telefonoTxtBox.Visible = true;
            telefonoTxtBox.Text = Convert.ToString(row.Cells["Telefono"].Value);
            calleTxtBox.Visible = true;
            calleTxtBox.Text = Convert.ToString(row.Cells["Calle"].Value);
            numeroTxtBox.Visible = true;
            numeroTxtBox.Text = Convert.ToString(row.Cells["Calle_Nro"].Value);
            pisoTxtBox.Visible = true;
            pisoTxtBox.Text = Convert.ToString(row.Cells["Piso"].Value);
            dptoTxtBox.Visible = true;
            dptoTxtBox.Text = Convert.ToString(row.Cells["Dpto"].Value);
            checkedListBox.Visible = true;
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                String hotelSeleccionado = Convert.ToString(checkedListBox.Items[i]);
                String consultaHoteles = "SELECT h.Nombre FROM AEFI.TL_Hotel h, AEFI.TL_Usuario_Por_Hotel uph WHERE uph.ID_Usuario = " + idUser + "AND uph.ID_Hotel = h.ID_Hotel AND h.Nombre = @nombreHotel";

                SqlCommand comando = new SqlCommand(consultaHoteles, conexion);
                comando.Parameters.Add(new SqlParameter("@nombreHotel", hotelSeleccionado));

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    checkedListBox.SetItemChecked(i, true);
                }



            }

        }

        private void loadCmbBox()
        {

            String cargarAniadirRoles = "SELECT DISTINCT r.Descripcion FROM AEFI.TL_Rol r, AEFI.TL_Usuario_Por_Rol upr WHERE upr.ID_Rol != r.ID_Rol AND (upr.ID_Usuario = @user OR NOT EXISTS (SELECT * FROM AEFI.TL_Usuario_Por_Rol WHERE ID_Usuario = @user)) ";

            String cargarQuitarRoles = "SELECT DISTINCT r.Descripcion FROM AEFI.TL_Rol r, AEFI.TL_Usuario_Por_Rol upr WHERE upr.ID_Rol = r.ID_Rol AND upr.ID_Usuario = @user ";


            String cargarHoteles = "SELECT Nombre " +
                                    "FROM AEFI.TL_Hotel h ";

            String cargarTipoDocumento = "SELECT Descripcion " +
                                         "FROM AEFI.TL_Tipo_Documento ";

            try
            {
                conexion.Open();
               
                //Cargo los tipos de documento
               SqlCommand comando = new SqlCommand(cargarTipoDocumento, conexion);
                SqlDataReader reader = comando.ExecuteReader();
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

                //Cargo los roles que tiene asignados
                comando = new SqlCommand(cargarQuitarRoles, conexion);
                comando.Parameters.Add(new SqlParameter("@user", idUser));
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    quitarcmbBox.Items.Add(reader["Descripcion"].ToString());
                    hotelesDelRolCmbBox.Items.Add(reader["Descripcion"].ToString());
                    hotelesDelRolCmbBox.SelectedIndex = 0;
                }


                //Cargo los roles que aun no tiene asignados
                comando = new SqlCommand(cargarAniadirRoles, conexion);
                comando.Parameters.Add(new SqlParameter("@user", idUser));

                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    aniadirCmbBox.Items.Add(reader["Descripcion"].ToString());
                   
                }

            }

            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private Boolean verificarTextBoxNoVacios()
        {
            bool textBoxNoVacio = false;

            foreach (Control c in this.Controls)
            {

                if (c is TextBox && c != passwordTxtBox)
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

        private void modiBtn_Click(object sender, EventArgs e)
        {
            if (verificarTextBoxNoVacios())
            {

                try
                {

                    String modificarUsuario = "UPDATE AEFI.TL_Usuario " +
                        "SET Password = @pass, Nombre = @nombre, Apellido = @apellido, Mail = @mail, Fecha_Nacimiento = @fecha " +
                        ", Telefono = @telefono, Calle = @calle, Piso = @piso, Dpto= @dpto, Calle_Nro = @calleNro WHERE ID_Usuario = " + idUser;
                    SqlCommand comando = new SqlCommand(modificarUsuario, conexion);

                    if(passwordTxtBox.Text == string.Empty)
                    {

                        comando.Parameters.Add(new SqlParameter("@Pass", pass));
                    }
                    else{
                    comando.Parameters.Add(new SqlParameter("@pass", BaseDeDatos.cifrar256(passwordTxtBox.Text)));
                    }
                    comando.Parameters.Add(new SqlParameter("@nombre", nombreTxtBox.Text));
                    comando.Parameters.Add(new SqlParameter("@apellido", apellidoTxtBox.Text));
                    comando.Parameters.Add(new SqlParameter("@mail", mailTxtBox.Text));
                    comando.Parameters.Add(new SqlParameter("@fecha", dateTimePicker1.Value.Date));
                    comando.Parameters.Add(new SqlParameter("@telefono", telefonoTxtBox.Text));
                    comando.Parameters.Add(new SqlParameter("@calle", calleTxtBox.Text));
                    comando.Parameters.Add(new SqlParameter("@calleNro", numeroTxtBox.Text));
                    comando.Parameters.Add(new SqlParameter("@dpto", dptoTxtBox.Text));
                    comando.Parameters.Add(new SqlParameter("@piso", pisoTxtBox.Text));
                    comando.ExecuteNonQuery();


                    for (int i = 0; i < checkedListBox.Items.Count; i++)
                    {
                        String consultaIDHotel = "Select ID_Hotel FROM AEFI.TL_Hotel WHERE Nombre = @descripcion";
                        String consultaIDRol = "Select ID_Rol FROM AEFI.TL_Rol WHERE Descripcion = @descripcion";

                        comando = new SqlCommand(consultaIDHotel, conexion);
                        comando.Parameters.Add(new SqlParameter("@descripcion", Convert.ToString(checkedListBox.Items[i])));
                        SqlDataReader reader = comando.ExecuteReader();
                        reader.Read();
                        int IDHotel = Convert.ToInt32(reader["ID_Hotel"]);
                        reader.Close();

                        if (hotelesDelRolCmbBox.SelectedIndex != -1)
                        {
                            comando = new SqlCommand(consultaIDRol, conexion);
                            comando.Parameters.Add(new SqlParameter("@descripcion", Convert.ToString(hotelesDelRolCmbBox.SelectedItem.ToString())));
                            reader = comando.ExecuteReader();
                            reader.Read();
                            int IDRol = Convert.ToInt32(reader["ID_Rol"]);
                            reader.Close();



                            if (checkedListBox.GetItemCheckState(i) == CheckState.Unchecked)
                            { // todas las no seleccionadas



                                comando = new SqlCommand("AEFI.eliminar_Hotel_Usuario", conexion);
                                comando.CommandType = CommandType.StoredProcedure;
                                comando.Parameters.Add(new SqlParameter("@IDHotel", IDHotel));
                                comando.Parameters.Add(new SqlParameter("@IDRol", IDRol));
                                comando.Parameters.Add(new SqlParameter("@IDUser", idUser));
                                comando.ExecuteNonQuery();


                            }
                            else
                            {
                                comando = new SqlCommand("AEFI.insertar_Hotel_Usuario", conexion);
                                comando.CommandType = CommandType.StoredProcedure;
                                comando.Parameters.Add(new SqlParameter("@IDHotel", IDHotel));
                                comando.Parameters.Add(new SqlParameter("@IDRol", IDRol));
                                comando.Parameters.Add(new SqlParameter("@IDUser", idUser));
                                comando.ExecuteNonQuery();
                            }
                        }

                                            
                        }

                    if (aniadirCmbBox.SelectedIndex != -1)
                    {
                        comando = new SqlCommand("AEFI.insertar_Rol_Usuario", conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@Descripcion", aniadirCmbBox.SelectedItem.ToString()));
                        comando.Parameters.Add(new SqlParameter("@user", idUser));
                        comando.ExecuteNonQuery();

                    }

                    if (quitarcmbBox.SelectedIndex != -1)
                    {
                        comando = new SqlCommand("AEFI.quitar_Rol_Usuario", conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@Descripcion", quitarcmbBox.SelectedItem.ToString()));
                        comando.Parameters.Add(new SqlParameter("@user", idUser));
                        comando.ExecuteNonQuery();


                    }
                    MessageBox.Show("Usuario Modificado Exitósamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.volverBtn_Click(this, e);
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
                MessageBox.Show("Complete todo los campos para proseguir", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

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

        private void telefonoTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            permitirSoloNumeros(e);
        }

        private void nrodocTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            permitirSoloNumeros(e);
        }

        private void numeroTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            permitirSoloNumeros(e);
        }

        private void pisoTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            permitirSoloNumeros(e);
        }

        private void bajaBtn_Click(object sender, EventArgs e)
        {
            if (usuariosDGV.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in usuariosDGV.SelectedRows)
                {
                    try
                    {
                        conexion.Open();

                        idUser = Convert.ToInt32(row.Cells["id_usuario"].Value);
                        SqlCommand comando = new SqlCommand("AEFI.deshabilitarUsuario", conexion);
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add(new SqlParameter("@IDUser", idUser));
                        comando.ExecuteNonQuery();

                        MessageBox.Show("Usuario deshabilitado correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.volverBtn_Click(this, e);
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

            else
            {
                MessageBox.Show("Debe seleccionar un Usuario", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void volverBtn_Click(object sender, EventArgs e)
        {
            FrmAbmDeUsuario r = new FrmAbmDeUsuario();
            this.Hide();
            r.ShowDialog();
            this.Close();
        }


        }
    }




        
    

