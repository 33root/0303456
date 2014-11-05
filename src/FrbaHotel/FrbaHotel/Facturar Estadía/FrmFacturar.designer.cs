namespace FrbaHotel.Facturar_Estadia
{
    partial class FrmFacturar
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
            this.facturarBtn = new System.Windows.Forms.Button();
            this.volverBtn = new System.Windows.Forms.Button();
            this.medioDePagoLbl = new System.Windows.Forms.Label();
            this.medioDePagoCmbBox = new System.Windows.Forms.ComboBox();
            this.estadiaDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.estadiaDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // facturarBtn
            // 
            this.facturarBtn.Location = new System.Drawing.Point(448, 356);
            this.facturarBtn.Name = "facturarBtn";
            this.facturarBtn.Size = new System.Drawing.Size(131, 23);
            this.facturarBtn.TabIndex = 2;
            this.facturarBtn.Text = "Facturar Estadía";
            this.facturarBtn.UseVisualStyleBackColor = true;
            // 
            // volverBtn
            // 
            this.volverBtn.Location = new System.Drawing.Point(611, 356);
            this.volverBtn.Name = "volverBtn";
            this.volverBtn.Size = new System.Drawing.Size(127, 23);
            this.volverBtn.TabIndex = 3;
            this.volverBtn.Text = "Volver";
            this.volverBtn.UseVisualStyleBackColor = true;
            this.volverBtn.Click += new System.EventHandler(this.volverBtn_Click);
            // 
            // medioDePagoLbl
            // 
            this.medioDePagoLbl.AutoSize = true;
            this.medioDePagoLbl.Location = new System.Drawing.Point(13, 316);
            this.medioDePagoLbl.Name = "medioDePagoLbl";
            this.medioDePagoLbl.Size = new System.Drawing.Size(141, 13);
            this.medioDePagoLbl.TabIndex = 3;
            this.medioDePagoLbl.Text = "Seleccionar Medio de Pago:";
            // 
            // medioDePagoCmbBox
            // 
            this.medioDePagoCmbBox.FormattingEnabled = true;
            this.medioDePagoCmbBox.Location = new System.Drawing.Point(161, 316);
            this.medioDePagoCmbBox.Name = "medioDePagoCmbBox";
            this.medioDePagoCmbBox.Size = new System.Drawing.Size(121, 21);
            this.medioDePagoCmbBox.TabIndex = 1;
            // 
            // estadiaDGV
            // 
            this.estadiaDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.estadiaDGV.Location = new System.Drawing.Point(16, 13);
            this.estadiaDGV.Name = "estadiaDGV";
            this.estadiaDGV.Size = new System.Drawing.Size(731, 297);
            this.estadiaDGV.TabIndex = 1;
            // 
            // FrmFacturar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 410);
            this.Controls.Add(this.estadiaDGV);
            this.Controls.Add(this.medioDePagoCmbBox);
            this.Controls.Add(this.medioDePagoLbl);
            this.Controls.Add(this.volverBtn);
            this.Controls.Add(this.facturarBtn);
            this.Name = "FrmFacturar";
            this.Text = "Facturar Estadía";
            this.Load += new System.EventHandler(this.FrmFacturar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.estadiaDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button facturarBtn;
        private System.Windows.Forms.Button volverBtn;
        private System.Windows.Forms.Label medioDePagoLbl;
        private System.Windows.Forms.ComboBox medioDePagoCmbBox;
        private System.Windows.Forms.DataGridView estadiaDGV;
    }
}