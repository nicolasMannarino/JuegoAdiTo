using System.Drawing;

namespace JuegoPrueba
{
    partial class Form1
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
            this.letras = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.respuesta = new System.Windows.Forms.FlowLayoutPanel();
            this.nivelLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.intentosFallidosLabel = new System.Windows.Forms.Label();
            this.monedasLabel = new System.Windows.Forms.Label();
            this.BotonPlay = new System.Windows.Forms.PictureBox();
            this.Multijugador = new System.Windows.Forms.PictureBox();
            this.picImagen = new System.Windows.Forms.PictureBox();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.MonedasImagen = new System.Windows.Forms.PictureBox();
            this.letras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BotonPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Multijugador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonedasImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // letras
            // 
            this.letras.Controls.Add(this.label2);
            this.letras.Location = new System.Drawing.Point(12, 455);
            this.letras.Name = "letras";
            this.letras.Size = new System.Drawing.Size(403, 142);
            this.letras.TabIndex = 2;
            this.letras.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
            // 
            // respuesta
            // 
            this.respuesta.AllowDrop = true;
            this.respuesta.Location = new System.Drawing.Point(12, 300);
            this.respuesta.Name = "respuesta";
            this.respuesta.Size = new System.Drawing.Size(403, 142);
            this.respuesta.TabIndex = 0;
            this.respuesta.Visible = false;
            // 
            // nivelLabel
            // 
            this.nivelLabel.AutoSize = true;
            this.nivelLabel.BackColor = System.Drawing.Color.Black;
            this.nivelLabel.Font = new System.Drawing.Font("Mistral", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nivelLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.nivelLabel.Location = new System.Drawing.Point(-3, 13);
            this.nivelLabel.Name = "nivelLabel";
            this.nivelLabel.Size = new System.Drawing.Size(60, 33);
            this.nivelLabel.TabIndex = 0;
            this.nivelLabel.Text = "Nivel";
            this.nivelLabel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // intentosFallidosLabel
            // 
            this.intentosFallidosLabel.AutoSize = true;
            this.intentosFallidosLabel.Font = new System.Drawing.Font("Mistral", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.intentosFallidosLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.intentosFallidosLabel.Location = new System.Drawing.Point(-3, 46);
            this.intentosFallidosLabel.Name = "intentosFallidosLabel";
            this.intentosFallidosLabel.Size = new System.Drawing.Size(86, 33);
            this.intentosFallidosLabel.TabIndex = 5;
            this.intentosFallidosLabel.Text = "Intentos";
            this.intentosFallidosLabel.Visible = false;
            // 
            // monedasLabel
            // 
            this.monedasLabel.AutoSize = true;
            this.monedasLabel.Font = new System.Drawing.Font("Mistral", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monedasLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.monedasLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.monedasLabel.Location = new System.Drawing.Point(312, 13);
            this.monedasLabel.Name = "monedasLabel";
            this.monedasLabel.Size = new System.Drawing.Size(90, 33);
            this.monedasLabel.TabIndex = 8;
            this.monedasLabel.Text = "Monedas";
            this.monedasLabel.Visible = false;
            // 
            // BotonPlay
            // 
            this.BotonPlay.Image = global::JuegoPrueba.Properties.Resources.botonPlay;
            this.BotonPlay.Location = new System.Drawing.Point(156, 219);
            this.BotonPlay.Name = "BotonPlay";
            this.BotonPlay.Size = new System.Drawing.Size(119, 114);
            this.BotonPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.BotonPlay.TabIndex = 6;
            this.BotonPlay.TabStop = false;
            this.BotonPlay.Click += new System.EventHandler(this.BotonPlay_Click);
            // 
            // Multijugador
            // 
            this.Multijugador.BackColor = System.Drawing.Color.Black;
            this.Multijugador.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Multijugador.Image = global::JuegoPrueba.Properties.Resources.Multijugador;
            this.Multijugador.Location = new System.Drawing.Point(29, 455);
            this.Multijugador.Name = "Multijugador";
            this.Multijugador.Size = new System.Drawing.Size(135, 87);
            this.Multijugador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Multijugador.TabIndex = 7;
            this.Multijugador.TabStop = false;
            // 
            // picImagen
            // 
            this.picImagen.Image = global::JuegoPrueba.Properties.Resources.imagen1;
            this.picImagen.Location = new System.Drawing.Point(12, 141);
            this.picImagen.Name = "picImagen";
            this.picImagen.Size = new System.Drawing.Size(403, 141);
            this.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImagen.TabIndex = 0;
            this.picImagen.TabStop = false;
            this.picImagen.Visible = false;
            // 
            // Logo
            // 
            this.Logo.Image = global::JuegoPrueba.Properties.Resources.LogoAdito;
            this.Logo.Location = new System.Drawing.Point(89, -35);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(264, 170);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Logo.TabIndex = 3;
            this.Logo.TabStop = false;
            // 
            // MonedasImagen
            // 
            this.MonedasImagen.Image = global::JuegoPrueba.Properties.Resources.monedas;
            this.MonedasImagen.Location = new System.Drawing.Point(272, 12);
            this.MonedasImagen.Name = "MonedasImagen";
            this.MonedasImagen.Size = new System.Drawing.Size(44, 33);
            this.MonedasImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MonedasImagen.TabIndex = 9;
            this.MonedasImagen.TabStop = false;
            this.MonedasImagen.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(427, 695);
            this.Controls.Add(this.MonedasImagen);
            this.Controls.Add(this.monedasLabel);
            this.Controls.Add(this.BotonPlay);
            this.Controls.Add(this.Multijugador);
            this.Controls.Add(this.intentosFallidosLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picImagen);
            this.Controls.Add(this.nivelLabel);
            this.Controls.Add(this.letras);
            this.Controls.Add(this.Logo);
            this.Controls.Add(this.respuesta);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.letras.ResumeLayout(false);
            this.letras.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BotonPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Multijugador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonedasImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picImagen;
        private System.Windows.Forms.FlowLayoutPanel letras;
        private System.Windows.Forms.FlowLayoutPanel respuesta;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Label nivelLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label intentosFallidosLabel;
        private System.Windows.Forms.PictureBox BotonPlay;
        private System.Windows.Forms.PictureBox Multijugador;
        private System.Windows.Forms.Label monedasLabel;
        private System.Windows.Forms.PictureBox MonedasImagen;
    }
}

