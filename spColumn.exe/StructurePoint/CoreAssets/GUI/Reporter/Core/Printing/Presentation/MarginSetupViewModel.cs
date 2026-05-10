using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using #7hc;
using #LQc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Printing.Presentation
{
	// Token: 0x02000DAE RID: 3502
	public sealed class MarginSetupViewModel : NotifyPropertyChangedObjectWithValidation
	{
		// Token: 0x06007E8C RID: 32396 RVA: 0x001BC914 File Offset: 0x001BAB14
		public MarginSetupViewModel(#8Sc dialogService)
		{
			this.#a = dialogService;
			this.#b = new MarginsSetupWindow();
			this.#b.Owner = (Application.Current.Windows.OfType<Window>().FirstOrDefault(new Func<Window, bool>(MarginSetupViewModel.<>c.<>9.#gUb)) ?? Application.Current.MainWindow);
			this.#k = new DelegateCommand(new Action<object>(this.#6H));
			this.#j = new DelegateCommand(new Action<object>(this.#5H));
			this.#b.DataContext = this;
		}

		// Token: 0x170025EF RID: 9711
		// (get) Token: 0x06007E8D RID: 32397 RVA: 0x00067190 File Offset: 0x00065390
		// (set) Token: 0x06007E8E RID: 32398 RVA: 0x0006719C File Offset: 0x0006539C
		public double SmallChange
		{
			get
			{
				return this.#i;
			}
			set
			{
				if (this.#i != value)
				{
					this.#i = value;
					base.RaisePropertyChanged(#Phc.#3hc(107280567));
				}
			}
		}

		// Token: 0x170025F0 RID: 9712
		// (get) Token: 0x06007E8F RID: 32399 RVA: 0x000671CA File Offset: 0x000653CA
		// (set) Token: 0x06007E90 RID: 32400 RVA: 0x000671D6 File Offset: 0x000653D6
		public double Left
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
					this.#qJd(value, #Phc.#3hc(107280518));
					base.RaisePropertyChanged(#Phc.#3hc(107280518));
				}
			}
		}

		// Token: 0x170025F1 RID: 9713
		// (get) Token: 0x06007E91 RID: 32401 RVA: 0x00067215 File Offset: 0x00065415
		// (set) Token: 0x06007E92 RID: 32402 RVA: 0x00067221 File Offset: 0x00065421
		public string GroupBoxHeader
		{
			get
			{
				return this.#h;
			}
			set
			{
				if (\u0093.\u0015\u0003(this.#h, value))
				{
					this.#h = value;
					base.RaisePropertyChanged(#Phc.#3hc(107280541));
				}
			}
		}

		// Token: 0x170025F2 RID: 9714
		// (get) Token: 0x06007E93 RID: 32403 RVA: 0x00067259 File Offset: 0x00065459
		// (set) Token: 0x06007E94 RID: 32404 RVA: 0x00067265 File Offset: 0x00065465
		public double Bottom
		{
			get
			{
				return this.#g;
			}
			set
			{
				if (this.#g != value)
				{
					this.#g = value;
					this.#qJd(value, #Phc.#3hc(107280488));
					base.RaisePropertyChanged(#Phc.#3hc(107280488));
				}
			}
		}

		// Token: 0x170025F3 RID: 9715
		// (get) Token: 0x06007E95 RID: 32405 RVA: 0x000672A4 File Offset: 0x000654A4
		// (set) Token: 0x06007E96 RID: 32406 RVA: 0x000672B0 File Offset: 0x000654B0
		public double Right
		{
			get
			{
				return this.#f;
			}
			set
			{
				if (this.#f != value)
				{
					this.#f = value;
					this.#qJd(value, #Phc.#3hc(107280511));
					base.RaisePropertyChanged(#Phc.#3hc(107280511));
				}
			}
		}

		// Token: 0x170025F4 RID: 9716
		// (get) Token: 0x06007E97 RID: 32407 RVA: 0x000672EF File Offset: 0x000654EF
		// (set) Token: 0x06007E98 RID: 32408 RVA: 0x000672FB File Offset: 0x000654FB
		public double Top
		{
			get
			{
				return this.#d;
			}
			set
			{
				if (this.#d != value)
				{
					this.#d = value;
					this.#qJd(value, #Phc.#3hc(107280502));
					base.RaisePropertyChanged(#Phc.#3hc(107280502));
				}
			}
		}

		// Token: 0x170025F5 RID: 9717
		// (get) Token: 0x06007E99 RID: 32409 RVA: 0x0006733A File Offset: 0x0006553A
		public DelegateCommand OkCommand { get; }

		// Token: 0x170025F6 RID: 9718
		// (get) Token: 0x06007E9A RID: 32410 RVA: 0x00067346 File Offset: 0x00065546
		public DelegateCommand CancelCommand { get; }

		// Token: 0x06007E9B RID: 32411 RVA: 0x001BC9C0 File Offset: 0x001BABC0
		public bool #0Pb(PageMarginsViewModel #Rf, string #pJd)
		{
			this.#c = false;
			this.GroupBoxHeader = \u0015.\u009A(#Phc.#3hc(107280497), #pJd);
			this.SmallChange = ((\u0011.~\u0094(#pJd, #Phc.#3hc(107280476), StringComparison.OrdinalIgnoreCase) >= 0) ? 0.1 : 5.0);
			this.Top = #Rf.Top;
			this.Left = #Rf.Left;
			this.Right = #Rf.Right;
			this.Bottom = #Rf.Bottom;
			\u008B.~\u0094\u0002(this.#b);
			if (this.#c)
			{
				#Rf.Left = this.Left;
				#Rf.Right = this.Right;
				#Rf.Top = this.Top;
				#Rf.Bottom = this.Bottom;
			}
			return this.#c;
		}

		// Token: 0x06007E9C RID: 32412 RVA: 0x001BCAC0 File Offset: 0x001BACC0
		private void #5H(object #GA)
		{
			if (!this.HasErrors)
			{
				this.#c = true;
				\u0007.~\u0010(this.#b);
				return;
			}
			this.#a.#qn(StructurePoint.CoreAssets.GUI.Reporter.Core.Resources.Localization.StringPleaseFixValidationErrors.#z2d());
		}

		// Token: 0x06007E9D RID: 32413 RVA: 0x00067352 File Offset: 0x00065552
		private void #qJd(double #f, [CallerMemberName] string #z8c = null)
		{
			if (#f <= 0.0)
			{
				this.AddError(#z8c, StructurePoint.CoreAssets.GUI.Reporter.Core.Resources.Localization.StringTheValueMustBeGreaterThanZero.#z2d());
				return;
			}
			base.RemoveError(#z8c);
		}

		// Token: 0x06007E9E RID: 32414 RVA: 0x00067385 File Offset: 0x00065585
		private void #6H(object #GA)
		{
			\u0007.~\u0010(this.#b);
		}

		// Token: 0x040033DD RID: 13277
		private readonly #8Sc #a;

		// Token: 0x040033DE RID: 13278
		private readonly MarginsSetupWindow #b;

		// Token: 0x040033DF RID: 13279
		private bool #c;

		// Token: 0x040033E0 RID: 13280
		private double #d;

		// Token: 0x040033E1 RID: 13281
		private double #e;

		// Token: 0x040033E2 RID: 13282
		private double #f;

		// Token: 0x040033E3 RID: 13283
		private double #g;

		// Token: 0x040033E4 RID: 13284
		private string #h;

		// Token: 0x040033E5 RID: 13285
		private double #i;

		// Token: 0x040033E6 RID: 13286
		[CompilerGenerated]
		private readonly DelegateCommand #j;

		// Token: 0x040033E7 RID: 13287
		[CompilerGenerated]
		private readonly DelegateCommand #k;
	}
}
