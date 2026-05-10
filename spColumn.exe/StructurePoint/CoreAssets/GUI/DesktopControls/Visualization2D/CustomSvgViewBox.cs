using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using #7hc;
using #o1d;
using Ab2d;
using Ab2d.Controls;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Visualization2D
{
	// Token: 0x020008C7 RID: 2247
	[CLSCompliant(false)]
	public sealed class CustomSvgViewBox : SvgViewbox
	{
		// Token: 0x06004728 RID: 18216 RVA: 0x0003BEC4 File Offset: 0x0003A0C4
		public CustomSvgViewBox()
		{
			base.SnapsToDevicePixels = false;
			base.UseLayoutRounding = false;
		}

		// Token: 0x06004729 RID: 18217 RVA: 0x0003BEDA File Offset: 0x0003A0DA
		public void Load(string svgData)
		{
			this.streamToLoad = new MemoryStream(Encoding.UTF8.GetBytes(svgData));
			this.Load(this.streamToLoad);
		}

		// Token: 0x0600472A RID: 18218 RVA: 0x0003BF0A File Offset: 0x0003A10A
		public void Load(Stream stream)
		{
			this.streamToLoad = stream;
			LayoutHelper.BeginInvokeOnApplicationThread(delegate()
			{
				base.Source = new Uri(#Phc.#3hc(107452666), UriKind.RelativeOrAbsolute);
			});
		}

		// Token: 0x0600472B RID: 18219 RVA: 0x00140A68 File Offset: 0x0013EC68
		protected override void ReadSvg(Uri sourceUri)
		{
			if (this.streamToLoad == null)
			{
				base.ReadSvg(sourceUri);
				return;
			}
			this.streamToLoad.#i2d();
			ReaderSvg readerSvg = new ReaderSvg
			{
				NamedObjectsSource = base.NamedObjectsSource,
				AutoSize = base.AutoSize,
				AddHiddenElements = true,
				ReadForeignObjects = true,
				FlattenHierarchies = false,
				OptimizeObjectGroups = false,
				TransformShapes = false,
				SwitchElementProcessingType = ReaderSvg.SwitchElementProcessingTypes.ShowFirstDiscardOthers,
				OverrideMiterLimit = 2.0
			};
			Viewbox viewbox = readerSvg.Read(this.streamToLoad);
			this.OnSvgFileLoaded(sourceUri, viewbox);
			UIElement child = viewbox.Child;
			viewbox.Child = null;
			this.Child = child;
			base.InnerReaderSvg = readerSvg;
		}

		// Token: 0x04002042 RID: 8258
		private Stream streamToLoad;
	}
}
