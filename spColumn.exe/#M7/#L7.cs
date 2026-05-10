using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #5Z;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.Products.Column.Model.Entities;

namespace #M7
{
	// Token: 0x020003C1 RID: 961
	internal sealed class #L7
	{
		// Token: 0x060020DE RID: 8414 RVA: 0x000C6D98 File Offset: 0x000C4F98
		public static #K2 #I7()
		{
			#K2 #K = new #K2();
			#K.Fcp = 4f;
			#K.Ec = 3745.85f;
			#K.Fc = 3.23452f;
			#K.Beta1 = 0.90105f;
			#K.Eps = 0.0035f;
			#K.Fy = 60f;
			#K.Es = 29000f;
			#K.IsConcreteStandard = true;
			#K.IsSteelStandard = true;
			#K.Precast = true;
			float eyt = 0.002069f;
			if (2 != 0)
			{
				#K.Eyt = eyt;
			}
			return #K;
		}

		// Token: 0x060020DF RID: 8415 RVA: 0x000C6E20 File Offset: 0x000C5020
		public static #K2 #J7()
		{
			#K2 #K = new #K2();
			#K.Fcp = 4f;
			#K.Ec = 3605f;
			#K.Fc = 3.4f;
			#K.Beta1 = 849999940f;
			#K.Eps = 0.003f;
			#K.Fy = 60f;
			#K.Es = 29000f;
			#K.IsConcreteStandard = true;
			#K.IsSteelStandard = true;
			#K.Precast = true;
			float eyt = 0.0020689655f;
			if (2 != 0)
			{
				#K.Eyt = eyt;
			}
			return #K;
		}

		// Token: 0x17000B69 RID: 2921
		// (get) Token: 0x060020E0 RID: 8416 RVA: 0x00020376 File Offset: 0x0001E576
		public static Dictionary<ColumnType, ReinforcementRatios> ReinforcementRatioDefaults { get; } = new Dictionary<ColumnType, ReinforcementRatios>
		{
			{
				ColumnType.Structural,
				new ReinforcementRatios
				{
					MinReinforcementRatio = 0.01f,
					MaxReinforcementRatio = 0.08f
				}
			},
			{
				ColumnType.Architectural,
				new ReinforcementRatios
				{
					MinReinforcementRatio = 0.005f,
					MaxReinforcementRatio = 0.08f
				}
			}
		};

		// Token: 0x04000D48 RID: 3400
		[CompilerGenerated]
		private static readonly Dictionary<ColumnType, ReinforcementRatios> #a;
	}
}
