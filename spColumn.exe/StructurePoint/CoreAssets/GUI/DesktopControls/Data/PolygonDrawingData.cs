using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A29 RID: 2601
	public sealed class PolygonDrawingData
	{
		// Token: 0x0600561D RID: 22045 RVA: 0x0004756E File Offset: 0x0004576E
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
		public PolygonDrawingData(IReadOnlyList<Point> points, bool isOpening)
		{
			#X0d.#V0d(points, #Phc.#3hc(107358670), Component.DesktopControls, #Phc.#3hc(107429557));
			this.Points = points;
			this.IsOpening = isOpening;
		}

		// Token: 0x170018CB RID: 6347
		// (get) Token: 0x0600561E RID: 22046 RVA: 0x0004759F File Offset: 0x0004579F
		// (set) Token: 0x0600561F RID: 22047 RVA: 0x000475AB File Offset: 0x000457AB
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public IReadOnlyList<Point> Points { get; private set; }

		// Token: 0x170018CC RID: 6348
		// (get) Token: 0x06005620 RID: 22048 RVA: 0x000475BC File Offset: 0x000457BC
		// (set) Token: 0x06005621 RID: 22049 RVA: 0x000475C8 File Offset: 0x000457C8
		public bool IsOpening { get; private set; }
	}
}
