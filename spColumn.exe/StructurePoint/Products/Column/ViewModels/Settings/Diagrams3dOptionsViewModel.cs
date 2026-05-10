using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using #0I;
using #7hc;
using #Lx;
using #oKe;
using #Ot;
using #pc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Core;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.ViewModels.Settings
{
	// Token: 0x02000181 RID: 385
	internal sealed class Diagrams3dOptionsViewModel : #ex<#tc>, #5I, IPanel, IChangesInfo, #Px
	{
		// Token: 0x06000C8B RID: 3211 RVA: 0x0009C49C File Offset: 0x0009A69C
		public Diagrams3dOptionsViewModel(Lazy<#tc> view, ICoreServices services, #nKe localizationService, ISettingsManager settingsManager) : base(view, services)
		{
			this.#a = localizationService;
			this.#b = settingsManager;
			this.CameraTypesSource.AddRange(this.#a.AvailableDiagram3DCameraTypes.Select(new Func<KeyValuePair<CameraType, string>, ComboItem<CameraType>>(Diagrams3dOptionsViewModel.<>c.<>9.#9Ub)));
		}

		// Token: 0x17000507 RID: 1287
		// (get) Token: 0x06000C8C RID: 3212 RVA: 0x0000FB0E File Offset: 0x0000DD0E
		// (set) Token: 0x06000C8D RID: 3213 RVA: 0x0000FB1A File Offset: 0x0000DD1A
		public bool AreMainAxesVisible
		{
			get
			{
				return this.#i;
			}
			set
			{
				this.SetProperty<bool>(ref this.#i, value, #Phc.#3hc(107411289));
			}
		}

		// Token: 0x17000508 RID: 1288
		// (get) Token: 0x06000C8E RID: 3214 RVA: 0x0000FB40 File Offset: 0x0000DD40
		// (set) Token: 0x06000C8F RID: 3215 RVA: 0x0000FB4C File Offset: 0x0000DD4C
		public bool IsCoordinateSystem
		{
			get
			{
				return this.#c;
			}
			set
			{
				this.SetProperty<bool>(ref this.#c, value, #Phc.#3hc(107411232));
			}
		}

		// Token: 0x17000509 RID: 1289
		// (get) Token: 0x06000C90 RID: 3216 RVA: 0x0000FB72 File Offset: 0x0000DD72
		// (set) Token: 0x06000C91 RID: 3217 RVA: 0x0000FB7E File Offset: 0x0000DD7E
		public bool Show3dRotationCube
		{
			get
			{
				return this.#d;
			}
			set
			{
				this.SetProperty<bool>(ref this.#d, value, #Phc.#3hc(107411207));
			}
		}

		// Token: 0x1700050A RID: 1290
		// (get) Token: 0x06000C92 RID: 3218 RVA: 0x0000FBA4 File Offset: 0x0000DDA4
		// (set) Token: 0x06000C93 RID: 3219 RVA: 0x0000FBB0 File Offset: 0x0000DDB0
		public bool Diagram3DIsMxMyPlaneVisible
		{
			get
			{
				return this.#e;
			}
			set
			{
				this.SetProperty<bool>(ref this.#e, value, #Phc.#3hc(107410670));
			}
		}

		// Token: 0x1700050B RID: 1291
		// (get) Token: 0x06000C94 RID: 3220 RVA: 0x0000FBD6 File Offset: 0x0000DDD6
		// (set) Token: 0x06000C95 RID: 3221 RVA: 0x0000FBE2 File Offset: 0x0000DDE2
		public bool Diagram3DIsPMxPlaneVisible
		{
			get
			{
				return this.#f;
			}
			set
			{
				this.SetProperty<bool>(ref this.#f, value, #Phc.#3hc(107410633));
			}
		}

		// Token: 0x1700050C RID: 1292
		// (get) Token: 0x06000C96 RID: 3222 RVA: 0x0000FC08 File Offset: 0x0000DE08
		// (set) Token: 0x06000C97 RID: 3223 RVA: 0x0000FC14 File Offset: 0x0000DE14
		public bool Diagram3DIsMyPPlaneVisible
		{
			get
			{
				return this.#g;
			}
			set
			{
				this.SetProperty<bool>(ref this.#g, value, #Phc.#3hc(107410596));
			}
		}

		// Token: 0x1700050D RID: 1293
		// (get) Token: 0x06000C98 RID: 3224 RVA: 0x0000FC3A File Offset: 0x0000DE3A
		// (set) Token: 0x06000C99 RID: 3225 RVA: 0x0000FC46 File Offset: 0x0000DE46
		public ComboItem<CameraType> SelectedCameraType
		{
			get
			{
				return this.#h;
			}
			set
			{
				this.SetProperty<ComboItem<CameraType>>(ref this.#h, value, #Phc.#3hc(107410591));
			}
		}

		// Token: 0x1700050E RID: 1294
		// (get) Token: 0x06000C9A RID: 3226 RVA: 0x0000FC6C File Offset: 0x0000DE6C
		public Color MainPlaneXYColor
		{
			get
			{
				return this.#b.MainAxisPlaneXYColor;
			}
		}

		// Token: 0x1700050F RID: 1295
		// (get) Token: 0x06000C9B RID: 3227 RVA: 0x0000FC81 File Offset: 0x0000DE81
		public Color MainPlaneZXColor
		{
			get
			{
				return this.#b.MainAxisPlaneZXColor;
			}
		}

		// Token: 0x17000510 RID: 1296
		// (get) Token: 0x06000C9C RID: 3228 RVA: 0x0000FC96 File Offset: 0x0000DE96
		public Color MainPlaneYZColor
		{
			get
			{
				return this.#b.MainAxisPlaneYZColor;
			}
		}

		// Token: 0x17000511 RID: 1297
		// (get) Token: 0x06000C9D RID: 3229 RVA: 0x0000FCAB File Offset: 0x0000DEAB
		public RadObservableCollection<ComboItem<CameraType>> CameraTypesSource { get; }

		// Token: 0x17000512 RID: 1298
		// (get) Token: 0x06000C9E RID: 3230 RVA: 0x0000FCB7 File Offset: 0x0000DEB7
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06000C9F RID: 3231 RVA: 0x0009C508 File Offset: 0x0009A708
		public bool GetHasChanges()
		{
			return this.IsCoordinateSystem != this.#b.IsCoordinateSystemVisible || this.Show3dRotationCube != this.#b.Show3dRotationCube || this.AreMainAxesVisible != this.#b.AreMainAxesVisible || this.Diagram3DIsMxMyPlaneVisible != this.#b.Diagram3DIsMxMyPlaneVisible || this.Diagram3DIsPMxPlaneVisible != this.#b.Diagram3DIsPMxPlaneVisible || this.Diagram3DIsMyPPlaneVisible != this.#b.Diagram3DIsMyPPlaneVisible || this.SelectedCameraType != this.CameraTypesSource.Single(new Func<ComboItem<CameraType>, bool>(this.#KTh));
		}

		// Token: 0x06000CA0 RID: 3232 RVA: 0x0009C5CC File Offset: 0x0009A7CC
		public override void UpdateFromModel(ColumnModel model)
		{
			this.IsCoordinateSystem = this.#b.IsCoordinateSystemVisible;
			this.Show3dRotationCube = this.#b.Show3dRotationCube;
			this.AreMainAxesVisible = this.#b.AreMainAxesVisible;
			this.Diagram3DIsMxMyPlaneVisible = this.#b.Diagram3DIsMxMyPlaneVisible;
			this.Diagram3DIsPMxPlaneVisible = this.#b.Diagram3DIsPMxPlaneVisible;
			this.Diagram3DIsMyPPlaneVisible = this.#b.Diagram3DIsMyPPlaneVisible;
			this.SelectedCameraType = this.CameraTypesSource.Single(new Func<ComboItem<CameraType>, bool>(this.#LTh));
		}

		// Token: 0x06000CA1 RID: 3233 RVA: 0x0009C67C File Offset: 0x0009A87C
		public override void UpdateModel(ColumnModel model)
		{
			this.#b.IsCoordinateSystemVisible = this.IsCoordinateSystem;
			this.#b.Show3dRotationCube = this.Show3dRotationCube;
			this.#b.AreMainAxesVisible = this.AreMainAxesVisible;
			this.#b.Diagram3DIsMxMyPlaneVisible = this.Diagram3DIsMxMyPlaneVisible;
			this.#b.Diagram3DIsPMxPlaneVisible = this.Diagram3DIsPMxPlaneVisible;
			this.#b.Diagram3DIsMyPPlaneVisible = this.Diagram3DIsMyPPlaneVisible;
			this.#b.CameraType = this.SelectedCameraType.Value;
		}

		// Token: 0x06000CA2 RID: 3234 RVA: 0x0009C71C File Offset: 0x0009A91C
		public override void #qt()
		{
			this.IsCoordinateSystem = false;
			this.Show3dRotationCube = true;
			this.AreMainAxesVisible = true;
			this.Diagram3DIsMxMyPlaneVisible = false;
			this.Diagram3DIsPMxPlaneVisible = false;
			this.Diagram3DIsMyPPlaneVisible = false;
			this.SelectedCameraType = this.CameraTypesSource.Single(new Func<ComboItem<CameraType>, bool>(Diagrams3dOptionsViewModel.<>c.<>9.#nXh));
		}

		// Token: 0x06000CA3 RID: 3235 RVA: 0x0009C790 File Offset: 0x0009A990
		public override void #or()
		{
			base.RaisePropertyChanged(#Phc.#3hc(107410534));
			base.RaisePropertyChanged(#Phc.#3hc(107410509));
			base.RaisePropertyChanged(#Phc.#3hc(107410516));
			base.#or();
		}

		// Token: 0x06000CA4 RID: 3236 RVA: 0x0000A950 File Offset: 0x00008B50
		void #5I.#Lr()
		{
			base.ClearErrors();
		}

		// Token: 0x06000CA5 RID: 3237 RVA: 0x0000A960 File Offset: 0x00008B60
		void #5I.#Or(string #em)
		{
			base.RemoveError(#em);
		}

		// Token: 0x06000CA6 RID: 3238 RVA: 0x0009C7E0 File Offset: 0x0009A9E0
		[CompilerGenerated]
		private bool #KTh(ComboItem<CameraType> #9o)
		{
			return #9o.Value.Equals(this.#b.CameraType);
		}

		// Token: 0x06000CA7 RID: 3239 RVA: 0x0009C7E0 File Offset: 0x0009A9E0
		[CompilerGenerated]
		private bool #LTh(ComboItem<CameraType> #9o)
		{
			return #9o.Value.Equals(this.#b.CameraType);
		}

		// Token: 0x040004AE RID: 1198
		private readonly #nKe #a;

		// Token: 0x040004AF RID: 1199
		private readonly ISettingsManager #b;

		// Token: 0x040004B0 RID: 1200
		private bool #c;

		// Token: 0x040004B1 RID: 1201
		private bool #d;

		// Token: 0x040004B2 RID: 1202
		private bool #e;

		// Token: 0x040004B3 RID: 1203
		private bool #f;

		// Token: 0x040004B4 RID: 1204
		private bool #g;

		// Token: 0x040004B5 RID: 1205
		private ComboItem<CameraType> #h;

		// Token: 0x040004B6 RID: 1206
		private bool #i;

		// Token: 0x040004B7 RID: 1207
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<CameraType>> #j = new RadObservableCollection<ComboItem<CameraType>>();
	}
}
