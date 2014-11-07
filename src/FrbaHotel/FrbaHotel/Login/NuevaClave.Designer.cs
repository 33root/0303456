namespace FrbaHotel.Login
{
    partial class NuevaClave
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
            this.claveTxtBox = new System.Windows.Forms.TextBox();
            this.nuevaClavelbl = new System.Windows.Forms.Label();
            this.clave2TxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.aceptarBtn = new System.Windows.Forms.Button();
            this.cancelarBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // claveTxtBox
            // 
            this.claveTxtBox.Location = new System.Drawing.Point(51, 50);
            this.claveTxtBox.Name = "claveTxtBox";
            this.claveTxtBox.PasswordChar = '*';
            this.claveTxtBox.Size = new System.Drawing.Size(183, 20);
            this.claveTxtBox.TabIndex = 0;
            // 
            // nuevaClavelbl
            // 
            this.nuevaClavelbl.AutoSize = true;
            this.nuevaClavelbl.Location = new System.Drawing.Point(48, 34);
            this.nuevaClavelbl.Name = "nuevaClavelbl";
            this.nuevaClavelbl.Size = new System.Drawing.Size(110, 13);
            this.nuevaClavelbl.TabIndex = 2;
            this.nuevaClavelbl.Text = "Ingrese Nueva Clave:";
            // 
            // clave2TxtBox
            // 
            this.clave2TxtBox.Location = new System.Drawing.Point(51, 108);
            this.clave2TxtBox.Name = "clave2TxtBox";
            this.clave2TxtBox.PasswordChar = '*';
            this.clave2TxtBox.Size = new System.Drawing.Size(183, 20);
            this.clave2TxtBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Reingrese la clave:";
            // 
            // aceptarBtn
            // 
            this.aceptarBtn.Location = new System.Drawing.Point(51, 159);
            this.aceptarBtn.Name = "aceptarBtn";
            this.aceptarBtn.Size = new System.Drawing.Size(75, 23);
            this.aceptarBtn.TabIndex = 5;
            this.aceptarBtn.Text = "Aceptar";
            this.aceptarBtn.UseVisualStyleBackColor = true;
            this.aceptarBtn.Click += new System.EventHandler(this.aceptarBtn_Click);
            // 
            // cancelarBtn
            // 
            this.cancelarBtn.Location = new System.Drawing.Point(151, 159);
            this.cancelarBtn.Name = "cancelarBtn";
            this.cancelarBtn.Size = new System.Drawing.Size(83, 23);
            this.cancelarBtn.TabIndex = 6;
            this.cancelarBtn.Text = "Cancelar";
            this.cancelarBtn.UseVisualStyleBackColor = true;
            this.cancelarBtn.Click += new System.EventHandler(this.cancelarBtn_Click);
            // 
            // NuevaClave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 194);
            this.Controls.Add(this.cancelarBtn);
            this.Controls.Add(this.aceptarBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clave2TxtBox);
            this.Controls.Add(this.nuevaClavelbl);
            this.Controls.Add(this.claveTxtBox);
            this.Name = "NuevaClave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva Clave";
            this.Load += new System.EventHandler(this.NuevaClave_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox claveTxtBox;
        private System.Windows.Forms.Label nuevaClavelbl;
        private System.Windows.Forms.TextBox clave2TxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button aceptarBtn;
        private System.Windows.Forms.Button cancelarBtn;
    }
}