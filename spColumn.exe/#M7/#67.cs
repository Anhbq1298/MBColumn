using System;
using System.Collections.Generic;
using #5Z;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.ViewModels.Loads.Modules;

namespace #M7
{
	// Token: 0x020003C2 RID: 962
	internal static class #67
	{
		// Token: 0x060020E3 RID: 8419 RVA: 0x0002037D File Offset: 0x0001E57D
		public static FactoredLoad #N7()
		{
			return new FactoredLoad
			{
				AxialLoad = 0f,
				MomentX = 0f,
				MomentY = 0f
			};
		}

		// Token: 0x060020E4 RID: 8420 RVA: 0x000C6F10 File Offset: 0x000C5110
		public static #Y3 #O7()
		{
			return new #Y3
			{
				Dead = 100f,
				Earthquake = 0f,
				Live = 0f,
				Snow = 0f,
				Wind = 0f
			};
		}

		// Token: 0x060020E5 RID: 8421 RVA: 0x000203A9 File Offset: 0x0001E5A9
		public static #Y3 #P7()
		{
			return #67.DefaultSustainedLoadFactors;
		}

		// Token: 0x060020E6 RID: 8422 RVA: 0x000203B4 File Offset: 0x0001E5B4
		public static LoadFactor #Q7()
		{
			return #67.#T7(0f, 0f, 0f, 0f, 0f);
		}

		// Token: 0x060020E7 RID: 8423 RVA: 0x000203D8 File Offset: 0x0001E5D8
		public static List<LoadFactor> #R7(DesignCodes #is)
		{
			return #67.LoadFactorDefaultValues[#is];
		}

		// Token: 0x060020E8 RID: 8424 RVA: 0x000203F1 File Offset: 0x0001E5F1
		public static CustomObservableCollection<ServiceLoadParameters> #S7()
		{
			return #67.DefaultServiceLoadsParametersCollection;
		}

		// Token: 0x060020E9 RID: 8425 RVA: 0x000203FC File Offset: 0x0001E5FC
		private static LoadFactor #T7(float #U7, float #V7, float #W7, float #X7, float #Y7)
		{
			return new LoadFactor
			{
				Dead = #U7,
				Live = #V7,
				Wind = #W7,
				Earthquake = #X7,
				Snow = #Y7
			};
		}

		// Token: 0x17000B6A RID: 2922
		// (get) Token: 0x060020EA RID: 8426 RVA: 0x000C6F60 File Offset: 0x000C5160
		private static Dictionary<DesignCodes, List<LoadFactor>> LoadFactorDefaultValues
		{
			get
			{
				return new Dictionary<DesignCodes, List<LoadFactor>>
				{
					{
						DesignCodes.ACI02,
						#67.LoadFactor_ACI02_ACI05_ACI08
					},
					{
						DesignCodes.ACI05,
						#67.LoadFactor_ACI02_ACI05_ACI08
					},
					{
						DesignCodes.ACI08,
						#67.LoadFactor_ACI02_ACI05_ACI08
					},
					{
						DesignCodes.ACI11,
						#67.LoadFactor_ACI11_ACI14_ACI19
					},
					{
						DesignCodes.ACI14,
						#67.LoadFactor_ACI11_ACI14_ACI19
					},
					{
						DesignCodes.ACI19,
						#67.LoadFactor_ACI11_ACI14_ACI19
					},
					{
						DesignCodes.CSA04,
						#67.LoadFactor_CSA_04
					},
					{
						DesignCodes.CSA14,
						#67.LoadFactor_CSA_14_CSA19
					},
					{
						DesignCodes.CSA19,
						#67.LoadFactor_CSA_14_CSA19
					},
					{
						DesignCodes.CSA94,
						#67.LoadFactor_CSA_94
					}
				};
			}
		}

		// Token: 0x17000B6B RID: 2923
		// (get) Token: 0x060020EB RID: 8427 RVA: 0x000C6FF8 File Offset: 0x000C51F8
		private static List<LoadFactor> LoadFactor_ACI02_ACI05_ACI08
		{
			get
			{
				return new List<LoadFactor>
				{
					#67.#T7(1.4f, 0f, 0f, 0f, 0f),
					#67.#T7(1.2f, 1.6f, 0f, 0f, 0.5f),
					#67.#T7(1.2f, 1f, 0f, 0f, 1.6f),
					#67.#T7(1.2f, 0f, 0.8f, 0f, 1.6f),
					#67.#T7(1.2f, 0f, -0.8f, 0f, 1.6f),
					#67.#T7(1.2f, 1f, 1.6f, 0f, 0.5f),
					#67.#T7(1.2f, 1f, -1.6f, 0f, 0.5f),
					#67.#T7(1.2f, 1f, 0f, 1f, 0.2f),
					#67.#T7(1.2f, 1f, 0f, -1f, 0.2f),
					#67.#T7(0.9f, 0f, 1.6f, 0f, 0f),
					#67.#T7(0.9f, 0f, -1.6f, 0f, 0f),
					#67.#T7(0.9f, 0f, 0f, 1f, 0f),
					#67.#T7(0.9f, 0f, 0f, -1f, 0f)
				};
			}
		}

