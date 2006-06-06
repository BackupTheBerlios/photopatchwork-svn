/*
 * Created by SharpDevelop.
 * User: ribouxj
 * Date: 18/05/2006
 * Time: 16:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace PictureButton
{
	partial class PictureButton : System.Windows.Forms.UserControl
	{
		private System.ComponentModel.IContainer components = null;
		
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PictureButton));
			this.PicturePanel = new System.Windows.Forms.Panel();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.OpenButton = new System.Windows.Forms.ToolStripButton();
			this.CropButton = new System.Windows.Forms.ToolStripButton();
			this.DeleteButton = new System.Windows.Forms.ToolStripButton();
			this.PicturePanel.SuspendLayout();
			this.toolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// PicturePanel
			// 
			this.PicturePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.PicturePanel.BackColor = System.Drawing.Color.Transparent;
			this.PicturePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.PicturePanel.Controls.Add(this.toolStrip);
			this.PicturePanel.Location = new System.Drawing.Point(0, 0);
			this.PicturePanel.Margin = new System.Windows.Forms.Padding(0);
			this.PicturePanel.Name = "PicturePanel";
			this.PicturePanel.Size = new System.Drawing.Size(229, 189);
			this.PicturePanel.TabIndex = 1;
			this.PicturePanel.Click += new System.EventHandler(this.PicturePanelClick);
			// 
			// toolStrip
			// 
			this.toolStrip.AllowMerge = false;
			this.toolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.toolStrip.BackColor = System.Drawing.Color.Transparent;
			this.toolStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.toolStrip.CanOverflow = false;
			this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip.GripMargin = new System.Windows.Forms.Padding(0);
			this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip.ImageScalingSize = new System.Drawing.Size(12, 12);
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.OpenButton,
									this.CropButton,
									this.DeleteButton});
			this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
			this.toolStrip.Location = new System.Drawing.Point(198, 113);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
			this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip.Size = new System.Drawing.Size(31, 78);
			this.toolStrip.TabIndex = 2;
			// 
			// OpenButton
			// 
			this.OpenButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.OpenButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenButton.Image")));
			this.OpenButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.OpenButton.Name = "OpenButton";
			this.OpenButton.Size = new System.Drawing.Size(30, 16);
			this.OpenButton.Click += new System.EventHandler(this.OpenButtonClick);
			// 
			// CropButton
			// 
			this.CropButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.CropButton.Image = ((System.Drawing.Image)(resources.GetObject("CropButton.Image")));
			this.CropButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.CropButton.Name = "CropButton";
			this.CropButton.Size = new System.Drawing.Size(30, 16);
			this.CropButton.Click += new System.EventHandler(this.CropButtonClick);
			// 
			// DeleteButton
			// 
			this.DeleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.DeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteButton.Image")));
			this.DeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.DeleteButton.Name = "DeleteButton";
			this.DeleteButton.Size = new System.Drawing.Size(30, 16);
			this.DeleteButton.Click += new System.EventHandler(this.DeleteButtonClick);
			// 
			// PictureButton
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.Controls.Add(this.PicturePanel);
			this.ForeColor = System.Drawing.SystemColors.ButtonShadow;
			this.Name = "PictureButton";
			this.Size = new System.Drawing.Size(229, 190);
			this.PicturePanel.ResumeLayout(false);
			this.PicturePanel.PerformLayout();
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton OpenButton;
		private System.Windows.Forms.ToolStripButton CropButton;
		private System.Windows.Forms.ToolStripButton DeleteButton;
		private System.Windows.Forms.Panel PicturePanel;
		
		void PicturePanelClick(object sender, System.EventArgs e) {
			if (PictureClick != null) PictureClick(this, e);
		}
		
		void CropButtonClick(object sender, System.EventArgs e) {
			if (Crop != null) Crop(this, e);
		}
		
		void DeleteButtonClick(object sender, System.EventArgs e) {
			if (Delete != null) Delete(this, e);
		}
		
		void OpenButtonClick(object sender, System.EventArgs e) {
			if (Open != null) Open(this, e);
		}
	}
}
