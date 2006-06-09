/*
 * Created by SharpDevelop.
 * User: ribouxj
 * Date: 18/05/2006
 * Time: 16:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
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
