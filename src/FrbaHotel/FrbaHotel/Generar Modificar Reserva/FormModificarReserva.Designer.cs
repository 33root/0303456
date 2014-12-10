namespace FrbaHotel.Generar_Modificar_Reserva
{
    partial class FormModificarReserva
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
            this.txbCodigoReserva = new System.Windows.Forms.TextBox();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.modificarButton = new System.Windows.Forms.Button();
            this.volverButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo de reserva";
            // 
            // txbCodigoReserva
            // 
            this.txbCodigoReserva.Location = new System.Drawing.Point(113, 13);
            this.txbCodigoReserva.Name = "txbCodigoReserva";
            this.txbCodigoReserva.Size = new System.Drawing.Size(171, 20);
            this.txbCodigoReserva.TabIndex = 1;
            this.txbCodigoReserva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbCodigoReserva_KeyPress);
            // 
            // BuscarButton
            // 
            this.BuscarButton.Location = new System.Drawing.Point(290, 9);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(192, 23);
            this.BuscarButton.TabIndex = 2;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = true;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(470, 150);
            this.dataGridView1.TabIndex = 3;
            // 
            // modificarButton
            // 
            this.modificarButton.Location = new System.Drawing.Point(290, 195);
            this.modificarButton.Name = "modificarButton";
            this.modificarButton.Size = new System.Drawing.Size(192, 23);
            this.modificarButton.TabIndex = 4;
            this.modificarButton.Text = "Modificar";
            this.modificarButton.UseVisualStyleBackColor = true;
            this.modificarButton.Click += new System.EventHandler(this.modificarButton_Click);
            // 
            // volverButton
            // 
            this.volverButton.Location = new System.Drawing.Point(113, 194);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(170, 23);
            this.volverButton.TabIndex = 5;
            this.volverButton.Text = "Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            this.volverButton.Click += new System.EventHandler(this.volverButton_Click);
            // 
            // FormModificarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 240);
            this.Controls.Add(this.volverButton);
            this.Controls.Add(this.modificarButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.BuscarButton);
            this.Controls.Add(this.txbCodigoReserva);
            this.Controls.Add(this.label1);
            this.Name = "FormModificarReserva";
            this.Text = "FormModificarReserva";
            this.Load += new System.EventHandler(this.FormModificarReserva_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbCodigoReserva;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button modificarButton;
        private System.Windows.Forms.Button volverButton;
    }
}