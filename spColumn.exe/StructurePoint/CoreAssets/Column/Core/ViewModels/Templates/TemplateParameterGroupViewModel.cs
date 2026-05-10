using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.Runtime;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Framework.Collections;

namespace StructurePoint.CoreAssets.Column.Core.ViewModels.Templates
{
	// Token: 0x02000827 RID: 2087
	public sealed class TemplateParameterGroupViewModel : NotifyPropertyChangedObjectBase
	{
		// Token: 0x060042CE RID: 17102 RVA: 0x00136F04 File Offset: 0x00135104
		public TemplateParameterGroupViewModel(TemplateEngine engine, ParameterRuntimeGroup group)
		{
			this.Group = group;
			this.Parameters.#pR(from item in @group.Parameters
			select TemplateParameterViewModelFactory.Create(engine, item));
			if (this.Parameters.Any<TemplateParameterViewModelBase>())
			{
				this.Parameters[0].IsFirst = true;
			}
		}

		// Token: 0x170013B8 RID: 5048
		// (get) Token: 0x060042CF RID: 17103 RVA: 0x00038162 File Offset: 0x00036362
		// (set) Token: 0x060042D0 RID: 17104 RVA: 0x0003816A File Offset: 0x0003636A
		public bool IsFirst { get; set; }

		// Token: 0x170013B9 RID: 5049
		// (get) Token: 0x060042D1 RID: 17105 RVA: 0x00038173 File Offset: 0x00036373
		public ParameterRuntimeGroup Group { get; }

		// Token: 0x170013BA RID: 5050
		// (get) Token: 0x060042D2 RID: 17106 RVA: 0x0003817B File Offset: 0x0003637B
		public string Name
		{
			get
			{
				return this.Group.Name;
			}
		}

		// Token: 0x170013BB RID: 5051
		// (get) Token: 0x060042D3 RID: 17107 RVA: 0x00038188 File Offset: 0x00036388
		public CustomObservableCollection<TemplateParameterViewModelBase> Parameters { get; } = new CustomObservableCollection<TemplateParameterViewModelBase>();

		// Token: 0x170013BC RID: 5052
		// (get) Token: 0x060042D4 RID: 17108 RVA: 0x00038190 File Offset: 0x00036390
		// (set) Token: 0x060042D5 RID: 17109 RVA: 0x00038198 File Offset: 0x00036398
		public SolidColorBrush ZoneColorBrush
		{
			get
			{
				return this.zoneColorBrush;
			}
			private set
			{
				if (this.zoneColorBrush != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107456613));
					this.zoneColorBrush = value;
					base.RaisePropertyChanged(#Phc.#3hc(107456613));
				}
			}
		}

		// Token: 0x170013BD RID: 5053
		// (get) Token: 0x060042D6 RID: 17110 RVA: 0x000381CA File Offset: 0x000363CA
		// (set) Token: 0x060042D7 RID: 17111 RVA: 0x00136F84 File Offset: 0x00135184
		public Color ZoneColor
		{
			get
			{
				return this.zoneColor;
			}
			set
			{
				if (this.zoneColor != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107456624));
					this.zoneColor = value;
					this.ZoneColorBrush = new SolidColorBrush(value);
					base.RaisePropertyChanged(#Phc.#3hc(107456624));
				}
			}
		}

		// Token: 0x170013BE RID: 5054
		// (get) Token: 0x060042D8 RID: 17112 RVA: 0x000381D2 File Offset: 0x000363D2
		// (set) Token: 0x060042D9 RID: 17113 RVA: 0x000381DA File Offset: 0x000363DA
		public bool ShowColoredZoneIndicator
		{
			get
			{
				return this.showColoredZoneIndicator;
			}
			set
			{
				if (this.showColoredZoneIndicator != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107456579));
					this.showColoredZoneIndicator = value;
					base.RaisePropertyChanged(#Phc.#3hc(107456579));
				}
			}
		}

		// Token: 0x170013BF RID: 5055
		// (get) Token: 0x060042DA RID: 17114 RVA: 0x0003820C File Offset: 0x0003640C
		// (set) Token: 0x060042DB RID: 17115 RVA: 0x00038214 File Offset: 0x00036414
		public int ZoneId { get; set; }

		// Token: 0x170013C0 RID: 5056
		// (get) Token: 0x060042DC RID: 17116 RVA: 0x0003821D File Offset: 0x0003641D
		// (set) Token: 0x060042DD RID: 17117 RVA: 0x00038225 File Offset: 0x00036425
		internal int ColorIndex { get; set; }

		// Token: 0x170013C1 RID: 5057
		// (get) Token: 0x060042DE RID: 17118 RVA: 0x0003822E File Offset: 0x0003642E
		// (set) Token: 0x060042DF RID: 17119 RVA: 0x00038236 File Offset: 0x00036436
		public Visibility Visibility
		{
			get
			{
				return this.visibility;
			}
			set
			{
				if (this.visibility != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107384000));
					this.visibility = value;
					base.RaisePropertyChanged(#Phc.#3hc(107384000));
				}
			}
		}

		// Token: 0x04001E17 RID: 7703
		private Color zoneColor;

		// Token: 0x04001E18 RID: 7704
		private bool showColoredZoneIndicator;

		// Token: 0x04001E19 RID: 7705
		private SolidColorBrush zoneColorBrush = Brushes.Transparent;

		// Token: 0x04001E1A RID: 7706
		private Visibility visibility;
	}
}
