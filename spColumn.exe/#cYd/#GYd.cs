using System;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #cYd
{
	// Token: 0x02000EB9 RID: 3769
	internal sealed class #GYd : #FYd
	{
		// Token: 0x06008619 RID: 34329 RVA: 0x0006D319 File Offset: 0x0006B519
		public #GYd(string #So, string #Qic, Component #Ric, #IYd #Sic) : this(#So, #Qic, #Ric, #Sic, #JYd.#e)
		{
		}

		// Token: 0x0600861A RID: 34330 RVA: 0x0006D32B File Offset: 0x0006B52B
		public #GYd(string #So, string #Qic, Component #Ric, #IYd #Sic, #JYd #Tic) : base(Strings.StringFileWithTheSpecifiedPathWasNotFound.#u2d(true) + #So.#z2d(), #Qic, #Ric, #Sic, #Tic)
		{
		}
	}
}
