namespace autoKimaiHelper
{
    partial class ProjectTaskSelect
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
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.evtIDString = new System.Windows.Forms.TextBox();
            this.pctIDString = new System.Windows.Forms.TextBox();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.evtID = new System.Windows.Forms.TextBox();
            this.pctID = new System.Windows.Forms.TextBox();
            this.evtSearchText = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.pctSearchText = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.pctList = new System.Windows.Forms.ListBox();
            this.evtList = new System.Windows.Forms.ListBox();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.materialTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPage1);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Location = new System.Drawing.Point(12, 86);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(891, 285);
            this.materialTabControl1.TabIndex = 63;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.evtIDString);
            this.tabPage1.Controls.Add(this.pctIDString);
            this.tabPage1.Controls.Add(this.materialRaisedButton1);
            this.tabPage1.Controls.Add(this.evtID);
            this.tabPage1.Controls.Add(this.pctID);
            this.tabPage1.Controls.Add(this.evtSearchText);
            this.tabPage1.Controls.Add(this.pctSearchText);
            this.tabPage1.Controls.Add(this.pctList);
            this.tabPage1.Controls.Add(this.evtList);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(883, 259);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // evtIDString
            // 
            this.evtIDString.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.evtIDString.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.evtIDString.Location = new System.Drawing.Point(6, 128);
            this.evtIDString.Name = "evtIDString";
            this.evtIDString.Size = new System.Drawing.Size(74, 22);
            this.evtIDString.TabIndex = 71;
            this.evtIDString.Visible = false;
            // 
            // pctIDString
            // 
            this.pctIDString.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pctIDString.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.pctIDString.Location = new System.Drawing.Point(6, 156);
            this.pctIDString.Name = "pctIDString";
            this.pctIDString.Size = new System.Drawing.Size(74, 22);
            this.pctIDString.TabIndex = 70;
            this.pctIDString.Visible = false;
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(358, 143);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(75, 23);
            this.materialRaisedButton1.TabIndex = 69;
            this.materialRaisedButton1.Text = "確定";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // evtID
            // 
            this.evtID.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.evtID.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.evtID.Location = new System.Drawing.Point(6, 0);
            this.evtID.Name = "evtID";
            this.evtID.Size = new System.Drawing.Size(74, 22);
            this.evtID.TabIndex = 68;
            this.evtID.Visible = false;
            // 
            // pctID
            // 
            this.pctID.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pctID.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.pctID.Location = new System.Drawing.Point(6, 28);
            this.pctID.Name = "pctID";
            this.pctID.Size = new System.Drawing.Size(74, 22);
            this.pctID.TabIndex = 67;
            this.pctID.Visible = false;
            // 
            // evtSearchText
            // 
            this.evtSearchText.Depth = 0;
            this.evtSearchText.Hint = "";
            this.evtSearchText.Location = new System.Drawing.Point(427, 172);
            this.evtSearchText.MaxLength = 32767;
            this.evtSearchText.MouseState = MaterialSkin.MouseState.HOVER;
            this.evtSearchText.Name = "evtSearchText";
            this.evtSearchText.PasswordChar = '\0';
            this.evtSearchText.SelectedText = "";
            this.evtSearchText.SelectionLength = 0;
            this.evtSearchText.SelectionStart = 0;
            this.evtSearchText.Size = new System.Drawing.Size(319, 23);
            this.evtSearchText.TabIndex = 66;
            this.evtSearchText.TabStop = false;
            this.evtSearchText.UseSystemPasswordChar = false;
            this.evtSearchText.TextChanged += new System.EventHandler(this.evtSearchText_TextChanged);
            // 
            // pctSearchText
            // 
            this.pctSearchText.Depth = 0;
            this.pctSearchText.Hint = "";
            this.pctSearchText.Location = new System.Drawing.Point(71, 172);
            this.pctSearchText.MaxLength = 32767;
            this.pctSearchText.MouseState = MaterialSkin.MouseState.HOVER;
            this.pctSearchText.Name = "pctSearchText";
            this.pctSearchText.PasswordChar = '\0';
            this.pctSearchText.SelectedText = "";
            this.pctSearchText.SelectionLength = 0;
            this.pctSearchText.SelectionStart = 0;
            this.pctSearchText.Size = new System.Drawing.Size(297, 23);
            this.pctSearchText.TabIndex = 65;
            this.pctSearchText.TabStop = false;
            this.pctSearchText.UseSystemPasswordChar = false;
            this.pctSearchText.TextChanged += new System.EventHandler(this.pctSearchText_TextChanged);
            // 
            // pctList
            // 
            this.pctList.BackColor = System.Drawing.Color.White;
            this.pctList.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.pctList.ForeColor = System.Drawing.SystemColors.Desktop;
            this.pctList.FormattingEnabled = true;
            this.pctList.ItemHeight = 16;
            this.pctList.Location = new System.Drawing.Point(71, 22);
            this.pctList.Name = "pctList";
            this.pctList.Size = new System.Drawing.Size(297, 100);
            this.pctList.TabIndex = 63;
            this.pctList.SelectedIndexChanged += new System.EventHandler(this.pctList_SelectedIndexChanged);
            // 
            // evtList
            // 
            this.evtList.BackColor = System.Drawing.Color.White;
            this.evtList.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.evtList.ForeColor = System.Drawing.SystemColors.Desktop;
            this.evtList.FormattingEnabled = true;
            this.evtList.ItemHeight = 16;
            this.evtList.Location = new System.Drawing.Point(427, 22);
            this.evtList.Name = "evtList";
            this.evtList.Size = new System.Drawing.Size(319, 100);
            this.evtList.TabIndex = 64;
            this.evtList.SelectedIndexChanged += new System.EventHandler(this.evtList_SelectedIndexChanged);
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(0, 57);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(159, 23);
            this.materialTabSelector1.TabIndex = 64;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // ProjectTaskSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(911, 371);
            this.Controls.Add(this.materialTabSelector1);
            this.Controls.Add(this.materialTabControl1);
            this.Name = "ProjectTaskSelect";
            this.Text = "ProjectTaskSelect";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProjectTaskSelect_FormClosed);
            this.materialTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox evtID;
        private System.Windows.Forms.TextBox pctID;
        private MaterialSkin.Controls.MaterialSingleLineTextField evtSearchText;
        private MaterialSkin.Controls.MaterialSingleLineTextField pctSearchText;
        private System.Windows.Forms.ListBox pctList;
        private System.Windows.Forms.ListBox evtList;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private System.Windows.Forms.TextBox evtIDString;
        private System.Windows.Forms.TextBox pctIDString;

    }
}