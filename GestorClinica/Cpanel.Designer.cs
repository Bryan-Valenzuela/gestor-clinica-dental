
namespace GestorClinica
{
    partial class Cpanel
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnFacturacion = new System.Windows.Forms.Button();
            this.btnCorte = new System.Windows.Forms.Button();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.contenedorCPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(720, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 620);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnFacturacion);
            this.panel2.Controls.Add(this.btnCorte);
            this.panel2.Location = new System.Drawing.Point(0, 110);
            this.panel2.Margin = new System.Windows.Forms.Padding(0, 110, 3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 400);
            this.panel2.TabIndex = 0;
            // 
            // btnFacturacion
            // 
            this.btnFacturacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(173)))), ((int)(((byte)(202)))));
            this.btnFacturacion.FlatAppearance.BorderSize = 0;
            this.btnFacturacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFacturacion.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturacion.ForeColor = System.Drawing.Color.White;
            this.btnFacturacion.Location = new System.Drawing.Point(26, 263);
            this.btnFacturacion.Name = "btnFacturacion";
            this.btnFacturacion.Size = new System.Drawing.Size(151, 49);
            this.btnFacturacion.TabIndex = 272;
            this.btnFacturacion.Text = "Facturacion";
            this.btnFacturacion.UseVisualStyleBackColor = false;
            this.btnFacturacion.Click += new System.EventHandler(this.btnFacturacion_Click);
            // 
            // btnCorte
            // 
            this.btnCorte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(173)))), ((int)(((byte)(202)))));
            this.btnCorte.FlatAppearance.BorderSize = 0;
            this.btnCorte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCorte.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCorte.ForeColor = System.Drawing.Color.White;
            this.btnCorte.Location = new System.Drawing.Point(26, 97);
            this.btnCorte.Name = "btnCorte";
            this.btnCorte.Size = new System.Drawing.Size(151, 49);
            this.btnCorte.TabIndex = 272;
            this.btnCorte.Text = "Corte";
            this.btnCorte.UseVisualStyleBackColor = false;
            this.btnCorte.Click += new System.EventHandler(this.btnCorte_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 50;
            this.bunifuElipse1.TargetControl = this.panel2;
            // 
            // contenedorCPanel
            // 
            this.contenedorCPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedorCPanel.Location = new System.Drawing.Point(0, 0);
            this.contenedorCPanel.Name = "contenedorCPanel";
            this.contenedorCPanel.Size = new System.Drawing.Size(720, 620);
            this.contenedorCPanel.TabIndex = 1;
            // 
            // Cpanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(970, 620);
            this.Controls.Add(this.contenedorCPanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Cpanel";
            this.Text = "Cpanel";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel contenedorCPanel;
        private System.Windows.Forms.Button btnFacturacion;
        private System.Windows.Forms.Button btnCorte;
    }
}