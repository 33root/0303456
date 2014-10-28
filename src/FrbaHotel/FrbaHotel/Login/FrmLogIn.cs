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

namespace FrbaHotel.Login
{
    public partial class FrmLogIn : Form
    {
        SqlConnection conexion = BaseDeDatos.conectar();
        int contador = 3;
        string usuarioVerificar = null;

        public FrmLogIn()
        {
            InitializeComponent();
        }

        private void FrmLogIn_Load(object sender, EventArgs e)
        {
            SqlConnection conexion = BaseDeDatos.conectar();

        }

        private void entrarBtn_Click(object sender, EventArgs e)
        {
            int rolSeleccionado;
            String consulta = "SELECT ID_Rol " +
                                  "FROM AEFI.TL_Rol " +
                                  "WHERE Descripcion = @Descripcion " +
                                  "AND Activo = 1";

            try
            {
                conexion.Open();

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.Add(new SqlParameter("@Descripcion", cxbRol.SelectedItem.ToString()));
                SqlDataReader reader = comando.ExecuteReader();
                reader.Read();
                rolSeleccionado = Convert.ToInt32(reader["ID_Rol"]);
                reader.Close();

                // cargo el rol en la variable global del sistema
                Program.idRol = rolSeleccionado;

                MessageBox.Show("Bienvenido al sistema", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //new de la ventana que se tiene que abrir
                this.Hide();
                //ShowDialog()
                this.Close();
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

        
        private void validarBtn_Click(object sender, EventArgs e)
        {
            String consultaUsuario = "SELECT ID_Usuario, Username, Password, Pass_Temporal, Habilitado " +
                                     "FROM AEFI.TL_Usuario " +
                                     "WHERE Username = @Username";

            String consultaRoles = "SELECT Descripcion " +
                                    "FROM AEFI.TL_Rol r " +
                                    "JOIN AEFI.TL_Usuario_Por_Rol x ON (x.ID_Rol = r.ID_Rol) " +
                                    "JOIN AEFI.TL_Usuario u ON (u.ID_Usuario = x.ID_usuario) " +
                                    "WHERE Username = @Username AND r.Activo = 1";

            try
            {
                conexion.Open(); 
                SqlCommand comando = new SqlCommand(consultaUsuario, conexion);
                comando.Parameters.Add(new SqlParameter("@Username", txbUsuario.Text));
                SqlDataReader reader = comando.ExecuteReader();

                // chequeo que exista el usuario ingresado
                if (!reader.HasRows)
                {
                    throw new Excepciones("Usuario inexistente");
                }

                else
                {
                    reader.Read();
                    int idUsuario = Convert.ToInt32(reader["ID_Usuario"]);
                    bool primerIngreso = Convert.ToBoolean(reader["Pass_Temporal"]);
                    bool habilitado = Convert.ToBoolean(reader["Habilitado"]);
                    string usuario = reader["Username"].ToString();
                    string contrasena = reader["Password"].ToString();
                    reader.Close();
                    cxbRol.Enabled = true;

                    if (!contrasena.Equals(BaseDeDatos.cifrar256(txbContrasena.Text)))
                    {
                        if (usuarioVerificar == null || usuarioVerificar == usuario)
                        {
                            contador--;
                        }
                        else
                        {
                            contador = 2;
                        }

                        usuarioVerificar = usuario;
                        throw new Excepciones("Contraseña incorrecta");
                    }

                    if (!habilitado)
                    {
                        throw new Excepciones("Usuario inhabilitado");
                    }

                    if (primerIngreso)
                    {
                        NuevaClave ingreso = new NuevaClave(usuario);
                        ingreso.ShowDialog();
                    }

                    txbContrasena.Enabled = false;

                    // se cargan las variables globales del sistema
                    Program.idUsuario = idUsuario;
                    Program.usuario = usuario;

                    entrarBtn.Enabled = true;

                    // cargo los roles del usuario logeado que puede elegir
                    comando = new SqlCommand(consultaRoles, conexion);
                    comando.Parameters.Add(new SqlParameter("@Username", usuario));
                    reader = comando.ExecuteReader();
                   // cxbRol.Items.Clear();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            cxbRol.Items.Add(reader["Descripcion"].ToString());
                        }
                        reader.Close();
                        cxbRol.SelectedIndex = 0;
                    }
                    else
                    {
                        reader.Close();
                        MessageBox.Show("No tiene roles asignados", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }




            }
            catch (Excepciones exc)
            {
                MessageBox.Show(exc.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // si ocurrieron 3 intentos fallidos en ingresar la contraseña se inhabilita al usuario
                if (contador == 0)
                {
                    string consultaInhabilitar = "UPDATE AEFI.TL_Usuario" +
                        "SET habilitado = 0 " +
                        "WHERE username = @usuario";
                    SqlCommand comandoInhabilitar = new SqlCommand(consultaInhabilitar, conexion);
                    comandoInhabilitar.Parameters.Add(new SqlParameter("@usuario", txbUsuario.Text));
                    comandoInhabilitar.ExecuteNonQuery();
                    MessageBox.Show("El usuario ha sido inhabilitado por ingresos invalidos", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void salirBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void invitadoBtn_Click(object sender, EventArgs e)
        {

            // cargo el rol de guest en la variable global del sistema
            Program.idRol = 1;

            MessageBox.Show("Bienvenido al sistema, usted ingresó como invitado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //new de la ventana que se tiene que abrir

            FormMenu menu = new FormMenu();
            this.Hide();
            menu.ShowDialog();
            this.Close(); 
        
        }

       


    }
}
