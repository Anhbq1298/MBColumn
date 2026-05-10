using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.Framework.Tools.Selection
{
	// Token: 0x02000BBE RID: 3006
	public interface IEntitiesSelector
	{
		// Token: 0x06006260 RID: 25184
		void #uR(IEnumerable<object> #8f);

		// Token: 0x06006261 RID: 25185
		void #ljb(object #Rf);

		// Token: 0x06006262 RID: 25186
		void #rLc(IEnumerable<object> #8f);

		// Token: 0x06006263 RID: 25187
		void #rLc(object #Rf);

		// Token: 0x06006264 RID: 25188
		bool #sLc(object #Rf);

		// Token: 0x06006265 RID: 25189
		IReadOnlyList<object> #wLc(bool #xLc, Point3D? #Xrb, Point3D #Yrb);

		// Token: 0x06006266 RID: 25190
		[SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
		IReadOnlyList<object> #qLc();

		// Token: 0x17001BE7 RID: 7143
		// (get) Token: 0x06006267 RID: 25191
		// (set) Token: 0x06006268 RID: 25192
		bool IsActive { get; set; }

		// Token: 0x17001BE8 RID: 7144
		// (get) Token: 0x06006269 RID: 25193
		// (set) Token: 0x0600626A RID: 25194
		bool SupportsSnapping { get; set; }
	}
}
