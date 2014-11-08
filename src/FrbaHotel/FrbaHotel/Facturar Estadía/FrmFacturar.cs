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

namespace FrbaHotel.Facturar_Estadia
{
    public partial class FrmFacturar : Form
    {

        SqlConnection conexion = BaseDeDatos.conectar();

        public FrmFacturar()
        {
            InitializeComponent();
        }


        private void FrmFacturar_Load(object sender, EventArgs e)
        {

            String cargarEstadias = "SELECT * FROM AEFI.TL_Estadia";

          
            //Cargo las estadias
            conexion.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cargarEstadias, conexion);
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            estadiaDGV.DataSource = tabla;
            conexion.Close();

            //Cargo los medios de pago
          
                medioDePagoCmbBox.Items.Add("Efectivo");
                medioDePagoCmbBox.Items.Add("Tarjeta de Crédito");
            






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
