namespace FrbaHotel.Registrar_Consumible
{
    partial class FrmRegistrarConsumible
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
            this.volverBtn = new System.Windows.Forms.Button();
            this.lblhabitacion = new System.Windows.Forms.Label();
            this.habitacionTxtBox = new System.Windows.Forms.TextBox();
            this.verConsumiblesBtn = new System.Windows.Forms.Button();
            this.eliminarBtn = new System.Windows.Forms.Button();
            this.agregarConsBtn = new System.Windows.Forms.Button();
            this.consumiblesCmbBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cantidadTxtBox = new System.Windows.Forms.TextBox();
            this.consumiblelbl = new System.Windows.Forms.Label();
            this.facturarBtn = new System.Windows.Forms.Button();
            this.consumibleDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.consumibleDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // volverBtn
            // 
            this.volverBtn.Location = new System.Drawing.Point(362, 303);
            this.volverBtn.Name = "volverBtn";
            this.volverBtn.Size = new System.Drawing.Size(100, 23);
            this.volverBtn.TabIndex = 2;
            this.volverBtn.Text = "Volver";
            this.volverBtn.Click += new System.EventHandler(this.volverBtn_Click);
            // 
            // lblhabitacion
            // 
            this.lblhabitacion.AutoSize = true;
            this.lblhabitacion.Location = new System.Drawing.Point(31, 20);
            this.lblhabitacion.Name = "lblhabitacion";
            this.lblhabitacion.Size = new System.Drawing.Size(61, 13);
            this.lblhabitacion.TabIndex = 3;
            this.lblhabitacion.Text = "Habitacion:";
            // 
            // habitacionTxtBox
            // 
            this.habitacionTxtBox.Location = new System.Drawing.Point(114, 20);
            this.habitacionTxtBox.Name = "habitacionTxtBox";
            this.habitacionTxtBox.Size = new System.Drawing.Size(151, 20);
            this.habitacionTxtBox.TabIndex = 4;
            this.habitacionTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.habitacionTxtBox_KeyPress);
            // 
            // verConsumiblesBtn
            // 
            this.verConsumiblesBtn.Location = new System.Drawing.Point(292, 18);
            this.verConsumiblesBtn.Name = "verConsumiblesBtn";
            this.verConsumiblesBtn.Size = new System.Drawing.Size(133, 23);
            this.verConsumiblesBtn.TabIndex = 5;
            this.verConsumiblesBtn.Text = "Ver Consumibles";
            this.verConsumiblesBtn.UseVisualStyleBackColor = true;
            this.verConsumiblesBtn.Click += new System.EventHandler(this.verConsumiblesBtn_Click);
            // 
            // eliminarBtn
            // 
            this.eliminarBtn.Enabled = false;
            this.eliminarBtn.Location = new System.Drawing.Point(318, 253);
            this.eliminarBtn.Name = "eliminarBtn";
            this.eliminarBtn.Size = new System.Drawing.Size(144, 23);
            this.eliminarBtn.TabIndex = 8;
            this.eliminarBtn.Text = "Eliminar";
            this.eliminarBtn.UseVisualStyleBackColor = true;
            this.eliminarBtn.Click += new System.EventHandler(this.eliminarBtn_Click);
            // 
            // agregarConsBtn
            // 
            this.agregarConsBtn.Enabled = false;
            this.agregarConsBtn.Location = new System.Drawing.Point(114, 83);
            this.agregarConsBtn.Name = "agregarConsBtn";
            this.agregarConsBtn.Size = new System.Drawing.Size(139, 27);
            this.agregarConsBtn.TabIndex = 9;
            this.agregarConsBtn.Text = "Agregar Consumible";
            this.agregarConsBtn.UseVisualStyleBackColor = true;
            this.agregarConsBtn.Click += new System.EventHandler(this.agregarConsBtn_Click);
            // 
            // consumiblesCmbBox
            // 
            this.consumiblesCmbBox.Enabled = false;
            this.consumiblesCmbBox.FormattingEnabled = true;
            this.consumiblesCmbBox.Location = new System.Drawing.Point(114, 47);
            this.consumiblesCmbBox.Name = "consumiblesCmbBox";
            this.consumiblesCmbBox.Size = new System.Drawing.Size(151, 21);
            this.consumiblesCmbBox.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(289, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Cantidad: ";
            // 
            // cantidadTxtBox
            // 
            this.cantidadTxtBox.Enabled = false;
            this.cantidadTxtBox.Location = new System.Drawing.Point(362, 48);
            this.cantidadTxtBox.Name = "cantidadTxtBox";
            this.cantidadTxtBox.Size = new System.Drawing.Size(100, 20);
            this.cantidadTxtBox.TabIndex = 12;
            this.cantidadTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cantidadTxtBox_KeyPress);
            // 
            // consumiblelbl
            // 
            this.consumiblelbl.AutoSize = true;
            this.consumiblelbl.Location = new System.Drawing.Point(31, 55);
            this.consumiblelbl.Name = "consumiblelbl";
            this.consumiblelbl.Size = new System.Drawing.Size(67, 13);
            this.consumiblelbl.TabIndex = 13;
            this.consumiblelbl.Text = "Consumible: ";
            // 
            // facturarBtn
            // 
            this.facturarBtn.Enabled = false;
            this.facturarBtn.Location = new System.Drawing.Point(71, 253);
            this.facturarBtn.Name = "facturarBtn";
            this.facturarBtn.Size = new System.Drawing.Size(160, 23);
            this.facturarBtn.TabIndex = 14;
            this.facturarBtn.Text = "Facturar Consumibles";
            this.facturarBtn.UseVisualStyleBackColor = true;
            this.facturarBtn.Click += new System.EventHandler(this.facturarBtn_Click);
            // 
            // consumibleDGV
            // 
            this.consumibleDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.consumibleDGV.Location = new System.Drawing.Point(71, 116);
            this.consumibleDGV.Name = "consumibleDGV";
            this.consumibleDGV.Size = new System.Drawing.Size(391, 113);
            this.consumibleDGV.TabIndex = 15;
            this.consumibleDGV.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.consumibleDGV_RowHeaderMouseClick);
            // 
            // FrmRegistrarConsumible
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 338);
            this.Controls.Add(this.consumibleDGV);
            this.Controls.Add(this.facturarBtn);
            this.Controls.Add(this.consumiblelbl);
            this.Controls.Add(this.cantidadTxtBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.consumiblesCmbBox);
            this.Controls.Add(this.agregarConsBtn);
            this.Controls.Add(this.eliminarBtn);
            this.Controls.Add(this.verConsumiblesBtn);
            this.Controls.Add(this.habitacionTxtBox);
            this.Controls.Add(this.lblhabitacion);
            this.Controls.Add(this.volverBtn);
            this.Name = "FrmRegistrarConsumible";
            this.Text = "Registrar Consumible";
            this.Load += new System.EventHandler(this.FrmRegistrarConsumible_Load);
            ((System.ComponentModel.ISupportInitialize)(this.consumibleDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button volverBtn;
        private System.Windows.Forms.Label lblhabitacion;
        private System.Windows.Forms.TextBox habitacionTxtBox;
        private System.Windows.Forms.Button verConsumiblesBtn;
        private System.Windows.Forms.Button eliminarBtn;
        private System.Windows.Forms.Button agregarConsBtn;
        private System.Windows.Forms.ComboBox consumiblesCmbBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cantidadTxtBox;
        private System.Windows.Forms.Label consumiblelbl;
        private System.Windows.Forms.Button facturarBtn;
        private System.Windows.Forms.DataGridView consumibleDGV;
    }
}
