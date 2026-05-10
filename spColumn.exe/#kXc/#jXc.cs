using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.GUI.Framework.Model.Entities;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #kXc
{
	// Token: 0x02000C95 RID: 3221
	internal sealed class #jXc
	{
		// Token: 0x06006835 RID: 26677 RVA: 0x001953E8 File Offset: 0x001935E8
		public #jXc(IEnumerable<ShapeDataModel> #lXc, IEnumerable<ShapeDataModel> #lBb)
		{
			#X0d.#V0d(#lXc, #Phc.#3hc(107439580), Component.GUIFramework, #Phc.#3hc(107439531));
			#X0d.#V0d(#lBb, #Phc.#3hc(107439510), Component.GUIFramework, #Phc.#3hc(107439461));
			this.SourceShapes = #lXc;
			this.ResultShapes = #lBb;
		}

		// Token: 0x06006836 RID: 26678 RVA: 0x00195444 File Offset: 0x00193644
		public #jXc(ShapeDataModel #mXc, IEnumerable<ShapeDataModel> #lBb)
		{
			#X0d.#V0d(#mXc, #Phc.#3hc(107439440), Component.GUIFramework, #Phc.#3hc(107439423));
			#X0d.#V0d(#lBb, #Phc.#3hc(107439510), Component.GUIFramework, #Phc.#3hc(107438826));
			this.SourceShapes = new List<ShapeDataModel>
			{
				#mXc
			};
			this.ResultShapes = #lBb;
		}

		// Token: 0x06006837 RID: 26679 RVA: 0x0005306F File Offset: 0x0005126F
		public #jXc(IEnumerable<ShapeDataModel> #lBb)
		{
			#X0d.#V0d(#lBb, #Phc.#3hc(107438805), Component.GUIFramework, #Phc.#3hc(107438756));
			this.SourceShapes = new List<ShapeDataModel>();
			this.ResultShapes = new List<ShapeDataModel>(#lBb);
		}

		// Token: 0x17001CDA RID: 7386
		// (get) Token: 0x06006838 RID: 26680 RVA: 0x000530AA File Offset: 0x000512AA
		// (set) Token: 0x06006839 RID: 26681 RVA: 0x000530B2 File Offset: 0x000512B2
		public IEnumerable<ShapeDataModel> SourceShapes { get; private set; }

		// Token: 0x17001CDB RID: 7387
		// (get) Token: 0x0600683A RID: 26682 RVA: 0x000530BB File Offset: 0x000512BB
		// (set) Token: 0x0600683B RID: 26683 RVA: 0x000530C3 File Offset: 0x000512C3
		public IEnumerable<ShapeDataModel> ResultShapes { get; private set; }

		// Token: 0x04002ADE RID: 10974
		[CompilerGenerated]
		private IEnumerable<ShapeDataModel> #a;

		// Token: 0x04002ADF RID: 10975
		[CompilerGenerated]
		private IEnumerable<ShapeDataModel> #b;
	}
}
