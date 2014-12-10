﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Menu;
using System.Data.SqlClient;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class FormModificarReserva : Form
    {
        SqlConnection conexion = BaseDeDatos.conectar();

        public FormModificarReserva()
        {
            InitializeComponent();
        }

        private void FormModificarReserva_Load(object sender, EventArgs e)
        {

        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {

            try
            {
                conexion.Open();

                string consulta = "SELECT Fecha_Desde, Cantidad_Huespedes, Cantidad_Noches " +
                                  "FROM AEFI.TL_Reserva " +
                                  "WHERE ID_Reserva = " + BaseDeDatos.agregarApostrofos(txbCodigoReserva.Text);

                DataTable tabla = new DataTable();
                SqlCommand comando = new SqlCommand(consulta, conexion);
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(tabla);
                dataGridView1.DataSource = tabla;
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

        private void modificarButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                /*FormGenerarReserva alta = new FormGenerarReserva(1, row.Cells);// la otra clase no esta terminada :P
                this.Hide();
                alta.ShowDialog();
                this.Close();*/
            }
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            FormMenu inicio = new FormMenu();
            this.Hide();
            inicio.ShowDialog();
            this.Close();
        }
    }
}
