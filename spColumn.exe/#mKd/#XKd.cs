using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Media;
using #5Fd;
using #7hc;
using #Qcd;
using #Ted;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.Views;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Tabular.TelerikGrid;
using Telerik.Windows.Controls;

namespace #mKd
{
	// Token: 0x02000DC5 RID: 3525
	internal sealed class #XKd : NotifyPropertyChangedObjectBase
	{
		// Token: 0x06007F3F RID: 32575 RVA: 0x001BE0D4 File Offset: 0x001BC2D4
		public #XKd(Option #bA, #7Fd #odd, Color? #YKd = null)
		{
			if (#bA == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107280257));
			}
			this.#a = #odd;
			this.#g = new ResultsTableView();
			this.#f = new TelerikGridRenderer(this.View.GridView, #odd, #YKd);
			this.RequiresRefresh = true;
			this.ParentWidth = 500.0;
		}

		// Token: 0x17002629 RID: 9769
		// (get) Token: 0x06007F40 RID: 32576 RVA: 0x00067C4F File Offset: 0x00065E4F
		public TelerikGridRenderer GridRenderer { get; }

		// Token: 0x1700262A RID: 9770
		// (get) Token: 0x06007F41 RID: 32577 RVA: 0x00067C5B File Offset: 0x00065E5B
		public RadGridView RadGridView
		{
			get
			{
				return this.View.GridView;
			}
		}

		// Token: 0x1700262B RID: 9771
		// (get) Token: 0x06007F42 RID: 32578 RVA: 0x00067C70 File Offset: 0x00065E70
		public ResultsTableView View { get; }

		// Token: 0x1700262C RID: 9772
		// (get) Token: 0x06007F43 RID: 32579 RVA: 0x00067C7C File Offset: 0x00065E7C
		// (set) Token: 0x06007F44 RID: 32580 RVA: 0x00067C88 File Offset: 0x00065E88
		public double ParentWidth { get; set; }

		// Token: 0x1700262D RID: 9773
		// (get) Token: 0x06007F45 RID: 32581 RVA: 0x00067C99 File Offset: 0x00065E99
		// (set) Token: 0x06007F46 RID: 32582 RVA: 0x00067CA5 File Offset: 0x00065EA5
		public bool RequiresRefresh { get; set; }

		// Token: 0x1700262E RID: 9774
		// (get) Token: 0x06007F47 RID: 32583 RVA: 0x00067CB6 File Offset: 0x00065EB6
		// (set) Token: 0x06007F48 RID: 32584 RVA: 0x00067CC2 File Offset: 0x00065EC2
		public string Title
		{
			get
			{
				return this.#b;
			}
			set
			{
				if (\u0093.\u0015\u0003(this.#b, value))
				{
					this.#b = value;
					base.RaisePropertyChanged(#Phc.#3hc(107408142));
				}
			}
		}

		// Token: 0x1700262F RID: 9775
		// (get) Token: 0x06007F49 RID: 32585 RVA: 0x00067CFA File Offset: 0x00065EFA
		// (set) Token: 0x06007F4A RID: 32586 RVA: 0x00067D06 File Offset: 0x00065F06
		public string Notes
		{
			get
			{
				return this.#d;
			}
			set
			{
				if (\u0093.\u0015\u0003(this.#d, value))
				{
					this.#d = value;
					base.RaisePropertyChanged(#Phc.#3hc(107280280));
				}
			}
		}

		// Token: 0x17002630 RID: 9776
		// (get) Token: 0x06007F4B RID: 32587 RVA: 0x00067D3E File Offset: 0x00065F3E
		// (set) Token: 0x06007F4C RID: 32588 RVA: 0x00067D4A File Offset: 0x00065F4A
		public bool AreNotesAvailable
		{
			get
			{
				return this.#e;
			}
			set
			{
				if (this.#e != value)
				{
					this.#e = value;
					base.RaisePropertyChanged(#Phc.#3hc(107280239));
				}
			}
		}

		// Token: 0x06007F4D RID: 32589 RVA: 0x00067D78 File Offset: 0x00065F78
		public void #hhd()
		{
			this.GridRenderer.#hhd();
		}

		// Token: 0x06007F4E RID: 32590 RVA: 0x00067D91 File Offset: 0x00065F91
		public void #ihd(double #jhd)
		{
			this.GridRenderer.#ihd(#jhd);
		}

		// Token: 0x06007F4F RID: 32591 RVA: 0x001BE13C File Offset: 0x001BC33C
		public void #RKd(int #SKd)
		{
			int? num = this.#c;
			int num2 = #SKd;
			if (!(num.GetValueOrDefault() == num2 & num != null))
			{
				this.RequiresRefresh = true;
				this.#c = new int?(#SKd);
			}
		}

		// Token: 0x06007F50 RID: 32592 RVA: 0x001BE188 File Offset: 0x001BC388
		public void #ghd(#rgd #TKd)
		{
			if (this.RequiresRefresh)
			{
				#TKd.#pgd();
				if (this.GridRenderer.RenderMode == #Igd.#a || this.GridRenderer.RenderMode == #Igd.#c)
				{
					this.#UKd(#TKd.Notes);
					this.Title = #TKd.Header;
				}
				this.RequiresRefresh = false;
			}
			if (this.GridRenderer.RenderMode == #Igd.#a || this.GridRenderer.RenderMode == #Igd.#c)
			{
				this.AreNotesAvailable = !\u0003.\u0004(this.Notes);
			}
		}

		// Token: 0x06007F51 RID: 32593 RVA: 0x001BE230 File Offset: 0x001BC430
		private void #UKd(IReadOnlyList<string> #VKd)
		{
			#VKd = #VKd.Select(new Func<string, string>(this.#WKd)).ToList<string>();
			if (!#VKd.Any<string>())
			{
				this.Notes = null;
				this.Notes = #Phc.#3hc(107361293);
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string text in #VKd)
			{
				if (!string.Equals(text, Environment.NewLine, StringComparison.OrdinalIgnoreCase))
				{
					stringBuilder.Append(text);
				}
				stringBuilder.AppendLine();
			}
			this.Notes = stringBuilder.ToString().Trim();
		}

		// Token: 0x06007F52 RID: 32594 RVA: 0x00067DAB File Offset: 0x00065FAB
		[CompilerGenerated]
		private string #WKd(string #pdd)
		{
			return #qdd.#ndd(this.#a, #pdd);
		}

		// Token: 0x04003437 RID: 13367
		private readonly #7Fd #a;

		// Token: 0x04003438 RID: 13368
		private string #b;

		// Token: 0x04003439 RID: 13369
		private int? #c;

		// Token: 0x0400343A RID: 13370
		private string #d;

		// Token: 0x0400343B RID: 13371
		private bool #e;

		// Token: 0x0400343C RID: 13372
		[CompilerGenerated]
		private readonly TelerikGridRenderer #f;

		// Token: 0x0400343D RID: 13373
		[CompilerGenerated]
		private readonly ResultsTableView #g;

		// Token: 0x0400343E RID: 13374
		[CompilerGenerated]
		private double #h;

		// Token: 0x0400343F RID: 13375
		[CompilerGenerated]
		private bool #i;
	}
}
