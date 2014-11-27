namespace FrbaHotel.Login
{
    partial class FrmLogIn
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
            this.txbUsuario = new System.Windows.Forms.TextBox();
            this.txbContrasena = new System.Windows.Forms.TextBox();
            this.validarBtn = new System.Windows.Forms.Button();
            this.cxbRol = new System.Windows.Forms.ComboBox();
            this.entrarBtn = new System.Windows.Forms.Button();
            this.invitadoBtn = new System.Windows.Forms.Button();
            this.salirBtn = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hotelCmbBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txbUsuario
            // 
            this.txbUsuario.Location = new System.Drawing.Point(81, 49);
            this.txbUsuario.Name = "txbUsuario";
            this.txbUsuario.Size = new System.Drawing.Size(191, 20);
            this.txbUsuario.TabIndex = 0;
            // 
            // txbContrasena
            // 
            this.txbContrasena.Location = new System.Drawing.Point(81, 119);
            this.txbContrasena.Name = "txbContrasena";
            this.txbContrasena.PasswordChar = '*';
            this.txbContrasena.Size = new System.Drawing.Size(191, 20);
            this.txbContrasena.TabIndex = 1;
            // 
            // validarBtn
            // 
            this.validarBtn.Location = new System.Drawing.Point(27, 154);
            this.validarBtn.Name = "validarBtn";
            this.validarBtn.Size = new System.Drawing.Size(245, 32);
            this.validarBtn.TabIndex = 2;
            this.validarBtn.Text = "Validar";
            this.validarBtn.UseVisualStyleBackColor = true;
            this.validarBtn.Click += new System.EventHandler(this.validarBtn_Click);
            // 
            // cxbRol
            // 
            this.cxbRol.Enabled = false;
            this.cxbRol.FormattingEnabled = true;
            this.cxbRol.Location = new System.Drawing.Point(81, 193);
            this.cxbRol.Name = "cxbRol";
            this.cxbRol.Size = new System.Drawing.Size(191, 21);
            this.cxbRol.TabIndex = 3;
            this.cxbRol.SelectedValueChanged += new System.EventHandler(this.cxbRol_SelectedValueChanged);
            // 
            // entrarBtn
            // 
            this.entrarBtn.Enabled = false;
            this.entrarBtn.Location = new System.Drawing.Point(16, 283);
            this.entrarBtn.Name = "entrarBtn";
            this.entrarBtn.Size = new System.Drawing.Size(107, 38);
            this.entrarBtn.TabIndex = 4;
            this.entrarBtn.Text = "Entrar";
            this.entrarBtn.UseVisualStyleBackColor = true;
            this.entrarBtn.Click += new System.EventHandler(this.entrarBtn_Click);
            // 
            // invitadoBtn
            // 
            this.invitadoBtn.Location = new System.Drawing.Point(196, 283);
            this.invitadoBtn.Name = "invitadoBtn";
            this.invitadoBtn.Size = new System.Drawing.Size(99, 41);
            this.invitadoBtn.TabIndex = 5;
            this.invitadoBtn.Text = "Entrar Como Invitado";
            this.invitadoBtn.UseVisualStyleBackColor = true;
            this.invitadoBtn.Click += new System.EventHandler(this.invitadoBtn_Click);
            // 
            // salirBtn
            // 
            this.salirBtn.Location = new System.Drawing.Point(66, 347);
            this.salirBtn.Name = "salirBtn";
            this.salirBtn.Size = new System.Drawing.Size(166, 23);
            this.salirBtn.TabIndex = 6;
            this.salirBtn.Text = "Salir";
            this.salirBtn.UseVisualStyleBackColor = true;
            this.salirBtn.Click += new System.EventHandler(this.salirBtn_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(13, 49);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblUsuario.TabIndex = 7;
            this.lblUsuario.Text = "Usuario:";
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Location = new System.Drawing.Point(13, 125);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(64, 13);
            this.lblContraseña.TabIndex = 8;
            this.lblContraseña.Text = "Contraseña:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Rol";
            // 
            // hotelCmbBox
            // 
            this.hotelCmbBox.Enabled = false;
            this.hotelCmbBox.FormattingEnabled = true;
            this.hotelCmbBox.Location = new System.Drawing.Point(81, 233);
            this.hotelCmbBox.Name = "hotelCmbBox";
            this.hotelCmbBox.Size = new System.Drawing.Size(191, 21);
            this.hotelCmbBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Hotel";
            // 
            // FrmLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 402);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hotelCmbBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblContraseña);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.salirBtn);
            this.Controls.Add(this.invitadoBtn);
            this.Controls.Add(this.entrarBtn);
            this.Controls.Add(this.cxbRol);
            this.Controls.Add(this.validarBtn);
            this.Controls.Add(this.txbContrasena);
            this.Controls.Add(this.txbUsuario);
            this.Name = "FrmLogIn";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogIn";
            this.Load += new System.EventHandler(this.FrmLogIn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbUsuario;
        private System.Windows.Forms.TextBox txbContrasena;
        private System.Windows.Forms.Button validarBtn;
        private System.Windows.Forms.ComboBox cxbRol;
        private System.Windows.Forms.Button entrarBtn;
        private System.Windows.Forms.Button invitadoBtn;
        private System.Windows.Forms.Button salirBtn;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox hotelCmbBox;
        private System.Windows.Forms.Label label2;
    }
}