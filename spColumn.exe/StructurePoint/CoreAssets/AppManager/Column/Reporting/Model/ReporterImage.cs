using System;
using System.Runtime.CompilerServices;
using #3Rd;
using #7hc;
using #hId;
using #owe;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Model
{
	// Token: 0x02001173 RID: 4467
	public sealed class ReporterImage
	{
		// Token: 0x0600976A RID: 38762 RVA: 0x00078799 File Offset: 0x00076999
		public ReporterImage(Diagram2DData diagram)
		{
			if (diagram == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107288897));
			}
			this.Diagram = diagram;
		}

		// Token: 0x17002BFF RID: 11263
		// (get) Token: 0x0600976B RID: 38763 RVA: 0x000787BC File Offset: 0x000769BC
		public Diagram2DData Diagram { get; }

		// Token: 0x17002C00 RID: 11264
		// (get) Token: 0x0600976C RID: 38764 RVA: 0x000787C4 File Offset: 0x000769C4
		public Diagram2DType DiagramType
		{
			get
			{
				return this.Diagram.DiagramType;
			}
		}

		// Token: 0x17002C01 RID: 11265
		// (get) Token: 0x0600976D RID: 38765 RVA: 0x000787D1 File Offset: 0x000769D1
		public double Diagram2DParameter
		{
			get
			{
				return this.Diagram.Parameter;
			}
		}

		// Token: 0x17002C02 RID: 11266
		// (get) Token: 0x0600976E RID: 38766 RVA: 0x000787DE File Offset: 0x000769DE
		// (set) Token: 0x0600976F RID: 38767 RVA: 0x000787E6 File Offset: 0x000769E6
		public #jJd PrintOptions { get; set; }

		// Token: 0x06009770 RID: 38768 RVA: 0x001FC8FC File Offset: 0x001FAAFC
		public void #Fte(#uwe #mA)
		{
			if (#mA == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107360163));
			}
			#oSd drawing = new #oSd
			{
				Label = this.Diagram.Description
			};
			string bookmarkName = string.Format(#Phc.#3hc(107288916), ++ReporterImage.#a, this.Diagram.Description);
			new ScreenshootOption(#mA.Screenshots, drawing, bookmarkName).Tag = this;
		}

		// Token: 0x0400410D RID: 16653
		private static int #a;

		// Token: 0x0400410E RID: 16654
		[CompilerGenerated]
		private readonly Diagram2DData #b;

		// Token: 0x0400410F RID: 16655
		[CompilerGenerated]
		private #jJd #c;
	}
}
