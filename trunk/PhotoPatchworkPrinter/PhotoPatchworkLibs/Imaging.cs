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
		public Rectangle Region;

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
			float destRatio = ((float)ImgInfos.Region.Width)/((float)ImgInfos.Region.Height);
			float left = 0;
			float top = 0;
			float width = (float)ImageSize.Width;
			float height = (float)ImageSize.Height;
			if (srcRatio>destRatio) {//larger
				width = height*destRatio;
				left = ((float)ImageSize.Width-width)/2F;
			} else {//taller
				height = width/destRatio;
				top = ((float)ImageSize.Height-height)/2F;
			}
			return new Rectangle((int)left, (int)top, (int)width, (int)height);
		}
	}
}
