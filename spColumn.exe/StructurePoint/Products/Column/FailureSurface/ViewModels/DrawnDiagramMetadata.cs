using System;
using System.Collections.Generic;
using System.Linq;
using #6re;
using #7hc;
using #Oze;
using #Wse;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.DTO;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;

namespace StructurePoint.Products.Column.FailureSurface.ViewModels
{
	// Token: 0x02000408 RID: 1032
	internal sealed class DrawnDiagramMetadata
	{
		// Token: 0x06002460 RID: 9312 RVA: 0x000CF5B0 File Offset: 0x000CD7B0
		public DrawnDiagramMetadata(#lte model, Diagram2DType diagramType, double parameter, IList<SelectedLoadData> selectedLoads, #5re settings, double diagramWidth, double diagramHeight, #8re filters, #mAe superImposeContextDump)
		{
			this.#a = model;
			this.#b = diagramType;
			this.#c = parameter;
			this.#d = settings;
			this.#e = diagramWidth;
			this.#f = diagramHeight;
			this.#g = filters;
			IList<SelectedLoadData> list;
			if (selectedLoads == null)
			{
				list = null;
			}
			else
			{
				list = selectedLoads.Select(new Func<SelectedLoadData, SelectedLoadData>(DrawnDiagramMetadata.<>c.<>9.#gUb)).ToList<SelectedLoadData>();
			}
			this.#h = (list ?? new List<SelectedLoadData>());
			this.#i = superImposeContextDump;
		}

		// Token: 0x06002461 RID: 9313 RVA: 0x000CF644 File Offset: 0x000CD844
		public string #h()
		{
			SelectedLoadData selectedLoadData = this.#h.FirstOrDefault<SelectedLoadData>();
			string text;
			if (selectedLoadData == null)
			{
				text = null;
			}
			else
			{
				int? num = selectedLoadData.Number;
				text = ((num != null) ? num.GetValueOrDefault().ToString() : null);
			}
			string text2 = text ?? #Phc.#3hc(107362262);
			return string.Format(#Phc.#3hc(107362221), new object[]
			{
				this.#b,
				this.#c,
				this.#h.Count,
				text2
			});
		}

		// Token: 0x06002462 RID: 9314 RVA: 0x00022B59 File Offset: 0x00020D59
		public bool #e(DrawnDiagramMetadata #L0)
		{
			return this.#afb(#L0) && this.#bfb(#L0);
		}

		// Token: 0x06002463 RID: 9315 RVA: 0x000CF6F8 File Offset: 0x000CD8F8
		public bool #afb(DrawnDiagramMetadata #L0)
		{
			if (this.#a != #L0.#a)
			{
				return false;
			}
			if (this.#e != #L0.#e || this.#f != #L0.#f)
			{
				return false;
			}
			if (this.#b != #L0.#b)
			{
				return false;
			}
			if (this.#c != #L0.#c)
			{
				return false;
			}
			if (this.#h.Count != #L0.#h.Count)
			{
				return false;
			}
			if (this.#d.#Qhd(#L0.#d) != 0)
			{
				return false;
			}
			if (this.#g.#Qhd(#L0.#g) != 0)
			{
				return false;
			}
			for (int i = 0; i < this.#h.Count; i++)
			{
				SelectedLoadData selectedLoadData = this.#h[i];
				SelectedLoadData #Gfb = #L0.#h[i];
				if (!selectedLoadData.#e(#Gfb))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06002464 RID: 9316 RVA: 0x00022B79 File Offset: 0x00020D79
		public bool #bfb(DrawnDiagramMetadata #L0)
		{
			return this.#i.#e(#L0.#i);
		}

		// Token: 0x04000E81 RID: 3713
		private readonly #lte #a;

		// Token: 0x04000E82 RID: 3714
		private readonly Diagram2DType #b;

		// Token: 0x04000E83 RID: 3715
		private readonly double #c;

		// Token: 0x04000E84 RID: 3716
		private readonly #5re #d;

		// Token: 0x04000E85 RID: 3717
		private readonly double #e;

		// Token: 0x04000E86 RID: 3718
		private readonly double #f;

		// Token: 0x04000E87 RID: 3719
		private readonly #8re #g;

		// Token: 0x04000E88 RID: 3720
		private readonly IList<SelectedLoadData> #h;

		// Token: 0x04000E89 RID: 3721
		private readonly #mAe #i;
	}
}
