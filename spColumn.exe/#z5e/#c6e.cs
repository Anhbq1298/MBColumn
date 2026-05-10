using System;
using System.Runtime.CompilerServices;
using #Gke;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace #z5e
{
	// Token: 0x0200132E RID: 4910
	internal class #c6e
	{
		// Token: 0x0600A3F9 RID: 41977 RVA: 0x0022F3C4 File Offset: 0x0022D5C4
		public #c6e(DesignReinforcement #B0e, ColumnStorageModel #hMe) : this()
		{
			switch (#hMe.Options.DesignReinforcement)
			{
			case ReinforcementType.Undefined:
			case ReinforcementType.Irregular:
				return;
			case ReinforcementType.AllEqual:
				if (((#B0e != null) ? #B0e.AllEqual : null) == null)
				{
					goto IL_1AD;
				}
				break;
			case ReinforcementType.EqualSpace:
				if (((#B0e != null) ? #B0e.AllEqual : null) == null)
				{
					goto IL_1AD;
				}
				break;
			case ReinforcementType.Different:
				if (((#B0e != null) ? #B0e.Different : null) != null)
				{
					this.AmountOfBars[0] = #B0e.Different.MinTopBottomNumberOfBars;
					this.AmountOfBars[1] = #B0e.Different.MaxTopBottomNumberOfBars;
					this.AmountOfBars[2] = #B0e.Different.MinLeftRightNumberOfBars;
					this.AmountOfBars[3] = #B0e.Different.MaxLeftRightNumberOfBars;
					this.BarNumber[0] = #B0e.Different.MinTopBottomBarSize;
					this.BarNumber[1] = #B0e.Different.MaxTopBottomBarSize;
					this.BarNumber[2] = #B0e.Different.MinLeftRightBarSize;
					this.BarNumber[3] = #B0e.Different.MaxLeftRightBarSize;
					this.ClearCover[0] = #B0e.Different.TopBottomClearCover;
					this.ClearCover[1] = #B0e.Different.TopBottomClearCover;
					this.ClearCover[2] = #B0e.Different.LeftRightClearCover;
					this.ClearCover[3] = #B0e.Different.LeftRightClearCover;
					return;
				}
				goto IL_1AD;
			default:
				goto IL_1AD;
			}
			this.BarNumber[0] = #B0e.AllEqual.MinBarSize;
			this.BarNumber[1] = #B0e.AllEqual.MaxBarSize;
			this.AmountOfBars[0] = #B0e.AllEqual.MinNumberOfBars;
			this.AmountOfBars[1] = #B0e.AllEqual.MaxNumberOfBars;
			this.ClearCover[0] = #B0e.AllEqual.ClearCover;
			return;
			IL_1AD:
			throw new ArgumentOutOfRangeException();
		}

		// Token: 0x0600A3FA RID: 41978 RVA: 0x0022F584 File Offset: 0x0022D784
		public #c6e(InvestigationReinforcement #B0e, ColumnStorageModel #hMe) : this()
		{
			switch (#hMe.Options.InvestigationReinforcement)
			{
			case ReinforcementType.Undefined:
			case ReinforcementType.Irregular:
				return;
			case ReinforcementType.AllEqual:
				if (((#B0e != null) ? #B0e.AllEqual : null) == null)
				{
					goto IL_1EA;
				}
				break;
			case ReinforcementType.EqualSpace:
				if (((#B0e != null) ? #B0e.AllEqual : null) == null)
				{
					goto IL_1EA;
				}
				break;
			case ReinforcementType.Different:
				if (((#B0e != null) ? #B0e.Different : null) != null)
				{
					this.AmountOfBars[0] = #B0e.Different.TopNumberOfBars;
					this.AmountOfBars[1] = #B0e.Different.BottomNumberOfBars;
					this.AmountOfBars[2] = #B0e.Different.LeftNumberOfBars;
					this.AmountOfBars[3] = #B0e.Different.RightNumberOfBars;
					this.BarNumber[0] = #B0e.Different.TopBarSize;
					this.BarNumber[1] = #B0e.Different.BottomBarSize;
					this.BarNumber[2] = #B0e.Different.LeftBarSize;
					this.BarNumber[3] = #B0e.Different.RightBarSize;
					this.ClearCover[0] = #B0e.Different.TopClearCover;
					this.ClearCover[1] = #B0e.Different.BottomClearCover;
					this.ClearCover[2] = #B0e.Different.LeftClearCover;
					this.ClearCover[3] = #B0e.Different.RightClearCover;
					return;
				}
				goto IL_1EA;
			default:
				goto IL_1EA;
			}
			this.AmountOfBars[0] = (this.AmountOfBars[1] = (this.AmountOfBars[2] = (this.AmountOfBars[3] = #B0e.AllEqual.NumberOfBars)));
			this.BarNumber[0] = (this.BarNumber[1] = (this.BarNumber[2] = (this.BarNumber[3] = #B0e.AllEqual.BarSize)));
			this.ClearCover[0] = (this.ClearCover[1] = (this.ClearCover[2] = (this.ClearCover[3] = #B0e.AllEqual.ClearCover)));
			return;
			IL_1EA:
			throw new ArgumentOutOfRangeException();
		}

		// Token: 0x0600A3FB RID: 41979 RVA: 0x0008013E File Offset: 0x0007E33E
		public #c6e()
		{
			this.AmountOfBars = new int[4];
			this.BarNumber = new int[4];
			this.ClearCover = new float[4];
		}

		// Token: 0x17002F0A RID: 12042
		// (get) Token: 0x0600A3FC RID: 41980 RVA: 0x0008016A File Offset: 0x0007E36A
		// (set) Token: 0x0600A3FD RID: 41981 RVA: 0x00080172 File Offset: 0x0007E372
		public int[] AmountOfBars { get; protected set; }

		// Token: 0x17002F0B RID: 12043
		// (get) Token: 0x0600A3FE RID: 41982 RVA: 0x0008017B File Offset: 0x0007E37B
		// (set) Token: 0x0600A3FF RID: 41983 RVA: 0x00080183 File Offset: 0x0007E383
		public int[] BarNumber { get; protected set; }

		// Token: 0x17002F0C RID: 12044
		// (get) Token: 0x0600A400 RID: 41984 RVA: 0x0008018C File Offset: 0x0007E38C
		public float[] ClearCover { get; }

		// Token: 0x0600A401 RID: 41985 RVA: 0x00080194 File Offset: 0x0007E394
		public static #c6e #Dge(#c6e #L0)
		{
			#c6e #c6e = new #c6e();
			#c6e.#mg(#L0);
			return #c6e;
		}

		// Token: 0x0600A402 RID: 41986 RVA: 0x0022F784 File Offset: 0x0022D984
		internal void #mg(#Rle #L0)
		{
			Array.Copy(#L0.#a, this.AmountOfBars, this.AmountOfBars.Length);
			Array.Copy(#L0.#b, this.BarNumber, this.BarNumber.Length);
			Array.Copy(#L0.#c, this.ClearCover, this.ClearCover.Length);
		}

		// Token: 0x0600A403 RID: 41987 RVA: 0x0022F7DC File Offset: 0x0022D9DC
		public void #mg(#c6e #L0)
		{
			Array.Copy(#L0.AmountOfBars, this.AmountOfBars, this.AmountOfBars.Length);
			Array.Copy(#L0.BarNumber, this.BarNumber, this.BarNumber.Length);
			Array.Copy(#L0.ClearCover, this.ClearCover, this.ClearCover.Length);
		}

		// Token: 0x040047D5 RID: 18389
		public const int #a = 0;

		// Token: 0x040047D6 RID: 18390
		public const int #b = 1;

		// Token: 0x040047D7 RID: 18391
		public const int #c = 2;

		// Token: 0x040047D8 RID: 18392
		public const int #d = 3;

		// Token: 0x040047D9 RID: 18393
		[CompilerGenerated]
		private int[] #e;

		// Token: 0x040047DA RID: 18394
		[CompilerGenerated]
		private int[] #f;

		// Token: 0x040047DB RID: 18395
		[CompilerGenerated]
		private readonly float[] #g;
	}
}
