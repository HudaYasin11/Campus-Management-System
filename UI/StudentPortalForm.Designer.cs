namespace BA_WinForms.UI
{
    partial class StudentPortalForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentPortalForm));
            this.btnMap = new System.Windows.Forms.Button();
            this.btnRoute = new System.Windows.Forms.Button();
            this.btnTimeTable = new System.Windows.Forms.Button();
            this.btnTips = new System.Windows.Forms.Button();
            this.btnFaqs = new System.Windows.Forms.Button();
            this.btnCourses = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnMap
            // 
            this.btnMap.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnMap.Font = new System.Drawing.Font("Segoe Script", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMap.ForeColor = System.Drawing.Color.White;
            this.btnMap.Location = new System.Drawing.Point(503, 123);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(300, 50);
            this.btnMap.TabIndex = 0;
            this.btnMap.Text = "🗺️ VIEW CAMPUS MAP";
            this.btnMap.UseVisualStyleBackColor = false;
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click);
            // 
            // btnRoute
            // 
            this.btnRoute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnRoute.Font = new System.Drawing.Font("Segoe Script", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoute.ForeColor = System.Drawing.Color.White;
            this.btnRoute.Location = new System.Drawing.Point(503, 191);
            this.btnRoute.Name = "btnRoute";
            this.btnRoute.Size = new System.Drawing.Size(300, 50);
            this.btnRoute.TabIndex = 1;
            this.btnRoute.Text = "📍 FIND BEST ROUTE\t";
            this.btnRoute.UseVisualStyleBackColor = false;
            this.btnRoute.Click += new System.EventHandler(this.btnRoute_Click);
            // 
            // btnTimeTable
            // 
            this.btnTimeTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnTimeTable.Font = new System.Drawing.Font("Segoe Script", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimeTable.ForeColor = System.Drawing.Color.White;
            this.btnTimeTable.Location = new System.Drawing.Point(503, 247);
            this.btnTimeTable.Name = "btnTimeTable";
            this.btnTimeTable.Size = new System.Drawing.Size(300, 50);
            this.btnTimeTable.TabIndex = 2;
            this.btnTimeTable.Text = "\t📅 VIEW TIMETABLE";
            this.btnTimeTable.UseVisualStyleBackColor = false;
            this.btnTimeTable.Click += new System.EventHandler(this.btnTimeTable_Click);
            // 
            // btnTips
            // 
            this.btnTips.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnTips.Font = new System.Drawing.Font("Segoe Script", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTips.ForeColor = System.Drawing.Color.White;
            this.btnTips.Location = new System.Drawing.Point(503, 319);
            this.btnTips.Name = "btnTips";
            this.btnTips.Size = new System.Drawing.Size(300, 50);
            this.btnTips.TabIndex = 3;
            this.btnTips.Text = "\t💡 FRESHER TIPS\t";
            this.btnTips.UseVisualStyleBackColor = false;
            this.btnTips.Click += new System.EventHandler(this.btnTips_Click);
            // 
            // btnFaqs
            // 
            this.btnFaqs.BackColor = System.Drawing.Color.DeepPink;
            this.btnFaqs.Font = new System.Drawing.Font("Segoe Script", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFaqs.ForeColor = System.Drawing.Color.White;
            this.btnFaqs.Location = new System.Drawing.Point(503, 384);
            this.btnFaqs.Name = "btnFaqs";
            this.btnFaqs.Size = new System.Drawing.Size(300, 50);
            this.btnFaqs.TabIndex = 4;
            this.btnFaqs.Text = "❓ FAQs\t";
            this.btnFaqs.UseVisualStyleBackColor = false;
            this.btnFaqs.Click += new System.EventHandler(this.btnFaqs_Click);
            // 
            // btnCourses
            // 
            this.btnCourses.BackColor = System.Drawing.Color.Red;
            this.btnCourses.Font = new System.Drawing.Font("Segoe Script", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCourses.ForeColor = System.Drawing.Color.White;
            this.btnCourses.Location = new System.Drawing.Point(503, 440);
            this.btnCourses.Name = "btnCourses";
            this.btnCourses.Size = new System.Drawing.Size(300, 50);
            this.btnCourses.TabIndex = 5;
            this.btnCourses.Text = "\t📚 VIEW ALL COURSES\t#";
            this.btnCourses.UseVisualStyleBackColor = false;
            this.btnCourses.Click += new System.EventHandler(this.btnCourses_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Silver;
            this.btnLogout.Font = new System.Drawing.Font("Segoe Script", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(503, 509);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(300, 50);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "\t🚪 LOGOUT";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblStatus.Location = new System.Drawing.Point(478, 53);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(325, 23);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Welcome Student! Select an option to continue.";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe Script", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Gold;
            this.lblTitle.Location = new System.Drawing.Point(507, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(296, 44);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "STUDENT PORTAL";
            // 
            // StudentPortalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1023, 550);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnCourses);
            this.Controls.Add(this.btnFaqs);
            this.Controls.Add(this.btnTips);
            this.Controls.Add(this.btnTimeTable);
            this.Controls.Add(this.btnRoute);
            this.Controls.Add(this.btnMap);
            this.DoubleBuffered = true;
            this.Name = "StudentPortalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Portal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMap;
        private System.Windows.Forms.Button btnRoute;
        private System.Windows.Forms.Button btnTimeTable;
        private System.Windows.Forms.Button btnTips;
        private System.Windows.Forms.Button btnFaqs;
        private System.Windows.Forms.Button btnCourses;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTitle;
    }
}