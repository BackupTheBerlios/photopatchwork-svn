// Photo Patchwork Printer
// Copyright (C) 2006 Jonathan RIBOUX
// 
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.

using System.Collections.Generic;

namespace PhotoPatchworkPrinter
{
	partial class MainForm : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components = null;
		private System.Drawing.Printing.PrintDocument document = null;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
			this.document = new System.Drawing.Printing.PrintDocument();
			this.ScrollPanel = new System.Windows.Forms.Panel();
			this.PagePanel = new System.Windows.Forms.Panel();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.croppingDialog = new PhotoPatchworkPrinter.CroppingDialog();
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.TSBPreview = new System.Windows.Forms.ToolStripButton();
			this.TSBExit = new System.Windows.Forms.ToolStripButton();
			this.Template = new List<PhotoPatchworkLibs.ImageInfos>();
			this.ScrollPanel.SuspendLayout();
			this.toolStripContainer1.ContentPanel.SuspendLayout();
			this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// printPreviewDialog
			// 
			this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog.Document = this.document;
			this.printPreviewDialog.Enabled = true;
			this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
			this.printPreviewDialog.Name = "printPreviewDialog";
			this.printPreviewDialog.Visible = false;
			// 
			// ScrollPanel
			// 
			this.ScrollPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.ScrollPanel.AutoScroll = true;
			this.ScrollPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ScrollPanel.BackColor = System.Drawing.Color.Transparent;
			this.ScrollPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.ScrollPanel.Controls.Add(this.PagePanel);
			this.ScrollPanel.Location = new System.Drawing.Point(0, 0);
			this.ScrollPanel.Name = "ScrollPanel";
			this.ScrollPanel.Size = new System.Drawing.Size(700, 624);
			this.ScrollPanel.TabIndex = 0;
			// 
			// PagePanel
			// 
			this.PagePanel.BackColor = System.Drawing.Color.White;
			this.PagePanel.Location = new System.Drawing.Point(0, 0);
			this.PagePanel.Name = "PagePanel";
			this.PagePanel.Size = new System.Drawing.Size(0, 0);
			this.PagePanel.TabIndex = 4;
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog";
			// 
			// croppingDialog
			// 
			this.croppingDialog.ClientSize = new System.Drawing.Size(456, 311);
			this.croppingDialog.Location = new System.Drawing.Point(22, 59);
			this.croppingDialog.Name = "croppingDialog";
			this.croppingDialog.Text = "Crop";
			this.croppingDialog.Visible = false;
			// 
			// toolStripContainer1
			// 
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.Controls.Add(this.ScrollPanel);
			this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(700, 624);
			this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.Size = new System.Drawing.Size(700, 649);
			this.toolStripContainer1.TabIndex = 2;
			this.toolStripContainer1.Text = "toolStripContainer1";
			// 
			// toolStripContainer1.TopToolStripPanel
			// 
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.TSBPreview,
									this.TSBExit});
			this.toolStrip1.Location = new System.Drawing.Point(3, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(58, 25);
			this.toolStrip1.TabIndex = 0;
			// 
			// TSBPreview
			// 
			this.TSBPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSBPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSBPreview.Name = "TSBPreview";
			this.TSBPreview.Size = new System.Drawing.Size(23, 22);
			this.TSBPreview.Text = "Preview";
			this.TSBPreview.Click += new System.EventHandler(this.TSBPreviewClick);
			// 
			// TSBExit
			// 
			this.TSBExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSBExit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSBExit.Name = "TSBExit";
			this.TSBExit.Size = new System.Drawing.Size(23, 22);
			this.TSBExit.Text = "Exit";
			this.TSBExit.Click += new System.EventHandler(this.TSBExitClick);
			//
			// document
			//
			this.document.PrintPage += (System.Drawing.Printing.PrintPageEventHandler)DocumentPrintPage;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(700, 649);
			this.Controls.Add(this.toolStripContainer1);
			this.Name = "MainForm";
			this.Text = "Photo Patchwork Printer";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.ScrollPanel.ResumeLayout(false);
			this.toolStripContainer1.ContentPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.PerformLayout();
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ToolStripButton TSBExit;
		private System.Windows.Forms.ToolStripButton TSBPreview;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripContainer toolStripContainer1;
		private System.Windows.Forms.Panel PagePanel;
		private System.Windows.Forms.Panel ScrollPanel;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private PhotoPatchworkPrinter.CroppingDialog croppingDialog;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
		private List<PhotoPatchworkLibs.ImageInfos> Template;
		
	}
}
