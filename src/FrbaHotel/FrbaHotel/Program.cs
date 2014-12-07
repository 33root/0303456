using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Configuration;



namespace FrbaHotel
{

    using FrbaHotel.Login;
    static class Program
    {
        public static string mailUsuario = "";
        public static int idUsuario = 0;
        public static string usuario = "";
        public static int idRol = 0;
        public static int idHotel = 0;
        public static string fecha = ConfigurationSettings.AppSettings["fecha"];
        public static string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        
        

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogIn());
        }
    }
}
