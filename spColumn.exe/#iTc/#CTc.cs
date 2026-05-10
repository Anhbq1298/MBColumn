using System;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls.RibbonToolbar;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #iTc
{
	// Token: 0x02000C6B RID: 3179
	internal abstract class #CTc : #kTc
	{
		// Token: 0x0600666F RID: 26223 RVA: 0x00190720 File Offset: 0x0018E920
		protected #CTc(#hTc #hB)
		{
			#X0d.#V0d(#hB, #Phc.#3hc(107441311), Component.ColumnReporter, #Phc.#3hc(107441254));
			this.#a = new RibbonToolbarButton
			{
				IsEnabled = true,
				Command = #hB.IncreaseRibbonToolbarSizeCommand
			};
			this.#b = new RibbonToolbarButton
			{
				IsEnabled = true,
				Command = #hB.DecreaseRibbonToolbarSizeCommand
			};
		}

		// Token: 0x17001C72 RID: 7282
		// (get) Token: 0x06006670 RID: 26224 RVA: 0x0005255E File Offset: 0x0005075E
		private IRibbonToolbarController LargeHorizontalToolbar
		{
			get
			{
				if (this.#c == null)
				{
					this.#c = this.#vTc();
				}
				return this.#c;
			}
		}

		// Token: 0x17001C73 RID: 7283
		// (get) Token: 0x06006671 RID: 26225 RVA: 0x0005257A File Offset: 0x0005077A
		private IRibbonToolbarController MediumHorizontalToolbar
		{
			get
			{
				if (this.#f == null)
				{
					this.#f = this.#wTc();
				}
				return this.#f;
			}
		}

		// Token: 0x17001C74 RID: 7284
		// (get) Token: 0x06006672 RID: 26226 RVA: 0x00052596 File Offset: 0x00050796
		private IRibbonToolbarController MediumVerticalToolbar
		{
			get
			{
				if (this.#g == null)
				{
					this.#g = this.#xTc();
				}
				return this.#g;
			}
		}

		// Token: 0x17001C75 RID: 7285
		// (get) Token: 0x06006673 RID: 26227 RVA: 0x000525B2 File Offset: 0x000507B2
		private IRibbonToolbarController SmallHorizontalToolbar
		{
			get
			{
				if (this.#d == null)
				{
					this.#d = this.#yTc();
				}
				return this.#d;
			}
		}

		// Token: 0x17001C76 RID: 7286
		// (get) Token: 0x06006674 RID: 26228 RVA: 0x000525CE File Offset: 0x000507CE
		private IRibbonToolbarController SmallVerticalToolbar
		{
			get
			{
				if (this.#e == null)
				{
					this.#e = this.#zTc();
				}
				return this.#e;
			}
		}

		// Token: 0x06006675 RID: 26229
		protected abstract IRibbonToolbarController #vTc();

		// Token: 0x06006676 RID: 26230
		protected abstract IRibbonToolbarController #wTc();

		// Token: 0x06006677 RID: 26231
		protected abstract IRibbonToolbarController #xTc();

		// Token: 0x06006678 RID: 26232
		protected abstract IRibbonToolbarController #yTc();

		// Token: 0x06006679 RID: 26233
		protected abstract IRibbonToolbarController #zTc();

		// Token: 0x0600667A RID: 26234 RVA: 0x0019078C File Offset: 0x0018E98C
		public IRibbonToolbarController #jTc(RibbonToolbarType #C)
		{
			for (;;)
			{
				switch (#C)
				{
				case RibbonToolbarType.SmallHorizontal:
					goto IL_1C;
				case RibbonToolbarType.SmallVertical:
					if (-1 != 0)
					{
						goto Block_1;
					}
					break;
				case RibbonToolbarType.MediumHorizontal:
					goto IL_37;
				case RibbonToolbarType.MediumVertical:
					goto IL_3E;
				case RibbonToolbarType.LargeHorizontal:
					if (8 != 0)
					{
						goto Block_2;
					}
					continue;
				}
				if (!false)
				{
					goto Block_3;
				}
			}
			IL_1C:
			return this.SmallHorizontalToolbar;
			Block_1:
			return this.SmallVerticalToolbar;
			Block_2:
			return this.LargeHorizontalToolbar;
			IL_37:
			return this.MediumHorizontalToolbar;
			IL_3E:
			return this.MediumVerticalToolbar;
			Block_3:
			return this.SmallHorizontalToolbar;
		}

		// Token: 0x0600667B RID: 26235 RVA: 0x000525EA File Offset: 0x000507EA
		protected void #ATc(IRibbonToolbarController #BTc)
		{
			IRibbonToolbarButton increaseToolbarButton = this.#a;
			if (4 != 0)
			{
				#BTc.IncreaseToolbarButton = increaseToolbarButton;
			}
			IRibbonToolbarButton decreaseToolbarButton = this.#b;
			if (4 != 0)
			{
				#BTc.DecreaseToolbarButton = decreaseToolbarButton;
			}
		}

		// Token: 0x04002A34 RID: 10804
		private readonly RibbonToolbarButton #a;

		// Token: 0x04002A35 RID: 10805
		private readonly RibbonToolbarButton #b;

		// Token: 0x04002A36 RID: 10806
		private IRibbonToolbarController #c;

		// Token: 0x04002A37 RID: 10807
		private IRibbonToolbarController #d;

		// Token: 0x04002A38 RID: 10808
		private IRibbonToolbarController #e;

		// Token: 0x04002A39 RID: 10809
		private IRibbonToolbarController #f;

		// Token: 0x04002A3A RID: 10810
		private IRibbonToolbarController #g;
	}
}
