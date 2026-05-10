using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Media;
using #7hc;
using #Ted;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Tabular.TelerikGrid
{
	// Token: 0x02000423 RID: 1059
	public class GridDataRowCore : INotifyPropertyChanged
	{
		// Token: 0x06002671 RID: 9841 RVA: 0x0002422F File Offset: 0x0002242F
		public GridDataRowCore()
		{
			this.Background = Brushes.White;
		}

		// Token: 0x140000A9 RID: 169
		// (add) Token: 0x06002672 RID: 9842 RVA: 0x000D6754 File Offset: 0x000D4954
		// (remove) Token: 0x06002673 RID: 9843 RVA: 0x000D679C File Offset: 0x000D499C
		private event PropertyChangedEventHandler myPropertyChanged
		{
			[CompilerGenerated]
			add
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.#b;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)\u008D.\u0097\u0002(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.#b, value2, propertyChangedEventHandler2);
				}
				while (propertyChangedEventHandler != propertyChangedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.#b;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)\u008D.\u0098\u0002(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.#b, value2, propertyChangedEventHandler2);
				}
				while (propertyChangedEventHandler != propertyChangedEventHandler2);
			}
		}

		// Token: 0x140000AA RID: 170
		// (add) Token: 0x06002674 RID: 9844 RVA: 0x00024242 File Offset: 0x00022442
		// (remove) Token: 0x06002675 RID: 9845 RVA: 0x0002425F File Offset: 0x0002245F
		public event PropertyChangedEventHandler PropertyChanged
		{
			add
			{
				if (this.EnablePropertyChanged)
				{
					this.myPropertyChanged += value;
				}
			}
			remove
			{
				if (this.EnablePropertyChanged)
				{
					this.myPropertyChanged -= value;
				}
			}
		}

		// Token: 0x17000D02 RID: 3330
		// (get) Token: 0x06002676 RID: 9846 RVA: 0x0002427C File Offset: 0x0002247C
		// (set) Token: 0x06002677 RID: 9847 RVA: 0x00024288 File Offset: 0x00022488
		public bool EnablePropertyChanged { get; set; }

		// Token: 0x17000D03 RID: 3331
		// (get) Token: 0x06002678 RID: 9848 RVA: 0x00024299 File Offset: 0x00022499
		// (set) Token: 0x06002679 RID: 9849 RVA: 0x000242A5 File Offset: 0x000224A5
		public int RowIndex { get; set; }

		// Token: 0x17000D04 RID: 3332
		// (get) Token: 0x0600267A RID: 9850 RVA: 0x000242B6 File Offset: 0x000224B6
		// (set) Token: 0x0600267B RID: 9851 RVA: 0x000242C2 File Offset: 0x000224C2
		public Brush Background
		{
			get
			{
				return this.#a;
			}
			set
			{
				if (this.#a != value)
				{
					this.#a = value;
					this.#Fkb(new PropertyChangedEventArgs(#Phc.#3hc(107363120)));
				}
			}
		}

		// Token: 0x17000D05 RID: 3333
		// (get) Token: 0x0600267C RID: 9852 RVA: 0x000242F5 File Offset: 0x000224F5
		// (set) Token: 0x0600267D RID: 9853 RVA: 0x00024301 File Offset: 0x00022501
		public bool HasCustomBackground { get; private set; }

		// Token: 0x17000D06 RID: 3334
		// (get) Token: 0x0600267E RID: 9854 RVA: 0x00024312 File Offset: 0x00022512
		// (set) Token: 0x0600267F RID: 9855 RVA: 0x0002431E File Offset: 0x0002251E
		public bool AnyRowHasCustomBackground { get; set; }

		// Token: 0x17000D07 RID: 3335
		// (get) Token: 0x06002680 RID: 9856 RVA: 0x0002432F File Offset: 0x0002252F
		// (set) Token: 0x06002681 RID: 9857 RVA: 0x0002433B File Offset: 0x0002253B
		public object Metadata { get; set; }

		// Token: 0x06002682 RID: 9858 RVA: 0x0002434C File Offset: 0x0002254C
		public void #1gc(string #wy)
		{
			if (this.EnablePropertyChanged)
			{
				this.#Fkb(new PropertyChangedEventArgs(#wy));
			}
		}

		// Token: 0x06002683 RID: 9859 RVA: 0x0002436E File Offset: 0x0002256E
		public static string #4ed(int #4jb)
		{
			return #8ed.#4ed(#4jb);
		}

		// Token: 0x06002684 RID: 9860 RVA: 0x0002437E File Offset: 0x0002257E
		public static string #3ed(int #4jb)
		{
			return #8ed.#3ed(#4jb);
		}

		// Token: 0x06002685 RID: 9861 RVA: 0x0002438E File Offset: 0x0002258E
		public static string #2ed(int #4jb)
		{
			return #8ed.#2ed(#4jb);
		}

		// Token: 0x06002686 RID: 9862 RVA: 0x000D67E4 File Offset: 0x000D49E4
		public void #kfd(int #4jb, #Rhd #f)
		{
			if (!this.#sfd(#4jb, #f))
			{
				throw new InvalidOperationException(\u0005.\u0007(#Phc.#3hc(107253613), \u007F.~\u0014\u0002(\u0084.\u0086\u0002(this)), #4jb).#z2d());
			}
		}

		// Token: 0x06002687 RID: 9863 RVA: 0x000D6844 File Offset: 0x000D4A44
		public #Rhd #lfd(int #4jb)
		{
			#Rhd result;
			if (this.#rfd(#4jb, out result))
			{
				return result;
			}
			throw new InvalidOperationException(\u0005.\u0007(#Phc.#3hc(107253544), \u007F.~\u0014\u0002(\u0084.\u0086\u0002(this)), #4jb).#z2d());
		}

		// Token: 0x06002688 RID: 9864 RVA: 0x000D68A4 File Offset: 0x000D4AA4
		public void #mfd(int #4jb, string #f)
		{
			if (!this.#ufd(#4jb, #f))
			{
				throw new InvalidOperationException(\u0005.\u0007(#Phc.#3hc(107252963), \u007F.~\u0014\u0002(\u0084.\u0086\u0002(this)), #4jb).#z2d());
			}
		}

		// Token: 0x06002689 RID: 9865 RVA: 0x000D6904 File Offset: 0x000D4B04
		public string #nfd(int #4jb)
		{
			string result;
			if (this.#tfd(#4jb, out result))
			{
				return result;
			}
			throw new InvalidOperationException(\u0005.\u0007(#Phc.#3hc(107252926), \u007F.~\u0014\u0002(\u0084.\u0086\u0002(this)), #4jb).#z2d());
		}

		// Token: 0x0600268A RID: 9866 RVA: 0x000D6964 File Offset: 0x000D4B64
		public void #ofd(int #4jb, Brush #pfd)
		{
			this.HasCustomBackground = true;
			if (!this.#wfd(#4jb, #pfd))
			{
				throw new InvalidOperationException(\u0005.\u0007(#Phc.#3hc(107252857), \u007F.~\u0014\u0002(\u0084.\u0086\u0002(this)), #4jb).#z2d());
			}
		}

		// Token: 0x0600268B RID: 9867 RVA: 0x000D69C8 File Offset: 0x000D4BC8
		public Brush #qfd(int? #4jb)
		{
			if (#4jb == null)
			{
				return this.Background;
			}
			Brush result;
			if (this.#vfd(#4jb.Value, out result))
			{
				return result;
			}
			throw new InvalidOperationException(string.Format(#Phc.#3hc(107252792), base.GetType().Name, #4jb).#z2d());
		}

		// Token: 0x0600268C RID: 9868 RVA: 0x0002439E File Offset: 0x0002259E
		protected virtual bool #rfd(int #4jb, out #Rhd #f)
		{
			#f = null;
			return false;
		}

		// Token: 0x0600268D RID: 9869 RVA: 0x0000C78B File Offset: 0x0000A98B
		protected virtual bool #sfd(int #4jb, #Rhd #f)
		{
			return false;
		}

		// Token: 0x0600268E RID: 9870 RVA: 0x0002439E File Offset: 0x0002259E
		protected virtual bool #tfd(int #4jb, out string #f)
		{
			#f = null;
			return false;
		}

		// Token: 0x0600268F RID: 9871 RVA: 0x0000C78B File Offset: 0x0000A98B
		protected virtual bool #ufd(int #4jb, string #f)
		{
			return false;
		}

		// Token: 0x06002690 RID: 9872 RVA: 0x0002439E File Offset: 0x0002259E
		protected virtual bool #vfd(int #4jb, out Brush #f)
		{
			#f = null;
			return false;
		}

		// Token: 0x06002691 RID: 9873 RVA: 0x0000C78B File Offset: 0x0000A98B
		protected virtual bool #wfd(int #4jb, Brush #f)
		{
			return false;
		}

		// Token: 0x06002692 RID: 9874 RVA: 0x000D6A30 File Offset: 0x000D4C30
		public void #xfd(#kgd #yfd, Brush #pfd, int #zfd)
		{
			if (#yfd == null || #pfd == null || !#yfd.Highlight)
			{
				return;
			}
			if (#yfd.Mode == #ggd.#a)
			{
				this.Background = #pfd;
				return;
			}
			if (#yfd.Mode == #ggd.#b)
			{
				this.HasCustomBackground = true;
				this.#ofd(#zfd, #pfd);
			}
		}

		// Token: 0x06002693 RID: 9875 RVA: 0x000243A8 File Offset: 0x000225A8
		public string #Afd(int? #4jb)
		{
			if (#4jb == null)
			{
				return null;
			}
			#Rhd #Rhd = this.#lfd(#4jb.Value);
			if (#Rhd == null)
			{
				return null;
			}
			return #Rhd.TextValue;
		}

		// Token: 0x06002694 RID: 9876 RVA: 0x000D6A80 File Offset: 0x000D4C80
		public double? #Bfd(int? #4jb)
		{
			if (#4jb == null)
			{
				return null;
			}
			#Rhd #Rhd = this.#lfd(#4jb.Value);
			if (#Rhd == null)
			{
				return null;
			}
			return #Rhd.NumericValue;
		}

		// Token: 0x06002695 RID: 9877 RVA: 0x000D6ACC File Offset: 0x000D4CCC
		public int? #Cfd(int? #4jb)
		{
			double? num = this.#Bfd(#4jb);
			if (num == null)
			{
				return null;
			}
			return new int?((int)num.Value);
		}

		// Token: 0x06002696 RID: 9878 RVA: 0x000243D9 File Offset: 0x000225D9
		protected virtual void #Fkb(PropertyChangedEventArgs #He)
		{
			PropertyChangedEventHandler propertyChangedEventHandler = this.#b;
			if (propertyChangedEventHandler == null)
			{
				return;
			}
			propertyChangedEventHandler(this, #He);
		}

		// Token: 0x04000F3F RID: 3903
		private Brush #a;

		// Token: 0x04000F40 RID: 3904
		[CompilerGenerated]
		private PropertyChangedEventHandler #b;

		// Token: 0x04000F41 RID: 3905
		[CompilerGenerated]
		private bool #c;

		// Token: 0x04000F42 RID: 3906
		[CompilerGenerated]
		private int #d;

		// Token: 0x04000F43 RID: 3907
		[CompilerGenerated]
		private bool #e;

		// Token: 0x04000F44 RID: 3908
		[CompilerGenerated]
		private bool #f;

		// Token: 0x04000F45 RID: 3909
		[CompilerGenerated]
		private object #g;
	}
}
