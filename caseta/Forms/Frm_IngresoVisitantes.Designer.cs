﻿namespace caseta
{
    partial class Frm_IngresoVisita
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
            this.SPC_Credencial = new WebEye.Controls.WinForms.StreamPlayerControl.StreamPlayerControl();
            this.SPC_Rostro = new WebEye.Controls.WinForms.StreamPlayerControl.StreamPlayerControl();
            this.SPC_PlacaDelantera = new WebEye.Controls.WinForms.StreamPlayerControl.StreamPlayerControl();
            this.SPC_PLacaT = new WebEye.Controls.WinForms.StreamPlayerControl.StreamPlayerControl();
            this.Lbl_Credential = new System.Windows.Forms.Label();
            this.Lbl_Face = new System.Windows.Forms.Label();
            this.Lbl_PlacaT = new System.Windows.Forms.Label();
            this.Lbl_PlacaD = new System.Windows.Forms.Label();
            this.Gbx_Busqueda = new System.Windows.Forms.GroupBox();
            this.DGV_Busqueda = new System.Windows.Forms.DataGridView();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Tbx_Busqueda = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.gbVisitantesActuales = new System.Windows.Forms.GroupBox();
            this.DGV_VisitantesActuales = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.Gbx_Registro = new System.Windows.Forms.GroupBox();
            this.Cbbx_Domicilio = new System.Windows.Forms.ComboBox();
            this.Tbx_Apellidos = new System.Windows.Forms.TextBox();
            this.Lbl_Apellidos = new System.Windows.Forms.Label();
            this.Tbx_Nombre = new System.Windows.Forms.TextBox();
            this.Lbl_Nombre = new System.Windows.Forms.Label();
            this.Lbl_Domicilio = new System.Windows.Forms.Label();
            this.Lbl_RType = new System.Windows.Forms.Label();
            this.Cbbx_RType = new System.Windows.Forms.ComboBox();
            this.Tbx_Desc = new System.Windows.Forms.TextBox();
            this.Tbx_PLacas = new System.Windows.Forms.TextBox();
            this.Lbl_Desc = new System.Windows.Forms.Label();
            this.Btn_PAcceso = new System.Windows.Forms.Button();
            this.Lbl_Placas = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.Gbx_Busqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Busqueda)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.gbVisitantesActuales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_VisitantesActuales)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.Gbx_Registro.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // SPC_Credencial
            // 
            this.SPC_Credencial.BackColor = System.Drawing.Color.CadetBlue;
            this.SPC_Credencial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SPC_Credencial.Location = new System.Drawing.Point(3, 267);
            this.SPC_Credencial.Name = "SPC_Credencial";
            this.SPC_Credencial.Size = new System.Drawing.Size(349, 213);
            this.SPC_Credencial.TabIndex = 34;
            // 
            // SPC_Rostro
            // 
            this.SPC_Rostro.BackColor = System.Drawing.SystemColors.ControlDark;
            this.SPC_Rostro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SPC_Rostro.Location = new System.Drawing.Point(358, 267);
            this.SPC_Rostro.Name = "SPC_Rostro";
            this.SPC_Rostro.Size = new System.Drawing.Size(350, 213);
            this.SPC_Rostro.TabIndex = 33;
            // 
            // SPC_PlacaDelantera
            // 
            this.SPC_PlacaDelantera.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.SPC_PlacaDelantera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SPC_PlacaDelantera.Location = new System.Drawing.Point(358, 26);
            this.SPC_PlacaDelantera.Name = "SPC_PlacaDelantera";
            this.SPC_PlacaDelantera.Size = new System.Drawing.Size(350, 212);
            this.SPC_PlacaDelantera.TabIndex = 32;
            // 
            // SPC_PLacaT
            // 
            this.SPC_PLacaT.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.SPC_PLacaT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SPC_PLacaT.Location = new System.Drawing.Point(3, 26);
            this.SPC_PLacaT.Name = "SPC_PLacaT";
            this.SPC_PLacaT.Size = new System.Drawing.Size(349, 212);
            this.SPC_PLacaT.TabIndex = 31;
            // 
            // Lbl_Credential
            // 
            this.Lbl_Credential.AutoSize = true;
            this.Lbl_Credential.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Credential.Location = new System.Drawing.Point(2, 241);
            this.Lbl_Credential.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Credential.Name = "Lbl_Credential";
            this.Lbl_Credential.Size = new System.Drawing.Size(94, 20);
            this.Lbl_Credential.TabIndex = 7;
            this.Lbl_Credential.Text = "Credencial";
            // 
            // Lbl_Face
            // 
            this.Lbl_Face.AutoSize = true;
            this.Lbl_Face.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Face.Location = new System.Drawing.Point(357, 241);
            this.Lbl_Face.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Face.Name = "Lbl_Face";
            this.Lbl_Face.Size = new System.Drawing.Size(63, 20);
            this.Lbl_Face.TabIndex = 2;
            this.Lbl_Face.Text = "Rostro";
            // 
            // Lbl_PlacaT
            // 
            this.Lbl_PlacaT.AutoSize = true;
            this.Lbl_PlacaT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_PlacaT.Location = new System.Drawing.Point(357, 0);
            this.Lbl_PlacaT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_PlacaT.Name = "Lbl_PlacaT";
            this.Lbl_PlacaT.Size = new System.Drawing.Size(137, 20);
            this.Lbl_PlacaT.TabIndex = 1;
            this.Lbl_PlacaT.Text = "Placa Delantera";
            // 
            // Lbl_PlacaD
            // 
            this.Lbl_PlacaD.AutoSize = true;
            this.Lbl_PlacaD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_PlacaD.Location = new System.Drawing.Point(2, 0);
            this.Lbl_PlacaD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_PlacaD.Name = "Lbl_PlacaD";
            this.Lbl_PlacaD.Size = new System.Drawing.Size(119, 20);
            this.Lbl_PlacaD.TabIndex = 0;
            this.Lbl_PlacaD.Text = "Placa Trasera";
            // 
            // Gbx_Busqueda
            // 
            this.Gbx_Busqueda.Controls.Add(this.DGV_Busqueda);
            this.Gbx_Busqueda.Controls.Add(this.Btn_Buscar);
            this.Gbx_Busqueda.Controls.Add(this.Tbx_Busqueda);
            this.Gbx_Busqueda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gbx_Busqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gbx_Busqueda.Location = new System.Drawing.Point(600, 3);
            this.Gbx_Busqueda.Name = "Gbx_Busqueda";
            this.Gbx_Busqueda.Size = new System.Drawing.Size(592, 201);
            this.Gbx_Busqueda.TabIndex = 35;
            this.Gbx_Busqueda.TabStop = false;
            this.Gbx_Busqueda.Text = "Busqueda";
            // 
            // DGV_Busqueda
            // 
            this.DGV_Busqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_Busqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Busqueda.Location = new System.Drawing.Point(6, 49);
            this.DGV_Busqueda.Name = "DGV_Busqueda";
            this.DGV_Busqueda.Size = new System.Drawing.Size(580, 146);
            this.DGV_Busqueda.TabIndex = 26;
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Buscar.Location = new System.Drawing.Point(465, 21);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(121, 23);
            this.Btn_Buscar.TabIndex = 1;
            this.Btn_Buscar.Text = "Buscar";
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            // 
            // Tbx_Busqueda
            // 
            this.Tbx_Busqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tbx_Busqueda.Location = new System.Drawing.Point(6, 21);
            this.Tbx_Busqueda.Name = "Tbx_Busqueda";
            this.Tbx_Busqueda.Size = new System.Drawing.Size(453, 22);
            this.Tbx_Busqueda.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.Lbl_PlacaD, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.SPC_PLacaT, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.SPC_Credencial, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.SPC_Rostro, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.Lbl_PlacaT, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Lbl_Face, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.SPC_PlacaDelantera, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Lbl_Credential, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(711, 483);
            this.tableLayoutPanel1.TabIndex = 36;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.gbVisitantesActuales, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1195, 489);
            this.tableLayoutPanel2.TabIndex = 37;
            // 
            // gbVisitantesActuales
            // 
            this.gbVisitantesActuales.Controls.Add(this.DGV_VisitantesActuales);
            this.gbVisitantesActuales.Controls.Add(this.label11);
            this.gbVisitantesActuales.Controls.Add(this.label10);
            this.gbVisitantesActuales.Controls.Add(this.label9);
            this.gbVisitantesActuales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbVisitantesActuales.Location = new System.Drawing.Point(719, 2);
            this.gbVisitantesActuales.Margin = new System.Windows.Forms.Padding(2);
            this.gbVisitantesActuales.Name = "gbVisitantesActuales";
            this.gbVisitantesActuales.Padding = new System.Windows.Forms.Padding(2);
            this.gbVisitantesActuales.Size = new System.Drawing.Size(474, 485);
            this.gbVisitantesActuales.TabIndex = 1;
            this.gbVisitantesActuales.TabStop = false;
            this.gbVisitantesActuales.Text = "Visitantes Actuales";
            // 
            // DGV_VisitantesActuales
            // 
            this.DGV_VisitantesActuales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_VisitantesActuales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_VisitantesActuales.Location = new System.Drawing.Point(5, 48);
            this.DGV_VisitantesActuales.Name = "DGV_VisitantesActuales";
            this.DGV_VisitantesActuales.Size = new System.Drawing.Size(464, 453);
            this.DGV_VisitantesActuales.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(201, 15);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Pre Registro";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 32);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Preferentes";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 15);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "No. de Visitantes";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.Gbx_Busqueda, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.Gbx_Registro, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 498);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 207F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1195, 207);
            this.tableLayoutPanel3.TabIndex = 39;
            // 
            // Gbx_Registro
            // 
            this.Gbx_Registro.Controls.Add(this.Cbbx_Domicilio);
            this.Gbx_Registro.Controls.Add(this.Tbx_Apellidos);
            this.Gbx_Registro.Controls.Add(this.Lbl_Apellidos);
            this.Gbx_Registro.Controls.Add(this.Tbx_Nombre);
            this.Gbx_Registro.Controls.Add(this.Lbl_Nombre);
            this.Gbx_Registro.Controls.Add(this.Lbl_Domicilio);
            this.Gbx_Registro.Controls.Add(this.Lbl_RType);
            this.Gbx_Registro.Controls.Add(this.Cbbx_RType);
            this.Gbx_Registro.Controls.Add(this.Tbx_Desc);
            this.Gbx_Registro.Controls.Add(this.Tbx_PLacas);
            this.Gbx_Registro.Controls.Add(this.Lbl_Desc);
            this.Gbx_Registro.Controls.Add(this.Btn_PAcceso);
            this.Gbx_Registro.Controls.Add(this.Lbl_Placas);
            this.Gbx_Registro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gbx_Registro.Location = new System.Drawing.Point(3, 3);
            this.Gbx_Registro.Name = "Gbx_Registro";
            this.Gbx_Registro.Size = new System.Drawing.Size(591, 201);
            this.Gbx_Registro.TabIndex = 41;
            this.Gbx_Registro.TabStop = false;
            // 
            // Cbbx_Domicilio
            // 
            this.Cbbx_Domicilio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Cbbx_Domicilio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Cbbx_Domicilio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.Cbbx_Domicilio.FormattingEnabled = true;
            this.Cbbx_Domicilio.Location = new System.Drawing.Point(152, 27);
            this.Cbbx_Domicilio.Margin = new System.Windows.Forms.Padding(2);
            this.Cbbx_Domicilio.Name = "Cbbx_Domicilio";
            this.Cbbx_Domicilio.Size = new System.Drawing.Size(431, 21);
            this.Cbbx_Domicilio.TabIndex = 2;
            this.Cbbx_Domicilio.Validating += new System.ComponentModel.CancelEventHandler(this.Cbbx_Domicilio_Validating);
            // 
            // Tbx_Apellidos
            // 
            this.Tbx_Apellidos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tbx_Apellidos.Location = new System.Drawing.Point(152, 96);
            this.Tbx_Apellidos.Margin = new System.Windows.Forms.Padding(2);
            this.Tbx_Apellidos.Name = "Tbx_Apellidos";
            this.Tbx_Apellidos.Size = new System.Drawing.Size(430, 20);
            this.Tbx_Apellidos.TabIndex = 5;
            this.Tbx_Apellidos.Validating += new System.ComponentModel.CancelEventHandler(this.Tbx_Apellidos_Validating);
            // 
            // Lbl_Apellidos
            // 
            this.Lbl_Apellidos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Apellidos.AutoSize = true;
            this.Lbl_Apellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Apellidos.Location = new System.Drawing.Point(8, 90);
            this.Lbl_Apellidos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Apellidos.Name = "Lbl_Apellidos";
            this.Lbl_Apellidos.Size = new System.Drawing.Size(100, 25);
            this.Lbl_Apellidos.TabIndex = 35;
            this.Lbl_Apellidos.Text = "Apellidos";
            // 
            // Tbx_Nombre
            // 
            this.Tbx_Nombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tbx_Nombre.Location = new System.Drawing.Point(152, 73);
            this.Tbx_Nombre.Margin = new System.Windows.Forms.Padding(2);
            this.Tbx_Nombre.Name = "Tbx_Nombre";
            this.Tbx_Nombre.Size = new System.Drawing.Size(430, 20);
            this.Tbx_Nombre.TabIndex = 4;
            this.Tbx_Nombre.Validating += new System.ComponentModel.CancelEventHandler(this.Tbx_Nombre_Validating);
            // 
            // Lbl_Nombre
            // 
            this.Lbl_Nombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Nombre.AutoSize = true;
            this.Lbl_Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Nombre.Location = new System.Drawing.Point(8, 67);
            this.Lbl_Nombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Nombre.Name = "Lbl_Nombre";
            this.Lbl_Nombre.Size = new System.Drawing.Size(87, 25);
            this.Lbl_Nombre.TabIndex = 33;
            this.Lbl_Nombre.Text = "Nombre";
            // 
            // Lbl_Domicilio
            // 
            this.Lbl_Domicilio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Domicilio.AutoSize = true;
            this.Lbl_Domicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Domicilio.Location = new System.Drawing.Point(8, 21);
            this.Lbl_Domicilio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Domicilio.Name = "Lbl_Domicilio";
            this.Lbl_Domicilio.Size = new System.Drawing.Size(99, 25);
            this.Lbl_Domicilio.TabIndex = 31;
            this.Lbl_Domicilio.Text = "Domicilio";
            // 
            // Lbl_RType
            // 
            this.Lbl_RType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_RType.AutoSize = true;
            this.Lbl_RType.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_RType.Location = new System.Drawing.Point(8, -3);
            this.Lbl_RType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_RType.Name = "Lbl_RType";
            this.Lbl_RType.Size = new System.Drawing.Size(140, 25);
            this.Lbl_RType.TabIndex = 11;
            this.Lbl_RType.Text = "Tipo Registro";
            // 
            // Cbbx_RType
            // 
            this.Cbbx_RType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Cbbx_RType.FormattingEnabled = true;
            this.Cbbx_RType.Location = new System.Drawing.Point(152, 3);
            this.Cbbx_RType.Margin = new System.Windows.Forms.Padding(2);
            this.Cbbx_RType.Name = "Cbbx_RType";
            this.Cbbx_RType.Size = new System.Drawing.Size(431, 21);
            this.Cbbx_RType.TabIndex = 1;
            this.Cbbx_RType.Validating += new System.ComponentModel.CancelEventHandler(this.Cbx_RType_Validating);
            // 
            // Tbx_Desc
            // 
            this.Tbx_Desc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tbx_Desc.Location = new System.Drawing.Point(152, 120);
            this.Tbx_Desc.Margin = new System.Windows.Forms.Padding(2);
            this.Tbx_Desc.Name = "Tbx_Desc";
            this.Tbx_Desc.Size = new System.Drawing.Size(431, 20);
            this.Tbx_Desc.TabIndex = 6;
            // 
            // Tbx_PLacas
            // 
            this.Tbx_PLacas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tbx_PLacas.Location = new System.Drawing.Point(152, 50);
            this.Tbx_PLacas.Margin = new System.Windows.Forms.Padding(2);
            this.Tbx_PLacas.MaxLength = 7;
            this.Tbx_PLacas.Name = "Tbx_PLacas";
            this.Tbx_PLacas.Size = new System.Drawing.Size(234, 20);
            this.Tbx_PLacas.TabIndex = 3;
            this.Tbx_PLacas.Validating += new System.ComponentModel.CancelEventHandler(this.Tbx_PLacas_Validating);
            // 
            // Lbl_Desc
            // 
            this.Lbl_Desc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Desc.AutoSize = true;
            this.Lbl_Desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Desc.Location = new System.Drawing.Point(8, 114);
            this.Lbl_Desc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Desc.Name = "Lbl_Desc";
            this.Lbl_Desc.Size = new System.Drawing.Size(125, 25);
            this.Lbl_Desc.TabIndex = 29;
            this.Lbl_Desc.Text = "Descripción";
            // 
            // Btn_PAcceso
            // 
            this.Btn_PAcceso.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_PAcceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_PAcceso.Location = new System.Drawing.Point(67, 144);
            this.Btn_PAcceso.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_PAcceso.Name = "Btn_PAcceso";
            this.Btn_PAcceso.Size = new System.Drawing.Size(319, 51);
            this.Btn_PAcceso.TabIndex = 7;
            this.Btn_PAcceso.Text = "Pedir Acceso";
            this.Btn_PAcceso.UseVisualStyleBackColor = true;
            this.Btn_PAcceso.Click += new System.EventHandler(this.Btn_PAcceso_Click);
            // 
            // Lbl_Placas
            // 
            this.Lbl_Placas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Placas.AutoSize = true;
            this.Lbl_Placas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Placas.Location = new System.Drawing.Point(8, 44);
            this.Lbl_Placas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Placas.Name = "Lbl_Placas";
            this.Lbl_Placas.Size = new System.Drawing.Size(77, 25);
            this.Lbl_Placas.TabIndex = 8;
            this.Lbl_Placas.Text = "Placas";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1201, 708);
            this.tableLayoutPanel4.TabIndex = 31;
            // 
            // Frm_IngresoVisita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1201, 708);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Frm_IngresoVisita";
            this.Text = "Ingreso Visita";
            this.Load += new System.EventHandler(this.Frm_IngresoVisita_Load);
            this.Gbx_Busqueda.ResumeLayout(false);
            this.Gbx_Busqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Busqueda)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.gbVisitantesActuales.ResumeLayout(false);
            this.gbVisitantesActuales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_VisitantesActuales)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.Gbx_Registro.ResumeLayout(false);
            this.Gbx_Registro.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label Lbl_Credential;
        private System.Windows.Forms.Label Lbl_Face;
        private System.Windows.Forms.Label Lbl_PlacaT;
        private System.Windows.Forms.Label Lbl_PlacaD;
        private WebEye.Controls.WinForms.StreamPlayerControl.StreamPlayerControl SPC_PLacaT;
        private WebEye.Controls.WinForms.StreamPlayerControl.StreamPlayerControl SPC_Credencial;
        private WebEye.Controls.WinForms.StreamPlayerControl.StreamPlayerControl SPC_Rostro;
        private WebEye.Controls.WinForms.StreamPlayerControl.StreamPlayerControl SPC_PlacaDelantera;
        private System.Windows.Forms.GroupBox Gbx_Busqueda;
        private System.Windows.Forms.DataGridView DGV_Busqueda;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.TextBox Tbx_Busqueda;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox gbVisitantesActuales;
        private System.Windows.Forms.DataGridView DGV_VisitantesActuales;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.GroupBox Gbx_Registro;
        private System.Windows.Forms.Label Lbl_RType;
        private System.Windows.Forms.ComboBox Cbbx_RType;
        private System.Windows.Forms.TextBox Tbx_Desc;
        private System.Windows.Forms.TextBox Tbx_PLacas;
        private System.Windows.Forms.Label Lbl_Desc;
        private System.Windows.Forms.Button Btn_PAcceso;
        private System.Windows.Forms.Label Lbl_Placas;
        private System.Windows.Forms.TextBox Tbx_Apellidos;
        private System.Windows.Forms.Label Lbl_Apellidos;
        private System.Windows.Forms.TextBox Tbx_Nombre;
        private System.Windows.Forms.Label Lbl_Nombre;
        private System.Windows.Forms.Label Lbl_Domicilio;
        private System.Windows.Forms.ComboBox Cbbx_Domicilio;
    }
}