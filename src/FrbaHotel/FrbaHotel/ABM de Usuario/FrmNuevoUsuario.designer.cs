namespace FrbaHotel.ABM_de_Usuario
{
    partial class FrmNuevoUsuario
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
            this.nuevoUsuarioBtn = new System.Windows.Forms.Button();
            this.cancelarBtn = new System.Windows.Forms.Button();
            this.tipolbl = new System.Windows.Forms.Label();
            this.tipoDocCmbBox = new System.Windows.Forms.ComboBox();
            this.nrodocTxtBox = new System.Windows.Forms.TextBox();
            this.nrodoclbl = new System.Windows.Forms.Label();
            this.fechalbl = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.nombreTxtBox = new System.Windows.Forms.TextBox();
            this.apellidoTxtBox = new System.Windows.Forms.TextBox();
            this.mailTxtBox = new System.Windows.Forms.TextBox();
            this.telefonoTxtBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mailbl = new System.Windows.Forms.Label();
            this.apellidolbl = new System.Windows.Forms.Label();
            this.nombrelbl = new System.Windows.Forms.Label();
            this.rolesBox = new System.Windows.Forms.ComboBox();
            this.rollbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.usuariolbl = new System.Windows.Forms.Label();
            this.passwordTxtBox = new System.Windows.Forms.TextBox();
            this.userTxtBox = new System.Windows.Forms.TextBox();
            this.pisoTxtBox = new System.Windows.Forms.TextBox();
            this.pisolbl = new System.Windows.Forms.Label();
            this.calleTxtBox = new System.Windows.Forms.TextBox();
            this.callelbl = new System.Windows.Forms.Label();
            this.dptoTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nrolbl = new System.Windows.Forms.Label();
            this.numeroTxtBox = new System.Windows.Forms.TextBox();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // nuevoUsuarioBtn
            // 
            this.nuevoUsuarioBtn.Location = new System.Drawing.Point(42, 724);
            this.nuevoUsuarioBtn.Name = "nuevoUsuarioBtn";
            this.nuevoUsuarioBtn.Size = new System.Drawing.Size(167, 23);
            this.nuevoUsuarioBtn.TabIndex = 2;
            this.nuevoUsuarioBtn.Text = "Crear Nuevo Usuario";
            this.nuevoUsuarioBtn.UseVisualStyleBackColor = true;
            this.nuevoUsuarioBtn.Click += new System.EventHandler(this.nuevoUsuarioBtn_Click);
            // 
            // cancelarBtn
            // 
            this.cancelarBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelarBtn.Location = new System.Drawing.Point(268, 724);
            this.cancelarBtn.Name = "cancelarBtn";
            this.cancelarBtn.Size = new System.Drawing.Size(166, 23);
            this.cancelarBtn.TabIndex = 3;
            this.cancelarBtn.Text = "Cancelar";
            this.cancelarBtn.UseVisualStyleBackColor = true;
            this.cancelarBtn.Click += new System.EventHandler(this.cancelarBtn_Click);
            // 
            // tipolbl
            // 
            this.tipolbl.AutoSize = true;
            this.tipolbl.Location = new System.Drawing.Point(43, 451);
            this.tipolbl.Name = "tipolbl";
            this.tipolbl.Size = new System.Drawing.Size(104, 13);
            this.tipolbl.TabIndex = 29;
            this.tipolbl.Text = "Tipo de Documento:";
            // 
            // tipoDocCmbBox
            // 
            this.tipoDocCmbBox.FormattingEnabled = true;
            this.tipoDocCmbBox.Location = new System.Drawing.Point(172, 451);
            this.tipoDocCmbBox.Name = "tipoDocCmbBox";
            this.tipoDocCmbBox.Size = new System.Drawing.Size(121, 21);
            this.tipoDocCmbBox.TabIndex = 24;
            // 
            // nrodocTxtBox
            // 
            this.nrodocTxtBox.Location = new System.Drawing.Point(172, 410);
            this.nrodocTxtBox.Name = "nrodocTxtBox";
            this.nrodocTxtBox.Size = new System.Drawing.Size(121, 20);
            this.nrodocTxtBox.TabIndex = 22;
            // 
            // nrodoclbl
            // 
            this.nrodoclbl.AutoSize = true;
            this.nrodoclbl.Location = new System.Drawing.Point(40, 410);
            this.nrodoclbl.Name = "nrodoclbl";
            this.nrodoclbl.Size = new System.Drawing.Size(120, 13);
            this.nrodoclbl.TabIndex = 20;
            this.nrodoclbl.Text = "Numero de Documento:";
            // 
            // fechalbl
            // 
            this.fechalbl.AutoSize = true;
            this.fechalbl.Location = new System.Drawing.Point(36, 374);
            this.fechalbl.Name = "fechalbl";
            this.fechalbl.Size = new System.Drawing.Size(111, 13);
            this.fechalbl.TabIndex = 28;
            this.fechalbl.Text = "Fecha de Nacimiento:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(172, 374);
            this.dateTimePicker1.MaxDate = new System.DateTime(2010, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(1940, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(121, 20);
            this.dateTimePicker1.TabIndex = 27;
            this.dateTimePicker1.Value = new System.DateTime(2010, 12, 31, 0, 0, 0, 0);
            // 
            // nombreTxtBox
            // 
            this.nombreTxtBox.Location = new System.Drawing.Point(166, 219);
            this.nombreTxtBox.Name = "nombreTxtBox";
            this.nombreTxtBox.Size = new System.Drawing.Size(121, 20);
            this.nombreTxtBox.TabIndex = 26;
            // 
            // apellidoTxtBox
            // 
            this.apellidoTxtBox.Location = new System.Drawing.Point(166, 261);
            this.apellidoTxtBox.Name = "apellidoTxtBox";
            this.apellidoTxtBox.Size = new System.Drawing.Size(121, 20);
            this.apellidoTxtBox.TabIndex = 25;
            // 
            // mailTxtBox
            // 
            this.mailTxtBox.Location = new System.Drawing.Point(166, 299);
            this.mailTxtBox.Name = "mailTxtBox";
            this.mailTxtBox.Size = new System.Drawing.Size(121, 20);
            this.mailTxtBox.TabIndex = 23;
            // 
            // telefonoTxtBox
            // 
            this.telefonoTxtBox.Location = new System.Drawing.Point(166, 334);
            this.telefonoTxtBox.Name = "telefonoTxtBox";
            this.telefonoTxtBox.Size = new System.Drawing.Size(121, 20);
            this.telefonoTxtBox.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 334);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Telefono:";
            // 
            // mailbl
            // 
            this.mailbl.AutoSize = true;
            this.mailbl.Location = new System.Drawing.Point(59, 302);
            this.mailbl.Name = "mailbl";
            this.mailbl.Size = new System.Drawing.Size(29, 13);
            this.mailbl.TabIndex = 18;
            this.mailbl.Text = "Mail:";
            this.mailbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // apellidolbl
            // 
            this.apellidolbl.AutoSize = true;
            this.apellidolbl.Location = new System.Drawing.Point(59, 268);
            this.apellidolbl.Name = "apellidolbl";
            this.apellidolbl.Size = new System.Drawing.Size(47, 13);
            this.apellidolbl.TabIndex = 17;
            this.apellidolbl.Text = "Apellido:";
            // 
            // nombrelbl
            // 
            this.nombrelbl.AutoSize = true;
            this.nombrelbl.Location = new System.Drawing.Point(59, 226);
            this.nombrelbl.Name = "nombrelbl";
            this.nombrelbl.Size = new System.Drawing.Size(47, 13);
            this.nombrelbl.TabIndex = 16;
            this.nombrelbl.Text = "Nombre:";
            // 
            // rolesBox
            // 
            this.rolesBox.FormattingEnabled = true;
            this.rolesBox.Location = new System.Drawing.Point(150, 121);
            this.rolesBox.Name = "rolesBox";
            this.rolesBox.Size = new System.Drawing.Size(121, 21);
            this.rolesBox.TabIndex = 41;
            // 
            // rollbl
            // 
            this.rollbl.AutoSize = true;
            this.rollbl.Location = new System.Drawing.Point(53, 124);
            this.rollbl.Name = "rollbl";
            this.rollbl.Size = new System.Drawing.Size(26, 13);
            this.rollbl.TabIndex = 40;
            this.rollbl.Text = "Rol:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Password:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // usuariolbl
            // 
            this.usuariolbl.AutoSize = true;
            this.usuariolbl.Location = new System.Drawing.Point(53, 40);
            this.usuariolbl.Name = "usuariolbl";
            this.usuariolbl.Size = new System.Drawing.Size(58, 13);
            this.usuariolbl.TabIndex = 38;
            this.usuariolbl.Text = "Username:";
            // 
            // passwordTxtBox
            // 
            this.passwordTxtBox.Location = new System.Drawing.Point(150, 81);
            this.passwordTxtBox.Name = "passwordTxtBox";
            this.passwordTxtBox.PasswordChar = '*';
            this.passwordTxtBox.Size = new System.Drawing.Size(121, 20);
            this.passwordTxtBox.TabIndex = 37;
            // 
            // userTxtBox
            // 
            this.userTxtBox.Location = new System.Drawing.Point(150, 40);
            this.userTxtBox.Name = "userTxtBox";
            this.userTxtBox.Size = new System.Drawing.Size(121, 20);
            this.userTxtBox.TabIndex = 36;
            // 
            // pisoTxtBox
            // 
            this.pisoTxtBox.Location = new System.Drawing.Point(109, 539);
            this.pisoTxtBox.Name = "pisoTxtBox";
            this.pisoTxtBox.Size = new System.Drawing.Size(100, 20);
            this.pisoTxtBox.TabIndex = 45;
            // 
            // pisolbl
            // 
            this.pisolbl.AutoSize = true;
            this.pisolbl.Location = new System.Drawing.Point(58, 539);
            this.pisolbl.Name = "pisolbl";
            this.pisolbl.Size = new System.Drawing.Size(30, 13);
            this.pisolbl.TabIndex = 44;
            this.pisolbl.Text = "Piso:";
            // 
            // calleTxtBox
            // 
            this.calleTxtBox.Location = new System.Drawing.Point(109, 498);
            this.calleTxtBox.Name = "calleTxtBox";
            this.calleTxtBox.Size = new System.Drawing.Size(100, 20);
            this.calleTxtBox.TabIndex = 43;
            // 
            // callelbl
            // 
            this.callelbl.AutoSize = true;
            this.callelbl.Location = new System.Drawing.Point(55, 498);
            this.callelbl.Name = "callelbl";
            this.callelbl.Size = new System.Drawing.Size(33, 13);
            this.callelbl.TabIndex = 42;
            this.callelbl.Text = "Calle:";
            // 
            // dptoTxtBox
            // 
            this.dptoTxtBox.Location = new System.Drawing.Point(310, 536);
            this.dptoTxtBox.Name = "dptoTxtBox";
            this.dptoTxtBox.Size = new System.Drawing.Size(65, 20);
            this.dptoTxtBox.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(228, 536);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Departamento:";
            // 
            // nrolbl
            // 
            this.nrolbl.AutoSize = true;
            this.nrolbl.Location = new System.Drawing.Point(246, 498);
            this.nrolbl.Name = "nrolbl";
            this.nrolbl.Size = new System.Drawing.Size(47, 13);
            this.nrolbl.TabIndex = 47;
            this.nrolbl.Text = "Número:";
            // 
            // numeroTxtBox
            // 
            this.numeroTxtBox.Location = new System.Drawing.Point(310, 495);
            this.numeroTxtBox.Name = "numeroTxtBox";
            this.numeroTxtBox.Size = new System.Drawing.Size(65, 20);
            this.numeroTxtBox.TabIndex = 46;
            // 
            // checkedListBox
            // 
            this.checkedListBox.CheckOnClick = true;
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.HorizontalScrollbar = true;
            this.checkedListBox.Location = new System.Drawing.Point(166, 609);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(191, 64);
            this.checkedListBox.TabIndex = 50;
            // 
            // FrmNuevoUsuario
            // 
            this.AcceptButton = this.nuevoUsuarioBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.CancelButton = this.cancelarBtn;
            this.ClientSize = new System.Drawing.Size(601, 746);
            this.Controls.Add(this.checkedListBox);
            this.Controls.Add(this.dptoTxtBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nrolbl);
            this.Controls.Add(this.numeroTxtBox);
            this.Controls.Add(this.pisoTxtBox);
            this.Controls.Add(this.pisolbl);
            this.Controls.Add(this.calleTxtBox);
            this.Controls.Add(this.callelbl);
            this.Controls.Add(this.rolesBox);
            this.Controls.Add(this.rollbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.usuariolbl);
            this.Controls.Add(this.passwordTxtBox);
            this.Controls.Add(this.userTxtBox);
            this.Controls.Add(this.tipolbl);
            this.Controls.Add(this.tipoDocCmbBox);
            this.Controls.Add(this.nrodocTxtBox);
            this.Controls.Add(this.nrodoclbl);
            this.Controls.Add(this.fechalbl);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.nombreTxtBox);
            this.Controls.Add(this.apellidoTxtBox);
            this.Controls.Add(this.mailTxtBox);
            this.Controls.Add(this.telefonoTxtBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mailbl);
            this.Controls.Add(this.apellidolbl);
            this.Controls.Add(this.nombrelbl);
            this.Controls.Add(this.cancelarBtn);
            this.Controls.Add(this.nuevoUsuarioBtn);
            this.Name = "FrmNuevoUsuario";
            this.Text = "Nuevo Usuario";
            this.Load += new System.EventHandler(this.FrmNuevoUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button nuevoUsuarioBtn;
        private System.Windows.Forms.Button cancelarBtn;
        private System.Windows.Forms.Label tipolbl;
        private System.Windows.Forms.ComboBox tipoDocCmbBox;
        private System.Windows.Forms.TextBox nrodocTxtBox;
        private System.Windows.Forms.Label nrodoclbl;
        private System.Windows.Forms.Label fechalbl;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox nombreTxtBox;
        private System.Windows.Forms.TextBox apellidoTxtBox;
        private System.Windows.Forms.TextBox mailTxtBox;
        private System.Windows.Forms.TextBox telefonoTxtBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label mailbl;
        private System.Windows.Forms.Label apellidolbl;
        private System.Windows.Forms.Label nombrelbl;
        private System.Windows.Forms.ComboBox rolesBox;
        private System.Windows.Forms.Label rollbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label usuariolbl;
        private System.Windows.Forms.TextBox passwordTxtBox;
        private System.Windows.Forms.TextBox userTxtBox;
        private System.Windows.Forms.TextBox pisoTxtBox;
        private System.Windows.Forms.Label pisolbl;
        private System.Windows.Forms.TextBox calleTxtBox;
        private System.Windows.Forms.Label callelbl;
        private System.Windows.Forms.TextBox dptoTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nrolbl;
        private System.Windows.Forms.TextBox numeroTxtBox;
        private System.Windows.Forms.CheckedListBox checkedListBox;
    }
}