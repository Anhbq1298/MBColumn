using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Text;
using #7hc;
using #v1c;
using Aspose.Words;
using Aspose.Words.Saving;

namespace #VEd
{
	// Token: 0x02000D6C RID: 3436
	internal static class #eFd
	{
		// Token: 0x06007CC1 RID: 31937 RVA: 0x001B6BA4 File Offset: 0x001B4DA4
		public static void #9Ed()
		{
			try
			{
				if (!#eFd.#c)
				{
					object obj = #eFd.#b;
					bool flag = false;
					try
					{
						\u000E\u0004.\u008D\u0008(obj, ref flag);
						if (!#eFd.#c)
						{
							#eFd.#dFd();
						}
						#eFd.#c = true;
					}
					finally
					{
						if (flag)
						{
							\u0017.\u009E(obj);
						}
					}
				}
			}
			catch (Exception ex)
			{
				string str = #eFd.#a;
				string str2 = \u008E.\u0099\u0002();
				Exception ex2 = ex;
				Console.WriteLine(str + str2 + ((ex2 != null) ? ex2.ToString() : null));
			}
		}

		// Token: 0x06007CC2 RID: 31938 RVA: 0x001B6C4C File Offset: 0x001B4E4C
		public static void #aFd(this Document #bFd, Stream #gp, SaveFormat #cA = SaveFormat.Emf, int #RIc = 5, Color? #cFd = null)
		{
			ImageSaveOptions imageSaveOptions = new ImageSaveOptions(#cA)
			{
				PageCount = 1,
				UseGdiEmfRenderer = true,
				DmlEffectsRenderingMode = DmlEffectsRenderingMode.Fine,
				JpegQuality = 100,
				UseHighQualityRendering = true,
				Scale = (float)#RIc
			};
			if (#cFd != null)
			{
				imageSaveOptions.PaperColor = #cFd.Value;
			}
			imageSaveOptions.MetafileRenderingOptions.RenderingMode = MetafileRenderingMode.Vector;
			imageSaveOptions.MetafileRenderingOptions.EmulateRasterOperations = true;
			imageSaveOptions.MetafileRenderingOptions.EmfPlusDualRenderingMode = EmfPlusDualRenderingMode.EmfPlusWithFallback;
			imageSaveOptions.MetafileRenderingOptions.UseEmfEmbeddedToWmf = false;
			imageSaveOptions.GraphicsQualityOptions = new GraphicsQualityOptions
			{
				CompositingQuality = new CompositingQuality?(CompositingQuality.HighQuality),
				SmoothingMode = new SmoothingMode?(SmoothingMode.HighQuality),
				TextRenderingHint = new TextRenderingHint?(TextRenderingHint.AntiAliasGridFit),
				InterpolationMode = new InterpolationMode?(InterpolationMode.High)
			};
			#bFd.Save(#gp, imageSaveOptions);
		}

		// Token: 0x06007CC3 RID: 31939 RVA: 0x001B6D34 File Offset: 0x001B4F34
		private static void #dFd()
		{
			#u1c #u1c = new #u1c(256, #u1c.#p1c<ASCIIEncoding>(#6Ed.#a), #u1c.#p1c<ASCIIEncoding>(#5Ed.#a));
			try
			{
				MemoryStream memoryStream = new MemoryStream(\u0010\u0004.~\u008F\u0008(\u009A.\u0094\u0003(), #u1c.#t1c(#8Ed.#a, #7Ed.#a)));
				try
				{
					\u0089\u0003.~\u009A\u0007(new License(), memoryStream);
				}
				finally
				{
					if (memoryStream != null)
					{
						\u0007.~\u000E(memoryStream);
					}
				}
			}
			finally
			{
				if (#u1c != null)
				{
					\u0007.~\u000E(#u1c);
				}
			}
		}

		// Token: 0x0400331C RID: 13084
		private static readonly string #a = #Phc.#3hc(107282390);

		// Token: 0x0400331D RID: 13085
		private static readonly object #b = new object();

		// Token: 0x0400331E RID: 13086
		private static volatile bool #c;
	}
}
