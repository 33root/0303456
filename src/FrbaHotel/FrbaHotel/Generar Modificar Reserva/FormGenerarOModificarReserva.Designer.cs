namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class FormGenerarOModificarReserva
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
            this.volverButton = new System.Windows.Forms.Button();
            this.GenerarReservaButton = new System.Windows.Forms.Button();
            this.modificarReservaButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // volverButton
            // 
            this.volverButton.Location = new System.Drawing.Point(154, 178);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(75, 23);
            this.volverButton.TabIndex = 0;
            this.volverButton.Text = "Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            this.volverButton.Click += new System.EventHandler(this.volverButton_Click);
            // 
            // GenerarReservaButton
            // 
            this.GenerarReservaButton.Location = new System.Drawing.Point(53, 61);
            this.GenerarReservaButton.Name = "GenerarReservaButton";
            this.GenerarReservaButton.Size = new System.Drawing.Size(138, 71);
            this.GenerarReservaButton.TabIndex = 1;
            this.GenerarReservaButton.Text = "Generar Reserva";
            this.GenerarReservaButton.UseVisualStyleBackColor = true;
            this.GenerarReservaButton.Click += new System.EventHandler(this.GenerarReservaButton_Click);
            // 
            // modificarReservaButton
            // 
            this.modificarReservaButton.Location = new System.Drawing.Point(197, 61);
            this.modificarReservaButton.Name = "modificarReservaButton";
            this.modificarReservaButton.Size = new System.Drawing.Size(138, 71);
            this.modificarReservaButton.TabIndex = 2;
            this.modificarReservaButton.Text = "Modificar Reserva";
            this.modificarReservaButton.UseVisualStyleBackColor = true;
            this.modificarReservaButton.Click += new System.EventHandler(this.modificarReservaButton_Click);
            // 
            // FormGenerarOModificarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 213);
            this.Controls.Add(this.modificarReservaButton);
            this.Controls.Add(this.GenerarReservaButton);
            this.Controls.Add(this.volverButton);
            this.Name = "FormGenerarOModificarReserva";
            this.Text = "Generar o Modificar Reserva";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button volverButton;
        private System.Windows.Forms.Button GenerarReservaButton;
        private System.Windows.Forms.Button modificarReservaButton;
    }
}