using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.Geometry.Data
{
	// Token: 0x0200081C RID: 2076
	public sealed class ShapesIntersectionResult
	{
		// Token: 0x0600429E RID: 17054 RVA: 0x00136C18 File Offset: 0x00134E18
		public ShapesIntersectionResult(ShapeData shapeGeometryData, IEnumerable<PolygonData> intersections)
		{
			#X0d.#V0d(shapeGeometryData, #Phc.#3hc(107371956), Component.Geometry, #Phc.#3hc(107457031));
			#X0d.#V0d(intersections, #Phc.#3hc(107366582), Component.Geometry, #Phc.#3hc(107457522));
			this.ShapeGeometryData = shapeGeometryData;
			this.Intersections = intersections;
		}

		// Token: 0x170013AA RID: 5034
		// (get) Token: 0x0600429F RID: 17055 RVA: 0x00037EEB File Offset: 0x000360EB
		// (set) Token: 0x060042A0 RID: 17056 RVA: 0x00037EF7 File Offset: 0x000360F7
		public ShapeData ShapeGeometryData { get; private set; }

		// Token: 0x170013AB RID: 5035
		// (get) Token: 0x060042A1 RID: 17057 RVA: 0x00037F08 File Offset: 0x00036108
		// (set) Token: 0x060042A2 RID: 17058 RVA: 0x00037F14 File Offset: 0x00036114
		public IEnumerable<PolygonData> Intersections { get; private set; }

		// Token: 0x04001E05 RID: 7685
		[CompilerGenerated]
		private ShapeData #a;

		// Token: 0x04001E06 RID: 7686
		[CompilerGenerated]
		private IEnumerable<PolygonData> #b;
	}
}
