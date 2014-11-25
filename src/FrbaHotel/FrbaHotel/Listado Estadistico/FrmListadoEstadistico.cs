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
            listadoCmbBox.Items.Add("Habitaciones con mayor cantidad de DIAS Y VECES que fueron ocupadas");
            listadoCmbBox.Items.Add("Cliente con mayor cantidad de puntos");


        


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

        private void trimestreCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.listadoCmbBox.Enabled = true;

        }

        private void anioTxtBox_TextChanged(object sender, EventArgs e)
        {
            this.trimestreCmbBox.Enabled = true;
        }

        private void listadoCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.listadoBtn.Enabled = true;

        }

        private void volverBtn_Click(object sender, EventArgs e)
        {
               
            FormMenu inicio = new FormMenu();
            this.Hide();
            inicio.ShowDialog();
            this.Close();
        

        }
 
        }

          
 

    }

