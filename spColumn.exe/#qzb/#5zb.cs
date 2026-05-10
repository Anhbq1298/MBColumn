using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using #7hc;
using #lH;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Services.API;
using Telerik.Windows.Data;

namespace #qzb
{
	// Token: 0x02000507 RID: 1287
	internal sealed class #5zb : #HH<#0zb>, INotifyPropertyChanged, IViewModel, IViewModel<#0zb>, #4zb
	{
		// Token: 0x06002ED8 RID: 11992 RVA: 0x00029EA7 File Offset: 0x000280A7
		public #5zb(Lazy<#0zb> #Ee, ICoreServices #0c) : base(#Ee, #0c)
		{
		}

		// Token: 0x17000F72 RID: 3954
		// (get) Token: 0x06002ED9 RID: 11993 RVA: 0x00029EDE File Offset: 0x000280DE
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x17000F73 RID: 3955
		// (get) Token: 0x06002EDA RID: 11994 RVA: 0x00029EEE File Offset: 0x000280EE
		public RadObservableCollection<ComboItem<PolygonApplication>> PolygonApplications { get; }

		// Token: 0x17000F74 RID: 3956
		// (get) Token: 0x06002EDB RID: 11995 RVA: 0x00029EFA File Offset: 0x000280FA
		// (set) Token: 0x06002EDC RID: 11996 RVA: 0x00029F06 File Offset: 0x00028106
		public PolygonApplication PolygonApplication
		{
			get
			{
				return this.#a;
			}
			set
			{
				if (this.#a != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107355712));
					this.#a = value;
					base.RaisePropertyChanged(#Phc.#3hc(107355712));
				}
			}
		}

		// Token: 0x06002EDD RID: 11997 RVA: 0x00029F44 File Offset: 0x00028144
		public void #5b()
		{
			this.PolygonApplication = PolygonApplication.Solid;
		}

		// Token: 0x040012CA RID: 4810
		private PolygonApplication #a;

		// Token: 0x040012CB RID: 4811
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<PolygonApplication>> #b = new RadObservableCollection<ComboItem<PolygonApplication>>
		{
			new ComboItem<PolygonApplication>(PolygonApplication.Solid, Strings.StringSolid),
			new ComboItem<PolygonApplication>(PolygonApplication.Opening, Strings.StringOpening)
		};
	}
}
