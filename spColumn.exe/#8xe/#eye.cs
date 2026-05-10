using System;
using System.Collections.Generic;
using #7hc;
using #FCd;
using #hye;
using #Qcd;
using #Wse;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Tables;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace #8xe
{
	// Token: 0x0200119D RID: 4509
	internal sealed class #eye : #mdd
	{
		// Token: 0x06009908 RID: 39176 RVA: 0x0020335C File Offset: 0x0020155C
		public #eye(#lte #Od)
		{
			if (#Od == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399786));
			}
			this.#a = #Od;
		}

		// Token: 0x06009909 RID: 39177 RVA: 0x002036B0 File Offset: 0x002018B0
		public int[] #3hc(#uDd #Xpb)
		{
			Type type = #Xpb.GetType();
			int[] array = this.#b.#F1d(type);
			if (array != null)
			{
				return array;
			}
			Options options = this.#a.Input.Options;
			if (options.ConsideredAxis == ConsideredAxis.Both)
			{
				if (options.IsACI())
				{
					return this.#d.#F1d(type);
				}
				return this.#f.#F1d(type);
			}
			else
			{
				if (options.IsACI())
				{
					return this.#c.#F1d(type);
				}
				return this.#e.#F1d(type);
			}
		}

		// Token: 0x040041B0 RID: 16816
		private readonly #lte #a;

		// Token: 0x040041B1 RID: 16817
		private readonly Dictionary<Type, int[]> #b = new Dictionary<Type, int[]>
		{
			{
				typeof(#vye),
				new int[]
				{
					215,
					325
				}
			},
			{
				typeof(#Aye),
				new int[]
				{
					215,
					200,
					90
				}
			},
			{
				typeof(#Bye),
				new int[]
				{
					215,
					200,
					90
				}
			},
			{
				typeof(#Rye),
				new int[]
				{
					215,
					200,
					90
				}
			},
			{
				typeof(#Qye),
				new int[]
				{
					100,
					100,
					100
				}
			},
			{
				typeof(#Iye),
				new int[]
				{
					100,
					100,
					100
				}
			},
			{
				typeof(#Lye),
				new int[]
				{
					280,
					200,
					90
				}
			},
			{
				typeof(#Nye),
				new int[]
				{
					215,
					200,
					90
				}
			},
			{
				typeof(#Wye),
				new int[]
				{
					100,
					100,
					100,
					20
				}
			},
			{
				typeof(#Kye),
				new int[]
				{
					50,
					50,
					50,
					70
				}
			},
			{
				typeof(#yye),
				new int[]
				{
					100,
					100,
					100
				}
			},
			{
				typeof(LoadingLoadCombinationsTable),
				new int[]
				{
					100,
					100,
					100,
					100,
					100,
					100
				}
			},
			{
				typeof(LoadingServiceLoadsTable),
				new int[]
				{
					100,
					100,
					100,
					100,
					100,
					100,
					100
				}
			},
			{
				typeof(#Vye),
				new int[]
				{
					215,
					200
				}
			},
			{
				typeof(#Uye),
				new int[]
				{
					110,
					110,
					110,
					110,
					110,
					110,
					110,
					110
				}
			},
			{
				typeof(#Sye),
				new int[]
				{
					120,
					120,
					120,
					120,
					120,
					120,
					120
				}
			},
			{
				typeof(#Gye),
				new int[]
				{
					300,
					200,
					90
				}
			},
			{
				typeof(#Eye),
				new int[]
				{
					100,
					100,
					100,
					100,
					100,
					100
				}
			}
		};

		// Token: 0x040041B2 RID: 16818
		private readonly Dictionary<Type, int[]> #c = new Dictionary<Type, int[]>
		{
			{
				typeof(ControlPointsTable),
				new int[]
				{
					50,
					215,
					100,
					100,
					100,
					100,
					100,
					100,
					100,
					20
				}
			}
		};

		// Token: 0x040041B3 RID: 16819
		private readonly Dictionary<Type, int[]> #d = new Dictionary<Type, int[]>
		{
			{
				typeof(ControlPointsTable),
				new int[]
				{
					50,
					215,
					100,
					100,
					100,
					100,
					100,
					100,
					100,
					20
				}
			}
		};

		// Token: 0x040041B4 RID: 16820
		private readonly Dictionary<Type, int[]> #e = new Dictionary<Type, int[]>
		{
			{
				typeof(ControlPointsTable),
				new int[]
				{
					50,
					215,
					100,
					100,
					100,
					100,
					100,
					100,
					20
				}
			}
		};

		// Token: 0x040041B5 RID: 16821
		private readonly Dictionary<Type, int[]> #f = new Dictionary<Type, int[]>
		{
			{
				typeof(ControlPointsTable),
				new int[]
				{
					50,
					215,
					100,
					100,
					100,
					100,
					100,
					100,
					20
				}
			}
		};
	}
}
