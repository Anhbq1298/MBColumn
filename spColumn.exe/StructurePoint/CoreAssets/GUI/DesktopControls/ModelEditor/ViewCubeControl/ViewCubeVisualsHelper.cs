using System;
using System.Collections.Generic;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using #7hc;
using Ab3d.Utilities;
using Ab3d.Visuals;
using HelixToolkit.Wpf;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl
{
	// Token: 0x0200094F RID: 2383
	internal abstract class ViewCubeVisualsHelper
	{
		// Token: 0x17001681 RID: 5761
		// (get) Token: 0x06004D8E RID: 19854 RVA: 0x000410A2 File Offset: 0x0003F2A2
		protected string AssemblyName
		{
			get
			{
				return typeof(ViewCubeVisualsHelper).Assembly.GetName().Name;
			}
		}

		// Token: 0x17001682 RID: 5762
		// (get) Token: 0x06004D8F RID: 19855 RVA: 0x000410C9 File Offset: 0x0003F2C9
		// (set) Token: 0x06004D90 RID: 19856 RVA: 0x000410D5 File Offset: 0x0003F2D5
		public MultiMaterialBoxVisual3D ViewCube { get; set; }

		// Token: 0x17001683 RID: 5763
		// (get) Token: 0x06004D91 RID: 19857 RVA: 0x000410E6 File Offset: 0x0003F2E6
		public double Offset
		{
			get
			{
				return 0.02;
			}
		}

		// Token: 0x17001684 RID: 5764
		// (get) Token: 0x06004D92 RID: 19858 RVA: 0x000410F1 File Offset: 0x0003F2F1
		// (set) Token: 0x06004D93 RID: 19859 RVA: 0x000410FD File Offset: 0x0003F2FD
		public List<VisualEventSource3D> EventSourceCollection { get; set; }

		// Token: 0x17001685 RID: 5765
		// (get) Token: 0x06004D94 RID: 19860 RVA: 0x0004110E File Offset: 0x0003F30E
		public Material TransparentMaterial { get; }

		// Token: 0x17001686 RID: 5766
		// (get) Token: 0x06004D95 RID: 19861 RVA: 0x0004111A File Offset: 0x0003F31A
		public Material SemiTransparentMaterial { get; }

		// Token: 0x17001687 RID: 5767
		// (get) Token: 0x06004D96 RID: 19862 RVA: 0x00041126 File Offset: 0x0003F326
		public SolidColorBrush AxisXColor { get; }

		// Token: 0x17001688 RID: 5768
		// (get) Token: 0x06004D97 RID: 19863 RVA: 0x00041132 File Offset: 0x0003F332
		public SolidColorBrush AxisYColor { get; }

		// Token: 0x17001689 RID: 5769
		// (get) Token: 0x06004D98 RID: 19864 RVA: 0x0004113E File Offset: 0x0003F33E
		public SolidColorBrush AxisZColor { get; }

		// Token: 0x1700168A RID: 5770
		// (get) Token: 0x06004D99 RID: 19865 RVA: 0x0004114A File Offset: 0x0003F34A
		public SolidColorBrush AxisLabelBackground { get; }

		// Token: 0x1700168B RID: 5771
		// (get) Token: 0x06004D9A RID: 19866
		public abstract string MainDirButtons { get; }

		// Token: 0x1700168C RID: 5772
		// (get) Token: 0x06004D9B RID: 19867
		public abstract string MainDirTextures { get; }

		// Token: 0x1700168D RID: 5773
		// (get) Token: 0x06004D9C RID: 19868 RVA: 0x00041156 File Offset: 0x0003F356
		public ImageSource CounterClockwiseNormalButtonImageSource
		{
			get
			{
				return new BitmapImage(new Uri(this.MainDirButtons + #Phc.#3hc(107469611)));
			}
		}

		// Token: 0x1700168E RID: 5774
		// (get) Token: 0x06004D9D RID: 19869 RVA: 0x00041183 File Offset: 0x0003F383
		public ImageSource CounterClockwiseSelectedButtonImageSource
		{
			get
			{
				return new BitmapImage(new Uri(this.MainDirButtons + #Phc.#3hc(107469590)));
			}
		}

		// Token: 0x1700168F RID: 5775
		// (get) Token: 0x06004D9E RID: 19870 RVA: 0x000411B0 File Offset: 0x0003F3B0
		public ImageSource ClockwiseNormalButtonImageSource
		{
			get
			{
				return new BitmapImage(new Uri(this.MainDirButtons + #Phc.#3hc(107468993)));
			}
		}

		// Token: 0x17001690 RID: 5776
		// (get) Token: 0x06004D9F RID: 19871 RVA: 0x000411DD File Offset: 0x0003F3DD
		public ImageSource ClockwiseSelectedButtonImageSource
		{
			get
			{
				return new BitmapImage(new Uri(this.MainDirButtons + #Phc.#3hc(107468984)));
			}
		}

		// Token: 0x17001691 RID: 5777
		// (get) Token: 0x06004DA0 RID: 19872 RVA: 0x0004120A File Offset: 0x0003F40A
		public ImageSource UpNormalButtonImageSource
		{
			get
			{
				return new BitmapImage(new Uri(this.MainDirButtons + #Phc.#3hc(107468907)));
			}
		}

		// Token: 0x17001692 RID: 5778
		// (get) Token: 0x06004DA1 RID: 19873 RVA: 0x00041237 File Offset: 0x0003F437
		public ImageSource UpSelectedButtonImageSource
		{
			get
			{
				return new BitmapImage(new Uri(this.MainDirButtons + #Phc.#3hc(107468874)));
			}
		}

		// Token: 0x17001693 RID: 5779
		// (get) Token: 0x06004DA2 RID: 19874 RVA: 0x00041264 File Offset: 0x0003F464
		public ImageSource RightNormalButtonImageSource
		{
			get
			{
				return new BitmapImage(new Uri(this.MainDirButtons + #Phc.#3hc(107468837)));
			}
		}

		// Token: 0x17001694 RID: 5780
		// (get) Token: 0x06004DA3 RID: 19875 RVA: 0x00041291 File Offset: 0x0003F491
		public ImageSource RightSelectedButtonImageSource
		{
			get
			{
				return new BitmapImage(new Uri(this.MainDirButtons + #Phc.#3hc(107468800)));
			}
		}

		// Token: 0x17001695 RID: 5781
		// (get) Token: 0x06004DA4 RID: 19876 RVA: 0x000412BE File Offset: 0x0003F4BE
		public ImageSource DownNormalButtonImageSource
		{
			get
			{
				return new BitmapImage(new Uri(this.MainDirButtons + #Phc.#3hc(107469303)));
			}
		}

		// Token: 0x17001696 RID: 5782
		// (get) Token: 0x06004DA5 RID: 19877 RVA: 0x000412EB File Offset: 0x0003F4EB
		public ImageSource DownSelectedButtonImageSource
		{
			get
			{
				return new BitmapImage(new Uri(this.MainDirButtons + #Phc.#3hc(107469266)));
			}
		}

		// Token: 0x17001697 RID: 5783
		// (get) Token: 0x06004DA6 RID: 19878 RVA: 0x00041318 File Offset: 0x0003F518
		public ImageSource LeftNormalButtonImageSource
		{
			get
			{
				return new BitmapImage(new Uri(this.MainDirButtons + #Phc.#3hc(107469197)));
			}
		}

		// Token: 0x17001698 RID: 5784
		// (get) Token: 0x06004DA7 RID: 19879 RVA: 0x00041345 File Offset: 0x0003F545
		public ImageSource LeftSelectedButtonImageSource
		{
			get
			{
				return new BitmapImage(new Uri(this.MainDirButtons + #Phc.#3hc(107469160)));
			}
		}

		// Token: 0x17001699 RID: 5785
		// (get) Token: 0x06004DA8 RID: 19880 RVA: 0x00041372 File Offset: 0x0003F572
		public string BackViewCubeTexture
		{
			get
			{
				return this.MainDirTextures + #Phc.#3hc(107469123);
			}
		}

		// Token: 0x1700169A RID: 5786
		// (get) Token: 0x06004DA9 RID: 19881 RVA: 0x00041395 File Offset: 0x0003F595
		public string BottomViewCubeTexture
		{
			get
			{
				return this.MainDirTextures + #Phc.#3hc(107469090);
			}
		}

		// Token: 0x1700169B RID: 5787
		// (get) Token: 0x06004DAA RID: 19882 RVA: 0x000413B8 File Offset: 0x0003F5B8
		public string FrontViewCubeTexture
		{
			get
			{
				return this.MainDirTextures + #Phc.#3hc(107469085);
			}
		}

		// Token: 0x1700169C RID: 5788
		// (get) Token: 0x06004DAB RID: 19883 RVA: 0x000413DB File Offset: 0x0003F5DB
		public string LeftViewCubeTexture
		{
			get
			{
				return this.MainDirTextures + #Phc.#3hc(107468540);
			}
		}

		// Token: 0x1700169D RID: 5789
		// (get) Token: 0x06004DAC RID: 19884 RVA: 0x000413FE File Offset: 0x0003F5FE
		public string RightViewCubeTexture
		{
			get
			{
				return this.MainDirTextures + #Phc.#3hc(107468507);
			}
		}

		// Token: 0x1700169E RID: 5790
		// (get) Token: 0x06004DAD RID: 19885 RVA: 0x00041421 File Offset: 0x0003F621
		public string TopViewCubeTexture
		{
			get
			{
				return this.MainDirTextures + #Phc.#3hc(107468474);
			}
		}

		// Token: 0x06004DAE RID: 19886 RVA: 0x00041444 File Offset: 0x0003F644
		protected static Material CreateMaterialFromImage(string path)
		{
			return new DiffuseMaterial(new ImageBrush(new BitmapImage(new Uri(path))));
		}

		// Token: 0x06004DAF RID: 19887 RVA: 0x0014EE88 File Offset: 0x0014D088
		public void SetupBindings(NewViewCubeControl viewCubeControl)
		{
			BindingHelper.SetBinding<string>(new BindingHelperParametersContainer<string>
			{
				Target = viewCubeControl.AxisXLabelVisual,
				TargetProperty = BillboardTextVisual3D.TextProperty,
				Source = viewCubeControl,
				PropertyExpression = (() => viewCubeControl.AxisXLabel),
				BindingMode = BindingMode.OneWay
			}, false);
			BindingHelper.SetBinding<string>(new BindingHelperParametersContainer<string>
			{
				Target = viewCubeControl.AxisYLabelVisual,
				TargetProperty = BillboardTextVisual3D.TextProperty,
				Source = viewCubeControl,
				PropertyExpression = (() => viewCubeControl.AxisYLabel),
				BindingMode = BindingMode.OneWay
			}, false);
			BindingHelper.SetBinding<string>(new BindingHelperParametersContainer<string>
			{
				Target = viewCubeControl.AxisZLabelVisual,
				TargetProperty = BillboardTextVisual3D.TextProperty,
				Source = viewCubeControl,
				PropertyExpression = (() => viewCubeControl.AxisZLabel),
				BindingMode = BindingMode.OneWay
			}, false);
		}

		// Token: 0x06004DB0 RID: 19888 RVA: 0x0014F040 File Offset: 0x0014D240
		protected void SetupMouseEventHandlers(Visual3D visual, MouseEventHandlers mouseEventHandlers, EventManager3D eventManager)
		{
			VisualEventSource3D visualEventSource3D = new VisualEventSource3D(visual);
			visualEventSource3D.MouseEnter += mouseEventHandlers.MouseEnter;
			visualEventSource3D.MouseLeave += mouseEventHandlers.MouseLeave;
			visualEventSource3D.MouseClick += mouseEventHandlers.MouseClick;
			eventManager.RegisterEventSource3D(visualEventSource3D);
			this.EventSourceCollection.Add(visualEventSource3D);
		}

		// Token: 0x06004DB1 RID: 19889 RVA: 0x0014F098 File Offset: 0x0014D298
		protected void MySetupViewCubeTextures()
		{
			this.ViewCube.FrontMaterial = ViewCubeVisualsHelper.CreateMaterialFromImage(this.TopViewCubeTexture);
			this.ViewCube.TopMaterial = ViewCubeVisualsHelper.CreateMaterialFromImage(this.BackViewCubeTexture);
			this.ViewCube.BackMaterial = ViewCubeVisualsHelper.CreateMaterialFromImage(this.BottomViewCubeTexture);
			this.ViewCube.BottomMaterial = ViewCubeVisualsHelper.CreateMaterialFromImage(this.FrontViewCubeTexture);
			this.ViewCube.LeftMaterial = ViewCubeVisualsHelper.CreateMaterialFromImage(this.LeftViewCubeTexture);
			this.ViewCube.RightMaterial = ViewCubeVisualsHelper.CreateMaterialFromImage(this.RightViewCubeTexture);
		}

		// Token: 0x06004DB2 RID: 19890 RVA: 0x0014F148 File Offset: 0x0014D348
		protected ViewCubeVisualsHelper()
		{
			this.<ViewCube>k__BackingField = new MultiMaterialBoxVisual3D();
			this.<EventSourceCollection>k__BackingField = new List<VisualEventSource3D>();
			this.<TransparentMaterial>k__BackingField = new DiffuseMaterial(new SolidColorBrush(Colors.Transparent));
			this.<SemiTransparentMaterial>k__BackingField = new DiffuseMaterial(new SolidColorBrush(Color.FromArgb(100, 0, 155, 7)));
			this.<AxisXColor>k__BackingField = new SolidColorBrush(Color.FromRgb(byte.MaxValue, 0, 0));
			this.<AxisYColor>k__BackingField = new SolidColorBrush(Color.FromRgb(0, byte.MaxValue, 0));
			this.<AxisZColor>k__BackingField = new SolidColorBrush(Color.FromRgb(0, 0, byte.MaxValue));
			this.<AxisLabelBackground>k__BackingField = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
			base..ctor();
		}

		// Token: 0x04002265 RID: 8805
		private const double DefaultOffset = 0.02;
	}
}
