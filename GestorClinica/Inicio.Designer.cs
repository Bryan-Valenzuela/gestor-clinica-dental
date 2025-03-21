
namespace GestorClinica
{
    partial class Inicio
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PContenido = new System.Windows.Forms.Panel();
            this.PSuperior = new System.Windows.Forms.Panel();
            this.tituloVentana = new System.Windows.Forms.Label();
            this.cerrar = new System.Windows.Forms.Label();
            this.minimizar = new System.Windows.Forms.Label();
            this.PIzquierdo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.PMenu = new System.Windows.Forms.Panel();
            this.btnCPanel = new System.Windows.Forms.Button();
            this.PMAgenda = new System.Windows.Forms.Panel();
            this.btnOrtodoncia = new System.Windows.Forms.Button();
            this.btnOdontopediatria = new System.Windows.Forms.Button();
            this.btnOdontologiaGeneral = new System.Windows.Forms.Button();
            this.btnAgenda = new System.Windows.Forms.Button();
            this.PMPacientes = new System.Windows.Forms.Panel();
            this.btnPAdulto = new System.Windows.Forms.Button();
            this.btnPKids = new System.Windows.Forms.Button();
            this.btnPGral = new System.Windows.Forms.Button();
            this.btnPacientes = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panel1.SuspendLayout();
            this.PSuperior.SuspendLayout();
            this.PIzquierdo.SuspendLayout();
            this.PMenu.SuspendLayout();
            this.PMAgenda.SuspendLayout();
            this.PMPacientes.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(388, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PContenido);
            this.panel1.Controls.Add(this.PSuperior);
            this.panel1.Controls.Add(this.PIzquierdo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 700);
            this.panel1.TabIndex = 1;
            // 
            // PContenido
            // 
            this.PContenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.PContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PContenido.Location = new System.Drawing.Point(230, 80);
            this.PContenido.Name = "PContenido";
            this.PContenido.Size = new System.Drawing.Size(970, 620);
            this.PContenido.TabIndex = 2;
            // 
            // PSuperior
            // 
            this.PSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(173)))), ((int)(((byte)(202)))));
            this.PSuperior.Controls.Add(this.tituloVentana);
            this.PSuperior.Controls.Add(this.cerrar);
            this.PSuperior.Controls.Add(this.minimizar);
            this.PSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.PSuperior.Location = new System.Drawing.Point(230, 0);
            this.PSuperior.Name = "PSuperior";
            this.PSuperior.Size = new System.Drawing.Size(970, 80);
            this.PSuperior.TabIndex = 1;
            // 
            // tituloVentana
            // 
            this.tituloVentana.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tituloVentana.Font = new System.Drawing.Font("Montserrat", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloVentana.ForeColor = System.Drawing.Color.White;
            this.tituloVentana.Location = new System.Drawing.Point(0, 23);
            this.tituloVentana.Name = "tituloVentana";
            this.tituloVentana.Size = new System.Drawing.Size(851, 31);
            this.tituloVentana.TabIndex = 2;
            this.tituloVentana.Text = " ";
            this.tituloVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cerrar
            // 
            this.cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cerrar.AutoSize = true;
            this.cerrar.Font = new System.Drawing.Font("Montserrat ExtraBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cerrar.ForeColor = System.Drawing.Color.White;
            this.cerrar.Location = new System.Drawing.Point(914, 23);
            this.cerrar.Name = "cerrar";
            this.cerrar.Size = new System.Drawing.Size(28, 29);
            this.cerrar.TabIndex = 1;
            this.cerrar.Text = "X";
            this.cerrar.Click += new System.EventHandler(this.cerrar_Click);
            // 
            // minimizar
            // 
            this.minimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizar.AutoSize = true;
            this.minimizar.Font = new System.Drawing.Font("Montserrat ExtraBold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizar.ForeColor = System.Drawing.Color.White;
            this.minimizar.Location = new System.Drawing.Point(857, 10);
            this.minimizar.Name = "minimizar";
            this.minimizar.Size = new System.Drawing.Size(36, 44);
            this.minimizar.TabIndex = 0;
            this.minimizar.Text = "_";
            this.minimizar.Visible = false;
            this.minimizar.Click += new System.EventHandler(this.label1_Click);
            // 
            // PIzquierdo
            // 
            this.PIzquierdo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(103)))), ((int)(((byte)(124)))));
            this.PIzquierdo.Controls.Add(this.label1);
            this.PIzquierdo.Controls.Add(this.PMenu);
            this.PIzquierdo.Controls.Add(this.panel2);
            this.PIzquierdo.Dock = System.Windows.Forms.DockStyle.Left;
            this.PIzquierdo.Location = new System.Drawing.Point(0, 0);
            this.PIzquierdo.Name = "PIzquierdo";
            this.PIzquierdo.Size = new System.Drawing.Size(230, 700);
            this.PIzquierdo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(93, 669);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "V 1.0";
            // 
            // PMenu
            // 
            this.PMenu.Controls.Add(this.btnCPanel);
            this.PMenu.Controls.Add(this.PMAgenda);
            this.PMenu.Controls.Add(this.btnAgenda);
            this.PMenu.Controls.Add(this.PMPacientes);
            this.PMenu.Controls.Add(this.btnPacientes);
            this.PMenu.Location = new System.Drawing.Point(0, 195);
            this.PMenu.Name = "PMenu";
            this.PMenu.Size = new System.Drawing.Size(230, 465);
            this.PMenu.TabIndex = 1;
            // 
            // btnCPanel
            // 
            this.btnCPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCPanel.FlatAppearance.BorderSize = 0;
            this.btnCPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCPanel.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCPanel.ForeColor = System.Drawing.Color.White;
            this.btnCPanel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCPanel.Location = new System.Drawing.Point(0, 356);
            this.btnCPanel.Name = "btnCPanel";
            this.btnCPanel.Size = new System.Drawing.Size(230, 50);
            this.btnCPanel.TabIndex = 4;
            this.btnCPanel.Text = "Panel de control";
            this.btnCPanel.UseVisualStyleBackColor = true;
            this.btnCPanel.Click += new System.EventHandler(this.btnCPanel_Click);
            // 
            // PMAgenda
            // 
            this.PMAgenda.Controls.Add(this.btnOrtodoncia);
            this.PMAgenda.Controls.Add(this.btnOdontopediatria);
            this.PMAgenda.Controls.Add(this.btnOdontologiaGeneral);
            this.PMAgenda.Dock = System.Windows.Forms.DockStyle.Top;
            this.PMAgenda.Location = new System.Drawing.Point(0, 228);
            this.PMAgenda.Name = "PMAgenda";
            this.PMAgenda.Size = new System.Drawing.Size(230, 128);
            this.PMAgenda.TabIndex = 3;
            // 
            // btnOrtodoncia
            // 
            this.btnOrtodoncia.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOrtodoncia.FlatAppearance.BorderSize = 0;
            this.btnOrtodoncia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrtodoncia.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrtodoncia.ForeColor = System.Drawing.Color.White;
            this.btnOrtodoncia.Location = new System.Drawing.Point(0, 80);
            this.btnOrtodoncia.Name = "btnOrtodoncia";
            this.btnOrtodoncia.Size = new System.Drawing.Size(230, 40);
            this.btnOrtodoncia.TabIndex = 2;
            this.btnOrtodoncia.Text = "Ortodoncia";
            this.btnOrtodoncia.UseVisualStyleBackColor = true;
            this.btnOrtodoncia.Click += new System.EventHandler(this.btnOrtodoncia_Click);
            // 
            // btnOdontopediatria
            // 
            this.btnOdontopediatria.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOdontopediatria.FlatAppearance.BorderSize = 0;
            this.btnOdontopediatria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOdontopediatria.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOdontopediatria.ForeColor = System.Drawing.Color.White;
            this.btnOdontopediatria.Location = new System.Drawing.Point(0, 40);
            this.btnOdontopediatria.Name = "btnOdontopediatria";
            this.btnOdontopediatria.Size = new System.Drawing.Size(230, 40);
            this.btnOdontopediatria.TabIndex = 1;
            this.btnOdontopediatria.Text = "Odontopediatria";
            this.btnOdontopediatria.UseVisualStyleBackColor = true;
            this.btnOdontopediatria.Click += new System.EventHandler(this.btnOdontopediatria_Click);
            // 
            // btnOdontologiaGeneral
            // 
            this.btnOdontologiaGeneral.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOdontologiaGeneral.FlatAppearance.BorderSize = 0;
            this.btnOdontologiaGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOdontologiaGeneral.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOdontologiaGeneral.ForeColor = System.Drawing.Color.White;
            this.btnOdontologiaGeneral.Location = new System.Drawing.Point(0, 0);
            this.btnOdontologiaGeneral.Name = "btnOdontologiaGeneral";
            this.btnOdontologiaGeneral.Size = new System.Drawing.Size(230, 40);
            this.btnOdontologiaGeneral.TabIndex = 0;
            this.btnOdontologiaGeneral.Text = "Odontologia general";
            this.btnOdontologiaGeneral.UseVisualStyleBackColor = true;
            this.btnOdontologiaGeneral.Click += new System.EventHandler(this.btnOdontologiaGeneral_Click);
            // 
            // btnAgenda
            // 
            this.btnAgenda.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAgenda.FlatAppearance.BorderSize = 0;
            this.btnAgenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgenda.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgenda.ForeColor = System.Drawing.Color.White;
            this.btnAgenda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgenda.Location = new System.Drawing.Point(0, 178);
            this.btnAgenda.Name = "btnAgenda";
            this.btnAgenda.Size = new System.Drawing.Size(230, 50);
            this.btnAgenda.TabIndex = 2;
            this.btnAgenda.Text = "Agenda";
            this.btnAgenda.UseVisualStyleBackColor = true;
            this.btnAgenda.Click += new System.EventHandler(this.btnAgenda_Click);
            // 
            // PMPacientes
            // 
            this.PMPacientes.Controls.Add(this.btnPAdulto);
            this.PMPacientes.Controls.Add(this.btnPKids);
            this.PMPacientes.Controls.Add(this.btnPGral);
            this.PMPacientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.PMPacientes.Location = new System.Drawing.Point(0, 50);
            this.PMPacientes.Name = "PMPacientes";
            this.PMPacientes.Size = new System.Drawing.Size(230, 128);
            this.PMPacientes.TabIndex = 1;
            this.PMPacientes.Visible = false;
            // 
            // btnPAdulto
            // 
            this.btnPAdulto.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPAdulto.FlatAppearance.BorderSize = 0;
            this.btnPAdulto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPAdulto.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPAdulto.ForeColor = System.Drawing.Color.White;
            this.btnPAdulto.Location = new System.Drawing.Point(0, 80);
            this.btnPAdulto.Name = "btnPAdulto";
            this.btnPAdulto.Size = new System.Drawing.Size(230, 40);
            this.btnPAdulto.TabIndex = 2;
            this.btnPAdulto.Text = "Paciente Adulto";
            this.btnPAdulto.UseVisualStyleBackColor = true;
            this.btnPAdulto.Click += new System.EventHandler(this.btnPAdulto_Click);
            // 
            // btnPKids
            // 
            this.btnPKids.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPKids.FlatAppearance.BorderSize = 0;
            this.btnPKids.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPKids.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPKids.ForeColor = System.Drawing.Color.White;
            this.btnPKids.Location = new System.Drawing.Point(0, 40);
            this.btnPKids.Name = "btnPKids";
            this.btnPKids.Size = new System.Drawing.Size(230, 40);
            this.btnPKids.TabIndex = 1;
            this.btnPKids.Text = "Paciente niño";
            this.btnPKids.UseVisualStyleBackColor = true;
            this.btnPKids.Click += new System.EventHandler(this.btnPKids_Click);
            // 
            // btnPGral
            // 
            this.btnPGral.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPGral.FlatAppearance.BorderSize = 0;
            this.btnPGral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPGral.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPGral.ForeColor = System.Drawing.Color.White;
            this.btnPGral.Location = new System.Drawing.Point(0, 0);
            this.btnPGral.Name = "btnPGral";
            this.btnPGral.Size = new System.Drawing.Size(230, 40);
            this.btnPGral.TabIndex = 0;
            this.btnPGral.Text = "Paciente general";
            this.btnPGral.UseVisualStyleBackColor = true;
            this.btnPGral.Click += new System.EventHandler(this.btnPGral_Click);
            // 
            // btnPacientes
            // 
            this.btnPacientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPacientes.FlatAppearance.BorderSize = 0;
            this.btnPacientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPacientes.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPacientes.ForeColor = System.Drawing.Color.White;
            this.btnPacientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPacientes.Location = new System.Drawing.Point(0, 0);
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Size = new System.Drawing.Size(230, 50);
            this.btnPacientes.TabIndex = 0;
            this.btnPacientes.Text = "Pacientes";
            this.btnPacientes.UseVisualStyleBackColor = true;
            this.btnPacientes.Click += new System.EventHandler(this.btnPacientes_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(57, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(111, 104);
            this.panel2.TabIndex = 0;
            this.panel2.Visible = false;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.PSuperior;
            this.bunifuDragControl1.Vertical = true;
            // 
            // bunifuDragControl2
            // 
            this.bunifuDragControl2.Fixed = true;
            this.bunifuDragControl2.Horizontal = true;
            this.bunifuDragControl2.TargetControl = this.PIzquierdo;
            this.bunifuDragControl2.Vertical = true;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(960, 480);
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.inicio_Load);
            this.panel1.ResumeLayout(false);
            this.PSuperior.ResumeLayout(false);
            this.PSuperior.PerformLayout();
            this.PIzquierdo.ResumeLayout(false);
            this.PIzquierdo.PerformLayout();
            this.PMenu.ResumeLayout(false);
            this.PMAgenda.ResumeLayout(false);
            this.PMPacientes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel PContenido;
        private System.Windows.Forms.Panel PSuperior;
        private System.Windows.Forms.Panel PIzquierdo;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl2;
        private System.Windows.Forms.Label minimizar;
        private System.Windows.Forms.Label cerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PMenu;
        private System.Windows.Forms.Panel PMPacientes;
        private System.Windows.Forms.Button btnPGral;
        private System.Windows.Forms.Button btnPacientes;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCPanel;
        private System.Windows.Forms.Panel PMAgenda;
        private System.Windows.Forms.Button btnOrtodoncia;
        private System.Windows.Forms.Button btnOdontopediatria;
        private System.Windows.Forms.Button btnOdontologiaGeneral;
        private System.Windows.Forms.Button btnAgenda;
        private System.Windows.Forms.Button btnPAdulto;
        private System.Windows.Forms.Button btnPKids;
        public System.Windows.Forms.Label tituloVentana;
    }
}

