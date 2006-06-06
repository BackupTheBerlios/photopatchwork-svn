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

		public PictureInfosStruct _PictureInfos;
		
		public event DeleteEventHandler Delete;
		public event CropEventHandler Crop;
		public event OpenEventHandler Open;
		public event PictureClickEventHandler PictureClick;
		
		public PictureButton() {
			InitializeComponent();
			this._PictureInfos.Width = 0;
			this._PictureInfos.Height = 0;
			this._PictureInfos.Bottom = 0;
			this._PictureInfos.Top = 0;
			this._PictureInfos.Left = 0;
			this._PictureInfos.Right = 0;
			this._PictureInfos.Flip = Flips.None;
			this._PictureInfos.Rotate = Rotations.Deg0;
		}

		public PictureButton(PictureInfosStruct pi) {
			InitializeComponent();
			this._PictureInfos = pi;
		}
		
		public PictureInfosStruct PictureInfos { get { return this._PictureInfos; } set { this._PictureInfos = value; this.UpdateImages(); } }
		
		public void UpdateImages() {
			if (this.PictureInfos.PicturePath == null) {
				this.BackgroundImage = null;
				return;
			}
			Image image = Image.FromFile(this.PictureInfos.PicturePath);
			float srcRatio = ((float)image.Width)/((float)image.Height);
			float destRatio = ((float)this.PictureInfos.Width)/((float)this.PictureInfos.Height);
			_PictureInfos.Left = 0;
			_PictureInfos.Right = 0;
			_PictureInfos.Top = 0;
			_PictureInfos.Bottom = 0;
			MessageBox.Show("srcRatio : "+srcRatio);
			MessageBox.Show("destRatio : "+destRatio);
			if (srcRatio>destRatio) {//larger
				_PictureInfos.Left = _PictureInfos.Right = (int)(((float)image.Width-(float)image.Height*destRatio)/(float)2);
				MessageBox.Show("Left : "+_PictureInfos.Left);
			} else {//taller
				_PictureInfos.Top = _PictureInfos.Bottom = (int)(((float)image.Height-(float)image.Width/destRatio)/(float)2);
				MessageBox.Show("Top : "+_PictureInfos.Top);
			}
			this.BackgroundImage = Thumbnail(image);
		}

		public Image CroppedImage() {
			if (this.PictureInfos.PicturePath == null) return null;
			return CroppedImage(Image.FromFile(this.PictureInfos.PicturePath));
		}

		private Image CroppedImage(Image srcImage) {
			return CropPicture(srcImage, this.PictureInfos.Left, this.PictureInfos.Top, this.PictureInfos.Right, this.PictureInfos.Bottom);
		}
		
		private Image Thumbnail(Image srcImage) {
			return this.CroppedImage().GetThumbnailImage(this.PicturePanel.Width, this.PicturePanel.Height, thumbnailCallback, IntPtr.Zero);
		}
		private bool thumbnailCallback() { return false; }

		private static Image CropPicture(Image Picture, int x0, int y0, int x1, int y1) {
			int srcWidth = Picture.Width-x0-x1;
			int srcHeight = Picture.Height-y0-y1;
			int destWidth = srcWidth;
			int destHeight = srcHeight;
			int sourceX = x0;
			int sourceY = y0;
			int destX = 0;
			int destY = 0;

			Bitmap bmPhoto = new Bitmap(destWidth, destHeight, PixelFormat.Format24bppRgb);
			bmPhoto.SetResolution(Picture.HorizontalResolution, Picture.VerticalResolution);

			Graphics grPhoto = Graphics.FromImage(bmPhoto);
			grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

			grPhoto.DrawImage(Picture,
			                  new Rectangle(destX,destY,destWidth,destHeight),
			                  new Rectangle(sourceX,sourceY,srcWidth,srcHeight),
			                  GraphicsUnit.Pixel);

			grPhoto.Dispose();
			return bmPhoto;
		}
	}

	public enum Rotations {Deg0=0, Deg90=1, Deg180=2, Deg270=3};
	public enum Flips {None=0, Horizontal=1, Vertical=2, Both=3};

	public struct PictureInfosStruct {// TODO cache image? thumbnail?
		public int Width;
		public int Height;
		public int Top;
		public int Left;
		public int Bottom;
		public int Right;
		public Rotations Rotate;
		public Flips Flip;
		public string PicturePath;
	}
}
