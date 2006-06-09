using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace PhotoPatchworkLibs
{
	public enum Rotations {Deg0=0, Deg90=1, Deg180=2, Deg270=3};
	public enum Flips {None=0, Horizontal=1, Vertical=2, Both=3};

	public struct ImageInfos {
		/// <summary>
		/// Path to picture file
		/// </summary>
		public string Path;

		/// <summary>
		/// Size of the printed picture in milimeters
		/// </summary>
		public Size Size;

		/// <summary>
		/// Cropping area in pixels
		/// </summary>
		public Rectangle Crop;

		/// <summary>
		/// Rotation (0, 90, 180 or 270)
		/// </summary>
		public Rotations Rotate;

		/// <summary>
		/// Flip (horizontal, vertical or both)
		/// </summary>
		public Flips Flip;
	}

	public static class Transforms
	{
		public static Image Crop(Image Img, Rectangle rect) {
			int srcW = rect.Width;
			int srcH = rect.Height;
			int dstW = srcW;
			int dstH = srcH;
			int srcX = rect.Left;
			int srcY = rect.Top;
			int dstX = 0;
			int dstY = 0;
			
			Bitmap bmRes = new Bitmap(dstW, dstH, PixelFormat.Format24bppRgb);
			bmRes.SetResolution(Img.HorizontalResolution, Img.VerticalResolution);
			
			Graphics gr = Graphics.FromImage(bmRes);
			gr.InterpolationMode = InterpolationMode.HighQualityBicubic; //TODO benchmark interpolation modes
			gr.DrawImage(Img, new Rectangle(dstX, dstY, dstW, dstH), new Rectangle(srcX, srcY, srcW, srcH), GraphicsUnit.Pixel);
			gr.Dispose();
			
			return bmRes;
		}

		public static Image Resize(Image Img, Size Size) {
			int srcW = Img.Width;
			int srcH = Img.Height;
			int dstW = Size.Width;
			int dstH = Size.Height;
			
			Bitmap bmRes = new Bitmap(dstW, dstH, PixelFormat.Format24bppRgb);
			bmRes.SetResolution(Img.HorizontalResolution, Img.VerticalResolution);
			
			Graphics gr = Graphics.FromImage(bmRes);
			gr.InterpolationMode = InterpolationMode.HighQualityBicubic; //TODO benchmark interpolation modes
			gr.DrawImage(Img, new Rectangle(0, 0, dstW, dstH), new Rectangle(0, 0, srcW, srcH), GraphicsUnit.Pixel);
			gr.Dispose();
			
			return bmRes;
		}
		
		public static Image Flip(Image Img, Flips Flip) {
			//TODO implement Flip
			return Img;
		}
		
		public static Image Rotate(Image Img, Rotations Rotation) {
			//TODO implement Rotate
			return Img;
		}
		
		public static Image GetImageFromImageInfos (ImageInfos ImgInfos) {
			return GetImageFromImageInfos (ImgInfos, true);
		}
		
		public static Image GetImageFromImageInfos (ImageInfos ImgInfos, bool DoCrop) {
			if (ImgInfos.Path == null) {
				return null;
			}
			Image imgRes = Image.FromFile(ImgInfos.Path);

			imgRes = Flip(imgRes, ImgInfos.Flip);
			imgRes = Rotate(imgRes, ImgInfos.Rotate);
			if (DoCrop) {
				if (ImgInfos.Crop.Left != -1) {
					imgRes = Crop(imgRes, ImgInfos.Crop);
				} else {
					ImgInfos.Crop = GetDefaultCropFromImageInfos(ImgInfos, imgRes.Size);
					imgRes = Crop(imgRes, ImgInfos.Crop);
				}
			}
			
			return imgRes;
		}
		
		public static Rectangle GetDefaultCropFromImageInfos(ImageInfos ImgInfos, Size ImageSize) {
			float srcRatio = ((float)ImageSize.Width)/((float)ImageSize.Height);
			float destRatio = ((float)ImgInfos.Size.Width)/((float)ImgInfos.Size.Height);
			float left=0;
			float top=0;
			float width=ImageSize.Width;
			float height=ImageSize.Height;
			if (srcRatio>destRatio) {//larger
				width=(float)ImageSize.Height*destRatio;
				left = ((float)ImageSize.Width-width)/(float)2;
			} else {//taller
				height=(float)ImageSize.Width/destRatio;
				top = ((float)ImageSize.Height-height)/(float)2;
			}
			return new Rectangle((int)left, (int)top, (int)width, (int)height);
		}
	}
}
