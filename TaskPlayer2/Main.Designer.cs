namespace TaskPlayer2
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAddTask = new System.Windows.Forms.Label();
            this.txbAddTask = new System.Windows.Forms.TextBox();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.imlMyImages = new System.Windows.Forms.ImageList(this.components);
            this.tCounterPulse = new System.Windows.Forms.Timer(this.components);
            this.olvTaskGrid = new BrightIdeasSoftware.ObjectListView();
            this.olvName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvTimeSpent = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPlayStop = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvTaskGrid)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnMinimize);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 82);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnClose.Location = new System.Drawing.Point(742, 25);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(38, 34);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnMinimize.Location = new System.Drawing.Point(697, 25);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(38, 34);
            this.btnMinimize.TabIndex = 4;
            this.btnMinimize.Text = "_";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click_1);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitle.Font = new System.Drawing.Font("Palatino Linotype", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblTitle.Location = new System.Drawing.Point(287, 21);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(182, 37);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Task Player 2";
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // lblAddTask
            // 
            this.lblAddTask.AutoSize = true;
            this.lblAddTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddTask.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblAddTask.Location = new System.Drawing.Point(21, 109);
            this.lblAddTask.Name = "lblAddTask";
            this.lblAddTask.Size = new System.Drawing.Size(90, 24);
            this.lblAddTask.TabIndex = 8;
            this.lblAddTask.Text = "Add Task";
            // 
            // txbAddTask
            // 
            this.txbAddTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbAddTask.Location = new System.Drawing.Point(117, 109);
            this.txbAddTask.Name = "txbAddTask";
            this.txbAddTask.Size = new System.Drawing.Size(537, 29);
            this.txbAddTask.TabIndex = 9;
            this.txbAddTask.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbAddTask_KeyPress);
            // 
            // btnAddTask
            // 
            this.btnAddTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(122)))), ((int)(((byte)(137)))));
            this.btnAddTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTask.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnAddTask.Location = new System.Drawing.Point(660, 106);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(111, 37);
            this.btnAddTask.TabIndex = 10;
            this.btnAddTask.Text = "Add";
            this.btnAddTask.UseVisualStyleBackColor = false;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // imlMyImages
            // 
            this.imlMyImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlMyImages.ImageStream")));
            this.imlMyImages.TransparentColor = System.Drawing.Color.Transparent;
            this.imlMyImages.Images.SetKeyName(0, "added");
            this.imlMyImages.Images.SetKeyName(1, "stopped");
            this.imlMyImages.Images.SetKeyName(2, "play");
            // 
            // tCounterPulse
            // 
            this.tCounterPulse.Interval = 1000;
            this.tCounterPulse.Tick += new System.EventHandler(this.tCounterPulse_Tick);
            // 
            // olvTaskGrid
            // 
            this.olvTaskGrid.AllColumns.Add(this.olvName);
            this.olvTaskGrid.AllColumns.Add(this.olvTimeSpent);
            this.olvTaskGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.olvTaskGrid.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvName,
            this.olvTimeSpent});
            this.olvTaskGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvTaskGrid.FullRowSelect = true;
            this.olvTaskGrid.Location = new System.Drawing.Point(25, 155);
            this.olvTaskGrid.Name = "olvTaskGrid";
            this.olvTaskGrid.ShowGroups = false;
            this.olvTaskGrid.Size = new System.Drawing.Size(746, 236);
            this.olvTaskGrid.SmallImageList = this.imlMyImages;
            this.olvTaskGrid.TabIndex = 7;
            this.olvTaskGrid.UseCompatibleStateImageBehavior = false;
            this.olvTaskGrid.View = System.Windows.Forms.View.Details;
            this.olvTaskGrid.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.olvTaskGrid_CellClick);
            this.olvTaskGrid.MouseLeave += new System.EventHandler(this.ToggleButtonImage);
            // 
            // olvName
            // 
            this.olvName.AspectName = "Name";
            this.olvName.CellPadding = null;
            this.olvName.ImageAspectName = "Status";
            this.olvName.Text = "Name";
            this.olvName.Width = 554;
            // 
            // olvTimeSpent
            // 
            this.olvTimeSpent.AspectName = "TotalFormattedTimeSpent";
            this.olvTimeSpent.CellPadding = null;
            this.olvTimeSpent.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvTimeSpent.Text = "Time Spent ";
            this.olvTimeSpent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvTimeSpent.Width = 168;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.White;
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Image = global::TaskPlayer2.Properties.Resources.export;
            this.btnExport.Location = new System.Drawing.Point(660, 35);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(99, 78);
            this.btnExport.TabIndex = 12;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPlayStop
            // 
            this.btnPlayStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlayStop.FlatAppearance.BorderSize = 0;
            this.btnPlayStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayStop.Image = global::TaskPlayer2.Properties.Resources.start;
            this.btnPlayStop.Location = new System.Drawing.Point(25, 9);
            this.btnPlayStop.Name = "btnPlayStop";
            this.btnPlayStop.Size = new System.Drawing.Size(140, 135);
            this.btnPlayStop.TabIndex = 11;
            this.btnPlayStop.UseVisualStyleBackColor = true;
            this.btnPlayStop.Click += new System.EventHandler(this.btnPlayStop_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel2.Controls.Add(this.lblVersion);
            this.panel2.Controls.Add(this.btnPlayStop);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Location = new System.Drawing.Point(0, 397);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 150);
            this.panel2.TabIndex = 13;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblVersion.Location = new System.Drawing.Point(667, 127);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(91, 17);
            this.lblVersion.TabIndex = 13;
            this.lblVersion.Text = "v2.2016.02.0";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(791, 546);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.txbAddTask);
            this.Controls.Add(this.lblAddTask);
            this.Controls.Add(this.olvTaskGrid);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.GrayText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Task Player 2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvTaskGrid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Label lblTitle;
        private BrightIdeasSoftware.ObjectListView olvTaskGrid;
        private BrightIdeasSoftware.OLVColumn olvName;
        private BrightIdeasSoftware.OLVColumn olvTimeSpent;
        private System.Windows.Forms.Label lblAddTask;
        private System.Windows.Forms.TextBox txbAddTask;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Button btnPlayStop;
        private System.Windows.Forms.ImageList imlMyImages;
        private System.Windows.Forms.Timer tCounterPulse;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblVersion;

    }
}

