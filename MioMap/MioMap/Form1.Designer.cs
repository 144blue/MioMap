using System;

namespace MioMap
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
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.rbParadas = new System.Windows.Forms.RadioButton();
            this.rbEstaciones = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rbTodo = new System.Windows.Forms.RadioButton();
            this.btMostrar = new System.Windows.Forms.Button();
            this.panelOpciones = new System.Windows.Forms.Panel();
            this.panelMapa = new System.Windows.Forms.Panel();
            this.panelOpciones.SuspendLayout();
            this.panelMapa.SuspendLayout();
            this.SuspendLayout();
            // 
            // gMapControl1
            // 
            this.gMapControl1.AutoScroll = true;
            this.gMapControl1.AutoSize = true;
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemmory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(3, 3);
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
            this.gMapControl1.Size = new System.Drawing.Size(534, 310);
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 0D;
            this.gMapControl1.Load += new System.EventHandler(this.GMapControl1_Load);
            // 
            // rbParadas
            // 
            this.rbParadas.AutoSize = true;
            this.rbParadas.Location = new System.Drawing.Point(20, 86);
            this.rbParadas.Name = "rbParadas";
            this.rbParadas.Size = new System.Drawing.Size(77, 17);
            this.rbParadas.TabIndex = 1;
            this.rbParadas.Text = "Estaciones";
            this.rbParadas.UseVisualStyleBackColor = true;
            this.rbParadas.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
            // 
            // rbEstaciones
            // 
            this.rbEstaciones.AutoSize = true;
            this.rbEstaciones.Location = new System.Drawing.Point(20, 127);
            this.rbEstaciones.Name = "rbEstaciones";
            this.rbEstaciones.Size = new System.Drawing.Size(64, 17);
            this.rbEstaciones.TabIndex = 2;
            this.rbEstaciones.Text = "Paradas";
            this.rbEstaciones.UseVisualStyleBackColor = true;
            this.rbEstaciones.CheckedChanged += new System.EventHandler(this.RadioButton2_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mostrar alguna de las siguientes opciones:";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // rbTodo
            // 
            this.rbTodo.AutoSize = true;
            this.rbTodo.Location = new System.Drawing.Point(20, 48);
            this.rbTodo.Name = "rbTodo";
            this.rbTodo.Size = new System.Drawing.Size(50, 17);
            this.rbTodo.TabIndex = 4;
            this.rbTodo.Text = "Todo";
            this.rbTodo.UseVisualStyleBackColor = true;
            this.rbTodo.CheckedChanged += new System.EventHandler(this.rbTodo_CheckedChanged);
            // 
            // btMostrar
            // 
            this.btMostrar.Location = new System.Drawing.Point(20, 166);
            this.btMostrar.Name = "btMostrar";
            this.btMostrar.Size = new System.Drawing.Size(106, 24);
            this.btMostrar.TabIndex = 5;
            this.btMostrar.Text = "Mostrar";
            this.btMostrar.UseVisualStyleBackColor = true;
            this.btMostrar.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelOpciones
            // 
            this.panelOpciones.AutoSize = true;
            this.panelOpciones.Controls.Add(this.label1);
            this.panelOpciones.Controls.Add(this.btMostrar);
            this.panelOpciones.Controls.Add(this.rbTodo);
            this.panelOpciones.Controls.Add(this.rbParadas);
            this.panelOpciones.Controls.Add(this.rbEstaciones);
            this.panelOpciones.Location = new System.Drawing.Point(574, 12);
            this.panelOpciones.Name = "panelOpciones";
            this.panelOpciones.Size = new System.Drawing.Size(227, 341);
            this.panelOpciones.TabIndex = 6;
            // 
            // panelMapa
            // 
            this.panelMapa.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMapa.Controls.Add(this.gMapControl1);
            this.panelMapa.Location = new System.Drawing.Point(12, 12);
            this.panelMapa.Name = "panelMapa";
            this.panelMapa.Size = new System.Drawing.Size(556, 341);
            this.panelMapa.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(816, 364);
            this.Controls.Add(this.panelMapa);
            this.Controls.Add(this.panelOpciones);
            this.Name = "Form1";
            this.Text = "Gestión de paradas y estaciones de MIO";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelOpciones.ResumeLayout(false);
            this.panelOpciones.PerformLayout();
            this.panelMapa.ResumeLayout(false);
            this.panelMapa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.RadioButton rbParadas;
        private System.Windows.Forms.RadioButton rbEstaciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbTodo;
        private System.Windows.Forms.Button btMostrar;
        private System.Windows.Forms.Panel panelOpciones;
        private System.Windows.Forms.Panel panelMapa;
    }
}

