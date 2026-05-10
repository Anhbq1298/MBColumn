using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #NHe;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.Drawing
{
	// Token: 0x02001240 RID: 4672
	public sealed class LoadPointTempData
	{
		// Token: 0x17002D50 RID: 11600
		// (get) Token: 0x06009C89 RID: 40073 RVA: 0x0007B8D9 File Offset: 0x00079AD9
		// (set) Token: 0x06009C8A RID: 40074 RVA: 0x0007B8E1 File Offset: 0x00079AE1
		public LoadPointDrawingData Load { get; set; }

		// Token: 0x17002D51 RID: 11601
		// (get) Token: 0x06009C8B RID: 40075 RVA: 0x0007B8EA File Offset: 0x00079AEA
		// (set) Token: 0x06009C8C RID: 40076 RVA: 0x0007B8F2 File Offset: 0x00079AF2
		public bool IsSelected { get; set; }

		// Token: 0x17002D52 RID: 11602
		// (get) Token: 0x06009C8D RID: 40077 RVA: 0x0007B8FB File Offset: 0x00079AFB
		// (set) Token: 0x06009C8E RID: 40078 RVA: 0x0007B903 File Offset: 0x00079B03
		public bool IsInner { get; set; }

		// Token: 0x17002D53 RID: 11603
		// (get) Token: 0x06009C8F RID: 40079 RVA: 0x0007B90C File Offset: 0x00079B0C
		// (set) Token: 0x06009C90 RID: 40080 RVA: 0x0007B914 File Offset: 0x00079B14
		public bool IsExactlySelected { get; set; }

		// Token: 0x17002D54 RID: 11604
		// (get) Token: 0x06009C91 RID: 40081 RVA: 0x0007B91D File Offset: 0x00079B1D
		// (set) Token: 0x06009C92 RID: 40082 RVA: 0x0007B925 File Offset: 0x00079B25
		public bool IsInMiddleOfDiagram { get; set; }

		// Token: 0x17002D55 RID: 11605
		// (get) Token: 0x06009C93 RID: 40083 RVA: 0x0007B92E File Offset: 0x00079B2E
		// (set) Token: 0x06009C94 RID: 40084 RVA: 0x0007B936 File Offset: 0x00079B36
		public float LoadLength { get; set; }

		// Token: 0x17002D56 RID: 11606
		// (get) Token: 0x06009C95 RID: 40085 RVA: 0x0007B93F File Offset: 0x00079B3F
		// (set) Token: 0x06009C96 RID: 40086 RVA: 0x0007B947 File Offset: 0x00079B47
		internal #OJe ValidationData { get; set; }

		// Token: 0x06009C97 RID: 40087 RVA: 0x00212F64 File Offset: 0x00211164
		public static List<LoadPointTempData> #Qrb(IList<LoadPointTempData> #yjb, int #Rrb)
		{
			IEnumerable<LoadPointTempData> first = #yjb.Where(new Func<LoadPointTempData, bool>(LoadPointTempData.<>c.<>9.#mef)).ToList<LoadPointTempData>();
			IOrderedEnumerable<LoadPointTempData> second = #yjb.Where(new Func<LoadPointTempData, bool>(LoadPointTempData.<>c.<>9.#nef)).OrderByDescending(new Func<LoadPointTempData, double?>(LoadPointTempData.<>c.<>9.#oef));
			return first.Union(second).OrderByDescending(new Func<LoadPointTempData, bool>(LoadPointTempData.<>c.<>9.#pef)).ThenByDescending(new Func<LoadPointTempData, bool>(LoadPointTempData.<>c.<>9.#qef)).ThenByDescending(new Func<LoadPointTempData, double?>(LoadPointTempData.<>c.<>9.#ref)).Take(#Rrb).ToList<LoadPointTempData>();
		}

		// Token: 0x0400439B RID: 17307
		[CompilerGenerated]
		private LoadPointDrawingData #a;

		// Token: 0x0400439C RID: 17308
		[CompilerGenerated]
		private bool #b;

		// Token: 0x0400439D RID: 17309
		[CompilerGenerated]
		private bool #c;

		// Token: 0x0400439E RID: 17310
		[CompilerGenerated]
		private bool #d;

		// Token: 0x0400439F RID: 17311
		[CompilerGenerated]
		private bool #e;

		// Token: 0x040043A0 RID: 17312
		[CompilerGenerated]
		private float #f;

		// Token: 0x040043A1 RID: 17313
		[CompilerGenerated]
		private #OJe #g;
	}
}
