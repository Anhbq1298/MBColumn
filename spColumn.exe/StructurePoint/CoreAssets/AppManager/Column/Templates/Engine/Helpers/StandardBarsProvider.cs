using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.Helpers
{
	// Token: 0x0200108C RID: 4236
	public sealed class StandardBarsProvider
	{
		// Token: 0x060090B9 RID: 37049 RVA: 0x00074BD7 File Offset: 0x00072DD7
		public StandardBarsProvider(IList<StandardBar> bars)
		{
			this.Bars = bars;
			this.#a = bars.ToDictionary(new Func<StandardBar, int>(StandardBarsProvider.<>c.<>9.#8Zb));
		}

		// Token: 0x17002A0E RID: 10766
		// (get) Token: 0x060090BA RID: 37050 RVA: 0x00074C11 File Offset: 0x00072E11
		public IList<StandardBar> Bars { get; }

		// Token: 0x060090BB RID: 37051 RVA: 0x001EA6F4 File Offset: 0x001E88F4
		public static int? #vCb(string #f)
		{
			#f = ((#f != null) ? #f.Trim() : null);
			if (string.IsNullOrWhiteSpace(#f))
			{
				return null;
			}
			if (#f.StartsWith(#Phc.#3hc(107378801)))
			{
				#f = #f.Substring(1);
			}
			int value;
			if (int.TryParse(#f, NumberStyles.Integer, CultureInfo.InvariantCulture, out value))
			{
				return new int?(value);
			}
			return null;
		}

		// Token: 0x060090BC RID: 37052 RVA: 0x00074C19 File Offset: 0x00072E19
		public StandardBar #whe(int #hNb)
		{
			return this.#a.#F1d(#hNb);
		}

		// Token: 0x04003CD2 RID: 15570
		private readonly Dictionary<int, StandardBar> #a;

		// Token: 0x04003CD3 RID: 15571
		[CompilerGenerated]
		private readonly IList<StandardBar> #b;
	}
}
