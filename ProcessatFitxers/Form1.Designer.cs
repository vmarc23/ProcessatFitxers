
namespace ProcessatFitxers
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_fitxers = new System.Windows.Forms.TextBox();
            this.txt_lletres = new System.Windows.Forms.TextBox();
            this.btn_codif = new System.Windows.Forms.Button();
            this.btf_genera = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número de fitxers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Número de lletres";
            // 
            // txt_fitxers
            // 
            this.txt_fitxers.Location = new System.Drawing.Point(123, 26);
            this.txt_fitxers.Margin = new System.Windows.Forms.Padding(2);
            this.txt_fitxers.Name = "txt_fitxers";
            this.txt_fitxers.Size = new System.Drawing.Size(76, 20);
            this.txt_fitxers.TabIndex = 2;
            // 
            // txt_lletres
            // 
            this.txt_lletres.Location = new System.Drawing.Point(123, 63);
            this.txt_lletres.Margin = new System.Windows.Forms.Padding(2);
            this.txt_lletres.Name = "txt_lletres";
            this.txt_lletres.Size = new System.Drawing.Size(76, 20);
            this.txt_lletres.TabIndex = 3;
            // 
            // btn_codif
            // 
            this.btn_codif.Location = new System.Drawing.Point(16, 107);
            this.btn_codif.Margin = new System.Windows.Forms.Padding(2);
            this.btn_codif.Name = "btn_codif";
            this.btn_codif.Size = new System.Drawing.Size(82, 50);
            this.btn_codif.TabIndex = 4;
            this.btn_codif.Text = "Generar Codificació";
            this.btn_codif.UseVisualStyleBackColor = true;
            this.btn_codif.Click += new System.EventHandler(this.btn_codif_Click);
            // 
            // btf_genera
            // 
            this.btf_genera.Location = new System.Drawing.Point(123, 107);
            this.btf_genera.Margin = new System.Windows.Forms.Padding(2);
            this.btf_genera.Name = "btf_genera";
            this.btf_genera.Size = new System.Drawing.Size(82, 50);
            this.btf_genera.TabIndex = 5;
            this.btf_genera.Text = "Generar Fitxers";
            this.btf_genera.UseVisualStyleBackColor = true;
            this.btf_genera.Click += new System.EventHandler(this.btf_genera_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 176);
            this.Controls.Add(this.btf_genera);
            this.Controls.Add(this.btn_codif);
            this.Controls.Add(this.txt_lletres);
            this.Controls.Add(this.txt_fitxers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_fitxers;
        private System.Windows.Forms.TextBox txt_lletres;
        private System.Windows.Forms.Button btn_codif;
        private System.Windows.Forms.Button btf_genera;
    }
}

