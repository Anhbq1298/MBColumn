using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Data;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.Products.Column.Model.Entities;

namespace #Wb
{
	// Token: 0x0200006A RID: 106
	internal sealed class #Vb : IMultiValueConverter
	{
		// Token: 0x0600040B RID: 1035 RVA: 0x000872C4 File Offset: 0x000854C4
		public object #Pb(object[] #Qb, Type #Rb, object #Sb, CultureInfo #D)
		{
			#Vb.#GTb #GTb = new #Vb.#GTb();
			#GTb.#a = #Qb;
			IList list = #GTb.#a[0] as IList;
			if (list != null && list.Contains(#GTb.#a[1]))
			{
				#X0d.#V0d(#GTb.#a, #Phc.#3hc(107386484), Component.DesktopControls, #Phc.#3hc(107386443));
				object obj = #GTb.#a.FirstOrDefault(new Func<object, bool>(#GTb.#FTb));
				ServiceLoad serviceLoad = obj as ServiceLoad;
				string format = #Phc.#3hc(107386422);
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendFormat(format, new object[]
				{
					#Phc.#3hc(107395517),
					serviceLoad.Dead.AxialLoad,
					serviceLoad.Dead.MomentXTop,
					serviceLoad.Dead.MomentXBottom,
					serviceLoad.Dead.MomentYTop,
					serviceLoad.Dead.MomentYBottom
				});
				stringBuilder.AppendFormat(format, new object[]
				{
					#Phc.#3hc(107386861),
					serviceLoad.Live.AxialLoad,
					serviceLoad.Live.MomentXTop,
					serviceLoad.Live.MomentXBottom,
					serviceLoad.Live.MomentYTop,
					serviceLoad.Live.MomentYBottom
				});
				stringBuilder.AppendFormat(format, new object[]
				{
					#Phc.#3hc(107386856),
					serviceLoad.Wind.AxialLoad,
					serviceLoad.Wind.MomentXTop,
					serviceLoad.Wind.MomentXBottom,
					serviceLoad.Wind.MomentYTop,
					serviceLoad.Wind.MomentYBottom
				});
				stringBuilder.AppendFormat(format, new object[]
				{
					#Phc.#3hc(107386851),
					serviceLoad.Earthquake.AxialLoad,
					serviceLoad.Earthquake.MomentXTop,
					serviceLoad.Earthquake.MomentXBottom,
					serviceLoad.Earthquake.MomentYTop,
					serviceLoad.Earthquake.MomentYBottom
				});
				stringBuilder.AppendFormat(format, new object[]
				{
					#Phc.#3hc(107386878),
					serviceLoad.Snow.AxialLoad,
					serviceLoad.Snow.MomentXTop,
					serviceLoad.Snow.MomentXBottom,
					serviceLoad.Snow.MomentYTop,
					serviceLoad.Snow.MomentYBottom
				});
				stringBuilder.Remove(stringBuilder.Length - 1, 1);
				return stringBuilder.ToString();
			}
			return string.Empty;
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x00008FC0 File Offset: 0x000071C0
		public object[] #Tb(object #f, Type[] #Ub, object #Sb, CultureInfo #D)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0200006B RID: 107
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x0600040F RID: 1039 RVA: 0x00008FCB File Offset: 0x000071CB
			internal bool #FTb(object #9o)
			{
				return #9o.Equals(this.#a[1]);
			}

			// Token: 0x0400009B RID: 155
			public object[] #a;
		}
	}
}
