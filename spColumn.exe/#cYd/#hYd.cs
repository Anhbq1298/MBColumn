using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #cYd
{
	// Token: 0x02000EAF RID: 3759
	internal class #hYd : #FYd
	{
		// Token: 0x060085F2 RID: 34290 RVA: 0x0006D10C File Offset: 0x0006B30C
		public #hYd(string #Sb, string #Qic, string #5, Component #Ric, #IYd #Sic) : this(#Sb, #5, #Qic, #Ric, #Sic, #JYd.#b)
		{
		}

		// Token: 0x060085F3 RID: 34291 RVA: 0x0006D120 File Offset: 0x0006B320
		public #hYd(string #Sb, string #5, string #Qic, Component #Ric, #IYd #Sic, #JYd #Tic) : base(#5 + Strings.StringInvalidParameter.#D2d(new object[]
		{
			#Sb
		}).#z2d(true), #Qic, #Ric, #Sic, #Tic)
		{
			this.MessageWithoutParameterInfo = #5;
		}

		// Token: 0x1700280E RID: 10254
		// (get) Token: 0x060085F4 RID: 34292 RVA: 0x0006D156 File Offset: 0x0006B356
		// (set) Token: 0x060085F5 RID: 34293 RVA: 0x0006D15E File Offset: 0x0006B35E
		public string MessageWithoutParameterInfo { get; private set; }

		// Token: 0x04003750 RID: 14160
		[CompilerGenerated]
		private string #a;
	}
}
