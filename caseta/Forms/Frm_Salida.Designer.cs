namespace caseta.Forms
{
    partial class Frm_Salida
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
            this.TxBx_Descripcion = new System.Windows.Forms.TextBox();
            this.TxBx_Direccion = new System.Windows.Forms.TextBox();
            this.Lbl_Descripcion = new System.Windows.Forms.Label();
            this.Lbl_Direccion = new System.Windows.Forms.Label();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.TxtBx_Search = new System.Windows.Forms.TextBox();
            this.DGV_Visitas = new System.Windows.Forms.DataGridView();
            this.Btn_Salida = new System.Windows.Forms.Button();
            this.TxBx_Nombre = new System.Windows.Forms.TextBox();
            this.TxBx_Placas = new System.Windows.Forms.TextBox();
            this.Lbl_Nombre = new System.Windows.Forms.Label();
            this.Lbl_Placas = new System.Windows.Forms.Label();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.SPC_PlacaTrasera = new WebEye.Controls.WinForms.StreamPlayerControl.StreamPlayerControl();
            this.SPC_PlacaDelantera = new WebEye.Controls.WinForms.StreamPlayerControl.StreamPlayerControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Cmn_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cmn_Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cmn_Domicilio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cmn_Ingreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cmn_Placas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cmn_Foto = new System.Windows.Forms.DataGridViewImageColumn();
            this.Cmn_UrlFoto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Visitas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxBx_Descripcion
            // 
            this.TxBx_Descripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxBx_Descripcion.Location = new System.Drawing.Point(132, 131);
            this.TxBx_Descripcion.Margin = new System.Windows.Forms.Padding(2);
            this.TxBx_Descripcion.Name = "TxBx_Descripcion";
            this.TxBx_Descripcion.Size = new System.Drawing.Size(289, 20);
            this.TxBx_Descripcion.TabIndex = 39;
            // 
            // TxBx_Direccion
            // 
            this.TxBx_Direccion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxBx_Direccion.Location = new System.Drawing.Point(131, 105);
            this.TxBx_Direccion.Margin = new System.Windows.Forms.Padding(2);
            this.TxBx_Direccion.Name = "TxBx_Direccion";
            this.TxBx_Direccion.Size = new System.Drawing.Size(289, 20);
            this.TxBx_Direccion.TabIndex = 38;
            // 
            // Lbl_Descripcion
            // 
            this.Lbl_Descripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Descripcion.AutoSize = true;
            this.Lbl_Descripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Descripcion.Location = new System.Drawing.Point(6, 125);
            this.Lbl_Descripcion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Descripcion.Name = "Lbl_Descripcion";
            this.Lbl_Descripcion.Size = new System.Drawing.Size(125, 25);
            this.Lbl_Descripcion.TabIndex = 37;
            this.Lbl_Descripcion.Text = "Descripción";
            // 
            // Lbl_Direccion
            // 
            this.Lbl_Direccion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Direccion.AutoSize = true;
            this.Lbl_Direccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Direccion.Location = new System.Drawing.Point(6, 99);
            this.Lbl_Direccion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Direccion.Name = "Lbl_Direccion";
            this.Lbl_Direccion.Size = new System.Drawing.Size(102, 25);
            this.Lbl_Direccion.TabIndex = 36;
            this.Lbl_Direccion.Text = "Dirección";
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Buscar.Location = new System.Drawing.Point(478, 13);
            this.Btn_Buscar.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(106, 20);
            this.Btn_Buscar.TabIndex = 35;
            this.Btn_Buscar.Text = "BUSCAR";
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            // 
            // TxtBx_Search
            // 
            this.TxtBx_Search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBx_Search.Location = new System.Drawing.Point(11, 14);
            this.TxtBx_Search.Margin = new System.Windows.Forms.Padding(2);
            this.TxtBx_Search.Name = "TxtBx_Search";
            this.TxtBx_Search.Size = new System.Drawing.Size(463, 20);
            this.TxtBx_Search.TabIndex = 34;
            // 
            // DGV_Visitas
            // 
            this.DGV_Visitas.AllowUserToAddRows = false;
            this.DGV_Visitas.AllowUserToDeleteRows = false;
            this.DGV_Visitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Visitas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cmn_Id,
            this.Cmn_Nombre,
            this.Cmn_Domicilio,
            this.Cmn_Ingreso,
            this.Cmn_Placas,
            this.Cmn_Foto,
            this.Cmn_UrlFoto});
            this.DGV_Visitas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Visitas.Location = new System.Drawing.Point(603, 357);
            this.DGV_Visitas.Name = "DGV_Visitas";
            this.DGV_Visitas.ReadOnly = true;
            this.DGV_Visitas.RowHeadersVisible = false;
            this.DGV_Visitas.Size = new System.Drawing.Size(595, 348);
            this.DGV_Visitas.TabIndex = 0;
            this.DGV_Visitas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Visitas_CellDoubleClick);
            this.DGV_Visitas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGV_Visitas_CellFormatting);
            // 
            // Btn_Salida
            // 
            this.Btn_Salida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Salida.Location = new System.Drawing.Point(437, 70);
            this.Btn_Salida.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Salida.Name = "Btn_Salida";
            this.Btn_Salida.Size = new System.Drawing.Size(132, 55);
            this.Btn_Salida.TabIndex = 32;
            this.Btn_Salida.Text = "Salida";
            this.Btn_Salida.UseVisualStyleBackColor = true;
            // 
            // TxBx_Nombre
            // 
            this.TxBx_Nombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxBx_Nombre.Location = new System.Drawing.Point(131, 78);
            this.TxBx_Nombre.Margin = new System.Windows.Forms.Padding(2);
            this.TxBx_Nombre.Name = "TxBx_Nombre";
            this.TxBx_Nombre.Size = new System.Drawing.Size(289, 20);
            this.TxBx_Nombre.TabIndex = 31;
            // 
            // TxBx_Placas
            // 
            this.TxBx_Placas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxBx_Placas.Location = new System.Drawing.Point(131, 52);
            this.TxBx_Placas.Margin = new System.Windows.Forms.Padding(2);
            this.TxBx_Placas.Name = "TxBx_Placas";
            this.TxBx_Placas.Size = new System.Drawing.Size(289, 20);
            this.TxBx_Placas.TabIndex = 30;
            // 
            // Lbl_Nombre
            // 
            this.Lbl_Nombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Nombre.AutoSize = true;
            this.Lbl_Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Nombre.Location = new System.Drawing.Point(6, 72);
            this.Lbl_Nombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Nombre.Name = "Lbl_Nombre";
            this.Lbl_Nombre.Size = new System.Drawing.Size(87, 25);
            this.Lbl_Nombre.TabIndex = 29;
            this.Lbl_Nombre.Text = "Nombre";
            // 
            // Lbl_Placas
            // 
            this.Lbl_Placas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Placas.AutoSize = true;
            this.Lbl_Placas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Placas.Location = new System.Drawing.Point(6, 46);
            this.Lbl_Placas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Placas.Name = "Lbl_Placas";
            this.Lbl_Placas.Size = new System.Drawing.Size(77, 25);
            this.Lbl_Placas.TabIndex = 28;
            this.Lbl_Placas.Text = "Placas";
            // 
            // pictureBox13
            // 
            this.pictureBox13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox13.Location = new System.Drawing.Point(2, 2);
            this.pictureBox13.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(290, 164);
            this.pictureBox13.TabIndex = 27;
            this.pictureBox13.TabStop = false;
            // 
            // pictureBox14
            // 
            this.pictureBox14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox14.Location = new System.Drawing.Point(296, 2);
            this.pictureBox14.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(291, 164);
            this.pictureBox14.TabIndex = 26;
            this.pictureBox14.TabStop = false;
            // 
            // SPC_PlacaTrasera
            // 
            this.SPC_PlacaTrasera.AutoSize = true;
            this.SPC_PlacaTrasera.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SPC_PlacaTrasera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SPC_PlacaTrasera.Location = new System.Drawing.Point(3, 3);
            this.SPC_PlacaTrasera.Name = "SPC_PlacaTrasera";
            this.SPC_PlacaTrasera.Size = new System.Drawing.Size(594, 348);
            this.SPC_PlacaTrasera.TabIndex = 7;
            // 
            // SPC_PlacaDelantera
            // 
            this.SPC_PlacaDelantera.AutoSize = true;
            this.SPC_PlacaDelantera.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SPC_PlacaDelantera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SPC_PlacaDelantera.Location = new System.Drawing.Point(3, 357);
            this.SPC_PlacaDelantera.Name = "SPC_PlacaDelantera";
            this.SPC_PlacaDelantera.Size = new System.Drawing.Size(594, 348);
            this.SPC_PlacaDelantera.TabIndex = 35;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.DGV_Visitas, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.SPC_PlacaTrasera, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.SPC_PlacaDelantera, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1201, 708);
            this.tableLayoutPanel1.TabIndex = 37;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(603, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(595, 348);
            this.tableLayoutPanel2.TabIndex = 41;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.pictureBox14, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.pictureBox13, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 177);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(589, 168);
            this.tableLayoutPanel3.TabIndex = 42;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Lbl_Placas);
            this.panel1.Controls.Add(this.TxBx_Descripcion);
            this.panel1.Controls.Add(this.Lbl_Nombre);
            this.panel1.Controls.Add(this.TxBx_Direccion);
            this.panel1.Controls.Add(this.TxBx_Placas);
            this.panel1.Controls.Add(this.Lbl_Descripcion);
            this.panel1.Controls.Add(this.TxBx_Nombre);
            this.panel1.Controls.Add(this.Lbl_Direccion);
            this.panel1.Controls.Add(this.Btn_Salida);
            this.panel1.Controls.Add(this.Btn_Buscar);
            this.panel1.Controls.Add(this.TxtBx_Search);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(589, 168);
            this.panel1.TabIndex = 40;
            // 
            // Cmn_Id
            // 
            this.Cmn_Id.DataPropertyName = "IdVisita";
            this.Cmn_Id.HeaderText = "ID";
            this.Cmn_Id.Name = "Cmn_Id";
            this.Cmn_Id.ReadOnly = true;
            this.Cmn_Id.Visible = false;
            // 
            // Cmn_Nombre
            // 
            this.Cmn_Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cmn_Nombre.DataPropertyName = "NombreCompleto";
            this.Cmn_Nombre.HeaderText = "Nombre";
            this.Cmn_Nombre.Name = "Cmn_Nombre";
            this.Cmn_Nombre.ReadOnly = true;
            // 
            // Cmn_Domicilio
            // 
            this.Cmn_Domicilio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cmn_Domicilio.DataPropertyName = "Domicilio";
            this.Cmn_Domicilio.HeaderText = "Domicilio";
            this.Cmn_Domicilio.Name = "Cmn_Domicilio";
            this.Cmn_Domicilio.ReadOnly = true;
            // 
            // Cmn_Ingreso
            // 
            this.Cmn_Ingreso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Cmn_Ingreso.DataPropertyName = "FechaIngreso";
            this.Cmn_Ingreso.HeaderText = "Ingreso";
            this.Cmn_Ingreso.Name = "Cmn_Ingreso";
            this.Cmn_Ingreso.ReadOnly = true;
            this.Cmn_Ingreso.Width = 67;
            // 
            // Cmn_Placas
            // 
            this.Cmn_Placas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Cmn_Placas.DataPropertyName = "Placas";
            this.Cmn_Placas.HeaderText = "Placas";
            this.Cmn_Placas.Name = "Cmn_Placas";
            this.Cmn_Placas.ReadOnly = true;
            this.Cmn_Placas.Width = 64;
            // 
            // Cmn_Foto
            // 
            this.Cmn_Foto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Cmn_Foto.HeaderText = "Foto";
            this.Cmn_Foto.Name = "Cmn_Foto";
            this.Cmn_Foto.ReadOnly = true;
            this.Cmn_Foto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Cmn_Foto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Cmn_Foto.Width = 53;
            // 
            // Cmn_UrlFoto
            // 
            this.Cmn_UrlFoto.DataPropertyName = "FotoRostro";
            this.Cmn_UrlFoto.HeaderText = "url";
            this.Cmn_UrlFoto.Name = "Cmn_UrlFoto";
            this.Cmn_UrlFoto.ReadOnly = true;
            this.Cmn_UrlFoto.Visible = false;
            // 
            // Frm_Salida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 708);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Frm_Salida";
            this.Text = "Salida Visita";
            this.Load += new System.EventHandler(this.Frm_Salida_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Visitas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Btn_Salida;
        private System.Windows.Forms.TextBox TxBx_Nombre;
        private System.Windows.Forms.TextBox TxBx_Placas;
        private System.Windows.Forms.Label Lbl_Nombre;
        private System.Windows.Forms.Label Lbl_Placas;
        private System.Windows.Forms.PictureBox pictureBox13;
        private System.Windows.Forms.PictureBox pictureBox14;
        private WebEye.Controls.WinForms.StreamPlayerControl.StreamPlayerControl SPC_PlacaTrasera;
        private WebEye.Controls.WinForms.StreamPlayerControl.StreamPlayerControl SPC_PlacaDelantera;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.TextBox TxtBx_Search;
        private System.Windows.Forms.DataGridView DGV_Visitas;
        private System.Windows.Forms.TextBox TxBx_Descripcion;
        private System.Windows.Forms.TextBox TxBx_Direccion;
        private System.Windows.Forms.Label Lbl_Descripcion;
        private System.Windows.Forms.Label Lbl_Direccion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cmn_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cmn_Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cmn_Domicilio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cmn_Ingreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cmn_Placas;
        private System.Windows.Forms.DataGridViewImageColumn Cmn_Foto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cmn_UrlFoto;
    }
}