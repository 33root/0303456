namespace FrbaHotel.ABM_de_Cliente
{
    partial class FrmHuesped
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
            this.buscarHuespedButton = new System.Windows.Forms.Button();
            this.nuevoHuespedButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buscarHuespedButton
            // 
            this.buscarHuespedButton.Location = new System.Drawing.Point(42, 43);
            this.buscarHuespedButton.Name = "buscarHuespedButton";
            this.buscarHuespedButton.Size = new System.Drawing.Size(212, 23);
            this.buscarHuespedButton.TabIndex = 0;
            this.buscarHuespedButton.Text = "Buscar Huesped";
            this.buscarHuespedButton.UseVisualStyleBackColor = true;
            this.buscarHuespedButton.Click += new System.EventHandler(this.buscarHuespedButton_Click);
            // 
            // nuevoHuespedButton
            // 
            this.nuevoHuespedButton.Location = new System.Drawing.Point(42, 72);
            this.nuevoHuespedButton.Name = "nuevoHuespedButton";
            this.nuevoHuespedButton.Size = new System.Drawing.Size(212, 23);
            this.nuevoHuespedButton.TabIndex = 1;
            this.nuevoHuespedButton.Text = "Ingresar Nuevo Huesped";
            this.nuevoHuespedButton.UseVisualStyleBackColor = true;
            this.nuevoHuespedButton.Click += new System.EventHandler(this.nuevoHuespedButton_Click);
            // 
            // FrmHuesped
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 140);
            this.Controls.Add(this.nuevoHuespedButton);
            this.Controls.Add(this.buscarHuespedButton);
            this.Name = "FrmHuesped";
            this.Text = "FrmHuesped";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buscarHuespedButton;
        private System.Windows.Forms.Button nuevoHuespedButton;
    }
}