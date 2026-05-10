using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using StructurePoint.CoreAssets.DataExchange.ExternFormat;

namespace #2ic
{
	// Token: 0x0200076F RID: 1903
	internal interface #Qjc
	{
		// Token: 0x17001281 RID: 4737
		// (get) Token: 0x06003D3A RID: 15674
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		List<#sjc> Arcs { get; }

		// Token: 0x17001282 RID: 4738
		// (get) Token: 0x06003D3B RID: 15675
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		List<#tjc> Circles { get; }

		// Token: 0x17001283 RID: 4739
		// (get) Token: 0x06003D3C RID: 15676
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		List<#fjc> Ellipses { get; }

		// Token: 0x17001284 RID: 4740
		// (get) Token: 0x06003D3D RID: 15677
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		List<ILine> Lines { get; }

		// Token: 0x17001285 RID: 4741
		// (get) Token: 0x06003D3E RID: 15678
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		List<IPoint> Points { get; }

		// Token: 0x17001286 RID: 4742
		// (get) Token: 0x06003D3F RID: 15679
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		List<#pjc> Polylines { get; }

		// Token: 0x17001287 RID: 4743
		// (get) Token: 0x06003D40 RID: 15680
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		List<#ljc> PolygonPolylines { get; }

		// Token: 0x17001288 RID: 4744
		// (get) Token: 0x06003D41 RID: 15681
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		List<#yjc> XLines { get; }

		// Token: 0x17001289 RID: 4745
		// (get) Token: 0x06003D42 RID: 15682
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		List<#jjc> Layers { get; }

		// Token: 0x1700128A RID: 4746
		// (get) Token: 0x06003D43 RID: 15683
		// (set) Token: 0x06003D44 RID: 15684
		ExternDrawingUnit DrawingUnit { get; set; }
	}
}
