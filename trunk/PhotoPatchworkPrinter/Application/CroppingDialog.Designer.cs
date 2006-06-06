/*
 * Created by SharpDevelop.
 * User: ${USER}
 * Date: ${DATE}
 * Time: ${TIME}
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace PhotoPatchworkPrinter
{
	partial class CroppingDialog : System.Windows.Forms.Form
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.PicturePanel = new System.Windows.Forms.Panel();
			this.SelectionPanel = new System.Windows.Forms.Panel();
			this.BtnAnnuler = new System.Windows.Forms.Button();
			this.BtnOk = new System.Windows.Forms.Button();
			this.CboRotation = new System.Windows.Forms.ComboBox();
			this.LblRotation = new System.Windows.Forms.Label();
			this.LblFlip = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.trackBar2 = new System.Windows.Forms.TrackBar();
			this.label1 = new System.Windows.Forms.Label();
			this.trackBar3 = new System.Windows.Forms.TrackBar();
			this.label3 = new System.Windows.Forms.Label();
			this.PicturePanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
			this.SuspendLayout();
			// 
			// PicturePanel
			// 
			this.PicturePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.PicturePanel.BackColor = System.Drawing.Color.White;
			this.PicturePanel.Controls.Add(this.SelectionPanel);
			this.PicturePanel.Location = new System.Drawing.Point(12, 12);
			this.PicturePanel.Name = "PicturePanel";
			this.PicturePanel.Size = new System.Drawing.Size(714, 491);
			this.PicturePanel.TabIndex = 0;
			// 
			// SelectionPanel
			// 
			this.SelectionPanel.BackColor = System.Drawing.Color.Transparent;
			this.SelectionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.SelectionPanel.ForeColor = System.Drawing.Color.Gray;
			this.SelectionPanel.Location = new System.Drawing.Point(12, 12);
			this.SelectionPanel.Name = "SelectionPanel";
			this.SelectionPanel.Size = new System.Drawing.Size(248, 187);
			this.SelectionPanel.TabIndex = 0;
			// 
			// BtnAnnuler
			// 
			this.BtnAnnuler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnAnnuler.Location = new System.Drawing.Point(651, 596);
			this.BtnAnnuler.Name = "BtnAnnuler";
			this.BtnAnnuler.Size = new System.Drawing.Size(75, 25);
			this.BtnAnnuler.TabIndex = 1;
			this.BtnAnnuler.Text = "&Annuler";
			this.BtnAnnuler.UseVisualStyleBackColor = true;
			this.BtnAnnuler.Click += new System.EventHandler(this.BtnAnnulerClick);
			// 
			// BtnOk
			// 
			this.BtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnOk.Location = new System.Drawing.Point(570, 596);
			this.BtnOk.Name = "BtnOk";
			this.BtnOk.Size = new System.Drawing.Size(75, 25);
			this.BtnOk.TabIndex = 2;
			this.BtnOk.Text = "&Ok";
			this.BtnOk.UseVisualStyleBackColor = true;
			this.BtnOk.Click += new System.EventHandler(this.BtnOkClick);
			// 
			// CboRotation
			// 
			this.CboRotation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.CboRotation.FormattingEnabled = true;
			this.CboRotation.Items.AddRange(new object[] {
									"0°",
									"90°",
									"180°",
									"270°"});
			this.CboRotation.Location = new System.Drawing.Point(80, 599);
			this.CboRotation.Name = "CboRotation";
			this.CboRotation.Size = new System.Drawing.Size(48, 21);
			this.CboRotation.TabIndex = 3;
			// 
			// LblRotation
			// 
			this.LblRotation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.LblRotation.AutoSize = true;
			this.LblRotation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblRotation.Location = new System.Drawing.Point(12, 602);
			this.LblRotation.Name = "LblRotation";
			this.LblRotation.Size = new System.Drawing.Size(62, 13);
			this.LblRotation.TabIndex = 4;
			this.LblRotation.Text = "Rotation :";
			this.LblRotation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LblFlip
			// 
			this.LblFlip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.LblFlip.AutoSize = true;
			this.LblFlip.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblFlip.Location = new System.Drawing.Point(134, 602);
			this.LblFlip.Name = "LblFlip";
			this.LblFlip.Size = new System.Drawing.Size(32, 13);
			this.LblFlip.TabIndex = 6;
			this.LblFlip.Text = "Flip :";
			this.LblFlip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBox1
			// 
			this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
									"None",
									"Horizontal",
									"Vertical",
									"Both"});
			this.comboBox1.Location = new System.Drawing.Point(172, 599);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(73, 21);
			this.comboBox1.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 569);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(45, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Zoom :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// trackBar1
			// 
			this.trackBar1.AutoSize = false;
			this.trackBar1.LargeChange = 50;
			this.trackBar1.Location = new System.Drawing.Point(80, 569);
			this.trackBar1.Maximum = 1000;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(646, 24);
			this.trackBar1.TabIndex = 11;
			this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
			// 
			// trackBar2
			// 
			this.trackBar2.AutoSize = false;
			this.trackBar2.LargeChange = 50;
			this.trackBar2.Location = new System.Drawing.Point(80, 539);
			this.trackBar2.Maximum = 1000;
			this.trackBar2.Name = "trackBar2";
			this.trackBar2.Size = new System.Drawing.Size(646, 24);
			this.trackBar2.TabIndex = 13;
			this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.None;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 539);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 12;
			this.label1.Text = "Top :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// trackBar3
			// 
			this.trackBar3.AutoSize = false;
			this.trackBar3.LargeChange = 50;
			this.trackBar3.Location = new System.Drawing.Point(80, 509);
			this.trackBar3.Maximum = 1000;
			this.trackBar3.Name = "trackBar3";
			this.trackBar3.Size = new System.Drawing.Size(646, 24);
			this.trackBar3.TabIndex = 15;
			this.trackBar3.TickStyle = System.Windows.Forms.TickStyle.None;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(12, 509);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 13);
			this.label3.TabIndex = 14;
			this.label3.Text = "Left :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CroppingDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(738, 633);
			this.Controls.Add(this.trackBar3);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.trackBar2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.trackBar1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.LblFlip);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.LblRotation);
			this.Controls.Add(this.CboRotation);
			this.Controls.Add(this.BtnOk);
			this.Controls.Add(this.BtnAnnuler);
			this.Controls.Add(this.PicturePanel);
			this.Name = "CroppingDialog";
			this.Text = "CroppingWindow";
			this.Load += new System.EventHandler(this.CroppingWindowLoad);
			this.PicturePanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Panel SelectionPanel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TrackBar trackBar3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TrackBar trackBar2;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label LblFlip;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.ComboBox CboRotation;
		private System.Windows.Forms.Label LblRotation;
		private System.Windows.Forms.Button BtnOk;
		private System.Windows.Forms.Button BtnAnnuler;
		private System.Windows.Forms.Panel PicturePanel;
		
	}
}
