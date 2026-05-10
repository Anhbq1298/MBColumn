using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using #7hc;
using #UYd;
using #v1c;
using Alphaleonis.Win32.Filesystem;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace #LQc
{
	// Token: 0x02000C43 RID: 3139
	internal abstract class #hSc : #cSc
	{
		// Token: 0x060065AE RID: 26030 RVA: 0x00051F6D File Offset: 0x0005016D
		protected #hSc(#v2c #my)
		{
			this.FileSystemService = #my;
		}

		// Token: 0x17001C59 RID: 7257
		// (get) Token: 0x060065AF RID: 26031 RVA: 0x00051F7C File Offset: 0x0005017C
		public #v2c FileSystemService { get; }

		// Token: 0x060065B0 RID: 26032
		public abstract string #9Rc(HelpID #PRc);

		// Token: 0x060065B1 RID: 26033
		public abstract string #aSc();

		// Token: 0x060065B2 RID: 26034 RVA: 0x0018F428 File Offset: 0x0018D628
		public virtual string #bSc(HelpID #PRc)
		{
			do
			{
				string #R0d = #Phc.#3hc(107443034);
				Component #x6c = Component.GUIFramework;
				string #Qic = #Phc.#3hc(107442468);
				if (!false)
				{
					#X0d.#V0d(#PRc, #R0d, #x6c, #Qic);
				}
			}
			while (false);
			return #Phc.#3hc(107441903).#D2d(new object[]
			{
				#PRc.Identifier
			});
		}

		// Token: 0x060065B3 RID: 26035 RVA: 0x0018F47C File Offset: 0x0018D67C
		public virtual string #9Rc(HelpID #PRc, string #eSc, string #fSc)
		{
			string text = this.#aSc();
			string text2;
			if (-1 != 0)
			{
				text2 = text;
			}
			if (this.FileSystemService.#V1c(text2))
			{
				return #Phc.#3hc(107441858).#D2d(new object[]
				{
					text2,
					this.#bSc(#PRc)
				});
			}
			return #Phc.#3hc(107441833).#D2d(new object[]
			{
				#eSc,
				this.#bSc(#PRc),
				#fSc
			});
		}

		// Token: 0x060065B4 RID: 26036 RVA: 0x0018F4F0 File Offset: 0x0018D6F0
		public virtual string #aSc(string #gSc, string #eSc)
		{
			Assembly assembly;
			if (4 != 0)
			{
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				if (!false)
				{
					assembly = executingAssembly;
				}
				if (4 == 0)
				{
					goto IL_3D;
				}
				if (!true)
				{
					goto IL_45;
				}
				if (assembly == null || string.IsNullOrWhiteSpace(assembly.Location))
				{
					return string.Empty;
				}
			}
			string directoryName = Path.GetDirectoryName(assembly.Location);
			string text;
			if (8 != 0)
			{
				text = directoryName;
			}
			IL_3D:
			if (!string.IsNullOrWhiteSpace(text))
			{
				return Path.Combine(new string[]
				{
					text,
					#gSc,
					#eSc
				});
			}
			IL_45:
			return string.Empty;
		}

		// Token: 0x040029C3 RID: 10691
		[CompilerGenerated]
		private readonly #v2c #a;
	}
}
