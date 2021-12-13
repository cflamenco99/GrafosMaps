namespace Dashboard
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.lbltitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMapas = new System.Windows.Forms.Button();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMejorRuta = new System.Windows.Forms.Button();
            this.cmbCiudadDestino = new System.Windows.Forms.ComboBox();
            this.cmbCiudadOrigen = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAgregarCiudad = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombreCiudad = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.btnTrazarRuta = new System.Windows.Forms.Button();
            this.cmbCiudadDestinoRutas = new System.Windows.Forms.ComboBox();
            this.cmbCiudadOrigenRutas = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1248, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 12;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lbltitle
            // 
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.lbltitle.Location = new System.Drawing.Point(197, 23);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(186, 32);
            this.lbltitle.TabIndex = 10;
            this.lbltitle.Text = "Grafos Maps";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 154);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label2.Location = new System.Drawing.Point(32, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Estructuras de datos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label1.Location = new System.Drawing.Point(26, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Carlos Flamenco";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Dashboard.Properties.Resources.Untitled_11;
            this.pictureBox1.Location = new System.Drawing.Point(58, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnMapas
            // 
            this.btnMapas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMapas.FlatAppearance.BorderSize = 0;
            this.btnMapas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMapas.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMapas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnMapas.Image = global::Dashboard.Properties.Resources.home;
            this.btnMapas.Location = new System.Drawing.Point(0, 154);
            this.btnMapas.Name = "btnMapas";
            this.btnMapas.Size = new System.Drawing.Size(186, 42);
            this.btnMapas.TabIndex = 1;
            this.btnMapas.Text = "Inicio";
            this.btnMapas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMapas.UseVisualStyleBackColor = true;
            this.btnMapas.Click += new System.EventHandler(this.btnDashbord_Click);
            this.btnMapas.Leave += new System.EventHandler(this.btnDashbord_Leave);
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.pnlNav.Location = new System.Drawing.Point(0, 193);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(3, 100);
            this.pnlNav.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.pnlNav);
            this.panel1.Controls.Add(this.btnMapas);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 761);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panel4.Controls.Add(this.gMapControl1);
            this.panel4.Location = new System.Drawing.Point(203, 62);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1047, 469);
            this.panel4.TabIndex = 36;
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemmory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(0, 3);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(1047, 466);
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 0D;
            this.gMapControl1.Load += new System.EventHandler(this.gMapControl1_Load);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMejorRuta);
            this.groupBox1.Controls.Add(this.cmbCiudadDestino);
            this.groupBox1.Controls.Add(this.cmbCiudadOrigen);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(203, 537);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 99);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Calcular Mejor Ruta";
            // 
            // btnMejorRuta
            // 
            this.btnMejorRuta.Location = new System.Drawing.Point(305, 40);
            this.btnMejorRuta.Name = "btnMejorRuta";
            this.btnMejorRuta.Size = new System.Drawing.Size(75, 23);
            this.btnMejorRuta.TabIndex = 46;
            this.btnMejorRuta.Text = "Mejor Ruta";
            this.btnMejorRuta.UseVisualStyleBackColor = true;
            this.btnMejorRuta.Click += new System.EventHandler(this.btnMejorRuta_Click_1);
            // 
            // cmbCiudadDestino
            // 
            this.cmbCiudadDestino.FormattingEnabled = true;
            this.cmbCiudadDestino.Location = new System.Drawing.Point(159, 42);
            this.cmbCiudadDestino.Name = "cmbCiudadDestino";
            this.cmbCiudadDestino.Size = new System.Drawing.Size(121, 21);
            this.cmbCiudadDestino.TabIndex = 45;
            // 
            // cmbCiudadOrigen
            // 
            this.cmbCiudadOrigen.FormattingEnabled = true;
            this.cmbCiudadOrigen.Location = new System.Drawing.Point(8, 42);
            this.cmbCiudadOrigen.Name = "cmbCiudadOrigen";
            this.cmbCiudadOrigen.Size = new System.Drawing.Size(121, 21);
            this.cmbCiudadOrigen.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label4.Location = new System.Drawing.Point(157, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 12);
            this.label4.TabIndex = 43;
            this.label4.Text = "Ciudad Destino";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label3.Location = new System.Drawing.Point(6, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 12);
            this.label3.TabIndex = 42;
            this.label3.Text = "Ciudad Origen";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAgregarCiudad);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtNombreCiudad);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Location = new System.Drawing.Point(203, 642);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(229, 99);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mantenimiento Ciudades";
            // 
            // btnAgregarCiudad
            // 
            this.btnAgregarCiudad.Location = new System.Drawing.Point(132, 38);
            this.btnAgregarCiudad.Name = "btnAgregarCiudad";
            this.btnAgregarCiudad.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarCiudad.TabIndex = 47;
            this.btnAgregarCiudad.Text = "Agregar Ciudad";
            this.btnAgregarCiudad.UseVisualStyleBackColor = true;
            this.btnAgregarCiudad.Click += new System.EventHandler(this.btnAgregarCiudad_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label5.Location = new System.Drawing.Point(6, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 12);
            this.label5.TabIndex = 43;
            this.label5.Text = "Nombre Ciudad";
            // 
            // txtNombreCiudad
            // 
            this.txtNombreCiudad.Location = new System.Drawing.Point(7, 39);
            this.txtNombreCiudad.Name = "txtNombreCiudad";
            this.txtNombreCiudad.Size = new System.Drawing.Size(100, 20);
            this.txtNombreCiudad.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtPrecio);
            this.groupBox3.Controls.Add(this.btnTrazarRuta);
            this.groupBox3.Controls.Add(this.cmbCiudadDestinoRutas);
            this.groupBox3.Controls.Add(this.cmbCiudadOrigenRutas);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox3.Location = new System.Drawing.Point(612, 537);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(638, 99);
            this.groupBox3.TabIndex = 47;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mantenimiento Rutas";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label8.Location = new System.Drawing.Point(306, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 12);
            this.label8.TabIndex = 48;
            this.label8.Text = "Precio";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(307, 42);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 20);
            this.txtPrecio.TabIndex = 47;
            this.txtPrecio.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnTrazarRuta
            // 
            this.btnTrazarRuta.Location = new System.Drawing.Point(433, 40);
            this.btnTrazarRuta.Name = "btnTrazarRuta";
            this.btnTrazarRuta.Size = new System.Drawing.Size(75, 23);
            this.btnTrazarRuta.TabIndex = 46;
            this.btnTrazarRuta.Text = "Trazar Ruta";
            this.btnTrazarRuta.UseVisualStyleBackColor = true;
            this.btnTrazarRuta.Click += new System.EventHandler(this.btnTrazarRuta_Click);
            // 
            // cmbCiudadDestinoRutas
            // 
            this.cmbCiudadDestinoRutas.FormattingEnabled = true;
            this.cmbCiudadDestinoRutas.Location = new System.Drawing.Point(159, 42);
            this.cmbCiudadDestinoRutas.Name = "cmbCiudadDestinoRutas";
            this.cmbCiudadDestinoRutas.Size = new System.Drawing.Size(121, 21);
            this.cmbCiudadDestinoRutas.TabIndex = 45;
            // 
            // cmbCiudadOrigenRutas
            // 
            this.cmbCiudadOrigenRutas.FormattingEnabled = true;
            this.cmbCiudadOrigenRutas.Location = new System.Drawing.Point(8, 42);
            this.cmbCiudadOrigenRutas.Name = "cmbCiudadOrigenRutas";
            this.cmbCiudadOrigenRutas.Size = new System.Drawing.Size(121, 21);
            this.cmbCiudadOrigenRutas.TabIndex = 44;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label6.Location = new System.Drawing.Point(157, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 12);
            this.label6.TabIndex = 43;
            this.label6.Text = "Ciudad Destino";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label7.Location = new System.Drawing.Point(6, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 12);
            this.label7.TabIndex = 42;
            this.label7.Text = "Ciudad Origen";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1277, 761);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbltitle);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Opacity = 0.97D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnMapas;
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMejorRuta;
        private System.Windows.Forms.ComboBox cmbCiudadDestino;
        private System.Windows.Forms.ComboBox cmbCiudadOrigen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAgregarCiudad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNombreCiudad;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnTrazarRuta;
        private System.Windows.Forms.ComboBox cmbCiudadDestinoRutas;
        private System.Windows.Forms.ComboBox cmbCiudadOrigenRutas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPrecio;
    }
}

