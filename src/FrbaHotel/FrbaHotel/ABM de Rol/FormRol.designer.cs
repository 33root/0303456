namespace FrbaHotel.ABM_de_Rol
{
    partial class FormRol
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
            this.modificarBtn = new System.Windows.Forms.Button();
            this.crearBtn = new System.Windows.Forms.Button();
            this.cancelarBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // modificarBtn
            // 
            this.modificarBtn.Location = new System.Drawing.Point(314, 78);
            this.modificarBtn.Name = "modificarBtn";
            this.modificarBtn.Size = new System.Drawing.Size(127, 42);
            this.modificarBtn.TabIndex = 0;
            this.modificarBtn.Text = "Modificar o Eliminar Rol Existente";
            this.modificarBtn.UseVisualStyleBackColor = true;
            this.modificarBtn.Click += new System.EventHandler(this.modificarBtn_Click);
            // 
            // crearBtn
            // 
            this.crearBtn.Location = new System.Drawing.Point(78, 78);
            this.crearBtn.Name = "crearBtn";
            this.crearBtn.Size = new System.Drawing.Size(127, 41);
            this.crearBtn.TabIndex = 1;
            this.crearBtn.Text = "Crear Nuevo Rol";
            this.crearBtn.UseVisualStyleBackColor = true;
            this.crearBtn.Click += new System.EventHandler(this.crearBtn_Click);
            // 
            // cancelarBtn
            // 
            this.cancelarBtn.Location = new System.Drawing.Point(438, 184);
            this.cancelarBtn.Name = "cancelarBtn";
            this.cancelarBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelarBtn.TabIndex = 2;
            this.cancelarBtn.Text = "Volver";
            this.cancelarBtn.UseVisualStyleBackColor = true;
            this.cancelarBtn.Click += new System.EventHandler(this.cancelarBtn_Click);
            // 
            // FormRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 219);
            this.Controls.Add(this.cancelarBtn);
            this.Controls.Add(this.crearBtn);
            this.Controls.Add(this.modificarBtn);
            this.Name = "FormRol";
            this.Text = "Administración de Roles";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button modificarBtn;
        private System.Windows.Forms.Button crearBtn;
        private System.Windows.Forms.Button cancelarBtn;

    }
}