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
		
		private void TSBPreviewClick(object sender, System.EventArgs e)
		{
			// Set the PrintPreviewDialog.Document property to
			// the PrintDocument object selected by the user.
			printPreviewDialog.Document = this.document;

			// Call the ShowDialog method. This will trigger the document's
			//  PrintPage event.
			printPreviewDialog.ShowDialog();

		}
		
		private void TSBExitClick(object sender, System.EventArgs e) {
			Close();
		}

		private void btnThumbClick(object sender, System.EventArgs e)
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
		private bool thumbnailCallback()
		{
			return false;
		}

		private void DocumentPrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			e.Graphics.PageUnit = GraphicsUnit.Millimeter;
			foreach (ImageInfos ii in this.Template) {
				if (ii.Path != null) {
					Image image = Transforms.GetImageFromImageInfos(ii);
					e.Graphics.DrawImage(image, ii.Region);
				}
			}
		}
		
		private void PictureButtonDelete(object sender, EventArgs e)
		{
			PictureButton.PictureButton pb = (PictureButton.PictureButton)sender;
			ImageInfos pi = pb.ImageInfos;
			pi.Path = null;
			pb.ImageInfos = pi;
		}
		
		private void PictureButtonCrop(object sender, EventArgs e)
		{
			PictureButton.PictureButton pb = (PictureButton.PictureButton)sender;

			croppingDialog.ImageInfos = pb.ImageInfos;
			if (croppingDialog.ShowDialog() == DialogResult.OK) {
				pb.ImageInfos = croppingDialog.ImageInfos;
				pb.UpdateThumbnail();
			}
		}
		
		private void PictureButtonOpen(object sender, EventArgs e)
		{
			PictureButton.PictureButton pb = (PictureButton.PictureButton)sender;
			if (openFileDialog.ShowDialog() == DialogResult.OK) {
				ImageInfos ii = pb.ImageInfos;
				ii.Path = openFileDialog.FileName;
				pb.ImageInfos = ii;
			}
		}

		private void MainFormLoad(object sender, System.EventArgs e)
		{
			// TODO add a zoom selector (or schrink page in window?)
			float zoomFactor = 3F;
			// TODO create a "New template" dialog, or a separated template editor?
			// TODO add a PageSetup dialog to get page size and margins
			this.resizePagePanel(new Size(210, 297), new Padding(10), zoomFactor);
			this.Template = getEmptyGridTemplate(new Size(40, 50), new Padding(3), new Size(210, 297), new Padding(10));
			this.refreshPageFromTemplate(Template, zoomFactor);
		}
		
		/// <summary>
		/// Lengths are given in milimeters.
		/// </summary>
		private void resizePagePanel(Size PageSize, Padding PageMargin, float zoomFactor) {
			this.PagePanel.Size = new Size((int)((PageSize.Width - PageMargin.Left - PageMargin.Right) * zoomFactor),
			                               (int)((PageSize.Height - PageMargin.Top - PageMargin.Bottom) * zoomFactor));
			
		}
		
		private static List<ImageInfos> getEmptyGridTemplate(Size PhotoSize, Padding PhotoMargin, Size PageSize, Padding PageMargin) {
			// TODO add template creation
			// TODO replace List<ImageInfos> with a real template class or struct
			int ncols = (int)((float)(PageSize.Width - PageMargin.Left - PageMargin.Right)/(float)PhotoSize.Width);
			int nrows = (int)((float)(PageSize.Height - PageMargin.Top - PageMargin.Bottom)/(float)PhotoSize.Height);

			List<PhotoPatchworkLibs.ImageInfos> Template = new List<PhotoPatchworkLibs.ImageInfos>();
			
			for (int col=0; col<ncols; col++) {
				for (int row=0; row<nrows; row++) {
					ImageInfos ii = new ImageInfos();
					// TODO use isEmpty instead of -1 detection
					ii.Crop = new Rectangle(-1, -1, -1, -1);
					ii.Region = new Rectangle((PhotoSize.Width + PhotoMargin.Left + PhotoMargin.Right) * col - PhotoMargin.Right,
					                          (PhotoSize.Height + PhotoMargin.Top + PhotoMargin.Bottom) * row - PhotoMargin.Bottom,
					                          PhotoSize.Width,
					                          PhotoSize.Height);
					Template.Add(ii);
				}
			}
			
			return Template;
		}
		
		private void refreshPageFromTemplate(List<ImageInfos> Template, float zoomFactor) {
			foreach (ImageInfos ii in Template) {
				PictureButton.PictureButton pb = new PictureButton.PictureButton();
				
				pb.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top|System.Windows.Forms.AnchorStyles.Left));
				pb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
				pb.Location = new System.Drawing.Point((int)(ii.Region.Left * zoomFactor), (int)(ii.Region.Top * zoomFactor));
				pb.Size = new System.Drawing.Size((int)(ii.Region.Width * zoomFactor), (int)(ii.Region.Height * zoomFactor));
				// pb.TabIndex = col + row * ncols;
				pb.ImageInfos = ii;
				
				pb.PictureClick += new PictureButton.PictureButton.PictureClickEventHandler(this.PictureButtonOpen);
				pb.Open += new PictureButton.PictureButton.OpenEventHandler(this.PictureButtonOpen);
				pb.Delete += new PictureButton.PictureButton.DeleteEventHandler(this.PictureButtonDelete);
				pb.Crop += new PictureButton.PictureButton.CropEventHandler(this.PictureButtonCrop);
				
				this.PagePanel.Controls.Add(pb);
			}
		}

	}
}
