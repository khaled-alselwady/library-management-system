namespace LibrarySystem_WindowsForms_.CirculationForms
{
    partial class frmAddEditReservation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtpReservationDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.numericMemberID = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericBookID = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnShowMemberInfo = new FontAwesome.Sharp.IconButton();
            this.btnShowBookInfo = new FontAwesome.Sharp.IconButton();
            this.btnExit = new FontAwesome.Sharp.IconButton();
            this.btnCancel = new FontAwesome.Sharp.IconButton();
            this.btnSave = new FontAwesome.Sharp.IconButton();
            this.lblMode = new System.Windows.Forms.Label();
            this.dgvShowMemberInfo = new System.Windows.Forms.DataGridView();
            this.dgvShowBookInfo = new System.Windows.Forms.DataGridView();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMemberID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBookID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowMemberInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowBookInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel4.Controls.Add(this.btnExit);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(800, 27);
            this.panel4.TabIndex = 78;
            this.panel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel4_MouseDown);
            // 
            // dtpReservationDate
            // 
            this.dtpReservationDate.CalendarFont = new System.Drawing.Font("Tahoma", 12F);
            this.dtpReservationDate.Font = new System.Drawing.Font("Tahoma", 14F);
            this.dtpReservationDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReservationDate.Location = new System.Drawing.Point(305, 389);
            this.dtpReservationDate.Name = "dtpReservationDate";
            this.dtpReservationDate.Size = new System.Drawing.Size(146, 30);
            this.dtpReservationDate.TabIndex = 86;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(140, 393);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 23);
            this.label4.TabIndex = 85;
            this.label4.Text = "Reservation Date:";
            // 
            // numericMemberID
            // 
            this.numericMemberID.Font = new System.Drawing.Font("Tahoma", 14F);
            this.numericMemberID.Location = new System.Drawing.Point(305, 124);
            this.numericMemberID.Name = "numericMemberID";
            this.numericMemberID.Size = new System.Drawing.Size(118, 30);
            this.numericMemberID.TabIndex = 83;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(187, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 23);
            this.label2.TabIndex = 82;
            this.label2.Text = "Member ID:";
            // 
            // numericBookID
            // 
            this.numericBookID.Font = new System.Drawing.Font("Tahoma", 14F);
            this.numericBookID.Location = new System.Drawing.Point(305, 253);
            this.numericBookID.Name = "numericBookID";
            this.numericBookID.Size = new System.Drawing.Size(118, 30);
            this.numericBookID.TabIndex = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(216, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 23);
            this.label1.TabIndex = 79;
            this.label1.Text = "Book ID:";
            // 
            // btnShowMemberInfo
            // 
            this.btnShowMemberInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnShowMemberInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(37)))));
            this.btnShowMemberInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowMemberInfo.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnShowMemberInfo.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnShowMemberInfo.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.btnShowMemberInfo.IconColor = System.Drawing.Color.Gainsboro;
            this.btnShowMemberInfo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnShowMemberInfo.IconSize = 23;
            this.btnShowMemberInfo.Location = new System.Drawing.Point(440, 120);
            this.btnShowMemberInfo.Name = "btnShowMemberInfo";
            this.btnShowMemberInfo.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.btnShowMemberInfo.Size = new System.Drawing.Size(114, 35);
            this.btnShowMemberInfo.TabIndex = 84;
            this.btnShowMemberInfo.Text = "Show Info";
            this.btnShowMemberInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnShowMemberInfo.UseVisualStyleBackColor = false;
            this.btnShowMemberInfo.Click += new System.EventHandler(this.btnShowMemberInfo_Click);
            // 
            // btnShowBookInfo
            // 
            this.btnShowBookInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnShowBookInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(37)))));
            this.btnShowBookInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowBookInfo.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnShowBookInfo.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnShowBookInfo.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.btnShowBookInfo.IconColor = System.Drawing.Color.Gainsboro;
            this.btnShowBookInfo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnShowBookInfo.IconSize = 23;
            this.btnShowBookInfo.Location = new System.Drawing.Point(440, 251);
            this.btnShowBookInfo.Name = "btnShowBookInfo";
            this.btnShowBookInfo.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.btnShowBookInfo.Size = new System.Drawing.Size(114, 35);
            this.btnShowBookInfo.TabIndex = 81;
            this.btnShowBookInfo.Text = "Show Info";
            this.btnShowBookInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnShowBookInfo.UseVisualStyleBackColor = false;
            this.btnShowBookInfo.Click += new System.EventHandler(this.btnShowBookCopyInfo_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btnExit.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExit.IconSize = 24;
            this.btnExit.Location = new System.Drawing.Point(768, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(32, 27);
            this.btnExit.TabIndex = 5;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btnCancel.IconColor = System.Drawing.Color.White;
            this.btnCancel.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnCancel.IconSize = 20;
            this.btnCancel.Location = new System.Drawing.Point(142, 494);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnCancel.Size = new System.Drawing.Size(128, 35);
            this.btnCancel.TabIndex = 88;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnSave.IconColor = System.Drawing.Color.White;
            this.btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSave.IconSize = 20;
            this.btnSave.Location = new System.Drawing.Point(7, 494);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSave.Size = new System.Drawing.Size(128, 35);
            this.btnSave.TabIndex = 87;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Tahoma", 25F);
            this.lblMode.ForeColor = System.Drawing.Color.Black;
            this.lblMode.Location = new System.Drawing.Point(217, 30);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(99, 41);
            this.lblMode.TabIndex = 89;
            this.lblMode.Text = "Mode";
            // 
            // dgvShowMemberInfo
            // 
            this.dgvShowMemberInfo.AllowUserToAddRows = false;
            this.dgvShowMemberInfo.AllowUserToDeleteRows = false;
            this.dgvShowMemberInfo.AllowUserToOrderColumns = true;
            this.dgvShowMemberInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvShowMemberInfo.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvShowMemberInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvShowMemberInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvShowMemberInfo.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvShowMemberInfo.GridColor = System.Drawing.Color.DarkGray;
            this.dgvShowMemberInfo.Location = new System.Drawing.Point(0, 161);
            this.dgvShowMemberInfo.Name = "dgvShowMemberInfo";
            this.dgvShowMemberInfo.ReadOnly = true;
            this.dgvShowMemberInfo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvShowMemberInfo.Size = new System.Drawing.Size(800, 66);
            this.dgvShowMemberInfo.TabIndex = 90;
            // 
            // dgvShowBookInfo
            // 
            this.dgvShowBookInfo.AllowUserToAddRows = false;
            this.dgvShowBookInfo.AllowUserToDeleteRows = false;
            this.dgvShowBookInfo.AllowUserToOrderColumns = true;
            this.dgvShowBookInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvShowBookInfo.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvShowBookInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvShowBookInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvShowBookInfo.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvShowBookInfo.GridColor = System.Drawing.Color.DarkGray;
            this.dgvShowBookInfo.Location = new System.Drawing.Point(0, 289);
            this.dgvShowBookInfo.Name = "dgvShowBookInfo";
            this.dgvShowBookInfo.ReadOnly = true;
            this.dgvShowBookInfo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvShowBookInfo.Size = new System.Drawing.Size(800, 66);
            this.dgvShowBookInfo.TabIndex = 91;
            // 
            // frmAddEditReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(800, 535);
            this.Controls.Add(this.dgvShowBookInfo);
            this.Controls.Add(this.dgvShowMemberInfo);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpReservationDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnShowMemberInfo);
            this.Controls.Add(this.numericMemberID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnShowBookInfo);
            this.Controls.Add(this.numericBookID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddEditReservation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAddEditReservation";
            this.Load += new System.EventHandler(this.frmAddEditReservation_Load);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericMemberID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBookID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowMemberInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowBookInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private FontAwesome.Sharp.IconButton btnExit;
        private System.Windows.Forms.DateTimePicker dtpReservationDate;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton btnShowMemberInfo;
        private System.Windows.Forms.NumericUpDown numericMemberID;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnShowBookInfo;
        private System.Windows.Forms.NumericUpDown numericBookID;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnCancel;
        private FontAwesome.Sharp.IconButton btnSave;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.DataGridView dgvShowMemberInfo;
        private System.Windows.Forms.DataGridView dgvShowBookInfo;
    }
}