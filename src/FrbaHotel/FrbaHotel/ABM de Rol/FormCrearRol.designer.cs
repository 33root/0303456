namespace FrbaHotel.ABM_de_Rol
{
    partial class FormCrearRol
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
            this.nombreRolLbl = new System.Windows.Forms.Label();
            this.nombreRolTxtBox = new System.Windows.Forms.TextBox();
            this.funcionalidadesLbl = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.estadoChkBox = new System.Windows.Forms.CheckBox();
            this.aceptarBtn = new System.Windows.Forms.Button();
            this.cancelarBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nombreRolLbl
            // 
            this.nombreRolLbl.AutoSize = true;
            this.nombreRolLbl.Location = new System.Drawing.Point(12, 55);
            this.nombreRolLbl.Name = "nombreRolLbl";
            this.nombreRolLbl.Size = new System.Drawing.Size(80, 13);
            this.nombreRolLbl.TabIndex = 0;
            this.nombreRolLbl.Text = "Nombre del Rol";
            // 
            // nombreRolTxtBox
            // 
            this.nombreRolTxtBox.AcceptsReturn = true;
            this.nombreRolTxtBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.nombreRolTxtBox.Location = new System.Drawing.Point(129, 52);
            this.nombreRolTxtBox.Name = "nombreRolTxtBox";
            this.nombreRolTxtBox.Size = new System.Drawing.Size(100, 20);
            this.nombreRolTxtBox.TabIndex = 1;
            this.nombreRolTxtBox.Text = "Nuevo Rol";
            this.nombreRolTxtBox.TextChanged += new System.EventHandler(this.nombreRolTxtBox_TextChanged);
            // 
            // funcionalidadesLbl
            // 
            this.funcionalidadesLbl.AutoSize = true;
            this.funcionalidadesLbl.Location = new System.Drawing.Point(15, 106);
            this.funcionalidadesLbl.Name = "funcionalidadesLbl";
            this.funcionalidadesLbl.Size = new System.Drawing.Size(84, 13);
            this.funcionalidadesLbl.TabIndex = 2;
            this.funcionalidadesLbl.Text = "Funcionalidades";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(129, 106);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 94);
            this.checkedListBox1.TabIndex = 3;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // estadoChkBox
            // 
            this.estadoChkBox.AutoSize = true;
            this.estadoChkBox.Location = new System.Drawing.Point(259, 54);
            this.estadoChkBox.Name = "estadoChkBox";
            this.estadoChkBox.Size = new System.Drawing.Size(92, 17);
            this.estadoChkBox.TabIndex = 4;
            this.estadoChkBox.Text = "Estado Activo";
            this.estadoChkBox.UseVisualStyleBackColor = true;
            this.estadoChkBox.CheckedChanged += new System.EventHandler(this.estadoChkBox_CheckedChanged);
            // 
            // aceptarBtn
            // 
            this.aceptarBtn.Location = new System.Drawing.Point(35, 276);
            this.aceptarBtn.Name = "aceptarBtn";
            this.aceptarBtn.Size = new System.Drawing.Size(97, 39);
            this.aceptarBtn.TabIndex = 5;
            this.aceptarBtn.Text = "Aceptar";
            this.aceptarBtn.UseVisualStyleBackColor = true;
            this.aceptarBtn.Click += new System.EventHandler(this.aceptarBtn_Click);
            // 
            // cancelarBtn
            // 
            this.cancelarBtn.Location = new System.Drawing.Point(225, 276);
            this.cancelarBtn.Name = "cancelarBtn";
            this.cancelarBtn.Size = new System.Drawing.Size(107, 39);
            this.cancelarBtn.TabIndex = 6;
            this.cancelarBtn.Text = "Volver";
            this.cancelarBtn.UseVisualStyleBackColor = true;
            this.cancelarBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormCrearRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 336);
            this.Controls.Add(this.cancelarBtn);
            this.Controls.Add(this.aceptarBtn);
            this.Controls.Add(this.estadoChkBox);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.funcionalidadesLbl);
            this.Controls.Add(this.nombreRolTxtBox);
            this.Controls.Add(this.nombreRolLbl);
            this.Name = "FormCrearRol";
            this.Text = "Crear Nuevo Rol";
            this.Load += new System.EventHandler(this.FormCrearRol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nombreRolLbl;
        private System.Windows.Forms.TextBox nombreRolTxtBox;
        private System.Windows.Forms.Label funcionalidadesLbl;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.CheckBox estadoChkBox;
        private System.Windows.Forms.Button aceptarBtn;
        private System.Windows.Forms.Button cancelarBtn;
    }
}