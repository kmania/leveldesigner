namespace LevelDesigner
{
    partial class LevelDesigner
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
            this.tbxColumns = new System.Windows.Forms.TextBox();
            this.tbxRows = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDraw = new System.Windows.Forms.Button();
            this.picture = new System.Windows.Forms.PictureBox();
            this.picturePanel = new System.Windows.Forms.GroupBox();
            this.tbxPositions = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.picturePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxColumns
            // 
            this.tbxColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxColumns.Location = new System.Drawing.Point(504, 12);
            this.tbxColumns.Name = "tbxColumns";
            this.tbxColumns.Size = new System.Drawing.Size(100, 20);
            this.tbxColumns.TabIndex = 1;
            // 
            // tbxRows
            // 
            this.tbxRows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxRows.Location = new System.Drawing.Point(504, 38);
            this.tbxRows.Name = "tbxRows";
            this.tbxRows.Size = new System.Drawing.Size(100, 20);
            this.tbxRows.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(451, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Columns";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(464, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Rows";
            // 
            // btnDraw
            // 
            this.btnDraw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDraw.Location = new System.Drawing.Point(528, 65);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 23);
            this.btnDraw.TabIndex = 5;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // picture
            // 
            this.picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picture.Location = new System.Drawing.Point(3, 16);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(427, 188);
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picture.TabIndex = 0;
            this.picture.TabStop = false;
            this.picture.Paint += new System.Windows.Forms.PaintEventHandler(this.picture_Paint);
            this.picture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picture_MouseMove);
            // 
            // picturePanel
            // 
            this.picturePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picturePanel.Controls.Add(this.picture);
            this.picturePanel.Location = new System.Drawing.Point(12, 12);
            this.picturePanel.Name = "picturePanel";
            this.picturePanel.Size = new System.Drawing.Size(433, 207);
            this.picturePanel.TabIndex = 6;
            this.picturePanel.TabStop = false;
            this.picturePanel.Text = "Map";
            // 
            // tbxPositions
            // 
            this.tbxPositions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxPositions.Location = new System.Drawing.Point(423, 94);
            this.tbxPositions.Name = "tbxPositions";
            this.tbxPositions.Size = new System.Drawing.Size(181, 20);
            this.tbxPositions.TabIndex = 7;
            // 
            // LevelDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 231);
            this.Controls.Add(this.tbxPositions);
            this.Controls.Add(this.picturePanel);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxRows);
            this.Controls.Add(this.tbxColumns);
            this.Name = "LevelDesigner";
            this.Text = "Level Designer";
            this.Load += new System.EventHandler(this.LevelDesigner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.picturePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxColumns;
        private System.Windows.Forms.TextBox tbxRows;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.GroupBox picturePanel;
        public System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.TextBox tbxPositions;
    }
}

