using System;
using #9pe;
using #tW;
using #xKe;
using StructurePoint.Products.Column.Services.API;

namespace #QQ
{
	// Token: 0x0200030A RID: 778
	internal sealed class #PQ : #sW
	{
		// Token: 0x06001ADA RID: 6874 RVA: 0x0001A81A File Offset: 0x00018A1A
		public #PQ(ICoreServices #0c)
		{
			this.#a = #0c;
		}

		// Token: 0x06001ADB RID: 6875 RVA: 0x000BDD08 File Offset: 0x000BBF08
		public void #NQ(#jqe #OQ)
		{
			#rLe #rLe = new #rLe();
			#rLe.#NQ(#OQ, this.#a.Project.Model.Options.Unit, this.#a.Project.Model.Options.Code);
		}

		// Token: 0x06001ADC RID: 6876 RVA: 0x000BDD64 File Offset: 0x000BBF64
		public void #4Uh(#Vai #OQ)
		{
			#rLe #rLe = new #rLe();
			#rLe.#4Uh(#OQ, this.#a.Project.Model.Options.Unit, this.#a.Project.Model.Options.Code);
		}

		// Token: 0x06001ADD RID: 6877 RVA: 0x000BDDC0 File Offset: 0x000BBFC0
		public void #5Uh(#Uai #OQ)
		{
			#rLe #rLe = new #rLe();
			#rLe.#5Uh(#OQ, this.#a.Project.Model.Options.Unit, this.#a.Project.Model.Options.Code);
		}

		// Token: 0x04000AB2 RID: 2738
		private readonly ICoreServices #a;
	}
}