		// Token: 0x17000B6C RID: 2924
		// (get) Token: 0x060020EC RID: 8428 RVA: 0x000C71FC File Offset: 0x000C53FC
		private static List<LoadFactor> LoadFactor_ACI11_ACI14_ACI19
		{
			get
			{
				return new List<LoadFactor>
				{
					#67.#T7(1.4f, 0f, 0f, 0f, 0f),
					#67.#T7(1.2f, 1.6f, 0f, 0f, 0.5f),
					#67.#T7(1.2f, 1f, 0f, 0f, 1.6f),
					#67.#T7(1.2f, 0f, 0.5f, 0f, 1.6f),
					#67.#T7(1.2f, 0f, -0.5f, 0f, 1.6f),
					#67.#T7(1.2f, 1f, 1f, 0f, 0.5f),
					#67.#T7(1.2f, 1f, -1f, 0f, 0.5f),
					#67.#T7(1.2f, 1f, 0f, 1f, 0.2f),
					#67.#T7(1.2f, 1f, 0f, -1f, 0.2f),
					#67.#T7(0.9f, 0f, 1f, 0f, 0f),
					#67.#T7(0.9f, 0f, -1f, 0f, 0f),
					#67.#T7(0.9f, 0f, 0f, 1f, 0f),
					#67.#T7(0.9f, 0f, 0f, -1f, 0f)
				};
			}
		}

		// Token: 0x17000B6D RID: 2925
		// (get) Token: 0x060020ED RID: 8429 RVA: 0x000C7400 File Offset: 0x000C5600
		private static List<LoadFactor> LoadFactor_CSA_14_CSA19
		{
			get
			{
				return new List<LoadFactor>
				{
					#67.#T7(1.4f, 0f, 0f, 0f, 0f),
					#67.#T7(1.25f, 1.5f, 0f, 0f, 1f),
					#67.#T7(0.9f, 1.5f, 0f, 0f, 1f),
					#67.#T7(1.25f, 1.5f, 0.4f, 0f, 0f),
					#67.#T7(1.25f, 1.5f, -0.4f, 0f, 0f),
					#67.#T7(0.9f, 1.5f, 0.4f, 0f, 0f),
					#67.#T7(0.9f, 1.5f, -0.4f, 0f, 0f),
					#67.#T7(1.25f, 1f, 0f, 0f, 1.5f),
					#67.#T7(0.9f, 1f, 0f, 0f, 1.5f),
					#67.#T7(1.25f, 0f, 0.4f, 0f, 1.5f),
					#67.#T7(1.25f, 0f, -0.4f, 0f, 1.5f),
					#67.#T7(0.9f, 0f, 0.4f, 0f, 1.5f),
					#67.#T7(0.9f, 0f, -0.4f, 0f, 1.5f),
					#67.#T7(1.25f, 0.5f, 1.4f, 0f, 0f),
					#67.#T7(1.25f, 0.5f, -1.4f, 0f, 0f),
					#67.#T7(1.25f, 0f, 1.4f, 0f, 0.5f),
					#67.#T7(1.25f, 0f, -1.4f, 0f, 0.5f),
					#67.#T7(0.9f, 0.5f, 1.4f, 0f, 0f),
					#67.#T7(0.9f, 0.5f, -1.4f, 0f, 0f),
					#67.#T7(0.9f, 0f, 1.4f, 0f, 0.5f),
					#67.#T7(0.9f, 0f, -1.4f, 0f, 0.5f),
					#67.#T7(1f, 0.5f, 0f, 1f, 0.25f),
					#67.#T7(1f, 0.5f, 0f, -1f, 0.25f)
				};
			}
		}

