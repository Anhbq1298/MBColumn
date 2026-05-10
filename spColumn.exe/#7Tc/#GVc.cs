using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #7Tc
{
	// Token: 0x02000C7B RID: 3195
	[DebuggerDisplay("Value: {DisplayValue}, Enabled: {IsEnabled}")]
	internal sealed class #GVc : NotifyPropertyChangedObjectBase, INotifyDataErrorInfo
	{
		// Token: 0x06006769 RID: 26473 RVA: 0x00052BA3 File Offset: 0x00050DA3
		public #GVc()
		{
			this.RoundingDecimals = 3;
			this.#g = null;
			this.#f = true;
		}

		// Token: 0x17001CB8 RID: 7352
		// (get) Token: 0x0600676A RID: 26474 RVA: 0x00052BC0 File Offset: 0x00050DC0
		// (set) Token: 0x0600676B RID: 26475 RVA: 0x00052BC8 File Offset: 0x00050DC8
		public int RoundingDecimals { get; set; }

		// Token: 0x17001CB9 RID: 7353
		// (get) Token: 0x0600676C RID: 26476 RVA: 0x00052BD1 File Offset: 0x00050DD1
		// (set) Token: 0x0600676D RID: 26477 RVA: 0x00193DB0 File Offset: 0x00191FB0
		public double? Min
		{
			get
			{
				return this.#d;
			}
			set
			{
				double? num = this.#d;
				double? num2;
				if (-1 != 0)
				{
					num2 = num;
				}
				for (;;)
				{
					if (2 != 0)
					{
						double? num3;
						if (!false)
						{
							num3 = value;
						}
						if (!(num2.GetValueOrDefault() == num3.GetValueOrDefault() & num2 != null == (num3 != null)))
						{
							goto IL_35;
						}
						goto IL_5F;
					}
					IL_45:
					if (8 == 0)
					{
						continue;
					}
					this.#d = value;
					string propertyName = #Phc.#3hc(107440316);
					if (false)
					{
						goto IL_5F;
					}
					base.RaisePropertyChanged(propertyName);
					goto IL_5F;
					IL_35:
					string propertyName2 = #Phc.#3hc(107440316);
					if (false)
					{
						goto IL_45;
					}
					base.RaisePropertyChanging(propertyName2);
					goto IL_45;
					IL_5F:
					if (5 != 0)
					{
						break;
					}
					goto IL_35;
				}
			}
		}

		// Token: 0x17001CBA RID: 7354
		// (get) Token: 0x0600676E RID: 26478 RVA: 0x00052BD9 File Offset: 0x00050DD9
		// (set) Token: 0x0600676F RID: 26479 RVA: 0x00193E34 File Offset: 0x00192034
		public double? Max
		{
			get
			{
				return this.#e;
			}
			set
			{
				double? num = this.#e;
				double? num2;
				if (-1 != 0)
				{
					num2 = num;
				}
				for (;;)
				{
					if (2 != 0)
					{
						double? num3;
						if (!false)
						{
							num3 = value;
						}
						if (!(num2.GetValueOrDefault() == num3.GetValueOrDefault() & num2 != null == (num3 != null)))
						{
							goto IL_35;
						}
						goto IL_5F;
					}
					IL_45:
					if (8 == 0)
					{
						continue;
					}
					this.#e = value;
					string propertyName = #Phc.#3hc(107440311);
					if (false)
					{
						goto IL_5F;
					}
					base.RaisePropertyChanged(propertyName);
					goto IL_5F;
					IL_35:
					string propertyName2 = #Phc.#3hc(107440311);
					if (false)
					{
						goto IL_45;
					}
					base.RaisePropertyChanging(propertyName2);
					goto IL_45;
					IL_5F:
					if (5 != 0)
					{
						break;
					}
					goto IL_35;
				}
			}
		}

		// Token: 0x17001CBB RID: 7355
		// (get) Token: 0x06006770 RID: 26480 RVA: 0x00052BE1 File Offset: 0x00050DE1
		// (set) Token: 0x06006771 RID: 26481 RVA: 0x00193EB8 File Offset: 0x001920B8
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public bool IsEnabled
		{
			get
			{
				return this.#f;
			}
			set
			{
				for (;;)
				{
					if (this.#f == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107408148);
					if (5 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IL_19:
					if (3 != 0)
					{
						if (false)
						{
							continue;
						}
						this.#f = value;
						string propertyName2 = #Phc.#3hc(107408148);
						if (!false)
						{
							base.RaisePropertyChanged(propertyName2);
						}
					}
					IL_36:
					if (true)
					{
						break;
					}
					goto IL_19;
				}
			}
		}

		// Token: 0x17001CBC RID: 7356
		// (get) Token: 0x06006772 RID: 26482 RVA: 0x00052BE9 File Offset: 0x00050DE9
		public double CalculatedValue
		{
			get
			{
				return this.#c;
			}
		}

		// Token: 0x17001CBD RID: 7357
		// (get) Token: 0x06006773 RID: 26483 RVA: 0x00052BF1 File Offset: 0x00050DF1
		// (set) Token: 0x06006774 RID: 26484 RVA: 0x00193F0C File Offset: 0x0019210C
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		public string DisplayValue
		{
			get
			{
				return this.#b;
			}
			set
			{
				if (this.#b != value)
				{
					string propertyName = #Phc.#3hc(107462980);
					if (!false)
					{
						base.RaisePropertyChanging(propertyName);
					}
					this.#b = value;
					string propertyName2 = #Phc.#3hc(107462980);
					if (!false)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x06006775 RID: 26485 RVA: 0x00052BF9 File Offset: 0x00050DF9
		public void #yVc(string #nzb, bool #zVc)
		{
			this.#g = #nzb;
			if (#zVc && !false)
			{
				this.#FVc();
			}
		}

		// Token: 0x06006776 RID: 26486 RVA: 0x00052C11 File Offset: 0x00050E11
		public void #AVc(bool #zVc)
		{
			this.#g = null;
			if (#zVc && !false)
			{
				this.#FVc();
			}
		}

		// Token: 0x06006777 RID: 26487 RVA: 0x00052C29 File Offset: 0x00050E29
		public void #BVc(double #f)
		{
			string text = this.#DVc(#f);
			if (4 != 0)
			{
				this.DisplayValue = text;
			}
			this.#c = #f;
		}

		// Token: 0x06006778 RID: 26488 RVA: 0x00193F5C File Offset: 0x0019215C
		public void #CVc()
		{
			double num;
			if (this.#EVc(this.#b, out num))
			{
				do
				{
					double num2;
					double value = num2 = this.#c;
					if (!false)
					{
						num2 = Math.Round(value, this.RoundingDecimals);
					}
					if (num2 == num)
					{
						return;
					}
				}
				while (false);
				if (!false)
				{
					this.#c = num;
				}
			}
		}

		// Token: 0x06006779 RID: 26489 RVA: 0x00193FA0 File Offset: 0x001921A0
		public string #IH()
		{
			double num;
			if (!this.#EVc(this.#b, out num))
			{
				return Strings.StringTheInputStringWasNotInCorrectFormat.#z2d();
			}
			double? num2 = this.Min;
			double? num3;
			if (-1 != 0)
			{
				num3 = num2;
			}
			double num5;
			if (num3 != null)
			{
				double num4 = num5 = num;
				double? num6 = this.Min;
				if (2 != 0)
				{
					num3 = num6;
				}
				if (7 == 0)
				{
					goto IL_8F;
				}
				if (num4 < num3.Value)
				{
					string stringTheValueIsSmallerThanTheMinimumAllowedValue = Strings.StringTheValueIsSmallerThanTheMinimumAllowedValue;
					object[] array = new object[1];
					int num7 = 0;
					double? num8 = this.Min;
					if (7 != 0)
					{
						num3 = num8;
					}
					array[num7] = this.#DVc(num3.Value);
					return stringTheValueIsSmallerThanTheMinimumAllowedValue.#D2d(array).#z2d();
				}
			}
			double? num9 = this.Max;
			if (!false)
			{
				num3 = num9;
			}
			if (num3 == null)
			{
				goto IL_D2;
			}
			num5 = num;
			IL_8F:
			double? num10 = this.Max;
			if (8 != 0)
			{
				num3 = num10;
			}
			if (num5 > num3.Value)
			{
				string stringTheValueIsGreaterThanTheMaximumAllowedValue = Strings.StringTheValueIsGreaterThanTheMaximumAllowedValue;
				object[] array2 = new object[1];
				int num11 = 0;
				double? num12 = this.Max;
				if (!false)
				{
					num3 = num12;
				}
				array2[num11] = this.#DVc(num3.Value);
				return stringTheValueIsGreaterThanTheMaximumAllowedValue.#D2d(array2).#z2d();
			}
			IL_D2:
			return null;
		}

		// Token: 0x0600677A RID: 26490 RVA: 0x0019409C File Offset: 0x0019229C
		private string #DVc(double #f)
		{
			double num = Math.Round(#f, this.RoundingDecimals);
			double num2;
			if (4 != 0)
			{
				num2 = num;
			}
			return num2.ToString(CultureInfo.CurrentCulture);
		}

		// Token: 0x0600677B RID: 26491 RVA: 0x00052C46 File Offset: 0x00050E46
		private bool #EVc(string #f, out double #kmc)
		{
			int num = double.TryParse(#f, NumberStyles.Any, CultureInfo.CurrentCulture, out #kmc) ? 1 : 0;
			for (;;)
			{
				if (num != 0)
				{
					do
					{
						#kmc = Math.Round(#kmc, this.RoundingDecimals);
					}
					while (false);
					if (!false)
					{
						break;
					}
				}
				int num2 = num = 0;
				if (num2 == 0)
				{
					return num2 != 0;
				}
			}
			return true;
		}

		// Token: 0x1400018E RID: 398
		// (add) Token: 0x0600677C RID: 26492 RVA: 0x001940C8 File Offset: 0x001922C8
		// (remove) Token: 0x0600677D RID: 26493 RVA: 0x00194120 File Offset: 0x00192320
		public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged
		{
			[CompilerGenerated]
			add
			{
				if (!false)
				{
					EventHandler<DataErrorsChangedEventArgs> eventHandler2;
					if (!false)
					{
						EventHandler<DataErrorsChangedEventArgs> eventHandler = this.#i;
						if (!false)
						{
							eventHandler2 = eventHandler;
						}
					}
					EventHandler<DataErrorsChangedEventArgs> eventHandler4;
					do
					{
						if (7 != 0)
						{
							EventHandler<DataErrorsChangedEventArgs> eventHandler3 = eventHandler2;
							if (3 != 0)
							{
								eventHandler4 = eventHandler3;
							}
							EventHandler<DataErrorsChangedEventArgs> eventHandler5 = (EventHandler<DataErrorsChangedEventArgs>)Delegate.Combine(eventHandler4, value);
							EventHandler<DataErrorsChangedEventArgs> value2;
							if (-1 != 0)
							{
								value2 = eventHandler5;
							}
							EventHandler<DataErrorsChangedEventArgs> eventHandler6 = Interlocked.CompareExchange<EventHandler<DataErrorsChangedEventArgs>>(ref this.#i, value2, eventHandler4);
							if (6 != 0)
							{
								eventHandler2 = eventHandler6;
							}
						}
					}
					while (eventHandler2 != eventHandler4);
				}
			}
			[CompilerGenerated]
			remove
			{
				if (!false)
				{
					EventHandler<DataErrorsChangedEventArgs> eventHandler2;
					if (!false)
					{
						EventHandler<DataErrorsChangedEventArgs> eventHandler = this.#i;
						if (!false)
						{
							eventHandler2 = eventHandler;
						}
					}
					EventHandler<DataErrorsChangedEventArgs> eventHandler4;
					do
					{
						if (7 != 0)
						{
							EventHandler<DataErrorsChangedEventArgs> eventHandler3 = eventHandler2;
							if (3 != 0)
							{
								eventHandler4 = eventHandler3;
							}
							EventHandler<DataErrorsChangedEventArgs> eventHandler5 = (EventHandler<DataErrorsChangedEventArgs>)Delegate.Remove(eventHandler4, value);
							EventHandler<DataErrorsChangedEventArgs> value2;
							if (-1 != 0)
							{
								value2 = eventHandler5;
							}
							EventHandler<DataErrorsChangedEventArgs> eventHandler6 = Interlocked.CompareExchange<EventHandler<DataErrorsChangedEventArgs>>(ref this.#i, value2, eventHandler4);
							if (6 != 0)
							{
								eventHandler2 = eventHandler6;
							}
						}
					}
					while (eventHandler2 != eventHandler4);
				}
			}
		}

		// Token: 0x0600677E RID: 26494 RVA: 0x00194178 File Offset: 0x00192378
		private void #FVc()
		{
			EventHandler<DataErrorsChangedEventArgs> eventHandler = this.#i;
			EventHandler<DataErrorsChangedEventArgs> eventHandler2;
			if (3 != 0)
			{
				eventHandler2 = eventHandler;
			}
			if (eventHandler2 != null)
			{
				EventHandler<DataErrorsChangedEventArgs> eventHandler3 = eventHandler2;
				ParameterExpression parameterExpression = Expression.Parameter(typeof(#GVc), #Phc.#3hc(107398878));
				ParameterExpression parameterExpression2;
				if (!false)
				{
					parameterExpression2 = parameterExpression;
				}
				DataErrorsChangedEventArgs e = new DataErrorsChangedEventArgs(#x0d<#GVc>.#XYd<string>(Expression.Lambda<Func<#GVc, string>>(Expression.Property(Expression.Constant(this, typeof(#GVc)), methodof(#GVc.#sl())), new ParameterExpression[]
				{
					parameterExpression2
				})).Name);
				if (3 != 0)
				{
					eventHandler3(this, e);
				}
			}
		}

		// Token: 0x0600677F RID: 26495 RVA: 0x00194208 File Offset: 0x00192408
		public IEnumerable #Azc(string #em)
		{
			List<string> list2;
			for (;;)
			{
				if (!false)
				{
					List<string> list = new List<string>();
					if (!false)
					{
						list2 = list;
					}
				}
				if (this.#g == null)
				{
					goto IL_23;
				}
				IL_14:
				if (false)
				{
					continue;
				}
				List<string> list3 = list2;
				string item = this.#g;
				if (!false)
				{
					list3.Add(item);
				}
				IL_23:
				if (!false)
				{
					break;
				}
				goto IL_14;
			}
			return list2;
		}

		// Token: 0x17001CBE RID: 7358
		// (get) Token: 0x06006780 RID: 26496 RVA: 0x00052C76 File Offset: 0x00050E76
		public bool HasErrors
		{
			get
			{
				return this.#g != null;
			}
		}

		// Token: 0x04002AA3 RID: 10915
		private const int #a = 3;

		// Token: 0x04002AA4 RID: 10916
		private string #b;

		// Token: 0x04002AA5 RID: 10917
		private double #c;

		// Token: 0x04002AA6 RID: 10918
		private double? #d;

		// Token: 0x04002AA7 RID: 10919
		private double? #e;

		// Token: 0x04002AA8 RID: 10920
		private bool #f;

		// Token: 0x04002AA9 RID: 10921
		private string #g;

		// Token: 0x04002AAA RID: 10922
		[CompilerGenerated]
		private int #h;

		// Token: 0x04002AAB RID: 10923
		[CompilerGenerated]
		private EventHandler<DataErrorsChangedEventArgs> #i;
	}
}
