namespace LibrarySystem_WindowsForms_.CirculationForms
{
    partial class frmAddEditIssue
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.numericMemberID = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericBookID = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnExit = new FontAwesome.Sharp.IconButton();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpIssueDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.btnCancel = new FontAwesome.Sharp.IconButton();
            this.btnIssueBook = new FontAwesome.Sharp.IconButton();
            this.btnYesNoAvailable = new FontAwesome.Sharp.IconButton();
            this.btnShowMemberInfo = new FontAwesome.Sharp.IconButton();
            this.btnShowBookInfo = new FontAwesome.Sharp.IconButton();
            this.dgvShowBookInfo = new System.Windows.Forms.DataGridView();
            this.dgvShowMemberInfo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.numericMemberID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBookID)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowBookInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowMemberInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // numericMemberID
            // 
            this.numericMemberID.Font = new System.Drawing.Font("Tahoma", 14F);
            this.numericMemberID.Location = new System.Drawing.Point(217, 242);
            this.numericMemberID.Name = "numericMemberID";
            this.numericMemberID.Size = new System.Drawing.Size(118, 30);
            this.numericMemberID.TabIndex = 53;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(99, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 23);
            this.label2.TabIndex = 52;
            this.label2.Text = "Member ID:";
            // 
            // numericBookID
            // 
            this.numericBookID.Font = new System.Drawing.Font("Tahoma", 14F);
            this.numericBookID.Location = new System.Drawing.Point(217, 130);
            this.numericBookID.Name = "numericBookID";
            this.numericBookID.Size = new System.Drawing.Size(118, 30);
            this.numericBookID.TabIndex = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(128, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 23);
            this.label1.TabIndex = 49;
            this.label1.Text = "Book ID:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel4.Controls.Add(this.btnExit);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(833, 27);
            this.panel4.TabIndex = 77;
            this.panel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel4_MouseDown);
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
            this.btnExit.Location = new System.Drawing.Point(801, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(32, 27);
            this.btnExit.TabIndex = 5;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(506, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 23);
            this.label3.TabIndex = 78;
            this.label3.Text = "Is Book Available:";
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.CalendarFont = new System.Drawing.Font("Tahoma", 12F);
            this.dtpDueDate.Font = new System.Drawing.Font("Tahoma", 13F);
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDueDate.Location = new System.Drawing.Point(217, 421);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(132, 28);
            this.dtpDueDate.TabIndex = 84;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(115, 422);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 23);
            this.label5.TabIndex = 83;
            this.label5.Text = "Due Date:";
            // 
            // dtpIssueDate
            // 
            this.dtpIssueDate.CalendarFont = new System.Drawing.Font("Tahoma", 12F);
            this.dtpIssueDate.Font = new System.Drawing.Font("Tahoma", 13F);
            this.dtpIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpIssueDate.Location = new System.Drawing.Point(217, 376);
            this.dtpIssueDate.Name = "dtpIssueDate";
            this.dtpIssueDate.Size = new System.Drawing.Size(132, 28);
            this.dtpIssueDate.TabIndex = 82;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(105, 377);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 23);
            this.label4.TabIndex = 81;
            this.label4.Text = "Issue Date:";
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Tahoma", 25F);
            this.lblMode.ForeColor = System.Drawing.Color.Black;
            this.lblMode.Location = new System.Drawing.Point(265, 30);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(99, 41);
            this.lblMode.TabIndex = 87;
            this.lblMode.Text = "Mode";
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
            this.btnCancel.Location = new System.Drawing.Point(143, 521);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnCancel.Size = new System.Drawing.Size(128, 35);
            this.btnCancel.TabIndex = 86;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnIssueBook
            // 
            this.btnIssueBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIssueBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnIssueBook.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGreen;
            this.btnIssueBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssueBook.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnIssueBook.ForeColor = System.Drawing.Color.White;
            this.btnIssueBook.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnIssueBook.IconColor = System.Drawing.Color.White;
            this.btnIssueBook.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnIssueBook.IconSize = 20;
            this.btnIssueBook.Location = new System.Drawing.Point(8, 521);
            this.btnIssueBook.Name = "btnIssueBook";
            this.btnIssueBook.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnIssueBook.Size = new System.Drawing.Size(128, 35);
            this.btnIssueBook.TabIndex = 85;
            this.btnIssueBook.Text = "Save";
            this.btnIssueBook.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIssueBook.UseVisualStyleBackColor = false;
            this.btnIssueBook.Click += new System.EventHandler(this.btnIssueBook_Click);
            // 
            // btnYesNoAvailable
            // 
            this.btnYesNoAvailable.BackColor = System.Drawing.Color.Transparent;
            this.btnYesNoAvailable.FlatAppearance.BorderSize = 0;
            this.btnYesNoAvailable.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnYesNoAvailable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYesNoAvailable.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnYesNoAvailable.ForeColor = System.Drawing.Color.Transparent;
            this.btnYesNoAvailable.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btnYesNoAvailable.IconColor = System.Drawing.Color.Red;
            this.btnYesNoAvailable.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnYesNoAvailable.IconSize = 40;
            this.btnYesNoAvailable.Location = new System.Drawing.Point(659, 120);
            this.btnYesNoAvailable.Name = "btnYesNoAvailable";
            this.btnYesNoAvailable.Size = new System.Drawing.Size(37, 46);
            this.btnYesNoAvailable.TabIndex = 80;
            this.btnYesNoAvailable.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnYesNoAvailable.UseVisualStyleBackColor = false;
            // 
            // btnShowMemberInfo
            // 
            this.btnShowMemberInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnShowMemberInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(149)))), ((int)(((byte)(243)))));
            this.btnShowMemberInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowMemberInfo.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnShowMemberInfo.ForeColor = System.Drawing.Color.White;
            this.btnShowMemberInfo.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.btnShowMemberInfo.IconColor = System.Drawing.Color.Gainsboro;
            this.btnShowMemberInfo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnShowMemberInfo.IconSize = 23;
            this.btnShowMemberInfo.Location = new System.Drawing.Point(355, 237);
            this.btnShowMemberInfo.Name = "btnShowMemberInfo";
            this.btnShowMemberInfo.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.btnShowMemberInfo.Size = new System.Drawing.Size(114, 35);
            this.btnShowMemberInfo.TabIndex = 54;
            this.btnShowMemberInfo.Text = "Show Info";
            this.btnShowMemberInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnShowMemberInfo.UseVisualStyleBackColor = false;
            this.btnShowMemberInfo.Click += new System.EventHandler(this.btnShowMemberInfo_Click);
            // 
            // btnShowBookInfo
            // 
            this.btnShowBookInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnShowBookInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(149)))), ((int)(((byte)(243)))));
            this.btnShowBookInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowBookInfo.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnShowBookInfo.ForeColor = System.Drawing.Color.White;
            this.btnShowBookInfo.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.btnShowBookInfo.IconColor = System.Drawing.Color.Gainsboro;
            this.btnShowBookInfo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnShowBookInfo.IconSize = 23;
            this.btnShowBookInfo.Location = new System.Drawing.Point(355, 125);
            this.btnShowBookInfo.Name = "btnShowBookInfo";
            this.btnShowBookInfo.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.btnShowBookInfo.Size = new System.Drawing.Size(114, 35);
            this.btnShowBookInfo.TabIndex = 51;
            this.btnShowBookInfo.Text = "Show Info";
            this.btnShowBookInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnShowBookInfo.UseVisualStyleBackColor = false;
            this.btnShowBookInfo.Click += new System.EventHandler(this.btnShowBookInfo_Click);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvShowBookInfo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvShowBookInfo.GridColor = System.Drawing.Color.DarkGray;
            this.dgvShowBookInfo.Location = new System.Drawing.Point(0, 166);
            this.dgvShowBookInfo.Name = "dgvShowBookInfo";
            this.dgvShowBookInfo.ReadOnly = true;
            this.dgvShowBookInfo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvShowBookInfo.Size = new System.Drawing.Size(833, 66);
            this.dgvShowBookInfo.TabIndex = 88;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvShowMemberInfo.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvShowMemberInfo.GridColor = System.Drawing.Color.DarkGray;
            this.dgvShowMemberInfo.Location = new System.Drawing.Point(0, 278);
            this.dgvShowMemberInfo.Name = "dgvShowMemberInfo";
            this.dgvShowMemberInfo.ReadOnly = true;
            this.dgvShowMemberInfo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvShowMemberInfo.Size = new System.Drawing.Size(833, 66);
            this.dgvShowMemberInfo.TabIndex = 89;
            // 
            // frmAddEditIssue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(833, 565);
            this.Controls.Add(this.dgvShowMemberInfo);
            this.Controls.Add(this.dgvShowBookInfo);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnIssueBook);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpIssueDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnYesNoAvailable);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnShowMemberInfo);
            this.Controls.Add(this.numericMemberID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnShowBookInfo);
            this.Controls.Add(this.numericBookID);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddEditIssue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAddEditIssue";
            this.Load += new System.EventHandler(this.frmAddEditIssue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericMemberID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBookID)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowBookInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowMemberInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnShowMemberInfo;
        private System.Windows.Forms.NumericUpDown numericMemberID;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnShowBookInfo;
        private System.Windows.Forms.NumericUpDown numericBookID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private FontAwesome.Sharp.IconButton btnExit;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton btnYesNoAvailable;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpIssueDate;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton btnIssueBook;
        private FontAwesome.Sharp.IconButton btnCancel;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.DataGridView dgvShowBookInfo;
        private System.Windows.Forms.DataGridView dgvShowMemberInfo;
    }
}