using System;
using System.Windows;
using System.Windows.Media;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x0200092A RID: 2346
	public sealed class PanelItem : NotifyPropertyChangedObjectBase, IPanelItem
	{
		// Token: 0x17001642 RID: 5698
		// (get) Token: 0x06004C76 RID: 19574 RVA: 0x00040017 File Offset: 0x0003E217
		// (set) Token: 0x06004C77 RID: 19575 RVA: 0x0014CC7C File Offset: 0x0014AE7C
		public string Header
		{
			get
			{
				return this.header;
			}
			set
			{
				if (this.header != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107450197));
					this.header = value;
					base.RaisePropertyChanged(#Phc.#3hc(107450197));
				}
			}
		}

		// Token: 0x17001643 RID: 5699
		// (get) Token: 0x06004C78 RID: 19576 RVA: 0x00040023 File Offset: 0x0003E223
		// (set) Token: 0x06004C79 RID: 19577 RVA: 0x0004002F File Offset: 0x0003E22F
		public HorizontalAlignment HorizontalAlignment
		{
			get
			{
				return this.horizontalAlignment;
			}
			set
			{
				if (this.horizontalAlignment != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107470830));
					this.horizontalAlignment = value;
					base.RaisePropertyChanged(#Phc.#3hc(107470830));
				}
			}
		}

		// Token: 0x17001644 RID: 5700
		// (get) Token: 0x06004C7A RID: 19578 RVA: 0x0004006D File Offset: 0x0003E26D
		// (set) Token: 0x06004C7B RID: 19579 RVA: 0x00040079 File Offset: 0x0003E279
		public object Content
		{
			get
			{
				return this.content;
			}
			set
			{
				if (this.content != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107470833));
					this.content = value;
					base.RaisePropertyChanged(#Phc.#3hc(107470833));
				}
			}
		}

		// Token: 0x17001645 RID: 5701
		// (get) Token: 0x06004C7C RID: 19580 RVA: 0x000400B7 File Offset: 0x0003E2B7
		// (set) Token: 0x06004C7D RID: 19581 RVA: 0x000400C3 File Offset: 0x0003E2C3
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

		// Token: 0x17001646 RID: 5702
		// (get) Token: 0x06004C7E RID: 19582 RVA: 0x00040101 File Offset: 0x0003E301
		// (set) Token: 0x06004C7F RID: 19583 RVA: 0x0014CCCC File Offset: 0x0014AECC
		public Thickness Margin
		{
			get
			{
				return this.margin;
			}
			set
			{
				if (this.margin != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107361172));
					this.margin = value;
					base.RaisePropertyChanged(#Phc.#3hc(107361172));
				}
			}
		}

		// Token: 0x17001647 RID: 5703
		// (get) Token: 0x06004C80 RID: 19584 RVA: 0x0004010D File Offset: 0x0003E30D
		// (set) Token: 0x06004C81 RID: 19585 RVA: 0x0014CD1C File Offset: 0x0014AF1C
		public Thickness BorderThickness
		{
			get
			{
				return this.borderThickness;
			}
			set
			{
				if (this.borderThickness != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107453155));
					this.borderThickness = value;
					base.RaisePropertyChanged(#Phc.#3hc(107453155));
				}
			}
		}

		// Token: 0x17001648 RID: 5704
		// (get) Token: 0x06004C82 RID: 19586 RVA: 0x00040119 File Offset: 0x0003E319
		// (set) Token: 0x06004C83 RID: 19587 RVA: 0x00040125 File Offset: 0x0003E325
		public Brush BorderBrush
		{
			get
			{
				return this.borderBrush;
			}
			set
			{
				if (this.borderBrush != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107453716));
					this.borderBrush = value;
					base.RaisePropertyChanged(#Phc.#3hc(107453716));
				}
			}
		}

		// Token: 0x040021C7 RID: 8647
		private string header;

		// Token: 0x040021C8 RID: 8648
		private HorizontalAlignment horizontalAlignment;

		// Token: 0x040021C9 RID: 8649
		private object content;

		// Token: 0x040021CA RID: 8650
		private Visibility visibility;

		// Token: 0x040021CB RID: 8651
		private Thickness margin;

		// Token: 0x040021CC RID: 8652
		private Thickness borderThickness;

		// Token: 0x040021CD RID: 8653
		private Brush borderBrush;
	}
}
