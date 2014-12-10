namespace FrbaHotel.Registrar_Estadia
{
    partial class FormRegistroEstadia
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
            this.reservaTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEntrada = new System.Windows.Forms.Button();
            this.salidaBtn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reservaTxtBox
            // 
            this.reservaTxtBox.Location = new System.Drawing.Point(99, 36);
            this.reservaTxtBox.Name = "reservaTxtBox";
            this.reservaTxtBox.Size = new System.Drawing.Size(86, 20);
            this.reservaTxtBox.TabIndex = 0;
            this.reservaTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.reservaTxtBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(96, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "N° de Reserva";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnEntrada
            // 
            this.btnEntrada.Location = new System.Drawing.Point(13, 78);
            this.btnEntrada.Name = "btnEntrada";
            this.btnEntrada.Size = new System.Drawing.Size(89, 33);
            this.btnEntrada.TabIndex = 2;
            this.btnEntrada.Text = "Entrada";
            this.btnEntrada.UseVisualStyleBackColor = true;
            this.btnEntrada.Click += new System.EventHandler(this.btnEntrada_Click);
            // 
            // salidaBtn
            // 
            this.salidaBtn.Location = new System.Drawing.Point(183, 78);
            this.salidaBtn.Name = "salidaBtn";
            this.salidaBtn.Size = new System.Drawing.Size(89, 33);
            this.salidaBtn.TabIndex = 3;
            this.salidaBtn.Text = "Salida";
            this.salidaBtn.UseVisualStyleBackColor = true;
            this.salidaBtn.Click += new System.EventHandler(this.salidaBtn_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(99, 140);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 26);
            this.button3.TabIndex = 4;
            this.button3.Text = "Volver";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FormRegistroEstadia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 179);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.salidaBtn);
            this.Controls.Add(this.btnEntrada);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reservaTxtBox);
            this.Name = "FormRegistroEstadia";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Registro Estadia";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox reservaTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEntrada;
        private System.Windows.Forms.Button salidaBtn;
        private System.Windows.Forms.Button button3;
    }
}