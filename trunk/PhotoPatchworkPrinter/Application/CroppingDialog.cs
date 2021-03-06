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
		private bool _isLoading = true;
		
		public CroppingDialog()
		{
			InitializeComponent();
		}

		public ImageInfos ImageInfos { get { return this._imgInfos; } set { this._imgInfos = value; } }

		void CroppingWindowLoad(object sender, System.EventArgs e) {
			this._isLoading = true;
			if (this._imgInfos.Path == null) {
				this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
				this.Close();
			}
			
			Image img = Transforms.GetImageFromImageInfos(this._imgInfos, false);

			if (this._imgInfos.Crop.Left == -1) {
				this._imgInfos.Crop = Transforms.GetDefaultCropFromImageInfos(this._imgInfos, img.Size);
			}

			this._imgSize = img.Size;
			
			this._imgRatio = (float)this._imgInfos.Region.Width / (float)this._imgInfos.Region.Height;
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
				newSize.Height = (int)((float)newSize.Width / this._fullImgRatio);
				this._dispRatio = (float)newSize.Width / (float)img.Width;
			} else {
				newSize.Width = (int)((float)newSize.Height * this._fullImgRatio);
				this._dispRatio = (float)newSize.Height / (float)img.Height;
			}

			img = Transforms.Resize(img, newSize);
			this.PicturePanel.BackgroundImage = img;
			this._isLoading = false;
			RefreshSelection();
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
			if (!this._isLoading) {
				this.RefreshSelection();
			}
		}
		
	}
}
