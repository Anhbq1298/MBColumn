using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using #7hc;
using #7Pb;
using #8Cc;
using #bnb;
using #eU;
using #o1d;
using #oKe;
using StructurePoint.CoreAssets.AppManager.Column.Core;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Units;
using StructurePoint.Products.Column.Services.API;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.Services
{
	// Token: 0x020002B7 RID: 695
	internal sealed class GuiController : NotifyPropertyChangedObjectBase, INotifyPropertyChanged, INotifyPropertyChanging, #zU
	{
		// Token: 0x06001814 RID: 6164 RVA: 0x000B5B78 File Offset: 0x000B3D78
		public GuiController(#oW project, #bDc undoManager, ISettingsManager settingsManager, #wU commandsManager, #nKe localization, #UV messageBus)
		{
			if (undoManager == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107404911));
			}
			if (project == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107404877));
			}
			this.#a = project;
			if (settingsManager == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107381742));
			}
			this.#b = settingsManager;
			this.#c = commandsManager;
			this.#d = localization;
			this.#e = messageBus;
			this.#xO();
			project.ModelChanged += this.#vO;
			undoManager.PropertyChanged += this.#7j;
			this.#j = new #cQb(project, localization);
			this.#l = new #Anb(project);
			this.#k = new #6Pb();
		}

		// Token: 0x170008EE RID: 2286
		// (get) Token: 0x06001815 RID: 6165 RVA: 0x000188E1 File Offset: 0x00016AE1
		public #cQb StatusBar { get; }

		// Token: 0x170008EF RID: 2287
		// (get) Token: 0x06001816 RID: 6166 RVA: 0x000188ED File Offset: 0x00016AED
		public #6Pb MessageStatusBar { get; }

		// Token: 0x170008F0 RID: 2288
		// (get) Token: 0x06001817 RID: 6167 RVA: 0x000188F9 File Offset: 0x00016AF9
		public #Anb EditorStatusBar { get; }

		// Token: 0x170008F1 RID: 2289
		// (get) Token: 0x06001818 RID: 6168 RVA: 0x00018905 File Offset: 0x00016B05
		public RadObservableCollection<RadMenuItem> UnitSystemStatusBarItems { get; }

		// Token: 0x170008F2 RID: 2290
		// (get) Token: 0x06001819 RID: 6169 RVA: 0x00018911 File Offset: 0x00016B11
		// (set) Token: 0x0600181A RID: 6170 RVA: 0x0001891D File Offset: 0x00016B1D
		public bool IsBackstageOpen
		{
			get
			{
				return this.#g;
			}
			set
			{
				if (this.#g != value)
				{
					this.#g = value;
					base.RaisePropertyChanged(#Phc.#3hc(107402193));
				}
			}
		}

		// Token: 0x170008F3 RID: 2291
		// (get) Token: 0x0600181B RID: 6171 RVA: 0x0001894B File Offset: 0x00016B4B
		// (set) Token: 0x0600181C RID: 6172 RVA: 0x00018957 File Offset: 0x00016B57
		public bool IsStartupPageOpen
		{
			get
			{
				return this.#f;
			}
			set
			{
				this.SetProperty<bool>(ref this.#f, value, #Phc.#3hc(107402172));
			}
		}

		// Token: 0x170008F4 RID: 2292
		// (get) Token: 0x0600181D RID: 6173 RVA: 0x0001897D File Offset: 0x00016B7D
		// (set) Token: 0x0600181E RID: 6174 RVA: 0x000B5C58 File Offset: 0x000B3E58
		public string ApplicationTitle
		{
			get
			{
				return this.#h;
			}
			set
			{
				if (this.#h != value)
				{
					this.#h = value;
					base.RaisePropertyChanged(#Phc.#3hc(107402115));
					base.RaisePropertyChanged(#Phc.#3hc(107402115));
				}
			}
		}

		// Token: 0x170008F5 RID: 2293
		// (get) Token: 0x0600181F RID: 6175 RVA: 0x00018989 File Offset: 0x00016B89
		// (set) Token: 0x06001820 RID: 6176 RVA: 0x00018995 File Offset: 0x00016B95
		public string CurrentUnitSystem
		{
			get
			{
				return this.#i;
			}
			set
			{
				if (this.#i != value)
				{
					this.#i = value;
					base.RaisePropertyChanged(#Phc.#3hc(107402090));
				}
			}
		}

		// Token: 0x06001821 RID: 6177 RVA: 0x000B5CA8 File Offset: 0x000B3EA8
		public void #sO()
		{
			if (this.#a.Model == null)
			{
				return;
			}
			this.StatusBar.#uP();
			this.#uO();
		}

		// Token: 0x06001822 RID: 6178 RVA: 0x000189C8 File Offset: 0x00016BC8
		public void #tO(string #5)
		{
			this.MessageStatusBar.#uP(#5);
		}

		// Token: 0x06001823 RID: 6179 RVA: 0x000B5CE4 File Offset: 0x000B3EE4
		public void #uO()
		{
			this.UnitSystemStatusBarItems.Where(new Func<RadMenuItem, bool>(GuiController.<>c.<>9.#d0b)).#I1d(new Action<RadMenuItem>(this.#yO));
			RadMenuItem radMenuItem = this.UnitSystemStatusBarItems.FirstOrDefault(new Func<RadMenuItem, bool>(this.#zO));
			this.CurrentUnitSystem = ((radMenuItem != null) ? radMenuItem.Header.ToString() : null);
		}

		// Token: 0x06001824 RID: 6180 RVA: 0x000189E2 File Offset: 0x00016BE2
		private void #7j(object #Ge, PropertyChangedEventArgs #He)
		{
			this.#sO();
			this.#uO();
		}

		// Token: 0x06001825 RID: 6181 RVA: 0x000189E2 File Offset: 0x00016BE2
		private void #vO(object #Ge, #7V #He)
		{
			this.#sO();
			this.#uO();
		}

		// Token: 0x06001826 RID: 6182 RVA: 0x000B5D68 File Offset: 0x000B3F68
		private void #wO(object #Sb)
		{
			UnitSystem unitSystem = (UnitSystem)#Sb;
			this.#c.ChangeUnitSystem.Execute(unitSystem);
			if (this.#a.Model.Options.Unit == unitSystem)
			{
				this.#uO();
				this.#e.#BV();
			}
		}

		// Token: 0x06001827 RID: 6183 RVA: 0x000B5DC8 File Offset: 0x000B3FC8
		private void #xO()
		{
			if (this.#b.RuntimeSettings.IsCommandlineMode)
			{
				return;
			}
			this.UnitSystemStatusBarItems.AddRange(this.#d.AvailableUnitSystems.Select(new Func<KeyValuePair<UnitSystem, string>, RadMenuItem>(this.#AO)));
		}

		// Token: 0x06001828 RID: 6184 RVA: 0x000189FC File Offset: 0x00016BFC
		[CompilerGenerated]
		private void #yO(RadMenuItem #Rf)
		{
			#Rf.IsChecked = ((UnitSystem)#Rf.CommandParameter == this.#a.Model.Options.Unit);
		}

		// Token: 0x06001829 RID: 6185 RVA: 0x000B5E1C File Offset: 0x000B401C
		[CompilerGenerated]
		private bool #zO(RadMenuItem #Rf)
		{
			return #Rf.IsChecked = ((UnitSystem)#Rf.CommandParameter == this.#a.Model.Options.Unit);
		}

		// Token: 0x0600182A RID: 6186 RVA: 0x000B5E60 File Offset: 0x000B4060
		[CompilerGenerated]
		private RadMenuItem #AO(KeyValuePair<UnitSystem, string> #Rf)
		{
			return new RadMenuItem
			{
				Header = #Rf.Value,
				CommandParameter = #Rf.Key,
				IsCheckable = true,
				Command = new DelegateCommand(new Action<object>(this.#wO)),
				Style = (Application.Current.TryFindResource(#Phc.#3hc(107402097)) as Style),
				MinWidth = 100.0
			};
		}

		// Token: 0x04000936 RID: 2358
		private readonly #oW #a;

		// Token: 0x04000937 RID: 2359
		private readonly ISettingsManager #b;

		// Token: 0x04000938 RID: 2360
		private readonly #wU #c;

		// Token: 0x04000939 RID: 2361
		private readonly #nKe #d;

		// Token: 0x0400093A RID: 2362
		private readonly #UV #e;

		// Token: 0x0400093B RID: 2363
		private bool #f = true;

		// Token: 0x0400093C RID: 2364
		private bool #g;

		// Token: 0x0400093D RID: 2365
		private string #h = ColumnGlobalInfo.ShortName;

		// Token: 0x0400093E RID: 2366
		private string #i;

		// Token: 0x0400093F RID: 2367
		[CompilerGenerated]
		private readonly #cQb #j;

		// Token: 0x04000940 RID: 2368
		[CompilerGenerated]
		private readonly #6Pb #k;

		// Token: 0x04000941 RID: 2369
		[CompilerGenerated]
		private readonly #Anb #l;

		// Token: 0x04000942 RID: 2370
		[CompilerGenerated]
		private readonly RadObservableCollection<RadMenuItem> #m = new RadObservableCollection<RadMenuItem>();
	}
}
