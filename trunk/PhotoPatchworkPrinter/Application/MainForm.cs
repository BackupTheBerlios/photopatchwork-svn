/*
 * Created by SharpDevelop.
 * User: ribouxj
 * Date: 18/05/2006
 * Time: 14:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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
			System.Drawing.Image image = System.Drawing.Image.FromFile("C:\\Documents and Settings\\ribouxj\\Mes documents\\Mes images\\Athlète.jpg");
			e.Graphics.DrawImage(image, 0, 0);
		}
		
		void PictureButtonDelete(object sender, EventArgs e)
		{
			PictureButton.PictureButton pb = (PictureButton.PictureButton)sender;
			PictureButton.PictureInfosStruct pi = pb.PictureInfos;
			pi.PicturePath = null;
			pb.PictureInfos = pi;
		}
		
		void PictureButtonCrop(object sender, EventArgs e)
		{
			/*PictureButton.PictureButton pb = (PictureButton.PictureButton)sender;
			PictureButton.PictureInfosStruct pi = pb.PictureInfos;
			pi.PicturePath = null;
			pb.PictureInfos = pi;*/
			DialogResult dr = croppingDialog.ShowDialog();
			
		}
		
		void PictureButtonOpen(object sender, EventArgs e)
		{
			PictureButton.PictureButton pb = (PictureButton.PictureButton)sender;
			if (openFileDialog.ShowDialog() == DialogResult.OK) {
				PictureButton.PictureInfosStruct pi = pb.PictureInfos;
				pi.PicturePath = openFileDialog.FileName;
				pb.PictureInfos = pi;
			}
		}

		void MainFormLoad(object sender, System.EventArgs e)
		{
			this.resizePicturesTable(210, 297, 40, 50);
		}
		
		/// <summary>
		/// Length aregiven in milimeters.
		/// </summary>
		void resizePicturesTable(int pageWidth, int pageHeight, int pictureWidth, int pictureHeight) {
			// TODO add margins (or directlty replace with page templates)
			int ncols = (int)((float)pageWidth/(float)pictureWidth);
			int nrows = (int)((float)pageHeight/(float)pictureHeight);
			float zoomFactor = 3F;
			int picturePxWidth = (int)((float)pictureWidth * zoomFactor);
			int picturePxHeight = (int)((float)pictureHeight * zoomFactor);

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
					PictureButton.PictureInfosStruct pis = new PictureButton.PictureInfosStruct();
					pis.Width = pictureWidth;
					pis.Height = pictureHeight;
					pb.PictureInfos = pis;
					this.PicturesTable.Controls.Add(pb, col, row);
				}
			}
		}
	}
}
