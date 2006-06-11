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
			this.BtnAnnuler = new System.Windows.Forms.Button();
			this.BtnOk = new System.Windows.Forms.Button();
			this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
			this.document = new System.Drawing.Printing.PrintDocument();
			this.grpBoxImages = new System.Windows.Forms.GroupBox();
			this.ScrollPanel = new System.Windows.Forms.Panel();
			this.PicturesTable = new System.Windows.Forms.TableLayoutPanel();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.croppingDialog = new PhotoPatchworkPrinter.CroppingDialog();
			this.grpBoxImages.SuspendLayout();
			this.ScrollPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// BtnAnnuler
			// 
			this.BtnAnnuler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnAnnuler.Location = new System.Drawing.Point(602, 609);
			this.BtnAnnuler.Name = "BtnAnnuler";
			this.BtnAnnuler.Size = new System.Drawing.Size(86, 28);
			this.BtnAnnuler.TabIndex = 0;
			this.BtnAnnuler.Text = "&Fermer";
			this.BtnAnnuler.UseVisualStyleBackColor = true;
			this.BtnAnnuler.Click += new System.EventHandler(this.BtnAnnulerClick);
			// 
			// BtnOk
			// 
			this.BtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnOk.Location = new System.Drawing.Point(510, 609);
			this.BtnOk.Name = "BtnOk";
			this.BtnOk.Size = new System.Drawing.Size(86, 28);
			this.BtnOk.TabIndex = 1;
			this.BtnOk.Text = "&Imprimer";
			this.BtnOk.UseVisualStyleBackColor = true;
			this.BtnOk.Click += new System.EventHandler(this.BtnTestClick);
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
			// grpBoxImages
			// 
			this.grpBoxImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.grpBoxImages.Controls.Add(this.ScrollPanel);
			this.grpBoxImages.Location = new System.Drawing.Point(12, 12);
			this.grpBoxImages.Name = "grpBoxImages";
			this.grpBoxImages.Size = new System.Drawing.Size(675, 591);
			this.grpBoxImages.TabIndex = 2;
			this.grpBoxImages.TabStop = false;
			this.grpBoxImages.Text = "Page";
			// 
			// ScrollPanel
			// 
			this.ScrollPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.ScrollPanel.AutoScroll = true;
			this.ScrollPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ScrollPanel.BackColor = System.Drawing.Color.Transparent;
			this.ScrollPanel.Controls.Add(this.PicturesTable);
			this.ScrollPanel.Location = new System.Drawing.Point(6, 20);
			this.ScrollPanel.Name = "ScrollPanel";
			this.ScrollPanel.Size = new System.Drawing.Size(663, 565);
			this.ScrollPanel.TabIndex = 0;
			// 
			// PicturesTable
			// 
			this.PicturesTable.AutoSize = true;
			this.PicturesTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.PicturesTable.BackColor = System.Drawing.Color.White;
			this.PicturesTable.ColumnCount = 2;
			this.PicturesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.PicturesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.PicturesTable.Location = new System.Drawing.Point(0, 0);
			this.PicturesTable.Name = "PicturesTable";
			this.PicturesTable.RowCount = 2;
			this.PicturesTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.PicturesTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.PicturesTable.Size = new System.Drawing.Size(0, 0);
			this.PicturesTable.TabIndex = 4;
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
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(700, 649);
			this.Controls.Add(this.grpBoxImages);
			this.Controls.Add(this.BtnOk);
			this.Controls.Add(this.BtnAnnuler);
			this.Name = "MainForm";
			this.Text = "Photo Patchwork Printer";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.grpBoxImages.ResumeLayout(false);
			this.ScrollPanel.ResumeLayout(false);
			this.ScrollPanel.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.TableLayoutPanel PicturesTable;
		private System.Windows.Forms.Panel ScrollPanel;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private PhotoPatchworkPrinter.CroppingDialog croppingDialog;
		private System.Windows.Forms.GroupBox grpBoxImages;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
		private System.Windows.Forms.Button BtnOk;
		private System.Windows.Forms.Button BtnAnnuler;
		
	}
}
