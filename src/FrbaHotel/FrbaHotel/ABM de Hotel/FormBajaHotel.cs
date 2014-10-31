using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaHotel.Servicios;

namespace FrbaHotel.Vistas.ABM_de_Hotel
{
    public partial class FormBajaHotel : Form
    {

        public FormBajaHotel()
        {
            InitializeComponent();
        }

        public FormBajaHotel(DataGridViewCellCollection cells)
        {
            InitializeComponent();
            lbNombre.Text = cells[1].Value.ToString();
        }


        private void BajaHotel_Load(object sender, EventArgs e)
        {

        }
    }
}
