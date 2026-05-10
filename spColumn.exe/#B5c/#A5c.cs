using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using #7hc;
using #8Cc;
using #cYd;
using #ezc;
using #Fmc;
using #IDc;
using #LQc;
using #N6c;
using #NWc;
using #o1d;
using #T0c;
using #UYd;
using #v1c;
using #Xic;
using Alphaleonis.Win32.Filesystem;
using StructurePoint.CoreAssets.DataExchange.CSV;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.DesktopControls.Grid;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.CoreAssets.GUI.Framework.Definitions;
using StructurePoint.CoreAssets.GUI.Framework.Model.Entities;
using StructurePoint.CoreAssets.GUI.SharedResources;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Infrastructure.Helpers;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Logger;

namespace #B5c
{
	// Token: 0x02000CCE RID: 3278
	[SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Temporary")]
	internal abstract class #A5c<#1Zb, #fx> : #CBc<!1>, #H5c<!0>, #G5c where #1Zb : class, INotifyPropertyChanged, INotifyPropertyChanging where #fx : class, #F5c
	{
		// Token: 0x06006B04 RID: 27396 RVA: 0x0019E600 File Offset: 0x0019C800
		[SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling")]
		protected #A5c(#GBc #2x, #fx #Ee, ILogger #3x) : base(#2x, #Ee, #3x)
		{
			#X0d.#V0d(#2x, #Phc.#3hc(107417812), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107430693));
			this.UndoManager = #2x.#vy<#bDc>();
			this.CommandFactory = #2x.#vy<ICommandFactory>();
			this.ErrorsHandlingService = #2x.#vy<#rBc>();
			this.DialogService = #2x.#vy<#8Sc>();
			this.FileSystemService = #2x.#vy<#v2c>();
			this.ResourcesHelper = #2x.#vy<IResourcesHelper>();
			this.SnappingProvider = #2x.#vy<#Qrc>();
			this.ModelEditorViewModel = #2x.#vy<#V0c>();
			this.LayoutService = #2x.#vy<#fTc>();
			this.NotificationService = #2x.#vy<#5Ic>();
			this.SettingsManager = #2x.#vy<#6Gc>();
			this.ProjectContext = #2x.#vy<#oW>();
			this.SelectedItems = new CustomObservableCollection<!0>();
			this.ImportCommand = this.CommandFactory.Create(new Action<object>(this.#u5c), new Predicate<object>(this.#w4c));
			this.ExportCommand = this.CommandFactory.Create(new Action<object>(this.#v5c), new Predicate<object>(this.#x4c));
			base.View.SetViewModel(this);
			this.IsFilteringEnabled = false;
			CommandManager.RegisterClassCommandBinding(#Ee.GetType(), new CommandBinding(ApplicationCommands.Copy, new ExecutedRoutedEventHandler(this.#84c)));
			CommandManager.RegisterClassCommandBinding(#Ee.GetType(), new CommandBinding(ApplicationCommands.Paste, new ExecutedRoutedEventHandler(this.#74c)));
			this.#j = true;
		}

		// Token: 0x17001D6D RID: 7533
		// (get) Token: 0x06006B05 RID: 27397 RVA: 0x000543F2 File Offset: 0x000525F2
		// (set) Token: 0x06006B06 RID: 27398 RVA: 0x000543FA File Offset: 0x000525FA
		private protected bool RowEditEndedWasCausedByUserCancellation { protected get; private set; }

		// Token: 0x17001D6E RID: 7534
		// (get) Token: 0x06006B07 RID: 27399 RVA: 0x00054403 File Offset: 0x00052603
		// (set) Token: 0x06006B08 RID: 27400 RVA: 0x0005440B File Offset: 0x0005260B
		private protected #6Gc SettingsManager { protected get; private set; }

		// Token: 0x17001D6F RID: 7535
		// (get) Token: 0x06006B09 RID: 27401 RVA: 0x00054414 File Offset: 0x00052614
		// (set) Token: 0x06006B0A RID: 27402 RVA: 0x0005441C File Offset: 0x0005261C
		public #oW ProjectContext { get; private set; }

		// Token: 0x17001D70 RID: 7536
		// (get) Token: 0x06006B0B RID: 27403 RVA: 0x00054425 File Offset: 0x00052625
		protected virtual #WWc MainModel
		{
			get
			{
				return this.ProjectContext.MainModel;
			}
		}

		// Token: 0x17001D71 RID: 7537
		// (get) Token: 0x06006B0C RID: 27404
		[SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
		protected abstract string[] OrderedColumnNames { get; }

		// Token: 0x17001D72 RID: 7538
		// (get) Token: 0x06006B0D RID: 27405
		[SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
		protected abstract string[] OrderedDataExchangeColumnNames { get; }

		// Token: 0x17001D73 RID: 7539
		// (get) Token: 0x06006B0E RID: 27406 RVA: 0x00054432 File Offset: 0x00052632
		// (set) Token: 0x06006B0F RID: 27407 RVA: 0x0005443A File Offset: 0x0005263A
		public CustomObservableCollection<#1Zb> SelectedItems { get; private set; }

		// Token: 0x17001D74 RID: 7540
		// (get) Token: 0x06006B10 RID: 27408 RVA: 0x00054443 File Offset: 0x00052643
		// (set) Token: 0x06006B11 RID: 27409 RVA: 0x0005444B File Offset: 0x0005264B
		private protected #1Zb CurrentEditRow { protected get; private set; }

		// Token: 0x17001D75 RID: 7541
		// (get) Token: 0x06006B12 RID: 27410 RVA: 0x00054454 File Offset: 0x00052654
		protected virtual IGridControl GridControl
		{
			get
			{
				return base.View.CurrentGridControl;
			}
		}

		// Token: 0x17001D76 RID: 7542
		// (get) Token: 0x06006B13 RID: 27411 RVA: 0x00054466 File Offset: 0x00052666
		// (set) Token: 0x06006B14 RID: 27412 RVA: 0x0005446E File Offset: 0x0005266E
		private protected #fTc LayoutService { protected get; private set; }

		// Token: 0x17001D77 RID: 7543
		// (get) Token: 0x06006B15 RID: 27413 RVA: 0x00054477 File Offset: 0x00052677
		// (set) Token: 0x06006B16 RID: 27414 RVA: 0x0019E78C File Offset: 0x0019C98C
		public #1Zb SelectedRow
		{
			get
			{
				return this.#e;
			}
			set
			{
				if (!false && (false || this.#e != value))
				{
					string propertyName = #Phc.#3hc(107430672);
					if (!false)
					{
						base.RaisePropertyChanging(propertyName);
					}
					this.#e = value;
					if (2 != 0)
					{
						string propertyName2 = #Phc.#3hc(107430672);
						if (3 != 0)
						{
							base.RaisePropertyChanged(propertyName2);
						}
					}
					if (-1 != 0)
					{
						this.#N4c();
					}
				}
			}
		}

		// Token: 0x17001D78 RID: 7544
		// (get) Token: 0x06006B17 RID: 27415 RVA: 0x0005447F File Offset: 0x0005267F
		// (set) Token: 0x06006B18 RID: 27416 RVA: 0x0019E7F8 File Offset: 0x0019C9F8
		public IGridControlColumn CurrentColumn
		{
			get
			{
				return this.#g;
			}
			set
			{
				for (;;)
				{
					if (this.#g == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107463745);
					if (5 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IL_19:
					if (3 != 0)
					{
						if (false)
						{
							continue;
						}
						this.#g = value;
						string propertyName2 = #Phc.#3hc(107463745);
						if (!false)
						{
							base.RaisePropertyChanged(propertyName2);
						}
					}
					IL_36:
					if (true)
					{
						break;
					}
					goto IL_19;
				}
			}
		}

		// Token: 0x17001D79 RID: 7545
		// (get) Token: 0x06006B19 RID: 27417 RVA: 0x00054487 File Offset: 0x00052687
		// (set) Token: 0x06006B1A RID: 27418 RVA: 0x0019E84C File Offset: 0x0019CA4C
		public #1Zb CurrentItem
		{
			get
			{
				return this.#h;
			}
			set
			{
				for (;;)
				{
					#1Zb #1Zb2;
					if (this.#h != value && !false)
					{
						#1Zb #1Zb = this.#h;
						if (!false)
						{
							#1Zb2 = #1Zb;
						}
						string propertyName = #Phc.#3hc(107463724);
						if (3 != 0)
						{
							base.RaisePropertyChanging(propertyName);
						}
						this.#h = value;
						goto IL_37;
					}
					IL_50:
					if (false)
					{
						continue;
					}
					if (!false)
					{
						break;
					}
					IL_37:
					!0 #x3c = #1Zb2;
					if (!false)
					{
						this.#w3c(#x3c, value);
					}
					string propertyName2 = #Phc.#3hc(107463724);
					if (false)
					{
						goto IL_50;
					}
					base.RaisePropertyChanged(propertyName2);
					goto IL_50;
				}
			}
		}

		// Token: 0x06006B1B RID: 27419 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #w3c(#1Zb #x3c, #1Zb #y3c)
		{
		}

		// Token: 0x17001D7A RID: 7546
		// (get) Token: 0x06006B1C RID: 27420 RVA: 0x0005448F File Offset: 0x0005268F
		// (set) Token: 0x06006B1D RID: 27421 RVA: 0x00054497 File Offset: 0x00052697
		public IDelegateCommand AddCommand { get; protected set; }

		// Token: 0x17001D7B RID: 7547
		// (get) Token: 0x06006B1E RID: 27422 RVA: 0x000544A0 File Offset: 0x000526A0
		// (set) Token: 0x06006B1F RID: 27423 RVA: 0x000544A8 File Offset: 0x000526A8
		public IDelegateCommand DeleteCommand { get; private set; }

		// Token: 0x17001D7C RID: 7548
		// (get) Token: 0x06006B20 RID: 27424 RVA: 0x000544B1 File Offset: 0x000526B1
		// (set) Token: 0x06006B21 RID: 27425 RVA: 0x000544B9 File Offset: 0x000526B9
		public IDelegateCommand DeleteAllCommand { get; private set; }

		// Token: 0x17001D7D RID: 7549
		// (get) Token: 0x06006B22 RID: 27426 RVA: 0x000544C2 File Offset: 0x000526C2
		// (set) Token: 0x06006B23 RID: 27427 RVA: 0x000544CA File Offset: 0x000526CA
		public IDelegateCommand ClearFiltersCommand { get; private set; }

		// Token: 0x17001D7E RID: 7550
		// (get) Token: 0x06006B24 RID: 27428 RVA: 0x000544D3 File Offset: 0x000526D3
		public virtual IEnumerable<#1Zb> Rows
		{
			get
			{
				return this.#f;
			}
		}

		// Token: 0x17001D7F RID: 7551
		// (get) Token: 0x06006B25 RID: 27429 RVA: 0x000544DB File Offset: 0x000526DB
		// (set) Token: 0x06006B26 RID: 27430 RVA: 0x000544E3 File Offset: 0x000526E3
		private protected virtual #bDc UndoManager { protected get; private set; }

		// Token: 0x17001D80 RID: 7552
		// (get) Token: 0x06006B27 RID: 27431 RVA: 0x000544EC File Offset: 0x000526EC
		// (set) Token: 0x06006B28 RID: 27432 RVA: 0x000544F4 File Offset: 0x000526F4
		public #5Ic NotificationService { get; private set; }

		// Token: 0x17001D81 RID: 7553
		// (get) Token: 0x06006B29 RID: 27433 RVA: 0x000544FD File Offset: 0x000526FD
		// (set) Token: 0x06006B2A RID: 27434 RVA: 0x00054505 File Offset: 0x00052705
		private protected ICommandFactory CommandFactory { protected get; private set; }

		// Token: 0x17001D82 RID: 7554
		// (get) Token: 0x06006B2B RID: 27435 RVA: 0x0005450E File Offset: 0x0005270E
		protected virtual IEnumerable<IGridControlColumn> Columns
		{
			get
			{
				return this.GridControl.Columns;
			}
		}

		// Token: 0x17001D83 RID: 7555
		// (get) Token: 0x06006B2C RID: 27436 RVA: 0x0005451B File Offset: 0x0005271B
		// (set) Token: 0x06006B2D RID: 27437 RVA: 0x00054523 File Offset: 0x00052723
		public #rBc ErrorsHandlingService { get; private set; }

		// Token: 0x17001D84 RID: 7556
		// (get) Token: 0x06006B2E RID: 27438 RVA: 0x0005452C File Offset: 0x0005272C
		// (set) Token: 0x06006B2F RID: 27439 RVA: 0x00054534 File Offset: 0x00052734
		public #8Sc DialogService { get; private set; }

		// Token: 0x17001D85 RID: 7557
		// (get) Token: 0x06006B30 RID: 27440 RVA: 0x0005453D File Offset: 0x0005273D
		// (set) Token: 0x06006B31 RID: 27441 RVA: 0x00054545 File Offset: 0x00052745
		public IDelegateCommand ImportCommand { get; private set; }

		// Token: 0x17001D86 RID: 7558
		// (get) Token: 0x06006B32 RID: 27442 RVA: 0x0005454E File Offset: 0x0005274E
		// (set) Token: 0x06006B33 RID: 27443 RVA: 0x00054556 File Offset: 0x00052756
		public IDelegateCommand ExportCommand { get; private set; }

		// Token: 0x17001D87 RID: 7559
		// (get) Token: 0x06006B34 RID: 27444 RVA: 0x0005455F File Offset: 0x0005275F
		// (set) Token: 0x06006B35 RID: 27445 RVA: 0x00054567 File Offset: 0x00052767
		private protected #v2c FileSystemService { protected get; private set; }

		// Token: 0x17001D88 RID: 7560
		// (get) Token: 0x06006B36 RID: 27446 RVA: 0x00054570 File Offset: 0x00052770
		// (set) Token: 0x06006B37 RID: 27447 RVA: 0x00054578 File Offset: 0x00052778
		private protected #V0c ModelEditorViewModel { protected get; private set; }

		// Token: 0x17001D89 RID: 7561
		// (get) Token: 0x06006B38 RID: 27448 RVA: 0x00054581 File Offset: 0x00052781
		// (set) Token: 0x06006B39 RID: 27449 RVA: 0x00054589 File Offset: 0x00052789
		private protected #Qrc SnappingProvider { protected get; private set; }

		// Token: 0x17001D8A RID: 7562
		// (get) Token: 0x06006B3A RID: 27450 RVA: 0x00054592 File Offset: 0x00052792
		// (set) Token: 0x06006B3B RID: 27451 RVA: 0x0005459A File Offset: 0x0005279A
		private protected IResourcesHelper ResourcesHelper { protected get; private set; }

		// Token: 0x17001D8B RID: 7563
		// (get) Token: 0x06006B3C RID: 27452 RVA: 0x000545A3 File Offset: 0x000527A3
		// (set) Token: 0x06006B3D RID: 27453 RVA: 0x000545AB File Offset: 0x000527AB
		public bool IsEditing { get; private set; }

		// Token: 0x17001D8C RID: 7564
		// (get) Token: 0x06006B3E RID: 27454 RVA: 0x000545B4 File Offset: 0x000527B4
		// (set) Token: 0x06006B3F RID: 27455 RVA: 0x000545BC File Offset: 0x000527BC
		public bool IsAdding { get; protected set; }

		// Token: 0x17001D8D RID: 7565
		// (get) Token: 0x06006B40 RID: 27456 RVA: 0x000545C5 File Offset: 0x000527C5
		// (set) Token: 0x06006B41 RID: 27457 RVA: 0x0019E8C8 File Offset: 0x0019CAC8
		public bool IsFilteringEnabled
		{
			get
			{
				return this.#i;
			}
			private set
			{
				if (this.IsFilteringEnabled != value)
				{
					string propertyName = #Phc.#3hc(107430143);
					if (!false)
					{
						base.RaisePropertyChanging(propertyName);
					}
					this.#i = value;
					if (8 != 0)
					{
						string propertyName2 = #Phc.#3hc(107430143);
						if (7 != 0)
						{
							base.RaisePropertyChanged(propertyName2);
						}
					}
					Expression<Func<bool>> expression = () => this.#S3c;
					if (-1 != 0)
					{
						base.RaisePropertyChanged<bool>(expression);
					}
				}
			}
		}

		// Token: 0x17001D8E RID: 7566
		// (get) Token: 0x06006B42 RID: 27458 RVA: 0x000545CD File Offset: 0x000527CD
		public bool IsReadOnly
		{
			get
			{
				return this.IsFilteringEnabled;
			}
		}

		// Token: 0x17001D8F RID: 7567
		// (get) Token: 0x06006B43 RID: 27459 RVA: 0x000545D5 File Offset: 0x000527D5
		// (set) Token: 0x06006B44 RID: 27460 RVA: 0x000545DD File Offset: 0x000527DD
		public virtual bool UseUndoManager
		{
			get
			{
				return this.#j;
			}
			protected set
			{
				this.#j = value;
			}
		}

		// Token: 0x06006B45 RID: 27461 RVA: 0x000545E6 File Offset: 0x000527E6
		public void #T3c()
		{
			base.View.CurrentGridControl.SetFocusOnControl();
		}

		// Token: 0x06006B46 RID: 27462 RVA: 0x00009E6A File Offset: 0x0000806A
		[SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
		[SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "message", Justification = "Private debug write method.")]
		[Conditional("DEBUG")]
		protected void #U3c(string #5)
		{
		}

		// Token: 0x06006B47 RID: 27463
		protected abstract IReadOnlyList<IGridControlColumn> #V3c();

		// Token: 0x06006B48 RID: 27464
		protected abstract #EBc #W3c(string #X3c, object #f, CultureInfo #Y3c, #1Zb #MB);

		// Token: 0x06006B49 RID: 27465 RVA: 0x0019E958 File Offset: 0x0019CB58
		protected virtual string #Z3c(#1Zb #uI)
		{
			List<string>.Enumerator enumerator = this.OrderedColumnNames.ToList<string>().GetEnumerator();
			List<string>.Enumerator enumerator2;
			if (true)
			{
				enumerator2 = enumerator;
				goto IL_14;
			}
			try
			{
				#EBc #EBc;
				for (;;)
				{
					IL_14:
					if (true)
					{
						goto IL_63;
					}
					goto IL_24;
					IL_49:
					if (5 == 0)
					{
						continue;
					}
					if (#EBc != null && #EBc.ErrorMessage != null)
					{
						break;
					}
					goto IL_63;
					IL_24:
					string text;
					object obj2;
					if (2 != 0)
					{
						object obj = ReflectionHelper.#E(#uI, text);
						if (!false)
						{
							obj2 = obj;
						}
					}
					#EBc #EBc2 = this.#W3c(text, obj2, CultureInfo.CurrentCulture, #uI);
					if (6 == 0)
					{
						goto IL_49;
					}
					#EBc = #EBc2;
					goto IL_49;
					IL_63:
					if (false)
					{
						goto IL_49;
					}
					if (!enumerator2.MoveNext())
					{
						goto Block_8;
					}
					string text2 = enumerator2.Current;
					if (6 == 0)
					{
						goto IL_24;
					}
					text = text2;
					goto IL_24;
				}
				string text3 = #EBc.ErrorMessage;
				string result;
				if (8 != 0)
				{
					result = text3;
				}
				return result;
				Block_8:;
			}
			finally
			{
				((IDisposable)enumerator2).Dispose();
			}
			return null;
		}

		// Token: 0x06006B4A RID: 27466
		protected abstract CSVRow #03c(#1Zb #uI);

		// Token: 0x06006B4B RID: 27467 RVA: 0x000545FE File Offset: 0x000527FE
		public void #13c(#I5c #uI)
		{
			!0 #uI2 = (!0)((object)#uI);
			if (2 != 0)
			{
				this.#14c(#uI2);
			}
		}

		// Token: 0x06006B4C RID: 27468 RVA: 0x0019EA0C File Offset: 0x0019CC0C
		public void #23c(IEnumerable<#I5c> #33c)
		{
			string #R0d = #Phc.#3hc(107430086);
			StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework;
			string #Qic = #Phc.#3hc(107430101);
			if (5 != 0)
			{
				#X0d.#V0d(#33c, #R0d, #x6c, #Qic);
			}
			for (;;)
			{
				List<#I5c> list2;
				if (!false)
				{
					List<#I5c> list = #33c.ToList<#I5c>();
					if (false)
					{
						goto IL_2B;
					}
					list2 = list;
					goto IL_2B;
				}
				IL_39:
				if (!false)
				{
					if (true)
					{
						break;
					}
					continue;
				}
				IL_2B:
				IEnumerable<#I5c> #33c2 = list2;
				#I5c #43c = list2.FirstOrDefault<#I5c>();
				if (false)
				{
					goto IL_39;
				}
				this.#23c(#33c2, #43c);
				goto IL_39;
			}
		}

		// Token: 0x06006B4D RID: 27469 RVA: 0x00054613 File Offset: 0x00052813
		public void #iLc()
		{
			IGridControl gridControl = this.GridControl;
			if (!false)
			{
				gridControl.ClearSelection();
			}
		}

		// Token: 0x06006B4E RID: 27470 RVA: 0x0019EA6C File Offset: 0x0019CC6C
		public void #23c(IEnumerable<#I5c> #33c, #I5c #43c)
		{
			#A5c<#1Zb, #fx>.#ZWb #ZWb = new #A5c<!0, !1>.#ZWb();
			#A5c<#1Zb, #fx>.#ZWb #ZWb2;
			if (8 != 0)
			{
				#ZWb2 = #ZWb;
			}
			do
			{
				#ZWb2.#a = this;
			}
			while (7 == 0);
			#ZWb2.#b = #33c;
			#ZWb2.#c = #43c;
			do
			{
				object #Rf = #ZWb2.#b;
				string #R0d = #Phc.#3hc(107430086);
				StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework;
				string #Qic = #Phc.#3hc(107430101);
				if (4 != 0)
				{
					#X0d.#V0d(#Rf, #R0d, #x6c, #Qic);
				}
				IGridControl gridControl = this.GridControl;
				object dataItem = #ZWb2.#c;
				Action finishedCallback = new Action(#ZWb2.#6bd);
				Action failedCallback = new Action(#ZWb2.#7bd);
				if (8 != 0)
				{
					gridControl.ScrollIntoViewAsync(dataItem, finishedCallback, failedCallback);
				}
			}
			while (!true);
		}

		// Token: 0x06006B4F RID: 27471 RVA: 0x0019EAFC File Offset: 0x0019CCFC
		public void #YAb()
		{
			if (this.GridControl.IsReadOnly)
			{
				return;
			}
			IGridControl gridControl = this.GridControl;
			bool isReadOnly = true;
			if (!false)
			{
				gridControl.IsReadOnly = isReadOnly;
			}
			EventArgs empty = EventArgs.Empty;
			if (!false)
			{
				this.#F4c(empty);
			}
			IGridControl gridControl2 = this.GridControl;
			bool isReadOnly2 = false;
			if (4 != 0)
			{
				gridControl2.IsReadOnly = isReadOnly2;
			}
		}

		// Token: 0x06006B50 RID: 27472 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #53c(string #em)
		{
		}

		// Token: 0x06006B51 RID: 27473 RVA: 0x0019EB50 File Offset: 0x0019CD50
		public virtual void #eb()
		{
			IGridControl gridControl = this.GridControl;
			EventHandler<GridControlRowValidatingEventArgs> value = new EventHandler<GridControlRowValidatingEventArgs>(this.#94c);
			if (true)
			{
				gridControl.OnRowValidating += value;
			}
			IGridControl gridControl2 = this.GridControl;
			EventHandler<GridControlCellValidatingEventArgs> value2 = new EventHandler<GridControlCellValidatingEventArgs>(this.#a5c);
			if (6 != 0)
			{
				gridControl2.OnCellValidating += value2;
			}
			IGridControl gridControl3 = this.GridControl;
			EventHandler value3 = new EventHandler(this.#g5c);
			if (5 != 0)
			{
				gridControl3.OnEditCanceled += value3;
			}
			IGridControl gridControl4 = this.GridControl;
			EventHandler<GridControlRowEditEndedEventArgs> value4 = new EventHandler<GridControlRowEditEndedEventArgs>(this.#h5c);
			if (!false)
			{
				gridControl4.OnRowEditEnded += value4;
			}
			IGridControl gridControl5 = this.GridControl;
			EventHandler<GridControlBeginningEditEventArgs> value5 = new EventHandler<GridControlBeginningEditEventArgs>(this.#f5c);
			if (!false)
			{
				gridControl5.OnEditBeginning += value5;
			}
			List<IGridControlColumn> list2;
			for (;;)
			{
				IL_82:
				IGridControl gridControl6 = this.GridControl;
				EventHandler value6 = new EventHandler(this.#i5c);
				if (!false)
				{
					gridControl6.OnInsertRequested += value6;
				}
				this.GridControl.OnDeleteRequested += this.#j5c;
				this.GridControl.OnSelectionChanged += this.#k5c;
				this.GridControl.OnRowValidated += this.#c5c;
				this.GridControl.OnCellValidated += this.#b5c;
				this.GridControl.OnChangeRowIndexRequested += this.#l5c;
				this.GridControl.OnFiltersStateChanged += this.#m5c;
				this.#f = this.#63c();
				this.#f.CollectionChanged -= this.#d5c;
				this.#f.CollectionChanging -= this.#e5c;
				this.#f.CollectionChanged += this.#d5c;
				this.#f.CollectionChanging += this.#e5c;
				this.#s5c();
				this.AddCommand = this.CommandFactory.Create(new Action<object>(this.#n4c), new Predicate<object>(this.#o4c));
				this.DeleteCommand = this.CommandFactory.Create(new Action<object>(this.#p4c), new Predicate<object>(this.#u4c));
				this.DeleteAllCommand = this.CommandFactory.Create(new Action<object>(this.#q4c), new Predicate<object>(this.#v4c));
				this.ClearFiltersCommand = this.CommandFactory.Create(new Action<object>(this.#s4c), new Predicate<object>(this.#t4c));
				List<IGridControlColumn> list = this.#V3c().ToList<IGridControlColumn>();
				list2 = new List<IGridControlColumn>(list.Count);
				string[] array = this.OrderedColumnNames;
				for (int i = 0; i < array.Length; i++)
				{
					#A5c<#1Zb, #fx>.#acd #acd = new #A5c<!0, !1>.#acd();
					#acd.#a = array[i];
					IGridControlColumn item = list.First(new Func<IGridControlColumn, bool>(#acd.#8bd));
					if (5 == 0)
					{
						goto IL_82;
					}
					list2.Add(item);
				}
				break;
			}
			this.GridControl.AddColumns(list2);
		}

		// Token: 0x06006B52 RID: 27474
		[SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
		protected abstract #k8c<#1Zb> #63c();

		// Token: 0x06006B53 RID: 27475
		protected abstract #1Zb #73c();

		// Token: 0x06006B54 RID: 27476 RVA: 0x0001233F File Offset: 0x0001053F
		protected virtual string #83c(ShapeDataModel #XDc)
		{
			return null;
		}

		// Token: 0x06006B55 RID: 27477 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #93c(ShapeDataModel #XDc, string #oT)
		{
		}

		// Token: 0x06006B56 RID: 27478 RVA: 0x0001233F File Offset: 0x0001053F
		protected virtual string #83c(NodeModel #SNc)
		{
			return null;
		}

		// Token: 0x06006B57 RID: 27479 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #93c(NodeModel #SNc, string #oT)
		{
		}

		// Token: 0x06006B58 RID: 27480
		protected abstract #1Zb #a4c(IList<#1Zb> #b4c, IList<CSVCell> #c4c, IList<string> #2kc, int #d4c, #3Hc #IK);

		// Token: 0x06006B59 RID: 27481
		protected abstract void #e4c(#1Zb #uI);

		// Token: 0x06006B5A RID: 27482 RVA: 0x00054626 File Offset: 0x00052826
		protected virtual void #e4c(#1Zb #uI, bool #f4c)
		{
			if (!false)
			{
				this.#e4c(#uI);
			}
		}

		// Token: 0x06006B5B RID: 27483 RVA: 0x0019EE48 File Offset: 0x0019D048
		protected virtual void #g4c(IEnumerable<#1Zb> #h4c)
		{
			if (#h4c == null)
			{
				return;
			}
			IEnumerator<#1Zb> enumerator = #h4c.GetEnumerator();
			IEnumerator<#1Zb> enumerator2;
			if (-1 != 0)
			{
				enumerator2 = enumerator;
			}
			try
			{
				for (;;)
				{
					#1Zb #1Zb2;
					if (!false)
					{
						if (!enumerator2.MoveNext())
						{
							break;
						}
						#1Zb #1Zb = enumerator2.Current;
						if (4 != 0)
						{
							#1Zb2 = #1Zb;
						}
					}
					!0 #uI = #1Zb2;
					if (2 != 0)
					{
						this.#e4c(#uI);
					}
				}
			}
			finally
			{
				if (4 != 0 && (false || enumerator2 != null))
				{
					enumerator2.Dispose();
				}
			}
		}

		// Token: 0x06006B5C RID: 27484
		protected abstract void #i4c(#1Zb #uI);

		// Token: 0x06006B5D RID: 27485
		protected abstract bool #j4c(IList<#1Zb> #k4c);

		// Token: 0x06006B5E RID: 27486 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #l4c(#1Zb #kD)
		{
		}

		// Token: 0x06006B5F RID: 27487 RVA: 0x00054636 File Offset: 0x00052836
		[SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
		protected virtual IGridControlColumn #m4c()
		{
			return this.Columns.FirstOrDefault<IGridControlColumn>();
		}

		// Token: 0x06006B60 RID: 27488 RVA: 0x0019EEB0 File Offset: 0x0019D0B0
		protected virtual void #n4c(object #Sb)
		{
			if (!false)
			{
				#A5c<#1Zb, #fx>.#ecd #ecd = new #A5c<!0, !1>.#ecd();
				#A5c<#1Zb, #fx>.#ecd #ecd2;
				if (4 != 0)
				{
					#ecd2 = #ecd;
				}
				#ecd2.#b = this;
				if (2 != 0)
				{
					#ecd2.#a = this.#73c();
					if (#ecd2.#a == null)
					{
						return;
					}
					if (this.UseUndoManager)
					{
						if (false)
						{
							goto IL_B7;
						}
						#bDc #bDc = this.UndoManager;
						if (!false)
						{
							#bDc.#uCc();
						}
						#bDc #bDc2 = this.UndoManager;
						bool flag = false;
						if (!false)
						{
							#bDc2.IsEnabled = flag;
						}
					}
					bool flag2 = true;
					if (!false)
					{
						this.IsAdding = flag2;
					}
					!0 #kD = #ecd2.#a;
					if (6 != 0)
					{
						this.#l4c(#kD);
					}
				}
				!0 #uI = #ecd2.#a;
				bool #f4c = true;
				if (!false)
				{
					this.#e4c(#uI, #f4c);
				}
				#1Zb #1Zb = this.Rows.FirstOrDefault(new Func<!0, bool>(#ecd2.#bcd));
				#A5c<!0, !1>.#ecd #ecd3 = #ecd2;
				#1Zb #1Zb2;
				if ((#1Zb2 = #1Zb) == null)
				{
					#1Zb2 = this.Rows.Last<#1Zb>();
				}
				#ecd3.#a = #1Zb2;
				IL_B7:
				this.#ljb(#ecd2.#a);
				this.CurrentColumn = this.#m4c();
				this.GridControl.ScrollIntoView(#ecd2.#a, this.CurrentColumn, new Action(#ecd2.#ccd));
				return;
			}
		}

		// Token: 0x06006B61 RID: 27489 RVA: 0x00054643 File Offset: 0x00052843
		protected virtual bool #o4c(object #Sb)
		{
			return !this.IsEditing && !this.IsFilteringEnabled;
		}

		// Token: 0x06006B62 RID: 27490 RVA: 0x0019EFEC File Offset: 0x0019D1EC
		protected virtual void #p4c(object #Sb)
		{
			List<#1Zb> list2;
			if (!false)
			{
				List<#1Zb> list = this.SelectedItems.ToList<#1Zb>();
				if (5 == 0)
				{
					goto IL_15;
				}
				list2 = list;
				goto IL_15;
			}
			for (;;)
			{
				IL_2B:
				#1Zb #uI;
				#1Zb #1Zb3;
				if (-1 != 0)
				{
					IGridControl gridControl = this.GridControl;
					if (!false)
					{
						gridControl.CancelEdit();
					}
					#1Zb #1Zb = list2.OrderBy(new Func<!0, int>(this.#y5c)).First<#1Zb>();
					if (!false)
					{
						#uI = #1Zb;
					}
					#1Zb #1Zb2 = list2.OrderBy(new Func<!0, int>(this.#z5c)).Last<#1Zb>();
					if (!false)
					{
						#1Zb3 = #1Zb2;
					}
				}
				if (#1Zb3 == null)
				{
					goto IL_EF;
				}
				if (4 == 0)
				{
					goto IL_15;
				}
				!0 !;
				if ((! = this.#O4c(#1Zb3)) == null)
				{
					! = this.#LB(#uI);
				}
				#1Zb #1Zb4;
				if (6 != 0)
				{
					#1Zb4 = !;
				}
				if (!this.#j4c(list2))
				{
					break;
				}
				#1Zb #uI2;
				if ((#uI2 = #1Zb4) == null)
				{
					#uI2 = this.Rows.FirstOrDefault<#1Zb>();
				}
				if (!false)
				{
					this.#14c(#uI2);
				}
				this.CurrentColumn = this.Columns.FirstOrDefault<IGridControlColumn>();
				if (true)
				{
					goto Block_9;
				}
			}
			return;
			Block_9:
			this.CurrentEditRow = default(!0);
			this.#r4c();
			IL_EF:
			this.#N4c();
			return;
			IL_15:
			if (!this.#f.Any<#1Zb>() || !list2.Any<#1Zb>())
			{
				return;
			}
			goto IL_2B;
		}

		// Token: 0x06006B63 RID: 27491 RVA: 0x0019F118 File Offset: 0x0019D318
		protected virtual void #q4c(object #Sb)
		{
			if (!this.#f.Any<#1Zb>())
			{
				return;
			}
			IGridControl gridControl = this.GridControl;
			if (!false)
			{
				gridControl.CancelEdit();
			}
			CustomObservableCollection<#1Zb> customObservableCollection = this.#f as CustomObservableCollection<!0>;
			CustomObservableCollection<#1Zb> customObservableCollection2;
			if (4 != 0)
			{
				customObservableCollection2 = customObservableCollection;
			}
			object obj = customObservableCollection2;
			string #wy = #Phc.#3hc(107377558);
			string #Qic = #Phc.#3hc(107430016);
			StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUI;
			if (7 != 0)
			{
				obj.#kYd(#wy, #Qic, #x6c);
			}
			if (!this.#j4c(customObservableCollection2))
			{
				return;
			}
			!0 ! = default(!0);
			if (-1 != 0)
			{
				this.CurrentEditRow = !;
			}
			if (true)
			{
				this.#r4c();
			}
			if (!false)
			{
				this.#N4c();
			}
		}

		// Token: 0x06006B64 RID: 27492 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #r4c()
		{
		}

		// Token: 0x06006B65 RID: 27493 RVA: 0x00054658 File Offset: 0x00052858
		protected virtual void #s4c(object #Sb)
		{
			IGridControl gridControl = this.GridControl;
			if (!false)
			{
				gridControl.ClearFilters();
			}
		}

		// Token: 0x06006B66 RID: 27494 RVA: 0x000545CD File Offset: 0x000527CD
		protected virtual bool #t4c(object #Sb)
		{
			return this.IsFilteringEnabled;
		}

		// Token: 0x06006B67 RID: 27495 RVA: 0x0005466B File Offset: 0x0005286B
		protected virtual bool #u4c(object #Sb)
		{
			return (!true || false || !this.IsEditing || false) && this.SelectedRow != null;
		}

		// Token: 0x06006B68 RID: 27496 RVA: 0x0005468E File Offset: 0x0005288E
		protected virtual bool #v4c(object #Sb)
		{
			int result;
			for (;;)
			{
				bool flag = this.IsEditing;
				for (;;)
				{
					if (flag)
					{
						goto IL_31;
					}
					if (8 == 0)
					{
						break;
					}
					if (this.GridControl.CurrentItemsInView == null)
					{
						goto IL_31;
					}
					result = ((flag = this.GridControl.CurrentItemsInView.OfType<#1Zb>().Any<#1Zb>()) ? 1 : 0);
					IL_2D:
					if (!false)
					{
						return result != 0;
					}
					continue;
					IL_31:
					bool flag2 = flag = ((result = 0) != 0);
					if (!flag2)
					{
						return flag2;
					}
					goto IL_2D;
				}
			}
			return result != 0;
		}

		// Token: 0x06006B69 RID: 27497 RVA: 0x00054643 File Offset: 0x00052843
		protected virtual bool #w4c(object #Sb)
		{
			return !this.IsEditing && !this.IsFilteringEnabled;
		}

		// Token: 0x06006B6A RID: 27498 RVA: 0x0005468E File Offset: 0x0005288E
		protected virtual bool #x4c(object #Sb)
		{
			int result;
			for (;;)
			{
				bool flag = this.IsEditing;
				for (;;)
				{
					if (flag)
					{
						goto IL_31;
					}
					if (8 == 0)
					{
						break;
					}
					if (this.GridControl.CurrentItemsInView == null)
					{
						goto IL_31;
					}
					result = ((flag = this.GridControl.CurrentItemsInView.OfType<#1Zb>().Any<#1Zb>()) ? 1 : 0);
					IL_2D:
					if (!false)
					{
						return result != 0;
					}
					continue;
					IL_31:
					bool flag2 = flag = ((result = 0) != 0);
					if (!flag2)
					{
						return flag2;
					}
					goto IL_2D;
				}
			}
			return result != 0;
		}

		// Token: 0x06006B6B RID: 27499 RVA: 0x0019F1B4 File Offset: 0x0019D3B4
		protected virtual void #y4c(#1Zb #uI, GridControlRowValidatingEventArgs #HA)
		{
			if (!true)
			{
				goto IL_1E;
			}
			string text = this.#Z3c(#uI);
			string text2;
			if (!false)
			{
				text2 = text;
			}
			IL_0E:
			while (#HA != null)
			{
				if (7 != 0)
				{
					if (text2 == null)
					{
						break;
					}
					bool isValid = false;
					if (false)
					{
						goto IL_1E;
					}
					#HA.IsValid = isValid;
					goto IL_1E;
				}
			}
			goto IL_31;
			IL_1E:
			string currentColumnUniqueName = #HA.CurrentColumnUniqueName;
			string text3;
			if (!false)
			{
				text3 = currentColumnUniqueName;
			}
			string propertyName = text3;
			string errorMessage = text2;
			if (!false)
			{
				#HA.AddValidationResult(propertyName, errorMessage);
			}
			IL_31:
			if (!false)
			{
				return;
			}
			goto IL_0E;
		}

		// Token: 0x06006B6C RID: 27500 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #z4c(EventArgs #HA)
		{
		}

		// Token: 0x06006B6D RID: 27501 RVA: 0x0019F20C File Offset: 0x0019D40C
		protected virtual void #A4c(#1Zb #uI, string #X3c, GridControlCellValidatingEventArgs #HA)
		{
			object #Rf = #uI;
			string #R0d = #Phc.#3hc(107361131);
			StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUI;
			string #Qic = #Phc.#3hc(107429963);
			if (!false)
			{
				#X0d.#V0d(#Rf, #R0d, #x6c, #Qic);
			}
			if (!false)
			{
				if (false)
				{
					goto IL_A3;
				}
				string #R0d2 = #Phc.#3hc(107429942);
				StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c2 = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUI;
				string #Qic2 = #Phc.#3hc(107429893);
				if (false)
				{
					goto IL_48;
				}
				#X0d.#V0d(#X3c, #R0d2, #x6c2, #Qic2);
				goto IL_48;
			}
			IL_86:
			#EBc #EBc;
			while (#EBc != null)
			{
				if (3 == 0)
				{
					goto IL_48;
				}
				if (6 != 0)
				{
					if (#EBc.IsValid)
					{
						break;
					}
					bool isValid = #EBc.IsValid;
					if (!true)
					{
						goto IL_A3;
					}
					#HA.IsValid = isValid;
					goto IL_A3;
				}
			}
			return;
			IL_48:
			string #R0d3 = #Phc.#3hc(107430384);
			StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c3 = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUI;
			string #Qic3 = #Phc.#3hc(107430339);
			if (!false)
			{
				#X0d.#V0d(#HA, #R0d3, #x6c3, #Qic3);
			}
			#EBc #EBc2 = this.#W3c(#X3c, #HA.NewValue, CultureInfo.CurrentCulture, (!0)((object)#HA.Row));
			if (!true)
			{
				goto IL_86;
			}
			#EBc = #EBc2;
			goto IL_86;
			IL_A3:
			string errorMessage = #EBc.ErrorMessage;
			if (true)
			{
				#HA.ErrorMessage = errorMessage;
			}
		}

		// Token: 0x06006B6E RID: 27502 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #B4c(EventArgs #HA)
		{
		}

		// Token: 0x06006B6F RID: 27503 RVA: 0x000546C5 File Offset: 0x000528C5
		protected virtual void #C4c()
		{
			if (6 != 0)
			{
				this.#t5c();
			}
		}

		// Token: 0x06006B70 RID: 27504 RVA: 0x000546D3 File Offset: 0x000528D3
		protected virtual void #D4c(NotifyCollectionChangedEventArgs #He)
		{
			if (!false)
			{
				this.#N4c();
			}
			IGridControl gridControl = this.GridControl;
			if (2 != 0)
			{
				gridControl.HandleCollectionChanged();
			}
			if (!false)
			{
				this.#s5c();
			}
		}

		// Token: 0x06006B71 RID: 27505 RVA: 0x0019F2F4 File Offset: 0x0019D4F4
		protected virtual void #E4c(GridControlBeginningEditEventArgs #HA)
		{
			if (!false)
			{
				string #R0d = #Phc.#3hc(107430384);
				StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUI;
				string #Qic = #Phc.#3hc(107430286);
				if (3 != 0)
				{
					#X0d.#V0d(#HA, #R0d, #x6c, #Qic);
				}
			}
			bool flag2;
			bool flag = flag2 = this.IsEditing;
			if (!false)
			{
				if (flag)
				{
					goto IL_6C;
				}
				flag2 = this.IsAdding;
			}
			if (!flag2 && this.UseUndoManager)
			{
				if (7 == 0)
				{
					goto IL_6C;
				}
				#bDc #bDc = this.UndoManager;
				if (6 != 0)
				{
					#bDc.#uCc();
				}
				#bDc #bDc2 = this.UndoManager;
				bool flag3 = false;
				if (!false)
				{
					#bDc2.IsEnabled = flag3;
				}
			}
			!0 ! = (!0)((object)#HA.CurrentRowItem);
			if (true)
			{
				this.CurrentEditRow = !;
			}
			bool flag4 = true;
			if (!false)
			{
				this.IsEditing = flag4;
			}
			IL_6C:
			if (6 != 0)
			{
				this.#N4c();
			}
		}

		// Token: 0x06006B72 RID: 27506 RVA: 0x0019F39C File Offset: 0x0019D59C
		protected virtual void #F4c(EventArgs #HA)
		{
			if ((this.UseUndoManager && this.UndoManager.CanPushMementoActions) || !this.IsEditing)
			{
				return;
			}
			if (this.UseUndoManager)
			{
				if (false)
				{
					goto IL_A1;
				}
				#bDc #bDc = this.UndoManager;
				if (6 != 0)
				{
					#bDc.#wCc();
				}
			}
			#1Zb #1Zb = this.CurrentEditRow;
			#1Zb #1Zb2;
			if (-1 != 0)
			{
				#1Zb2 = #1Zb;
			}
			bool flag = this.IsAdding && #1Zb2 != null;
			bool flag2;
			if (!false)
			{
				flag2 = flag;
				goto IL_5E;
			}
			try
			{
				do
				{
					IL_5E:
					bool flag3 = true;
					if (2 != 0)
					{
						this.RowEditEndedWasCausedByUserCancellation = flag3;
					}
					IGridControl gridControl = this.GridControl;
					if (7 != 0)
					{
						gridControl.CancelEdit();
					}
				}
				while (3 == 0);
			}
			finally
			{
				if (!false)
				{
					this.RowEditEndedWasCausedByUserCancellation = false;
				}
			}
			if (!this.UseUndoManager)
			{
				goto IL_A1;
			}
			IL_95:
			#bDc #bDc2 = this.UndoManager;
			bool flag4 = false;
			if (4 != 0)
			{
				#bDc2.IsEnabled = flag4;
			}
			IL_A1:
			if (flag2)
			{
				this.#i4c(#1Zb2);
				this.#14c(this.Rows.LastOrDefault<#1Zb>());
			}
			else
			{
				this.#14c(#1Zb2);
			}
			if (this.UseUndoManager)
			{
				this.UndoManager.IsEnabled = true;
				if (false)
				{
					goto IL_95;
				}
				this.UndoManager.#vCc();
			}
			this.#N4c();
		}

		// Token: 0x06006B73 RID: 27507 RVA: 0x0019F4C4 File Offset: 0x0019D6C4
		protected virtual void #G4c(GridControlRowEditEndedEventArgs #HA)
		{
			string #R0d = #Phc.#3hc(107430384);
			StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUI;
			string #Qic = #Phc.#3hc(107430265);
			if (!false)
			{
				#X0d.#V0d(#HA, #R0d, #x6c, #Qic);
			}
			bool flag = false;
			bool flag2;
			if (!false)
			{
				flag2 = flag;
			}
			for (;;)
			{
				if (#HA.NewData == null || #HA.OldValues == null)
				{
					goto IL_B4;
				}
				int num;
				bool flag3 = (num = (this.IsAdding ? 1 : 0)) != 0;
				if (!true)
				{
					goto IL_BD;
				}
				if (flag3)
				{
					goto IL_B4;
				}
				if (this.UseUndoManager)
				{
					#bDc #bDc = this.UndoManager;
					bool flag4 = true;
					if (3 != 0)
					{
						#bDc.IsEnabled = flag4;
					}
				}
				if (!this.#e3c((!0)((object)#HA.NewData), #HA.OldValues))
				{
					if (this.UseUndoManager)
					{
						#bDc #bDc2 = this.UndoManager;
						if (true)
						{
							#bDc2.#wCc();
						}
						goto IL_9F;
					}
					goto IL_9F;
				}
				else
				{
					if (4 != 0)
					{
						this.#H4c(#HA);
					}
					bool flag5 = true;
					if (2 == 0)
					{
						goto IL_9F;
					}
					flag2 = flag5;
					goto IL_9F;
				}
				IL_E0:
				bool flag7;
				bool flag6 = flag7 = flag2;
				if (false)
				{
					goto IL_C7;
				}
				if (flag6)
				{
					this.#r4c();
				}
				if (!false)
				{
					break;
				}
				continue;
				IL_9F:
				if (this.UseUndoManager)
				{
					this.UndoManager.#vCc();
					goto IL_E0;
				}
				goto IL_E0;
				IL_B4:
				if (this.IsAdding)
				{
					num = 1;
					goto IL_BD;
				}
				goto IL_E0;
				IL_C7:
				if (flag7)
				{
					this.UndoManager.IsEnabled = true;
					this.UndoManager.#vCc();
					goto IL_E0;
				}
				goto IL_E0;
				IL_BD:
				flag2 = (num != 0);
				if (!false)
				{
					flag7 = this.UseUndoManager;
					goto IL_C7;
				}
				goto IL_9F;
			}
			this.#r5c();
			if (this.RowEditEndedWasCausedByUserCancellation)
			{
				#HA.UserDefinedErrors.Clear();
			}
			this.#N4c();
		}

		// Token: 0x06006B74 RID: 27508 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #H4c(GridControlRowEditEndedEventArgs #HA)
		{
		}

		// Token: 0x06006B75 RID: 27509 RVA: 0x000546FE File Offset: 0x000528FE
		protected virtual void #I4c(EventArgs #He)
		{
			if (6 != 0)
			{
				this.#N4c();
			}
		}

		// Token: 0x06006B76 RID: 27510 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #J4c(#1Zb #uI, int #4jb)
		{
		}

		// Token: 0x06006B77 RID: 27511 RVA: 0x0005470C File Offset: 0x0005290C
		protected virtual void #K4c(bool #L4c)
		{
			if (!false)
			{
				this.IsFilteringEnabled = #L4c;
			}
			if (!false)
			{
				this.#N4c();
			}
		}

		// Token: 0x06006B78 RID: 27512 RVA: 0x00054728 File Offset: 0x00052928
		[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		protected static string #M4c<#d3c>(Expression<Func<#1Zb, #d3c>> #b3c)
		{
			if (true)
			{
				string #R0d = #Phc.#3hc(107430759);
				StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUI;
				string #Qic = #Phc.#3hc(107430778);
				if (3 != 0)
				{
					#X0d.#V0d(#b3c, #R0d, #x6c, #Qic);
				}
			}
			return #x0d<!0>.#XYd<#d3c>(#b3c).Name;
		}

		// Token: 0x06006B79 RID: 27513 RVA: 0x0019F618 File Offset: 0x0019D818
		protected static string #72c(string #82c)
		{
			PropertyInfo[] properties = typeof(!0).GetProperties(BindingFlags.Instance | BindingFlags.Public);
			PropertyInfo[] #92c;
			if (4 != 0)
			{
				#92c = properties;
			}
			return DefinitionGridHelper.#72c(#82c, #92c);
		}

		// Token: 0x06006B7A RID: 27514 RVA: 0x0005475C File Offset: 0x0005295C
		[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		[SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
		protected static string #a3c<#d3c>(Expression<Func<#1Zb, #d3c>> #b3c)
		{
			return DefinitionGridHelper.#a3c<#1Zb, #d3c>(#b3c);
		}

		// Token: 0x06006B7B RID: 27515 RVA: 0x0019F644 File Offset: 0x0019D844
		protected virtual void #N4c()
		{
			IDelegateCommand delegateCommand = this.AddCommand;
			if (2 != 0)
			{
				delegateCommand.InvalidateCanExecute();
			}
			if (2 == 0)
			{
				goto IL_21;
			}
			IDelegateCommand delegateCommand2 = this.DeleteCommand;
			if (!false)
			{
				delegateCommand2.InvalidateCanExecute();
			}
			IL_17:
			IDelegateCommand delegateCommand3 = this.DeleteAllCommand;
			if (!false)
			{
				delegateCommand3.InvalidateCanExecute();
			}
			IL_21:
			IDelegateCommand delegateCommand4 = this.ClearFiltersCommand;
			if (!false)
			{
				delegateCommand4.InvalidateCanExecute();
			}
			if (!false)
			{
				IDelegateCommand delegateCommand5 = this.ExportCommand;
				if (!false)
				{
					delegateCommand5.InvalidateCanExecute();
				}
				IDelegateCommand delegateCommand6 = this.ImportCommand;
				if (!false)
				{
					delegateCommand6.InvalidateCanExecute();
				}
				return;
			}
			goto IL_17;
		}

		// Token: 0x06006B7C RID: 27516 RVA: 0x0019F6C0 File Offset: 0x0019D8C0
		protected #1Zb #LB(#1Zb #uI)
		{
			#1Zb result;
			List<#1Zb> list2;
			int num2;
			do
			{
				if (#uI.Equals(null))
				{
					result = default(!0);
				}
				else
				{
					List<#1Zb> list = this.Rows.ToList<#1Zb>();
					if (5 != 0)
					{
						list2 = list;
					}
					int num = list2.IndexOf(#uI);
					int num3;
					do
					{
						if (8 != 0)
						{
							num2 = num;
						}
						num3 = (num = num2);
					}
					while (6 == 0);
					if (num3 > 0)
					{
						goto IL_49;
					}
					if (!false)
					{
						goto Block_4;
					}
				}
			}
			while (6 == 0);
			return result;
			Block_4:
			result = default(!0);
			return result;
			IL_49:
			return list2.ElementAt(num2 - 1);
		}

		// Token: 0x06006B7D RID: 27517 RVA: 0x0019F728 File Offset: 0x0019D928
		protected #1Zb #O4c(#1Zb #uI)
		{
			if (#uI.Equals(null))
			{
				return default(!0);
			}
			List<#1Zb> list = this.Rows.ToList<#1Zb>();
			List<#1Zb> list2;
			if (!false)
			{
				list2 = list;
			}
			if (-1 != 0)
			{
				int num2;
				int num = num2 = list2.IndexOf(#uI);
				int num3;
				int num6;
				if (-1 != 0)
				{
					if (!false)
					{
						num3 = num;
					}
					int num4 = num2 = num3;
					int num5 = num6 = 1;
					if (num5 == 0)
					{
						goto IL_44;
					}
					num2 = num4 + num5;
				}
				num6 = list2.Count;
				IL_44:
				if (num2 < num6)
				{
					return list2.ElementAt(num3 + 1);
				}
			}
			return default(!0);
		}

		// Token: 0x06006B7E RID: 27518 RVA: 0x0019F794 File Offset: 0x0019D994
		protected virtual IList<CSVRow> #P4c(IList<#1Zb> #Q4c)
		{
			List<CSVRow> list = new List<CSVRow>();
			List<CSVRow> list2;
			if (!false)
			{
				list2 = list;
			}
			if (#Q4c != null && #Q4c.Any<#1Zb>())
			{
				if (false)
				{
					goto IL_74;
				}
				if (this.OrderedDataExchangeColumnNames == null)
				{
					return list2;
				}
				CSVRow csvrow = new CSVRow();
				CSVRow csvrow2;
				if (6 != 0)
				{
					csvrow2 = csvrow;
				}
				string[] array = this.OrderedDataExchangeColumnNames;
				string[] array2;
				if (2 != 0)
				{
					array2 = array;
				}
				int num = 0;
				int num2;
				if (2 != 0)
				{
					num2 = num;
				}
				goto IL_67;
				IL_47:
				string text = array2[num2];
				string text2;
				if (!false)
				{
					text2 = text;
				}
				csvrow2.#dlc(text2);
				int num3 = num2;
				int num4;
				do
				{
					num4 = ++num3;
				}
				while (4 == 0);
				if (-1 != 0)
				{
					num2 = num4;
				}
				IL_67:
				if (num2 < array2.Length)
				{
					goto IL_47;
				}
				list2.Add(csvrow2);
				IL_74:
				foreach (#1Zb #uI in #Q4c)
				{
					CSVRow csvrow3 = this.#03c(#uI);
					if (csvrow3 != null)
					{
						list2.Add(csvrow3);
					}
				}
				if (6 != 0)
				{
					return list2;
				}
				goto IL_47;
			}
			return list2;
		}

		// Token: 0x06006B7F RID: 27519 RVA: 0x00054764 File Offset: 0x00052964
		protected string #R4c(bool #S4c)
		{
			return this.ViewTitle.#F2d() + (#S4c ? Strings.StringPaste : Strings.StringImport);
		}

		// Token: 0x06006B80 RID: 27520 RVA: 0x0019F894 File Offset: 0x0019DA94
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		protected virtual void #T4c(IList<CSVRow> #U4c, bool #S4c, #3Hc #IK)
		{
			if (!false)
			{
				string text = #S4c ? Strings.StringCouldNotPasteAllRows : Strings.StringCouldNotImportAllRows;
				string text2;
				if (!false)
				{
					text2 = text;
				}
				try
				{
					string[] array = this.OrderedDataExchangeColumnNames;
					string[] array2;
					if (-1 != 0)
					{
						array2 = array;
					}
					if (array2 != null)
					{
						List<#1Zb> list3;
						bool flag3;
						if (!false)
						{
							IList<CSVRow> list = CSVHelper.#0kc(#U4c, array2);
							if (!false)
							{
								#U4c = list;
							}
							if (!#U4c.Any<CSVRow>())
							{
								return;
							}
							if (this.UseUndoManager)
							{
								#bDc #bDc = this.UndoManager;
								bool flag = false;
								if (3 != 0)
								{
									#bDc.IsEnabled = flag;
								}
							}
							List<#1Zb> list2 = new List<!0>();
							if (7 != 0)
							{
								list3 = list2;
							}
							bool flag2 = false;
							if (5 != 0)
							{
								flag3 = flag2;
							}
							int num = 0;
							for (;;)
							{
								int num3;
								int num2 = num3 = num;
								int num5;
								int num4 = num5 = #U4c.Count;
								if (4 != 0)
								{
									if (num2 >= num4)
									{
										break;
									}
									CSVRow csvrow = #U4c[num];
									#1Zb #1Zb = this.#a4c(list3, csvrow.Cells.Take(array2.Count<string>()).ToList<CSVCell>(), array2, num + 1, #IK);
									if (#1Zb != null)
									{
										list3.Add(#1Zb);
										goto IL_CA;
									}
									int num6 = num3 = 1;
									if (num6 != 0)
									{
										flag3 = (num6 != 0);
										goto IL_CA;
									}
									IL_CC:
									num5 = 1;
									goto IL_CD;
									IL_CA:
									num3 = num;
									goto IL_CC;
								}
								IL_CD:
								num = num3 + num5;
							}
							if (!list3.Any<#1Zb>())
							{
								if (flag3)
								{
									this.DialogService.#od(text2.#z2d(true) + Strings.StringPleaseCheckTheErrorsPanel.#z2d(), MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK, MessageBoxOptions.None);
								}
								return;
							}
							if (!this.UseUndoManager)
							{
								goto IL_133;
							}
						}
						this.UndoManager.IsEnabled = true;
						this.UndoManager.#uCc();
						IL_133:
						this.#g4c(list3);
						if (flag3)
						{
							this.DialogService.#od(text2.#z2d(true) + Strings.StringPleaseCheckTheErrorsPanel.#z2d(), MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK, MessageBoxOptions.None);
						}
					}
				}
				catch (#hYd #hYd)
				{
					this.NotificationService.#1Ic(#IK, text2.#z2d(true) + #hYd.MessageWithoutParameterInfo);
					this.DialogService.#od(#hYd.MessageWithoutParameterInfo, MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK, MessageBoxOptions.None);
				}
				catch (Exception #ob)
				{
					if (3 != 0)
					{
						this.ErrorsHandlingService.#bzc(#ob, #Phc.#3hc(107430180), #IK);
					}
				}
				finally
				{
					if (this.UseUndoManager)
					{
						this.UndoManager.IsEnabled = true;
						this.UndoManager.#vCc();
					}
				}
			}
		}

		// Token: 0x06006B81 RID: 27521 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #V4c(IList<string> #Usb, #3Hc #IK)
		{
		}

		// Token: 0x06006B82 RID: 27522 RVA: 0x00054785 File Offset: 0x00052985
		protected static Binding #W4c(string #So)
		{
			return new Binding(#So);
		}

		// Token: 0x06006B83 RID: 27523 RVA: 0x0019FAFC File Offset: 0x0019DCFC
		public #1Zb #X4c()
		{
			#A5c<#1Zb, #fx>.#gcd #gcd = new #A5c<!0, !1>.#gcd();
			#A5c<#1Zb, #fx>.#gcd #gcd2;
			if (!false)
			{
				#gcd2 = #gcd;
			}
			#1Zb #1Zb = this.GridControl.RetrieveCurrentItem() as !0;
			#1Zb #1Zb2;
			if (!false)
			{
				#1Zb2 = #1Zb;
			}
			if (#1Zb2 != null && 7 != 0 && this.Rows.Contains(#1Zb2))
			{
				return #1Zb2;
			}
			for (;;)
			{
				#gcd2.#a = this.GridControl.SelectedCells.ToList<GridControlCellInfo>();
				if (!false)
				{
					if (!#gcd2.#a.Any<GridControlCellInfo>() || !#gcd2.#a.All(new Func<GridControlCellInfo, bool>(#gcd2.#fcd)))
					{
						goto IL_C4;
					}
					#1Zb #1Zb3 = (!0)((object)#gcd2.#a[0].Item);
					if (4 != 0)
					{
						#1Zb2 = #1Zb3;
					}
					if (!false)
					{
						break;
					}
				}
			}
			if (#1Zb2 == null)
			{
				goto IL_B5;
			}
			IL_A7:
			if (this.Rows.Contains(#1Zb2))
			{
				return #1Zb2;
			}
			IL_B5:
			#1Zb result = default(!0);
			if (4 != 0)
			{
				return result;
			}
			goto IL_A7;
			IL_C4:
			return default(!0);
		}

		// Token: 0x06006B84 RID: 27524 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #Y4c()
		{
		}

		// Token: 0x06006B85 RID: 27525 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #Z4c()
		{
		}

		// Token: 0x06006B86 RID: 27526 RVA: 0x0005478D File Offset: 0x0005298D
		protected void #04c()
		{
			!0 ! = this.CurrentItem;
			if (!false)
			{
				this.CurrentEditRow = !;
			}
			IGridControl gridControl = this.GridControl;
			if (2 != 0)
			{
				gridControl.BeginEdit();
			}
		}

		// Token: 0x06006B87 RID: 27527 RVA: 0x000547B3 File Offset: 0x000529B3
		protected virtual bool #e3c(#1Zb #f3c, IDictionary<string, object> #g3c)
		{
			return DefinitionGridHelper.#e3c<#1Zb>(#f3c, #g3c);
		}

		// Token: 0x06006B88 RID: 27528 RVA: 0x000547BC File Offset: 0x000529BC
		protected void #ljb(#1Zb #uI)
		{
			IGridControl gridControl = this.GridControl;
			object item = #uI;
			if (!false)
			{
				gridControl.SelectItem(item);
			}
		}

		// Token: 0x06006B89 RID: 27529 RVA: 0x000547D6 File Offset: 0x000529D6
		protected void #14c(#1Zb #uI)
		{
			for (;;)
			{
				if (!false)
				{
					IGridControl gridControl = this.GridControl;
					object dataItem = #uI;
					if (!false)
					{
						gridControl.ScrollIntoView(dataItem);
					}
				}
				if (!false)
				{
					IGridControl gridControl2 = this.GridControl;
					object item = #uI;
					if (!false)
					{
						gridControl2.SelectItem(item);
					}
					if (!false)
					{
						break;
					}
				}
			}
		}

		// Token: 0x06006B8A RID: 27530 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #24c(#I5c #uI, PropertyChangingEventArgs #He)
		{
		}

		// Token: 0x06006B8B RID: 27531 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #34c(#I5c #uI, PropertyChangedEventArgs #He)
		{
		}

		// Token: 0x06006B8C RID: 27532 RVA: 0x0019FBE8 File Offset: 0x0019DDE8
		protected virtual object #44c(PropertyInfo #F, string #54c)
		{
			if (!false)
			{
				if (-1 == 0)
				{
					goto IL_2D;
				}
				string #R0d = #Phc.#3hc(107265775);
				StructurePoint.CoreAssets.Infrastructure.Exceptions.Component #x6c = StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUI;
				string #Qic = #Phc.#3hc(107265790);
				if (!false)
				{
					#X0d.#V0d(#F, #R0d, #x6c, #Qic);
				}
			}
			IL_23:
			Type propertyType = #F.PropertyType;
			Type type;
			if (!false)
			{
				type = propertyType;
			}
			IL_2D:
			if (!false)
			{
				object result;
				if (type == typeof(Color))
				{
					object obj = ColorConverter.ConvertFromString(#54c);
					if (3 != 0)
					{
						result = obj;
					}
				}
				else if (type.IsEnum)
				{
					object obj2 = Enum.Parse(type, #54c);
					if (!false)
					{
						result = obj2;
					}
				}
				else
				{
					object obj3 = Convert.ChangeType(#54c, #F.PropertyType, CultureInfo.CurrentCulture);
					if (-1 != 0)
					{
						result = obj3;
					}
				}
				return result;
			}
			goto IL_23;
		}

		// Token: 0x06006B8D RID: 27533 RVA: 0x00054811 File Offset: 0x00052A11
		protected virtual #L1c[] #64c()
		{
			return new #L1c[]
			{
				new #L1c(Strings.StringCSVFiles, #Phc.#3hc(107408483))
			};
		}

		// Token: 0x06006B8E RID: 27534 RVA: 0x0019FC84 File Offset: 0x0019DE84
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Unexpected exceptions catch.")]
		private void #74c(object #Ge, ExecutedRoutedEventArgs #VRc)
		{
			if (this.GridControl.IsReadOnly)
			{
				return;
			}
			#3Hc #3Hc = new #3Hc();
			string text = this.#R4c(true);
			if (!false)
			{
				#3Hc.CallerInfo = text;
			}
			#3Hc #3Hc2;
			if (5 != 0)
			{
				#3Hc2 = #3Hc;
			}
			try
			{
				string text2 = Clipboard.GetText();
				string text3;
				if (!false)
				{
					text3 = text2;
				}
				if (!string.IsNullOrWhiteSpace(text3))
				{
					if (this.GridControl.SelectedCells != null && this.GridControl.SelectedCells.Count<GridControlCellInfo>() == 1)
					{
						GridControlCellInfo gridControlCellInfo = this.GridControl.SelectedCells.First<GridControlCellInfo>();
						GridControlCellInfo gridControlCellInfo2;
						if (3 != 0)
						{
							gridControlCellInfo2 = gridControlCellInfo;
						}
						if (!false && !gridControlCellInfo2.Column.IsReadOnly)
						{
							string #54c = text3;
							GridControlCellInfo #x5c = gridControlCellInfo2;
							if (!false)
							{
								this.#w5c(#54c, #x5c);
							}
						}
					}
					else
					{
						IList<CSVRow> list = CSVHelper.#Tkc(text3, new string[]
						{
							#Phc.#3hc(107464305),
							CSVHelper.DefaultColumnSeparator
						});
						IList<CSVRow> #U4c;
						if (-1 != 0)
						{
							#U4c = list;
						}
						this.#T4c(#U4c, true, #3Hc2);
					}
				}
			}
			catch (#hYd #hYd)
			{
				this.NotificationService.#2Ic(#3Hc2, null, #hYd);
				base.Logger.Log(LoggingLevel.Error, #hYd);
				this.DialogService.#od(#hYd.Message, MessageBoxButton.OK, MessageBoxImage.Hand, MessageBoxResult.OK, MessageBoxOptions.None);
			}
			catch (Exception #ob)
			{
				this.ErrorsHandlingService.#bzc(#ob, #Phc.#3hc(107265705), #3Hc2);
			}
		}

		// Token: 0x06006B8F RID: 27535 RVA: 0x0019FDEC File Offset: 0x0019DFEC
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Unexpected exceptions catch.")]
		private void #84c(object #Ge, ExecutedRoutedEventArgs #VRc)
		{
			if (!false && 4 != 0)
			{
				#3Hc #3Hc = new #3Hc(this.#R4c(true));
				#3Hc #Ic;
				if (!false)
				{
					#Ic = #3Hc;
				}
				try
				{
					List<#1Zb> list = this.SelectedItems.ToList<#1Zb>();
					List<#1Zb> list2;
					if (!false)
					{
						list2 = list;
					}
					IEnumerable<GridControlCellInfo> selectedCells = this.GridControl.SelectedCells;
					IEnumerable<GridControlCellInfo> enumerable;
					if (!false)
					{
						enumerable = selectedCells;
					}
					if (list2.Any<#1Zb>())
					{
						string text = CSVHelper.#Wkc(this.#P4c(list2), #Phc.#3hc(107464305));
						if (5 != 0)
						{
							Clipboard.SetText(text);
						}
					}
					else
					{
						while (enumerable != null)
						{
							if (4 != 0)
							{
								GridControlCellInfo gridControlCellInfo = enumerable.FirstOrDefault<GridControlCellInfo>();
								GridControlCellInfo gridControlCellInfo2;
								if (!false)
								{
									gridControlCellInfo2 = gridControlCellInfo;
								}
								if (gridControlCellInfo2 == null)
								{
									break;
								}
								string text2 = gridControlCellInfo2.ExtractCellText();
								if (7 == 0)
								{
									break;
								}
								Clipboard.SetText(text2);
								break;
							}
						}
					}
				}
				catch (Exception #ob)
				{
					this.ErrorsHandlingService.#bzc(#ob, #Phc.#3hc(107265684), #Ic);
				}
			}
		}

		// Token: 0x06006B90 RID: 27536 RVA: 0x00054830 File Offset: 0x00052A30
		private void #94c(object #Ge, GridControlRowValidatingEventArgs #HA)
		{
			!0 #uI = (!0)((object)#HA.RowDataContext);
			if (7 != 0)
			{
				this.#y4c(#uI, #HA);
			}
		}

		// Token: 0x06006B91 RID: 27537 RVA: 0x0005484C File Offset: 0x00052A4C
		private void #a5c(object #Ge, GridControlCellValidatingEventArgs #HA)
		{
			!0 #uI = (!0)((object)#HA.Row);
			string columnUniqueName = #HA.ColumnUniqueName;
			if (4 != 0)
			{
				this.#A4c(#uI, columnUniqueName, #HA);
			}
		}

		// Token: 0x06006B92 RID: 27538 RVA: 0x0005486F File Offset: 0x00052A6F
		private void #b5c(object #Ge, EventArgs #He)
		{
			if (!false)
			{
				this.#B4c(#He);
			}
		}

		// Token: 0x06006B93 RID: 27539 RVA: 0x0005487F File Offset: 0x00052A7F
		private void #c5c(object #Ge, EventArgs #He)
		{
			if (!false)
			{
				this.#z4c(#He);
			}
		}

		// Token: 0x06006B94 RID: 27540 RVA: 0x0005488F File Offset: 0x00052A8F
		[SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "StructurePoint.GUI.Mats.ViewModels.DefinitionGridViewModelBase<TRow,TView>.MyDebugWrite(System.String)")]
		private void #d5c(object #Ge, NotifyCollectionChangedEventArgs #He)
		{
			if (!false)
			{
				this.#D4c(#He);
			}
			if (!false)
			{
				this.#N4c();
			}
		}

		// Token: 0x06006B95 RID: 27541 RVA: 0x000548AB File Offset: 0x00052AAB
		private void #e5c(object #Ge, NotifyCollectionChangedEventArgs #He)
		{
			if (6 != 0)
			{
				this.#C4c();
			}
		}

		// Token: 0x06006B96 RID: 27542 RVA: 0x000548B9 File Offset: 0x00052AB9
		private void #f5c(object #Ge, GridControlBeginningEditEventArgs #HA)
		{
			if (!false)
			{
				this.#E4c(#HA);
			}
		}

		// Token: 0x06006B97 RID: 27543 RVA: 0x000548C9 File Offset: 0x00052AC9
		private void #g5c(object #Ge, EventArgs #He)
		{
			if (!false)
			{
				this.#F4c(#He);
			}
		}

		// Token: 0x06006B98 RID: 27544 RVA: 0x000548D9 File Offset: 0x00052AD9
		private void #h5c(object #Ge, GridControlRowEditEndedEventArgs #He)
		{
			if (!false)
			{
				this.#G4c(#He);
			}
		}

		// Token: 0x06006B99 RID: 27545 RVA: 0x000548E9 File Offset: 0x00052AE9
		private void #i5c(object #Ge, EventArgs #He)
		{
			if (this.#o4c(null))
			{
				object #Sb = null;
				if (!false)
				{
					this.#n4c(#Sb);
				}
			}
		}

		// Token: 0x06006B9A RID: 27546 RVA: 0x00054902 File Offset: 0x00052B02
		private void #j5c(object #Ge, EventArgs #He)
		{
			if (this.#u4c(null))
			{
				object #Sb = null;
				if (!false)
				{
					this.#p4c(#Sb);
				}
			}
		}

		// Token: 0x06006B9B RID: 27547 RVA: 0x0005491B File Offset: 0x00052B1B
		private void #k5c(object #Ge, EventArgs #He)
		{
			if (!false)
			{
				this.#I4c(#He);
			}
		}

		// Token: 0x06006B9C RID: 27548 RVA: 0x0005492B File Offset: 0x00052B2B
		private void #l5c(object #Ge, GridControlChangeRowIndexRequestEventArgs #He)
		{
			if (4 != 0)
			{
				bool flag2;
				bool flag = flag2 = this.IsEditing;
				do
				{
					if (3 != 0)
					{
						if (flag2)
						{
							return;
						}
						flag = (flag2 = this.IsAdding);
					}
				}
				while (7 == 0);
				if (!flag)
				{
					!0 #uI = (!0)((object)#He.Row);
					int index = #He.Index;
					if (!false)
					{
						this.#J4c(#uI, index);
					}
				}
			}
		}

		// Token: 0x06006B9D RID: 27549 RVA: 0x00054965 File Offset: 0x00052B65
		private void #m5c(object #Ge, GridControlFiltersStateChangedEventArgs #He)
		{
			bool enabled = #He.Enabled;
			if (2 != 0)
			{
				this.#K4c(enabled);
			}
		}

		// Token: 0x06006B9E RID: 27550 RVA: 0x0019FEC4 File Offset: 0x0019E0C4
		private void #n5c(object #Ge, PropertyChangingEventArgs #He)
		{
			#I5c #I5c = #Ge as #I5c;
			#I5c #I5c2;
			if (!false)
			{
				#I5c2 = #I5c;
			}
			if (#I5c2 != null)
			{
				#I5c #uI = #I5c2;
				if (!false)
				{
					this.#24c(#uI, #He);
				}
			}
		}

		// Token: 0x06006B9F RID: 27551 RVA: 0x0019FEF4 File Offset: 0x0019E0F4
		[SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "StructurePoint.GUI.Mats.ViewModels.DefinitionGridViewModelBase<TRow,TView>.MyDebugWrite(System.String)")]
		private void #o5c(object #Ge, PropertyChangedEventArgs #He)
		{
			do
			{
				#I5c #I5c2;
				if (!false)
				{
					#I5c #I5c = #Ge as #I5c;
					if (!false)
					{
						#I5c2 = #I5c;
					}
				}
				while (#I5c2 != null)
				{
					#I5c #uI = #I5c2;
					if (!false)
					{
						this.#34c(#uI, #He);
					}
					if (!false)
					{
						return;
					}
				}
			}
			while (false);
		}

		// Token: 0x06006BA0 RID: 27552 RVA: 0x0019FF2C File Offset: 0x0019E12C
		private void #p5c(IEnumerable<#I5c> #33c, #I5c #q5c)
		{
			#07c #07c = new #07c(this.SelectedItems);
			#07c #07c2;
			if (7 != 0)
			{
				#07c2 = #07c;
			}
			try
			{
				this.GridControl.ClearSelection();
				this.CurrentItem = (!0)((object)#q5c);
				List<#I5c> list = #33c.ToList<#I5c>();
				list.Remove(#q5c);
				list.Add(#q5c);
				using (List<#I5c>.Enumerator enumerator = list.GetEnumerator())
				{
					for (;;)
					{
						bool flag2;
						bool flag = flag2 = enumerator.MoveNext();
						#I5c #I5c2;
						if (!false)
						{
							if (!flag)
							{
								break;
							}
							#I5c #I5c = enumerator.Current;
							if (6 != 0)
							{
								#I5c2 = #I5c;
							}
							flag2 = this.SelectedItems.Contains((!0)((object)#I5c2));
						}
						if (!flag2)
						{
							Collection<!0> collection = this.SelectedItems;
							!0 item = (!0)((object)#I5c2);
							if (6 != 0)
							{
								collection.Add(item);
							}
						}
					}
				}
			}
			finally
			{
				if (#07c2 != null)
				{
					((IDisposable)#07c2).Dispose();
				}
			}
		}

		// Token: 0x06006BA1 RID: 27553 RVA: 0x001A0000 File Offset: 0x0019E200
		private void #r5c()
		{
			for (;;)
			{
				if (!false)
				{
					!0 ! = default(!0);
					if (!false)
					{
						this.CurrentEditRow = !;
					}
				}
				for (;;)
				{
					bool flag = false;
					if (!false)
					{
						this.IsEditing = flag;
					}
					if (7 == 0)
					{
						break;
					}
					bool flag2 = false;
					if (-1 != 0)
					{
						this.IsAdding = flag2;
					}
					if (!false)
					{
						return;
					}
				}
			}
		}

		// Token: 0x06006BA2 RID: 27554 RVA: 0x001A0048 File Offset: 0x0019E248
		private void #s5c()
		{
			IEnumerator<#1Zb> enumerator = this.Rows.GetEnumerator();
			IEnumerator<#1Zb> enumerator2;
			if (4 != 0)
			{
				enumerator2 = enumerator;
			}
			try
			{
				while (enumerator2.MoveNext())
				{
					!0 ! = enumerator2.Current;
					!.PropertyChanged -= this.#o5c;
					!.PropertyChanged += this.#o5c;
					INotifyPropertyChanging notifyPropertyChanging = !;
					PropertyChangingEventHandler value = new PropertyChangingEventHandler(this.#n5c);
					if (!false)
					{
						notifyPropertyChanging.PropertyChanging -= value;
					}
					INotifyPropertyChanging notifyPropertyChanging2 = !;
					PropertyChangingEventHandler value2 = new PropertyChangingEventHandler(this.#n5c);
					if (!false)
					{
						notifyPropertyChanging2.PropertyChanging += value2;
					}
				}
			}
			finally
			{
				if (enumerator2 != null)
				{
					enumerator2.Dispose();
				}
			}
		}

		// Token: 0x06006BA3 RID: 27555 RVA: 0x001A0104 File Offset: 0x0019E304
		private void #t5c()
		{
			if (7 != 0 && !false)
			{
				IEnumerator<#1Zb> enumerator = this.Rows.GetEnumerator();
				IEnumerator<#1Zb> enumerator2;
				if (!false)
				{
					enumerator2 = enumerator;
				}
				try
				{
					while (enumerator2.MoveNext())
					{
						!0 ! = enumerator2.Current;
						INotifyPropertyChanged notifyPropertyChanged = !;
						PropertyChangedEventHandler value = new PropertyChangedEventHandler(this.#o5c);
						if (true)
						{
							notifyPropertyChanged.PropertyChanged -= value;
						}
						INotifyPropertyChanging notifyPropertyChanging = !;
						PropertyChangingEventHandler value2 = new PropertyChangingEventHandler(this.#n5c);
						if (!false)
						{
							notifyPropertyChanging.PropertyChanging -= value2;
						}
					}
				}
				finally
				{
					while (enumerator2 != null)
					{
						if (4 != 0)
						{
							enumerator2.Dispose();
							break;
						}
					}
				}
			}
		}

		// Token: 0x06006BA4 RID: 27556 RVA: 0x001A0194 File Offset: 0x0019E394
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Unexpected exceptions catch.")]
		private void #u5c(object #Sb)
		{
			#3Hc #3Hc = new #3Hc(this.#R4c(false));
			#3Hc #3Hc2;
			if (6 != 0)
			{
				#3Hc2 = #3Hc;
			}
			try
			{
				#L1c[] array = this.#64c();
				#L1c[] #m2c;
				if (-1 != 0)
				{
					#m2c = array;
				}
				string text = this.FileSystemService.#S1c(new #12c(#m2c, #Phc.#3hc(107408483), null));
				string text2;
				if (true)
				{
					text2 = text;
				}
				#3Hc #3Hc3 = #3Hc2;
				string text3 = text2;
				if (!false)
				{
					#3Hc3.FilePath = text3;
				}
				if (!string.IsNullOrWhiteSpace(text2))
				{
					Stream stream = this.FileSystemService.#U1c(text2);
					Stream stream2;
					if (!false)
					{
						stream2 = stream;
					}
					try
					{
						if (!Alphaleonis.Win32.Filesystem.Path.GetExtension(text2).Equals(string.Format(CultureInfo.InvariantCulture, #Phc.#3hc(107265631), new object[]
						{
							#Phc.#3hc(107413479)
						}), StringComparison.OrdinalIgnoreCase))
						{
							IList<CSVRow> #U4c = CSVHelper.#Tkc(stream2, new string[]
							{
								CSVHelper.DefaultColumnSeparator,
								#Phc.#3hc(107464305)
							});
							if (3 != 0)
							{
								this.#T4c(#U4c, false, #3Hc2);
								goto IL_E5;
							}
						}
						IList<string> list = #Wic.#Vic(stream2);
						IList<string> #Usb;
						if (!false)
						{
							#Usb = list;
						}
						this.#V4c(#Usb, #3Hc2);
						IL_E5:;
					}
					finally
					{
						if (stream2 != null)
						{
							((IDisposable)stream2).Dispose();
						}
					}
				}
			}
			catch (#hYd #hYd)
			{
				this.NotificationService.#1Ic(#3Hc2, #hYd.MessageWithoutParameterInfo, null);
				this.DialogService.#od(#hYd.MessageWithoutParameterInfo, MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK, MessageBoxOptions.None);
			}
			catch (Exception #ob)
			{
				this.ErrorsHandlingService.#bzc(#ob, #Phc.#3hc(107265622), #3Hc2);
			}
		}

		// Token: 0x06006BA5 RID: 27557 RVA: 0x001A0354 File Offset: 0x0019E554
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Unexpected exceptions catch.")]
		private void #v5c(object #Sb)
		{
			#3Hc #3Hc = new #3Hc(this.#R4c(false));
			#3Hc #3Hc2;
			if (!false)
			{
				#3Hc2 = #3Hc;
			}
			try
			{
				#L1c[] array = new #L1c[]
				{
					new #L1c(Strings.StringCSVFiles, #Phc.#3hc(107408483))
				};
				#L1c[] #m2c;
				if (-1 != 0)
				{
					#m2c = array;
				}
				string text = this.FileSystemService.#11c(new #62c(#m2c, #Phc.#3hc(107408483), null));
				string text2;
				if (7 != 0)
				{
					text2 = text;
				}
				#3Hc #3Hc3 = #3Hc2;
				string text3 = text2;
				if (2 != 0)
				{
					#3Hc3.FilePath = text3;
				}
				if (!string.IsNullOrWhiteSpace(text2))
				{
					Stream stream = this.FileSystemService.#T1c(text2);
					Stream stream2;
					if (!false)
					{
						stream2 = stream;
					}
					try
					{
						string text4 = CSVHelper.#Wkc(this.#P4c(this.GridControl.CurrentItemsInView.OfType<#1Zb>().ToList<#1Zb>()), CSVHelper.DefaultColumnSeparator);
						string #Ukc;
						if (7 != 0)
						{
							#Ukc = text4;
						}
						stream2.#LAc(#Ukc);
					}
					finally
					{
						if (stream2 != null)
						{
							((IDisposable)stream2).Dispose();
						}
					}
				}
			}
			catch (#hYd #hYd)
			{
				this.NotificationService.#2Ic(#3Hc2, null, #hYd);
				this.DialogService.#od(#hYd.Message, MessageBoxButton.OK, MessageBoxImage.Hand, MessageBoxResult.OK, MessageBoxOptions.None);
			}
			catch (Exception #ob)
			{
				this.ErrorsHandlingService.#bzc(#ob, #Phc.#3hc(107265622), #3Hc2);
			}
		}

		// Token: 0x06006BA6 RID: 27558 RVA: 0x001A04A8 File Offset: 0x0019E6A8
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Unexpected exceptions catch.")]
		private void #w5c(string #54c, GridControlCellInfo #x5c)
		{
			#EBc #EBc = this.#W3c(#x5c.Column.DataMemberBinding.Path.Path, #54c, CultureInfo.CurrentCulture, (!0)((object)#x5c.Item));
			#EBc #EBc2;
			if (8 != 0)
			{
				#EBc2 = #EBc;
			}
			this.#h = (!0)((object)#x5c.Item);
			#3Hc #3Hc = new #3Hc(this.#R4c(true));
			#3Hc #Ic;
			if (!false)
			{
				#Ic = #3Hc;
			}
			if (#EBc2 != null && #EBc2.IsValid)
			{
				try
				{
					PropertyInfo propertyInfo = #x5c.ExtractCellPropertyInfo();
					PropertyInfo propertyInfo2;
					if (true)
					{
						propertyInfo2 = propertyInfo;
					}
					object obj = this.#44c(propertyInfo2, #54c);
					object obj2;
					if (4 != 0)
					{
						obj2 = obj;
					}
					object obj3 = #x5c.ExtractCellValue();
					object obj4;
					if (7 != 0)
					{
						obj4 = obj3;
					}
					if (!object.Equals(obj4, obj2))
					{
						if (this.UseUndoManager)
						{
							#bDc #bDc = this.UndoManager;
							if (3 != 0)
							{
								#bDc.#uCc();
							}
						}
						#x5c.SetCellValue(obj2);
						string text = this.#Z3c((!0)((object)#x5c.Item));
						if (text != null)
						{
							if (!this.UseUndoManager)
							{
								goto IL_E4;
							}
						}
						else if (!false)
						{
							this.#Y4c();
							goto IL_130;
						}
						this.UndoManager.#wCc();
						IL_E4:
						#x5c.SetCellValue(obj4);
						string text2 = Strings.StringTheValueCannotBePasted.#z2d() + Environment.NewLine + text;
						this.NotificationService.#1Ic(#Ic, text2);
						this.DialogService.#od(text2, MessageBoxButton.OK, MessageBoxImage.Hand, MessageBoxResult.OK, MessageBoxOptions.None);
						IL_130:
						if (this.UseUndoManager)
						{
							this.UndoManager.#vCc();
						}
					}
					return;
				}
				catch (Exception #ob)
				{
					this.ErrorsHandlingService.#bzc(#ob, #Phc.#3hc(107265537), #Ic);
					return;
				}
			}
			if (#EBc2 != null)
			{
				string text3 = Strings.StringTheValueCannotBePasted.#z2d() + Environment.NewLine + #EBc2.ErrorMessage;
				this.NotificationService.#2Ic(#Ic, text3);
				this.DialogService.#od(text3, MessageBoxButton.OK, MessageBoxImage.Hand, MessageBoxResult.OK, MessageBoxOptions.None);
			}
		}

		// Token: 0x06006BA7 RID: 27559 RVA: 0x0005497A File Offset: 0x00052B7A
		[CompilerGenerated]
		private int #y5c(#1Zb #Rf)
		{
			return this.#f.#C7c(#Rf);
		}

		// Token: 0x06006BA8 RID: 27560 RVA: 0x0005497A File Offset: 0x00052B7A
		[CompilerGenerated]
		private int #z5c(#1Zb #Rf)
		{
			return this.#f.#C7c(#Rf);
		}

		// Token: 0x04002BB5 RID: 11189
		private const string #a = "\t";

		// Token: 0x04002BB6 RID: 11190
		protected const string #b = "csv";

		// Token: 0x04002BB7 RID: 11191
		protected const string #c = "txt";

		// Token: 0x04002BB8 RID: 11192
		protected const int #d = 0;

		// Token: 0x04002BB9 RID: 11193
		private #1Zb #e;

		// Token: 0x04002BBA RID: 11194
		private #k8c<#1Zb> #f;

		// Token: 0x04002BBB RID: 11195
		private IGridControlColumn #g;

		// Token: 0x04002BBC RID: 11196
		private #1Zb #h;

		// Token: 0x04002BBD RID: 11197
		private bool #i;

		// Token: 0x04002BBE RID: 11198
		private bool #j;

		// Token: 0x04002BBF RID: 11199
		[CompilerGenerated]
		private bool #k;

		// Token: 0x04002BC0 RID: 11200
		[CompilerGenerated]
		private #6Gc #l;

		// Token: 0x04002BC1 RID: 11201
		[CompilerGenerated]
		private #oW #m;

		// Token: 0x04002BC2 RID: 11202
		[CompilerGenerated]
		private CustomObservableCollection<#1Zb> #n;

		// Token: 0x04002BC3 RID: 11203
		[CompilerGenerated]
		private #1Zb #o;

		// Token: 0x04002BC4 RID: 11204
		[CompilerGenerated]
		private #fTc #p;

		// Token: 0x04002BC5 RID: 11205
		[CompilerGenerated]
		private IDelegateCommand #q;

		// Token: 0x04002BC6 RID: 11206
		[CompilerGenerated]
		private IDelegateCommand #r;

		// Token: 0x04002BC7 RID: 11207
		[CompilerGenerated]
		private IDelegateCommand #s;

		// Token: 0x04002BC8 RID: 11208
		[CompilerGenerated]
		private IDelegateCommand #t;

		// Token: 0x04002BC9 RID: 11209
		[CompilerGenerated]
		private #bDc #u;

		// Token: 0x04002BCA RID: 11210
		[CompilerGenerated]
		private #5Ic #v;

		// Token: 0x04002BCB RID: 11211
		[CompilerGenerated]
		private ICommandFactory #w;

		// Token: 0x04002BCC RID: 11212
		[CompilerGenerated]
		private #rBc #x;

		// Token: 0x04002BCD RID: 11213
		[CompilerGenerated]
		private #8Sc #y;

		// Token: 0x04002BCE RID: 11214
		[CompilerGenerated]
		private IDelegateCommand #z;

		// Token: 0x04002BCF RID: 11215
		[CompilerGenerated]
		private IDelegateCommand #A;

		// Token: 0x04002BD0 RID: 11216
		[CompilerGenerated]
		private #v2c #B;

		// Token: 0x04002BD1 RID: 11217
		[CompilerGenerated]
		private #V0c #C;

		// Token: 0x04002BD2 RID: 11218
		[CompilerGenerated]
		private #Qrc #D;

		// Token: 0x04002BD3 RID: 11219
		[CompilerGenerated]
		private IResourcesHelper #E;

		// Token: 0x04002BD4 RID: 11220
		[CompilerGenerated]
		private bool #F;

		// Token: 0x04002BD5 RID: 11221
		[CompilerGenerated]
		private bool #G;

		// Token: 0x02000CCF RID: 3279
		[CompilerGenerated]
		private sealed class #ZWb
		{
			// Token: 0x06006BAA RID: 27562 RVA: 0x0005498D File Offset: 0x00052B8D
			internal void #6bd()
			{
				#A5c<!0, !1> #A5c = this.#a;
				IEnumerable<#I5c> #33c = this.#b;
				#I5c #q5c = this.#c;
				if (!false)
				{
					#A5c.#p5c(#33c, #q5c);
				}
			}

			// Token: 0x06006BAB RID: 27563 RVA: 0x0005498D File Offset: 0x00052B8D
			internal void #7bd()
			{
				#A5c<!0, !1> #A5c = this.#a;
				IEnumerable<#I5c> #33c = this.#b;
				#I5c #q5c = this.#c;
				if (!false)
				{
					#A5c.#p5c(#33c, #q5c);
				}
			}

			// Token: 0x04002BD6 RID: 11222
			public #A5c<#1Zb, #fx> #a;

			// Token: 0x04002BD7 RID: 11223
			public IEnumerable<#I5c> #b;

			// Token: 0x04002BD8 RID: 11224
			public #I5c #c;
		}

		// Token: 0x02000CD0 RID: 3280
		[CompilerGenerated]
		private sealed class #acd
		{
			// Token: 0x06006BAD RID: 27565 RVA: 0x000549AE File Offset: 0x00052BAE
			internal bool #8bd(IGridControlColumn #9bd)
			{
				return #9bd.DataMemberBinding.Path.Path == this.#a;
			}

			// Token: 0x04002BD9 RID: 11225
			public string #a;
		}

		// Token: 0x02000CD1 RID: 3281
		[CompilerGenerated]
		private sealed class #ecd
		{
			// Token: 0x06006BAF RID: 27567 RVA: 0x000549CB File Offset: 0x00052BCB
			internal bool #bcd(#1Zb #Rf)
			{
				return #Rf == this.#a;
			}

			// Token: 0x06006BB0 RID: 27568 RVA: 0x001A0690 File Offset: 0x0019E890
			internal void #ccd()
			{
				do
				{
					#A5c<!0, !1> #A5c = this.#b;
					if (5 != 0)
					{
						#A5c.#04c();
					}
				}
				while (false);
				#fTc #fTc = this.#b.LayoutService;
				double #aTc = 0.05;
				Action #bTc;
				if ((#bTc = this.#c) == null)
				{
					#bTc = (this.#c = new Action(this.#dcd));
				}
				if (!false)
				{
					#fTc.#9Sc(#aTc, #bTc);
				}
			}

			// Token: 0x06006BB1 RID: 27569 RVA: 0x000549E0 File Offset: 0x00052BE0
			internal void #dcd()
			{
				do
				{
					if (true && !false)
					{
						IGridControl gridControl = this.#b.GridControl;
						object dataItem = this.#a;
						object column = this.#b.CurrentColumn;
						if (!false)
						{
							gridControl.BeginEdit(dataItem, column);
						}
					}
				}
				while (false);
			}

			// Token: 0x04002BDA RID: 11226
			public #1Zb #a;

			// Token: 0x04002BDB RID: 11227
			public #A5c<#1Zb, #fx> #b;

			// Token: 0x04002BDC RID: 11228
			public Action #c;
		}

		// Token: 0x02000CD2 RID: 3282
		[CompilerGenerated]
		private sealed class #gcd
		{
			// Token: 0x06006BB3 RID: 27571 RVA: 0x00054A19 File Offset: 0x00052C19
			internal bool #fcd(GridControlCellInfo #Vpb)
			{
				return #Vpb.Item == this.#a[0].Item;
			}

			// Token: 0x04002BDD RID: 11229
			public List<GridControlCellInfo> #a;
		}
	}
}
