using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using #7hc;
using #o1d;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.Navigation
{
	// Token: 0x02000E06 RID: 3590
	public class ReportContentVisibilityOption : NotifyPropertyChangedObjectBase
	{
		// Token: 0x06008139 RID: 33081 RVA: 0x001C2478 File Offset: 0x001C0678
		public ReportContentVisibilityOption(Option option, string name, ReportContentVisibilityOption parent = null, bool isHeader = false)
		{
			this.#k = parent;
			if (isHeader)
			{
				this.#m = Brushes.Black;
				this.#l = FontWeights.SemiBold;
				this.#i = FontStyles.Normal;
			}
			else
			{
				this.#l = FontWeights.Normal;
				this.#m = ReportContentVisibilityOption.#a;
				this.#i = FontStyles.Italic;
			}
			if (option == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107280257));
			}
			this.#j = option;
			this.Name = name;
			if (parent != null)
			{
				parent.Children.Add(this);
			}
			this.#h = isHeader;
			this.#n = new ObservableCollection<ReportContentVisibilityOption>();
			this.#o = new List<ReportContentVisibilityOption>();
			this.#e = false;
			this.#d = true;
		}

		// Token: 0x17002684 RID: 9860
		// (get) Token: 0x0600813A RID: 33082 RVA: 0x000693E7 File Offset: 0x000675E7
		public bool IsHeader { get; }

		// Token: 0x17002685 RID: 9861
		// (get) Token: 0x0600813B RID: 33083 RVA: 0x000693F3 File Offset: 0x000675F3
		public FontStyle FontStyle { get; }

		// Token: 0x17002686 RID: 9862
		// (get) Token: 0x0600813C RID: 33084 RVA: 0x000693FF File Offset: 0x000675FF
		public Option DocumentOption { get; }

		// Token: 0x17002687 RID: 9863
		// (get) Token: 0x0600813D RID: 33085 RVA: 0x0006940B File Offset: 0x0006760B
		// (set) Token: 0x0600813E RID: 33086 RVA: 0x00069417 File Offset: 0x00067617
		public bool IsExpanded
		{
			get
			{
				return this.#c;
			}
			set
			{
				if (this.#c != value)
				{
					this.#c = value;
					base.RaisePropertyChanged(#Phc.#3hc(107408133));
				}
			}
		}

		// Token: 0x17002688 RID: 9864
		// (get) Token: 0x0600813F RID: 33087 RVA: 0x00069445 File Offset: 0x00067645
		public ReportContentVisibilityOption Parent { get; }

		// Token: 0x17002689 RID: 9865
		// (get) Token: 0x06008140 RID: 33088 RVA: 0x00069451 File Offset: 0x00067651
		public FontWeight FontWeight { get; }

		// Token: 0x1700268A RID: 9866
		// (get) Token: 0x06008141 RID: 33089 RVA: 0x0006945D File Offset: 0x0006765D
		public Brush ForegroundColor { get; }

		// Token: 0x1700268B RID: 9867
		// (get) Token: 0x06008142 RID: 33090 RVA: 0x00069469 File Offset: 0x00067669
		public ObservableCollection<ReportContentVisibilityOption> Children { get; }

		// Token: 0x1700268C RID: 9868
		// (get) Token: 0x06008143 RID: 33091 RVA: 0x00069475 File Offset: 0x00067675
		public List<ReportContentVisibilityOption> LinkedOptions { get; }

		// Token: 0x1700268D RID: 9869
		// (get) Token: 0x06008144 RID: 33092 RVA: 0x00069481 File Offset: 0x00067681
		// (set) Token: 0x06008145 RID: 33093 RVA: 0x0006948D File Offset: 0x0006768D
		public bool IsSelected
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
					this.#RQd(true);
					base.RaisePropertyChanged(#Phc.#3hc(107407591));
				}
			}
		}

		// Token: 0x1700268E RID: 9870
		// (get) Token: 0x06008146 RID: 33094 RVA: 0x000694C2 File Offset: 0x000676C2
		// (set) Token: 0x06008147 RID: 33095 RVA: 0x000694DB File Offset: 0x000676DB
		public bool IsEnabled
		{
			get
			{
				return this.DocumentOption.IsEnabled;
			}
			set
			{
				if (this.DocumentOption.IsEnabled != value)
				{
					this.DocumentOption.IsEnabled = value;
					this.#SQd(value);
					base.RaisePropertyChanged(#Phc.#3hc(107408148));
				}
			}
		}

		// Token: 0x1700268F RID: 9871
		// (get) Token: 0x06008148 RID: 33096 RVA: 0x0006951A File Offset: 0x0006771A
		// (set) Token: 0x06008149 RID: 33097 RVA: 0x001C2554 File Offset: 0x001C0754
		public bool? IsChecked
		{
			get
			{
				return this.#b;
			}
			set
			{
				bool? flag = this.#b;
				bool? flag2 = value;
				if (!(flag.GetValueOrDefault() == flag2.GetValueOrDefault() & flag != null == (flag2 != null)))
				{
					this.#IQd(value, this.PropagateIsCheckedToLinkedOptions, false);
				}
			}
		}

		// Token: 0x17002690 RID: 9872
		// (get) Token: 0x0600814A RID: 33098 RVA: 0x00069526 File Offset: 0x00067726
		// (set) Token: 0x0600814B RID: 33099 RVA: 0x00069532 File Offset: 0x00067732
		public string Name
		{
			get
			{
				return this.#g;
			}
			set
			{
				if (\u0093.\u0015\u0003(this.#g, value))
				{
					this.#g = value;
					base.RaisePropertyChanged(#Phc.#3hc(107409209));
				}
			}
		}

		// Token: 0x17002691 RID: 9873
		// (get) Token: 0x0600814C RID: 33100 RVA: 0x0006956A File Offset: 0x0006776A
		// (set) Token: 0x0600814D RID: 33101 RVA: 0x00069576 File Offset: 0x00067776
		public bool IsCheckable
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
					base.RaisePropertyChanged(#Phc.#3hc(107466465));
				}
			}
		}

		// Token: 0x17002692 RID: 9874
		// (get) Token: 0x0600814E RID: 33102 RVA: 0x000695A4 File Offset: 0x000677A4
		// (set) Token: 0x0600814F RID: 33103 RVA: 0x000695B0 File Offset: 0x000677B0
		public bool ForceIsVisible
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
					base.RaisePropertyChanged(#Phc.#3hc(107278108));
				}
			}
		}

		// Token: 0x17002693 RID: 9875
		// (get) Token: 0x06008150 RID: 33104 RVA: 0x000695DE File Offset: 0x000677DE
		// (set) Token: 0x06008151 RID: 33105 RVA: 0x000695EA File Offset: 0x000677EA
		public bool PropagateIsCheckedToLinkedOptions { get; set; }

		// Token: 0x17002694 RID: 9876
		// (get) Token: 0x06008152 RID: 33106 RVA: 0x000695FB File Offset: 0x000677FB
		// (set) Token: 0x06008153 RID: 33107 RVA: 0x00069607 File Offset: 0x00067807
		public bool IsLinkedOptionsParent { get; set; }

		// Token: 0x06008154 RID: 33108 RVA: 0x001C25A8 File Offset: 0x001C07A8
		public void #IQd(bool? #f, bool #JQd, bool #KQd)
		{
			ReportContentVisibilityOption.#tWb #tWb = new ReportContentVisibilityOption.#tWb();
			#tWb.#a = #KQd;
			#tWb.#b = #JQd;
			#tWb.#c = this;
			this.#b = #f;
			if (#f != null)
			{
				if (#f.GetValueOrDefault())
				{
					if (this.IsLinkedOptionsParent)
					{
						this.DocumentOption.Value = new bool?(true);
						using (IEnumerator<ReportContentVisibilityOption> enumerator = this.Children.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								ReportContentVisibilityOption reportContentVisibilityOption = enumerator.Current;
								bool? flag = reportContentVisibilityOption.IsChecked;
								bool? flag2 = #f;
								if (flag.GetValueOrDefault() == flag2.GetValueOrDefault() & flag != null == (flag2 != null))
								{
									reportContentVisibilityOption.#PQd();
								}
								else
								{
									bool flag3 = reportContentVisibilityOption.LinkedOptions.All(new Func<ReportContentVisibilityOption, bool>(ReportContentVisibilityOption.<>c.<>9.#RWd));
									bool flag4 = reportContentVisibilityOption.LinkedOptions.Any(new Func<ReportContentVisibilityOption, bool>(ReportContentVisibilityOption.<>c.<>9.#SWd));
									if (#tWb.#a || reportContentVisibilityOption.IsEnabled)
									{
										reportContentVisibilityOption.#IQd(new bool?(flag4 || flag3), #tWb.#b, #tWb.#a);
									}
									if (reportContentVisibilityOption == this.Children.Last<ReportContentVisibilityOption>())
									{
										reportContentVisibilityOption.#PQd();
										this.DocumentOption.Value = this.IsChecked;
									}
								}
							}
							goto IL_219;
						}
					}
					this.Children.Where(new Func<ReportContentVisibilityOption, bool>(#tWb.#NWd)).#I1d(new Action<ReportContentVisibilityOption>(#tWb.#OWd));
					if (#tWb.#b)
					{
						this.#TQd(true);
					}
					this.DocumentOption.Value = new bool?(true);
				}
				else
				{
					this.Children.Where(new Func<ReportContentVisibilityOption, bool>(#tWb.#PWd)).#I1d(new Action<ReportContentVisibilityOption>(#tWb.#QWd));
					if (#tWb.#b)
					{
						this.#TQd(false);
					}
					this.DocumentOption.Value = new bool?(false);
				}
			}
			else
			{
				this.DocumentOption.Value = null;
			}
			IL_219:
			this.#PQd();
			base.RaisePropertyChanged<bool?>(() => this.#yQd);
		}

		// Token: 0x06008155 RID: 33109 RVA: 0x001C2830 File Offset: 0x001C0A30
		public void #LQd(bool? #f)
		{
			bool? flag = this.IsChecked;
			bool? flag2 = #f;
			if (!(flag.GetValueOrDefault() == flag2.GetValueOrDefault() & flag != null == (flag2 != null)))
			{
				this.#b = #f;
				this.DocumentOption.Value = #f;
				base.RaisePropertyChanged<bool?>(() => this.#yQd);
			}
		}

		// Token: 0x06008156 RID: 33110 RVA: 0x001C28CC File Offset: 0x001C0ACC
		public void #MQd()
		{
			base.RaisePropertyChanged<bool>(System.Linq.Expressions.Expression.Lambda<Func<bool>>(\u0089\u0005.\u0081\u000F(\u0087\u0005.\u007F\u000F(this, \u001E.\u000F\u0002(typeof(ReportContentVisibilityOption).TypeHandle)), (MethodInfo)\u0088\u0005.\u0080\u000F(methodof(ReportContentVisibilityOption.#yA()).MethodHandle)), new ParameterExpression[0]));
		}

		// Token: 0x06008157 RID: 33111 RVA: 0x001C2930 File Offset: 0x001C0B30
		public void #NQd()
		{
			this.IsExpanded = true;
			#hZd.#mbb<ReportContentVisibilityOption>(this.Children, new Func<ReportContentVisibilityOption, IEnumerable<ReportContentVisibilityOption>>(ReportContentVisibilityOption.<>c.<>9.#TWd), new Action<ReportContentVisibilityOption>(ReportContentVisibilityOption.<>c.<>9.#UWd));
		}

		// Token: 0x06008158 RID: 33112 RVA: 0x001C299C File Offset: 0x001C0B9C
		public void #OQd()
		{
			this.IsExpanded = false;
			#hZd.#mbb<ReportContentVisibilityOption>(this.Children, new Func<ReportContentVisibilityOption, IEnumerable<ReportContentVisibilityOption>>(ReportContentVisibilityOption.<>c.<>9.#VWd), new Action<ReportContentVisibilityOption>(ReportContentVisibilityOption.<>c.<>9.#WWd));
		}

		// Token: 0x06008159 RID: 33113 RVA: 0x001C2A08 File Offset: 0x001C0C08
		public void #PQd()
		{
			if (this.Parent == null)
			{
				return;
			}
			if (this.Parent.Children.Where(new Func<ReportContentVisibilityOption, bool>(ReportContentVisibilityOption.<>c.<>9.#XWd)).All(new Func<ReportContentVisibilityOption, bool>(ReportContentVisibilityOption.<>c.<>9.#YWd)))
			{
				this.Parent.IsChecked = new bool?(true);
			}
			else if (this.Parent.Children.Where(new Func<ReportContentVisibilityOption, bool>(ReportContentVisibilityOption.<>c.<>9.#ZWd)).All(new Func<ReportContentVisibilityOption, bool>(ReportContentVisibilityOption.<>c.<>9.#0Wd)))
			{
				this.Parent.IsChecked = new bool?(false);
			}
			else
			{
				this.Parent.IsChecked = null;
			}
			this.Parent.#PQd();
		}

		// Token: 0x0600815A RID: 33114 RVA: 0x001C2B2C File Offset: 0x001C0D2C
		public void #QQd(bool #f)
		{
			bool? flag = this.#b;
			bool flag2 = #f;
			if (!(flag.GetValueOrDefault() == flag2 & flag != null))
			{
				this.#b = new bool?(#f);
				this.DocumentOption.Value = new bool?(#f);
				this.#PQd();
				base.RaisePropertyChanged<bool?>(System.Linq.Expressions.Expression.Lambda<Func<bool?>>(\u0089\u0005.\u0081\u000F(\u0087\u0005.\u007F\u000F(this, \u001E.\u000F\u0002(typeof(ReportContentVisibilityOption).TypeHandle)), (MethodInfo)\u0088\u0005.\u0080\u000F(methodof(ReportContentVisibilityOption.#yQd()).MethodHandle)), new ParameterExpression[0]));
			}
		}

		// Token: 0x0600815B RID: 33115 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #RQd(bool #0r)
		{
		}

		// Token: 0x0600815C RID: 33116 RVA: 0x001C2BE0 File Offset: 0x001C0DE0
		private void #SQd(bool #f)
		{
			this.DocumentOption.IsEnabled = #f;
			IEnumerator<ReportContentVisibilityOption> enumerator = this.Children.GetEnumerator();
			try
			{
				while (\u0010\u0002.~\u0019\u0004(enumerator))
				{
					enumerator.Current.IsEnabled = #f;
				}
			}
			finally
			{
				if (enumerator != null)
				{
					\u0007.~\u000E(enumerator);
				}
			}
		}

		// Token: 0x0600815D RID: 33117 RVA: 0x001C2C50 File Offset: 0x001C0E50
		private void #TQd(bool #f)
		{
			foreach (ReportContentVisibilityOption reportContentVisibilityOption in this.LinkedOptions)
			{
				ReportContentVisibilityOption reportContentVisibilityOption2 = reportContentVisibilityOption.Parent;
				if (reportContentVisibilityOption2 != null)
				{
					bool? flag = reportContentVisibilityOption2.IsChecked;
					bool flag2 = true;
					if ((flag.GetValueOrDefault() == flag2 & flag != null) || reportContentVisibilityOption2.IsChecked == null)
					{
						reportContentVisibilityOption.#QQd(#f);
					}
				}
			}
		}

		// Token: 0x04003504 RID: 13572
		private static readonly Brush #a = new SolidColorBrush(\u009E\u0005.\u009B\u000F(byte.MaxValue, 0, 112, 213));

		// Token: 0x04003505 RID: 13573
		private bool? #b = new bool?(true);

		// Token: 0x04003506 RID: 13574
		private bool #c = true;

		// Token: 0x04003507 RID: 13575
		private bool #d;

		// Token: 0x04003508 RID: 13576
		private bool #e;

		// Token: 0x04003509 RID: 13577
		private bool #f;

		// Token: 0x0400350A RID: 13578
		private string #g;

		// Token: 0x0400350B RID: 13579
		[CompilerGenerated]
		private readonly bool #h;

		// Token: 0x0400350C RID: 13580
		[CompilerGenerated]
		private readonly FontStyle #i;

		// Token: 0x0400350D RID: 13581
		[CompilerGenerated]
		private readonly Option #j;

		// Token: 0x0400350E RID: 13582
		[CompilerGenerated]
		private readonly ReportContentVisibilityOption #k;

		// Token: 0x0400350F RID: 13583
		[CompilerGenerated]
		private readonly FontWeight #l;

		// Token: 0x04003510 RID: 13584
		[CompilerGenerated]
		private readonly Brush #m;

		// Token: 0x04003511 RID: 13585
		[CompilerGenerated]
		private readonly ObservableCollection<ReportContentVisibilityOption> #n;

		// Token: 0x04003512 RID: 13586
		[CompilerGenerated]
		private readonly List<ReportContentVisibilityOption> #o;

		// Token: 0x04003513 RID: 13587
		[CompilerGenerated]
		private bool #p = true;

		// Token: 0x04003514 RID: 13588
		[CompilerGenerated]
		private bool #q;

		// Token: 0x02000E08 RID: 3592
		[CompilerGenerated]
		private sealed class #tWb
		{
			// Token: 0x0600816C RID: 33132 RVA: 0x00069689 File Offset: 0x00067889
			internal bool #NWd(ReportContentVisibilityOption #Rf)
			{
				return this.#a || #Rf.IsEnabled;
			}

			// Token: 0x0600816D RID: 33133 RVA: 0x000696A7 File Offset: 0x000678A7
			internal void #OWd(ReportContentVisibilityOption #Rf)
			{
				#Rf.#IQd(new bool?(true), this.#b, this.#a);
			}

			// Token: 0x0600816E RID: 33134 RVA: 0x00069689 File Offset: 0x00067889
			internal bool #PWd(ReportContentVisibilityOption #Rf)
			{
				return this.#a || #Rf.IsEnabled;
			}

			// Token: 0x0600816F RID: 33135 RVA: 0x000696CD File Offset: 0x000678CD
			internal void #QWd(ReportContentVisibilityOption #Rf)
			{
				#Rf.#IQd(new bool?(false), this.#b, this.#a);
			}

			// Token: 0x04003520 RID: 13600
			public bool #a;

			// Token: 0x04003521 RID: 13601
			public bool #b;

			// Token: 0x04003522 RID: 13602
			public ReportContentVisibilityOption #c;
		}
	}
}
