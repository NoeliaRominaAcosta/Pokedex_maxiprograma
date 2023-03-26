namespace Pokedex
{
    partial class altaPokemon
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
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.nombre = new System.Windows.Forms.Label();
            this.numero = new System.Windows.Forms.Label();
            this.descripcion = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tipo = new System.Windows.Forms.Label();
            this.debilidad = new System.Windows.Forms.Label();
            this.cbxTipo = new System.Windows.Forms.ComboBox();
            this.cbxDebilidad = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(120, 45);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(167, 20);
            this.txtNombre.TabIndex = 5;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(120, 140);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(167, 20);
            this.txtDescripcion.TabIndex = 6;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(120, 93);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(167, 20);
            this.txtNumero.TabIndex = 7;
            // 
            // nombre
            // 
            this.nombre.AutoSize = true;
            this.nombre.Location = new System.Drawing.Point(27, 52);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(44, 13);
            this.nombre.TabIndex = 8;
            this.nombre.Text = "Nombre";
            // 
            // numero
            // 
            this.numero.AutoSize = true;
            this.numero.Location = new System.Drawing.Point(27, 100);
            this.numero.Name = "numero";
            this.numero.Size = new System.Drawing.Size(44, 13);
            this.numero.TabIndex = 9;
            this.numero.Text = "Numero";
            // 
            // descripcion
            // 
            this.descripcion.AutoSize = true;
            this.descripcion.Location = new System.Drawing.Point(27, 147);
            this.descripcion.Name = "descripcion";
            this.descripcion.Size = new System.Drawing.Size(63, 13);
            this.descripcion.TabIndex = 10;
            this.descripcion.Text = "Descripcion";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(48, 298);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 11;
            this.btnAgregar.Text = "Aceptar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(169, 298);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // tipo
            // 
            this.tipo.AutoSize = true;
            this.tipo.Location = new System.Drawing.Point(27, 192);
            this.tipo.Name = "tipo";
            this.tipo.Size = new System.Drawing.Size(28, 13);
            this.tipo.TabIndex = 13;
            this.tipo.Text = "Tipo";
            // 
            // debilidad
            // 
            this.debilidad.AutoSize = true;
            this.debilidad.Location = new System.Drawing.Point(27, 237);
            this.debilidad.Name = "debilidad";
            this.debilidad.Size = new System.Drawing.Size(51, 13);
            this.debilidad.TabIndex = 14;
            this.debilidad.Text = "Debilidad";
            // 
            // cbxTipo
            // 
            this.cbxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipo.FormattingEnabled = true;
            this.cbxTipo.Location = new System.Drawing.Point(120, 184);
            this.cbxTipo.Name = "cbxTipo";
            this.cbxTipo.Size = new System.Drawing.Size(167, 21);
            this.cbxTipo.TabIndex = 15;
            // 
            // cbxDebilidad
            // 
            this.cbxDebilidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDebilidad.FormattingEnabled = true;
            this.cbxDebilidad.Location = new System.Drawing.Point(120, 229);
            this.cbxDebilidad.Name = "cbxDebilidad";
            this.cbxDebilidad.Size = new System.Drawing.Size(167, 21);
            this.cbxDebilidad.TabIndex = 16;
            // 
            // altaPokemon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(611, 343);
            this.Controls.Add(this.cbxDebilidad);
            this.Controls.Add(this.cbxTipo);
            this.Controls.Add(this.debilidad);
            this.Controls.Add(this.tipo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.descripcion);
            this.Controls.Add(this.numero);
            this.Controls.Add(this.nombre);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtNombre);
            this.Name = "altaPokemon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "altaPokemon";
            this.Load += new System.EventHandler(this.altaPokemon_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label nombre;
        private System.Windows.Forms.Label numero;
        private System.Windows.Forms.Label descripcion;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label tipo;
        private System.Windows.Forms.Label debilidad;
        private System.Windows.Forms.ComboBox cbxTipo;
        private System.Windows.Forms.ComboBox cbxDebilidad;
    }
}