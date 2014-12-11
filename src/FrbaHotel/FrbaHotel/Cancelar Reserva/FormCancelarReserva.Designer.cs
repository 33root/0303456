namespace FrbaHotel.Cancelar_Reserva
{
    partial class FormCancelarReserva
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbNumeroDeReserva = new System.Windows.Forms.TextBox();
            this.txbMotivo = new System.Windows.Forms.TextBox();
            this.dtpFechaDeCancelacion = new System.Windows.Forms.DateTimePicker();
            this.CancelarReservaButton = new System.Windows.Forms.Button();
            this.VolverButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero de reserva";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Motivo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(251, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha de cancelacion";
            // 
            // txbNumeroDeReserva
            // 
            this.txbNumeroDeReserva.Location = new System.Drawing.Point(116, 13);
            this.txbNumeroDeReserva.Name = "txbNumeroDeReserva";
            this.txbNumeroDeReserva.Size = new System.Drawing.Size(129, 20);
            this.txbNumeroDeReserva.TabIndex = 3;
            this.txbNumeroDeReserva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbNumeroDeReserva_KeyPress);
            // 
            // txbMotivo
            // 
            this.txbMotivo.Location = new System.Drawing.Point(57, 45);
            this.txbMotivo.Name = "txbMotivo";
            this.txbMotivo.Size = new System.Drawing.Size(514, 20);
            this.txbMotivo.TabIndex = 4;
            this.txbMotivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbMotivo_KeyPress);
            // 
            // dtpFechaDeCancelacion
            // 
            this.dtpFechaDeCancelacion.Checked = false;
            this.dtpFechaDeCancelacion.Enabled = false;
            this.dtpFechaDeCancelacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDeCancelacion.Location = new System.Drawing.Point(371, 13);
            this.dtpFechaDeCancelacion.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpFechaDeCancelacion.MinDate = new System.DateTime(2014, 12, 10, 0, 0, 0, 0);
            this.dtpFechaDeCancelacion.Name = "dtpFechaDeCancelacion";
            this.dtpFechaDeCancelacion.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaDeCancelacion.TabIndex = 5;
            // 
            // CancelarReservaButton
            // 
            this.CancelarReservaButton.Location = new System.Drawing.Point(417, 71);
            this.CancelarReservaButton.Name = "CancelarReservaButton";
            this.CancelarReservaButton.Size = new System.Drawing.Size(154, 23);
            this.CancelarReservaButton.TabIndex = 6;
            this.CancelarReservaButton.Text = "Cancelar Reserva";
            this.CancelarReservaButton.UseVisualStyleBackColor = true;
            this.CancelarReservaButton.Click += new System.EventHandler(this.CancelarReservaButton_Click);
            // 
            // VolverButton
            // 
            this.VolverButton.Location = new System.Drawing.Point(257, 71);
            this.VolverButton.Name = "VolverButton";
            this.VolverButton.Size = new System.Drawing.Size(154, 23);
            this.VolverButton.TabIndex = 7;
            this.VolverButton.Text = "Volver";
            this.VolverButton.UseVisualStyleBackColor = true;
            this.VolverButton.Click += new System.EventHandler(this.VolverButton_Click);
            // 
            // FormCancelarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 112);
            this.Controls.Add(this.VolverButton);
            this.Controls.Add(this.CancelarReservaButton);
            this.Controls.Add(this.dtpFechaDeCancelacion);
            this.Controls.Add(this.txbMotivo);
            this.Controls.Add(this.txbNumeroDeReserva);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormCancelarReserva";
            this.Text = "FormCancelarReserva";
            this.Load += new System.EventHandler(this.FormCancelarReserva_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbNumeroDeReserva;
        private System.Windows.Forms.TextBox txbMotivo;
        private System.Windows.Forms.DateTimePicker dtpFechaDeCancelacion;
        private System.Windows.Forms.Button CancelarReservaButton;
        private System.Windows.Forms.Button VolverButton;
    }
}