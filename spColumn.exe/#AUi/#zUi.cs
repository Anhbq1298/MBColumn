using System;
using System.IO;
using #7hc;
using #MYe;
using #v1c;
using #Wse;
using #X7e;
using #z5e;
using Alphaleonis.Win32.Filesystem;
using StructurePoint.CoreAssets.GUI.Framework.IO;
using StructurePoint.Products.Column.BatchExecution.Execution;

namespace #AUi
{
	// Token: 0x020006EA RID: 1770
	internal sealed class #zUi
	{
		// Token: 0x06003ACD RID: 15053 RVA: 0x00032FCA File Offset: 0x000311CA
		public #zUi(ProjectExecutionParameters #Pc)
		{
			this.#a = #Pc;
			this.#b = new FileSystemService();
		}

		// Token: 0x06003ACE RID: 15054 RVA: 0x00115CC4 File Offset: 0x00113EC4
		public void #xRb(#lte #Od)
		{
			if (((#Od != null) ? #Od.Output : null) == null)
			{
				return;
			}
			#38e #jMe = #28e.#18e(new #N5e((#A5e)#Od.Input.Options.Code));
			#1Ye #1Ye = new #1Ye(#Od.Output, #jMe);
			if (!string.IsNullOrWhiteSpace(this.#a.CsvDiagramPath))
			{
				string #So = this.#BRb();
				using (Stream stream = this.#b.#T1c(#So))
				{
					#1Ye.#ZYe(stream, #1Ye.#qp.#a, false);
				}
				if (this.#a.IncludeNominalDiagram)
				{
					#So = this.#DRb();
					using (Stream stream2 = this.#b.#T1c(#So))
					{
						#1Ye.#ZYe(stream2, #1Ye.#qp.#a, true);
					}
				}
			}
			if (!string.IsNullOrWhiteSpace(this.#a.TxtDiagramPath))
			{
				string #So2 = this.#CRb();
				using (Stream stream3 = this.#b.#T1c(#So2))
				{
					#1Ye.#ZYe(stream3, #1Ye.#qp.#b, false);
				}
				if (this.#a.IncludeNominalDiagram)
				{
					#So2 = this.#ERb();
					using (Stream stream4 = this.#b.#T1c(#So2))
					{
						#1Ye.#ZYe(stream4, #1Ye.#qp.#b, true);
					}
				}
			}
		}

		// Token: 0x06003ACF RID: 15055 RVA: 0x00032FE4 File Offset: 0x000311E4
		public string #BRb()
		{
			return this.#yRb(this.#a.CsvDiagramPath, #Phc.#3hc(107348408), #Phc.#3hc(107408483));
		}

		// Token: 0x06003AD0 RID: 15056 RVA: 0x00033017 File Offset: 0x00031217
		public string #CRb()
		{
			return this.#yRb(this.#a.TxtDiagramPath, #Phc.#3hc(107348408), #Phc.#3hc(107413479));
		}

		// Token: 0x06003AD1 RID: 15057 RVA: 0x0003304A File Offset: 0x0003124A
		public string #DRb()
		{
			return this.#yRb(this.#a.CsvDiagramPath, #Phc.#3hc(107348363), #Phc.#3hc(107408483));
		}

		// Token: 0x06003AD2 RID: 15058 RVA: 0x0003307D File Offset: 0x0003127D
		public string #ERb()
		{
			return this.#yRb(this.#a.TxtDiagramPath, #Phc.#3hc(107348363), #Phc.#3hc(107413479));
		}

		// Token: 0x06003AD3 RID: 15059 RVA: 0x00115E4C File Offset: 0x0011404C
		private string #yRb(string #zRb, string #C, string #In)
		{
			if (string.IsNullOrWhiteSpace(#zRb))
			{
				return null;
			}
			string text = Alphaleonis.Win32.Filesystem.Path.GetFileNameWithoutExtension(#zRb);
			text = text + #Phc.#3hc(107408434) + #C;
			#In = (((#In != null) ? #In.Trim() : null) ?? string.Empty);
			if (!string.IsNullOrWhiteSpace(#In) && !#In.StartsWith(#Phc.#3hc(107356879), StringComparison.Ordinal))
			{
				#In = #Phc.#3hc(107356879) + #In;
			}
			return Alphaleonis.Win32.Filesystem.Path.Combine(new string[]
			{
				Alphaleonis.Win32.Filesystem.Path.GetDirectoryName(#zRb),
				text
			}) + #In;
		}

		// Token: 0x04001909 RID: 6409
		private readonly ProjectExecutionParameters #a;

		// Token: 0x0400190A RID: 6410
		private readonly #v2c #b;
	}
}