		// Token: 0x17000B6E RID: 2926
		// (get) Token: 0x060020EE RID: 8430 RVA: 0x000C776C File Offset: 0x000C596C
		private static List<LoadFactor> LoadFactor_CSA_04
		{
			get
			{
				return new List<LoadFactor>
				{
					#67.#T7(1.4f, 0f, 0f, 0f, 0f),
					#67.#T7(1.25f, 1.5f, 0f, 0f, 0.5f),
					#67.#T7(0.9f, 1.5f, 0f, 0f, 0.5f),
					#67.#T7(1.25f, 1.5f, 0.4f, 0f, 0f),
					#67.#T7(1.25f, 1.5f, -0.4f, 0f, 0f),
					#67.#T7(0.9f, 1.5f, 0.4f, 0f, 0f),
					#67.#T7(0.9f, 1.5f, -0.4f, 0f, 0f),
					#67.#T7(1.25f, 0.5f, 0f, 0f, 1.5f),
					#67.#T7(0.9f, 0.5f, 0f, 0f, 1.5f),
					#67.#T7(1.25f, 0f, 0.4f, 0f, 1.5f),
					#67.#T7(1.25f, 0f, -0.4f, 0f, 1.5f),
					#67.#T7(0.9f, 0f, 0.4f, 0f, 1.5f),
					#67.#T7(0.9f, 0f, -0.4f, 0f, 1.5f),
					#67.#T7(1.25f, 0.5f, 1.4f, 0f, 0f),
					#67.#T7(1.25f, 0.5f, -1.4f, 0f, 0f),
					#67.#T7(1.25f, 0f, 1.4f, 0f, 0.5f),
					#67.#T7(1.25f, 0f, -1.4f, 0f, 0.5f),
					#67.#T7(0.9f, 0.5f, 1.4f, 0f, 0f),
					#67.#T7(0.9f, 0.5f, -1.4f, 0f, 0f),
					#67.#T7(0.9f, 0f, 1.4f, 0f, 0.5f),
					#67.#T7(0.9f, 0f, -1.4f, 0f, 0.5f),
					#67.#T7(1f, 0.5f, 0f, 1f, 0.25f),
					#67.#T7(1f, 0.5f, 0f, -1f, 0.25f)
				};
			}
		}

		// Token: 0x17000B6F RID: 2927
		// (get) Token: 0x060020EF RID: 8431 RVA: 0x000C7AD8 File Offset: 0x000C5CD8
		private static List<LoadFactor> LoadFactor_CSA_94
		{
			get
			{
				return new List<LoadFactor>
				{
					#67.#T7(1.25f, 0f, 0f, 0f, 0f),
					#67.#T7(1.25f, 1.5f, 0f, 0f, 1.5f),
					#67.#T7(0.85f, 1.5f, 0f, 0f, 1.5f),
					#67.#T7(1.25f, 1.05f, 1.05f, 0f, 1.05f),
					#67.#T7(1.25f, 1.05f, -1.05f, 0f, 1.05f),
					#67.#T7(0.85f, 1.05f, 1.05f, 0f, 1.05f),
					#67.#T7(0.85f, 1.05f, -1.05f, 0f, 1.05f),
					#67.#T7(1.25f, 0f, 1.5f, 0f, 0f),
					#67.#T7(1.25f, 0f, -1.5f, 0f, 0f),
					#67.#T7(0.85f, 0f, 1.5f, 0f, 0f),
					#67.#T7(0.85f, 0f, -1.5f, 0f, 0f),
					#67.#T7(1f, 0f, 0f, 1f, 0f),
					#67.#T7(1f, 0f, 0f, -1f, 0f),
					#67.#T7(1f, 0.5f, 0f, 1f, 0.5f),
					#67.#T7(1f, 0.5f, 0f, -1f, 0.5f)
				};
			}
		}

		// Token: 0x17000B70 RID: 2928
		// (get) Token: 0x060020F0 RID: 8432 RVA: 0x000C7D24 File Offset: 0x000C5F24
		private static CustomObservableCollection<ServiceLoadParameters> DefaultServiceLoadsParametersCollection
		{
			get
			{
				return new CustomObservableCollection<ServiceLoadParameters>
				{
					new ServiceLoadParameters
					{
						Name = Strings.StringDead,
						ServiceLoads = new #V3()
					},
					new ServiceLoadParameters
					{
						Name = Strings.StringLive,
						ServiceLoads = new #V3()
					},
					new ServiceLoadParameters
					{
						Name = Strings.StringWind,
						ServiceLoads = new #V3()
					},
					new ServiceLoadParameters
					{
						Name = Strings.StringEq,
						ServiceLoads = new #V3()
					},
					new ServiceLoadParameters
					{
						Name = Strings.StringSnow,
						ServiceLoads = new #V3()
					}
				};
			}
		}

		// Token: 0x17000B71 RID: 2929
		// (get) Token: 0x060020F1 RID: 8433 RVA: 0x000C7DF0 File Offset: 0x000C5FF0
		private static #Y3 DefaultSustainedLoadFactors
		{
			get
			{
				return new #Y3
				{
					Dead = 100f,
					Live = 0f,
					Wind = 0f,
					Earthquake = 0f,
					Snow = 0f
				};
			}
		}
	}
}
