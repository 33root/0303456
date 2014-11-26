namespace FrbaHotel.Facturar_Estadía
{
    partial class FrmTarjeta
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
            this.aceptarBtn = new System.Windows.Forms.Button();
            this.numeroLbl = new System.Windows.Forms.Label();
            this.vencimientoLbl = new System.Windows.Forms.Label();
            this.numeroTxtBox = new System.Windows.Forms.TextBox();
            this.cancelarBtn = new System.Windows.Forms.Button();
            this.vtoCalendar = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // aceptarBtn
            // 
            this.aceptarBtn.Location = new System.Drawing.Point(36, 281);
            this.aceptarBtn.Name = "aceptarBtn";
            this.aceptarBtn.Size = new System.Drawing.Size(140, 23);
            this.aceptarBtn.TabIndex = 0;
            this.aceptarBtn.Text = "Aceptar";
            this.aceptarBtn.UseVisualStyleBackColor = true;
            this.aceptarBtn.Click += new System.EventHandler(this.aceptarBtn_Click);
            // 
            // numeroLbl
            // 
            this.numeroLbl.AutoSize = true;
            this.numeroLbl.Location = new System.Drawing.Point(30, 39);
            this.numeroLbl.Name = "numeroLbl";
            this.numeroLbl.Size = new System.Drawing.Size(47, 13);
            this.numeroLbl.TabIndex = 1;
            this.numeroLbl.Text = "Número:";
            // 
            // vencimientoLbl
            // 
            this.vencimientoLbl.AutoSize = true;
            this.vencimientoLbl.Location = new System.Drawing.Point(33, 93);
            this.vencimientoLbl.Name = "vencimientoLbl";
            this.vencimientoLbl.Size = new System.Drawing.Size(74, 13);
            this.vencimientoLbl.TabIndex = 2;
            this.vencimientoLbl.Text = "Fecha de Vto:";
            // 
            // numeroTxtBox
            // 
            this.numeroTxtBox.Location = new System.Drawing.Point(121, 39);
            this.numeroTxtBox.Name = "numeroTxtBox";
            this.numeroTxtBox.Size = new System.Drawing.Size(100, 20);
            this.numeroTxtBox.TabIndex = 4;
            this.numeroTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeroTxtBox_KeyPress);
            // 
            // cancelarBtn
            // 
            this.cancelarBtn.Location = new System.Drawing.Point(240, 281);
            this.cancelarBtn.Name = "cancelarBtn";
            this.cancelarBtn.Size = new System.Drawing.Size(151, 23);
            this.cancelarBtn.TabIndex = 5;
            this.cancelarBtn.Text = "Cancelar";
            this.cancelarBtn.UseVisualStyleBackColor = true;
            this.cancelarBtn.Click += new System.EventHandler(this.cancelarBtn_Click);
            // 
            // vtoCalendar
            // 
            System.DateTime manana = System.DateTime.Today.AddDays(1);
            this.vtoCalendar.Location = new System.Drawing.Point(119, 93);
            this.vtoCalendar.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.vtoCalendar.MaxSelectionCount = 1;
            this.vtoCalendar.MinDate = manana;
            this.vtoCalendar.Name = "vtoCalendar";
            this.vtoCalendar.TabIndex = 3;
            // 
            // FrmTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 316);
            this.Controls.Add(this.cancelarBtn);
            this.Controls.Add(this.numeroTxtBox);
            this.Controls.Add(this.vtoCalendar);
            this.Controls.Add(this.vencimientoLbl);
            this.Controls.Add(this.numeroLbl);
            this.Controls.Add(this.aceptarBtn);
            this.Name = "FrmTarjeta";
            this.Text = "Datos de Tarjeta de Crédito";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button aceptarBtn;
        private System.Windows.Forms.Label numeroLbl;
        private System.Windows.Forms.Label vencimientoLbl;
        private System.Windows.Forms.TextBox numeroTxtBox;
        private System.Windows.Forms.Button cancelarBtn;
        private System.Windows.Forms.MonthCalendar vtoCalendar;
    }
}