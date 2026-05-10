using System;
using System.Collections.ObjectModel;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Ribbon
{
	// Token: 0x020008B0 RID: 2224
	public sealed class RibbonTab : NotifyPropertyChangedObjectBase
	{
		// Token: 0x06004614 RID: 17940 RVA: 0x0003A979 File Offset: 0x00038B79
		public RibbonTab(string text)
		{
			#X0d.#W0d(text, #Phc.#3hc(107453475), Component.GUI, #Phc.#3hc(107453498));
			this.Text = text;
			this.groups = new ObservableCollection<RibbonGroup>();
		}

		// Token: 0x17001482 RID: 5250
		// (get) Token: 0x06004615 RID: 17941 RVA: 0x0003A9AE File Offset: 0x00038BAE
		public ObservableCollection<RibbonGroup> Groups
		{
			get
			{
				return this.groups;
			}
		}

		// Token: 0x17001483 RID: 5251
		// (get) Token: 0x06004616 RID: 17942 RVA: 0x0003A9BA File Offset: 0x00038BBA
		// (set) Token: 0x06004617 RID: 17943 RVA: 0x0003A9C6 File Offset: 0x00038BC6
		public bool IsSelected
		{
			get
			{
				return this.isSelected;
			}
			set
			{
				if (this.isSelected != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107407591));
					this.isSelected = value;
					base.RaisePropertyChanged(#Phc.#3hc(107407591));
				}
			}
		}

		// Token: 0x17001484 RID: 5252
		// (get) Token: 0x06004618 RID: 17944 RVA: 0x0003AA04 File Offset: 0x00038C04
		// (set) Token: 0x06004619 RID: 17945 RVA: 0x0013D768 File Offset: 0x0013B968
		public string Text
		{
			get
			{
				return this.text;
			}
			set
			{
				if (this.text != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107350927));
					this.text = value;
					base.RaisePropertyChanged(#Phc.#3hc(107350927));
				}
			}
		}

		// Token: 0x04001FCE RID: 8142
		private bool isSelected;

		// Token: 0x04001FCF RID: 8143
		private string text;

		// Token: 0x04001FD0 RID: 8144
		private readonly ObservableCollection<RibbonGroup> groups;
	}
}
