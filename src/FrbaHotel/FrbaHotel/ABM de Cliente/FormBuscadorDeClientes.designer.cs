namespace FrbaHotel.ABM_de_Cliente
{
    partial class FormBuscadorDeClientes
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
            this.txbNombre = new System.Windows.Forms.TextBox();
            this.txbApellido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbDocumento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTipoDeDocumento = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbMail = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.eliminarBtn = new System.Windows.Forms.Button();
            this.limpiarBtn = new System.Windows.Forms.Button();
            this.buscarButton = new System.Windows.Forms.Button();
            this.modificarButton = new System.Windows.Forms.Button();
            this.habilitarBtn = new System.Windows.Forms.Button();
            this.volverBtn = new System.Windows.Forms.Button();
            this.seleccionarClienteBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(324, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellido";
            // 
            // txbNombre
            // 
            this.txbNombre.Location = new System.Drawing.Point(63, 12);
            this.txbNombre.Name = "txbNombre";
            this.txbNombre.Size = new System.Drawing.Size(183, 20);
            this.txbNombre.TabIndex = 2;
            // 
            // txbApellido
            // 
            this.txbApellido.Location = new System.Drawing.Point(374, 13);
            this.txbApellido.Name = "txbApellido";
            this.txbApellido.Size = new System.Drawing.Size(206, 20);
            this.txbApellido.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Documento";
            // 
            // txbDocumento
            // 
            this.txbDocumento.Location = new System.Drawing.Point(81, 50);
            this.txbDocumento.Name = "txbDocumento";
            this.txbDocumento.Size = new System.Drawing.Size(165, 20);
            this.txbDocumento.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(269, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tipo de documento";
            // 
            // cbTipoDeDocumento
            // 
            this.cbTipoDeDocumento.FormattingEnabled = true;
            this.cbTipoDeDocumento.Location = new System.Drawing.Point(374, 42);
            this.cbTipoDeDocumento.Name = "cbTipoDeDocumento";
            this.cbTipoDeDocumento.Size = new System.Drawing.Size(206, 21);
            this.cbTipoDeDocumento.TabIndex = 7;
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Mail";
            // 
            // txbMail
            // 
            this.txbMail.Location = new System.Drawing.Point(63, 83);
            this.txbMail.Name = "txbMail";
            this.txbMail.Size = new System.Drawing.Size(183, 20);
            this.txbMail.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(16, 116);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(564, 240);
            this.dataGridView1.TabIndex = 9;
            // 
            // eliminarBtn
            // 
            this.eliminarBtn.Location = new System.Drawing.Point(410, 362);
            this.eliminarBtn.Name = "eliminarBtn";
            this.eliminarBtn.Size = new System.Drawing.Size(75, 23);
            this.eliminarBtn.TabIndex = 11;
            this.eliminarBtn.Text = "Eliminar";
            this.eliminarBtn.UseVisualStyleBackColor = true;
            this.eliminarBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // limpiarBtn
            // 
            this.limpiarBtn.Location = new System.Drawing.Point(313, 362);
            this.limpiarBtn.Name = "limpiarBtn";
            this.limpiarBtn.Size = new System.Drawing.Size(75, 23);
            this.limpiarBtn.TabIndex = 12;
            this.limpiarBtn.Text = "Limpiar";
            this.limpiarBtn.UseVisualStyleBackColor = true;
            this.limpiarBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // buscarButton
            // 
            this.buscarButton.Location = new System.Drawing.Point(505, 362);
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.Size = new System.Drawing.Size(75, 23);
            this.buscarButton.TabIndex = 13;
            this.buscarButton.Text = "Buscar";
            this.buscarButton.UseVisualStyleBackColor = true;
            this.buscarButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // modificarButton
            // 
            this.modificarButton.Location = new System.Drawing.Point(212, 362);
            this.modificarButton.Name = "modificarButton";
            this.modificarButton.Size = new System.Drawing.Size(75, 23);
            this.modificarButton.TabIndex = 14;
            this.modificarButton.Text = "Modificar";
            this.modificarButton.UseVisualStyleBackColor = true;
            this.modificarButton.Click += new System.EventHandler(this.modificarButton_Click);
            // 
            // habilitarBtn
            // 
            this.habilitarBtn.Location = new System.Drawing.Point(113, 362);
            this.habilitarBtn.Name = "habilitarBtn";
            this.habilitarBtn.Size = new System.Drawing.Size(75, 23);
            this.habilitarBtn.TabIndex = 15;
            this.habilitarBtn.Text = "Habilitar";
            this.habilitarBtn.UseVisualStyleBackColor = true;
            this.habilitarBtn.Click += new System.EventHandler(this.button5_Click);
            // 
            // volverBtn
            // 
            this.volverBtn.Location = new System.Drawing.Point(12, 362);
            this.volverBtn.Name = "volverBtn";
            this.volverBtn.Size = new System.Drawing.Size(75, 23);
            this.volverBtn.TabIndex = 16;
            this.volverBtn.Text = "Volver";
            this.volverBtn.UseVisualStyleBackColor = true;
            this.volverBtn.Click += new System.EventHandler(this.button6_Click);
            // 
            // seleccionarClienteBtn
            // 
            this.seleccionarClienteBtn.Location = new System.Drawing.Point(364, 83);
            this.seleccionarClienteBtn.Name = "seleccionarClienteBtn";
            this.seleccionarClienteBtn.Size = new System.Drawing.Size(212, 23);
            this.seleccionarClienteBtn.TabIndex = 17;
            this.seleccionarClienteBtn.Text = "Seleccionar Cliente";
            this.seleccionarClienteBtn.UseVisualStyleBackColor = true;
            this.seleccionarClienteBtn.Visible = false;
            this.seleccionarClienteBtn.Click += new System.EventHandler(this.seleccionarBtn_Click);
            // 
            // FormBuscadorDeClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 392);
            this.Controls.Add(this.seleccionarClienteBtn);
            this.Controls.Add(this.volverBtn);
            this.Controls.Add(this.habilitarBtn);
            this.Controls.Add(this.modificarButton);
            this.Controls.Add(this.buscarButton);
            this.Controls.Add(this.limpiarBtn);
            this.Controls.Add(this.eliminarBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txbMail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbTipoDeDocumento);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbDocumento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbApellido);
            this.Controls.Add(this.txbNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormBuscadorDeClientes";
            this.Text = "FormBuscadorDeClientes";
            this.Load += new System.EventHandler(this.FormBuscadorDeClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbNombre;
        private System.Windows.Forms.TextBox txbApellido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbDocumento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbTipoDeDocumento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbMail;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button eliminarBtn;
        private System.Windows.Forms.Button limpiarBtn;
        private System.Windows.Forms.Button buscarButton;
        private System.Windows.Forms.Button modificarButton;
        private System.Windows.Forms.Button habilitarBtn;
        private System.Windows.Forms.Button volverBtn;
        private System.Windows.Forms.Button seleccionarClienteBtn;
    }
}