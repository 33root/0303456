namespace FrbaHotel.Vistas.ABM_de_Hotel
{
    partial class FormNuevoHotel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNuevoHotel));
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.tbMail = new System.Windows.Forms.TextBox();
            this.tbTelefono = new System.Windows.Forms.TextBox();
            this.tbCalle = new System.Windows.Forms.TextBox();
            this.tbCantEstrellas = new System.Windows.Forms.TextBox();
            this.tbCiudad = new System.Windows.Forms.TextBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelMail = new System.Windows.Forms.Label();
            this.labelTelefono = new System.Windows.Forms.Label();
            this.labelDireccion = new System.Windows.Forms.Label();
            this.labelCantEstrellas = new System.Windows.Forms.Label();
            this.labelCiudad = new System.Windows.Forms.Label();
            this.labelPais = new System.Windows.Forms.Label();
            this.tbPais = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNroCalle = new System.Windows.Forms.TextBox();
            this.lbIdHotel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudRecarga = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecarga)).BeginInit();
            this.SuspendLayout();
            // 
            // tbNombre
            // 
            resources.ApplyResources(this.tbNombre, "tbNombre");
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Tag = "";
            this.tbNombre.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tbMail
            // 
            resources.ApplyResources(this.tbMail, "tbMail");
            this.tbMail.Name = "tbMail";
            this.tbMail.Tag = "";
            // 
            // tbTelefono
            // 
            resources.ApplyResources(this.tbTelefono, "tbTelefono");
            this.tbTelefono.Name = "tbTelefono";
            this.tbTelefono.Tag = "";
            // 
            // tbCalle
            // 
            resources.ApplyResources(this.tbCalle, "tbCalle");
            this.tbCalle.Name = "tbCalle";
            this.tbCalle.Tag = "";
            this.tbCalle.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // tbCantEstrellas
            // 
            resources.ApplyResources(this.tbCantEstrellas, "tbCantEstrellas");
            this.tbCantEstrellas.Name = "tbCantEstrellas";
            this.tbCantEstrellas.Tag = "";
            // 
            // tbCiudad
            // 
            resources.ApplyResources(this.tbCiudad, "tbCiudad");
            this.tbCiudad.Name = "tbCiudad";
            this.tbCiudad.Tag = "";
            // 
            // labelNombre
            // 
            resources.ApplyResources(this.labelNombre, "labelNombre");
            this.labelNombre.Name = "labelNombre";
            // 
            // labelMail
            // 
            resources.ApplyResources(this.labelMail, "labelMail");
            this.labelMail.Name = "labelMail";
            // 
            // labelTelefono
            // 
            resources.ApplyResources(this.labelTelefono, "labelTelefono");
            this.labelTelefono.Name = "labelTelefono";
            // 
            // labelDireccion
            // 
            resources.ApplyResources(this.labelDireccion, "labelDireccion");
            this.labelDireccion.Name = "labelDireccion";
            this.labelDireccion.Click += new System.EventHandler(this.labelDireccion_Click);
            // 
            // labelCantEstrellas
            // 
            resources.ApplyResources(this.labelCantEstrellas, "labelCantEstrellas");
            this.labelCantEstrellas.Name = "labelCantEstrellas";
            // 
            // labelCiudad
            // 
            resources.ApplyResources(this.labelCiudad, "labelCiudad");
            this.labelCiudad.Name = "labelCiudad";
            // 
            // labelPais
            // 
            resources.ApplyResources(this.labelPais, "labelPais");
            this.labelPais.Name = "labelPais";
            // 
            // tbPais
            // 
            resources.ApplyResources(this.tbPais, "tbPais");
            this.tbPais.Name = "tbPais";
            this.tbPais.Tag = "";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.dtpFecha, "dtpFecha");
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // btnVolver
            // 
            resources.ApplyResources(this.btnVolver, "btnVolver");
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnCrear
            // 
            resources.ApplyResources(this.btnCrear, "btnCrear");
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // tbNroCalle
            // 
            resources.ApplyResources(this.tbNroCalle, "tbNroCalle");
            this.tbNroCalle.Name = "tbNroCalle";
            this.tbNroCalle.Tag = "";
            // 
            // lbIdHotel
            // 
            resources.ApplyResources(this.lbIdHotel, "lbIdHotel");
            this.lbIdHotel.Name = "lbIdHotel";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // nudRecarga
            // 
            resources.ApplyResources(this.nudRecarga, "nudRecarga");
            this.nudRecarga.Name = "nudRecarga";
            // 
            // FormNuevoHotel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nudRecarga);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbIdHotel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbNroCalle);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.labelPais);
            this.Controls.Add(this.tbPais);
            this.Controls.Add(this.labelCiudad);
            this.Controls.Add(this.labelCantEstrellas);
            this.Controls.Add(this.labelDireccion);
            this.Controls.Add(this.labelTelefono);
            this.Controls.Add(this.labelMail);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.tbCiudad);
            this.Controls.Add(this.tbCantEstrellas);
            this.Controls.Add(this.tbCalle);
            this.Controls.Add(this.tbTelefono);
            this.Controls.Add(this.tbMail);
            this.Controls.Add(this.tbNombre);
            this.Name = "FormNuevoHotel";
            this.Load += new System.EventHandler(this.FormHotel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudRecarga)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.TextBox tbMail;
        private System.Windows.Forms.TextBox tbTelefono;
        private System.Windows.Forms.TextBox tbCalle;
        private System.Windows.Forms.TextBox tbCantEstrellas;
        private System.Windows.Forms.TextBox tbCiudad;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelMail;
        private System.Windows.Forms.Label labelTelefono;
        private System.Windows.Forms.Label labelDireccion;
        private System.Windows.Forms.Label labelCantEstrellas;
        private System.Windows.Forms.Label labelCiudad;
        private System.Windows.Forms.Label labelPais;
        private System.Windows.Forms.TextBox tbPais;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNroCalle;
        private System.Windows.Forms.Label lbIdHotel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudRecarga;
    }
}