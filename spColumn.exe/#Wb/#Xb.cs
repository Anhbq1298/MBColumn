using System;
using System.Collections;
using System.Globalization;
using System.Windows.Data;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #Wb
{
	// Token: 0x0200006D RID: 109
	internal sealed class #Xb : IMultiValueConverter
	{
		// Token: 0x06000416 RID: 1046 RVA: 0x00087798 File Offset: 0x00085998
		public object #Pb(object[] #Qb, Type #Rb, object #Sb, CultureInfo #D)
		{
			#X0d.#V0d(#Qb, #Phc.#3hc(107386484), Component.DesktopControls, #Phc.#3hc(107386443));
			if (#Qb.Length != 2)
			{
				throw new InvalidOperationException(#Phc.#3hc(107386796));
			}
			IList list = #Qb[0] as IList;
			if (list == null || !list.Contains(#Qb[1]))
			{
				return string.Empty;
			}
			if (#Sb != null)
			{
				return ((#Sb != null) ? #Sb.ToString() : null) + (list.IndexOf(#Qb[1]) + 1).ToString();
			}
			return (list.IndexOf(#Qb[1]) + 1).ToString();
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x00008FC0 File Offset: 0x000071C0
		public object[] #Tb(object #f, Type[] #Rb, object #Sb, CultureInfo #D)
		{
			throw new NotSupportedException();
		}
	}
}
