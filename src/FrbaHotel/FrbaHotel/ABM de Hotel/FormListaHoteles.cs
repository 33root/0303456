using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Servicios;
using System.Data.SqlClient;
using FrbaHotel.Menu;




namespace FrbaHotel.Vistas.ABM_de_Hotel
{
    public partial class FormListaDeHoteles : Form
    {                      


        SqlConnection conexion = BaseDeDatos.ObtenerConexion();

        public FormListaDeHoteles()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            FormMenu menu = new FormMenu();
            this.Hide();
            menu.ShowDialog();
            this.Close();
        }

        private void dgvHoteles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormListaDeHoteles_Load(object sender, EventArgs e)
        {

        }
        
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            conexion.Open();


            string Query = "SELECT h.ID_Hotel, h.Nombre, h.Cantidad_Estrellas, h.Ciudad, h.Pais, h.Mail, h.Telefono, h.Calle, h.Fecha_Creacion, h.Nro_Calle, h.Recarga_Estrellas FROM AEFI.TL_Hotel h WHERE h.Cantidad_Estrellas IS NOT NULL";
                



            if (!String.IsNullOrEmpty(tbCantEstrellas.Text))
            {
                String aux = BaseDeDatos.agregarApostrofos(tbCantEstrellas.Text);
                Query = Query + " AND h.Cantidad_Estrellas LIKE " + aux;   
            }

            if (!String.IsNullOrEmpty(tbCiudad.Text))
            {
                String aux = BaseDeDatos.agregarApostrofos("%" + tbCiudad.Text + "%");
                Query = Query + " AND h.Ciudad LIKE " + aux;   
            }

            if (!String.IsNullOrEmpty(tbPais.Text))
            {
                String aux = BaseDeDatos.agregarApostrofos("%" + tbPais.Text + "%");
                Query = Query + " AND h.Pais LIKE " + aux;
            }

           


           // falta Nombre, Pais...
           

            

           SqlDataAdapter adapter = new SqlDataAdapter(Query, conexion);
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            dgvHoteles.DataSource = tabla;
          
          
           conexion.Close();

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvHoteles.DataSource = null;
            tbNombre.Clear();
            tbCantEstrellas.Clear();
            tbCiudad.Clear();
            tbPais.Clear();
        
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvHoteles.SelectedRows)
            {
                FormNuevoHotel alta = new FormNuevoHotel(1, row.Cells);
                this.Hide();
                alta.ShowDialog();
                this.Close();
            }
        }

        private void btnDesabilitar_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dgvHoteles.SelectedRows)
            {
                FormBajaHotel baja = new FormBajaHotel(row.Cells);
                this.Hide();
                baja.ShowDialog();
               
            }
        }

       
    }
}
