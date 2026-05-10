using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Units;

namespace #npe
{
	// Token: 0x0200110C RID: 4364
	internal sealed class #mpe
	{
		// Token: 0x060093EB RID: 37867 RVA: 0x00076508 File Offset: 0x00074708
		public static List<StandardBar> #bpe(BarGroupType #WF, UnitSystem #Qg)
		{
			return #mpe.#lpe(#mpe.#cpe(#WF), #WF, #Qg);
		}

		// Token: 0x060093EC RID: 37868 RVA: 0x00076517 File Offset: 0x00074717
		private static List<StandardBar> #cpe(BarGroupType #WF)
		{
			switch (#WF)
			{
			case BarGroupType.ASTM615:
				return #mpe.#dpe();
			case BarGroupType.CSA:
				return #mpe.#epe();
			case BarGroupType.PREN10080:
				return #mpe.#fpe();
			case BarGroupType.ASTM615M:
				return #mpe.#gpe();
			default:
				return new List<StandardBar>();
			}
		}

		// Token: 0x060093ED RID: 37869 RVA: 0x001F7E34 File Offset: 0x001F6034
		private static List<StandardBar> #dpe()
		{
			return new List<StandardBar>
			{
				new StandardBar(3, 0.375f, 0.11f, 0.376f),
				new StandardBar(4, 0.5f, 0.2f, 0.668f),
				new StandardBar(5, 0.625f, 0.31f, 1.043f),
				new StandardBar(6, 0.75f, 0.44f, 1.502f),
				new StandardBar(7, 0.875f, 0.6f, 2.044f),
				new StandardBar(8, 1f, 0.79f, 2.67f),
				new StandardBar(9, 1.128f, 1f, 3.4f),
				new StandardBar(10, 1.27f, 1.27f, 4.303f),
				new StandardBar(11, 1.41f, 1.56f, 5.313f),
				new StandardBar(14, 1.693f, 2.25f, 7.65f),
				new StandardBar(18, 2.257f, 4f, 13.6f)
			};
		}

		// Token: 0x060093EE RID: 37870 RVA: 0x001F7F74 File Offset: 0x001F6174
		private static List<StandardBar> #epe()
		{
			return new List<StandardBar>
			{
				new StandardBar(10, 11.3f, 100f, 0.785f),
				new StandardBar(15, 16f, 200f, 1.57f),
				new StandardBar(20, 19.5f, 300f, 2.356f),
				new StandardBar(25, 25.2f, 500f, 3.925f),
				new StandardBar(30, 29.9f, 700f, 5.495f),
				new StandardBar(35, 35.7f, 1000f, 7.85f),
				new StandardBar(45, 43.7f, 1500f, 11.775f),
				new StandardBar(55, 56.4f, 2500f, 19.625f)
			};
		}

		// Token: 0x060093EF RID: 37871 RVA: 0x001F8068 File Offset: 0x001F6268
		private static List<StandardBar> #fpe()
		{
			return new List<StandardBar>
			{
				new StandardBar(6, 6f, 28.3f, 0.222f),
				new StandardBar(8, 8f, 50.3f, 0.395f),
				new StandardBar(10, 10f, 78.5f, 0.617f),
				new StandardBar(12, 12f, 113f, 0.888f),
				new StandardBar(14, 14f, 154f, 1.208f),
				new StandardBar(16, 16f, 201f, 1.578f),
				new StandardBar(20, 20f, 314f, 2.466f),
				new StandardBar(25, 25f, 491f, 3.853f),
				new StandardBar(28, 28f, 616f, 4.836f),
				new StandardBar(32, 32f, 801f, 6.313f),
				new StandardBar(40, 40f, 1256f, 9.865f)
			};
		}

		// Token: 0x060093F0 RID: 37872 RVA: 0x001F81AC File Offset: 0x001F63AC
		private static List<StandardBar> #gpe()
		{
			return new List<StandardBar>
			{
				new StandardBar(10, 9.5f, 71f, 0.56f),
				new StandardBar(13, 12.7f, 129f, 0.994f),
				new StandardBar(16, 15.9f, 199f, 1.552f),
				new StandardBar(19, 19.1f, 284f, 2.235f),
				new StandardBar(22, 22.2f, 387f, 3.042f),
				new StandardBar(25, 25.4f, 510f, 3.973f),
				new StandardBar(29, 28.7f, 645f, 5.06f),
				new StandardBar(32, 32.3f, 819f, 6.404f),
				new StandardBar(36, 35.8f, 1006f, 7.907f),
				new StandardBar(43, 43f, 1452f, 11.38f),
				new StandardBar(57, 57.3f, 2581f, 20.24f)
			};
		}

		// Token: 0x060093F1 RID: 37873 RVA: 0x001F82F4 File Offset: 0x001F64F4
		private static ValueTuple<float, float> #hpe(BarGroupType #WF, UnitSystem #Qg)
		{
			bool flag = #WF == BarGroupType.ASTM615 && #Qg == UnitSystem.SIMetric;
			bool flag2 = #WF == BarGroupType.CSA && #Qg == UnitSystem.USCustomary;
			bool flag3 = #WF == BarGroupType.PREN10080 && #Qg == UnitSystem.USCustomary;
			bool flag4 = #WF == BarGroupType.ASTM615M && #Qg == UnitSystem.USCustomary;
			if (flag)
			{
				return new ValueTuple<float, float>(25.4f, 1.488164f);
			}
			if (flag2 || flag3 || flag4)
			{
				return new ValueTuple<float, float>(0.03937f, 0.67197f);
			}
			return new ValueTuple<float, float>(1f, 1f);
		}

		// Token: 0x060093F2 RID: 37874 RVA: 0x001F8368 File Offset: 0x001F6568
		private static StandardBar #ipe(StandardBar #rG, float #jpe, float #kpe)
		{
			float diameter = (float)Math.Round((double)(#rG.Diameter * #jpe), 3);
			float area = (float)Math.Round((double)(#rG.Area * #jpe * #jpe), 3);
			float weight = (float)Math.Round((double)(#rG.Weight * #kpe), 3);
			return new StandardBar(#rG.Size, diameter, area, weight);
		}

		// Token: 0x060093F3 RID: 37875 RVA: 0x001F83B8 File Offset: 0x001F65B8
		private static List<StandardBar> #lpe(List<StandardBar> #KJ, BarGroupType #WF, UnitSystem #Qg)
		{
			#mpe.#W9b #W9b = new #mpe.#W9b();
			ValueTuple<float, float> valueTuple = #mpe.#hpe(#WF, #Qg);
			#W9b.#a = valueTuple.Item1;
			#W9b.#b = valueTuple.Item2;
			if (#W9b.#a == 1f && #W9b.#b == 1f)
			{
				return #KJ;
			}
			return #KJ.Select(new Func<StandardBar, StandardBar>(#W9b.#wbf)).ToList<StandardBar>();
		}

		// Token: 0x0200110D RID: 4365
		[CompilerGenerated]
		private sealed class #W9b
		{
			// Token: 0x060093F6 RID: 37878 RVA: 0x00076550 File Offset: 0x00074750
			internal StandardBar #wbf(StandardBar #rG)
			{
				return #mpe.#ipe(#rG, this.#a, this.#b);
			}

			// Token: 0x04003F0D RID: 16141
			public float #a;

			// Token: 0x04003F0E RID: 16142
			public float #b;
		}
	}
}
