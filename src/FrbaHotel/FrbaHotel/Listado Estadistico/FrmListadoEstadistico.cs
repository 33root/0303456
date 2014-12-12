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


namespace FrbaHotel.Listado_Estadistico
{
    public partial class FrmListadoEstadistico : Form
    {
        SqlConnection conexion = BaseDeDatos.conectar();


        public FrmListadoEstadistico()
        {
            InitializeComponent();
        }

        private void FrmListadoEstadistico_Load(object sender, EventArgs e)
        {
            trimestreCmbBox.Items.Add("Primer Trimestre");
            trimestreCmbBox.Items.Add("Segundo Trimestre");
            trimestreCmbBox.Items.Add("Tercer Trimestre");
            trimestreCmbBox.Items.Add("Cuarto Trimestre");

            listadoCmbBox.Items.Add("Hoteles con mayor cantidad de RESERVAS CANCELADAS");
            listadoCmbBox.Items.Add("Hoteles con mayor cantidad de CONSUMIBLES FACTURADOS");
            listadoCmbBox.Items.Add("Hoteles con mayor cantidad de DIAS FUERA DE SERVICIO");
            listadoCmbBox.Items.Add("Habitaciones con mayor cantidad de DIAS que fueron ocupadas");
            listadoCmbBox.Items.Add("Habitaciones con mayor cantidad de VECES que fueron ocupadas");
            listadoCmbBox.Items.Add("Cliente con mayor cantidad de puntos");

            trimestreCmbBox.SelectedIndex = 0;
            listadoCmbBox.SelectedIndex = 0;

        }

        private void anioTxtBox_KeyPress(object sender, KeyPressEventArgs e)
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



        private void anioTxtBox_TextChanged(object sender, EventArgs e)
        {
            this.trimestreCmbBox.Enabled = true;
            this.listadoCmbBox.Enabled = true;
            this.listadoBtn.Enabled = true;
        }


        private void volverBtn_Click(object sender, EventArgs e)
        {
               
            FormMenu inicio = new FormMenu();
            this.Hide();
            inicio.ShowDialog();
            this.Close();
        

        }

        private void listadoBtn_Click(object sender, EventArgs e)
        {
            string procedimiento = null;
            switch (listadoCmbBox.SelectedIndex)
            {
                case 0:
                    procedimiento = "AEFI.top5_reservasCanceladas";
                    break;
                case 1:
                    procedimiento = "AEFI.top5_consumiblesFacturados";
                    break;
                case 2:
                    procedimiento = "AEFI.top5_diasFueraDeServicio";
                    break;
                case 3:
                    procedimiento = "AEFI.top5_diasOcupados";
                    break;
                case 4:
                    procedimiento = "AEFI.top5_vecesReservada";
                    break;
                case 5:
                    procedimiento = "AEFI.top5_puntosCliente";
                    break;
            }

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand(procedimiento, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@ano", anioTxtBox.Text));
                comando.Parameters.Add(new SqlParameter("@inicio_trimestre",
                    BaseDeDatos.converTrimToInt(trimestreCmbBox.SelectedIndex) + 1));
                comando.Parameters.Add(new SqlParameter("@fin_trimestre",
                    BaseDeDatos.converTrimToInt(trimestreCmbBox.SelectedIndex) + 3));



                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                listadoDGV.DataSource = dataTable;

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


       

        
                                                }
 
        }

          
 

    

