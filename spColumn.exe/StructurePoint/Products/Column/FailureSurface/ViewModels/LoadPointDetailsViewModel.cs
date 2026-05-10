using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using #12e;
using #7hc;
using #9Ue;
using #gMe;
using #hye;
using #lH;
using #Mbb;
using #wdd;
using #Wse;
using #y6e;
using #Zjb;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Tabular.TelerikGrid;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.FailureSurface.ViewModels.DTO;
using StructurePoint.Products.Column.FailureSurface.Views;
using StructurePoint.Products.Column.Services.API;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.FailureSurface.ViewModels
{
	// Token: 0x02000412 RID: 1042
	internal sealed class LoadPointDetailsViewModel : #HH<ILoadPointDetailsWindow>, INotifyPropertyChanged, IViewModel<ILoadPointDetailsWindow>, IViewModel, #0gb
	{
		// Token: 0x06002513 RID: 9491 RVA: 0x000D2A9C File Offset: 0x000D0C9C
		public LoadPointDetailsViewModel(ICoreServices services, Lazy<ILoadPointDetailsWindow> view) : base(view, services)
		{
			this.#d = new DelegateCommand(new Action<object>(this.#5H), new Predicate<object>(this.#chb));
			this.#b = new RadObservableCollection<#5jb>();
			this.#c = new RadObservableCollection<#5jb>();
		}

		// Token: 0x17000C8F RID: 3215
		// (get) Token: 0x06002514 RID: 9492 RVA: 0x0002333C File Offset: 0x0002153C
		public RadObservableCollection<#5jb> LoadPointItems { get; }

		// Token: 0x17000C90 RID: 3216
		// (get) Token: 0x06002515 RID: 9493 RVA: 0x00023348 File Offset: 0x00021548
		public RadObservableCollection<#5jb> CapacityRatioItems { get; }

		// Token: 0x17000C91 RID: 3217
		// (get) Token: 0x06002516 RID: 9494 RVA: 0x00023354 File Offset: 0x00021554
		public DelegateCommand OkCommand { get; }

		// Token: 0x17000C92 RID: 3218
		// (get) Token: 0x06002517 RID: 9495 RVA: 0x00023360 File Offset: 0x00021560
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06002518 RID: 9496 RVA: 0x00023370 File Offset: 0x00021570
		protected override void #uh(ILoadPointDetailsWindow #Ee)
		{
			base.#uh(#Ee);
			#Ee.DataContext = this;
		}

		// Token: 0x06002519 RID: 9497 RVA: 0x0002338C File Offset: 0x0002158C
		public void #Ygb(#lte #Wdb, IList<GridDataRowCore> #Zgb, #Yjb #Lg)
		{
			if (#Wdb == null)
			{
				return;
			}
			this.#7gb(#Wdb);
			this.#ahb(#Wdb, #Zgb, #Lg);
			base.View.ShowDialog();
		}

		// Token: 0x0600251A RID: 9498 RVA: 0x000D2AEC File Offset: 0x000D0CEC
		public static GridDataRowCore #5W(#lte #Od, IList<GridDataRowCore> #Zgb, #Yjb #Lg)
		{
			LoadPointDetailsViewModel.#8Ub #8Ub = new LoadPointDetailsViewModel.#8Ub();
			#8Ub.#a = #Lg;
			#8Ub.#b = #Od;
			var source = #Zgb.Select(new Func<GridDataRowCore, <>f__AnonymousType6<GridDataRowCore, LoadPointRowMetadata>>(LoadPointDetailsViewModel.<>c.<>9.#izf)).ToList();
			var <>f__AnonymousType = source.FirstOrDefault(new Func<<>f__AnonymousType6<GridDataRowCore, LoadPointRowMetadata>, bool>(#8Ub.#25b));
			if (<>f__AnonymousType == null)
			{
				<>f__AnonymousType = source.FirstOrDefault(new Func<<>f__AnonymousType6<GridDataRowCore, LoadPointRowMetadata>, bool>(#8Ub.#35b));
			}
			if (<>f__AnonymousType == null)
			{
				return null;
			}
			return <>f__AnonymousType.Item;
		}

		// Token: 0x0600251B RID: 9499 RVA: 0x000D2B88 File Offset: 0x000D0D88
		internal static bool #3gb(double? #4gb, double? #5gb)
		{
			double? num = #4gb;
			double? num2;
			if (!false)
			{
				num2 = num;
			}
			double? num3 = #5gb;
			return (num2.GetValueOrDefault() == num3.GetValueOrDefault() & num2 != null == (num3 != null)) || (#4gb != null && #5gb != null && Math.Abs(#4gb.Value - #5gb.Value) <= 0.1);
		}

		// Token: 0x0600251C RID: 9500 RVA: 0x000D2C04 File Offset: 0x000D0E04
		private static bool #3gb(#lte #Od, #C6e #6gb, double? #4gb, double #5gb)
		{
			if (#6gb == #C6e.#a && #Od.Input.Options.ConsiderXAxis())
			{
				return LoadPointDetailsViewModel.#3gb(#4gb, new double?(#5gb));
			}
			return #6gb != #C6e.#b || !#Od.Input.Options.ConsiderYAxis() || LoadPointDetailsViewModel.#3gb(#4gb, new double?(#5gb));
		}

		// Token: 0x0600251D RID: 9501 RVA: 0x00009E6A File Offset: 0x0000806A
		private void #7gb(#lte #Od)
		{
		}

		// Token: 0x0600251E RID: 9502 RVA: 0x000D2C64 File Offset: 0x000D0E64
		private void #8gb(#lte #Od, LoadPointRowMetadata #3ab)
		{
			this.LoadPointItems.Add(new #5jb(Strings.StringPointNo, this.#qp(#3ab.Number), null));
			string #oT = #Od.Input.Options.IsCSA() ? Strings.StringPf : Strings.StringPu;
			string #oT2 = #Od.Input.Options.IsCSA() ? Strings.StringMfx : Strings.StringMux;
			string #oT3 = #Od.Input.Options.IsCSA() ? Strings.StringMfy : Strings.StringMuy;
			if (#Od.Input.Options.ActiveLoad == LoadType.Service)
			{
				this.LoadPointItems.Add(new #5jb(Strings.StringLoadNo, this.#qp(#3ab.LoadNumber), null));
				this.LoadPointItems.Add(new #5jb(Strings.StringCombination, this.#qp(#3ab.CombinationNumber), null));
				this.LoadPointItems.Add(new #5jb(Strings.StringLocation, this.#qp(#3ab.Location), null));
			}
			this.LoadPointItems.Add(new #5jb(#oT, this.#qp(#3ab.AxialLoad, NativeNumberFormat.F11_2, #Phc.#3hc(107361293)), #Od.GeneralInfo.UnitStringF));
			this.LoadPointItems.Add(new #5jb(#oT2, this.#qp(#3ab.MomentX, NativeNumberFormat.F11_2, #Phc.#3hc(107361293)), #Od.GeneralInfo.UnitStringM));
			this.LoadPointItems.Add(new #5jb(#oT3, this.#qp(#3ab.MomentY, NativeNumberFormat.F11_2, #Phc.#3hc(107361293)), #Od.GeneralInfo.UnitStringM));
			this.LoadPointItems.Add(new #5jb(Strings.StringCapacityRatio, this.#qp(#3ab.DisplayedCapacityRatio), null));
		}

		// Token: 0x0600251F RID: 9503 RVA: 0x000D2E48 File Offset: 0x000D1048
		private void #9gb(#lte #Od, LoadPointRowMetadata #3ab)
		{
			string text = #Od.Input.Options.IsACI() ? #Phc.#3hc(107361283) : #Phc.#3hc(107361288);
			string text2 = #Od.Input.Options.IsACI() ? #Phc.#3hc(107361301) : #Phc.#3hc(107361306);
			string text3 = #Od.Input.Options.IsACI() ? #Phc.#3hc(107361767) : #Phc.#3hc(107361772);
			CapacityRatioCalculation capacityRatioCalculation = #3ab.Calculation;
			LoadPointDrawingData loadPointDrawingData = #3ab.Parameters;
			Collection<#5jb> collection = this.CapacityRatioItems;
			string #oT = text;
			string #f;
			if (capacityRatioCalculation == null)
			{
				#f = string.Empty;
			}
			else
			{
				float? num = capacityRatioCalculation.PhiPn;
				#f = this.#qp((num != null) ? new double?((double)num.GetValueOrDefault()) : null, NativeNumberFormat.F11_2, #Phc.#3hc(107361293));
			}
			collection.Add(new #5jb(#oT, #f, #Od.GeneralInfo.UnitStringF));
			bool flag = #Od.Input.Options.SectionCapacityMethod == SectionCapacityMethodType.CriticalCapacity;
			if (capacityRatioCalculation != null && loadPointDrawingData != null)
			{
				if (!capacityRatioCalculation.Flags.HasFlag(#YNe.#b) && !capacityRatioCalculation.Flags.HasFlag(#YNe.#g) && !capacityRatioCalculation.Flags.HasFlag(#YNe.#h) && !loadPointDrawingData.Flags.HasFlag(#FVe.#f) && !loadPointDrawingData.Flags.HasFlag(#FVe.#g))
				{
					#u3e.#xif? #xif = loadPointDrawingData.MinMax;
					#u3e.#xif #xif2 = #u3e.#xif.#b;
					if (!(#xif.GetValueOrDefault() == #xif2 & #xif != null))
					{
						#xif = loadPointDrawingData.MinMax;
						#xif2 = #u3e.#xif.#c;
						if (!(#xif.GetValueOrDefault() == #xif2 & #xif != null) && string.IsNullOrWhiteSpace(#jye.#iye(capacityRatioCalculation.Flags)))
						{
							goto IL_265;
						}
					}
				}
				if (!flag)
				{
					goto IL_1F1;
				}
				IL_265:
				bool flag2 = #Od.Input.Options.SectionCapacityMethod == SectionCapacityMethodType.MomentCapacity;
				if (flag2)
				{
					if (#Od.Input.Options.ConsiderXAxis())
					{
						Collection<#5jb> collection2 = this.CapacityRatioItems;
						string #oT2 = text2;
						float? num = loadPointDrawingData.PhiMnx;
						collection2.Add(new #5jb(#oT2, this.#qp((num != null) ? new double?((double)num.GetValueOrDefault()) : null, NativeNumberFormat.F11_2, #Phc.#3hc(107361293)), #Od.GeneralInfo.UnitStringM));
					}
					if (#Od.Input.Options.ConsiderYAxis())
					{
						Collection<#5jb> collection3 = this.CapacityRatioItems;
						string #oT3 = text3;
						float? num = loadPointDrawingData.PhiMny;
						collection3.Add(new #5jb(#oT3, this.#qp((num != null) ? new double?((double)num.GetValueOrDefault()) : null, NativeNumberFormat.F11_2, #Phc.#3hc(107361293)), #Od.GeneralInfo.UnitStringM));
						return;
					}
					return;
				}
				else
				{
					if (#Od.Input.Options.ConsiderXAxis())
					{
						Collection<#5jb> collection4 = this.CapacityRatioItems;
						string #oT4 = text2;
						float? num = capacityRatioCalculation.PhiMnx;
						collection4.Add(new #5jb(#oT4, this.#qp((num != null) ? new double?((double)num.GetValueOrDefault()) : null, NativeNumberFormat.F11_2, #Phc.#3hc(107361293)), #Od.GeneralInfo.UnitStringM));
					}
					if (#Od.Input.Options.ConsiderYAxis())
					{
						Collection<#5jb> collection5 = this.CapacityRatioItems;
						string #oT5 = text3;
						float? num = capacityRatioCalculation.PhiMny;
						collection5.Add(new #5jb(#oT5, this.#qp((num != null) ? new double?((double)num.GetValueOrDefault()) : null, NativeNumberFormat.F11_2, #Phc.#3hc(107361293)), #Od.GeneralInfo.UnitStringM));
						return;
					}
					return;
				}
			}
			IL_1F1:
			if (#Od.Input.Options.ConsiderXAxis())
			{
				this.CapacityRatioItems.Add(new #5jb(text2, #Phc.#3hc(107361293), #Od.GeneralInfo.UnitStringM));
			}
			if (#Od.Input.Options.ConsiderYAxis())
			{
				this.CapacityRatioItems.Add(new #5jb(text3, #Phc.#3hc(107361293), #Od.GeneralInfo.UnitStringM));
				return;
			}
		}

		// Token: 0x06002520 RID: 9504 RVA: 0x000D32A0 File Offset: 0x000D14A0
		private void #ahb(#lte #Od, IList<GridDataRowCore> #Zgb, #Yjb #Lg)
		{
			this.LoadPointItems.Clear();
			this.CapacityRatioItems.Clear();
			GridDataRowCore gridDataRowCore = LoadPointDetailsViewModel.#5W(#Od, #Zgb, #Lg);
			LoadPointRowMetadata loadPointRowMetadata = ((gridDataRowCore != null) ? gridDataRowCore.Metadata : null) as LoadPointRowMetadata;
			if (loadPointRowMetadata == null)
			{
				return;
			}
			this.#8gb(#Od, loadPointRowMetadata);
			this.#9gb(#Od, loadPointRowMetadata);
		}

		// Token: 0x06002521 RID: 9505 RVA: 0x000D3300 File Offset: 0x000D1500
		private string #qp(int? #f)
		{
			if (#f == null)
			{
				return #Phc.#3hc(107361293);
			}
			return #f.Value.ToString(CultureInfo.InvariantCulture);
		}

		// Token: 0x06002522 RID: 9506 RVA: 0x000233BA File Offset: 0x000215BA
		private string #qp(double? #f, NativeNumberFormat #cA = NativeNumberFormat.F11_2, string #bhb = "---")
		{
			if (#f == null)
			{
				return #bhb;
			}
			return #ned.#qp(new float?((float)#f.Value), #cA, #Phc.#3hc(107381628)).Trim();
		}

		// Token: 0x06002523 RID: 9507 RVA: 0x000233F5 File Offset: 0x000215F5
		private string #qp(string #f)
		{
			if (string.IsNullOrWhiteSpace(#f))
			{
				return #Phc.#3hc(107361293);
			}
			return #f;
		}

		// Token: 0x06002524 RID: 9508 RVA: 0x00003375 File Offset: 0x00001575
		private bool #chb(object #Sb)
		{
			return true;
		}

		// Token: 0x06002525 RID: 9509 RVA: 0x00023417 File Offset: 0x00021617
		private void #5H(object #Sb)
		{
			base.View.Close();
		}

		// Token: 0x04000EBE RID: 3774
		private const string #a = "---";

		// Token: 0x04000EBF RID: 3775
		[CompilerGenerated]
		private readonly RadObservableCollection<#5jb> #b;

		// Token: 0x04000EC0 RID: 3776
		[CompilerGenerated]
		private readonly RadObservableCollection<#5jb> #c;

		// Token: 0x04000EC1 RID: 3777
		[CompilerGenerated]
		private readonly DelegateCommand #d;

		// Token: 0x02000414 RID: 1044
		[CompilerGenerated]
		private sealed class #8Ub
		{
			// Token: 0x0600252A RID: 9514 RVA: 0x000D3344 File Offset: 0x000D1544
			internal bool #25b(<>f__AnonymousType6<GridDataRowCore, LoadPointRowMetadata> #Rf)
			{
				if (#Rf.Metadata != null && #Rf.Metadata.Number != null)
				{
					int value = #Rf.Metadata.Number.Value;
					int? num = this.#a.Index;
					return value == num.GetValueOrDefault() & num != null;
				}
				return false;
			}

			// Token: 0x0600252B RID: 9515 RVA: 0x000D33AC File Offset: 0x000D15AC
			internal bool #35b(<>f__AnonymousType6<GridDataRowCore, LoadPointRowMetadata> #Rf)
			{
				return #Rf.Metadata != null && LoadPointDetailsViewModel.#3gb(#Rf.Metadata.AxialLoad, new double?(this.#a.AxialForce)) && LoadPointDetailsViewModel.#3gb(this.#b, #C6e.#a, #Rf.Metadata.MomentX, this.#a.MomentX) && LoadPointDetailsViewModel.#3gb(this.#b, #C6e.#b, #Rf.Metadata.MomentY, this.#a.MomentY);
			}

			// Token: 0x04000EC4 RID: 3780
			public #Yjb #a;

			// Token: 0x04000EC5 RID: 3781
			public #lte #b;
		}
	}
}
