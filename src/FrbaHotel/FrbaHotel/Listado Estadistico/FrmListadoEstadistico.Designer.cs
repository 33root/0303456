namespace FrbaHotel.Listado_Estadistico
{
    partial class FrmListadoEstadistico
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
            this.trimestreCmbBox = new System.Windows.Forms.ComboBox();
            this.anioTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listadoCmbBox = new System.Windows.Forms.ComboBox();
            this.listadoBtn = new System.Windows.Forms.Button();
            this.volverBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Año:";
            // 
            // trimestreCmbBox
            // 
            this.trimestreCmbBox.Enabled = false;
            this.trimestreCmbBox.FormattingEnabled = true;
            this.trimestreCmbBox.Location = new System.Drawing.Point(179, 79);
            this.trimestreCmbBox.Name = "trimestreCmbBox";
            this.trimestreCmbBox.Size = new System.Drawing.Size(121, 21);
            this.trimestreCmbBox.TabIndex = 2;
            this.trimestreCmbBox.SelectedIndexChanged += new System.EventHandler(this.trimestreCmbBox_SelectedIndexChanged);
            // 
            // anioTxtBox
            // 
            this.anioTxtBox.HideSelection = false;
            this.anioTxtBox.Location = new System.Drawing.Point(191, 36);
            this.anioTxtBox.Name = "anioTxtBox";
            this.anioTxtBox.Size = new System.Drawing.Size(100, 20);
            this.anioTxtBox.TabIndex = 1;
            this.anioTxtBox.TextChanged += new System.EventHandler(this.anioTxtBox_TextChanged);
            this.anioTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.anioTxtBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(60, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Trimestre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Listado Estadístico: ";
            // 
            // listadoCmbBox
            // 
            this.listadoCmbBox.Enabled = false;
            this.listadoCmbBox.FormattingEnabled = true;
            this.listadoCmbBox.Location = new System.Drawing.Point(179, 121);
            this.listadoCmbBox.Name = "listadoCmbBox";
            this.listadoCmbBox.Size = new System.Drawing.Size(121, 21);
            this.listadoCmbBox.TabIndex = 3;
            this.listadoCmbBox.SelectedIndexChanged += new System.EventHandler(this.listadoCmbBox_SelectedIndexChanged);
            // 
            // listadoBtn
            // 
            this.listadoBtn.Enabled = false;
            this.listadoBtn.Location = new System.Drawing.Point(161, 157);
            this.listadoBtn.Name = "listadoBtn";
            this.listadoBtn.Size = new System.Drawing.Size(154, 24);
            this.listadoBtn.TabIndex = 5;
            this.listadoBtn.Text = "Mostrar Listado";
            this.listadoBtn.UseVisualStyleBackColor = true;
            // 
            // volverBtn
            // 
            this.volverBtn.Location = new System.Drawing.Point(277, 394);
            this.volverBtn.Name = "volverBtn";
            this.volverBtn.Size = new System.Drawing.Size(121, 23);
            this.volverBtn.TabIndex = 6;
            this.volverBtn.Text = "Volver";
            this.volverBtn.UseVisualStyleBackColor = true;
            this.volverBtn.Click += new System.EventHandler(this.volverBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(66, 197);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(332, 150);
            this.dataGridView1.TabIndex = 7;
            // 
            // FrmListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 425);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.volverBtn);
            this.Controls.Add(this.listadoBtn);
            this.Controls.Add(this.listadoCmbBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.anioTxtBox);
            this.Controls.Add(this.trimestreCmbBox);
            this.Controls.Add(this.label1);
            this.Name = "FrmListadoEstadistico";
            this.Text = "Listado Estadístico";
            this.Load += new System.EventHandler(this.FrmListadoEstadistico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox trimestreCmbBox;
        private System.Windows.Forms.TextBox anioTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox listadoCmbBox;
        private System.Windows.Forms.Button listadoBtn;
        private System.Windows.Forms.Button volverBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}