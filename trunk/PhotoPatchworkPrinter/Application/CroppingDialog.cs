using System;
using System.Drawing;
using System.Windows.Forms;
using PhotoPatchworkLibs;

namespace PhotoPatchworkPrinter
{
	/// <summary>
	/// Description of CroppingWindow.
	/// </summary>
	public partial class CroppingDialog
	{
		private ImageInfos _imgInfos;
		private Size _imgSize;
		private float _imgRatio;
		private float _fullImgRatio;
		private float _dispRatio;
		
		public CroppingDialog()
		{
			InitializeComponent();
		}

		public ImageInfos ImageInfos { get { return this._imgInfos; } set { this._imgInfos = value; } }

		void CroppingWindowLoad(object sender, System.EventArgs e)
		{
			Image img = Transforms.GetImageFromImageInfos(_imgInfos, false);

			if (this._imgInfos.Crop.Left == -1) {
				this._imgInfos.Crop = Transforms.GetDefaultCropFromImageInfos(_imgInfos, img.Size);
			}

			this._imgSize = img.Size;
			
			this._imgRatio = (float)_imgInfos.Size.Width / (float)_imgInfos.Size.Height;
			this._fullImgRatio = (float)img.Width / (float)img.Height;

			
			TrkBarLeft.Minimum = 0;
			TrkBarTop.Minimum = 0;
			TrkBarZoom.Minimum = 0;

			TrkBarLeft.Maximum = img.Width - 1;
			TrkBarTop.Maximum = img.Height - 1;
			TrkBarZoom.Maximum = 10000;

			TrkBarLeft.Value = this._imgInfos.Crop.Left;
			TrkBarTop.Value = this._imgInfos.Crop.Top;
			if (_imgRatio > _fullImgRatio) {
				TrkBarZoom.Value = (int)((float)this._imgInfos.Crop.Width / (float)img.Width * 10000F);
			} else {
				TrkBarZoom.Value = (int)((float)this._imgInfos.Crop.Height / (float)img.Height * 10000F);
			}
			
			
			Size newSize = new Size(this.PicturePanel.Width, this.PicturePanel.Height);
			float pnlRatio = (float)this.PicturePanel.Width / (float)this.PicturePanel.Height;
			if (this._fullImgRatio > pnlRatio) {
				newSize.Height = (int)(newSize.Width / this._fullImgRatio);
			} else {
				newSize.Width = (int)(newSize.Height * this._fullImgRatio);
			}
			this._dispRatio = (float)newSize.Width / (float)img.Width;

			img = Transforms.Resize(img, newSize);
			this.PicturePanel.BackgroundImage = img;

			
			this.RefreshSelection();
		}
		
		void RefreshSelection() {
			float left = (float)TrkBarLeft.Value;
			float top = (float)TrkBarTop.Value;
			float width = (float)_imgSize.Width * (float)TrkBarZoom.Value / 10000F;
			float height = (float)_imgSize.Height * (float)TrkBarZoom.Value / 10000F;

			if (_imgRatio > _fullImgRatio) {
				height = width / _imgRatio;
			} else {
				width = height * _imgRatio;
			}
			
			this._imgInfos.Crop = new Rectangle((int)left, (int)top, (int)width, (int)height);
			
			this.SelectionPanel.Left = (int)(left * _dispRatio);
			this.SelectionPanel.Top = (int)(top * _dispRatio);
			this.SelectionPanel.Width = (int)(width * _dispRatio);
			this.SelectionPanel.Height = (int)(height * _dispRatio);
		}
		
		void BtnOkClick(object sender, System.EventArgs e) {
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}
		
		void BtnAnnulerClick(object sender, System.EventArgs e) {
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

		void TrkBarsValueChanged(object sender, System.EventArgs e) {
			this.RefreshSelection();
		}
		
	}
}
