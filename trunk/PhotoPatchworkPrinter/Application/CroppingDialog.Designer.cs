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
			this.CboFlip = new System.Windows.Forms.ComboBox();
			this.LblZoom = new System.Windows.Forms.Label();
			this.TrkBarZoom = new System.Windows.Forms.TrackBar();
			this.TrkBarTop = new System.Windows.Forms.TrackBar();
			this.LblTop = new System.Windows.Forms.Label();
			this.TrkBarLeft = new System.Windows.Forms.TrackBar();
			this.LblLeft = new System.Windows.Forms.Label();
			this.PicturePanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.TrkBarZoom)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TrkBarTop)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TrkBarLeft)).BeginInit();
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
			this.LblRotation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblRotation.Location = new System.Drawing.Point(12, 598);
			this.LblRotation.Name = "LblRotation";
			this.LblRotation.Size = new System.Drawing.Size(62, 21);
			this.LblRotation.TabIndex = 4;
			this.LblRotation.Text = "Rotation :";
			this.LblRotation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// LblFlip
			// 
			this.LblFlip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.LblFlip.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblFlip.Location = new System.Drawing.Point(134, 599);
			this.LblFlip.Name = "LblFlip";
			this.LblFlip.Size = new System.Drawing.Size(32, 21);
			this.LblFlip.TabIndex = 6;
			this.LblFlip.Text = "Flip :";
			this.LblFlip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CboFlip
			// 
			this.CboFlip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.CboFlip.FormattingEnabled = true;
			this.CboFlip.Items.AddRange(new object[] {
									"None",
									"Horizontal",
									"Vertical",
									"Both"});
			this.CboFlip.Location = new System.Drawing.Point(172, 599);
			this.CboFlip.Name = "CboFlip";
			this.CboFlip.Size = new System.Drawing.Size(73, 21);
			this.CboFlip.TabIndex = 5;
			// 
			// LblZoom
			// 
			this.LblZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.LblZoom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblZoom.Location = new System.Drawing.Point(12, 569);
			this.LblZoom.Name = "LblZoom";
			this.LblZoom.Size = new System.Drawing.Size(62, 24);
			this.LblZoom.TabIndex = 10;
			this.LblZoom.Text = "Zoom :";
			this.LblZoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TrkBarZoom
			// 
			this.TrkBarZoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.TrkBarZoom.AutoSize = false;
			this.TrkBarZoom.LargeChange = 50;
			this.TrkBarZoom.Location = new System.Drawing.Point(80, 569);
			this.TrkBarZoom.Maximum = 1000;
			this.TrkBarZoom.Name = "TrkBarZoom";
			this.TrkBarZoom.Size = new System.Drawing.Size(646, 24);
			this.TrkBarZoom.TabIndex = 11;
			this.TrkBarZoom.TickStyle = System.Windows.Forms.TickStyle.None;
			// 
			// TrkBarTop
			// 
			this.TrkBarTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.TrkBarTop.AutoSize = false;
			this.TrkBarTop.LargeChange = 50;
			this.TrkBarTop.Location = new System.Drawing.Point(80, 539);
			this.TrkBarTop.Maximum = 1000;
			this.TrkBarTop.Name = "TrkBarTop";
			this.TrkBarTop.Size = new System.Drawing.Size(646, 24);
			this.TrkBarTop.TabIndex = 13;
			this.TrkBarTop.TickStyle = System.Windows.Forms.TickStyle.None;
			// 
			// LblTop
			// 
			this.LblTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.LblTop.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblTop.Location = new System.Drawing.Point(12, 539);
			this.LblTop.Name = "LblTop";
			this.LblTop.Size = new System.Drawing.Size(62, 24);
			this.LblTop.TabIndex = 12;
			this.LblTop.Text = "Top :";
			this.LblTop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TrkBarLeft
			// 
			this.TrkBarLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.TrkBarLeft.AutoSize = false;
			this.TrkBarLeft.LargeChange = 50;
			this.TrkBarLeft.Location = new System.Drawing.Point(80, 509);
			this.TrkBarLeft.Maximum = 1000;
			this.TrkBarLeft.Name = "TrkBarLeft";
			this.TrkBarLeft.Size = new System.Drawing.Size(646, 24);
			this.TrkBarLeft.TabIndex = 15;
			this.TrkBarLeft.TickStyle = System.Windows.Forms.TickStyle.None;
			// 
			// LblLeft
			// 
			this.LblLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.LblLeft.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblLeft.Location = new System.Drawing.Point(12, 509);
			this.LblLeft.Name = "LblLeft";
			this.LblLeft.Size = new System.Drawing.Size(62, 24);
			this.LblLeft.TabIndex = 14;
			this.LblLeft.Text = "Left :";
			this.LblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CroppingDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(738, 633);
			this.Controls.Add(this.TrkBarLeft);
			this.Controls.Add(this.LblLeft);
			this.Controls.Add(this.TrkBarTop);
			this.Controls.Add(this.LblTop);
			this.Controls.Add(this.TrkBarZoom);
			this.Controls.Add(this.LblZoom);
			this.Controls.Add(this.LblFlip);
			this.Controls.Add(this.CboFlip);
			this.Controls.Add(this.LblRotation);
			this.Controls.Add(this.CboRotation);
			this.Controls.Add(this.BtnOk);
			this.Controls.Add(this.BtnAnnuler);
			this.Controls.Add(this.PicturePanel);
			this.Name = "CroppingDialog";
			this.Text = "CroppingWindow";
			this.Load += new System.EventHandler(this.CroppingWindowLoad);
			this.PicturePanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.TrkBarZoom)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TrkBarTop)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TrkBarLeft)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ComboBox CboFlip;
		private System.Windows.Forms.Label LblZoom;
		private System.Windows.Forms.TrackBar TrkBarZoom;
		private System.Windows.Forms.TrackBar TrkBarTop;
		private System.Windows.Forms.Label LblTop;
		private System.Windows.Forms.TrackBar TrkBarLeft;
		private System.Windows.Forms.Label LblLeft;
		private System.Windows.Forms.Panel SelectionPanel;
		private System.Windows.Forms.Label LblFlip;
		private System.Windows.Forms.ComboBox CboRotation;
		private System.Windows.Forms.Label LblRotation;
		private System.Windows.Forms.Button BtnOk;
		private System.Windows.Forms.Button BtnAnnuler;
		private System.Windows.Forms.Panel PicturePanel;
		
	}
}
