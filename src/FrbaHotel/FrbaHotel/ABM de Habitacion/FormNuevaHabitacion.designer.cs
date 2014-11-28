namespace FrbaHotel.ABM_de_Habitacion
{
    partial class FormNuevaHabitacion
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
            this.btnCrear = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbTHabitacion = new System.Windows.Forms.ComboBox();
            this.cmbVista = new System.Windows.Forms.ComboBox();
            this.tbPiso = new System.Windows.Forms.TextBox();
            this.tbNumero = new System.Windows.Forms.TextBox();
            this.lbIDHotel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbIDHabitacion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(35, 165);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(79, 31);
            this.btnCrear.TabIndex = 35;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(212, 165);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(79, 31);
            this.btnVolver.TabIndex = 34;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Tipo Habitacion";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Vista";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Piso";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Numero";
            // 
            // cmbTHabitacion
            // 
            this.cmbTHabitacion.FormattingEnabled = true;
            this.cmbTHabitacion.Location = new System.Drawing.Point(91, 128);
            this.cmbTHabitacion.Name = "cmbTHabitacion";
            this.cmbTHabitacion.Size = new System.Drawing.Size(121, 21);
            this.cmbTHabitacion.TabIndex = 27;
            this.cmbTHabitacion.Text = "Base Simple";
            this.cmbTHabitacion.SelectedIndexChanged += new System.EventHandler(this.cmbTHabitacion_SelectedIndexChanged);
            // 
            // cmbVista
            // 
            this.cmbVista.FormattingEnabled = true;
            this.cmbVista.Location = new System.Drawing.Point(91, 88);
            this.cmbVista.Name = "cmbVista";
            this.cmbVista.Size = new System.Drawing.Size(121, 21);
            this.cmbVista.TabIndex = 26;
            this.cmbVista.Text = "N";
            this.cmbVista.SelectedIndexChanged += new System.EventHandler(this.cmbVista_SelectedIndexChanged);
            // 
            // tbPiso
            // 
            this.tbPiso.Location = new System.Drawing.Point(91, 49);
            this.tbPiso.Name = "tbPiso";
            this.tbPiso.Size = new System.Drawing.Size(100, 20);
            this.tbPiso.TabIndex = 25;
            this.tbPiso.TextChanged += new System.EventHandler(this.tbPiso_TextChanged);
            this.tbPiso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPiso_KeyPress);
            // 
            // tbNumero
            // 
            this.tbNumero.Location = new System.Drawing.Point(91, 12);
            this.tbNumero.Name = "tbNumero";
            this.tbNumero.Size = new System.Drawing.Size(100, 20);
            this.tbNumero.TabIndex = 24;
            this.tbNumero.TextChanged += new System.EventHandler(this.tbNombre_TextChanged);
            this.tbNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumero_KeyPress);
            // 
            // lbIDHotel
            // 
            this.lbIDHotel.AutoSize = true;
            this.lbIDHotel.Location = new System.Drawing.Point(281, 52);
            this.lbIDHotel.Name = "lbIDHotel";
            this.lbIDHotel.Size = new System.Drawing.Size(0, 13);
            this.lbIDHotel.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(226, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "ID Hotel:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "ID Habit:";
            // 
            // lbIDHabitacion
            // 
            this.lbIDHabitacion.AutoSize = true;
            this.lbIDHabitacion.Location = new System.Drawing.Point(281, 15);
            this.lbIDHabitacion.Name = "lbIDHabitacion";
            this.lbIDHabitacion.Size = new System.Drawing.Size(0, 13);
            this.lbIDHabitacion.TabIndex = 38;
            // 
            // FormNuevaHabitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 208);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbIDHabitacion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbIDHotel);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbTHabitacion);
            this.Controls.Add(this.cmbVista);
            this.Controls.Add(this.tbPiso);
            this.Controls.Add(this.tbNumero);
            this.Name = "FormNuevaHabitacion";
            this.Text = "Nueva Habitacion";
            this.Load += new System.EventHandler(this.FormNuevaHabitacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbTHabitacion;
        private System.Windows.Forms.ComboBox cmbVista;
        private System.Windows.Forms.TextBox tbPiso;
        private System.Windows.Forms.TextBox tbNumero;
        private System.Windows.Forms.Label lbIDHotel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbIDHabitacion;
    }
}