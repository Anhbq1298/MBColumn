using System;
using System.Runtime.CompilerServices;
using System.Windows;
using #7hc;
using #7Pb;
using #eU;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace #bnb
{
	// Token: 0x0200044B RID: 1099
	internal sealed class #Anb : NotifyPropertyChangedObjectBase
	{
		// Token: 0x06002846 RID: 10310 RVA: 0x000DAED4 File Offset: 0x000D90D4
		public #Anb(#oW #xn)
		{
			this.#b = this.#a;
			this.#d = new #anb(#xn);
			this.#e = new #gnb(#xn);
			this.#f = new #jnb(#xn);
			this.#g = new #Enb(#xn);
		}

		// Token: 0x17000D7F RID: 3455
		// (get) Token: 0x06002847 RID: 10311 RVA: 0x00025259 File Offset: 0x00023459
		// (set) Token: 0x06002848 RID: 10312 RVA: 0x00025265 File Offset: 0x00023465
		public Visibility Visibility
		{
			get
			{
				return this.#c;
			}
			set
			{
				if (this.#c != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107384000));
					this.#c = value;
					base.RaisePropertyChanged(#Phc.#3hc(107384000));
				}
			}
		}

		// Token: 0x17000D80 RID: 3456
		// (get) Token: 0x06002849 RID: 10313 RVA: 0x000252A3 File Offset: 0x000234A3
		// (set) Token: 0x0600284A RID: 10314 RVA: 0x000DAF38 File Offset: 0x000D9138
		public #gQb Active
		{
			get
			{
				return this.#b;
			}
			private set
			{
				if (this.#b != value)
				{
					#gQb #gQb = this.#b;
					if (#gQb != null)
					{
						#gQb.#yl();
					}
					base.RaisePropertyChanging(#Phc.#3hc(107359842));
					this.#b = value;
					base.RaisePropertyChanged(#Phc.#3hc(107359842));
				}
			}
		}

		// Token: 0x17000D81 RID: 3457
		// (get) Token: 0x0600284B RID: 10315 RVA: 0x000252AF File Offset: 0x000234AF
		public #anb Diagram3D { get; }

		// Token: 0x17000D82 RID: 3458
		// (get) Token: 0x0600284C RID: 10316 RVA: 0x000252BB File Offset: 0x000234BB
		public #gnb DiagramMM { get; }

		// Token: 0x17000D83 RID: 3459
		// (get) Token: 0x0600284D RID: 10317 RVA: 0x000252C7 File Offset: 0x000234C7
		public #jnb DiagramPM { get; }

		// Token: 0x17000D84 RID: 3460
		// (get) Token: 0x0600284E RID: 10318 RVA: 0x000252D3 File Offset: 0x000234D3
		public #Enb Section { get; }

		// Token: 0x17000D85 RID: 3461
		// (get) Token: 0x0600284F RID: 10319 RVA: 0x000252DF File Offset: 0x000234DF
		// (set) Token: 0x06002850 RID: 10320 RVA: 0x000252EB File Offset: 0x000234EB
		public #Fnb CoordinatesType { get; private set; }

		// Token: 0x06002851 RID: 10321 RVA: 0x000DAF94 File Offset: 0x000D9194
		public void #5b(#Fnb #C)
		{
			this.CoordinatesType = #C;
			switch (#C)
			{
			case #Fnb.#b:
				this.Active = this.Diagram3D;
				break;
			case #Fnb.#c:
				this.Active = this.DiagramPM;
				break;
			case #Fnb.#d:
				this.Active = this.DiagramMM;
				break;
			case #Fnb.#e:
				this.Active = this.Section;
				break;
			default:
				this.Active = this.#a;
				break;
			}
			this.Visibility = (#C > #Fnb.#a).ToVisibility();
		}

		// Token: 0x04000FE8 RID: 4072
		private readonly #Anb.#E6b #a = new #Anb.#E6b();

		// Token: 0x04000FE9 RID: 4073
		private #gQb #b;

		// Token: 0x04000FEA RID: 4074
		private Visibility #c = Visibility.Collapsed;

		// Token: 0x04000FEB RID: 4075
		[CompilerGenerated]
		private readonly #anb #d;

		// Token: 0x04000FEC RID: 4076
		[CompilerGenerated]
		private readonly #gnb #e;

		// Token: 0x04000FED RID: 4077
		[CompilerGenerated]
		private readonly #jnb #f;

		// Token: 0x04000FEE RID: 4078
		[CompilerGenerated]
		private readonly #Enb #g;

		// Token: 0x04000FEF RID: 4079
		[CompilerGenerated]
		private #Fnb #h;

		// Token: 0x0200044C RID: 1100
		internal sealed class #E6b : #gQb
		{
			// Token: 0x06002852 RID: 10322 RVA: 0x000252FC File Offset: 0x000234FC
			public #E6b() : base(#Phc.#3hc(107380616), Visibility.Visible)
			{
				base.Values.Add(new #nQb());
			}
		}
	}
}
