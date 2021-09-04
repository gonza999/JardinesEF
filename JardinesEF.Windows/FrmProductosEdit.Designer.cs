
namespace JardinesEF.Windows
{
    partial class FrmProductosEdit
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
            this.components = new System.ComponentModel.Container();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.CategoriasComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ProveedoresComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.StockTextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.PrecioUnitarioTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LatinTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ProductoTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NivelDeReposicionTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendidoCheckBox = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // CancelarButton
            // 
            this.CancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelarButton.Location = new System.Drawing.Point(267, 253);
            this.CancelarButton.Margin = new System.Windows.Forms.Padding(4);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(135, 63);
            this.CancelarButton.TabIndex = 146;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(32, 253);
            this.GuardarButton.Margin = new System.Windows.Forms.Padding(4);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(135, 63);
            this.GuardarButton.TabIndex = 145;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CategoriasComboBox
            // 
            this.CategoriasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoriasComboBox.FormattingEnabled = true;
            this.CategoriasComboBox.Location = new System.Drawing.Point(107, 94);
            this.CategoriasComboBox.Name = "CategoriasComboBox";
            this.CategoriasComboBox.Size = new System.Drawing.Size(259, 21);
            this.CategoriasComboBox.TabIndex = 123;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 122;
            this.label7.Text = "Categoria :";
            // 
            // ProveedoresComboBox
            // 
            this.ProveedoresComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProveedoresComboBox.FormattingEnabled = true;
            this.ProveedoresComboBox.Location = new System.Drawing.Point(107, 64);
            this.ProveedoresComboBox.Name = "ProveedoresComboBox";
            this.ProveedoresComboBox.Size = new System.Drawing.Size(259, 21);
            this.ProveedoresComboBox.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Proveedor :";
            // 
            // StockTextBox
            // 
            this.StockTextBox.Location = new System.Drawing.Point(107, 147);
            this.StockTextBox.MaxLength = 20;
            this.StockTextBox.Name = "StockTextBox";
            this.StockTextBox.Size = new System.Drawing.Size(131, 20);
            this.StockTextBox.TabIndex = 6;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 150);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Stock:";
            // 
            // PrecioUnitarioTextBox
            // 
            this.PrecioUnitarioTextBox.Location = new System.Drawing.Point(107, 121);
            this.PrecioUnitarioTextBox.MaxLength = 150;
            this.PrecioUnitarioTextBox.Name = "PrecioUnitarioTextBox";
            this.PrecioUnitarioTextBox.Size = new System.Drawing.Size(367, 20);
            this.PrecioUnitarioTextBox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Precio unitario :";
            // 
            // LatinTextBox
            // 
            this.LatinTextBox.Location = new System.Drawing.Point(107, 38);
            this.LatinTextBox.MaxLength = 150;
            this.LatinTextBox.Name = "LatinTextBox";
            this.LatinTextBox.Size = new System.Drawing.Size(367, 20);
            this.LatinTextBox.TabIndex = 140;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 143;
            this.label3.Text = "Nombre en latin:";
            // 
            // ProductoTextBox
            // 
            this.ProductoTextBox.Location = new System.Drawing.Point(107, 12);
            this.ProductoTextBox.MaxLength = 150;
            this.ProductoTextBox.Name = "ProductoTextBox";
            this.ProductoTextBox.Size = new System.Drawing.Size(367, 20);
            this.ProductoTextBox.TabIndex = 141;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 144;
            this.label1.Text = "Producto :";
            // 
            // NivelDeReposicionTextBox
            // 
            this.NivelDeReposicionTextBox.Location = new System.Drawing.Point(134, 176);
            this.NivelDeReposicionTextBox.MaxLength = 20;
            this.NivelDeReposicionTextBox.Name = "NivelDeReposicionTextBox";
            this.NivelDeReposicionTextBox.Size = new System.Drawing.Size(131, 20);
            this.NivelDeReposicionTextBox.TabIndex = 148;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 147;
            this.label4.Text = "Nivel de Reposicion : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 149;
            this.label5.Text = "Suspendido : ";
            // 
            // SuspendidoCheckBox
            // 
            this.SuspendidoCheckBox.AutoSize = true;
            this.SuspendidoCheckBox.Location = new System.Drawing.Point(96, 205);
            this.SuspendidoCheckBox.Name = "SuspendidoCheckBox";
            this.SuspendidoCheckBox.Size = new System.Drawing.Size(15, 14);
            this.SuspendidoCheckBox.TabIndex = 150;
            this.SuspendidoCheckBox.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmProductosEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 361);
            this.Controls.Add(this.SuspendidoCheckBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.NivelDeReposicionTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PrecioUnitarioTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StockTextBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.CategoriasComboBox);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.GuardarButton);
            this.Controls.Add(this.ProveedoresComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LatinTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ProductoTextBox);
            this.Controls.Add(this.label1);
            this.Name = "FrmProductosEdit";
            this.Text = "FrmProductosEdit";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.ComboBox CategoriasComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox ProveedoresComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox StockTextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox PrecioUnitarioTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LatinTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ProductoTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NivelDeReposicionTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox SuspendidoCheckBox;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}