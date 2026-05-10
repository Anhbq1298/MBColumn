using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using #8Cc;

namespace #TCc
{
	// Token: 0x02000B69 RID: 2921
	internal class #5Cc : #3Cc
	{
		// Token: 0x06005F41 RID: 24385 RVA: 0x0004F09F File Offset: 0x0004D29F
		public #5Cc(#bDc #DJ) : base(#DJ)
		{
		}

		// Token: 0x06005F42 RID: 24386 RVA: 0x0004F0A8 File Offset: 0x0004D2A8
		[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate")]
		[SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
		public new void #PCc(object #Zr, object #0r, [CallerMemberName] string #em = null)
		{
			if (!false)
			{
				base.#PCc(#Zr, #0r, #em);
			}
		}

		// Token: 0x06005F43 RID: 24387 RVA: 0x0004F0BC File Offset: 0x0004D2BC
		[SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
		[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate")]
		public new void #OCc(object #Zr, object #0r, [CallerMemberName] string #em = null)
		{
			if (!false)
			{
				base.#OCc(#Zr, #0r, #em);
			}
		}

		// Token: 0x06005F44 RID: 24388 RVA: 0x0004F0D0 File Offset: 0x0004D2D0
		[SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
		[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate")]
		public void #1gc([CallerMemberName] string #em = null)
		{
			if (!false)
			{
				base.RaisePropertyChanged(#em);
			}
		}

		// Token: 0x06005F45 RID: 24389 RVA: 0x0004F0E0 File Offset: 0x0004D2E0
		[SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
		[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate")]
		public void #4Cc([CallerMemberName] string #em = null)
		{
			if (!false)
			{
				base.RaisePropertyChanging(#em);
			}
		}
	}
}
