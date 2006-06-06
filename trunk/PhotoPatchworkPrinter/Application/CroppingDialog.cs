/*
 * Created by SharpDevelop.
 * User: ribouxj
 * Date: 19/05/2006
 * Time: 10:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace PhotoPatchworkPrinter
{
	/// <summary>
	/// Description of CroppingWindow.
	/// </summary>
	public partial class CroppingDialog
	{
		// TODO use a structure instead
		private long _CropLeft;
		private long _CropRight;
		private long _CropTop;
		private long _CropBottom;
		private PictureButton.Rotations _Rotate;
		private PictureButton.Flips _Flip;
		private string _PicturePath;
		
		
		public CroppingDialog()
		{
			InitializeComponent();
			this._PicturePath = null;
			this._CropBottom = 0;
			this._CropLeft = 0;
			this._CropRight = 0;
			this._CropTop = 0;
			this._Flip = PictureButton.Flips.None;
			this._Rotate = PictureButton.Rotations.Deg0;
		}

		public long CropLeft { get { return this._CropLeft; } set { this._CropLeft = value; } }
		public long CropRight { get { return this._CropRight; } set { this._CropRight= value; } }
		public long CropTop { get { return this._CropTop; } set { this._CropTop = value; } }
		public long CropBottom { get { return this._CropBottom; } set { this._CropBottom = value; } }
		public PictureButton.Rotations Rotate { get { return this._Rotate; } set { this._Rotate = value; } }
		public PictureButton.Flips Flip { get { return this._Flip; } set { this._Flip = value; } }
		public string PicturePath { get { return this._PicturePath; } set { this._PicturePath = value; this.Refresh(); } }

		void CroppingWindowLoad(object sender, System.EventArgs e)
		{
			if (this.PicturePath != null) {
				Image image = Image.FromFile(this.PicturePath);
				
				double imageRatio = (double)image.Width/(double)image.Height;
				double panelRatio = (double)this.PicturePanel.Width/(double)this.PicturePanel.Height;
				double tWidth;
				double tHeight;
				if (imageRatio>panelRatio) { //if picture is larger than panel
					tHeight = this.PicturePanel.Height;
					tWidth = tHeight*imageRatio;
				} else { //if picture is taller than panel
					tWidth = this.PicturePanel.Width;
					tHeight = tWidth/imageRatio;
				}
				Image tImage = image.GetThumbnailImage ((int)tWidth, (int)tHeight, thumbnailCallback, IntPtr.Zero);
				Graphics grImage = Graphics.FromImage(tImage);
				grImage.Clip = new Region(new Rectangle(15,0,32,32));
				grImage.Clear(Color.AliceBlue);
				
				this.PicturePanel.BackgroundImage = tImage;
			} else {
				this.PicturePanel.BackgroundImage = null;
			}
		}
		
		public bool thumbnailCallback()
		{
			return false;
		}
		
		void BtnOkClick(object sender, System.EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}
		
		void BtnAnnulerClick(object sender, System.EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}
	}
}
