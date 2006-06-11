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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PhotoPatchworkLibs;

namespace PhotoPatchworkPrinter
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm
	{

		[STAThread]
		public static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
		public MainForm()
		{
			InitializeComponent();
		}
		
		void BtnTestClick(object sender, System.EventArgs e)
		{
			printPreviewDialog.ShowDialog();
		}
		
		void BtnAnnulerClick(object sender, System.EventArgs e) {
			Close();
		}

		void btnThumbClick(object sender, System.EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK) {
				Button button = (Button)sender;
				Image image = Image.FromFile(openFileDialog.FileName);
				double imageRatio = (double)image.Width/(double)image.Height;
				double buttonRatio = (double)button.Width/(double)button.Height;
				double tWidth;
				double tHeight;
				if (imageRatio>buttonRatio) { //if picture larger than button
					tHeight = button.Height;
					tWidth = tHeight*imageRatio;
				} else { //if picture taller than button
					tWidth = button.Width;
					tHeight = tWidth/imageRatio;
				}
				Image tImage = image.GetThumbnailImage ((int)tWidth, (int)tHeight, thumbnailCallback, IntPtr.Zero);
				button.Image = tImage;
			}
		}
		public bool thumbnailCallback()
		{
			return false;
		}


		private void document_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			string text = "In document_PrintPage method.";
			System.Drawing.Font printFont = new System.Drawing.Font("Arial", 35, System.Drawing.FontStyle.Regular);

			e.Graphics.DrawString(text, printFont, System.Drawing.Brushes.Black, 0, 0);
			System.Drawing.Image image = System.Drawing.Image.FromFile("C:\\Documents and Settings\\ribouxj\\Mes documents\\Mes images\\Athl�te.jpg");
			e.Graphics.DrawImage(image, 0, 0);
		}
		
		void PictureButtonDelete(object sender, EventArgs e)
		{
			PictureButton.PictureButton pb = (PictureButton.PictureButton)sender;
			ImageInfos pi = pb.ImageInfos;
			pi.Path = null;
			pb.ImageInfos = pi;
		}
		
		void PictureButtonCrop(object sender, EventArgs e)
		{
			PictureButton.PictureButton pb = (PictureButton.PictureButton)sender;

			croppingDialog.ImageInfos = pb.ImageInfos;
			if (croppingDialog.ShowDialog() == DialogResult.OK) {
				pb.ImageInfos = croppingDialog.ImageInfos;
				pb.UpdateThumbnail();
			}
		}
		
		void PictureButtonOpen(object sender, EventArgs e)
		{
			PictureButton.PictureButton pb = (PictureButton.PictureButton)sender;
			if (openFileDialog.ShowDialog() == DialogResult.OK) {
				ImageInfos ii = pb.ImageInfos;
				ii.Path = openFileDialog.FileName;
				pb.ImageInfos = ii;
			}
		}

		void MainFormLoad(object sender, System.EventArgs e)
		{
			this.resizePicturesTable(new Size(210, 297), new Size(40, 50));
		}
		
		/// <summary>
		/// Lengths are given in milimeters.
		/// </summary>
		void resizePicturesTable(Size PageSize, Size PhotoSize) {
			// TODO add margins (or directlty replace with page templates !!!)
			int ncols = (int)((float)PageSize.Width/(float)PhotoSize.Width);
			int nrows = (int)((float)PageSize.Height/(float)PhotoSize.Height);
			float zoomFactor = 3F;
			int picturePxWidth = (int)((float)PhotoSize.Width * zoomFactor);
			int picturePxHeight = (int)((float)PhotoSize.Height * zoomFactor);

			this.PicturesTable.ColumnCount = ncols;
			this.PicturesTable.ColumnStyles.Clear();
			for (int i=0; i<ncols; i++) {
				this.PicturesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, picturePxWidth+6F));
			}
			this.PicturesTable.RowCount = nrows;
			for (int i=0; i<nrows; i++) {
				this.PicturesTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, picturePxHeight+6F));
			}
			for (int col=0; col<ncols; col++) {
				for (int row=0; row<nrows; row++) {
					PictureButton.PictureButton pb = new PictureButton.PictureButton();
					pb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
					pb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
					pb.Location = new System.Drawing.Point(3, 3);
					pb.Size = new System.Drawing.Size((int)picturePxWidth, (int)picturePxHeight);
					pb.TabIndex = col+row*ncols;
					pb.PictureClick += new PictureButton.PictureButton.PictureClickEventHandler(this.PictureButtonOpen);
					pb.Open += new PictureButton.PictureButton.OpenEventHandler(this.PictureButtonOpen);
					pb.Delete += new PictureButton.PictureButton.DeleteEventHandler(this.PictureButtonDelete);
					pb.Crop += new PictureButton.PictureButton.CropEventHandler(this.PictureButtonCrop);
					ImageInfos ii = new ImageInfos();
					ii.Crop = new Rectangle(-1, -1, -1, -1);
					ii.Size = new Size(PhotoSize.Width, PhotoSize.Height);
					pb.ImageInfos = ii;
					this.PicturesTable.Controls.Add(pb, col, row);
				}
			}
		}
	}
}
