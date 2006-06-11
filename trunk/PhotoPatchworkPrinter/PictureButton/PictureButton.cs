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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using PhotoPatchworkLibs;

namespace PictureButton
{
	/// <summary>
	/// PictureButton is a container for a picture. It can store extra infos too, such as cropping parameters, rotation, flip, ...
	/// </summary>
	public partial class PictureButton
	{
		public delegate void DeleteEventHandler(object sender, EventArgs e);
		public delegate void CropEventHandler(object sender, EventArgs e);
		public delegate void OpenEventHandler(object sender, EventArgs e);
		public delegate void PictureClickEventHandler(object sender, EventArgs e);

		public ImageInfos _ImageInfos;
		
		public event DeleteEventHandler Delete;
		public event CropEventHandler Crop;
		public event OpenEventHandler Open;
		public event PictureClickEventHandler PictureClick;
		
		public PictureButton() {
			InitializeComponent();
			this._ImageInfos.Size = new Size(0, 0);
			this._ImageInfos.Crop = new Rectangle(-1,-1,-1,-1);
			this._ImageInfos.Flip = Flips.None;
			this._ImageInfos.Rotate = Rotations.Deg0;
		}

		public PictureButton(ImageInfos pi) {
			InitializeComponent();
			this._ImageInfos = pi;
		}
		
		public ImageInfos ImageInfos { get { return this._ImageInfos; } set { this._ImageInfos = value; this.UpdateThumbnail(); } }
		
		public void UpdateThumbnail() {
			Image image = Transforms.GetImageFromImageInfos(this.ImageInfos);
			if (image == null) {
				this.PicturePanel.BackgroundImage = null;
			} else {
				this.PicturePanel.BackgroundImage = image.GetThumbnailImage(this.PicturePanel.Width, this.PicturePanel.Height, thumbnailCallback, IntPtr.Zero);
			}
		}
		private bool thumbnailCallback() { return false; }
	}
}
