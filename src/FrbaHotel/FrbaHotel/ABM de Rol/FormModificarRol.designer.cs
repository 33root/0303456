namespace FrbaHotel.ABM_de_Rol
{
    partial class FormModificarRol
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
            this.rolesBox = new System.Windows.Forms.ComboBox();
            this.confirmarBtn = new System.Windows.Forms.Button();
            this.seleccionarlbl = new System.Windows.Forms.Label();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.funcionalidadeslbl = new System.Windows.Forms.Label();
            this.nombreRolBox = new System.Windows.Forms.TextBox();
            this.nombreLbl = new System.Windows.Forms.Label();
            this.aplicarCambiosBtn = new System.Windows.Forms.Button();
            this.estadoChkBox = new System.Windows.Forms.CheckBox();
            this.cancelarBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rolesBox
            // 
            this.rolesBox.FormattingEnabled = true;
            this.rolesBox.Location = new System.Drawing.Point(135, 54);
            this.rolesBox.Name = "rolesBox";
            this.rolesBox.Size = new System.Drawing.Size(176, 21);
            this.rolesBox.TabIndex = 0;
            // 
            // confirmarBtn
            // 
            this.confirmarBtn.Location = new System.Drawing.Point(144, 91);
            this.confirmarBtn.Name = "confirmarBtn";
            this.confirmarBtn.Size = new System.Drawing.Size(149, 28);
            this.confirmarBtn.TabIndex = 0;
            this.confirmarBtn.Text = "Confirmar";
            this.confirmarBtn.UseVisualStyleBackColor = true;
            this.confirmarBtn.Click += new System.EventHandler(this.confirmarBtn_Click_1);
            // 
            // seleccionarlbl
            // 
            this.seleccionarlbl.AutoSize = true;
            this.seleccionarlbl.Location = new System.Drawing.Point(132, 38);
            this.seleccionarlbl.Name = "seleccionarlbl";
            this.seleccionarlbl.Size = new System.Drawing.Size(183, 13);
            this.seleccionarlbl.TabIndex = 2;
            this.seleccionarlbl.Text = "Seleccione Rol A Modificar o Eliminar";
            // 
            // checkedListBox
            // 
            this.checkedListBox.CheckOnClick = true;
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Location = new System.Drawing.Point(32, 177);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.ScrollAlwaysVisible = true;
            this.checkedListBox.Size = new System.Drawing.Size(143, 184);
            this.checkedListBox.TabIndex = 25;
            this.checkedListBox.ThreeDCheckBoxes = true;
            this.checkedListBox.Visible = false;
            // 
            // funcionalidadeslbl
            // 
            this.funcionalidadeslbl.AutoSize = true;
            this.funcionalidadeslbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funcionalidadeslbl.Location = new System.Drawing.Point(29, 144);
            this.funcionalidadeslbl.Name = "funcionalidadeslbl";
            this.funcionalidadeslbl.Size = new System.Drawing.Size(84, 13);
            this.funcionalidadeslbl.TabIndex = 4;
            this.funcionalidadeslbl.Text = "Funcionalidades";
            this.funcionalidadeslbl.Visible = false;
            // 
            // nombreRolBox
            // 
            this.nombreRolBox.Location = new System.Drawing.Point(285, 217);
            this.nombreRolBox.Name = "nombreRolBox";
            this.nombreRolBox.Size = new System.Drawing.Size(106, 20);
            this.nombreRolBox.TabIndex = 5;
            this.nombreRolBox.Visible = false;
            // 
            // nombreLbl
            // 
            this.nombreLbl.AutoSize = true;
            this.nombreLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreLbl.Location = new System.Drawing.Point(181, 217);
            this.nombreLbl.Name = "nombreLbl";
            this.nombreLbl.Size = new System.Drawing.Size(80, 13);
            this.nombreLbl.TabIndex = 6;
            this.nombreLbl.Text = "Nombre del Rol";
            this.nombreLbl.Visible = false;
            // 
            // aplicarCambiosBtn
            // 
            this.aplicarCambiosBtn.Location = new System.Drawing.Point(32, 378);
            this.aplicarCambiosBtn.Name = "aplicarCambiosBtn";
            this.aplicarCambiosBtn.Size = new System.Drawing.Size(160, 33);
            this.aplicarCambiosBtn.TabIndex = 7;
            this.aplicarCambiosBtn.Text = "Aplicar Cambios";
            this.aplicarCambiosBtn.UseVisualStyleBackColor = true;
            this.aplicarCambiosBtn.Visible = false;
            this.aplicarCambiosBtn.Click += new System.EventHandler(this.aplicarCambiosBtn_Click);
            // 
            // estadoChkBox
            // 
            this.estadoChkBox.AutoSize = true;
            this.estadoChkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.estadoChkBox.Location = new System.Drawing.Point(201, 177);
            this.estadoChkBox.Name = "estadoChkBox";
            this.estadoChkBox.Size = new System.Drawing.Size(92, 17);
            this.estadoChkBox.TabIndex = 8;
            this.estadoChkBox.Text = "Estado Activo";
            this.estadoChkBox.UseVisualStyleBackColor = true;
            this.estadoChkBox.Visible = false;
            // 
            // cancelarBtn
            // 
            this.cancelarBtn.Location = new System.Drawing.Point(235, 378);
            this.cancelarBtn.Name = "cancelarBtn";
            this.cancelarBtn.Size = new System.Drawing.Size(156, 33);
            this.cancelarBtn.TabIndex = 9;
            this.cancelarBtn.Text = "Volver";
            this.cancelarBtn.UseVisualStyleBackColor = true;
            this.cancelarBtn.Click += new System.EventHandler(this.cancelarBtn_Click);
            // 
            // FormModificarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 423);
            this.Controls.Add(this.cancelarBtn);
            this.Controls.Add(this.estadoChkBox);
            this.Controls.Add(this.aplicarCambiosBtn);
            this.Controls.Add(this.nombreLbl);
            this.Controls.Add(this.nombreRolBox);
            this.Controls.Add(this.funcionalidadeslbl);
            this.Controls.Add(this.checkedListBox);
            this.Controls.Add(this.seleccionarlbl);
            this.Controls.Add(this.confirmarBtn);
            this.Controls.Add(this.rolesBox);
            this.Name = "FormModificarRol";
            this.Text = "Modificar Rol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox rolesBox;
        private System.Windows.Forms.Button confirmarBtn;
        private System.Windows.Forms.Label seleccionarlbl;
        private System.Windows.Forms.CheckedListBox checkedListBox;
        private System.Windows.Forms.Label funcionalidadeslbl;
        private System.Windows.Forms.TextBox nombreRolBox;
        private System.Windows.Forms.Label nombreLbl;
        private System.Windows.Forms.Button aplicarCambiosBtn;
        private System.Windows.Forms.CheckBox estadoChkBox;
        private System.Windows.Forms.Button cancelarBtn;

    }
}