using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.RibbonToolbar
{
	// Token: 0x020008F0 RID: 2288
	public sealed class RibbonToolbarController : NotifyPropertyChangedObjectBase, IRibbonToolbarController
	{
		// Token: 0x060048B9 RID: 18617 RVA: 0x00144450 File Offset: 0x00142650
		public RibbonToolbarController()
		{
			this.groups = new ObservableCollection<RibbonToolbarGroup>();
			this.ButtonsBackground = new SolidColorBrush(Color.FromRgb(238, 238, 242));
			this.ButtonsBorderThickness = new Thickness(1.0);
			this.ButtonsBorderBrush = new SolidColorBrush(Color.FromRgb(204, 206, 219));
		}

		// Token: 0x060048BA RID: 18618 RVA: 0x001444C0 File Offset: 0x001426C0
		public RibbonToolbarController(IEnumerable<RibbonToolbarGroup> groups, Orientation orientation, Visibility separatorsVisibility)
		{
			this.groups = new ObservableCollection<RibbonToolbarGroup>(groups);
			this.ButtonsBackground = new SolidColorBrush(Color.FromRgb(238, 238, 242));
			this.ButtonsBorderThickness = new Thickness(1.0);
			this.ButtonsBorderBrush = new SolidColorBrush(Color.FromRgb(204, 206, 219));
			this.Orientation = orientation;
			this.SeparatorsVisibility = separatorsVisibility;
		}

		// Token: 0x1700153C RID: 5436
		// (get) Token: 0x060048BB RID: 18619 RVA: 0x0003D354 File Offset: 0x0003B554
		public IList<RibbonToolbarGroup> Groups
		{
			get
			{
				return this.groups;
			}
		}

		// Token: 0x1700153D RID: 5437
		// (get) Token: 0x060048BC RID: 18620 RVA: 0x0003D360 File Offset: 0x0003B560
		// (set) Token: 0x060048BD RID: 18621 RVA: 0x0003D36C File Offset: 0x0003B56C
		public Orientation Orientation
		{
			get
			{
				return this.orientation;
			}
			set
			{
				if (this.orientation != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107450099));
					this.orientation = value;
					base.RaisePropertyChanged(#Phc.#3hc(107450099));
				}
			}
		}

		// Token: 0x1700153E RID: 5438
		// (get) Token: 0x060048BE RID: 18622 RVA: 0x0003D3AA File Offset: 0x0003B5AA
		// (set) Token: 0x060048BF RID: 18623 RVA: 0x0003D3B6 File Offset: 0x0003B5B6
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

		// Token: 0x1700153F RID: 5439
		// (get) Token: 0x060048C0 RID: 18624 RVA: 0x0003D3F4 File Offset: 0x0003B5F4
		// (set) Token: 0x060048C1 RID: 18625 RVA: 0x0003D400 File Offset: 0x0003B600
		public Visibility SeparatorsVisibility
		{
			get
			{
				return this.separatorsVisibility;
			}
			set
			{
				if (this.separatorsVisibility != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107450050));
					this.separatorsVisibility = value;
					base.RaisePropertyChanged(#Phc.#3hc(107450050));
				}
			}
		}

		// Token: 0x17001540 RID: 5440
		// (get) Token: 0x060048C2 RID: 18626 RVA: 0x0003D43E File Offset: 0x0003B63E
		// (set) Token: 0x060048C3 RID: 18627 RVA: 0x00144540 File Offset: 0x00142740
		public Thickness ButtonsBorderThickness
		{
			get
			{
				return this.buttonsBorderThickness;
			}
			set
			{
				if (this.buttonsBorderThickness != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107450021));
					this.buttonsBorderThickness = value;
					base.RaisePropertyChanged(#Phc.#3hc(107450021));
				}
			}
		}

		// Token: 0x17001541 RID: 5441
		// (get) Token: 0x060048C4 RID: 18628 RVA: 0x0003D44A File Offset: 0x0003B64A
		// (set) Token: 0x060048C5 RID: 18629 RVA: 0x0003D456 File Offset: 0x0003B656
		public Brush ButtonsBorderBrush
		{
			get
			{
				return this.buttonsBorderBrush;
			}
			set
			{
				if (this.buttonsBorderBrush != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107449988));
					this.buttonsBorderBrush = value;
					base.RaisePropertyChanged(#Phc.#3hc(107449988));
				}
			}
		}

		// Token: 0x17001542 RID: 5442
		// (get) Token: 0x060048C6 RID: 18630 RVA: 0x0003D494 File Offset: 0x0003B694
		// (set) Token: 0x060048C7 RID: 18631 RVA: 0x0003D4A0 File Offset: 0x0003B6A0
		public Brush ButtonsBackground
		{
			get
			{
				return this.buttonsBackground;
			}
			set
			{
				if (this.buttonsBackground != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107449963));
					this.buttonsBackground = value;
					base.RaisePropertyChanged(#Phc.#3hc(107449963));
				}
			}
		}

		// Token: 0x17001543 RID: 5443
		// (get) Token: 0x060048C8 RID: 18632 RVA: 0x0003D4DE File Offset: 0x0003B6DE
		// (set) Token: 0x060048C9 RID: 18633 RVA: 0x0003D4EA File Offset: 0x0003B6EA
		public IEditionToolData SelectedToolData { get; set; }

		// Token: 0x17001544 RID: 5444
		// (get) Token: 0x060048CA RID: 18634 RVA: 0x0003D4FB File Offset: 0x0003B6FB
		// (set) Token: 0x060048CB RID: 18635 RVA: 0x0003D507 File Offset: 0x0003B707
		public IRibbonToolbarButton IncreaseToolbarButton { get; set; }

		// Token: 0x17001545 RID: 5445
		// (get) Token: 0x060048CC RID: 18636 RVA: 0x0003D518 File Offset: 0x0003B718
		// (set) Token: 0x060048CD RID: 18637 RVA: 0x0003D524 File Offset: 0x0003B724
		public IRibbonToolbarButton DecreaseToolbarButton { get; set; }

		// Token: 0x140000F1 RID: 241
		// (add) Token: 0x060048CE RID: 18638 RVA: 0x00144590 File Offset: 0x00142790
		// (remove) Token: 0x060048CF RID: 18639 RVA: 0x001445D4 File Offset: 0x001427D4
		public event EventHandler<SelectedItemChangedEventArgs<IEditionToolData>> SelectedToolChanged;

		// Token: 0x060048D0 RID: 18640 RVA: 0x00144618 File Offset: 0x00142818
		protected void OnSelectedToolChanged(IEditionToolData previousToolData, IEditionToolData newToolData)
		{
			EventHandler<SelectedItemChangedEventArgs<IEditionToolData>> selectedToolChanged = this.SelectedToolChanged;
			if (selectedToolChanged != null)
			{
				selectedToolChanged(this, new SelectedItemChangedEventArgs<IEditionToolData>(previousToolData, newToolData));
			}
		}

		// Token: 0x060048D1 RID: 18641 RVA: 0x0014464C File Offset: 0x0014284C
		public void ActivateTool(IEditionToolData tool)
		{
			IEditionToolData selectedToolData = this.SelectedToolData;
			this.SelectedToolData = tool;
			this.OnSelectedToolChanged(selectedToolData, tool);
		}

		// Token: 0x040020BB RID: 8379
		private readonly ObservableCollection<RibbonToolbarGroup> groups;

		// Token: 0x040020BC RID: 8380
		private Orientation orientation;

		// Token: 0x040020BD RID: 8381
		private Visibility visibility;

		// Token: 0x040020BE RID: 8382
		private Visibility separatorsVisibility;

		// Token: 0x040020BF RID: 8383
		private Thickness buttonsBorderThickness;

		// Token: 0x040020C0 RID: 8384
		private Brush buttonsBorderBrush;

		// Token: 0x040020C1 RID: 8385
		private Brush buttonsBackground;
	}
}
