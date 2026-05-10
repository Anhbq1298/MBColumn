using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #7hc;
using #wdd;

namespace #FCd
{
	// Token: 0x02000D5F RID: 3423
	internal sealed class #eDd
	{
		// Token: 0x06007C4F RID: 31823 RVA: 0x00064F37 File Offset: 0x00063137
		public #eDd(int #Upb, int #Jhd)
		{
			this.RightCellBorders = new double[#Upb];
			this.BottomCellBorders = new HashSet<int>();
			this.HeaderRowsCount = #Jhd;
			this.#e = #Upb - 1;
		}

		// Token: 0x17002563 RID: 9571
		// (get) Token: 0x06007C50 RID: 31824 RVA: 0x00064F71 File Offset: 0x00063171
		// (set) Token: 0x06007C51 RID: 31825 RVA: 0x00064F7D File Offset: 0x0006317D
		public bool ApplyOuterBorder { get; set; }

		// Token: 0x17002564 RID: 9572
		// (get) Token: 0x06007C52 RID: 31826 RVA: 0x00064F8E File Offset: 0x0006318E
		// (set) Token: 0x06007C53 RID: 31827 RVA: 0x00064F9A File Offset: 0x0006319A
		public int RowsCount { get; set; }

		// Token: 0x17002565 RID: 9573
		// (get) Token: 0x06007C54 RID: 31828 RVA: 0x00064FAB File Offset: 0x000631AB
		// (set) Token: 0x06007C55 RID: 31829 RVA: 0x00064FB7 File Offset: 0x000631B7
		public int HeaderRowsCount
		{
			get
			{
				return this.#f;
			}
			private set
			{
				this.#f = value;
				this.LastHeaderRowIndex = value - 1;
			}
		}

		// Token: 0x17002566 RID: 9574
		// (get) Token: 0x06007C56 RID: 31830 RVA: 0x00064FD5 File Offset: 0x000631D5
		// (set) Token: 0x06007C57 RID: 31831 RVA: 0x00064FE1 File Offset: 0x000631E1
		public int LastHeaderRowIndex { get; private set; }

		// Token: 0x17002567 RID: 9575
		// (get) Token: 0x06007C58 RID: 31832 RVA: 0x00064FF2 File Offset: 0x000631F2
		public bool IsHeaderLess
		{
			get
			{
				return this.HeaderRowsCount <= 0;
			}
		}

		// Token: 0x17002568 RID: 9576
		// (get) Token: 0x06007C59 RID: 31833 RVA: 0x00065008 File Offset: 0x00063208
		// (set) Token: 0x06007C5A RID: 31834 RVA: 0x00065014 File Offset: 0x00063214
		public double[] RightCellBorders { get; private set; }

		// Token: 0x17002569 RID: 9577
		// (get) Token: 0x06007C5B RID: 31835 RVA: 0x00065025 File Offset: 0x00063225
		// (set) Token: 0x06007C5C RID: 31836 RVA: 0x00065031 File Offset: 0x00063231
		public ISet<int> BottomCellBorders { get; private set; }

		// Token: 0x1700256A RID: 9578
		// (get) Token: 0x06007C5D RID: 31837 RVA: 0x00065042 File Offset: 0x00063242
		private int LastRowIndex
		{
			get
			{
				return this.RowsCount - 1;
			}
		}

		// Token: 0x06007C5E RID: 31838 RVA: 0x00065054 File Offset: 0x00063254
		public void #7Cd(int #9bd, double #f)
		{
			this.RightCellBorders[#9bd] = #f;
		}

		// Token: 0x06007C5F RID: 31839 RVA: 0x001B5AEC File Offset: 0x001B3CEC
		public void #4l(int #uI, int #9bd, #SCd #C, double #f)
		{
			switch (#C)
			{
			case #SCd.#a:
				this.#8Cd(#uI, #9bd, null, new double?(#f), null, null);
				return;
			case #SCd.#b:
				this.#8Cd(#uI, #9bd, new double?(#f), null, null, null);
				return;
			case #SCd.#a | #SCd.#b:
				break;
			case #SCd.#c:
				this.#8Cd(#uI, #9bd, null, null, new double?(#f), null);
				return;
			default:
				if (#C == #SCd.#d)
				{
					this.#8Cd(#uI, #9bd, null, null, null, new double?(#f));
					return;
				}
				break;
			}
			throw new ArgumentOutOfRangeException(#Phc.#3hc(107383497), #C, null);
		}

		// Token: 0x06007C60 RID: 31840 RVA: 0x001B5C00 File Offset: 0x001B3E00
		public void #8Cd(int #uI, int #9bd, double? #Sc, double? #ZW, double? #Tc, double? #0W)
		{
			Dictionary<int, #OCd> dictionary;
			if (!this.#d.TryGetValue(#uI, out dictionary))
			{
				dictionary = new Dictionary<int, #OCd>();
				this.#d[#uI] = dictionary;
			}
			#OCd #OCd;
			if (!dictionary.TryGetValue(#9bd, out #OCd))
			{
				#OCd = new #OCd();
				dictionary[#9bd] = #OCd;
			}
			if (#Sc != null)
			{
				#OCd.Left = #Sc.Value;
			}
			if (#ZW != null)
			{
				#OCd.Top = #ZW.Value;
			}
			if (#Tc != null)
			{
				#OCd.Right = #Tc.Value;
			}
			if (#0W != null)
			{
				#OCd.Bottom = #0W.Value;
			}
		}

		// Token: 0x06007C61 RID: 31841 RVA: 0x001B5CC0 File Offset: 0x001B3EC0
		public #OCd #9Cd(int #uI, int #Vpb)
		{
			Dictionary<int, #OCd> dictionary;
			#OCd result;
			if (this.#d.TryGetValue(#uI, out dictionary) && dictionary.TryGetValue(#Vpb, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x06007C62 RID: 31842 RVA: 0x001B5CF8 File Offset: 0x001B3EF8
		public double #aDd(int #uI, int #Vpb)
		{
			#OCd #OCd = this.#9Cd(#uI, #Vpb);
			if (#OCd != null && #OCd.Left > 0.0)
			{
				return #OCd.Left;
			}
			if ((this.IsHeaderLess || this.ApplyOuterBorder) && #Vpb == 0)
			{
				return #2dd.#f;
			}
			return 0.0;
		}

		// Token: 0x06007C63 RID: 31843 RVA: 0x001B5D58 File Offset: 0x001B3F58
		public double #bDd(int #uI, int #Vpb)
		{
			#OCd #OCd = this.#9Cd(#uI, #Vpb);
			if (#OCd != null && #OCd.Bottom > 0.0)
			{
				return #OCd.Bottom;
			}
			if (#uI == this.LastRowIndex || #uI == this.LastHeaderRowIndex)
			{
				return #2dd.#f;
			}
			if (this.IsHeaderLess)
			{
				return #2dd.#d;
			}
			if (this.BottomCellBorders.Contains(#uI))
			{
				return #2dd.#d;
			}
			return 0.0;
		}

		// Token: 0x06007C64 RID: 31844 RVA: 0x001B5DE8 File Offset: 0x001B3FE8
		public double #cDd(int #uI, int #Vpb)
		{
			#OCd #OCd = this.#9Cd(#uI, #Vpb);
			if (#OCd != null && #OCd.Top > 0.0)
			{
				return #OCd.Top;
			}
			if (#uI == 0)
			{
				return #2dd.#f;
			}
			return 0.0;
		}

		// Token: 0x06007C65 RID: 31845 RVA: 0x001B5E38 File Offset: 0x001B4038
		public double #dDd(int #uI, int #Vpb)
		{
			#OCd #OCd = this.#9Cd(#uI, #Vpb);
			if (#OCd != null && #OCd.Right > 0.0)
			{
				return #OCd.Right;
			}
			double num = this.RightCellBorders[#Vpb];
			if (num > 0.0)
			{
				return num;
			}
			if (!this.ApplyOuterBorder && !this.IsHeaderLess)
			{
				return 0.0;
			}
			if (#Vpb != this.#e)
			{
				return 0.0;
			}
			return #2dd.#f;
		}

		// Token: 0x040032F8 RID: 13048
		private const int #a = 0;

		// Token: 0x040032F9 RID: 13049
		private const int #b = 0;

		// Token: 0x040032FA RID: 13050
		private const double #c = 0.0;

		// Token: 0x040032FB RID: 13051
		private readonly Dictionary<int, Dictionary<int, #OCd>> #d = new Dictionary<int, Dictionary<int, #OCd>>();

		// Token: 0x040032FC RID: 13052
		private readonly int #e;

		// Token: 0x040032FD RID: 13053
		private int #f;

		// Token: 0x040032FE RID: 13054
		[CompilerGenerated]
		private bool #g;

		// Token: 0x040032FF RID: 13055
		[CompilerGenerated]
		private int #h;

		// Token: 0x04003300 RID: 13056
		[CompilerGenerated]
		private int #i;

		// Token: 0x04003301 RID: 13057
		[CompilerGenerated]
		private double[] #j;

		// Token: 0x04003302 RID: 13058
		[CompilerGenerated]
		private ISet<int> #k;
	}
}
