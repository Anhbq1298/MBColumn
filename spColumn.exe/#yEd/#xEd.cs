using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using #5Fd;
using #7hc;
using #FCd;
using #Qcd;
using #wdd;
using Aspose.Words;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;

namespace #yEd
{
	// Token: 0x02000D62 RID: 3426
	internal abstract class #xEd : #ned
	{
		// Token: 0x06007C70 RID: 31856 RVA: 0x000651E1 File Offset: 0x000633E1
		protected #xEd(#HEd #ib)
		{
			this.Children = new List<#xEd>();
			this.Renderer = #ib.Renderer;
			this.Context = #ib;
		}

		// Token: 0x1700256B RID: 9579
		// (get) Token: 0x06007C71 RID: 31857 RVA: 0x00065207 File Offset: 0x00063407
		// (set) Token: 0x06007C72 RID: 31858 RVA: 0x00065213 File Offset: 0x00063413
		public #HEd Context { get; private set; }

		// Token: 0x1700256C RID: 9580
		// (get) Token: 0x06007C73 RID: 31859 RVA: 0x00065224 File Offset: 0x00063424
		// (set) Token: 0x06007C74 RID: 31860 RVA: 0x00065230 File Offset: 0x00063430
		private protected #ldd Renderer { protected get; private set; }

		// Token: 0x1700256D RID: 9581
		// (get) Token: 0x06007C75 RID: 31861 RVA: 0x00065241 File Offset: 0x00063441
		// (set) Token: 0x06007C76 RID: 31862 RVA: 0x0006524D File Offset: 0x0006344D
		private protected List<#xEd> Children { protected get; private set; }

		// Token: 0x06007C77 RID: 31863 RVA: 0x0006525E File Offset: 0x0006345E
		public void #vzc(#xEd #oEd)
		{
			if (#oEd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107251695));
			}
			this.Children.Add(#oEd);
		}

		// Token: 0x06007C78 RID: 31864 RVA: 0x0006528B File Offset: 0x0006348B
		public virtual void #2cd()
		{
			this.Renderer.#2cd();
		}

		// Token: 0x06007C79 RID: 31865
		public abstract void #pEd();

		// Token: 0x06007C7A RID: 31866 RVA: 0x001B5F68 File Offset: 0x001B4168
		protected void #eCd(IEnumerable<string> #wed, bool #qEd)
		{
			IList<string> list;
			if ((list = (#wed as IList<string>)) == null)
			{
				list = #wed.ToList<string>();
			}
			IList<string> list2 = list;
			if (list2.Any<string>())
			{
				for (int i = 0; i < list2.Count; i++)
				{
					string text = list2[i];
					if (!string.Equals(text, Environment.NewLine, StringComparison.OrdinalIgnoreCase))
					{
						this.Context.Renderer.#6cd(text, new StyleIdentifier?(StyleIdentifier.BodyText));
					}
					this.Context.Renderer.#3cd(string.Empty, StyleIdentifier.BodyText, null, null, null);
				}
			}
			if (#qEd)
			{
				this.Context.Renderer.#3cd(string.Empty, StyleIdentifier.NoSpacing, null, null, null);
				return;
			}
			if (list2.Any<string>())
			{
				#ldd #ldd = this.Context.Renderer;
				string empty = string.Empty;
				StyleIdentifier #4cd = StyleIdentifier.User;
				string #5cd = #2dd.NoSpacingSmallStyleKey;
				#ldd.#3cd(empty, #4cd, null, null, #5cd);
			}
		}

		// Token: 0x06007C7B RID: 31867 RVA: 0x001B606C File Offset: 0x001B426C
		protected void #eCd(IEnumerable<string> #wed, bool #qEd, string #rEd)
		{
			List<string> list = #wed.ToList<string>();
			if (list.Any<string>())
			{
				this.#sEd(#Phc.#3hc(107251686), new string[]
				{
					#Phc.#3hc(107409209),
					#rEd
				});
			}
			this.#eCd(list, #qEd);
			if (list.Any<string>())
			{
				this.#vEd(#Phc.#3hc(107251686));
			}
		}

		// Token: 0x06007C7C RID: 31868 RVA: 0x001B60DC File Offset: 0x001B42DC
		private void #sEd(string #tEd, params string[] #uEd)
		{
			if (!this.Context.RenderXmlTestTags)
			{
				return;
			}
			StringBuilder stringBuilder = new StringBuilder();
			if (#uEd != null && #uEd.Length != 0)
			{
				if (#uEd.Length % 2 != 0)
				{
					throw new ArgumentOutOfRangeException(#Phc.#3hc(107251709));
				}
				for (int i = 0; i < #uEd.Length; i += 2)
				{
					\u009B\u0003.~\u0017\u0008(stringBuilder, #Phc.#3hc(107251660), #uEd[i], #uEd[i + 1]);
				}
			}
			this.Renderer.#rGd(#tEd, \u007F.~\u0012\u0002(\u007F.~\u0011\u0002(stringBuilder)));
		}

		// Token: 0x06007C7D RID: 31869 RVA: 0x000652A4 File Offset: 0x000634A4
		private void #vEd(string #tEd)
		{
			if (!this.Context.RenderXmlTestTags)
			{
				return;
			}
			this.Renderer.#sGd(#tEd);
		}

		// Token: 0x06007C7E RID: 31870 RVA: 0x001B6184 File Offset: 0x001B4384
		protected void #Rcd(#uDd #Xpb, string #wy)
		{
			this.#sEd(#Phc.#3hc(107251675), new string[]
			{
				#Phc.#3hc(107409209),
				#wy
			});
			this.#Rcd(#Xpb);
			this.#vEd(#Phc.#3hc(107251675));
		}

		// Token: 0x06007C7F RID: 31871 RVA: 0x000652CC File Offset: 0x000634CC
		protected void #Rcd(#uDd #Xpb)
		{
			this.Renderer.#Rcd(#Xpb);
		}

		// Token: 0x06007C80 RID: 31872 RVA: 0x000652E6 File Offset: 0x000634E6
		protected void #Scd(Option #bA)
		{
			this.#Scd(#bA.BookmarkName, #Phc.#3hc(107399922));
		}

		// Token: 0x06007C81 RID: 31873 RVA: 0x001B61DC File Offset: 0x001B43DC
		protected void #wEd()
		{
			if (this.Children.Any<#xEd>())
			{
				foreach (#xEd #xEd in this.Children)
				{
					this.Context.#GEd();
					#xEd.#pEd();
				}
			}
		}

		// Token: 0x06007C82 RID: 31874 RVA: 0x0006530A File Offset: 0x0006350A
		private void #Scd(string #Tcd, string #Ukc = " ")
		{
			this.Renderer.#Scd(#Tcd, #Ukc);
		}

		// Token: 0x04003303 RID: 13059
		[CompilerGenerated]
		private #HEd #a;

		// Token: 0x04003304 RID: 13060
		[CompilerGenerated]
		private #ldd #b;

		// Token: 0x04003305 RID: 13061
		[CompilerGenerated]
		private List<#xEd> #c;
	}
}
