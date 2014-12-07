namespace FrbaHotel.ABM_de_Usuario
{
    partial class FrmAbmDeUsuario
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
            this.modificarUsuarioBtn = new System.Windows.Forms.Button();
            this.volverBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nuevoUsuarioBtn
            // 
            this.nuevoUsuarioBtn.Location = new System.Drawing.Point(12, 81);
            this.nuevoUsuarioBtn.Name = "nuevoUsuarioBtn";
            this.nuevoUsuarioBtn.Size = new System.Drawing.Size(117, 47);
            this.nuevoUsuarioBtn.TabIndex = 0;
            this.nuevoUsuarioBtn.Text = "Nuevo Usuario";
            this.nuevoUsuarioBtn.UseVisualStyleBackColor = true;
            this.nuevoUsuarioBtn.Click += new System.EventHandler(this.nuevoUsuarioBtn_Click);
            // 
            // modificarUsuarioBtn
            // 
            this.modificarUsuarioBtn.Location = new System.Drawing.Point(154, 81);
            this.modificarUsuarioBtn.Name = "modificarUsuarioBtn";
            this.modificarUsuarioBtn.Size = new System.Drawing.Size(118, 47);
            this.modificarUsuarioBtn.TabIndex = 1;
            this.modificarUsuarioBtn.Text = "Modificar o Dar de Baja Usuarios";
            this.modificarUsuarioBtn.UseVisualStyleBackColor = true;
            this.modificarUsuarioBtn.Click += new System.EventHandler(this.modificarUsuarioBtn_Click);
            // 
            // volverBtn
            // 
            this.volverBtn.Location = new System.Drawing.Point(101, 227);
            this.volverBtn.Name = "volverBtn";
            this.volverBtn.Size = new System.Drawing.Size(91, 23);
            this.volverBtn.TabIndex = 2;
            this.volverBtn.Text = "Volver";
            this.volverBtn.UseVisualStyleBackColor = true;
            this.volverBtn.Click += new System.EventHandler(this.volverBtn_Click);
            // 
            // FrmAbmDeUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.volverBtn);
            this.Controls.Add(this.modificarUsuarioBtn);
            this.Controls.Add(this.nuevoUsuarioBtn);
            this.Name = "FrmAbmDeUsuario";
            this.Text = "Gestor de Usuarios";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button nuevoUsuarioBtn;
        private System.Windows.Forms.Button modificarUsuarioBtn;
        private System.Windows.Forms.Button volverBtn;
    }
}