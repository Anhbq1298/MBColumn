using System;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using #7hc;
using #cMb;
using #LFb;
using #o1d;
using #qzb;
using devDept.Eyeshot;
using devDept.Geometry;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Editor.Core.Tools;
using StructurePoint.Products.Column.Editor.Section.Irregular.Tools.API;
using StructurePoint.Products.Column.Resources;
using StructurePoint.Products.Column.Resources.Images;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.Items;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Shapes
{
	// Token: 0x020004FF RID: 1279
	internal sealed class AddSlabCircleTool : BaseToolWithChildren, #uNb, #RFb
	{
		// Token: 0x06002EA3 RID: 11939 RVA: 0x000F1EF4 File Offset: 0x000F00F4
		public AddSlabCircleTool(IExtendedServices services, #Qzb diameterTool, #NFb radiusTool, #Uzb threePointsTool) : base(services)
		{
			this.#a = diameterTool;
			this.#b = radiusTool;
			base.ChildTools.#pR(new IChildColumnEditorTool[]
			{
				radiusTool,
				diameterTool,
				threePointsTool
			});
			this.Tools.Add(new CircleToolViewModel
			{
				Tool = radiusTool,
				Name = Strings.StringCircle,
				Icon = ColumnImages.ShapeCircular_24X24,
				Tooltip = TooltipsHelper.SlabsCircle
			});
			this.Tools.Add(new CircleToolViewModel
			{
				Tool = diameterTool,
				Name = Strings.StringCircle2Point,
				Icon = ColumnImages.ShapeCircular2Points_24X24,
				Tooltip = TooltipsHelper.SlabsCircleByDiameter
			});
			this.Tools.Add(new CircleToolViewModel
			{
				Tool = threePointsTool,
				Name = Strings.StringCircle3Point,
				Icon = ColumnImages.ShapeCircular3Points_24X24,
				Tooltip = TooltipsHelper.SlabsCircleByTangentPoints
			});
			this.#c = this.Tools.First<CircleToolViewModel>();
		}

		// Token: 0x17000F6A RID: 3946
		// (get) Token: 0x06002EA4 RID: 11940 RVA: 0x00029C42 File Offset: 0x00027E42
		public override IView ParametersView
		{
			get
			{
				return this.#c.Tool.ParametersView;
			}
		}

		// Token: 0x17000F6B RID: 3947
		// (get) Token: 0x06002EA5 RID: 11941 RVA: 0x00029C60 File Offset: 0x00027E60
		// (set) Token: 0x06002EA6 RID: 11942 RVA: 0x000F1FFC File Offset: 0x000F01FC
		public CircleToolViewModel SelectedTool
		{
			get
			{
				return this.#c;
			}
			set
			{
				if (this.#c != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107355842));
					this.#c = value;
					this.#8vb(value.Tool);
					base.RaisePropertyChanged(#Phc.#3hc(107355842));
				}
			}
		}

		// Token: 0x17000F6C RID: 3948
		// (get) Token: 0x06002EA7 RID: 11943 RVA: 0x00029C6C File Offset: 0x00027E6C
		public RadObservableCollection<CircleToolViewModel> Tools { get; }

		// Token: 0x06002EA8 RID: 11944 RVA: 0x000F2054 File Offset: 0x000F0254
		public void #cWh()
		{
			if (this.#c != this.Tools.First<CircleToolViewModel>())
			{
				this.#c = this.Tools.First<CircleToolViewModel>();
				base.RaisePropertyChanged(#Phc.#3hc(107355842));
			}
		}

		// Token: 0x06002EA9 RID: 11945 RVA: 0x00028AE6 File Offset: 0x00026CE6
		protected override void #Zzb()
		{
			base.#vMb(ColumnResources.Cross_Add_CursorData);
		}

		// Token: 0x06002EAA RID: 11946 RVA: 0x00029C78 File Offset: 0x00027E78
		public override void OnActivated()
		{
			base.OnActivated();
			this.#8vb(this.SelectedTool.Tool);
		}

		// Token: 0x06002EAB RID: 11947 RVA: 0x000F20A4 File Offset: 0x000F02A4
		public override void OnDeactivated()
		{
			base.OnDeactivated();
			this.#8vb(null);
			CircleToolViewModel circleToolViewModel = this.SelectedTool;
			#tNb #tNb = ((circleToolViewModel != null) ? circleToolViewModel.Tool : null) as #tNb;
			if (#tNb != null)
			{
				#tNb.OnDeactivated();
			}
		}

		// Token: 0x06002EAC RID: 11948 RVA: 0x00029C9D File Offset: 0x00027E9D
		public override void HandleMouseMove(MouseEventArgs args, Point screenPosition, Point3D planePosition)
		{
			base.HandleMouseMove(args, screenPosition, planePosition);
			base.#kMb(args, screenPosition, planePosition);
		}

		// Token: 0x06002EAD RID: 11949 RVA: 0x00029CBE File Offset: 0x00027EBE
		public override void HandleMouseDown(MouseButtonEventArgs args, Point screenPosition, Point3D planePosition)
		{
			base.HandleMouseDown(args, screenPosition, planePosition);
			base.#iMb(args, screenPosition, planePosition);
		}

		// Token: 0x06002EAE RID: 11950 RVA: 0x00029CDF File Offset: 0x00027EDF
		public override void HandleMouseUp(MouseButtonEventArgs args, Point screenPosition, Point3D planePosition)
		{
			base.HandleMouseUp(args, screenPosition, planePosition);
			base.#lMb(args, screenPosition, planePosition);
		}

		// Token: 0x06002EAF RID: 11951 RVA: 0x00029D00 File Offset: 0x00027F00
		public override void HandleKeyDown(KeyEventArgs args)
		{
			base.HandleKeyDown(args);
			base.#qMb(args);
		}

		// Token: 0x06002EB0 RID: 11952 RVA: 0x00029D1D File Offset: 0x00027F1D
		public override void HandleKeyUp(KeyEventArgs args)
		{
			base.HandleKeyUp(args);
			base.#nMb(args);
		}

		// Token: 0x06002EB1 RID: 11953 RVA: 0x00029D3A File Offset: 0x00027F3A
		public override void HandleDrawOverlay(devDept.Eyeshot.Environment.DrawSceneParams data, Point screenPosition, Point3D planePosition)
		{
			base.HandleDrawOverlay(data, screenPosition, planePosition);
			base.#gMb(data, screenPosition, planePosition);
		}

		// Token: 0x06002EB2 RID: 11954 RVA: 0x00029D5B File Offset: 0x00027F5B
		public override void HandleDynamicInputCoordinateChange(DynamicInputCoordinateEventArgs args)
		{
			base.HandleDynamicInputCoordinateChange(args);
			this.#eMb(args);
		}

		// Token: 0x06002EB3 RID: 11955 RVA: 0x00029D78 File Offset: 0x00027F78
		public override void HandleDynamicInputCoordinateCommited(DynamicInputCoordinateEventArgs args)
		{
			base.HandleDynamicInputCoordinateCommited(args);
			base.#mMb(args);
		}

		// Token: 0x06002EB4 RID: 11956 RVA: 0x00029D95 File Offset: 0x00027F95
		public override void HandleDynamicInputCoordinateSnapRequested(DynamicInputCoordinateSnapEventArgs args)
		{
			base.HandleDynamicInputCoordinateSnapRequested(args);
			base.#nWh(args);
		}

		// Token: 0x06002EB5 RID: 11957 RVA: 0x00029DB2 File Offset: 0x00027FB2
		public override void HandleDynamicInputCoordinateValidation(DynamicInputValueValidationEventArgs args)
		{
			base.HandleDynamicInputCoordinateValidation(args);
			base.#jMb(args);
		}

		// Token: 0x06002EB6 RID: 11958 RVA: 0x00029DCF File Offset: 0x00027FCF
		public override void #1kb()
		{
			base.#1kb();
			base.#fMb();
		}

		// Token: 0x06002EB7 RID: 11959 RVA: 0x000F20EC File Offset: 0x000F02EC
		private void #8vb(#MFb #Ph)
		{
			this.Tools.#I1d(new Action<CircleToolViewModel>(AddSlabCircleTool.<>c.<>9.#I0h));
			if (#Ph != null)
			{
				#Ph.IsEnabled = true;
				if (!#Ph.Wrapper.IsSelected)
				{
					#Ph.Toolbar.#8vb(#Ph.Wrapper);
				}
				base.ActiveViewport.Editor.SetFocusExt();
			}
		}

		// Token: 0x040012C0 RID: 4800
		private readonly #Qzb #a;

		// Token: 0x040012C1 RID: 4801
		private readonly #NFb #b;

		// Token: 0x040012C2 RID: 4802
		private CircleToolViewModel #c;

		// Token: 0x040012C3 RID: 4803
		[CompilerGenerated]
		private readonly RadObservableCollection<CircleToolViewModel> #d = new RadObservableCollection<CircleToolViewModel>();
	}
}
