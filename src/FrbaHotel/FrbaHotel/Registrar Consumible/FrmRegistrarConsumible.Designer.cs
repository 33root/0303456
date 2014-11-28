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
            this.label1 = new System.Windows.Forms.Label();
            this.cbConsumibles = new System.Windows.Forms.ComboBox();
            this.volverBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbHabitacion = new System.Windows.Forms.ComboBox();
            this.lstConsumibles = new System.Windows.Forms.ListBox();
            this.AGREGAR = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Consumible";
            // 
            // cbConsumibles
            // 
            this.cbConsumibles.FormattingEnabled = true;
            this.cbConsumibles.Location = new System.Drawing.Point(155, 59);
            this.cbConsumibles.Name = "cbConsumibles";
            this.cbConsumibles.Size = new System.Drawing.Size(121, 21);
            this.cbConsumibles.TabIndex = 1;
            this.cbConsumibles.SelectedIndexChanged += new System.EventHandler(this.cbConsumibles_SelectedIndexChanged);
            // 
            // volverBtn
            // 
            this.volverBtn.Location = new System.Drawing.Point(34, 316);
            this.volverBtn.Name = "volverBtn";
            this.volverBtn.Size = new System.Drawing.Size(75, 23);
            this.volverBtn.TabIndex = 2;
            this.volverBtn.Text = "VOLVER";
            this.volverBtn.UseVisualStyleBackColor = true;
            this.volverBtn.Click += new System.EventHandler(this.volverBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Habitacion";
            // 
            // cbHabitacion
            // 
            this.cbHabitacion.FormattingEnabled = true;
            this.cbHabitacion.Location = new System.Drawing.Point(155, 13);
            this.cbHabitacion.Name = "cbHabitacion";
            this.cbHabitacion.Size = new System.Drawing.Size(121, 21);
            this.cbHabitacion.TabIndex = 4;
            // 
            // lstConsumibles
            // 
            this.lstConsumibles.DisplayMember = "descripcion";
            this.lstConsumibles.FormattingEnabled = true;
            this.lstConsumibles.Location = new System.Drawing.Point(34, 121);
            this.lstConsumibles.MultiColumn = true;
            this.lstConsumibles.Name = "lstConsumibles";
            this.lstConsumibles.Size = new System.Drawing.Size(278, 160);
            this.lstConsumibles.TabIndex = 11;
            this.lstConsumibles.ValueMember = "id";
            this.lstConsumibles.SelectedIndexChanged += new System.EventHandler(this.lstConsumibles_SelectedIndexChanged);
            // 
            // AGREGAR
            // 
            this.AGREGAR.Location = new System.Drawing.Point(74, 92);
            this.AGREGAR.Name = "AGREGAR";
            this.AGREGAR.Size = new System.Drawing.Size(75, 23);
            this.AGREGAR.TabIndex = 12;
            this.AGREGAR.Text = "Agregar";
            this.AGREGAR.UseVisualStyleBackColor = true;
            this.AGREGAR.Click += new System.EventHandler(this.AGREGAR_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(292, 316);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Registrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(195, 92);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Eliminar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmRegistrarConsumible
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 338);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AGREGAR);
            this.Controls.Add(this.lstConsumibles);
            this.Controls.Add(this.cbHabitacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.volverBtn);
            this.Controls.Add(this.cbConsumibles);
            this.Controls.Add(this.label1);
            this.Name = "FrmRegistrarConsumible";
            this.Text = "FrmRegistrarConsumible";
            this.Load += new System.EventHandler(this.FrmRegistrarConsumible_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbConsumibles;
        private System.Windows.Forms.Button volverBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbHabitacion;
        private System.Windows.Forms.ListBox lstConsumibles;
        private System.Windows.Forms.Button AGREGAR;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
