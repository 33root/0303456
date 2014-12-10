namespace FrbaHotel.ABM_de_Cliente
{
    partial class FormClienteNuevo
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
            this.label1 = new System.Windows.Forms.Label();
            this.txbNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbApellido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbDocumentoNumero = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTipoDeDocumento = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbMail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbTelefono = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txbDireccion = new System.Windows.Forms.TextBox();
            this.txbNumero = new System.Windows.Forms.TextBox();
            this.txbLocalidad = new System.Windows.Forms.TextBox();
            this.txbPaisOrigen = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.CrearButton = new System.Windows.Forms.Button();
            this.VolverButton = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txbPiso = new System.Windows.Forms.TextBox();
            this.txbDpto = new System.Windows.Forms.TextBox();
            this.LimpiarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // txbNombre
            // 
            this.txbNombre.Location = new System.Drawing.Point(89, 13);
            this.txbNombre.Name = "txbNombre";
            this.txbNombre.Size = new System.Drawing.Size(208, 20);
            this.txbNombre.TabIndex = 1;
            this.txbNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbNombre_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apellido";
            // 
            // txbApellido
            // 
            this.txbApellido.Location = new System.Drawing.Point(89, 44);
            this.txbApellido.Name = "txbApellido";
            this.txbApellido.Size = new System.Drawing.Size(208, 20);
            this.txbApellido.TabIndex = 3;
            this.txbApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbApellido_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Documento";
            // 
            // txbDocumentoNumero
            // 
            this.txbDocumentoNumero.Location = new System.Drawing.Point(89, 72);
            this.txbDocumentoNumero.Name = "txbDocumentoNumero";
            this.txbDocumentoNumero.Size = new System.Drawing.Size(208, 20);
            this.txbDocumentoNumero.TabIndex = 5;
            this.txbDocumentoNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbDocumentoNumero_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tipo de documento";
            // 
            // cbTipoDeDocumento
            // 
            this.cbTipoDeDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoDeDocumento.FormattingEnabled = true;
            this.cbTipoDeDocumento.Location = new System.Drawing.Point(122, 100);
            this.cbTipoDeDocumento.Name = "cbTipoDeDocumento";
            this.cbTipoDeDocumento.Size = new System.Drawing.Size(175, 21);
            this.cbTipoDeDocumento.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Mail";
            // 
            // txbMail
            // 
            this.txbMail.Location = new System.Drawing.Point(89, 130);
            this.txbMail.Name = "txbMail";
            this.txbMail.Size = new System.Drawing.Size(208, 20);
            this.txbMail.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Telefono";
            // 
            // txbTelefono
            // 
            this.txbTelefono.Location = new System.Drawing.Point(89, 160);
            this.txbTelefono.Name = "txbTelefono";
            this.txbTelefono.Size = new System.Drawing.Size(208, 20);
            this.txbTelefono.TabIndex = 11;
            this.txbTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbTelefono_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Numero";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Calle";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 249);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Localidad";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 276);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Pais de origen";
            // 
            // txbDireccion
            // 
            this.txbDireccion.Location = new System.Drawing.Point(89, 193);
            this.txbDireccion.Name = "txbDireccion";
            this.txbDireccion.Size = new System.Drawing.Size(208, 20);
            this.txbDireccion.TabIndex = 16;
            this.txbDireccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbDireccion_KeyPress);
            // 
            // txbNumero
            // 
            this.txbNumero.Location = new System.Drawing.Point(89, 222);
            this.txbNumero.Name = "txbNumero";
            this.txbNumero.Size = new System.Drawing.Size(208, 20);
            this.txbNumero.TabIndex = 17;
            this.txbNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbCalle_KeyPress);
            // 
            // txbLocalidad
            // 
            this.txbLocalidad.Location = new System.Drawing.Point(89, 249);
            this.txbLocalidad.Name = "txbLocalidad";
            this.txbLocalidad.Size = new System.Drawing.Size(208, 20);
            this.txbLocalidad.TabIndex = 18;
            this.txbLocalidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbLocalidad_KeyPress);
            // 
            // txbPaisOrigen
            // 
            this.txbPaisOrigen.Location = new System.Drawing.Point(89, 276);
            this.txbPaisOrigen.Name = "txbPaisOrigen";
            this.txbPaisOrigen.Size = new System.Drawing.Size(208, 20);
            this.txbPaisOrigen.TabIndex = 19;
            this.txbPaisOrigen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbNacionalidad_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(319, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Fecha de nacimiento";
            // 
            // CrearButton
            // 
            this.CrearButton.Location = new System.Drawing.Point(439, 340);
            this.CrearButton.Name = "CrearButton";
            this.CrearButton.Size = new System.Drawing.Size(75, 23);
            this.CrearButton.TabIndex = 23;
            this.CrearButton.Text = "Crear";
            this.CrearButton.UseVisualStyleBackColor = true;
            this.CrearButton.Click += new System.EventHandler(this.CrearButton_Click);
            // 
            // VolverButton
            // 
            this.VolverButton.Location = new System.Drawing.Point(274, 340);
            this.VolverButton.Name = "VolverButton";
            this.VolverButton.Size = new System.Drawing.Size(75, 23);
            this.VolverButton.TabIndex = 24;
            this.VolverButton.Text = "Volver";
            this.VolverButton.UseVisualStyleBackColor = true;
            this.VolverButton.Click += new System.EventHandler(this.VolverButton_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(322, 44);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(319, 222);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Piso";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(319, 249);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "Dpto";
            // 
            // txbPiso
            // 
            this.txbPiso.Location = new System.Drawing.Point(370, 221);
            this.txbPiso.Name = "txbPiso";
            this.txbPiso.Size = new System.Drawing.Size(144, 20);
            this.txbPiso.TabIndex = 30;
            this.txbPiso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbPiso_KeyPress);
            // 
            // txbDpto
            // 
            this.txbDpto.Location = new System.Drawing.Point(370, 248);
            this.txbDpto.Name = "txbDpto";
            this.txbDpto.Size = new System.Drawing.Size(144, 20);
            this.txbDpto.TabIndex = 31;
            // 
            // LimpiarButton
            // 
            this.LimpiarButton.Location = new System.Drawing.Point(358, 340);
            this.LimpiarButton.Name = "LimpiarButton";
            this.LimpiarButton.Size = new System.Drawing.Size(75, 23);
            this.LimpiarButton.TabIndex = 34;
            this.LimpiarButton.Text = "Limpiar";
            this.LimpiarButton.UseVisualStyleBackColor = true;
            this.LimpiarButton.Click += new System.EventHandler(this.LimpiarButton_Click);
            // 
            // FormClienteNuevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 384);
            this.Controls.Add(this.LimpiarButton);
            this.Controls.Add(this.txbDpto);
            this.Controls.Add(this.txbPiso);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.VolverButton);
            this.Controls.Add(this.CrearButton);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txbPaisOrigen);
            this.Controls.Add(this.txbLocalidad);
            this.Controls.Add(this.txbNumero);
            this.Controls.Add(this.txbDireccion);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txbTelefono);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txbMail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbTipoDeDocumento);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbDocumentoNumero);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbApellido);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbNombre);
            this.Controls.Add(this.label1);
            this.Name = "FormClienteNuevo";
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.FormClienteNuevo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbApellido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbDocumentoNumero;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbTipoDeDocumento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbMail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbTelefono;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txbDireccion;
        private System.Windows.Forms.TextBox txbNumero;
        private System.Windows.Forms.TextBox txbLocalidad;
        private System.Windows.Forms.TextBox txbPaisOrigen;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button CrearButton;
        private System.Windows.Forms.Button VolverButton;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txbPiso;
        private System.Windows.Forms.TextBox txbDpto;
        private System.Windows.Forms.Button LimpiarButton;
    }
}