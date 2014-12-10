namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class FormGenerarReserva
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
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txbCantidadDeHuespedes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTipoDeHabitacion = new System.Windows.Forms.ComboBox();
            this.checkearDisponibilidadButton = new System.Windows.Forms.Button();
            this.TipoDeRegimen = new System.Windows.Forms.Label();
            this.cbTipoDeRegimen = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.verCostoButton = new System.Windows.Forms.Button();
            this.ingresarButton = new System.Windows.Forms.Button();
            this.txbCantidadDeNoches = new System.Windows.Forms.TextBox();
            this.CancelarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cantidad De Noches";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(16, 49);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpDesde.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cantidad de huespedes";
            // 
            // txbCantidadDeHuespedes
            // 
            this.txbCantidadDeHuespedes.Location = new System.Drawing.Point(16, 92);
            this.txbCantidadDeHuespedes.Name = "txbCantidadDeHuespedes";
            this.txbCantidadDeHuespedes.Size = new System.Drawing.Size(200, 20);
            this.txbCantidadDeHuespedes.TabIndex = 5;
            this.txbCantidadDeHuespedes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbCantidadDeHuespedes_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(232, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tipo de habitacion";
            // 
            // cbTipoDeHabitacion
            // 
            this.cbTipoDeHabitacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoDeHabitacion.FormattingEnabled = true;
            this.cbTipoDeHabitacion.Location = new System.Drawing.Point(235, 92);
            this.cbTipoDeHabitacion.Name = "cbTipoDeHabitacion";
            this.cbTipoDeHabitacion.Size = new System.Drawing.Size(200, 21);
            this.cbTipoDeHabitacion.TabIndex = 7;
            // 
            // checkearDisponibilidadButton
            // 
            this.checkearDisponibilidadButton.Location = new System.Drawing.Point(16, 163);
            this.checkearDisponibilidadButton.Name = "checkearDisponibilidadButton";
            this.checkearDisponibilidadButton.Size = new System.Drawing.Size(419, 23);
            this.checkearDisponibilidadButton.TabIndex = 8;
            this.checkearDisponibilidadButton.Text = "Checkear Disponibilidad";
            this.checkearDisponibilidadButton.UseVisualStyleBackColor = true;
            this.checkearDisponibilidadButton.Click += new System.EventHandler(this.checkearDisponibilidadButton_Click);
            // 
            // TipoDeRegimen
            // 
            this.TipoDeRegimen.AutoSize = true;
            this.TipoDeRegimen.Location = new System.Drawing.Point(16, 119);
            this.TipoDeRegimen.Name = "TipoDeRegimen";
            this.TipoDeRegimen.Size = new System.Drawing.Size(83, 13);
            this.TipoDeRegimen.TabIndex = 9;
            this.TipoDeRegimen.Text = "Tipo de regimen";
            // 
            // cbTipoDeRegimen
            // 
            this.cbTipoDeRegimen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoDeRegimen.FormattingEnabled = true;
            this.cbTipoDeRegimen.Location = new System.Drawing.Point(16, 136);
            this.cbTipoDeRegimen.Name = "cbTipoDeRegimen";
            this.cbTipoDeRegimen.Size = new System.Drawing.Size(200, 21);
            this.cbTipoDeRegimen.TabIndex = 10;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 193);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(419, 150);
            this.dataGridView1.TabIndex = 11;
            // 
            // verCostoButton
            // 
            this.verCostoButton.Location = new System.Drawing.Point(279, 384);
            this.verCostoButton.Name = "verCostoButton";
            this.verCostoButton.Size = new System.Drawing.Size(75, 23);
            this.verCostoButton.TabIndex = 12;
            this.verCostoButton.Text = "Ver Costo";
            this.verCostoButton.UseVisualStyleBackColor = true;
            this.verCostoButton.Click += new System.EventHandler(this.verCostoButton_Click);
            // 
            // ingresarButton
            // 
            this.ingresarButton.Location = new System.Drawing.Point(360, 384);
            this.ingresarButton.Name = "ingresarButton";
            this.ingresarButton.Size = new System.Drawing.Size(75, 23);
            this.ingresarButton.TabIndex = 13;
            this.ingresarButton.Text = "Ingresar";
            this.ingresarButton.UseVisualStyleBackColor = true;
            this.ingresarButton.Click += new System.EventHandler(this.ingresarButton_Click);
            // 
            // txbCantidadDeNoches
            // 
            this.txbCantidadDeNoches.Location = new System.Drawing.Point(235, 49);
            this.txbCantidadDeNoches.Name = "txbCantidadDeNoches";
            this.txbCantidadDeNoches.Size = new System.Drawing.Size(200, 20);
            this.txbCantidadDeNoches.TabIndex = 14;
            this.txbCantidadDeNoches.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbCantidadDeNoches_KeyPress);
            // 
            // CancelarButton
            // 
            this.CancelarButton.Location = new System.Drawing.Point(198, 384);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(75, 23);
            this.CancelarButton.TabIndex = 15;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // FormGenerarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 429);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.txbCantidadDeNoches);
            this.Controls.Add(this.ingresarButton);
            this.Controls.Add(this.verCostoButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbTipoDeRegimen);
            this.Controls.Add(this.TipoDeRegimen);
            this.Controls.Add(this.checkearDisponibilidadButton);
            this.Controls.Add(this.cbTipoDeHabitacion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbCantidadDeHuespedes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormGenerarReserva";
            this.Text = "GenerarReserva";
            this.Load += new System.EventHandler(this.FormGenerarReserva_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbCantidadDeHuespedes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbTipoDeHabitacion;
        private System.Windows.Forms.Button checkearDisponibilidadButton;
        private System.Windows.Forms.Label TipoDeRegimen;
        private System.Windows.Forms.ComboBox cbTipoDeRegimen;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button verCostoButton;
        private System.Windows.Forms.Button ingresarButton;
        private System.Windows.Forms.TextBox txbCantidadDeNoches;
        private System.Windows.Forms.Button CancelarButton;
    }
}