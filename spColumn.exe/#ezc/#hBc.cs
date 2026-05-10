using System;
using System.Diagnostics.CodeAnalysis;
using #7hc;
using #UYd;
using Microsoft.Practices.Unity;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #ezc
{
	// Token: 0x02000B47 RID: 2887
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Ioc")]
	internal sealed class #hBc : IDisposable, #HBc
	{
		// Token: 0x06005E48 RID: 24136 RVA: 0x0004E719 File Offset: 0x0004C919
		public #hBc()
		{
			this.#a = new UnityContainer();
		}

		// Token: 0x06005E49 RID: 24137 RVA: 0x0004E72C File Offset: 0x0004C92C
		[SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Lifetime manager will be disposed with entire UnityContainer.")]
		public void #P<#eBc, #fBc>() where #fBc : !!0
		{
			this.#a.RegisterType(new ContainerControlledLifetimeManager(), new InjectionMember[0]);
		}

		// Token: 0x06005E4A RID: 24138 RVA: 0x0004E745 File Offset: 0x0004C945
		public void #gBc<#eBc, #fBc>() where #fBc : !!0
		{
			this.#a.RegisterType(new PerResolveLifetimeManager(), new InjectionMember[0]);
		}

		// Token: 0x06005E4B RID: 24139 RVA: 0x0004E75E File Offset: 0x0004C95E
		[SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
		public void #P<#eBc, #fBc>(string #wy) where #fBc : !!0
		{
			this.#a.RegisterType(#wy, new ContainerControlledLifetimeManager(), new InjectionMember[0]);
		}

		// Token: 0x06005E4C RID: 24140 RVA: 0x0004E778 File Offset: 0x0004C978
		public void #sy<#Fu>(#Fu #ty)
		{
			if (4 != 0)
			{
				object #Rf = #ty;
				string #R0d = #Phc.#3hc(107418466);
				Component #x6c = Component.GUIFramework;
				string #Qic = #Phc.#3hc(107418485);
				if (!false)
				{
					#X0d.#V0d(#Rf, #R0d, #x6c, #Qic);
				}
				this.#a.RegisterInstance(#ty);
			}
		}

		// Token: 0x06005E4D RID: 24141 RVA: 0x0004E7B4 File Offset: 0x0004C9B4
		public #Fu #vy<#Fu>()
		{
			return this.#a.Resolve(new ResolverOverride[0]);
		}

		// Token: 0x06005E4E RID: 24142 RVA: 0x0004E7C7 File Offset: 0x0004C9C7
		public #Fu #vy<#Fu>(string #wy)
		{
			return this.#a.Resolve(#wy, new ResolverOverride[0]);
		}

		// Token: 0x06005E4F RID: 24143 RVA: 0x0004E7DB File Offset: 0x0004C9DB
		public void #1()
		{
			bool #POb = true;
			if (!false)
			{
				this.#1(#POb);
			}
			if (!false)
			{
				GC.SuppressFinalize(this);
			}
		}

		// Token: 0x06005E50 RID: 24144 RVA: 0x0004E7F7 File Offset: 0x0004C9F7
		protected void #1(bool #POb)
		{
			if (8 != 0 && 5 != 0)
			{
				if (this.#b)
				{
					return;
				}
				if (#POb && 2 != 0)
				{
					IDisposable disposable = this.#a;
					if (-1 != 0)
					{
						disposable.Dispose();
					}
				}
				this.#b = true;
			}
		}

		// Token: 0x04002717 RID: 10007
		private readonly IUnityContainer #a;

		// Token: 0x04002718 RID: 10008
		private bool #b;
	}
}
