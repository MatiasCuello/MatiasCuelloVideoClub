namespace VideoClub.Windows
{
    partial class frmLocalidadesAE
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
            this.CancelButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.LocalidadTextBox = new System.Windows.Forms.TextBox();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblProvincia = new System.Windows.Forms.Label();
            this.ProvinciaComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.Image = global::VideoClub.Windows.Properties.Resources.Cancelar;
            this.CancelButton.Location = new System.Drawing.Point(322, 169);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(94, 64);
            this.CancelButton.TabIndex = 21;
            this.CancelButton.Text = "Cancelar";
            this.CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Image = global::VideoClub.Windows.Properties.Resources.OK;
            this.OkButton.Location = new System.Drawing.Point(62, 169);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(94, 64);
            this.OkButton.TabIndex = 22;
            this.OkButton.Text = "OK";
            this.OkButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // LocalidadTextBox
            // 
            this.LocalidadTextBox.Location = new System.Drawing.Point(119, 44);
            this.LocalidadTextBox.MaxLength = 50;
            this.LocalidadTextBox.Name = "LocalidadTextBox";
            this.LocalidadTextBox.Size = new System.Drawing.Size(297, 20);
            this.LocalidadTextBox.TabIndex = 20;
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(59, 47);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(56, 13);
            this.lblLocalidad.TabIndex = 19;
            this.lblLocalidad.Text = "Localidad:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblProvincia
            // 
            this.lblProvincia.AutoSize = true;
            this.lblProvincia.Location = new System.Drawing.Point(59, 92);
            this.lblProvincia.Name = "lblProvincia";
            this.lblProvincia.Size = new System.Drawing.Size(54, 13);
            this.lblProvincia.TabIndex = 19;
            this.lblProvincia.Text = "Provincia:";
            // 
            // ProvinciaComboBox
            // 
            this.ProvinciaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProvinciaComboBox.FormattingEnabled = true;
            this.ProvinciaComboBox.Location = new System.Drawing.Point(119, 89);
            this.ProvinciaComboBox.Name = "ProvinciaComboBox";
            this.ProvinciaComboBox.Size = new System.Drawing.Size(297, 21);
            this.ProvinciaComboBox.TabIndex = 23;
            // 
            // frmLocalidadesAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.ControlBox = false;
            this.Controls.Add(this.ProvinciaComboBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.LocalidadTextBox);
            this.Controls.Add(this.lblProvincia);
            this.Controls.Add(this.lblLocalidad);
            this.MaximumSize = new System.Drawing.Size(500, 300);
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "frmLocalidadesAE";
            this.Text = "Localidades";
            this.Load += new System.EventHandler(this.frmLocalidadesAE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.TextBox LocalidadTextBox;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox ProvinciaComboBox;
        private System.Windows.Forms.Label lblProvincia;
    }
}