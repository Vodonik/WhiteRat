namespace WhiteRat
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
			this.btnPrepare = new System.Windows.Forms.Button();
			this.btnLearn = new System.Windows.Forms.Button();
			this.btnTest = new System.Windows.Forms.Button();
			this.txtDebug = new System.Windows.Forms.TextBox();
			this.pbxDraw = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pbxDraw)).BeginInit();
			this.SuspendLayout();
			// 
			// btnPrepare
			// 
			this.btnPrepare.Location = new System.Drawing.Point(29, 159);
			this.btnPrepare.Name = "btnPrepare";
			this.btnPrepare.Size = new System.Drawing.Size(75, 23);
			this.btnPrepare.TabIndex = 0;
			this.btnPrepare.Text = "&Prepare";
			this.btnPrepare.UseVisualStyleBackColor = true;
			this.btnPrepare.Click += new System.EventHandler(this.btnPrepare_Click);
			// 
			// btnLearn
			// 
			this.btnLearn.Location = new System.Drawing.Point(110, 159);
			this.btnLearn.Name = "btnLearn";
			this.btnLearn.Size = new System.Drawing.Size(75, 23);
			this.btnLearn.TabIndex = 1;
			this.btnLearn.Text = "&Learn";
			this.btnLearn.UseVisualStyleBackColor = true;
			this.btnLearn.Click += new System.EventHandler(this.btnLearn_Click);
			// 
			// btnTest
			// 
			this.btnTest.Location = new System.Drawing.Point(191, 159);
			this.btnTest.Name = "btnTest";
			this.btnTest.Size = new System.Drawing.Size(75, 23);
			this.btnTest.TabIndex = 2;
			this.btnTest.Text = "&Test";
			this.btnTest.UseVisualStyleBackColor = true;
			this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
			// 
			// txtDebug
			// 
			this.txtDebug.Location = new System.Drawing.Point(150, 13);
			this.txtDebug.Multiline = true;
			this.txtDebug.Name = "txtDebug";
			this.txtDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDebug.Size = new System.Drawing.Size(138, 128);
			this.txtDebug.TabIndex = 3;
			// 
			// pbxDraw
			// 
			this.pbxDraw.Location = new System.Drawing.Point(68, 66);
			this.pbxDraw.Name = "pbxDraw";
			this.pbxDraw.Size = new System.Drawing.Size(16, 16);
			this.pbxDraw.TabIndex = 4;
			this.pbxDraw.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(300, 193);
			this.Controls.Add(this.pbxDraw);
			this.Controls.Add(this.txtDebug);
			this.Controls.Add(this.btnTest);
			this.Controls.Add(this.btnLearn);
			this.Controls.Add(this.btnPrepare);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.pbxDraw)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnPrepare;
		private System.Windows.Forms.Button btnLearn;
		private System.Windows.Forms.Button btnTest;
		private System.Windows.Forms.TextBox txtDebug;
		private System.Windows.Forms.PictureBox pbxDraw;
	}
}