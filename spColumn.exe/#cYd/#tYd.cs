using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #cYd
{
	// Token: 0x02000EB6 RID: 3766
	[SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors")]
	internal sealed class #tYd : #FYd
	{
		// Token: 0x0600860E RID: 34318 RVA: 0x0006D288 File Offset: 0x0006B488
		public #tYd(string #Sb, string #Qic, string #5, Component #Ric, #IYd #Sic) : this(#Sb, #5, #Qic, #Ric, #Sic, #JYd.#b)
		{
		}

		// Token: 0x0600860F RID: 34319 RVA: 0x0006D29C File Offset: 0x0006B49C
		public #tYd(string #Sb, string #5, string #Qic, Component #Ric, #IYd #Sic, #JYd #Tic) : base(#5 + Strings.StringInvalidParameter.#D2d(new object[]
		{
			#Sb
		}).#z2d(true), #Qic, #Ric, #Sic, #Tic)
		{
			this.MessageWithoutParameterInfo = #5;
		}

		// Token: 0x17002811 RID: 10257
		// (get) Token: 0x06008610 RID: 34320 RVA: 0x0006D2D2 File Offset: 0x0006B4D2
		// (set) Token: 0x06008611 RID: 34321 RVA: 0x0006D2DA File Offset: 0x0006B4DA
		public string MessageWithoutParameterInfo { get; private set; }

		// Token: 0x04003756 RID: 14166
		[CompilerGenerated]
		private string #a;
	}
}
