using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering
{
	// Token: 0x0200045D RID: 1117
	public class DocumentContentOptionsCore
	{
		// Token: 0x06002929 RID: 10537 RVA: 0x0000C78B File Offset: 0x0000A98B
		public virtual bool #Dcd(Option #bA)
		{
			return false;
		}

		// Token: 0x0600292A RID: 10538 RVA: 0x0001233F File Offset: 0x0001053F
		public virtual Option #qP()
		{
			return null;
		}

		// Token: 0x0600292B RID: 10539 RVA: 0x0001233F File Offset: 0x0001053F
		public virtual Option #Ecd()
		{
			return null;
		}

		// Token: 0x0600292C RID: 10540 RVA: 0x000DE18C File Offset: 0x000DC38C
		public IReadOnlyList<Option> #Fcd()
		{
			return base.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(new Func<PropertyInfo, bool>(DocumentContentOptionsCore.<>c.<>9.#yUd)).ToList<PropertyInfo>().Select(new Func<PropertyInfo, Option>(this.#Hcd)).ToList<Option>();
		}

		// Token: 0x0600292D RID: 10541 RVA: 0x00025C0E File Offset: 0x00023E0E
		public bool #Gcd()
		{
			return this.#Fcd().Any(new Func<Option, bool>(DocumentContentOptionsCore.<>c.<>9.#zUd));
		}

		// Token: 0x0600292F RID: 10543 RVA: 0x00025C46 File Offset: 0x00023E46
		[CompilerGenerated]
		private Option #Hcd(PropertyInfo #Rf)
		{
			return (Option)\u0089\u0002.~\u0087\u0005(#Rf, this, null);
		}
	}
}
