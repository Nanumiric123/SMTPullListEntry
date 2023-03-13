namespace SMTPullListEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblReelNum = new System.Windows.Forms.Label();
            this.datagridReqData = new System.Windows.Forms.DataGridView();
            this.PART_NUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHORTAGE_QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RECEIVED_QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REF_LOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRINTED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REF_NUM_REEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LBLMESSAGE = new System.Windows.Forms.Label();
            this.btnGeneratePullList = new System.Windows.Forms.Button();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.txtBnum = new System.Windows.Forms.TextBox();
            this.lblBadgeNum = new System.Windows.Forms.Label();
            this.lbl_qtyPerReel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datagridReqData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(16, 313);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(151, 55);
            this.btnSave.TabIndex = 0;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(217, 313);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(151, 55);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Clear";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtMaterial
            // 
            this.txtMaterial.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterial.Location = new System.Drawing.Point(139, 25);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(211, 26);
            this.txtMaterial.TabIndex = 2;
            this.txtMaterial.TabStop = false;
            this.txtMaterial.TextChanged += new System.EventHandler(this.txtMaterial_TextChanged);
            this.txtMaterial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterial.Location = new System.Drawing.Point(67, 28);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(66, 19);
            this.lblMaterial.TabIndex = 3;
            this.lblMaterial.Text = "Material :";
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.Location = new System.Drawing.Point(62, 97);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(71, 19);
            this.lblQty.TabIndex = 4;
            this.lblQty.Text = "Quantity : ";
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(139, 97);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(100, 26);
            this.txtQty.TabIndex = 5;
            this.txtQty.TabStop = false;
            this.txtQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            this.txtQty.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtQty_KeyUp);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.Location = new System.Drawing.Point(60, 133);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(73, 19);
            this.lblLocation.TabIndex = 6;
            this.lblLocation.Text = "Location : ";
            // 
            // lblReelNum
            // 
            this.lblReelNum.AutoSize = true;
            this.lblReelNum.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReelNum.Location = new System.Drawing.Point(31, 171);
            this.lblReelNum.Name = "lblReelNum";
            this.lblReelNum.Size = new System.Drawing.Size(102, 19);
            this.lblReelNum.TabIndex = 7;
            this.lblReelNum.Text = "Reel Quantity : ";
            // 
            // datagridReqData
            // 
            this.datagridReqData.AllowUserToAddRows = false;
            this.datagridReqData.AllowUserToDeleteRows = false;
            this.datagridReqData.AllowUserToOrderColumns = true;
            this.datagridReqData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridReqData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PART_NUMBER,
            this.SHORTAGE_QTY,
            this.RECEIVED_QTY,
            this.REF_LOC,
            this.PRINTED,
            this.REF_NUM_REEL});
            this.datagridReqData.Location = new System.Drawing.Point(390, 12);
            this.datagridReqData.Name = "datagridReqData";
            this.datagridReqData.ReadOnly = true;
            this.datagridReqData.Size = new System.Drawing.Size(650, 445);
            this.datagridReqData.TabIndex = 8;
            this.datagridReqData.TabStop = false;
            this.datagridReqData.SelectionChanged += new System.EventHandler(this.datagridReqData_SelectionChanged);
            // 
            // PART_NUMBER
            // 
            this.PART_NUMBER.DataPropertyName = "PART_NUMBER";
            this.PART_NUMBER.HeaderText = "Part Number";
            this.PART_NUMBER.Name = "PART_NUMBER";
            this.PART_NUMBER.ReadOnly = true;
            // 
            // SHORTAGE_QTY
            // 
            this.SHORTAGE_QTY.DataPropertyName = "SHORTAGE_QTY";
            this.SHORTAGE_QTY.HeaderText = "Shortage Qty";
            this.SHORTAGE_QTY.Name = "SHORTAGE_QTY";
            this.SHORTAGE_QTY.ReadOnly = true;
            // 
            // RECEIVED_QTY
            // 
            this.RECEIVED_QTY.DataPropertyName = "RECEIVED_QTY";
            this.RECEIVED_QTY.HeaderText = "Received Qty";
            this.RECEIVED_QTY.Name = "RECEIVED_QTY";
            this.RECEIVED_QTY.ReadOnly = true;
            // 
            // REF_LOC
            // 
            this.REF_LOC.DataPropertyName = "REF_LOC";
            this.REF_LOC.HeaderText = "Ref. Loc.";
            this.REF_LOC.Name = "REF_LOC";
            this.REF_LOC.ReadOnly = true;
            // 
            // PRINTED
            // 
            this.PRINTED.DataPropertyName = "PRINTED";
            this.PRINTED.HeaderText = "Printed";
            this.PRINTED.Name = "PRINTED";
            this.PRINTED.ReadOnly = true;
            // 
            // REF_NUM_REEL
            // 
            this.REF_NUM_REEL.DataPropertyName = "REF_NUM_REEL";
            this.REF_NUM_REEL.HeaderText = "Ref. Num. Reel";
            this.REF_NUM_REEL.Name = "REF_NUM_REEL";
            this.REF_NUM_REEL.ReadOnly = true;
            // 
            // LBLMESSAGE
            // 
            this.LBLMESSAGE.AutoSize = true;
            this.LBLMESSAGE.BackColor = System.Drawing.Color.Red;
            this.LBLMESSAGE.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLMESSAGE.Location = new System.Drawing.Point(16, 222);
            this.LBLMESSAGE.Name = "LBLMESSAGE";
            this.LBLMESSAGE.Size = new System.Drawing.Size(0, 24);
            this.LBLMESSAGE.TabIndex = 9;
            this.LBLMESSAGE.Visible = false;
            // 
            // btnGeneratePullList
            // 
            this.btnGeneratePullList.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeneratePullList.Location = new System.Drawing.Point(16, 385);
            this.btnGeneratePullList.Name = "btnGeneratePullList";
            this.btnGeneratePullList.Size = new System.Drawing.Size(151, 49);
            this.btnGeneratePullList.TabIndex = 10;
            this.btnGeneratePullList.TabStop = false;
            this.btnGeneratePullList.Text = "Generate Pull List";
            this.btnGeneratePullList.UseVisualStyleBackColor = true;
            this.btnGeneratePullList.Click += new System.EventHandler(this.btnGeneratePullList_Click);
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteSelected.Location = new System.Drawing.Point(217, 385);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(151, 49);
            this.btnDeleteSelected.TabIndex = 11;
            this.btnDeleteSelected.TabStop = false;
            this.btnDeleteSelected.Text = "Delete Selected";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // txtBnum
            // 
            this.txtBnum.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBnum.Location = new System.Drawing.Point(139, 270);
            this.txtBnum.Name = "txtBnum";
            this.txtBnum.Size = new System.Drawing.Size(100, 26);
            this.txtBnum.TabIndex = 12;
            this.txtBnum.TabStop = false;
            this.txtBnum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBnum_KeyPress);
            this.txtBnum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBnum_KeyUp);
            // 
            // lblBadgeNum
            // 
            this.lblBadgeNum.AutoSize = true;
            this.lblBadgeNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBadgeNum.Location = new System.Drawing.Point(9, 272);
            this.lblBadgeNum.Name = "lblBadgeNum";
            this.lblBadgeNum.Size = new System.Drawing.Size(124, 20);
            this.lblBadgeNum.TabIndex = 13;
            this.lblBadgeNum.Text = "BadgeNumber : ";
            // 
            // lbl_qtyPerReel
            // 
            this.lbl_qtyPerReel.AutoSize = true;
            this.lbl_qtyPerReel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_qtyPerReel.Location = new System.Drawing.Point(23, 62);
            this.lbl_qtyPerReel.Name = "lbl_qtyPerReel";
            this.lbl_qtyPerReel.Size = new System.Drawing.Size(152, 23);
            this.lbl_qtyPerReel.TabIndex = 14;
            this.lbl_qtyPerReel.Text = "Quantity / Reel : ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 469);
            this.Controls.Add(this.lbl_qtyPerReel);
            this.Controls.Add(this.lblBadgeNum);
            this.Controls.Add(this.txtBnum);
            this.Controls.Add(this.btnDeleteSelected);
            this.Controls.Add(this.btnGeneratePullList);
            this.Controls.Add(this.LBLMESSAGE);
            this.Controls.Add(this.datagridReqData);
            this.Controls.Add(this.lblReelNum);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.lblMaterial);
            this.Controls.Add(this.txtMaterial);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "SMT Pull List Entry";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagridReqData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblReelNum;
        private System.Windows.Forms.DataGridView datagridReqData;
        private System.Windows.Forms.DataGridViewTextBoxColumn PART_NUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn SHORTAGE_QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn RECEIVED_QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn REF_LOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRINTED;
        private System.Windows.Forms.DataGridViewTextBoxColumn REF_NUM_REEL;
        private System.Windows.Forms.Label LBLMESSAGE;
        private System.Windows.Forms.Button btnGeneratePullList;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.TextBox txtBnum;
        private System.Windows.Forms.Label lblBadgeNum;
        private System.Windows.Forms.Label lbl_qtyPerReel;
    }
}

