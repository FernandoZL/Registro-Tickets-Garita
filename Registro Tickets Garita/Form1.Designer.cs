namespace Registro_Tickets_Garita
{
    partial class FormRegistro
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistro));
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelApellido = new System.Windows.Forms.Label();
            this.labelLicencia = new System.Windows.Forms.Label();
            this.labelProveedor = new System.Windows.Forms.Label();
            this.labelPlacas = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.textBoxLicencia = new System.Windows.Forms.TextBox();
            this.textBoxProveedor = new System.Windows.Forms.TextBox();
            this.textBoxPlacas = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureLogo
            // 
            this.pictureLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureLogo.Image")));
            this.pictureLogo.Location = new System.Drawing.Point(195, 12);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(172, 75);
            this.pictureLogo.TabIndex = 0;
            this.pictureLogo.TabStop = false;
            // 
            // labelTitulo
            // 
            this.labelTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(12, 12);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(177, 75);
            this.labelTitulo.TabIndex = 1;
            this.labelTitulo.Text = "Registro de unidades GARITA";
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombre.Location = new System.Drawing.Point(21, 161);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(96, 26);
            this.labelNombre.TabIndex = 2;
            this.labelNombre.Text = "Nombre:";
            // 
            // labelApellido
            // 
            this.labelApellido.AutoSize = true;
            this.labelApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelApellido.Location = new System.Drawing.Point(21, 198);
            this.labelApellido.Name = "labelApellido";
            this.labelApellido.Size = new System.Drawing.Size(96, 26);
            this.labelApellido.TabIndex = 3;
            this.labelApellido.Text = "Apellido:";
            // 
            // labelLicencia
            // 
            this.labelLicencia.AutoSize = true;
            this.labelLicencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLicencia.Location = new System.Drawing.Point(21, 237);
            this.labelLicencia.Name = "labelLicencia";
            this.labelLicencia.Size = new System.Drawing.Size(138, 26);
            this.labelLicencia.TabIndex = 4;
            this.labelLicencia.Text = "No. Licencia:";
            // 
            // labelProveedor
            // 
            this.labelProveedor.AutoSize = true;
            this.labelProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProveedor.Location = new System.Drawing.Point(21, 281);
            this.labelProveedor.Name = "labelProveedor";
            this.labelProveedor.Size = new System.Drawing.Size(118, 26);
            this.labelProveedor.TabIndex = 5;
            this.labelProveedor.Text = "Proveedor:";
            // 
            // labelPlacas
            // 
            this.labelPlacas.AutoSize = true;
            this.labelPlacas.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlacas.Location = new System.Drawing.Point(21, 325);
            this.labelPlacas.Name = "labelPlacas";
            this.labelPlacas.Size = new System.Drawing.Size(84, 26);
            this.labelPlacas.TabIndex = 6;
            this.labelPlacas.Text = "Placas:";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.Location = new System.Drawing.Point(129, 415);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(116, 40);
            this.btnRegistrar.TabIndex = 7;
            this.btnRegistrar.Text = "Registrar ✔";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(166, 167);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(169, 20);
            this.textBoxNombre.TabIndex = 9;
            this.textBoxNombre.TextChanged += new System.EventHandler(this.textBoxNombre_TextChanged);
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Location = new System.Drawing.Point(166, 205);
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(169, 20);
            this.textBoxApellido.TabIndex = 10;
            this.textBoxApellido.TextChanged += new System.EventHandler(this.textBoxApellido_TextChanged);
            // 
            // textBoxLicencia
            // 
            this.textBoxLicencia.Location = new System.Drawing.Point(166, 244);
            this.textBoxLicencia.Name = "textBoxLicencia";
            this.textBoxLicencia.Size = new System.Drawing.Size(169, 20);
            this.textBoxLicencia.TabIndex = 11;
            this.textBoxLicencia.TextChanged += new System.EventHandler(this.textBoxLicencia_TextChanged);
            // 
            // textBoxProveedor
            // 
            this.textBoxProveedor.Location = new System.Drawing.Point(166, 287);
            this.textBoxProveedor.Name = "textBoxProveedor";
            this.textBoxProveedor.Size = new System.Drawing.Size(169, 20);
            this.textBoxProveedor.TabIndex = 12;
            this.textBoxProveedor.TextChanged += new System.EventHandler(this.textBoxProveedor_TextChanged);
            // 
            // textBoxPlacas
            // 
            this.textBoxPlacas.Location = new System.Drawing.Point(166, 331);
            this.textBoxPlacas.Name = "textBoxPlacas";
            this.textBoxPlacas.Size = new System.Drawing.Size(169, 20);
            this.textBoxPlacas.TabIndex = 13;
            this.textBoxPlacas.TextChanged += new System.EventHandler(this.textBoxPlacas_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Location = new System.Drawing.Point(216, 489);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 9);
            this.label1.TabIndex = 15;
            this.label1.Text = "©Mejora Continua Fernándo Zuñiga - 2,023";
            // 
            // FormRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 507);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPlacas);
            this.Controls.Add(this.textBoxProveedor);
            this.Controls.Add(this.textBoxLicencia);
            this.Controls.Add(this.textBoxApellido);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.labelPlacas);
            this.Controls.Add(this.labelProveedor);
            this.Controls.Add(this.labelLicencia);
            this.Controls.Add(this.labelApellido);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.pictureLogo);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "FormRegistro";
            this.Text = "Registrar Unidades";
            this.Load += new System.EventHandler(this.FormRegistro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureLogo;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelApellido;
        private System.Windows.Forms.Label labelLicencia;
        private System.Windows.Forms.Label labelProveedor;
        private System.Windows.Forms.Label labelPlacas;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.TextBox textBoxLicencia;
        private System.Windows.Forms.TextBox textBoxProveedor;
        private System.Windows.Forms.TextBox textBoxPlacas;
        private System.Windows.Forms.Label label1;
    }
}

