using System;
using System.Runtime.CompilerServices;
using #n8;
using StructurePoint.Products.Column.Model.Entities;

namespace StructurePoint.Products.Column.ViewModels.Loads.Modules
{
	// Token: 0x02000201 RID: 513
	internal sealed class LoadGroup : ValidatableBaseEntity, #G8
	{
		// Token: 0x06001186 RID: 4486 RVA: 0x0001376A File Offset: 0x0001196A
		public LoadGroup()
		{
			this.#a = new ServiceLoad();
		}

		// Token: 0x06001187 RID: 4487 RVA: 0x0001377D File Offset: 0x0001197D
		public LoadGroup(ServiceLoad serviceLoad)
		{
			this.#a = serviceLoad;
		}

		// Token: 0x06001188 RID: 4488 RVA: 0x0001378C File Offset: 0x0001198C
		public LoadGroup(LoadGroup other)
		{
			this.#a = new ServiceLoad(other.ServiceLoad);
		}

		// Token: 0x1700067B RID: 1659
		// (get) Token: 0x06001189 RID: 4489 RVA: 0x000137A5 File Offset: 0x000119A5
		public ServiceLoad ServiceLoad { get; }

		// Token: 0x1700067C RID: 1660
		// (get) Token: 0x0600118A RID: 4490 RVA: 0x000137B1 File Offset: 0x000119B1
		public override bool HasErrors
		{
			get
			{
				return this.#QC(this.ServiceLoad);
			}
		}

		// Token: 0x0600118B RID: 4491 RVA: 0x000A8F34 File Offset: 0x000A7134
		private bool #QC(ServiceLoad #RC)
		{
			return #RC.HasErrors || #RC.Dead.HasErrors || #RC.Live.HasErrors || #RC.Wind.HasErrors || #RC.Snow.HasErrors || #RC.Earthquake.HasErrors;
		}

		// Token: 0x040006E8 RID: 1768
		[CompilerGenerated]
		private readonly ServiceLoad #a;
	}
}
