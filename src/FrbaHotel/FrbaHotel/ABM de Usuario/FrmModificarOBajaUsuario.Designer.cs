namespace FrbaHotel.ABM_de_Usuario
{
    partial class FrmModificarOBajaUsuario
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
            this.usuariosDGV = new System.Windows.Forms.DataGridView();
            this.bajaBtn = new System.Windows.Forms.Button();
            this.modificarBtn = new System.Windows.Forms.Button();
            this.apellidoTxtBox = new System.Windows.Forms.TextBox();
            this.apellidolbl = new System.Windows.Forms.Label();
            this.mailbl = new System.Windows.Forms.Label();
            this.telefonolbl = new System.Windows.Forms.Label();
            this.telefonoTxtBox = new System.Windows.Forms.TextBox();
            this.mailTxtBox = new System.Windows.Forms.TextBox();
            this.hotelesLbl = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.fechalbl = new System.Windows.Forms.Label();
            this.nrodoclbl = new System.Windows.Forms.Label();
            this.nrodocTxtBox = new System.Windows.Forms.TextBox();
            this.tipoDocCmbBox = new System.Windows.Forms.ComboBox();
            this.tipolbl = new System.Windows.Forms.Label();
            this.callelbl = new System.Windows.Forms.Label();
            this.calleTxtBox = new System.Windows.Forms.TextBox();
            this.pisolbl = new System.Windows.Forms.Label();
            this.pisoTxtBox = new System.Windows.Forms.TextBox();
            this.numeroTxtBox = new System.Windows.Forms.TextBox();
            this.nrolbl = new System.Windows.Forms.Label();
            this.dptolbl = new System.Windows.Forms.Label();
            this.dptoTxtBox = new System.Windows.Forms.TextBox();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.aniadirCmbBox = new System.Windows.Forms.ComboBox();
            this.aniadirlbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordTxtBox = new System.Windows.Forms.TextBox();
            this.nombreTxtBox = new System.Windows.Forms.TextBox();
            this.nombrelbl = new System.Windows.Forms.Label();
            this.modiBtn = new System.Windows.Forms.Button();
            this.volverBtn = new System.Windows.Forms.Button();
            this.quitarlbl = new System.Windows.Forms.Label();
            this.quitarcmbBox = new System.Windows.Forms.ComboBox();
            this.hotelesDelRolCmbBox = new System.Windows.Forms.ComboBox();
            this.hotelesDelRolLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // usuariosDGV
            // 
            this.usuariosDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usuariosDGV.Location = new System.Drawing.Point(12, 12);
            this.usuariosDGV.MultiSelect = false;
            this.usuariosDGV.Name = "usuariosDGV";
            this.usuariosDGV.Size = new System.Drawing.Size(637, 191);
            this.usuariosDGV.TabIndex = 0;
            // 
            // bajaBtn
            // 
            this.bajaBtn.Location = new System.Drawing.Point(12, 219);
            this.bajaBtn.Name = "bajaBtn";
            this.bajaBtn.Size = new System.Drawing.Size(150, 32);
            this.bajaBtn.TabIndex = 1;
            this.bajaBtn.Text = "Dar de Baja";
            this.bajaBtn.UseVisualStyleBackColor = true;
            this.bajaBtn.Click += new System.EventHandler(this.bajaBtn_Click);
            // 
            // modificarBtn
            // 
            this.modificarBtn.Location = new System.Drawing.Point(486, 219);
            this.modificarBtn.Name = "modificarBtn";
            this.modificarBtn.Size = new System.Drawing.Size(163, 32);
            this.modificarBtn.TabIndex = 2;
            this.modificarBtn.Text = "Modificar Usuario";
            this.modificarBtn.UseVisualStyleBackColor = true;
            this.modificarBtn.Click += new System.EventHandler(this.modificarBtn_Click);
            // 
            // apellidoTxtBox
            // 
            this.apellidoTxtBox.AccessibleName = "grupo";
            this.apellidoTxtBox.Location = new System.Drawing.Point(428, 316);
            this.apellidoTxtBox.Name = "apellidoTxtBox";
            this.apellidoTxtBox.Size = new System.Drawing.Size(121, 20);
            this.apellidoTxtBox.TabIndex = 52;
            this.apellidoTxtBox.Visible = false;
            // 
            // apellidolbl
            // 
            this.apellidolbl.AccessibleName = "grupo";
            this.apellidolbl.AutoSize = true;
            this.apellidolbl.Location = new System.Drawing.Point(321, 323);
            this.apellidolbl.Name = "apellidolbl";
            this.apellidolbl.Size = new System.Drawing.Size(47, 13);
            this.apellidolbl.TabIndex = 64;
            this.apellidolbl.Text = "Apellido:";
            this.apellidolbl.Visible = false;
            // 
            // mailbl
            // 
            this.mailbl.AccessibleName = "grupo";
            this.mailbl.AutoSize = true;
            this.mailbl.Location = new System.Drawing.Point(321, 362);
            this.mailbl.Name = "mailbl";
            this.mailbl.Size = new System.Drawing.Size(29, 13);
            this.mailbl.TabIndex = 66;
            this.mailbl.Text = "Mail:";
            this.mailbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.mailbl.Visible = false;
            // 
            // telefonolbl
            // 
            this.telefonolbl.AccessibleName = "grupo";
            this.telefonolbl.AutoSize = true;
            this.telefonolbl.Location = new System.Drawing.Point(321, 391);
            this.telefonolbl.Name = "telefonolbl";
            this.telefonolbl.Size = new System.Drawing.Size(52, 13);
            this.telefonolbl.TabIndex = 67;
            this.telefonolbl.Text = "Telefono:";
            this.telefonolbl.Visible = false;
            // 
            // telefonoTxtBox
            // 
            this.telefonoTxtBox.AccessibleName = "grupo";
            this.telefonoTxtBox.Location = new System.Drawing.Point(428, 391);
            this.telefonoTxtBox.Name = "telefonoTxtBox";
            this.telefonoTxtBox.Size = new System.Drawing.Size(121, 20);
            this.telefonoTxtBox.TabIndex = 54;
            this.telefonoTxtBox.Visible = false;
            this.telefonoTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.telefonoTxtBox_KeyPress);
            // 
            // mailTxtBox
            // 
            this.mailTxtBox.AccessibleName = "grupo";
            this.mailTxtBox.Location = new System.Drawing.Point(428, 359);
            this.mailTxtBox.Name = "mailTxtBox";
            this.mailTxtBox.Size = new System.Drawing.Size(121, 20);
            this.mailTxtBox.TabIndex = 53;
            this.mailTxtBox.Visible = false;
            // 
            // hotelesLbl
            // 
            this.hotelesLbl.AccessibleName = "grupo";
            this.hotelesLbl.AutoSize = true;
            this.hotelesLbl.Location = new System.Drawing.Point(165, 591);
            this.hotelesLbl.Name = "hotelesLbl";
            this.hotelesLbl.Size = new System.Drawing.Size(101, 13);
            this.hotelesLbl.TabIndex = 75;
            this.hotelesLbl.Text = "Hotel(es) Asignados";
            this.hotelesLbl.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.AccessibleName = "grupo";
            this.dateTimePicker1.Location = new System.Drawing.Point(457, 433);
            this.dateTimePicker1.MaxDate = new System.DateTime(2010, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(1940, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(121, 20);
            this.dateTimePicker1.TabIndex = 55;
            this.dateTimePicker1.Value = new System.DateTime(2010, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.Visible = false;
            // 
            // fechalbl
            // 
            this.fechalbl.AccessibleName = "grupo";
            this.fechalbl.AutoSize = true;
            this.fechalbl.Location = new System.Drawing.Point(321, 433);
            this.fechalbl.Name = "fechalbl";
            this.fechalbl.Size = new System.Drawing.Size(111, 13);
            this.fechalbl.TabIndex = 69;
            this.fechalbl.Text = "Fecha de Nacimiento:";
            this.fechalbl.Visible = false;
            // 
            // nrodoclbl
            // 
            this.nrodoclbl.AccessibleName = "grupo";
            this.nrodoclbl.AutoSize = true;
            this.nrodoclbl.Location = new System.Drawing.Point(16, 431);
            this.nrodoclbl.Name = "nrodoclbl";
            this.nrodoclbl.Size = new System.Drawing.Size(120, 13);
            this.nrodoclbl.TabIndex = 68;
            this.nrodoclbl.Text = "Numero de Documento:";
            this.nrodoclbl.Visible = false;
            // 
            // nrodocTxtBox
            // 
            this.nrodocTxtBox.AccessibleName = "grupo";
            this.nrodocTxtBox.Location = new System.Drawing.Point(148, 433);
            this.nrodocTxtBox.Name = "nrodocTxtBox";
            this.nrodocTxtBox.Size = new System.Drawing.Size(121, 20);
            this.nrodocTxtBox.TabIndex = 57;
            this.nrodocTxtBox.Visible = false;
            this.nrodocTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nrodocTxtBox_KeyPress);
            // 
            // tipoDocCmbBox
            // 
            this.tipoDocCmbBox.AccessibleName = "grupo";
            this.tipoDocCmbBox.FormattingEnabled = true;
            this.tipoDocCmbBox.Location = new System.Drawing.Point(148, 403);
            this.tipoDocCmbBox.Name = "tipoDocCmbBox";
            this.tipoDocCmbBox.Size = new System.Drawing.Size(121, 21);
            this.tipoDocCmbBox.TabIndex = 56;
            this.tipoDocCmbBox.Visible = false;
            // 
            // tipolbl
            // 
            this.tipolbl.AccessibleName = "grupo";
            this.tipolbl.AutoSize = true;
            this.tipolbl.Location = new System.Drawing.Point(19, 401);
            this.tipolbl.Name = "tipolbl";
            this.tipolbl.Size = new System.Drawing.Size(104, 13);
            this.tipolbl.TabIndex = 70;
            this.tipolbl.Text = "Tipo de Documento:";
            this.tipolbl.Visible = false;
            // 
            // callelbl
            // 
            this.callelbl.AccessibleName = "grupo";
            this.callelbl.AutoSize = true;
            this.callelbl.Location = new System.Drawing.Point(136, 482);
            this.callelbl.Name = "callelbl";
            this.callelbl.Size = new System.Drawing.Size(33, 13);
            this.callelbl.TabIndex = 71;
            this.callelbl.Text = "Calle:";
            this.callelbl.Visible = false;
            // 
            // calleTxtBox
            // 
            this.calleTxtBox.AccessibleName = "grupo";
            this.calleTxtBox.Location = new System.Drawing.Point(190, 482);
            this.calleTxtBox.Name = "calleTxtBox";
            this.calleTxtBox.Size = new System.Drawing.Size(100, 20);
            this.calleTxtBox.TabIndex = 58;
            this.calleTxtBox.Visible = false;
            // 
            // pisolbl
            // 
            this.pisolbl.AccessibleName = "grupo";
            this.pisolbl.AutoSize = true;
            this.pisolbl.Location = new System.Drawing.Point(139, 523);
            this.pisolbl.Name = "pisolbl";
            this.pisolbl.Size = new System.Drawing.Size(30, 13);
            this.pisolbl.TabIndex = 72;
            this.pisolbl.Text = "Piso:";
            this.pisolbl.Visible = false;
            // 
            // pisoTxtBox
            // 
            this.pisoTxtBox.AccessibleName = "grupo";
            this.pisoTxtBox.Location = new System.Drawing.Point(190, 523);
            this.pisoTxtBox.Name = "pisoTxtBox";
            this.pisoTxtBox.Size = new System.Drawing.Size(100, 20);
            this.pisoTxtBox.TabIndex = 60;
            this.pisoTxtBox.Visible = false;
            this.pisoTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pisoTxtBox_KeyPress);
            // 
            // numeroTxtBox
            // 
            this.numeroTxtBox.AccessibleName = "grupo";
            this.numeroTxtBox.Location = new System.Drawing.Point(391, 479);
            this.numeroTxtBox.Name = "numeroTxtBox";
            this.numeroTxtBox.Size = new System.Drawing.Size(65, 20);
            this.numeroTxtBox.TabIndex = 59;
            this.numeroTxtBox.Visible = false;
            this.numeroTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeroTxtBox_KeyPress);
            // 
            // nrolbl
            // 
            this.nrolbl.AccessibleName = "grupo";
            this.nrolbl.AutoSize = true;
            this.nrolbl.Location = new System.Drawing.Point(327, 482);
            this.nrolbl.Name = "nrolbl";
            this.nrolbl.Size = new System.Drawing.Size(47, 13);
            this.nrolbl.TabIndex = 73;
            this.nrolbl.Text = "Número:";
            this.nrolbl.Visible = false;
            // 
            // dptolbl
            // 
            this.dptolbl.AccessibleName = "grupo";
            this.dptolbl.AutoSize = true;
            this.dptolbl.Location = new System.Drawing.Point(309, 520);
            this.dptolbl.Name = "dptolbl";
            this.dptolbl.Size = new System.Drawing.Size(77, 13);
            this.dptolbl.TabIndex = 74;
            this.dptolbl.Text = "Departamento:";
            this.dptolbl.Visible = false;
            // 
            // dptoTxtBox
            // 
            this.dptoTxtBox.AccessibleName = "grupo";
            this.dptoTxtBox.Location = new System.Drawing.Point(391, 520);
            this.dptoTxtBox.Name = "dptoTxtBox";
            this.dptoTxtBox.Size = new System.Drawing.Size(65, 20);
            this.dptoTxtBox.TabIndex = 61;
            this.dptoTxtBox.Visible = false;
            // 
            // checkedListBox
            // 
            this.checkedListBox.AccessibleName = "grupo";
            this.checkedListBox.CheckOnClick = true;
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.HorizontalScrollbar = true;
            this.checkedListBox.Location = new System.Drawing.Point(292, 591);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(191, 64);
            this.checkedListBox.TabIndex = 62;
            this.checkedListBox.Visible = false;
            // 
            // aniadirCmbBox
            // 
            this.aniadirCmbBox.AccessibleName = "grupo";
            this.aniadirCmbBox.FormattingEnabled = true;
            this.aniadirCmbBox.Location = new System.Drawing.Point(145, 366);
            this.aniadirCmbBox.Name = "aniadirCmbBox";
            this.aniadirCmbBox.Size = new System.Drawing.Size(121, 21);
            this.aniadirCmbBox.TabIndex = 78;
            this.aniadirCmbBox.Visible = false;
            // 
            // aniadirlbl
            // 
            this.aniadirlbl.AccessibleName = "grupo";
            this.aniadirlbl.AutoSize = true;
            this.aniadirlbl.Location = new System.Drawing.Point(48, 369);
            this.aniadirlbl.Name = "aniadirlbl";
            this.aniadirlbl.Size = new System.Drawing.Size(59, 13);
            this.aniadirlbl.TabIndex = 83;
            this.aniadirlbl.Text = "Añadir Rol:";
            this.aniadirlbl.Visible = false;
            // 
            // label2
            // 
            this.label2.AccessibleName = "grupo";
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 82;
            this.label2.Text = "Password:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label2.Visible = false;
            // 
            // passwordTxtBox
            // 
            this.passwordTxtBox.AccessibleName = "grupo";
            this.passwordTxtBox.Location = new System.Drawing.Point(145, 269);
            this.passwordTxtBox.Name = "passwordTxtBox";
            this.passwordTxtBox.PasswordChar = '*';
            this.passwordTxtBox.Size = new System.Drawing.Size(121, 20);
            this.passwordTxtBox.TabIndex = 77;
            this.passwordTxtBox.Visible = false;
            // 
            // nombreTxtBox
            // 
            this.nombreTxtBox.AccessibleName = "grupo";
            this.nombreTxtBox.Location = new System.Drawing.Point(428, 279);
            this.nombreTxtBox.Name = "nombreTxtBox";
            this.nombreTxtBox.Size = new System.Drawing.Size(121, 20);
            this.nombreTxtBox.TabIndex = 79;
            this.nombreTxtBox.Visible = false;
            // 
            // nombrelbl
            // 
            this.nombrelbl.AccessibleName = "grupo";
            this.nombrelbl.AutoSize = true;
            this.nombrelbl.Location = new System.Drawing.Point(321, 286);
            this.nombrelbl.Name = "nombrelbl";
            this.nombrelbl.Size = new System.Drawing.Size(47, 13);
            this.nombrelbl.TabIndex = 80;
            this.nombrelbl.Text = "Nombre:";
            this.nombrelbl.Visible = false;
            // 
            // modiBtn
            // 
            this.modiBtn.AccessibleName = "grupo";
            this.modiBtn.Location = new System.Drawing.Point(12, 680);
            this.modiBtn.Name = "modiBtn";
            this.modiBtn.Size = new System.Drawing.Size(204, 33);
            this.modiBtn.TabIndex = 84;
            this.modiBtn.Text = "Modificar";
            this.modiBtn.UseVisualStyleBackColor = true;
            this.modiBtn.Visible = false;
            this.modiBtn.Click += new System.EventHandler(this.modiBtn_Click);
            // 
            // volverBtn
            // 
            this.volverBtn.Location = new System.Drawing.Point(486, 680);
            this.volverBtn.Name = "volverBtn";
            this.volverBtn.Size = new System.Drawing.Size(204, 33);
            this.volverBtn.TabIndex = 85;
            this.volverBtn.Text = "Volver";
            this.volverBtn.UseVisualStyleBackColor = true;
            this.volverBtn.Click += new System.EventHandler(this.volverBtn_Click);
            // 
            // quitarlbl
            // 
            this.quitarlbl.AccessibleName = "grupo";
            this.quitarlbl.AutoSize = true;
            this.quitarlbl.Location = new System.Drawing.Point(45, 338);
            this.quitarlbl.Name = "quitarlbl";
            this.quitarlbl.Size = new System.Drawing.Size(57, 13);
            this.quitarlbl.TabIndex = 86;
            this.quitarlbl.Text = "Quitar Rol:";
            this.quitarlbl.Visible = false;
            // 
            // quitarcmbBox
            // 
            this.quitarcmbBox.AccessibleName = "grupo";
            this.quitarcmbBox.FormattingEnabled = true;
            this.quitarcmbBox.Location = new System.Drawing.Point(145, 334);
            this.quitarcmbBox.Name = "quitarcmbBox";
            this.quitarcmbBox.Size = new System.Drawing.Size(121, 21);
            this.quitarcmbBox.TabIndex = 87;
            this.quitarcmbBox.Visible = false;
            // 
            // hotelesDelRolCmbBox
            // 
            this.hotelesDelRolCmbBox.AccessibleName = "grupo";
            this.hotelesDelRolCmbBox.FormattingEnabled = true;
            this.hotelesDelRolCmbBox.Location = new System.Drawing.Point(292, 564);
            this.hotelesDelRolCmbBox.Name = "hotelesDelRolCmbBox";
            this.hotelesDelRolCmbBox.Size = new System.Drawing.Size(191, 21);
            this.hotelesDelRolCmbBox.TabIndex = 89;
            this.hotelesDelRolCmbBox.Visible = false;
            // 
            // hotelesDelRolLbl
            // 
            this.hotelesDelRolLbl.AccessibleName = "grupo";
            this.hotelesDelRolLbl.AutoSize = true;
            this.hotelesDelRolLbl.Location = new System.Drawing.Point(184, 567);
            this.hotelesDelRolLbl.Name = "hotelesDelRolLbl";
            this.hotelesDelRolLbl.Size = new System.Drawing.Size(82, 13);
            this.hotelesDelRolLbl.TabIndex = 88;
            this.hotelesDelRolLbl.Text = "Hoteles del Rol:";
            this.hotelesDelRolLbl.Visible = false;
            // 
            // FrmModificarOBajaUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 734);
            this.Controls.Add(this.hotelesDelRolCmbBox);
            this.Controls.Add(this.hotelesDelRolLbl);
            this.Controls.Add(this.quitarcmbBox);
            this.Controls.Add(this.quitarlbl);
            this.Controls.Add(this.volverBtn);
            this.Controls.Add(this.modiBtn);
            this.Controls.Add(this.aniadirCmbBox);
            this.Controls.Add(this.aniadirlbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.passwordTxtBox);
            this.Controls.Add(this.nombreTxtBox);
            this.Controls.Add(this.nombrelbl);
            this.Controls.Add(this.hotelesLbl);
            this.Controls.Add(this.checkedListBox);
            this.Controls.Add(this.dptoTxtBox);
            this.Controls.Add(this.dptolbl);
            this.Controls.Add(this.nrolbl);
            this.Controls.Add(this.numeroTxtBox);
            this.Controls.Add(this.pisoTxtBox);
            this.Controls.Add(this.pisolbl);
            this.Controls.Add(this.calleTxtBox);
            this.Controls.Add(this.callelbl);
            this.Controls.Add(this.tipolbl);
            this.Controls.Add(this.tipoDocCmbBox);
            this.Controls.Add(this.nrodocTxtBox);
            this.Controls.Add(this.nrodoclbl);
            this.Controls.Add(this.fechalbl);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.apellidoTxtBox);
            this.Controls.Add(this.mailTxtBox);
            this.Controls.Add(this.telefonoTxtBox);
            this.Controls.Add(this.telefonolbl);
            this.Controls.Add(this.mailbl);
            this.Controls.Add(this.apellidolbl);
            this.Controls.Add(this.modificarBtn);
            this.Controls.Add(this.bajaBtn);
            this.Controls.Add(this.usuariosDGV);
            this.Name = "FrmModificarOBajaUsuario";
            this.Text = "FrmModificarOBajaUsuario";
            this.Load += new System.EventHandler(this.FrmModificarOBajaUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usuariosDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView usuariosDGV;
        private System.Windows.Forms.Button bajaBtn;
        private System.Windows.Forms.Button modificarBtn;
        private System.Windows.Forms.TextBox apellidoTxtBox;
        private System.Windows.Forms.Label apellidolbl;
        private System.Windows.Forms.Label mailbl;
        private System.Windows.Forms.Label telefonolbl;
        private System.Windows.Forms.TextBox telefonoTxtBox;
        private System.Windows.Forms.TextBox mailTxtBox;
        private System.Windows.Forms.Label hotelesLbl;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label fechalbl;
        private System.Windows.Forms.Label nrodoclbl;
        private System.Windows.Forms.TextBox nrodocTxtBox;
        private System.Windows.Forms.ComboBox tipoDocCmbBox;
        private System.Windows.Forms.Label tipolbl;
        private System.Windows.Forms.Label callelbl;
        private System.Windows.Forms.TextBox calleTxtBox;
        private System.Windows.Forms.Label pisolbl;
        private System.Windows.Forms.TextBox pisoTxtBox;
        private System.Windows.Forms.TextBox numeroTxtBox;
        private System.Windows.Forms.Label nrolbl;
        private System.Windows.Forms.Label dptolbl;
        private System.Windows.Forms.TextBox dptoTxtBox;
        private System.Windows.Forms.CheckedListBox checkedListBox;
        private System.Windows.Forms.ComboBox aniadirCmbBox;
        private System.Windows.Forms.Label aniadirlbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwordTxtBox;
        private System.Windows.Forms.TextBox nombreTxtBox;
        private System.Windows.Forms.Label nombrelbl;
        private System.Windows.Forms.Button modiBtn;
        private System.Windows.Forms.Button volverBtn;
        private System.Windows.Forms.Label quitarlbl;
        private System.Windows.Forms.ComboBox quitarcmbBox;
        private System.Windows.Forms.ComboBox hotelesDelRolCmbBox;
        private System.Windows.Forms.Label hotelesDelRolLbl;
    }
}