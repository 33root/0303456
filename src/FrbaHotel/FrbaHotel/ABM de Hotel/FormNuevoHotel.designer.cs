namespace FrbaHotel.ABM_de_Hotel
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
            this.nudRecarga = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.lbIdHotel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNroCalle = new System.Windows.Forms.TextBox();
            this.btnCrear = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelPais = new System.Windows.Forms.Label();
            this.tbPais = new System.Windows.Forms.TextBox();
            this.labelCiudad = new System.Windows.Forms.Label();
            this.labelCantEstrellas = new System.Windows.Forms.Label();
            this.labelDireccion = new System.Windows.Forms.Label();
            this.labelTelefono = new System.Windows.Forms.Label();
            this.labelMail = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.tbCiudad = new System.Windows.Forms.TextBox();
            this.tbCantEstrellas = new System.Windows.Forms.TextBox();
            this.tbCalle = new System.Windows.Forms.TextBox();
            this.tbTelefono = new System.Windows.Forms.TextBox();
            this.tbMail = new System.Windows.Forms.TextBox();
            this.tbNombre = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecarga)).BeginInit();
            this.SuspendLayout();
            // 
            // nudRecarga
            // 
            this.nudRecarga.Location = new System.Drawing.Point(106, 124);
            this.nudRecarga.Name = "nudRecarga";
            this.nudRecarga.Size = new System.Drawing.Size(134, 20);
            this.nudRecarga.TabIndex = 48;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(132, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 47;
            this.label4.Text = "ID Hotel:";
            // 
            // lbIdHotel
            // 
            this.lbIdHotel.AutoSize = true;
            this.lbIdHotel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbIdHotel.Location = new System.Drawing.Point(187, 197);
            this.lbIdHotel.Name = "lbIdHotel";
            this.lbIdHotel.Size = new System.Drawing.Size(0, 13);
            this.lbIdHotel.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(319, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "Nro Calle";
            // 
            // tbNroCalle
            // 
            this.tbNroCalle.AccessibleDescription = "";
            this.tbNroCalle.AccessibleName = "";
            this.tbNroCalle.Location = new System.Drawing.Point(399, 61);
            this.tbNroCalle.Name = "tbNroCalle";
            this.tbNroCalle.Size = new System.Drawing.Size(134, 20);
            this.tbNroCalle.TabIndex = 44;
            this.tbNroCalle.Tag = "";
            this.tbNroCalle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNroCalle_KeyPress);
            // 
            // btnCrear
            // 
            this.btnCrear.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCrear.Location = new System.Drawing.Point(313, 209);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(113, 27);
            this.btnCrear.TabIndex = 43;
            this.btnCrear.Text = "Crear Hotel";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnVolver.Location = new System.Drawing.Point(454, 209);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(113, 27);
            this.btnVolver.TabIndex = 42;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(17, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Recarga Estrellas";
            // 
            // labelPais
            // 
            this.labelPais.AutoSize = true;
            this.labelPais.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelPais.Location = new System.Drawing.Point(319, 139);
            this.labelPais.Name = "labelPais";
            this.labelPais.Size = new System.Drawing.Size(27, 13);
            this.labelPais.TabIndex = 38;
            this.labelPais.Text = "Pais";
            // 
            // tbPais
            // 
            this.tbPais.AccessibleDescription = "";
            this.tbPais.AccessibleName = "";
            this.tbPais.Location = new System.Drawing.Point(399, 132);
            this.tbPais.Name = "tbPais";
            this.tbPais.Size = new System.Drawing.Size(134, 20);
            this.tbPais.TabIndex = 37;
            this.tbPais.Tag = "";
            this.tbPais.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPais_KeyPress);
            // 
            // labelCiudad
            // 
            this.labelCiudad.AutoSize = true;
            this.labelCiudad.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCiudad.Location = new System.Drawing.Point(319, 101);
            this.labelCiudad.Name = "labelCiudad";
            this.labelCiudad.Size = new System.Drawing.Size(40, 13);
            this.labelCiudad.TabIndex = 36;
            this.labelCiudad.Text = "Ciudad";
            // 
            // labelCantEstrellas
            // 
            this.labelCantEstrellas.AutoSize = true;
            this.labelCantEstrellas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCantEstrellas.Location = new System.Drawing.Point(17, 165);
            this.labelCantEstrellas.Name = "labelCantEstrellas";
            this.labelCantEstrellas.Size = new System.Drawing.Size(74, 13);
            this.labelCantEstrellas.TabIndex = 35;
            this.labelCantEstrellas.Text = "Cant. Estrellas";
            // 
            // labelDireccion
            // 
            this.labelDireccion.AutoSize = true;
            this.labelDireccion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelDireccion.Location = new System.Drawing.Point(319, 35);
            this.labelDireccion.Name = "labelDireccion";
            this.labelDireccion.Size = new System.Drawing.Size(30, 13);
            this.labelDireccion.TabIndex = 34;
            this.labelDireccion.Text = "Calle";
            // 
            // labelTelefono
            // 
            this.labelTelefono.AutoSize = true;
            this.labelTelefono.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelTelefono.Location = new System.Drawing.Point(17, 94);
            this.labelTelefono.Name = "labelTelefono";
            this.labelTelefono.Size = new System.Drawing.Size(49, 13);
            this.labelTelefono.TabIndex = 33;
            this.labelTelefono.Text = "Telefono";
            // 
            // labelMail
            // 
            this.labelMail.AutoSize = true;
            this.labelMail.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelMail.Location = new System.Drawing.Point(17, 58);
            this.labelMail.Name = "labelMail";
            this.labelMail.Size = new System.Drawing.Size(26, 13);
            this.labelMail.TabIndex = 32;
            this.labelMail.Text = "Mail";
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelNombre.Location = new System.Drawing.Point(17, 20);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(44, 13);
            this.labelNombre.TabIndex = 31;
            this.labelNombre.Text = "Nombre";
            // 
            // tbCiudad
            // 
            this.tbCiudad.AccessibleDescription = "";
            this.tbCiudad.AccessibleName = "";
            this.tbCiudad.Location = new System.Drawing.Point(399, 94);
            this.tbCiudad.Name = "tbCiudad";
            this.tbCiudad.Size = new System.Drawing.Size(134, 20);
            this.tbCiudad.TabIndex = 30;
            this.tbCiudad.Tag = "";
            this.tbCiudad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCiudad_KeyPress);
            // 
            // tbCantEstrellas
            // 
            this.tbCantEstrellas.AccessibleDescription = "";
            this.tbCantEstrellas.AccessibleName = "";
            this.tbCantEstrellas.Location = new System.Drawing.Point(106, 160);
            this.tbCantEstrellas.Name = "tbCantEstrellas";
            this.tbCantEstrellas.Size = new System.Drawing.Size(134, 20);
            this.tbCantEstrellas.TabIndex = 29;
            this.tbCantEstrellas.Tag = "";
            this.tbCantEstrellas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCantEstrellas_KeyPress);
            // 
            // tbCalle
            // 
            this.tbCalle.AccessibleDescription = "";
            this.tbCalle.AccessibleName = "";
            this.tbCalle.Location = new System.Drawing.Point(399, 28);
            this.tbCalle.Name = "tbCalle";
            this.tbCalle.Size = new System.Drawing.Size(200, 20);
            this.tbCalle.TabIndex = 28;
            this.tbCalle.Tag = "";
            // 
            // tbTelefono
            // 
            this.tbTelefono.AccessibleDescription = "";
            this.tbTelefono.AccessibleName = "";
            this.tbTelefono.Location = new System.Drawing.Point(106, 86);
            this.tbTelefono.Name = "tbTelefono";
            this.tbTelefono.Size = new System.Drawing.Size(134, 20);
            this.tbTelefono.TabIndex = 27;
            this.tbTelefono.Tag = "";
            this.tbTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTelefono_KeyPress);
            // 
            // tbMail
            // 
            this.tbMail.AccessibleDescription = "";
            this.tbMail.AccessibleName = "";
            this.tbMail.Location = new System.Drawing.Point(106, 50);
            this.tbMail.Name = "tbMail";
            this.tbMail.Size = new System.Drawing.Size(134, 20);
            this.tbMail.TabIndex = 26;
            this.tbMail.Tag = "";
            // 
            // tbNombre
            // 
            this.tbNombre.AccessibleDescription = "";
            this.tbNombre.AccessibleName = "";
            this.tbNombre.Location = new System.Drawing.Point(106, 12);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(134, 20);
            this.tbNombre.TabIndex = 25;
            this.tbNombre.Tag = "";
            // 
            // FormNuevoHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 248);
            this.Controls.Add(this.nudRecarga);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbIdHotel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbNroCalle);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.label2);
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
            this.Text = "Nuevo Hotel";
            this.Load += new System.EventHandler(this.FormNuevoHotel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudRecarga)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudRecarga;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbIdHotel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNroCalle;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelPais;
        private System.Windows.Forms.TextBox tbPais;
        private System.Windows.Forms.Label labelCiudad;
        private System.Windows.Forms.Label labelCantEstrellas;
        private System.Windows.Forms.Label labelDireccion;
        private System.Windows.Forms.Label labelTelefono;
        private System.Windows.Forms.Label labelMail;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.TextBox tbCiudad;
        private System.Windows.Forms.TextBox tbCantEstrellas;
        private System.Windows.Forms.TextBox tbCalle;
        private System.Windows.Forms.TextBox tbTelefono;
        private System.Windows.Forms.TextBox tbMail;
        private System.Windows.Forms.TextBox tbNombre;
    }
}